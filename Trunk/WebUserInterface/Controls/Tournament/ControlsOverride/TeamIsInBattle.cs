using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TeamIsInBattle : BaseFieldControl<TeamStorage>, INamingContainer
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
            if(0 != entity.IsInBattle)
            {
                writer.Write("<div class='true'/>");
            }
            else
            {
                writer.Write("<div class='false'/>");
            }
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
