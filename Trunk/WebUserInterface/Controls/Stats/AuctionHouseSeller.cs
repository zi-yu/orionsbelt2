using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;


namespace OrionsBelt.WebUserInterface.Controls
{
    public class AuctionHouseSeller : BaseFieldControl<AuctionHouse>, INamingContainer
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
            writer.Write(string.Format("{0}(<a href='{2}PlayerInfo.aspx?PlayerStorage={3}'>{1}</a>)",
                entity.Owner.Principal.DisplayName, entity.Owner.Name,WebUtilities.ApplicationPath,entity.Owner.Id));
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
