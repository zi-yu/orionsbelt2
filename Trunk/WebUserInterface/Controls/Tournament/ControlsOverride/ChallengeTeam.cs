using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class ChallengeTeam : BaseFieldControl<TeamStorage>, INamingContainer
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
            Principal current = HttpContext.Current.User as Principal;
            if (current == null || current.Team == null)
            {
                return;
            }
            IList<TeamStorage> list = (IList<TeamStorage>)State.Items["LadderTeamCollection"];
            int currIdx = list.IndexOf(entity);
            int myIdx = (int)State.Items["MyLadderTeamCollectionIdx"];
            
            if (0 == entity.IsInBattle &&
                0 == current.Team.IsInBattle &&
                entity.RestUntil < Clock.Instance.Tick &&
                current.Team.StoppedUntil < Clock.Instance.Tick &&
                myIdx - currIdx <= 5 &&
                myIdx - currIdx > 0)
            {
                string href = string.Format("LadderTeamList.aspx?Team={0}'", entity.Id);
                GenericRenderer.WriteRightLinkButton(writer, href, LanguageManager.Localize("Challenge"));
            }
            if (entity.Id == current.Team.Id)
            {
                //writer.Write("{0}", LanguageManager.Instance.Get("Yours"));
                if (current.Team.StoppedUntil > Clock.Instance.Tick)
                {
                    writer.Write(" ({0})", LanguageManager.Instance.Get("InCoolDown"));
                }
            }

        }

        #endregion BaseFieldControl<LadderInfo> Implementatio
    }
}
