using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine.Tournament;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PlayoffRender : ControlBase
    {
        #region Properties

        private List<Battle> Battles {
            get { return (List<Battle>)State.GetItems("PlayoffBattles"); }
            set { State.SetItems("PlayoffBattles", value); }
        }

        #endregion Properties

        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Core.Tournament tour;
            IList<Battle> battles;

            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);
            if(HttpContext.Current.Request.QueryString["Stage"] == null ||
                Int32.Parse(HttpContext.Current.Request.QueryString["Stage"]) != 0)
            {
                return;
            }

            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                battles =
                    persistance.TypedQuery(
                        "select b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate player where b.TournamentNHibernate.Id={0} and b.GroupNHibernate.Id is null order by b.SeqNumber",
                        tourId);
            }
            if(battles.Count > 0)
            {
                Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Playoffs"));
                tour = battles[0].Tournament;
                battles = (List<Battle>)Hql.Unify<Battle>(battles);
                Battles = (List<Battle>) battles;
                WritePlayoffs(tour, battles);
            }
        }

        #endregion Control Events

        #region Rendering

        private void WritePlayoffs(Core.Tournament tour, IList<Battle> battles)
        {
            int type = TournamentManager.BeginningEliminatory(tour);
            Write("<div id='playoffs' class='players{0}'>", type.ToString());

            List<List<string>> data = new List<List<string>>();
            foreach (int phase in GetPhases(type)) {
                List<string> phaseContent = GetPhaseContent(tour, battles, type, phase);
                data.Add(phaseContent);
            }

            WriteData(tour, type, data);
            
            Write("</div>");
        }

        private void WriteData(Core.Tournament tour, int type, List<List<string>> data)
        {
            Write("<table>");

            for (int i = 0; i < GetTotalRows(type); ++i) {
                Write("<tr>");
                for (int j = 0; j < Math.Log(type, 2); ++j) {
                    Write("<td>");
                    string content = GetContent(data, j, i);
                    Write(content);
                    Write("</td>");
                }
                Write("</tr>");
            }

            Write("</table>");
        }

        private static string GetContent(List<List<string>> data, int j, int i)
        {
            if( data.Count > j && data[j].Count > i ) {
                return data[j][i];
            }
            return string.Empty;
        }

        private List<string> GetPhaseContent(Core.Tournament tour, IList<Battle> battles, int topPhase, int phase)
        {
            List<string> list = new List<string>();

            for (int i = 0; i < GetStartJunk(topPhase, phase); ++i) {
                list.Add("<td/>");
            }

            foreach (Battle battle in GetBattle(battles, topPhase, phase, tour)) {
                if (battle != null) {
                    list.Add(GetBattleRepresentation(battle));
                } else {
                    list.Add(GetUnfinishedBattleContent());
                }
                for (int i = 0; i < GetInnerJunk(topPhase, phase); ++i) {
                    list.Add("<td/>");
                }
            }
            return list;
        }

        private string GetUnfinishedBattleContent()
        {
            TextWriter writer = new StringWriter();

            writer.Write("<ul class='empty'>");
            writer.Write("<li><span>?</span></li>" );
            writer.Write("<li><span>?</span></li>");
            writer.Write("<li class='info'>?</li>");
            writer.Write("</ul>");

            return writer.ToString();
        }

        private IEnumerable<Battle> GetBattle(IList<Battle> battles, int topPhase, int phase, Core.Tournament tour)
        {
            List<Battle> phaseBattles = GetPhaseBattles(battles, phase);
            int phaseFinal = phase / 2;

            if (phaseBattles.Count == phaseFinal) {
                foreach (Battle battle in phaseBattles) {
                    yield return battle;
                }
            } else {
                for (int i = 0; i < phaseFinal; ++i) {
                    yield return null;
                }
            }
        }

        private List<Battle> GetPhaseBattles(IList<Battle> battles, int phase)
        {
            int phaseFinal = phase / 2;
            List<Battle> list = new List<Battle>();
            foreach(Battle battle in battles ) {
                int battleFinal = NumericUtils.GetDecimalPart(battle.SeqNumber);
                if (battleFinal == phaseFinal) {
                    list.Add(battle);
                }
                
            }
            return list;
        }

        private string GetBattleRepresentation(Battle battle)
        {
            TextWriter writer = new StringWriter();

            if (battle.BattleType == "Regicide" || battle.BattleType == "TotalAnnihalation" || battle.BattleType == "Domination")
            {
                writer.Write("<ul>");
                writer.Write("<li class='Win{1}'>{0}</li>", GetPlayerInfo(battle.PlayerInformation[0]),
                             !battle.PlayerInformation[0].HasLost);
                writer.Write("<li class='Win{1}'>{0}</li>", GetPlayerInfo(battle.PlayerInformation[1]),
                             !battle.PlayerInformation[1].HasLost);
                writer.Write("<li class='info'><a href='{1}Battle/Battle.aspx?Id={2}'>{0}</a></li>",
                             LanguageManager.Instance.Get("ViewBattle"), WebUtilities.ApplicationPath, battle.Id);
                writer.Write("</ul>");
            }
            else
            {
                bool team2Lost = true;

                if (battle.PlayerInformation.Count > 2)
                {
                    team2Lost = battle.PlayerInformation[2].HasLost;
                }
                writer.Write("<ul>");
                writer.Write("<li class='Win{1}'>{0}</li>", GetTeamInfo(battle,0,1),
                             !battle.PlayerInformation[0].HasLost);
                writer.Write("<li class='Win{1}'>{0}</li>", GetTeamInfo(battle, 2, 3),
                             !team2Lost);
                writer.Write("<li class='info'><a href='{1}Battle/Battle.aspx?Id={2}'>{0}</a></li>",
                             LanguageManager.Instance.Get("ViewBattle"), WebUtilities.ApplicationPath, battle.Id);
                writer.Write("</ul>");
            }

            return writer.ToString();
        }

        private string GetTeamInfo(Battle battle, int idx0, int idx1)
        {
            TextWriter writer = new StringWriter();

            int score1 = 0;
            int score2 = 0;
            string teamName = string.Empty;
            string avatar1 = string.Empty;
            string avatar2 = string.Empty;
            int owner = 0;

            if(idx0 <battle.PlayerInformation.Count)
            {
                score1 = battle.PlayerInformation[idx0].WinScore;
                teamName = battle.PlayerInformation[idx0].TeamName;
                avatar1 = GetAvatar(battle.PlayerInformation[idx0].Owner);
                owner = battle.PlayerInformation[idx0].Owner;
                writer.Write("<img src='{0}' alt='avatar' />", avatar1);
            }           

            if (idx1 < battle.PlayerInformation.Count)
            {
                score2 = battle.PlayerInformation[idx1].WinScore; 
                writer.Write("<span>{2} ({3})</span>", WebUtilities.ApplicationPath, owner, teamName, score1 + score2);
                avatar2 = GetAvatar(battle.PlayerInformation[idx1].Owner);
                writer.Write("<img src='{0}' alt='avatar' style='margin-left:-10px;' />", avatar2);
            }
            else
            {
                writer.Write("<span>{2} ({3})</span>", WebUtilities.ApplicationPath, owner, teamName, score1);
            }
            
            return writer.ToString();
        }

        private string GetTeamInfo(PlayerBattleInformation player, PlayerBattleInformation player2)
        {
            TextWriter writer = new StringWriter();

            int score = player.WinScore + player2.WinScore;

            writer.Write("<img src='{0}' alt='avatar' />", GetAvatar(player.Owner));
            writer.Write("<span>{2} ({3})</span>", WebUtilities.ApplicationPath, player.Owner, player.TeamName, score);
            writer.Write("<img src='{0}' alt='avatar' style='margin-left:-10px;' />", GetAvatar(player2.Owner));
            return writer.ToString();
        }

        private string GetPlayerInfo(PlayerBattleInformation player)
        {
            TextWriter writer = new StringWriter();

            int score = player.WinScore;
            
            writer.Write("<img src='{0}' alt='avatar' />", GetAvatar(player.Owner));
            writer.Write("<span><a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a> ({3})</span>", WebUtilities.ApplicationPath, player.Owner, player.Name, score);

            return writer.ToString();
        }

        #endregion Rendering

        #region Utils

        private IEnumerable<int> GetPhases(int bigPhase)
        {
            for (int val = bigPhase; val > 1; val /= 2) {
                yield return val;
            }
            yield return 0;
        }

        private int GetTotalRows(int type)
        {
            return type - 1;
        }

        private int GetStartJunk(int topPhase, int phase)
        {
            int count = 0;
            for (int i = topPhase; i != phase; i /= 2) {
                ++count;
            }
            int dummy = Convert.ToInt32(Math.Pow(count, 2));
            if (dummy > 1) {
                --dummy;
            }
            return dummy;
        }

        private int GetInnerJunk(int topPhase, int phase)
        {
            int count = 0;
            for (int i = topPhase; i != phase; i /= 2) {
                ++count;
            }

            switch (count) {
                case 0: return 1;
                case 1: return 3;
                case 2: return 7;
                case 3: return 15;
                case 4: return 31;
            }

            return 0;
        }

        private string GetAvatar(int p)
        {
            IList<Principal> list = null;
            if (State.HasItems("PrincipalAvatarList")) {
                list = (IList<Principal>)State.GetItems("PrincipalAvatarList");
            } else {
                list = GetAllPrincipals();
                State.SetItems("PrincipalAvatarList", list);
            }

            string avatar = null;

            foreach (Principal principal in list) {
                if (principal.Id == p) {
                    avatar = principal.Avatar;
                    break;
                }
            }

            if (string.IsNullOrEmpty(avatar)) {
                avatar = ResourcesManager.DefaultAvatar;
            }

            return avatar;
        }

        private IList<Principal> GetAllPrincipals()
        {
            TextWriter query = new StringWriter();
            query.Write("from SpecializedPrincipal p where 1=0 ");
            foreach (Battle battle in Battles) {
                foreach(PlayerBattleInformation info in battle.PlayerInformation ) {
                    query.Write(" or p.Id = {0}", info.Owner);
                }
            }
            return Hql.StatelessQuery<Principal>(query.ToString());
        }

        #endregion Utils

    };
}
