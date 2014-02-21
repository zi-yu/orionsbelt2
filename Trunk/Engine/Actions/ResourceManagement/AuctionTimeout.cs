using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Battle Timeout
    /// </summary>
    public class AuctionTimeout : AutoRepeteAction {

        #region Ctor 

        public AuctionTimeout()
        {
			Start(1);
		}

        #endregion Ctor 

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        protected override void ProcessAction(bool forcedEnd) {
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                IList<AuctionHouse> items =
                    persistance.TypedQuery("select e from SpecializedAuctionHouse e where e.Timeout <= {0} and e.BuyedInTick = 0", CurrentTick);

                for(int iter = 0; iter < items.Count; ++iter)
                {

                    if (items[iter].HigherBidOwner == 0)
                    {
                        using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                        {
                            IList<PlayerStorage> playerStorage = persistance2.SelectById(items[iter].Owner.Id);
                            AddResource(iter, items, playerStorage, false);

                            items[iter].BuyedInTick = -1;
                            Messenger.Add(Category.Player, typeof(NotSoldMessage), items[iter].Owner.Id,
                                        items[iter].Quantity.ToString(), items[iter].Details);
                        }
                    }
                    else
                    {
                        IList<PlayerStorage> playerStorage;
                        //recursos para o items[iter].HigherBidOwner;
                        using (IPlayerStoragePersistance persistance2 = Persistance.Instance.GetPlayerStoragePersistance(persistance))
                        {
                            playerStorage = persistance2.SelectById(items[iter].HigherBidOwner);
                            AddResource(iter, items, playerStorage, true);

                            Messenger.Add(Category.Player, typeof(BidBuyoutMessage), items[iter].HigherBidOwner,
                                items[iter].Quantity.ToString(), items[iter].Details, items[iter].CurrentBid.ToString());
                        }

                        //creditar parte da bid;
                        using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                        {
                            items[iter].Owner.Principal.Credits += (items[iter].CurrentBid -
                                                                    CreditsUtil.GetTax(items[iter].CurrentBid));
                            persistance2.Update(items[iter].Owner.Principal);
                            TransactionManager.AuctionHouseTransaction(items[iter], playerStorage[0],persistance2);

                            Messenger.Add(Category.Player, typeof(SellerMessage), items[iter].Owner.Id,
                                        items[iter].Quantity.ToString(), items[iter].Details, 
                                        CreditsUtil.GetValueWithoutTax(items[iter].CurrentBid).ToString());
                        }
                        items[iter].BuyedInTick = CurrentTick;
                        items[iter].OrionsPaid = CreditsUtil.GetValueWithoutTax(items[iter].CurrentBid);
                    }
                    
                    persistance.Update(items[iter]);
                }
                persistance.Flush();
            }
        }

        private static void AddResource(int iter, IList<AuctionHouse> items, IList<PlayerStorage> playerStorage, bool wasSold)
        {
            IResourceInfo info = RulesUtils.GetResource(items[iter].Details);
            if (info.Type == ResourceType.Intrinsic || (info.AuctionType & AuctionHouseType.Ultimate) != 0)
            {
                IPlayer playerInfo = new Player(playerStorage[0]);
                IFleetInfo fleet = playerInfo.GetHomePlanet().DefenseFleet;
                if (wasSold)
                {
                    fleet.AddCargo(
                        new ResourceQuantity(RulesUtils.GetResource(items[iter].Details), items[iter].Quantity));
                    GameEngine.Persist(fleet);
                }else
                {
                    playerInfo.AddQuantity(RulesUtils.GetResource(items[iter].Details), items[iter].Quantity);
                    GameEngine.Persist(playerInfo);
                }
            }
            else
            {
                //naves
                IPlayer playerInfo = new Player(playerStorage[0]);
                IFleetInfo fleet = playerInfo.GetHomePlanet().DefenseFleet;
                fleet.Add(items[iter].Details, items[iter].Quantity);
                GameEngine.Persist(fleet);
            }
        }

        #endregion Base Implementation

    };

}
