using System.IO;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class PlayerFleetsRenderer : FleetsRendererBase {

		#region Public

		public static void Render(TextWriter writer) {
			writer.Write("<div id='fleetList'>");
			
			foreach (IFleetInfo fleet in PlayerUtils.Current.Fleets ) {
				FleetRenderer.Render(writer,fleet);
			}
			if (PlayerUtils.Current.Fleets.Count > 0 ) {
				RenderMenu(writer);
				writer.Write("<div id='saveChangesDiv'>");
				//GenericRenderer.WriteInputButton(writer, "saveChanges", LanguageManager.Instance.Get("Save"), "Fleet.saveChangesPlayer();");
				GenericRenderer.WriteInputButton(writer, "saveChanges", LanguageManager.Instance.Get("Save"));
				writer.Write("</div>");
				RenderFleetsJson(writer, PlayerUtils.Current.Fleets, false);
			}
			writer.Write("</div>");
		}

		#endregion Public
	}
}
