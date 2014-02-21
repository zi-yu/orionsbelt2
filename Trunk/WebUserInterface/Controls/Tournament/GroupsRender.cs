using System;
using System.Collections.Generic;
using System.Text;
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
    public class GroupsRender : ControlBase
    {
        #region Control Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Core.Tournament tour;
            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);
            int stage = 1;
            if (HttpContext.Current.Request.QueryString["Stage"] != null)
            {
                stage = Int32.Parse(HttpContext.Current.Request.QueryString["Stage"]);
                if(0 == stage)
                {
                    return;
                }
            }

            IList<Core.Tournament> tours = Hql.Query<Core.Tournament>(
                        "select tournament from SpecializedTournament tournament inner join fetch tournament.GroupsNHibernate g where tournament.Id = :id",
                        Hql.Param("id", tourId)
                    );

            if (tours.Count == 0)
            {
                return;
            }
            tour = tours[0];

            IList<PlayersGroupStorage> groups = tour.Groups;

            if (tour.TournamentType == "TotalAnnihalation" ||
                tour.TournamentType == "Regicide" ||
                tour.TournamentType == "Domination")
            {
                RenderPrincipalGroup(groups, tourId, stage-1);
            }
            else
            {
                RenderTeamGroup(groups, tourId, stage-1);
            }
        }

        #endregion Control Events

        private void RenderPrincipalGroup(IList<PlayersGroupStorage> groups, int tourId, int stage)
        {
            string page = (string)HttpContext.Current.Request.QueryString["GroupPage"];
            int start = 0;
            if (!string.IsNullOrEmpty(page))
            {
                start = (Int32.Parse(page) - 1);
            }

            List<List<GroupPlayer>> sortedGroups;
            sortedGroups = TournamentManager.GetPlayersByGroupOrdered(groups, stage, tourId, start);
            
            IList<PlayersGroupStorage> stageGroups = new List<PlayersGroupStorage>();
            StageGroups(groups, stage, stageGroups, start);

            WritePages(groups,stage);

            Write("<div id='tournamentPlayersState1' class='bigBorder'><div class='top'><h2>{0} {1}</h2></div><div class='center'>", LanguageManager.Instance.Get("Stage"), (stage + 1).ToString());

            for (int iter = 0; iter < sortedGroups.Count; ++iter)
            {
                Write("<table class='newtable'><caption><a href='{6}Tournaments/GroupBattles.aspx?Group={7}'>{0} {1}</a></caption><tr><th colspan='2'>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>",
                      LanguageManager.Instance.Get("Group"), (iter + 1 + start * 10).ToString(),
                      LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Points"),
                      LanguageManager.Instance.Get("Wins"), LanguageManager.Instance.Get("Losses"),
                      WebUtilities.ApplicationPath, stageGroups[iter].Id.ToString());

                foreach (GroupPlayer player in sortedGroups[iter])
                {
					Write("<tr{7}><td>{6}</td><td><a href='{4}PrincipalInfo.aspx?Principal={5}'>{0}</a></td><td>{1}</td><td>{2}</td><td>{3}</td></tr>", 
                        player.Player.Principal.DisplayName, player.Points.ToString(),
                        player.Wins.ToString(),player.Losses.ToString(),
                        WebUtilities.ApplicationPath, player.Player.Principal.Id.ToString(),
                        GetAvatar(player.Player.Principal),
                        GetRowClass(player.Player.Principal));
                }
                WriteNotEndedBattles(stageGroups, iter);
                Write("</table>");

                if ((iter+1) % 3 == 0) {
                    Write("<div class='clear'></div>");
                }
            }

            Write("</div><div class='bottom'></div></div>");

        }

        private string GetRowClass(Principal principal)
        {
            if (Utils.PrincipalExists && principal.Id == Utils.Principal.Id) {
                return " class='selected'";
            }
            return string.Empty;
        }

        private string GetAvatar(Principal principal)
        {
            string avatar = principal.Avatar;
            if (string.IsNullOrEmpty(avatar)) {
                avatar = ResourcesManager.DefaultAvatar;
            }
            return string.Format("<img src='{0}' title='{1}' alt='{1}' />", avatar, principal.Name);
        }

        private void RenderTeamGroup(IList<PlayersGroupStorage> groups, int tourId, int stage)
        {
            string page = (string)HttpContext.Current.Request.QueryString["GroupPage"];
            int start = 0;
            if (!string.IsNullOrEmpty(page))
            {
                start = (Int32.Parse(page) - 1);
            }

            List<List<GroupPlayer>> sortedGroups;
            sortedGroups = TournamentManager.GetTeamsByGroupOrdered(groups, stage, tourId, start);

            IList<PlayersGroupStorage> stageGroups = new List<PlayersGroupStorage>();
            StageGroups(groups, stage, stageGroups, start);

            WritePages(groups, stage);
            Write("<div id='tournamentPlayersState1' class='bigBorder'><div class='top'><h2>{0} {1}</h2></div><div class='center'>", LanguageManager.Instance.Get("Stage"), (stage + 1).ToString());

            for (int iter = 0; iter < sortedGroups.Count; ++iter)
            {
                Write("<table class='newtable' style='float:left;width:315px;margin:5px;'><caption><a href='{4}Tournaments/GroupBattles.aspx?Group={5}'>{0} {1}</a></caption><tr><th>{2}</th><th>{3}</th></tr>",
                      LanguageManager.Instance.Get("Group"), (iter + 1 + start*10).ToString(),
                      LanguageManager.Instance.Get("Name"), LanguageManager.Instance.Get("Points"),
                      WebUtilities.ApplicationPath, stageGroups[iter].Id.ToString());

                foreach (GroupPlayer player in sortedGroups[iter])
                {
                    Write("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td></tr>",
                    player.Player.Team.Name, player.Points.ToString(),
                    player.Wins.ToString(), player.Losses.ToString());
                }
                WriteNotEndedBattles(stageGroups, iter);
                Write("</table>");

                if ((iter + 1) % 3 == 0) {
                    Write("<div class='clear'></div>");
                }
            }

            Write("</div><div class='bottom'></div></div>");
        }

        private void WritePages(IList<PlayersGroupStorage> groups, int stage)
        {
            int groupNum = 0;
            foreach (PlayersGroupStorage group in groups)
            {
                if (group.EliminatoryNumber == stage )
                    ++groupNum;
            }

            double pageCount = Math.Ceiling((double)groupNum/10);

            if(pageCount == 1)
            {
                return;
            }

            string url = Page.Request.Url.AbsolutePath;
            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);

            Write("<div>");
            for(int iter = 1; iter <= pageCount; ++iter)
            {
                Write("<a href='{0}?Tournament={1}&Stage={3}&GroupPage={2}'>{2}</a> ",url, tourId.ToString(),iter.ToString(), (stage+1).ToString());
            }
            Write("</div>");
        }

        private void StageGroups(IList<PlayersGroupStorage> groups, int stage, IList<PlayersGroupStorage> stageGroups, int page)
        {
            int start = (page)*10;
            int processed = 0;
            int count = 0;
            for (int iter = 0; iter < groups.Count && count < 10; ++iter)
            {
                if (groups[iter].EliminatoryNumber != stage)
                {
                    continue;
                }

                if (processed < start)
                {
                    ++processed;
                }
                else
                {
                    stageGroups.Add(groups[iter]);
                    ++count;
                }
            }
        }

        private void WriteNotEndedBattles(IList<PlayersGroupStorage> stageGroups, int iter)
        {            
            if (Utils.Principal.IsInRole("admin"))
            {
                Write("<tr><th colspan='5'>");
                int notEnded = 0;
                foreach(Battle b in stageGroups[iter].Battles)
                {
                    if(!b.HasEnded)
                    {
                        ++notEnded;
                    }
                }
                Write("Not ended battles = {0}", notEnded.ToString());
                Write("</th></tr>");
            }
        }

    }
}