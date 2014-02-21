using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class MarketView : Page
    {
        protected ProductList paged;
        private Market market;
        protected TransactionPagedList transactions;
        protected NearMarkets nears;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            market = EntityUtils.GetFromQueryString<Market>();
            SectorCoordinate marketCoord = new SectorCoordinate(market.Coordinates);
            nears.Coordinates = marketCoord;
            //Page.ClientScript.RegisterHiddenField("resource","");
            

            using (IProductPersistance persistance = Persistance.Instance.GetProductPersistance())
            {
                paged.Collection = persistance.SelectByMarket(market);
            }

            transactions.Where = string.Format("e.TransactionContext='Market' and e.IdentifierGain={0}", market.Id);
        }

    }
}
