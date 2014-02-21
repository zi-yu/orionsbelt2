using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ArenaLinkedPlayer : BaseFieldControl<ArenaStorage>, INamingContainer
    {
        #region BaseFieldControl<PlayerStorage> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, ArenaStorage entity, int renderCount, bool flipFlop)
        {
            if (null != entity.Owner)
            {
                writer.Write(string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
                                           WebUtilities.ApplicationPath, entity.Owner.Id, entity.Owner.Name));
            }
        }

        #endregion BaseFieldControl<PlayerStorage> Implementatio
    }
}
