using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TeamLinkedName : BaseFieldControl<TeamStorage>, INamingContainer
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
            writer.Write("<a href='{0}Tournaments/Team.aspx?TeamStorage={1}'>{2}</a>", WebUtilities.ApplicationPath,
                             entity.Id, entity.Name);
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
