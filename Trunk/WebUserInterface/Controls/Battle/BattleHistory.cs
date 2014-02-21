using OrionsBelt.WebUserInterface.WebBattle;
using System.Web.UI;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using System.Collections;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {
	public class BattleHistory : Control {

        #region Utils

        private static string query = @"select b from SpecializedBattle b inner join b.PlayerInformationNHibernate pi where b.HasEnded = :ended and ( ( b.BattleMode = 'Friendly' and pi.Owner = :principal )  or ( b.BattleMode = 'Campaign' and pi.Owner = :principal ) or ( b.BattleMode = 'Tournament' and pi.Owner = :principal ) or ( b.BattleMode = 'Battle' and pi.Owner = :player ) or ( b.BattleMode = 'Arena' and pi.Owner = :player )) order by b.UpdatedDate desc";

        protected virtual bool BattlesEnded {
            get { return true; }
        }

        protected virtual long GetCount()
        {
            object result = Hql.ExecuteScalar(query.Replace("select b", "select count(b)"),
                Hql.Param("ended", true),
                Hql.Param("player", PlayerUtils.Current.Id),
                Hql.Param("principal", Utils.Principal.Id)
            );
            if (result == null) {
                return 0;
            }
            return (long)result;
        }

        protected virtual IList<SimpleBattleInfo> LoadHistoryBattles()
        {
            Dictionary<string, object> param = new Dictionary<string, object>();
            param["player"] = PlayerUtils.Current.Id;
            param["principal"] = Utils.Principal.Id;
            param["ended"] = true;
            IList<Battle> battles = Hql.Query<Battle>(query, param);
            if (battles.Count > 0) {
                return LoadAllBattles(SimpleBattleInfos.GetHql(SimpleBattleInfos.GetWhere(battles)));
            }
            return null;
        }

        protected IList<SimpleBattleInfo> LoadAllBattles(string[] hql) 
        {
            List<SimpleBattleInfo> list = new List<SimpleBattleInfo>();
			using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
				IList battles = persistance.MultiQuery(hql, new Dictionary<string, object>());
				IList<Battle> allBattles = Hql.Unify(SectorUtils.ConvertToList<Battle>((IEnumerable)battles[0]));
				foreach (Battle battle in allBattles) {
                    list.Add(GetSimpleBattleInfo(battle));
				}
			}
            return list;
		}

        protected virtual SimpleBattleInfo GetSimpleBattleInfo(Battle battle)
        {
            return new SimpleBattleInfo(battle);
        }

        #endregion Utils

        #region Events

        protected override void OnInit(System.EventArgs e)
        {
            base.OnInit(e);
            long count = GetCount();
            State.SetItems(BasePagination<Battle>.CountKey, count);
        }

        protected override void Render(HtmlTextWriter writer)
        {
            int cols = 6;
            writer.Write("<table class='newtable'>");

            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Battle"));
            if (BattlesEnded) {
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Result"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Score"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("BattleType"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Mode"));
            } else {
                cols = 4;
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("WinPercentage"));
                writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("TimeLeft"));
            }
            writer.Write("<th></th>");
            writer.Write("</tr>");

            IList<SimpleBattleInfo> list = LoadHistoryBattles();
            if (list == null || list.Count == 0) {
                writer.Write("<tr>");
                writer.Write("<td colspan='{1}'>{0}</td>", GetNoBattlesText(), cols);
                writer.Write("</tr>");
                writer.Write("</table>"); 
                return;
            }
            
            foreach (SimpleBattleInfo info in list) {
                writer.Write("<tr>");
                writer.Write("<td>{2}</td>", WebUtilities.ApplicationPath, info.BattleId, info.GetOpponents(true));
                
                if (BattlesEnded) {
                    writer.Write("<td>{0}</td>", GetResultString(info));
                    writer.Write("<td>{0}{1}</td>", info.Score, GetOpponentsScore(info.Opponents));
                    writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(info.BattleType.ToString()));
                    //if (info.BattleMode == BattleMode.Tournament && info.TournamentId > 0) {
                    //    writer.Write("<td><a href='Tournaments/TournamentRegist.aspx?Tournament={1}'><{0}</a></td>", LanguageManager.Instance.Get(info.BattleMode.ToString()), info.TournamentId);
                    //} else {
                        writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(info.BattleMode.ToString()));
                    //}
                } else {
                    writer.Write("<td>{0}</td>", info.VictoryPercentage);
                    writer.Write("<td>{0}</td>", info.TimeLeft);
                }
                writer.Write("<td><div class='buttonSmall'><a href='{0}Battle/Battle.aspx?Id={1}'>{2}</a></div></td>", WebUtilities.ApplicationPath, info.BattleId, LanguageManager.Instance.Get("ViewBattle"));
                writer.Write("</tr>");
            }
            writer.Write("</table>");
        }

        protected virtual string GetNoBattlesText()
        {
            return LanguageManager.Instance.Get("NoBattles");
        }

        private object GetOpponentsScore(List<OtherPlayersInformations> list)
        {
            TextWriter writer = new StringWriter();
            foreach (OtherPlayersInformations info in list) {
                writer.Write(" - {0}", info.Score);
            }
            return writer.ToString();
        }

        private string GetResultString(SimpleBattleInfo info)
        {
            if (info.HasLost) {
                return string.Format("<span class='red'>{0}</span>", LanguageManager.Instance.Get("Lost"));
            }
            return string.Format("<span class='green'>{0}</span>", LanguageManager.Instance.Get("Won"));;
        }

        #endregion Events

    };
}
