using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Generic;
using OrionsBelt.TournamentCore;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class GroupRender : ControlBase
    {
        #region Control Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Core.Tournament tour;
            int group = Int32.Parse(HttpContext.Current.Request.QueryString["Group"]);


            tour = Hql.Query<Core.Tournament>(
                        "select tournament from SpecializedTournament tournament inner join fetch tournament.GroupsNHibernate g where g.Id = :id",
                        Hql.Param("id", group)
                    )[0];
            

            IList<PlayersGroupStorage> groups = tour.Groups;

            if (tour.TournamentType == "TotalAnnihalation" ||
                tour.TournamentType == "Regicide" ||
                tour.TournamentType == "Domination")
            {
                RenderPrincipalGroup(groups);
            }
            else
            {
                RenderTeamGroup(groups);
            }
        }

        #endregion Control Events

        private void RenderPrincipalGroup(IList<PlayersGroupStorage> groups)
        {
            List<GroupPlayer> sortedGroups;
            sortedGroups = TournamentManager.GetPlayersByGroupOrdered(groups);
            
            IList<PlayersGroupStorage> stageGroups = new List<PlayersGroupStorage>();
            StageGroups(groups, stageGroups);

            Write("<h1>{0} {1}</h1><table class='table'><tr><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>",
                  LanguageManager.Instance.Get("Group"), (groups[0].GroupNumber+1).ToString(),
                  LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Points"),
                  LanguageManager.Instance.Get("Wins"), LanguageManager.Instance.Get("Losses"));

            foreach (GroupPlayer player in sortedGroups)
            {
                Write("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", 
                    player.Player.Principal.DisplayName, player.Points.ToString(),
                    player.Wins.ToString(),player.Losses.ToString());
            }
            Write("</table>");
            

        }
        
        private void RenderTeamGroup(IList<PlayersGroupStorage> groups)
        {
            List<GroupPlayer> sortedGroups;
            sortedGroups = TournamentManager.GetTeamsByGroupOrdered(groups);

            IList<PlayersGroupStorage> stageGroups = new List<PlayersGroupStorage>();
            StageGroups(groups, stageGroups);

            Write("<h1>{0} {1}</h1><table class='table'><tr><th>{2}</th><th>{3}</th></tr>",
                  LanguageManager.Instance.Get("Group"), (groups[0].GroupNumber + 1).ToString(),
                  LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Points"));

            foreach (GroupPlayer player in sortedGroups)
            {
                Write("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                    player.Player.Team.Name, player.Points.ToString(),
                    player.Wins.ToString(), player.Losses.ToString());
            }
            Write("</table>");  
        }
        

        private static void StageGroups(IList<PlayersGroupStorage> groups, ICollection<PlayersGroupStorage> stageGroups)
        {

            for (int iter = 0; iter < groups.Count; ++iter)
            {
                stageGroups.Add(groups[iter]);
            }
        }

    }
}