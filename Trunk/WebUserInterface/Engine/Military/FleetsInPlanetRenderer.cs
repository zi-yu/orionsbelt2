using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class FleetsInPlanetRenderer : FleetsRendererBase {

		#region Public

		public static void Render(TextWriter writer, IPlanet planet) {
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("DefenseFleet"));
			writer.Write("<div class='panelPlaceHolder'>");
			FleetRenderer.RenderInPlanet(writer, planet, planet.DefenseFleet);
			writer.Write("</div>");

			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("FleetInPlanet"));
			writer.Write("<div class='panelPlaceHolder'>");

			foreach (IFleetInfo fleet in planet.Fleets) {
				if ( fleet.Movable ) {
					FleetRenderer.RenderInPlanet(writer, planet, fleet);
				}
			}

			writer.Write("</div>");
			RenderMenu(writer);

			writer.Write("<div id='saveChangesDiv'>");
			//GenericRenderer.WriteInputButton(writer, "saveChanges", LanguageManager.Instance.Get("Save"), "Fleet.saveChangesPlanet();");
			GenericRenderer.WriteInputButton(writer, "saveChanges", LanguageManager.Instance.Get("Save"));

			writer.Write("</div>");

			RenderFleetsJson(writer, planet.Fleets, true);
		}

		#endregion Public
	}
}
