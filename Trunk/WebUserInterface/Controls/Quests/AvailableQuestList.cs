using System.Web;
using System.Web.UI;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.UniverseInfo;
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
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

	public class AvailableQuestList : Control {

        #region Events

        protected override void Render(HtmlTextWriter mainwriter)
        {
            TutorialManager.Current = Tutorial.CheckpointQuest;

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get("AvailableQuests"));

            StringWriter writer = new StringWriter();
            writer.Write("<table class='newtable' id='quests'>");

            writer.Write("<tr>");
			writer.Write("<th class='questText'>{0}</th>", LanguageManager.Instance.Get("Quest"));
			//writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Reward"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Context"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Type"));
            writer.Write("<th style='width:100px;'>{0}</th>", LanguageManager.Instance.Get("Help"));
            writer.Write("<th style='width:100px;'></th>");
            writer.Write("</tr>");

            WriteQuests(writer);
            writer.Write("</table>");

            Border.RenderBig(mainwriter, title, writer.ToString());
        }

        private void WriteQuests(TextWriter writer)
        {
            foreach (IQuestData data in PlayerUtils.Current.Quests) {
				WriteQuestData(writer, data);
            }

            foreach (IQuestInfo info in QuestManager.GetQuests(PlayerUtils.Current))  {
#if !DEBUG
					if(info.Context == QuestContext.Mercs || info.Context == QuestContext.SpaceForce) {
					    continue;
					}
#endif
                if (CanIncludeQuestInfo(PlayerUtils.Current.Quests, info))  {
                    WriteQuestInfo(writer, info);
                }
            }
        }

        public static bool CanIncludeQuestInfo(IList<IQuestData> list, IQuestInfo info)
        {
            foreach (IQuestData data in list) {
                if (data.Info == info && !info.CanAcceptMultiple ) {
                    return false;
                }
                if (info.IsExclusive && data.Info.IsExclusive) {
                    return false;
                }
            }
            return true;
        }

        private void WriteQuestData(TextWriter writer, IQuestData data)
        {
            writer.Write("<tr>");

            WriteDataTitle(writer, data);
			writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(data.Info.Context.ToString()));
			WriteType(writer, data.Info);
            WriteHelp(writer, data.Info);

			//writer.Write("<td>");
			//WriteRewards(writer, data, true);
			//writer.Write("</td>");

            if (links.ContainsKey(data.Info.Name)) {
                writer.Write("<td>");
                links[data.Info.Name](writer, data);
                writer.Write("</td>");
            } else {
                writer.Write("<td><div class='buttonSmall'><a href='javascript:Quests.getQuest2(\"{0}\",\"{1}\");'>{2}</a></div></td>", data.Info.Name, data.Storage.Id, LanguageManager.Localize("Deliver"));
                //writer.Write("<td><a href='Quest.aspx?Info={0}&Id={1}'>{2}</a></td>", data.Info.Name, data.Storage.Id, LanguageManager.Instance.Get("Deliver"));
            }

            writer.Write("</tr>");
        }

        private void WriteType(TextWriter writer, IQuestInfo info)
        {
            string key = "CheckPoint";
            if (info.IsProgressive) {
                key = "Task";
            }
            writer.Write("<td><a href='{0}Manual.aspx?path=Quests.aspx#Types'>{1}</a></td>",
                    WebUtilities.ApplicationPath,
                    LanguageManager.Instance.Get(key)
                );
        }

        private static void WriteDataTitle(TextWriter writer, IQuestData data)
        {
			writer.Write("<td class='questText'>");
            if (titles.ContainsKey(data.Info.Name)) {
                titles[data.Info.Name](writer, data);
            } else {
                if (!string.IsNullOrEmpty(data.Name)) {
                    writer.Write("{0} - ", data.Name);
                }
                writer.Write("{0} ({1}% {2}", LanguageManager.Instance.Get(data.Info.Name), data.Percentage, LanguageManager.Instance.Get("Complete"));
                if (data.DeadlineTick > 0) {
                    if (data.DeadlineTick >= Clock.Instance.Tick) { 
                        writer.Write(" - {0}: <span class='green'>{1}</span>", LanguageManager.Instance.Get("Deadline"), TimeFormatter.GetFormattedTicksTo(data.DeadlineTick));
                    } else {
                        writer.Write(" - <span class='red'>{0}</span>", LanguageManager.Instance.Get("TimeIsUp"));
                    }
                }
                writer.Write(")");
            }
            writer.Write("</td>");
        }

        private void WriteHelp(TextWriter writer, IQuestInfo info)
        {
            writer.Write("<td><div class='buttonSmall'><a href='{0}Manual.aspx?path=Quest/{1}.aspx'>{2}</a></div></td>",
                    WebUtilities.ApplicationPath,
                    info.Name,
                    LanguageManager.Instance.Get("Help")
                );
        }

        private void WriteQuestInfo(TextWriter writer, IQuestInfo info)
        {
            writer.Write("<tr>");

            writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(info.Name));
			writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(info.Context.ToString()));
			WriteType(writer, info);
            WriteHelp(writer, info);

            //writer.Write("<td>");
            //WriteRewards(writer, info, true);
            //writer.Write("</td>");

			//if (info.IsProgressive) {
			//    //writer.Write("<td><a href='Quest.aspx?Info={0}'>{1}</a></td>", info.Name, LanguageManager.Instance.Get("Accept"));
			//    writer.Write("<td><a href='javascript:Quests.getQuest(\"{0}\");'>{1}</a></td>", info.Name, LanguageManager.Instance.Get("Accept"));
			//    TutorialManager.Current = Tutorial.TaskQuest;
			//} else {
			//    writer.Write("<td><a href='javascript:Quests.getQuest(\"{0}\");'>{1}</a></td>", info.Name, LanguageManager.Instance.Get("More"));
			//    //writer.Write("<td><a href='Quest.aspx?Info={0}'>{1}</a></td>", info.Name, LanguageManager.Instance.Get("More"));
			//}
            writer.Write("<td ><div class='buttonSmall'><a href='javascript:Quests.getQuest(\"{0}\");'>{1}</a></div></td>", info.Name, LanguageManager.Instance.Get("More"));

            writer.Write("</tr>");
        }

        public static void WriteRewards(TextWriter writer, IQuestData data, bool includeOrions)
        {
            writer.Write("<ul>");
            QuestManager.WriteInfoSpecificRewards(writer, data.Info, includeOrions, false);
            int dataScore = data.Info.GetDataScore(data);
            if (dataScore > 0) {
                writer.Write("<li>{0} : {1}</li>", LanguageManager.Instance.Get("Score"), dataScore);
            }
            writer.Write("</ul>");
        }

        public static void WriteRewards(TextWriter writer, IQuestInfo info, bool includeOrions)
        {
            
            QuestManager.WriteInfoSpecificRewards(writer, info, includeOrions, true);

        }

        #endregion Events

        #region Static Handlers

        private delegate void WriteData(TextWriter writer, IQuestData data);
        private static Dictionary<string, WriteData> titles = new Dictionary<string, WriteData>();
        private static Dictionary<string, WriteData> links = new Dictionary<string, WriteData>();

        static AvailableQuestList()
        {
            titles.Add("CustomPlayerBounty", WriteCustomBountyTitle);

            links.Add("CustomPlayerBounty", WriteCustomBountyLink);
        }

        private static void WriteCustomBountyTitle(TextWriter writer, IQuestData data)
        {
            writer.Write( OrionsBelt.WebUserInterface.Quests.BountyPage.GetTitle(data) );
        }

        private static void WriteCustomBountyLink(TextWriter writer, IQuestData data)
        {
//            writer.Write("<a href='Bounty.aspx?Id={0}'>{1}</a>", data.Name, LanguageManager.Instance.Get("More"));
            writer.Write("<div class='buttonSmall'><a href='javascript:Quests.getBounty(\"{0}\");'>{1}</a></div>", data.Name, LanguageManager.Instance.Get("More"));
        }

        #endregion Static Handlers

    };
}

