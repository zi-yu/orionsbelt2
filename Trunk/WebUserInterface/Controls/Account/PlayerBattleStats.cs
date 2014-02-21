using System;
using System.Collections;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.IO;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PlayerBattleStats : Control
    {
        #region Private

        private string BattleStats(IList stats) {
            StringWriter writer = new StringWriter();

            writer.Write("<table class='newtable'><tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>",
                  LanguageManager.Instance.Get("Type"),
                  LanguageManager.Instance.Get("Wins"),
                  LanguageManager.Instance.Get("Defeats"),
                  LanguageManager.Instance.Get("GiveUps"),
                  LanguageManager.Instance.Get("Total"));

            int wins = 0;
            int defeats = 0;
            int giveUps = 0;
            int totals = 0;

            int currWins = GetCount(stats, "Battle", false, false);
            wins += currWins;
            int currDefeats = GetCount(stats, "Battle", true, false);
            int currGiveUps = GetCount(stats, "Battle", true, true);
            giveUps += currGiveUps;
            currDefeats += currGiveUps;
            defeats += currDefeats;
            int tempTotal = currWins + currDefeats;
            totals += tempTotal;

            WriteTableRow(writer, currWins, currGiveUps, currDefeats, tempTotal, "Universe");

            currWins = GetCount(stats, "Arena", false, false);
            wins += currWins;
            currDefeats = GetCount(stats, "Arena", true, false);
            currGiveUps = GetCount(stats, "Arena", true, true);
            giveUps += currGiveUps;
            currDefeats += currGiveUps;
            defeats += currDefeats;
            tempTotal = currWins + currDefeats;
            totals += tempTotal;

            WriteTableRow(writer, currWins, currGiveUps, currDefeats, tempTotal, "Arena");


            if (0 != totals) {
                writer.Write(
                    "<tr><th>{0}</th><td><span class='green'>{1} ({5}%)</span></td><td><span class='red'>{2} ({6}%)</span></td><td>{3}</td><td>{4}</td></td></tr>",
                    LanguageManager.Instance.Get("Total"), wins.ToString(),
                    defeats.ToString(), giveUps.ToString(), totals.ToString(),
                    (wins * 100 / totals).ToString(), (100 - (wins * 100 / totals)).ToString());
            } else {
                writer.Write(
                    "<tr><th>{0}</th><td><span class='green'>0 (0%)</span></td><td><span class='red'>0 (0%)</span></td><td>0</td><td>0</td></td></tr>",
                    LanguageManager.Instance.Get("Total"));
            }

            writer.Write("</table>");

            return writer.ToString();
        }

        private void WriteTableRow(TextWriter writer, int currWins, int currGiveUps, int currDefeats, int tempTotal, string langKey) {
            if (0 != tempTotal) {
                writer.Write(
                    "<tr><td>{0}</td><td><span class='green'>{1} ({5}%)</span></td><td><span class='red'>{2} ({6}%)</span></td><td>{3}</td><td>{4}</td></td></tr>",
                    LanguageManager.Instance.Get(langKey), currWins.ToString(),
                    currDefeats.ToString(), currGiveUps.ToString(), tempTotal.ToString(),
                    (currWins * 100 / tempTotal).ToString(), (100 - (currWins * 100 / tempTotal)).ToString());
            } else {
                writer.Write(
                    "<tr><td>{0}</td><td><span class='green'>0 (0%)</span></td><td><span class='red'>0 (0%)</span></td><td>0</td><td>0</td></td></tr>",
                    LanguageManager.Instance.Get(langKey));

            }
        }

        private static int GetCount(IList stats, string type, bool hasLost, bool hasGaveUp) {
            foreach (IList stat in stats) {
                if (stat[0].ToString() == type &&
                    Convert.ToBoolean(stat[1].ToString()) == hasLost &&
                    Convert.ToBoolean(stat[2].ToString()) == hasGaveUp) {
                    return Convert.ToInt32(stat[3]);
                }
            }
            return 0;
        }

        #endregion

        #region Control Events

        protected override void Render(HtmlTextWriter writer){
            PlayerStorage curr = State.GetItems<PlayerStorage>();
            IList info;
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                info = persistance.Query(@"SELECT b.BattleMode,p.HasLost,p.HasGaveUp,count(p) 
                                    FROM SpecializedPlayerBattleInformation p
                                    inner join p.BattleNHibernate b
                                    where p.Owner={0} and b.HasEnded=1 and (b.BattleMode='Battle' or b.BattleMode='Arena')
                                    group by p.HasLost,p.HasGaveUp,b.BattleMode",curr.Id);
            }

            string title = string.Format("<h2>{0}</h2>",LanguageManager.Instance.Get("BattleStats"));
            string content = BattleStats(info);

            Border.RenderNormal("battleStats", writer, title, content);
        }

        #endregion Control Events

      
    }
}