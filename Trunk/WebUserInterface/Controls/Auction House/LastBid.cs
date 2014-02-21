using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class LastBid : AuctionHouseHigherBidOwner
    {
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if (entity.HigherBidOwner == PlayerUtils.Current.Storage.Id)
            {
                writer.Write("<div class='true'/>");
            }
            else
            {
                writer.Write("<div class='false'/>");
            }
        }
    }
}
