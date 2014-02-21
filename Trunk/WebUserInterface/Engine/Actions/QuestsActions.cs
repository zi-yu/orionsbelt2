using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Quests;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Quests;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	
	public class QuestsActions : ActionBase {

        #region Quests

		private void SetResult(Result result) {
			string css = "success";
			string token = "GenericSuccess";
			if (!result.Ok) {
				css = "information";
				token = "GenericFail";
			}
			HttpContext.Current.Response.Write(string.Format("<div class='{0}'>{1}</div>", css, LanguageManager.Instance.Get(token)));
		}

		private IQuestData GetData() {
			string raw = HttpContext.Current.Request.QueryString["Id"];
			if (string.IsNullOrEmpty(raw)) {
				QuestData data = new QuestData();
				data.Player = PlayerUtils.Current;
				return data;
			}

			int id = int.Parse(raw);
			IList<QuestStorage> list = Hql.Query<QuestStorage>("select quest from SpecializedQuestStorage quest where quest.Id = :id", Hql.Param("id", id));
			IQuestData dbData = QuestConversion.ConvertStorageToQuest(list[0]);
			dbData.Player = PlayerUtils.Current;
			IList<IQuestData> quests = new List<IQuestData>();
			quests.Add(dbData);
			dbData.Player.Quests = quests;
			return dbData;
		}

		private IQuestInfo GetQuestInfo() {
			string qs = HttpContext.Current.Request.QueryString["Info"];
			if (string.IsNullOrEmpty(qs)) {
				throw new UIException("No Info at query string");
			}
			return QuestManager.GetQuestType(qs);
		}

		private bool ToAccept(IQuestInfo info) {
			return info.IsProgressive && string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["Id"]);
		}

		private bool MayCancel(IQuestInfo info) {
			return info.IsProgressive && !string.IsNullOrEmpty(HttpContext.Current.Request.QueryString["Id"]);
		}
		
		public static void WriteRequiredItems(TextWriter writer, IQuestInfo info) {
			if(info.MustHaveResources!= null){
				writer.Write("<h2>{0}</h2>", LanguageManager.Localize("RequiredItems"));
				writer.Write("<ul id='questResources'>");
				foreach (IResourceQuantity resource in info.MustHaveResources) {
					writer.Write("<li>{0}<br/>{1}</li>", ResourcesManager.GetResourceSmallImageHtml(resource.Resource), resource.Quantity);
				}
				writer.Write("</ul>");
			}
		}

		public void WriteDeliveredItems(TextWriter writer, IQuestInfo info) {
			if (info.MustHaveResources != null && !(info is ITradeRouteQuest)) {
				IQuestData data = GetData();
				if(data.QuestIntProgress.Count == 0) {
					return;
				}
				
				writer.Write("<h2>{0}</h2>", LanguageManager.Localize("DeliveredItems"));
				bool deliveredItems = false;
				foreach (IResourceQuantity resource in info.MustHaveResources) {
					int quantity = data.QuestIntProgress[resource.Resource.Name];
					if (quantity != 0) {
						if (!deliveredItems) {
							writer.Write("<ul id='questResources'>");							
						}
						writer.Write("<li>{0}<br/>{1}</li>", ResourcesManager.GetResourceSmallImageHtml(resource.Resource), quantity);
						deliveredItems = true;
					}
				}
				if (deliveredItems){
					writer.Write("</ul>");
					writer.Write("<p>{0}% {1}</p>", data.Percentage, LanguageManager.Localize("ItemsDelivered"));
				}else {
					writer.Write("<p>{0}</p>",LanguageManager.Localize("NoDeliveredItems"));
				}
			}
		}

        private static List<KeyValuePair<IResourceInfo, int>> GetUnits(Dictionary<IResourceInfo, int> dictionary) {
            List<KeyValuePair<IResourceInfo, int>> list = new List<KeyValuePair<IResourceInfo, int>>();
            foreach (KeyValuePair<IResourceInfo, int> pair in dictionary) {
                if(pair.Key is IUnitInfo) {
                    list.Add(pair);
                }
            }
            return list;
        }

        private static List<KeyValuePair<IResourceInfo, int>> GetResources(Dictionary<IResourceInfo, int> dictionary) {
            List<KeyValuePair<IResourceInfo, int>> list = new List<KeyValuePair<IResourceInfo, int>>();
            foreach (KeyValuePair<IResourceInfo, int> pair in dictionary) {
                if (pair.Key is BaseIntrinsic) {
                    list.Add(pair);
                }
            }
            return list;
        }

		public static void WriteReward(TextWriter writer, IQuestInfo info) {
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("Reward"));
            if (info.ScoreReward != 0) {
                writer.Write("<p><b>{0}:</b> {1}</p>", LanguageManager.Localize("ScoreReceived"), info.ScoreReward);
            }
            
            if (info.OrionsReward != 0) {
				writer.Write("<p><b>{0}:</b> {1} <img src='{2}' alt='{0}' title='{0}'/></p>", LanguageManager.Localize("Orions"), info.OrionsReward, ResourcesManager.GetIconsImage("Orions"));
			}
			
			if (info.ProfessionPoints != null) {
				writer.Write("<p><b>{0}:</b> ", LanguageManager.Localize("ProfessionReceived"));
				foreach (KeyValuePair<Profession, int> pair in info.ProfessionPoints) {
					writer.Write(" {0} : {1}", LanguageManager.Instance.Get(pair.Key.ToString()), pair.Value);
				}
				writer.Write("</p>");
			}
			if (info.IntrinsicRewards != null) {
                List<KeyValuePair<IResourceInfo, int>> resources = GetResources(info.IntrinsicRewards);
                if (resources.Count > 0){
                    writer.Write("<p><b>{0}:</b> ", LanguageManager.Localize("Resources"));
                    foreach (KeyValuePair<IResourceInfo, int> pair in resources) {
					    writer.Write("{0} {1} ", pair.Value, ResourcesManager.GetResourceSmallImageHtml(pair.Key.Name));
				    }
				    writer.Write("</p>");
                }
                
                List<KeyValuePair<IResourceInfo, int>> units = GetUnits(info.IntrinsicRewards);
                if (units.Count > 0) {
                    writer.Write("<p><b>{0}:</b> ", LanguageManager.Localize("Units"));
                    foreach (KeyValuePair<IResourceInfo, int> pair in units) {
                        writer.Write("{0} <img src='{1}' alt='{2}' title='{2}' class='resourceSmallNoBck'>", pair.Value, ResourcesManager.GetUnitImage(pair.Key.Name), LanguageManager.Localize(pair.Key.Name));
                    }
                    writer.Write("</p>");
                }
			}
		}

        private string PrepareQuest(IQuestInfo info) {
			TextWriter writer = new StringWriter();

			string title = string.Format("<h2>{0}</h2>",LanguageManager.Localize("QuestObjectives"));

            TextWriter content = new StringWriter();
            

            content.Write("<div id='questObjectives'>{0}</div>", GetQuestObjectives(info));
            WriteRequiredItems(content, info);
            WriteDeliveredItems(content, info);
            WriteReward(content, info);
            content.Write("<div id='result'></div>");

            TextWriter bottom = new StringWriter();
            bottom.Write("<div id='questButtons'>");
			if (ToAccept(info)) {
                GenericRenderer.WriteInputButton(bottom, "accept", LanguageManager.Localize("Accept"), string.Format("Quests.accept(\"{0}\",\"{1}\");", info.Name, HttpContext.Current.Request.QueryString["Target"]));
			} else {
				string id = HttpContext.Current.Request.QueryString["Id"];
                GenericRenderer.WriteInputButton(bottom, "deliver", LanguageManager.Localize("Deliver"), string.Format("Quests.deliver(\"{0}\",\"{1}\");", info.Name, id));
			}
			if (MayCancel(info)) {
				string id = HttpContext.Current.Request.QueryString["Id"];
                GenericRenderer.WriteInputButton(bottom, "abandon", LanguageManager.Localize("AbandonQuest"), string.Format("Quests.cancel(\"{0}\",\"{1}\");", info.Name, id));
			}
            bottom.Write("</div>");

            Border.RenderNormalOpac(writer, title, content.ToString(), bottom.ToString());
			return writer.ToString();
		}

        private static string GetQuestObjectives(IQuestInfo info) {
            string translation = LanguageManager.Instance.Get(info.Name + "Manual");
            if (translation.Contains("[Universe]")) {
                translation = translation.Replace("[Universe]", LanguageManager.Localize("Universe"));
            }
            if (translation.Contains("[Arenas]")) {
                translation = translation.Replace("[Arenas]", LanguageManager.Localize("Arenas"));
            }
            return translation;
        }

		#endregion Quests

		#region Bounties

		#region Utils

		private static string GetOrions(IQuestData data) {
			return data.QuestIntConfig["Reward"].ToString();
		}

		private static object GetTargetLink(IQuestData data) {
			return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
					WebUtilities.ApplicationPath, data.QuestIntConfig["TargetId"], data.QuestStringConfig["TargetName"]
				);
		}

		private static string GetSourceLink(IQuestData data) {
			return string.Format("<a href='{0}PlayerInfo.aspx?PlayerStorage={1}'>{2}</a>",
					WebUtilities.ApplicationPath, data.QuestIntConfig["SourceId"], data.QuestStringConfig["SourceName"]
				);
		}

		#endregion Utils

		private static IQuestData GetBounty() {
			QuestStorage storage = EntityUtils.GetFromQueryString<QuestStorage>("Id");
			IQuestData data = QuestConversion.ConvertStorageToQuest(storage);
			State.SetItems(data);
			return data;
		}

		private static bool GetAbandonState() {
			foreach (IQuestData data in BountyParticipantsRender.GetQuestList()) {
				if (data.Storage.Player.Id == PlayerUtils.Current.Id && data.QuestIntProgress["Points"] == 0) {
					return true;
				}
			}

			return false;
		}

		private static bool GetAcceptState(IQuestData template) {
			if (template.QuestIntConfig["TargetId"] == PlayerUtils.Current.Id ||
				template.QuestIntConfig["SourceId"] == PlayerUtils.Current.Id ||
				template.Completed || template.Percentage >= 100) {
				return false;
			}


			foreach (IQuestData data in BountyParticipantsRender.GetQuestList()) {
				if (data.Storage.Player.Id == PlayerUtils.Current.Id) {
					return false;
				}
			}

			return true;
		}

		private static string GetTitle(IQuestData data) {
			return string.Format(LanguageManager.Instance.Get("CustomBountyInfo"),
					GetSourceLink(data),
					GetOrions(data),
					GetTargetLink(data)
				);
		}

		private static string GetObjective(IQuestData data) {
			return string.Format(LanguageManager.Instance.Get("CustomBountyObjective"), data.QuestIntConfig["Points"]);
		}

		private static string PrepareBounty(IQuestData questData) {
			TextWriter writer = new StringWriter();
			
            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("QuestObjectives"));

            TextWriter content = new StringWriter();
            content.Write("<div id='questObjectives'>{0}<br/>{1}</div>", GetTitle(questData), GetObjective(questData));
            content.Write("<h2>{0}</h2>", LanguageManager.Localize("Reward"));
            content.Write("<p><b>{0}:</b> {1} <img src='{2}' alt='{0}' title='{0}'/></p>", LanguageManager.Localize("Orions"), GetOrions(questData), ResourcesManager.GetIconsImage("Orions"));
            content.Write("<div id='result'></div>");
            content.Write("<div id='registeredHunters'>");
            BountyParticipantsRender.Render(content);
            content.Write("</div>");

            TextWriter bottom = new StringWriter();
            bottom.Write("<div id='questButtons'>");
            if (GetAcceptState(questData)) {
                GenericRenderer.WriteInputButton(bottom, "accept", LanguageManager.Localize("Accept"), string.Format("Quests.acceptBounty(\"{0}\");", questData.Storage.Id));
            }

            if (GetAbandonState()) {
                GenericRenderer.WriteInputButton(bottom, "abandon", LanguageManager.Localize("AbandonQuest"), string.Format("Quests.cancelBounty(\"{0}\");", questData.Storage.Id));
            }
            bottom.Write("</div>");

            Border.RenderNormalOpac(writer, title, content.ToString(), bottom.ToString());

			return writer.ToString();
		}

		#endregion Bounties

		#region Delegates

		private void CheckQuest() {
			try {
				IQuestInfo info = GetQuestInfo();
				HttpContext.Current.Response.Write(PrepareQuest(info));
			} catch (UIException) {
				HttpContext.Current.Response.Write("0");
			}
		}

		private void CheckBounty() {
			IQuestData questData = GetBounty();
			HttpContext.Current.Response.Write(PrepareBounty(questData));
		}

		private void Cancel() {
			IQuestData data = GetData();
			data.Info.OnAbandon(data);
			using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
				persistance.Delete(data.Storage);
				persistance.Flush();
			}
		}

		private void AcceptQuest() {
			IQuestInfo info = GetQuestInfo();
			if (!AvailableQuestList.CanIncludeQuestInfo(PlayerUtils.Current.Quests, info)) {
				throw new UnAuthorizedException();
			}
			IQuestData data = info.AddToPlayer(PlayerUtils.Current);
			info.PrepareDataFromArgs(data, HttpContext.Current.Request.QueryString);
			GameEngine.Persist(PlayerUtils.Current);
		}

		private void DeliverQuest() {
			IQuestInfo info = GetQuestInfo();
			IQuestData data = GetData();

			Result result = info.CanComplete(data);
			
			if (result.Ok) {
				info.Complete(data);
			}

			using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
				persistance.Update(Utils.Principal);
				GameEngine.Persist(PlayerUtils.Current,false,true);
			}

			SetResult(result);
		}

		private static void AcceptBounty() {
			IQuestData data = GetBounty();
			if (GetAcceptState(data)) {
				IQuestData newData = QuestManager.AcceptCustomBounty(PlayerUtils.Current, data);
				BountyParticipantsRender.GetQuestList().Add(newData);
			}
		}

		private static void CancelBounty() {
			QuestManager.AbandonCustomBounty(PlayerUtils.Current, GetBounty());
		}

		private static void DeliverAcademyQuestItem() {
			AcademyQuestDelivery.DeliverQuestItems();
		}

		#endregion Delegates

		#region Constructor

		public QuestsActions() {
			actions["quest"] = CheckQuest;
			actions["bounty"] = CheckBounty;
			actions["accept"] = AcceptQuest;
			actions["deliver"] = DeliverQuest;
			actions["cancel"] = Cancel;
			actions["acceptBounty"] = AcceptBounty;
			actions["cancelBounty"] = CancelBounty;
			actions["deliverAcademyQuestItem"] = DeliverAcademyQuestItem;
		}

		#endregion Constructor
	
	}
}
