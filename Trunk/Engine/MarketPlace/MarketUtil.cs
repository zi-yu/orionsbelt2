using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Results;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Universe;

namespace OrionsBelt.Engine.MarketPlace
{
    public class MarketUtil
    {

        #region Public Methods

        /// <summary>
        /// Buy a resource in a market
        /// </summary>
        /// <param name="market">The market where is made the buy</param>
        /// <param name="fleet">Fleet to get the cargo</param>
        /// <param name="player">Buyer</param>
        /// <param name="product">The resource to buy</param>
        /// <param name="toPay">The quantity of the product that is to buy</param>
        /// <returns>The success or insuccess of the operation</returns>
        public static Result BuyItem(Market market, Fleet fleet, PlayerStorage player, string product, int toPay)
        {
            if(toPay > player.Principal.Credits)
            {
                return new Result(new NotCredits());
            }

            Product prod = MarketHaveProduct(market, product);
            if(null == prod)
            {
                return new Result(new InvalidProduct("The product {0} does not exists in this market.", product));
            }

            if(prod.Type == ProductType.Rare.ToString())
            {
                if (prod.Quantity < toPay * prod.Price)
                {
                    return new Result(new NotProduct());
                }

                UpdatePrincipalAndQuantity(toPay, player, prod);
            }
            else
            {
                UpdatePrincipal(toPay, player);
            }
            TransactionManager.MarketTransaction(market,player,toPay,product);

            Messenger.Add(Category.Player, typeof(BuyInMarketMessage), player.Id,
                            (toPay * prod.Price).ToString(), product, market.Name, fleet.Name);

            if (!Server.IsInTests)
            {
                //IPlayer playerInfo = new Player(player);
                //toPay = credit number; price = X of the product for 1 credit
                //playerInfo.AddQuantity(RulesUtils.GetResource(product), toPay*prod.Price);
                IFleetInfo fleetInfo = new FleetInfo(fleet);
                fleetInfo.AddCargo(new ResourceQuantity(RulesUtils.GetResource(product), toPay * prod.Price));
                GameEngine.Persist(fleetInfo);
                Persistance.Flush();
            }

            return Result.Success;
        }

        public static int CreateMarket(string name, Coordinate system, Coordinate sector, int level, ISector isector)
        {
            using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance())
            {
                Market market = persistance.Create();
                market.Name = "Market"+name;
                market.Coordinates = string.Format("{0}:{1}:{2}:{3}", system.X, system.Y, sector.X, sector.Y);
                market.Level = level;
                market.Sector = isector.Storage;

                persistance.Update(market);
                
                using (IProductPersistance persistance2 = Persistance.Instance.GetProductPersistance(persistance))
                {
                    CreateProduct(market, "Serium", 16, persistance2);
                    CreateProduct(market, "Energy", 14, persistance2);
                    CreateProduct(market, "Elk", 14, persistance2);
                    CreateProduct(market, "Protol", 14, persistance2);
                    CreateProduct(market, "Gold", 14, persistance2);
                    CreateProduct(market, "Titanium", 16, persistance2);
                    if(level > 1)
                    {
                        CreateProduct(market, "Mithril", 12, persistance2);
                        CreateProduct(market, "Uranium", 12, persistance2);
                    }
                }

                persistance.Flush();
                return market.Id;
            }
        }

        public static IList<SectorCoordinate> GetNearMarkets(SectorCoordinate coord)
        {
            IList<SectorCoordinate> toReturn = new List<SectorCoordinate>();
            int corner = coord.System.X - 5;

            if(corner > 0)
            {
                for (int coorY = coord.System.Y - 5; coorY <= 37 && coorY <= coord.System.Y + 5; coorY += 5)
                {
                    if(coorY > 0)
                    {
                        toReturn.Add(new SectorCoordinate(corner, coorY,0,0));
                    }
                }
            }

            corner = coord.System.X +5;

            if (corner <= 37)
            {
                for (int coorY = coord.System.Y - 5; coorY <= 37 && coorY <= coord.System.Y + 5; coorY += 5)
                {
                    if (coorY > 0)
                    {
                        toReturn.Add(new SectorCoordinate(corner, coorY, 0, 0));
                    }
                }
            }

            if (coord.System.Y - 5 > 0)
            {
                toReturn.Add(new SectorCoordinate(coord.System.X, coord.System.Y - 5, 0, 0));
            }

            if (coord.System.Y + 5 <= 37)
            {
                toReturn.Add(new SectorCoordinate(coord.System.X, coord.System.Y + 5, 0, 0));
            }
            return toReturn;
        }

        /// <summary>
        /// Return the trade resource for the market
        /// </summary>
        /// <param name="market">The market to be analysed</param>
        /// <returns>An IIntrinsicInfo object representing the trade resource. If null the market is invalid</returns>
        public static IIntrinsicInfo GetTradeResource(Market market){
            SectorCoordinate coor = new SectorCoordinate(market.Coordinates);
            return GetTradeResource(coor, market.Level);
        }

        /// <summary>
        /// Return the trade resource for the market
        /// </summary>
        /// <param name="coor">The market Coordinate</param>
        /// <param name="marketLevel">The market Level</param>
        /// <returns>An IIntrinsicInfo object representing the trade resource. If null the market is invalid</returns>
        public static IIntrinsicInfo GetTradeResource(SectorCoordinate coor, int marketLevel){
            IList<IIntrinsicInfo> resources = RulesUtils.GetTradeResources();
            int position = (coor.System.X + coor.System.Y) % 2;
            int count = 0;
            int level = marketLevel == 5 ? 3 : marketLevel;
            level = level == 9 ? 10 : level;
            foreach (IIntrinsicInfo info in resources)
            {
                if (info.StartLevel == level)
                {
                    if (position == count)
                    {
                        return info;
                    }
                    else
                    {
                        ++count;
                    }
                }
            }

            return null;
        }


        #endregion Public Methods

        #region Private Methods

        private static void CreateProduct(Market market, string name, int price, IProductPersistance persistance2)
        {
            Product prod = persistance2.Create();
            prod.Market = market;
            prod.Quantity = 0;
            prod.Price = price;
            prod.Type = "Intrinsic";
            prod.Name = name;
            persistance2.Update(prod);
        }


        private static void UpdatePrincipal(int toPay, PlayerStorage player)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                player.Principal.Credits -= toPay;
                persistance.Update(player.Principal);
                //persistance.Flush();
            }
        }

        private static void UpdatePrincipalAndQuantity(int toPay, PlayerStorage player, Product prod)
        {
            using (IProductPersistance persistance = Persistance.Instance.GetProductPersistance())
            {
                prod.Quantity -= toPay*prod.Price;
                if (prod.Quantity == 0)
                {
                    persistance.Delete(prod);
                }
                else
                {
                    persistance.Update(prod);
                }
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                {
                    player.Principal.Credits -= toPay;
                    persistance2.Update(player.Principal);
                    //persistance2.Flush();
                }
            }
        }

        private static Product MarketHaveProduct(Market market, string product)
        {
            foreach (Product prod in market.Products)
            {
                if(prod.Name == product)
                {
                    return prod;
                }
            }
            return null;
        }

        #endregion Private Methods

    }
}
