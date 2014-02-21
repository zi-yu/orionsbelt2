using System;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.MarketPlace
{
    public class AuctionHouseUtil
    {
        #region Public Methods

        /// <summary>
        /// Put a resource in the auction house
        /// </summary>
        /// <param name="item">Resource info</param>
        /// <param name="defenseFleet">If the resource is a ship this is the defense fleet of the home planet</param>
        /// <returns>Item id in the auction house</returns>
        public static int PutInAuction(IAuctionItem item, IFleetInfo defenseFleet)
        {
            return PutInAuction(item, defenseFleet, false, false);
        }

        /// <summary>
        /// Put a resource in the auction house
        /// </summary>
        /// <param name="item">Resource info</param>
        /// <param name="defenseFleet">If the resource is a ship this is the defense fleet of the home planet</param>
        /// <param name="isAdmin">Is make in administration mode</param>
        /// <param name="advertise">If is to advertise</param>
        /// <returns>Item id in the auction house</returns>
        public static int PutInAuction(IAuctionItem item, IFleetInfo defenseFleet, bool isAdmin, bool advertise)
        {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                try
                {
                    persistance.StartTransaction();
                    AuctionHouse auction = AddItemToAuction(persistance, item, advertise);

                    if (!isAdmin)
                    {
                        RemoveResources(item, defenseFleet);
                    }
                    
                    persistance.CommitTransaction();
                    return auction.Id;
                }catch(Exception)
                {
                    persistance.RollbackTransaction();
                    return 0;
                } 
            }
        }

        private static void RemoveResources(IAuctionItem item, IFleetInfo defenseFleet)
        {
            if (((AuctionHouseType) Enum.Parse(typeof (AuctionHouseType), item.IsComplexType.ToString()) &
                 (AuctionHouseType.Intrinsic | AuctionHouseType.Rare)) != 0)
            {
                PlayerUtils.Current.RemoveQuantity(RulesUtils.GetResource(item.ShortIdentifier),
                                                   item.Quantity);
                GameEngine.Persist(PlayerUtils.Current);
            }
            else
            {
                defenseFleet.Remove(item.ShortIdentifier, item.Quantity);
                GameEngine.Persist(defenseFleet);
                //naves
            }
        }

        private static AuctionHouse AddItemToAuction(IPersistance<AuctionHouse> persistance, IAuctionItem item, bool advertise)
        {
            AuctionHouse auction = persistance.Create();
            auction.Begin = Clock.Instance.Tick;
            auction.Buyout = item.Buyout;
            auction.CurrentBid = item.Bid;
            auction.Details = item.ShortIdentifier;
            auction.Quantity = item.Quantity;
            auction.HigherBidOwner = 0;
            auction.BuyedInTick = 0;
            auction.Owner = item.Owner;
            auction.Price = item.Bid;
            auction.ComplexNumber = item.IsComplexType;
            auction.Timeout = auction.Begin + item.Time;
            auction.OrionsPaid = 0;
            auction.Advertise = advertise;
            persistance.Update(auction);
            if(advertise)
            {
                Utils.Principal.Credits -= 5;
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                {
                    TransactionManager.AdvertiseTransaction(5, auction, persistance);
                    persistance2.Update(Utils.Principal);
                }
            }
            return auction;
        }

        /// <summary>
        /// Make a bid to an item
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="player">Principal that makes the bid</param>
        /// <param name="bid">Bid value</param>
        /// <returns>The operation result</returns>
        public static string MakeBid(int id, PlayerStorage player, int bid)
        {
            if (bid > player.Principal.Credits)
            {
                return "NoCredits";
            }
            
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                int prevPlayerId, prevBid;
                persistance.StartTransaction();
                IList<AuctionHouse> auctions = persistance.SelectById(id);
                if (0 == auctions.Count)
                {
                    return "InvalidItem";
                }
                if(bid <= auctions[0].CurrentBid)
                {
                    return "LowerBid";
                }

                if (bid >= auctions[0].Buyout && 0 != auctions[0].Buyout)
                {
                    return "GreaterThanBuyout";
                }
                prevPlayerId = auctions[0].HigherBidOwner;
                prevBid = auctions[0].CurrentBid;
                auctions[0].HigherBidOwner = player.Id;
                auctions[0].CurrentBid = bid;

                persistance.Update(auctions[0]);
                persistance.Flush();
                persistance.CommitTransaction();

                UpdateHistorical(bid, player, persistance, auctions);
                UpdatePrincipals(bid, player, persistance, prevPlayerId, prevBid);
            }
            return "Ok";
        }

        /// <summary>
        /// Make a bid to an item
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="player">Principal that makes the bid</param>
        /// <returns>The operation result</returns>
        public static string MakeBid(int id, PlayerStorage player)
        {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                int prevPlayerId, prevBid;
                persistance.StartTransaction();
                IList<AuctionHouse> auctions = persistance.SelectById(id);
                if (0 == auctions.Count)
                {
                    return "InvalidItem";
                }

                int bid;
                if (auctions[0].HigherBidOwner == 0)
                {
                    bid = auctions[0].CurrentBid;
                }
                else
                {
                    bid = CreditsUtil.GetNextBid(auctions[0].CurrentBid);
                }

                if (bid > player.Principal.Credits)
                {
                    return "NoCredits";
                }

                if (bid >= auctions[0].Buyout && 0 != auctions[0].Buyout)
                {
                    return "GreaterThanBuyout";
                }

                if (auctions[0].Owner.Principal == player.Principal && auctions[0].Owner.Id != player.Id)
                {
                    return "SamePrincipal";
                }

                if (auctions[0].BuyedInTick != 0)
                {
                    return "AlreadyBuyed";
                }

                prevPlayerId = auctions[0].HigherBidOwner;
                prevBid = auctions[0].CurrentBid;
                auctions[0].HigherBidOwner = player.Id;
                auctions[0].CurrentBid = bid;

                if(Clock.Instance.Tick + 1 == auctions[0].Timeout)
                {
                    auctions[0].Timeout += 1;
                }

                if (0 != prevPlayerId)
                {
                    Messenger.Add(Category.Player, typeof(OverbidMessage), prevPlayerId,
                            auctions[0].Quantity.ToString(), auctions[0].Details);
                }

                persistance.Update(auctions[0]);
                persistance.Flush();
                persistance.CommitTransaction();

                UpdateHistorical(bid, player, persistance, auctions);
                UpdatePrincipals(bid, player, persistance, prevPlayerId, prevBid);
            }
            return "Ok";
        }

        /// <summary>
        /// Buyout an item
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="player">Principal that makes the buyout</param>
        /// <returns>The operation result</returns>
        public static string MakeBuyout(int id, PlayerStorage player)
        {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                int prevPlayerId, prevBid;
                persistance.StartTransaction();
                IList<AuctionHouse> auctions = persistance.SelectById(id);

                if (0 == auctions.Count)
                {
                    return "InvalidItem";
                }
                if (0 == auctions[0].Buyout)
                {
                    return "NoBuyout";
                }

                if (0 != auctions[0].BuyedInTick)
                {
                    return "AlreadyBuyed";
                }

                if (player.Principal.Credits < auctions[0].Buyout)
                {
                    return "NoCredits";
                }

                if (auctions[0].Owner.Principal == player.Principal && auctions[0].Owner.Id != player.Id)
                {
                    return "SamePrincipalAccountError";
                }

                prevPlayerId = auctions[0].HigherBidOwner;
                prevBid = auctions[0].CurrentBid;
                auctions[0].HigherBidOwner = player.Id;
                auctions[0].CurrentBid = auctions[0].Buyout;
                auctions[0].BuyedInTick = Clock.Instance.Tick;
                auctions[0].OrionsPaid = CreditsUtil.GetValueWithoutTax(auctions[0].Buyout);

                if (0 != prevPlayerId)
                {
                    Messenger.Add(Category.Player, typeof(BidSoldMessage), prevPlayerId,
                            auctions[0].Quantity.ToString(), auctions[0].Details);
                }

                persistance.Update(auctions[0]);
                persistance.Flush();
                persistance.CommitTransaction();

                UpdateHistorical(auctions[0].Buyout, player, persistance, auctions);
                UpdatePrincipals(auctions[0].Owner, auctions[0].Buyout, player, persistance, prevPlayerId, prevBid, false);
                TransactionManager.AuctionHouseTransaction(auctions[0], player, persistance);

                Messenger.Add(Category.Player, typeof(SellerMessage), auctions[0].Owner.Id,
                    auctions[0].Quantity.ToString(), auctions[0].Details, auctions[0].OrionsPaid.ToString());

                Messenger.Add(Category.Player, typeof(BidBuyoutMessage), auctions[0].HigherBidOwner,
                    auctions[0].Quantity.ToString(), auctions[0].Details, auctions[0].Buyout.ToString());

                if (!Server.IsInTests)
                {
                    if (
                        ((AuctionHouseType) Enum.Parse(typeof (AuctionHouseType), auctions[0].ComplexNumber.ToString()) &
                         (AuctionHouseType.Intrinsic | AuctionHouseType.Rare | AuctionHouseType.Ultimate)) != 0)
                    {
                        IPlayer playerInfo = new Player(player);
                        IFleetInfo fleet = playerInfo.GetHomePlanet().DefenseFleet;
                        fleet.AddCargo(new ResourceQuantity(RulesUtils.GetResource(auctions[0].Details), auctions[0].Quantity));
                        //playerInfo.AddQuantity(RulesUtils.GetResource(auctions[0].Details), auctions[0].Quantity);
                        GameEngine.Persist(fleet);
                    }
                    else
                    {
                        //naves
                        IPlayer playerInfo = new Player(player);
                        IFleetInfo fleet = playerInfo.GetHomePlanet().DefenseFleet;
                        fleet.Add(auctions[0].Details, auctions[0].Quantity);
                        GameEngine.Persist(fleet);
                    }
                }
                persistance.Flush();
            }
            return "Ok";
        }

        /// <summary>
        /// Buyout an item only for administration
        /// </summary>
        /// <param name="id">Item id</param>
        /// <param name="player">Principal that makes the buyout</param>
        /// <returns>The operation result</returns>
        public static string MakeAdminBuyout(int id, PlayerStorage player)
        {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                int prevPlayerId, prevBid;
                persistance.StartTransaction();
                IList<AuctionHouse> auctions = persistance.SelectById(id);

                if (0 == auctions.Count)
                {
                    return "InvalidItem";
                }
                if (0 == auctions[0].Buyout)
                {
                    return "NoBuyout";
                }

                if (0 != auctions[0].BuyedInTick)
                {
                    return "AlreadyBuyed";
                }

                prevPlayerId = auctions[0].HigherBidOwner;
                prevBid = auctions[0].CurrentBid;
                auctions[0].HigherBidOwner = player.Id;
                auctions[0].CurrentBid = auctions[0].Buyout;
                auctions[0].BuyedInTick = Clock.Instance.Tick;
                auctions[0].OrionsPaid = CreditsUtil.GetValueWithoutTax(auctions[0].Buyout);

                persistance.Update(auctions[0]);
                persistance.Flush();
                persistance.CommitTransaction();

                UpdateHistorical(auctions[0].Buyout, player, persistance, auctions);
                UpdatePrincipals(auctions[0].Owner, auctions[0].Buyout, player, persistance, prevPlayerId, prevBid, true);
                TransactionManager.AuctionHouseTransaction(auctions[0], player, persistance);
                persistance.Flush();
            }
            return "Ok";
        }

        public static bool ValidatePlayers(PlayerStorage player)
        {
            /*
            if (player.ActivatedInTick != 0 && (player.ActivatedInTick+(144*3)) > Clock.Instance.Tick)
            {
                return false;
            }

            return true;
            */
            if(player.IsPrimary)
            {
                return true;
            }
            else
            {
                if ((player.ActivatedInTick + (144 * 10)) < Clock.Instance.Tick && player.ActivatedInTick != 0)
                {
                    PlayerUtils.Current.IsPrimary = true;
                    GameEngine.Persist(PlayerUtils.Current);
                    return true;
                }
                using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
                {
                    IList<PlayerStorage> players = persistance.SelectByPrincipal(player.Principal);
                    foreach (PlayerStorage storage in players)
                    {
                        if (storage.IsPrimary)
                        {
                            return false;
                        }
                    }
                }

                PlayerUtils.Current.IsPrimary = true;
                GameEngine.Persist(PlayerUtils.Current);
                return true;
            }
        }

        #endregion Public Methods

        #region Private Methods

        private static void UpdatePrincipals(PlayerStorage owner, int buyout, PlayerStorage player, IPersistanceSession persistance, int prevPrincipalId, int prevBid, bool isAdmin)
        {
            using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
            {
                if (!isAdmin)
                {
                    player.Principal.Credits -= buyout;
                    persistance2.Update(player.Principal);
                }
                if (0 != prevPrincipalId)
                {
                    IList<PlayerStorage> players;
                    using (IPlayerStoragePersistance persistance3 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                    {
                        players = persistance3.SelectById(prevPrincipalId);
                    }
                    players[0].Principal.Credits += prevBid;
                    persistance2.Update(players[0].Principal);
                }

                owner.Principal.Credits += (buyout - CreditsUtil.GetTax(buyout));
                persistance2.Update(owner.Principal);

                persistance2.Flush();
            }
        }

        private static void UpdatePrincipals(int bid, PlayerStorage player, IPersistanceSession persistance, int prevPrincipalId, int prevBid)
        {
            using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
            {
                player.Principal.Credits -= bid;
                persistance2.Update(player.Principal);
                if(0 != prevPrincipalId)
                {
                    IList<PlayerStorage> players;
                    using (IPlayerStoragePersistance persistance3 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                    {
                        players = persistance3.SelectById(prevPrincipalId);
                    }
                    players[0].Principal.Credits += prevBid;
                    persistance2.Update(players[0].Principal);
                }
                persistance2.Flush();
            }
        }

        private static void UpdateHistorical(int bid, PlayerStorage principal, IPersistanceSession persistance, IList<AuctionHouse> auctions)
        {
            using (IBidHistoricalPersistance persistance2 = Persistance.Instance.GetBidHistoricalPersistance(persistance))
            {
                BidHistorical bidHistory = persistance2.Create();
                bidHistory.MadeBy = principal;
                bidHistory.Resource = auctions[0];
                bidHistory.Date = DateTime.Now;
                bidHistory.Value = bid;
                persistance2.Update(bidHistory);
            }
        }

        #endregion Private Methods

        
    }
}
