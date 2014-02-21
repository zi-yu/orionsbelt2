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

	public class CustomBountyList : Control {

        #region Events

        protected override void Render(HtmlTextWriter mainwriter)
        {
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("CustomBountyPrizeList"));

            StringWriter writer = new StringWriter();
            writer.Write("<table class='newtable'>");

            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Target"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Complete"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Reward"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("BountyClient"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Context"));
            writer.Write("<th style='width:100px'></th>");
            writer.Write("</tr>");

            IList<QuestStorage> quests = GetQuestList();
            if (quests.Count == 0) {
                writer.Write("<tr><td colspan='6'>{0}</td></tr>", LanguageManager.Instance.Get("NoneAvailable"));
            } else {
                WritePlayerBounties(writer, quests);
            }

            writer.Write("</table>");

            Border.RenderBig(mainwriter, title, writer.ToString());
        }

        private void WritePlayerBounties(TextWriter writer, IList<QuestStorage> quests)
        {
            foreach (QuestStorage storage in quests) {
                IQuestData data = QuestConversion.ConvertStorageToQuest(storage);
                writer.Write("<tr {0}>",HasQuest(storage.Id));

                writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>", WebUtilities.ApplicationPath, data.QuestIntConfig["TargetId"], data.QuestStringConfig["TargetName"]);
                writer.Write("<td>{0:#0} %</td>", data.Percentage);
                writer.Write("<td>{0} {1}</td>", data.QuestIntConfig["Reward"], LanguageManager.Instance.Get("Orions"));
                writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>", WebUtilities.ApplicationPath, data.QuestIntConfig["SourceId"], data.QuestStringConfig["SourceName"]);
                writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(QuestContext.BountyHunter.ToString()));
                //writer.Write("<td><a href='Bounty.aspx?Id={0}'>{1}</a></td>", storage.Id, LanguageManager.Instance.Get("More"));
				writer.Write("<td><div class='buttonSmall'><a href='javascript:Quests.getBounty(\"{0}\");'>{1}</a></div></td>", storage.Id, LanguageManager.Instance.Get("More"));

                writer.Write("</tr>");
            }
        }

        private bool HasQuest(int id) {
            foreach (QuestData q in PlayerUtils.Current.Quests) {
                if (q.Storage.Id == id) {
                    return true;
                }
            }
            return false;
        }

        private IList<QuestStorage> GetQuestList()
        {
            return Hql.StatelessQuery<QuestStorage>("select quest from SpecializedQuestStorage quest where quest.Type = 'CustomPlayerBountyTemplate' and quest.Completed = false order by quest.CreatedDate desc", null);
        }

        #endregion Events

    };
}

