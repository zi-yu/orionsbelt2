using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TournamentLink : BaseFieldControl<Core.Tournament>, INamingContainer
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
            if(entity.IsCustom)
            {
                writer.Write("<div class='button'><a href='Tournaments/Tournament.aspx?Tournament={0}'>{1}</a></div>", entity.Id, LanguageManager.Instance.Get("ViewTournament"));
            }
            else
            {
                writer.Write("<div class='button'><a href='Tournaments/Tournament.aspx?Tournament={0}&Stage=0'>{1}</a></div>", entity.Id, LanguageManager.Instance.Get("ViewTournament"));
            }
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio

    }
}
