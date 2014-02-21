using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Core;
using System.IO;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class AuctionHouseMenu : MenuBase {

        #region Private

         private void ResolveAdmin() {
            if (Utils.Principal.IsInRole("admin")) {
                options[options.Length - 2] = "AuctionHouse/AuctionAdmin.aspx";
                optionsLabel[options.Length - 2] = "BuyAdmin";
                options[options.Length - 1] = "AuctionHouse/AddToAuctionAdmin.aspx";
                optionsLabel[options.Length - 1] = "AddToAuctionAdmin";
            }
         }

        #endregion Private

        #region Control Events

         protected override void  Render(HtmlTextWriter writer){
            ResolveAdmin();
 	        base.Render(writer);
        }

        #endregion

        #region Constructor

         public AuctionHouseMenu() {
             options = new string[] { "AuctionHouse/AuctionHouse.aspx", "AuctionHouse/MyAuctionItems.aspx", "AuctionHouse/AddToAuction.aspx", "AuctionHouse/MyBids.aspx", "", "" };
             optionsLabel = new string[] { "AuctionHouse", "MyAuctionItems", "AddToAuction", "MyBids", "", "" };
        }

        #endregion Constructor
    }
}