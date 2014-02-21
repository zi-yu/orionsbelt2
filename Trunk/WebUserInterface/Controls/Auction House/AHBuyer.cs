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
    public class AHBuyer : BaseFieldControl<AuctionHouse>, INamingContainer
    {

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if(entity.HigherBidOwner == 0)
            {
                writer.Write("-");
            }
            else
            {
                writer.Write(string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{1}</a>",
                WebUtilities.ApplicationPath, entity.HigherBidOwner));
            }
        }
    }
}
