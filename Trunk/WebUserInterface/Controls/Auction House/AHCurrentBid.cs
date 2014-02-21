using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AHCurrentBid : AuctionHouseCurrentBid
    {
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if (entity.HigherBidOwner != 0)
            {
                if (Utils.Principal.IsInRole("admin"))
                {
                    writer.Write("<a href='{0}Stats/BidRegist.aspx?Product={1}'>",WebUtilities.ApplicationPath, entity.Id);
                    base.Render(writer, entity, renderCount, flipFlop);
                    writer.Write("</a>");
                }
                else
                {
                    base.Render(writer, entity, renderCount, flipFlop);
                }
            }
            else
            {
                writer.Write("-");
            }
        }
    }
}
