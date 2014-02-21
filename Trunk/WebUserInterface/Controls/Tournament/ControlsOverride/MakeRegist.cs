using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MakeRegist : BaseFieldControl<Core.Tournament>, INamingContainer
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
            IList<PrincipalTournament> principals = entity.Regists;

            if ((principals.Count >= entity.MaxPlayers && 0 != entity.MaxPlayers) ||
                (Utils.Principal.EloRanking > entity.MaxElo && 0 != entity.MaxElo) ||
                (Utils.Principal.EloRanking < entity.MinElo && 0 != entity.MinElo))
            {
                writer.Write("<div class='button'><a href='Tournaments/TournamentRegist.aspx?Tournament={0}'>{1}</a></div>", entity.Id,
                             LanguageManager.Instance.Get("ViewTournament"));
                return;
            }

            if ((null == Utils.Principal.Team || !Utils.Principal.Team.IsComplete) &&
                (entity.TournamentType == "TotalAnnihalation4" || entity.TournamentType == "Regicide4" ||
                 entity.TournamentType == "Domination4"))
            {
                writer.Write("<div class='button'><a href='Tournaments/TournamentRegist.aspx?Tournament={0}'>{1}</a></div>", entity.Id,
                             LanguageManager.Instance.Get("ViewTournament"));
                return;
            }

            foreach (PrincipalTournament regist in principals)
            {
                
                if ((null != regist.Principal && regist.Principal.Id == Utils.Principal.Id) ||
                    (null != regist.Team && null != Utils.Principal.Team && regist.Team.Id == Utils.Principal.Team.Id))
                {
                    writer.Write("<div class='button'><a href='Tournaments/TournamentRegist.aspx?Tournament={0}'>{1}</a></div>", entity.Id,
                                 LanguageManager.Instance.Get("ViewTournament"));
                    return;
                }
            }

            if (entity.TournamentType == "TotalAnnihalation4" || 
                entity.TournamentType == "Regicide4" ||
                entity.TournamentType == "Domination4")
            {
                writer.Write(
                    "<div class='button'><a href='Tournaments/TournamentRegist.aspx?Tournament={0}'>{1}</a></div>&nbsp;<div class='buttonSmall'><a href='Tournaments/TournamentRegist.aspx?Regist=2&Tournament={0}'>{2}</a></div>"
                    , entity.Id, LanguageManager.Instance.Get("ViewTournament"), LanguageManager.Instance.Get("Regist"));
            }
            else
            {
                writer.Write(
                    "<div class='button'><a href='Tournaments/TournamentRegist.aspx?Tournament={0}'>{1}</a></div>&nbsp;<div class='buttonSmall'><a href='Tournaments/TournamentRegist.aspx?Regist=1&Tournament={0}'>{2}</a></div>"
                    , entity.Id, LanguageManager.Instance.Get("ViewTournament"), LanguageManager.Instance.Get("Regist"));
            }
        }

        #endregion BaseFieldControl<LadderInfo> Implementatio

    }
}
