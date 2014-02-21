using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MinEloRender : TournamentMinElo
    {

        #region BaseFieldControl<Tournament> Implementation

        /// <summary>
        /// Renders an entity object's information
        /// </summary>
        /// <param name="writer">The HtmlTextWriter</param>
        /// <param name="entity">The entity instance</param>
        /// <param name="renderCount">The render count</param>
        /// <param name="flipFlop">True if render count is odd</param>
        protected override void Render(HtmlTextWriter writer, Core.Tournament entity, int renderCount, bool flipFlop)
        {
            if (entity.MinElo != 0)
            {
                base.Render(writer, entity, renderCount, flipFlop);
            }
            else
            {
                writer.Write(LanguageManager.Instance.Get("NoLimit"));
            }
            
        }

        #endregion BaseFieldControl<Tournament> Implementation
       
    }
}
