using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;
using OrionsBelt.Engine.Quests;
using System.IO;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PirateBountyList : Control {

        #region Events

        protected override void Render(HtmlTextWriter mainwriter)
        {
            if (CurrPlayerAlreadyHasBounty()) {
                return;
            }

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("PiratePrizeList"));

            StringWriter writer = new StringWriter();
            writer.Write("<table class='newtable'>");

            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Player"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Level"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Alliance"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Context"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Reward"));
            writer.Write("<th style='width:100px'></th>");
            writer.Write("</tr>");

            IList<PlayerStorage> players = GetPlayerList();
            if (players.Count == 0) {
                writer.Write("<tr><td colspan='4'>{0}</td></tr>", LanguageManager.Instance.Get("NoneAvailable"));
            } else {
                WritePlayerBounties(writer, players);
            }

            writer.Write("</table>");

            Border.RenderBig(mainwriter, title, writer.ToString());
        }

        private bool CurrPlayerAlreadyHasBounty()
        {
            //foreach (IQuestData data in PlayerUtils.Current.Quests) {
            //    if (data.Info is PlayerBounty) {
            //        return true;
            //    }
            //    if (data.Info.IsExclusive) {
            //        return true;
            //    }
            //}
            return false;
        }

        private void WritePlayerBounties(TextWriter writer, IList<PlayerStorage> players)
        {
            IQuestInfo playerBounty = QuestManager.GetQuestType("PlayerBounty");
            foreach (PlayerStorage storage in players) {
                if (storage.Id == PlayerUtils.Current.Id || AlreadyOnQuest(storage)) {
                    continue;
                }
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", WebUtilities.WritePlayerWithAvatar(storage));
                writer.Write("<td>{0}</td>", storage.PlanetLevel);
                if (storage.Alliance != null) {
                    writer.Write("<td><a href='{0}Alliance/Info.aspx?Id={1}'>{2}</a></td>", WebUtilities.ApplicationPath, storage.Alliance.Id, storage.Alliance.Name);
                } else {
                    writer.Write("<td></td>");
                }
                writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(QuestContext.BountyHunter.ToString()));
                writer.Write("<td>");
                WriteRewards(writer, playerBounty, storage);
                writer.Write("</td>");
                //writer.Write("<td><a href='Quest.aspx?Info={0}&Target={2}'>{1}</a></td>", playerBounty.Name, LanguageManager.Instance.Get("Accept"), storage.Id);
                writer.Write("<td><div class='buttonSmall'><a href='javascript:Quests.getQuest3(\"{0}\",\"{1}\");'>{2}</a></div></td>", playerBounty.Name, storage.Id, LanguageManager.Localize("More"));

                writer.Write("</tr>");
            }
        }

        private bool AlreadyOnQuest(PlayerStorage storage)
        {
            foreach (IQuestData data in PlayerUtils.Current.Quests) {
                if (data.Info is PlayerBounty && data.QuestIntConfig.ContainsKey("TargetPlayerId") && data.QuestIntConfig["TargetPlayerId"] == storage.Id) {
                    return true;
                }
            }
            return false;
        }

        private static void WriteRewards(TextWriter writer, IQuestInfo info, PlayerStorage storage)
        {
            writer.Write("{0} {1}", PlayerBounty.GetScoreReward(storage.PlanetLevel), LanguageManager.Instance.Get("Score"));
        }

        private IList<PlayerStorage> GetPlayerList()
        {
            return Hql.StatelessQuery<PlayerStorage>(0, 50, "select player from SpecializedPlayerStorage player left join fetch player.AllianceNHibernate alliance where player.PirateRanking > player.MerchantRanking and player.PirateRanking > player.BountyRanking and player.PlanetLevel >= :planetLevel order by player.PlanetLevel desc, player.BountyRanking desc", new KeyValuePair<string, object>[] { new KeyValuePair<string, object>("planetLevel", PlayerUtils.Current.PlanetLevel - 3) });
        }

        #endregion Events

    };
}

