
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Quests;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class AcademyQuestDelivery : ControlBase {

		#region Fields

		private IFleetInfo fleet;

		#endregion Fields

		#region Properties

		#endregion Properties

		#region Private

		private static IQuestData MercQuestForDelivery() {
			foreach (IQuestData data in PlayerUtils.Current.Quests) {
				if (data.Info is MercQuest) {
					return data;
				}
			}
			return null;
		}

		private static string GetDeliverEvent(IFleetInfo fleet) {
			string system = HttpContext.Current.Request.QueryString["systemDst"];
			string sector = HttpContext.Current.Request.QueryString["sectorDst"];
			return string.Format("Quests.deliverAcademyQuestItem({0},\"{1}\",\"{2}\");", fleet.Id, system, sector);
		}

		private static void ItemsToDeliver(TextWriter writer, IQuestData mobsQuestData, IFleetInfo fleet) {
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("ItemsToDeliver"));
			List<IResourceQuantity> resources = GetQuestItemsInFleet(fleet,mobsQuestData);
			if (resources.Count > 0) {
				writer.Write("<ul id='questResources'>");
				foreach (IResourceQuantity resource in resources) {
					writer.Write("<li>{0}<br/>{1}</li>", ResourcesManager.GetResourceSmallImageHtml(resource.Resource), resource.Quantity);
				}
				writer.Write("</ul>");
				writer.Write("<div id='questButtons'>");

				GenericRenderer.WriteInputButton(writer, "deliverQuestItems", LanguageManager.Localize("DeliverQuestItems"), GetDeliverEvent(fleet));
				writer.Write("</div>");
			} else {
				writer.Write("<p>{0}</p>", LanguageManager.Localize("FleetDoesNotHaveCargo"));
			}
		}

		private static void ItemsDelivered(TextWriter writer, IQuestData mobsQuestData) {
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("DeliveredItems"));
			bool deliveredItems = false;
			foreach (IResourceQuantity resource in mobsQuestData.Info.MustHaveResources) {
				int quantity = mobsQuestData.QuestIntProgress[resource.Resource.Name];
				if (quantity != 0) {
					if (!deliveredItems) {
						writer.Write("<ul id='questResources'>");
					}
					writer.Write("<li>{0}<br/>{1}</li>", ResourcesManager.GetResourceSmallImageHtml(resource.Resource), quantity);
					deliveredItems = true;
				}
			}
			if (deliveredItems) {
				writer.Write("</ul>");
				writer.Write("<p>{0}% {1}</p>", mobsQuestData.Percentage, LanguageManager.Localize("ItemsDelivered"));
			} else {
				writer.Write("<p>{0}</p>", LanguageManager.Localize("NoDeliveredItems"));
			}
		}

		private static List<IResourceQuantity> GetQuestItemsInFleet(IFleetInfo fleet, IQuestData data) {
			List<IResourceQuantity> list = new List<IResourceQuantity>();
			if (fleet.Cargo == null) {
				return list;
			}

			foreach (IResourceQuantity resource in data.Info.MustHaveResources) {
				if( fleet.Cargo.ContainsKey(resource.Resource)) {
					int cargoQuantity = fleet.Cargo[resource.Resource];
					int currentQuantity = data.QuestIntProgress[resource.Resource.Name];
					int total = currentQuantity + cargoQuantity;

					if( total > resource.Quantity) {
						cargoQuantity = resource.Quantity - currentQuantity;
					}

					if (cargoQuantity > 0){
						list.Add(new ResourceQuantity(resource.Resource, cargoQuantity));
					}
				}
			}
			return list;
		}

		private static void Render(TextWriter writer, IFleetInfo fleet, IQuestData mobsQuestData) {
			if (mobsQuestData != null) {
				writer.Write("<div id='questsToDeliver'>");
				writer.Write("<h1>{0}</h1>", LanguageManager.Localize("CurrentQuest"));
				writer.Write("<p>{0}</p>", LanguageManager.Localize(mobsQuestData.Info.GetType().Name));

				if (fleet.HasCargo) {
					ItemsToDeliver(writer, mobsQuestData, fleet);
				} else {
					writer.Write("<p>{0}</p>", LanguageManager.Localize("FleetDoesNotHaveCargo"));
				}

				ItemsDelivered(writer, mobsQuestData);

				writer.Write("</div>");
			}
		}

		#endregion Private

		#region Public
		
		public static void DeliverQuestItems() {
			IQuestData mobsQuestData = MercQuestForDelivery();
			IFleetInfo fleet = new FleetInfo(EntityUtils.GetFromQueryString<Fleet>());
			Coordinate system = new Coordinate(HttpContext.Current.Request.QueryString["system"]);
			Coordinate sector = new Coordinate(HttpContext.Current.Request.QueryString["sector"]);

			SectorCoordinate academyCoordinate = new SectorCoordinate(system, sector);

			List<IResourceQuantity> resources = GetQuestItemsInFleet(fleet, mobsQuestData);
			foreach (IResourceQuantity res in resources) {
				fleet.DecrementCargo(res.Resource,res.Quantity);
			}

			QuestManager.ProcessMobs(academyCoordinate, PlayerUtils.Current, resources.ToArray());
			//Message msg = LanguageManager.Instance.Get("MarketTradeRouteSuccess");

			using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
				session.StartTransaction();

				//Messenger.Add();
				GameEngine.Persist(PlayerUtils.Current, false, false);
				GameEngine.Persist(fleet);

				session.CommitTransaction();
			}

			StringWriter writer = new StringWriter();
			Render(writer, fleet, mobsQuestData);
			HttpContext.Current.Response.Write(writer.ToString());
		}

		#endregion

		#region Control Events

		protected override void OnInit(System.EventArgs e) {
			fleet = new FleetInfo(EntityUtils.GetFromQueryString<Fleet>());
		}

		protected override void Render(HtmlTextWriter writer) {
			IQuestData mobsQuestData = MercQuestForDelivery();
			Render(writer, fleet, mobsQuestData);
		}

		#endregion Control Events
	}
}
