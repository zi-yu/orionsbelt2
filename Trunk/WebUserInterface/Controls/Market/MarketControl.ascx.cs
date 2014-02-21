using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MarketControl : System.Web.UI.UserControl
    {
        protected ProductList paged;
        protected Literal message;
        private Market market;
        private Fleet fleet;
        protected NearMarkets nears;
        protected TradeRoutes tradeRoutes;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            market = EntityUtils.GetFromQueryString<Market>();
            fleet = EntityUtils.GetFromQueryString<Fleet>();
            SectorCoordinate marketCoord = new SectorCoordinate(market.Coordinates);
            nears.Coordinates = marketCoord;
            tradeRoutes.TargetMarket = market;
            tradeRoutes.Fleet = new FleetInfo(fleet);

            UniversePersistance.AddSpecialSector(PlayerUtils.Current, SectorUtils.LoadSector(market.Sector), SpecialSectorType.Market);
			Persistance.Flush();/*
            if (!SectorUtils.IsInRange(marketCoord,
                                  new SectorCoordinate(fleet.SystemX, fleet.SystemY, fleet.SectorX, fleet.SectorY)))
            {
                Page.Response.Redirect("Error.aspx");
            }*/
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            foreach (string key in Request.Form.AllKeys)
            {
                if (key.StartsWith("b_"))
                {
                    string resource = key.Substring(2);
                    int quantity;
                    if (Int32.TryParse(Request.Form[resource], out quantity))
                    {
                        BuyProduct(resource, quantity);
                    }
                    else
                    {
                        message.Text = LanguageManager.Instance.Get("NaN");
                    }

                }
            }
            using (IProductPersistance persistance = Persistance.Instance.GetProductPersistance())
            {
                /*
                IList<Product> prods = persistance.SelectByMarket(market);
                IList<Product> temp = new List<Product>(prods.Count);
                foreach (Product prod in prods)
                {
                    if (prod.Type != "Rare" || prod.Quantity != 0)
                    {
                        temp.Add(prod);
                    }
                }
                paged.Collection = temp;
                 */
                paged.Collection = persistance.SelectByMarket(market);
            }
        }

        private void BuyProduct(string resource, int quantity)
        {
            if(0 >= quantity)
            {
                return;
            }
            Result res = MarketUtil.BuyItem(market, fleet, PlayerUtils.Current.Storage, resource, quantity);
            if (res.Ok)
            {
                message.Text = LanguageManager.Instance.Get(res.Passed[0].Name);
            }
            else
            {
                message.Text = LanguageManager.Instance.Get(res.Failed[0].Name);
            }
        }
    }
}