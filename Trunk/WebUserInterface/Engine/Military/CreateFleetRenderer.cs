using System.IO;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Engine {
	public class CreateFleetRenderer {

		#region Public

		public static void Render(TextWriter writer, IPlanet planet) {
			writer.Write("<div id='createFleet'>");
			writer.Write("{0}: ", LanguageManager.Instance.Get("CreateFleet"));
			writer.Write("<input type='text' id='fleetName' />");
			
			GenericRenderer.WriteRightLinkButton(writer,
				string.Format("javascript:Planet.createFleet({0});",planet.Storage.Id),
				LanguageManager.Instance.Get("Create")
			);
			
			writer.Write("</div>");

		}

		#endregion Public

	}
}
