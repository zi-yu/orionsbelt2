using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Controls {
	public class DisplayMob : Control {

		#region Fields

		private Principal principal;
		private string nameNoSpaces;
		private string race;

		#endregion Fields

		#region Control Events
		
		protected override void OnInit(EventArgs e) {
			string account = HttpContext.Current.Request.QueryString["Principal"];
			if (!string.IsNullOrEmpty(account)) {
				principal = Hql.Query<Principal>("from SpecializedPrincipal e left join fetch e.PlayerNHibernate p where e.Id = :id", Hql.Param("id", account))[0];
			}else {
				HttpContext.Current.Response.Redirect("~/Default.aspx");
			}
			nameNoSpaces = principal.Name.Replace(" ", "");
			race = principal.Player[0].Race;
		}

		protected override void Render(HtmlTextWriter writer) {
			writer.Write("<div id='mobLogo'><img src='{1}' alt='{0}' title='{0}'/></div>", LanguageManager.Localize(race), ResourcesManager.GetMobImage(race));
			writer.Write("<div id='mobImage'><img src='{0}' alt='{1}' title='{1}'/></div>", ResourcesManager.GetMobImage(nameNoSpaces), principal.Name);
			writer.Write("<div id='mobInfo'>");
			writer.Write("<h2>{0}</h2>",LanguageManager.Localize("Lore"));
			FramesHtml.FrameHtml(writer,string.Format("<div id='mobLore'>{0}</div>", LanguageManager.Localize(race + "Lore")));
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("Units"));
			FramesHtml.FrameHtml(writer,GetUnitsHtml());
			writer.Write("<h2>{0}</h2>", LanguageManager.Localize("Fleets"));
			WriteFleets(writer);
			writer.Write("</div>");
		}

		private string GetUnitsHtml() {
			StringWriter writer = new StringWriter();
			Race unitRace = (Race)Enum.Parse(typeof(Race), race);
			List<BaseUnit> units = Units.AllUnits.FindAll(delegate(BaseUnit u) {
				foreach( Race r in u.Races) {
					if (r.Equals(unitRace)) {
						return true;
					}
				}
				return false;
			});
			writer.Write("<div id='mobUnits'>");
			foreach (BaseUnit unit in units) {
				writer.Write("<a href='{2}'><img src='{0}' alt='{1}' title='{1}'/></a>", ResourcesManager.GetUnitImage(unit), LanguageManager.Localize(unit.Name), WebUtilities.GetManualLink("Unit",unit));
			}
			writer.Write("</div>");

			return writer.ToString();
		}

		private void WriteFleets(HtmlTextWriter writer) {
			foreach (PlayerStorage p in principal.Player) {
				string playerNameNoSpaces = p.Name.Replace(" ", "");
				WriteFleet(writer, p.Name, playerNameNoSpaces);	
			}
		}

		private void WriteFleet(HtmlTextWriter writer, string name, string simpleName) {
			FramesHtml.FrameHtmlTitleIcon(writer,name,LanguageManager.Localize(simpleName+"FleetDescription"),ResourcesManager.GetMobImage(nameNoSpaces+"Avatar"));
		}

		#endregion Control Events


	}
}
