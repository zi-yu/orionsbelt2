using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AHHistoricalLink : AuctionHouseId
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {

            if (entity.BuyedInTick != -1)
            {
                writer.Write(string.Format("<a href='{0}Stats/BidRegist.aspx?Product={1}'>{1}</a>",
                                           WebUtilities.ApplicationPath, entity.Id));
            }
            else
            {
                writer.Write(entity.Id);
            }
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
