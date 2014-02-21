using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AHBid : BaseFieldControl<AuctionHouse>, INamingContainer
    {
        private bool showOperator = true;

        public bool ShowOperator
        {
            get { return showOperator; }
            set { showOperator = value; }
        }

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            
            int nextBid;
            if (entity.HigherBidOwner == 0)
            {
                nextBid = entity.CurrentBid;
            }
            else
            {
                nextBid = CreditsUtil.GetNextBid(entity.CurrentBid);
            }

            if (entity.Owner.Principal.Id == Utils.Principal.Id)
            {
                writer.Write(nextBid);
                return;
            }

            if (entity.Buyout > nextBid || entity.Buyout == 0)
            {
                if (Utils.Principal.Credits >= nextBid && 
                    showOperator && 
                    entity.HigherBidOwner != PlayerUtils.Current.Id )//&&
                    //(entity.Owner.Principal.Id != Utils.Principal.Id || entity.Owner.Id == PlayerUtils.Current.Id))
                {
                    string url = string.Format("AuctionHouse.aspx?bid={0}", entity.Id);
                    string page = HttpContext.Current.Request.QueryString["Page"];
                    int pageNum;
                    if (Int32.TryParse(page, out pageNum))
                    {
                        url += string.Format("&Page={0}", pageNum);
                    }
                    page = HttpContext.Current.Request.QueryString["Sort"];
                    if (!string.IsNullOrEmpty(page))
                    {
                        url += string.Format("&Sort={0}", page);
                    }
                    GenericRenderer.WriteSmallCenterLinkButton(writer, url,
                        string.Format("{0} {1}", LanguageManager.Instance.Get("Bid"), nextBid)
                    );
                }
                else
                {
                    writer.Write(nextBid);
                }

            }
            else
            {
                writer.Write("-");
            }
        }
    }
}
