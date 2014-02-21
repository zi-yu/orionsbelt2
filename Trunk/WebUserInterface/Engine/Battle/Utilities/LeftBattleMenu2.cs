using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.WebBattle;

namespace OrionsBelt.WebUserInterface.Engine {

	public class LeftBattleMenu2 {
		
		#region Delegates

		#endregion Delegates

		#region Private

		private static void RenderProperties(TextWriter writer) {
			writer.Write("<div class='unitProperties'><div>");
			writer.Write("<div id='specials'></div>");
			writer.Write("{0}: <span id='unitQuant'></span><br/>", LanguageManager.Instance.Get("Quantity"));
			writer.Write("{0}: <span id='baseAttack'></span><br/>", LanguageManager.Instance.Get("Attack"));
			writer.Write("{0}: <span id='baseDefense'></span><br/>", LanguageManager.Instance.Get("Defense"));
			writer.Write("{0}: <span id='hitPoints'></span><br/>", LanguageManager.Instance.Get("HitPoints"));
			writer.Write("{0}: <span id='movementCost'></span><br/>", LanguageManager.Instance.Get("MovementCost"));
			writer.Write("{0}: <span id='range'></span><br/>", LanguageManager.Instance.Get("Range"));
			writer.Write("</div></div>");
		}

		private static void RenderHowToAttack(TextWriter writer) {
			writer.Write("<div class='howToAttack'>");
			writer.Write("<div><table><tbody><tr><td id='haa'></td><td id='hab'></td><td id='hac'></td></tr>");
			writer.Write("<tr><td id='had'></td><td id='hacenter'></td><td id='hae'></td></tr>");
			writer.Write("<tr><td id='haf'></td><td id='hag'></td><td id='hah'></td></tr></tbody></table>");
			writer.Write("</div></div>");
		}

		private static void RenderHowToMove(TextWriter writer) {
			writer.Write("<div class='howToMove'>");
			writer.Write("<div><table><tbody><tr><td id='hma'></td><td id='hmb'></td><td id='hmc'></td></tr>");
			writer.Write("<tr><td id='hmd'></td><td id='hmcenter'></td><td id='hme'></td></tr>");
			writer.Write("<tr><td id='hmf'></td><td id='hmg'></td><td id='hmh'></td></tr></tbody></table>");
			writer.Write("</div></div>");
		}

		#endregion Private

		#region Public

		public static void Render(TextWriter writer, InitialContainerManager manager) {
			writer.Write("<div id='leftBattleMenu'>");
			writer.Write("<h3>{0}</h3>",LanguageManager.Instance.Get("UnitProperties"));
			RenderProperties(writer);
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("StrongAgainst"));
			writer.Write("<div class='strongAgainst'><div id='strongAgainst'></div></div>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("WeakerAgainst"));
			writer.Write("<div class='weakerAgainst'><div id='weakerAgainst'></div></div>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("HowToAttack"));
			RenderHowToAttack(writer);
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("HowToMove"));
			RenderHowToMove(writer);
			writer.Write("</div>");
		}

		#endregion Public

		#region Constructor

		#endregion Constructor

	}
}