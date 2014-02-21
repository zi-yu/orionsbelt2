using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TeamYours : BaseFieldControl<TeamStorage>, INamingContainer
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
            Principal current = Utils.Principal;
            if (current.Team == null || entity.Principals.Count != 2 ) {
                return;
            }

            if (entity.Principals[0].Id == current.Id || entity.Principals[1].Id == current.Id) {
                writer.Write(" class='my' ");
            }

        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
