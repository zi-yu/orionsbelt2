using System;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Quests {
	public class BountyParticipantsRender {

		#region Events

		public static void Render(TextWriter writer) {
			writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("BountyParticipants"));
			writer.Write("<table class='newtable'>");

			writer.Write("<tr>");
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Player"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("PointsTaken"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Percentage"));
			writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Orions"));
			writer.Write("</tr>");

			IList<IQuestData> quests = GetQuestList();
			if (quests.Count == 0) {
				writer.Write("<tr><td colspan='5'>{0}</td></tr>", LanguageManager.Instance.Get("NoneAvailable"));
			} else {
				WritePlayerBounties(writer, quests);
			}

			writer.Write("</table>");
		}

		private static void WritePlayerBounties(TextWriter writer, IList<IQuestData> quests) {
			int totalPoints = 0;
			double totalPercentage = 0;
			int totalOrions = 0;

			foreach (IQuestData data in quests) {

				double percentage = GetPercentage(quests, data);
				int orions = Convert.ToInt32(Math.Round(percentage / 100 * QuestManager.GetRealVountyReward(data)));
				int points = data.QuestIntProgress["Points"];

				writer.Write("<tr>");
				writer.Write("<td><a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a></td>",
						WebUtilities.ApplicationPath, data.Storage.Player.Id, data.Storage.Player.Name
					);
				writer.Write("<td>{0}</td>", points);

				writer.Write("<td>{0:#0} %</td>", percentage);
				writer.Write("<td>{0}</td>", orions);
				writer.Write("</tr>");

				totalPoints += points;
				totalOrions += orions;
				totalPercentage += percentage;
			}

			writer.Write("<tr>");
			writer.Write("<td><strong>{0}</strong></td>", LanguageManager.Instance.Get("Total"));
			writer.Write("<td><strong>{0}</strong></td>", totalPoints);
			writer.Write("<td><strong>{0:#0.00}%</strong></td>", totalPercentage);
			writer.Write("<td><strong>{0}</strong></td>", totalOrions);
			writer.Write("</tr>");
		}

		private static double GetPercentage(IList<IQuestData> quests, IQuestData data) {
			double sum = 0;
			foreach (IQuestData curr in quests) {
				sum += curr.QuestIntProgress["Points"];
			}

			if (sum < data.QuestIntConfig["Points"]) {
				sum = data.QuestIntConfig["Points"];
			}

			double dataPoints = data.QuestIntProgress["Points"];
			return dataPoints / sum * 100;
		}

		internal static IList<IQuestData> GetQuestList() {
			if (State.HasItems<List<IQuestData>>()) {
				return State.GetItems<List<IQuestData>>();
			}

			IQuestData data = State.GetItems<IQuestData>();
			IList<QuestStorage> raw = Hql.StatelessQuery<QuestStorage>("select quest from SpecializedQuestStorage quest inner join fetch quest.PlayerNHibernate player where quest.Name = :id", Hql.Param("id", data.Storage.Id.ToString()));

			List<IQuestData> list = new List<IQuestData>();
			foreach (QuestStorage storage in raw) {
				list.Add(QuestConversion.ConvertStorageToQuest(storage));
			}
			State.SetItems<List<IQuestData>>(list);
			return list;
		}

		internal static IList<IQuestData> GetQuestList(IQuestData data) {
			if (State.HasItems<List<IQuestData>>()) {
				return State.GetItems<List<IQuestData>>();
			}

			IList<QuestStorage> raw = Hql.StatelessQuery<QuestStorage>("select quest from SpecializedQuestStorage quest inner join fetch quest.PlayerNHibernate player where quest.Name = :id", Hql.Param("id", data.Storage.Id.ToString()));

			List<IQuestData> list = new List<IQuestData>();
			foreach (QuestStorage storage in raw) {
				list.Add(QuestConversion.ConvertStorageToQuest(storage));
			}
			State.SetItems<List<IQuestData>>(list);
			return list;
		}

		#endregion Events
	}
}
