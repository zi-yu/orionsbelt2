using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class TeamELOStats : ControlBase
    {
        private TeamStorage currTeam;

        public TeamStorage CurrTeam
        {
            get { return currTeam; }
            set { currTeam = value; }
        }

        #region Control Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (currTeam != null)
            {
                IList<PrincipalStats> stats =
                    Hql.Query<PrincipalStats>("select s from SpecializedPrincipalStats s where s.Id = :id",
                                              Hql.Param("id", currTeam.MyStatsId));                

                GeneralStats(stats);
                BattleStats(stats);

                Write("</table>");
            }
        }

        private void BattleStats(IList<PrincipalStats> stats)
        {
            Write("<table class='newtable'><tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>",
                  LanguageManager.Instance.Get("Type"),
                  LanguageManager.Instance.Get("Wins"),
                  LanguageManager.Instance.Get("Defeats"),
                  LanguageManager.Instance.Get("GiveUps"),
                  LanguageManager.Instance.Get("Total"));

            if (0 < stats.Count)
            {
                int wins = 0;
                int defeats = 0;
                int giveUps = 0;
                int totals = 0;
                foreach (Core.BattleStats stat in stats[0].BattleStats)
                {
                    int total = stat.Wins + stat.Defeats;
                    totals += total;
                    wins += stat.Wins;
                    defeats += stat.Defeats;
                    giveUps += stat.GiveUps;
                    
                    Write("<tr><td>{0}</td><td><span class='green'>{1} ({5}%)</span></td><td><span class='red'>{2} ({6}%)</span></td><td>{3}</td><td>{4}</td></td></tr>",
                          LanguageManager.Instance.Get(stat.Type), stat.Wins.ToString(),
                          stat.Defeats.ToString(), stat.GiveUps.ToString(), total.ToString(),
                        (stat.Wins * 100 / total).ToString(), (100 - (stat.Wins * 100 / total)).ToString());

                }
                if (0 != totals)
                {
                    Write(
                        "<tr><th>{0}</th><td><span class='green'>{1} ({5}%)</span></td><td><span class='red'>{2} ({6}%)</span></td><td>{3}</td><td>{4}</td></td></tr>",
                        LanguageManager.Instance.Get("Total"), wins.ToString(),
                        defeats.ToString(), giveUps.ToString(), totals.ToString(),
                        (wins*100/totals).ToString(), (100 - (wins*100/totals)).ToString());
                }
                else
                {
                    Write(
                        "<tr><th>{0}</th><td><span class='green'>0 (0%)</span></td><td><span class='red'>0 (0%)</span></td><td>0</td><td>0</td></td></tr>",
                        LanguageManager.Instance.Get("Total"));
                }
            }
        }

        private void GeneralStats(IList<PrincipalStats> stats)
        {
            Write("<table class='newtable'><tr><th rowspan='2'>{0}</th><th colspan='3'>ELO</th><th colspan='3'>{1}</th></tr><tr><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th><th>{6}</th><th>{7}</th></tr>",
                  LanguageManager.Instance.Get("NumberOfBattles"),
                  LanguageManager.Instance.Get("Ladder"),
                  LanguageManager.Instance.Get("CurrPoints"),
                  LanguageManager.Instance.Get("Max"),
                  LanguageManager.Instance.Get("Min"),
                  LanguageManager.Instance.Get("CurrPosition"),
                  LanguageManager.Instance.Get("Best"),
                  LanguageManager.Instance.Get("Worst"));

            if (0 < stats.Count)
            {
                Write("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td>",
                      stats[0].NumberPlayedBattles.ToString(), currTeam.EloRanking.ToString(),
                      stats[0].MaxElo.ToString(), stats[0].MinElo.ToString());

                if (currTeam.LadderActive)
                {
                    Write("<td>{0}</td><td>{1}</td><td>{2}</td></tr></table>",
                          currTeam.LadderPosition.ToString(), stats[0].MaxLadder.ToString(), stats[0].MinLadder.ToString());
                }
                else
                {
                    Write("<td>{0}</td><td>{0}</td><td>{0}</td></tr></table>",
                          LanguageManager.Instance.Get("Inactive"));
                }
            }
            else
            {
                Write("<tr><td>0</td><td>1000</td><td>1000</td><td>1000</td>");

                if (currTeam.LadderActive)
                {
                    Write("<td>{0}</td><td>{0}</td><td>{0}</td></tr></table>",
                          currTeam.LadderPosition.ToString());
                }
                else
                {
                    Write("<td>{0}</td><td>{0}</td><td>{0}</td></tr></table>",
                          LanguageManager.Instance.Get("Inactive"));
                }
            }
        }

        #endregion Control Events

      
    }
}