using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Common;

using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Controls.Auction_House;

namespace OrionsBelt.WebUserInterface {

	public class AuctionAdmin: Page 
    {
        protected Literal message;
	    protected AuctionSearch search;
        protected AuctionHousePagedList paged;

        protected override void OnInit(EventArgs e)
        { 
            base.OnInit(e);
            string id = HttpContext.Current.Request.QueryString["buy"];
            int itemId;
            if (Int32.TryParse(id, out itemId))
            {
                message.Text = LanguageManager.Instance.Get(AuctionHouseUtil.MakeAdminBuyout(itemId, PlayerUtils.Current.Storage));
                return;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            paged.Where += search.Where;
        }
    }
}
