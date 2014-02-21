using System;
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
using System.Collections.Generic;
using System.IO;
using System.Web.Caching;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls{
    
    public class AHAdvertising : Control{

        #region Private

        private static IList<AuctionHouse> GetData() {
            if (State.HasCache("AHAds")) {
                return (IList<AuctionHouse>)State.GetCache("AHAds");
            }

            IList<AuctionHouse> items = Hql.StatelessQuery<AuctionHouse>(0, 100, "select e from SpecializedAuctionHouse e where e.BuyedInTick=0 and e.Advertise=1 order by e.UpdatedDate desc", null);
            State.Cache.Add("AHAds", items, null, DateTime.Now.AddMinutes(25), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return items;

        }

        #endregion Private

        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            writer.Write("<div class='defaultMessagesSmall'>");
            IList<AuctionHouse> data = GetData();

            writer.Write("<script type='text/javascript'> window.Auction=[5");

            foreach (AuctionHouse item in data) {
                int bid = item.HigherBidOwner == 0 ? item.Price : CreditsUtil.GetNextBid(item.CurrentBid);
                string buyout = item.Buyout != 0 ? item.Buyout.ToString() : "'-'";
                writer.Write(",{{name:'{0}',id:{1},quant:{2},bid:{3},buy:{4}}}",
                    item.Details, item.Id, item.Quantity, bid, buyout);
            }

            writer.Write("];</script>");

            WriteBoard(writer);

            writer.Write("</div>");
        }

        private void WriteBoard(HtmlTextWriter writer) {
            StringWriter w = new StringWriter();
            w.Write("<table id='ahAd'><tr>");
            w.Write("<th>{0}</th>",LanguageManager.Localize("Quantity"));
            w.Write("<th>{0}</th>",LanguageManager.Localize("Description"));
            w.Write("<th>{0}</th>",LanguageManager.Localize("NextBid"));
            w.Write("<th>{0}</th>",LanguageManager.Localize("Buyout"));
            w.Write("</tr></table>");

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("AuctionHouseItems"));

            Border.RenderStraightSmall(writer, title, w.ToString());
        }

        #endregion Control Events

    }
}
