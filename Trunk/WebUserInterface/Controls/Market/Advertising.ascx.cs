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

namespace OrionsBelt.WebUserInterface.Controls
{
    public class Advertising : System.Web.UI.UserControl
    {
        protected Literal jason;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            IList<AuctionHouse> data = GetData();

            TextWriter writer = new StringWriter();
            writer.Write("<script type='text/javascript'> window.Auction=[5");

            foreach (AuctionHouse item in data) 
            {
                int bid = item.HigherBidOwner == 0 ? item.Price : CreditsUtil.GetNextBid(item.CurrentBid);
                string buyout = item.Buyout != 0 ? item.Buyout.ToString() : "'-'";
                writer.Write(",{{name:'{0}',id:{1},quant:{2},bid:{3},buy:{4}}}",
                    item.Details, item.Id, item.Quantity, bid, buyout);
            }

            writer.Write("];</script>");

            jason.Text = writer.ToString();

        }

        private static IList<AuctionHouse> GetData()
        {
            if (State.HasCache("AHAds")) {
                return (IList<AuctionHouse>)State.GetCache("AHAds");
            }

            IList<AuctionHouse> items = Hql.StatelessQuery<AuctionHouse>(0, 100, "select e from SpecializedAuctionHouse e where e.BuyedInTick=0 and e.Advertise=1 order by e.UpdatedDate desc", null);
            State.Cache.Add("AHAds", items, null, DateTime.Now.AddMinutes(25), Cache.NoSlidingExpiration, CacheItemPriority.Default, null);

            return items;
            
        }

        #region Properties

        public string FirstTrStyle {
            get {
                if (ExcludeHeader) {
                    return " style='display:none;'";
                }
                return string.Empty;  
            }
        }

        private bool excludeHeader = false;

        public bool ExcludeHeader
        {
            get { return excludeHeader; }
            set { excludeHeader = value; }
        }
	

        #endregion Properties

    }
}