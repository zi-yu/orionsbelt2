using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TournamentStatus : BaseFieldControl<Core.Tournament>, INamingContainer
    {
        #region BaseFieldControl<LadderInfo> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Core.Tournament entity, int renderCount, bool flipFlop)
        {
            if(entity.CreatedDate == entity.EndDate)
            {
                writer.Write(LanguageManager.Instance.Get("Running"));
            }
            else
            {
                writer.Write(LanguageManager.Instance.Get("Ended"));
            }
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio

    }
}
