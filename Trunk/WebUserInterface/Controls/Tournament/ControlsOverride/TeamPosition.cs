using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TeamPosition : BaseFieldControl<TeamStorage>, INamingContainer
    {
        #region BaseFieldControl<LadderInfo> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, TeamStorage entity, int renderCount, bool flipFlop)
        {
            writer.Write(renderCount);
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
