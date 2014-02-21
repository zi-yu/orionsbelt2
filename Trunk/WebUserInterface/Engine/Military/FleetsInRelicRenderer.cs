using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class FleetsInRelicRenderer : FleetsRendererBase {

		#region Public

		public static void Render(TextWriter writer, IFleetInfo relicFleet, List<IFleetInfo> fleets) {
			writer.Write("<div id='fleetList'>");
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("DefenseFleet"));
			writer.Write("<div class='panelPlaceHolder'>");
			FleetRenderer.Render(writer, relicFleet);
			writer.Write("</div>");

			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("FleetNearRelic"));
			writer.Write("<div class='panelPlaceHolder'>");

			foreach (IFleetInfo fleet in fleets) {
				if ( fleet.Movable ) {
					FleetRenderer.Render(writer, fleet);
				}
			}

			writer.Write("</div>");
			RenderMenu(writer);

			writer.Write("<div id='saveChangesDiv'>");
			GenericRenderer.WriteInputButton(writer, "saveChanges", LanguageManager.Instance.Get("Save"));

			writer.Write("</div>");
			RenderFleetsJson(writer, fleets, true);
			writer.Write("</div>");
		}

		#endregion Public
	}
}
