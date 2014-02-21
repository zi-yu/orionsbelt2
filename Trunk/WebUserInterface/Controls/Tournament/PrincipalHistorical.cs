using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic;
using System.IO;
using System.Web.UI;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrincipalHistorical : Control
    {

        #region Private


        private void RenderTournament(StringWriter writer, PrincipalTournament regist) {
            string name;
            if (regist.Tournament.IsCustom) {
                name = string.Format("<a href='{1}Tournaments/Tournament.aspx?Tournament={2}'>{0}</a>",
                    regist.Tournament.Name, WebUtilities.ApplicationPath, regist.Tournament.Id);
            } else {
                name = string.Format("<a href='{2}Tournaments/Tournament.aspx?Tournament={3}&Stage=0'>{0} {1}</a>",
                    LanguageManager.Instance.Get(regist.Tournament.Token), regist.Tournament.TokenNumber,
                    WebUtilities.ApplicationPath, regist.Tournament.Id);
            }

            if (regist.HasEliminated) {
                string eliminatated;
                if (0 != regist.EliminatedInBattleId) {
                    eliminatated = string.Format("<a href='{1}Battle/Battle.aspx?id={2}'>{0}</a>",
                                                 LanguageManager.Instance.Get(regist.EliminatedInFase),
                                                 WebUtilities.ApplicationPath, regist.EliminatedInBattleId);
                } else {
                    eliminatated = LanguageManager.Instance.Get(regist.EliminatedInFase);
                }

                writer.Write("<tr><td>{0}</td><td>{1}</td></tr>", string.Format(Resources.EliminatedInFaseToken, name, regist.Principal.DisplayName,
                                                   eliminatated), TimeFormatter.GetFormattedTime(DateTime.Now - regist.UpdatedDate));
            } else {
                if (regist.EliminatedInFase == "Winner") {
                    writer.Write("<tr><td>{0}</td><td>{1}</td></tr>", string.Format(Resources.WinTournamentToken, name,
                        regist.Principal.DisplayName), TimeFormatter.GetFormattedTime(DateTime.Now - regist.UpdatedDate));
                } else {
                    writer.Write("<tr><td>{0}</td><td>{1}</td></tr>", string.Format(Resources.NotEliminatedYetToken, name, regist.Principal.DisplayName),
                        TimeFormatter.GetFormattedTime(DateTime.Now - regist.Tournament.StartTime));
                }
            }
        }

        #endregion Private
        
        #region Control Events

        protected override void Render(HtmlTextWriter writer) {
            int pId = State.GetItems<Principal>().Id;
            IList<PrincipalTournament> regists = Hql.Query<PrincipalTournament>(
                        "select p from SpecializedPrincipalTournament p inner join fetch p.TournamentNHibernate g where p.PrincipalNHibernate.Id = :id order by p.UpdatedDate",
                        Hql.Param("id", pId));

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("TournamentHistory"));

            StringWriter content = new StringWriter();
            if (regists.Count == 0) {
                content.Write("<p>{0}</p>", LanguageManager.Instance.Get("NeverEnter"));
            } else {
                content.Write("<table class='newtable'>");
                foreach (PrincipalTournament regist in regists) {
                    RenderTournament(content, regist);
                }
                content.Write("</table>");
            }

            writer.Write("<div id='principalHistory'>");
            Border.RenderNormal(writer, title, content.ToString());
            writer.Write("<div>");

        }

        #endregion Control Events

    }
}