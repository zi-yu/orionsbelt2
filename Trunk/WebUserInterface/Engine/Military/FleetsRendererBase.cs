using System.Collections.Generic;
using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {
	public class FleetsRendererBase {

		#region Private

		private static void ToJson(TextWriter writer, IFleetInfo fleet, List<IFleetInfo> fleets, bool first) {
			if (!first) {
				writer.Write(",");
			}
			writer.Write("'{0}':{{ p:", fleet.Id);
			WriteFleetsThatCanDrop(writer, fleet, fleets);
			writer.Write("}");
		}

		private static void WriteFleetsThatCanDrop(TextWriter writer, IFleetInfo fleet, List<IFleetInfo> fleets) {
			writer.Write("[");
			bool first = true;
			List<SectorCoordinate> surroundingCoordinates = SectorUtils.GetPossibleCoordinates(fleet.Location);
			foreach (SectorCoordinate coordinate in surroundingCoordinates) {
				IFleetInfo possibleFleet = fleets.Find(delegate(IFleetInfo f) { return f.Location.Equals(coordinate); });
				if (possibleFleet != null) {
					if (!first) {
						writer.Write(",");
					}
					writer.Write(possibleFleet.Id);
					first = false;
				}
			}
			writer.Write("]");
		}

		#endregion Private

		#region Protected

		protected static void RenderFleetsJson(TextWriter writer, List<IFleetInfo> fleets, bool dummyMode) {
            writer.Write("<script type='text/javascript'>var Fleets");
			if(dummyMode) {
				writer.Write(";");
			}else {
				writer.Write("={");
				bool first = true;
				foreach (IFleetInfo info in fleets) {
					ToJson(writer, info, fleets,first);
					first = false;
				}
				writer.Write("};");
			}

			writer.Write("</script>");
		}

		protected static void RenderMenu(TextWriter writer) {
			writer.Write("<div id='quantitySelector' class='optionMenu hidden'>");
			writer.Write("<div class='optionMenuTitle'>{0}</div>", LanguageManager.Instance.Get("InsertQuantity"));
			writer.Write("<div class='optionMenuText'><input type='text' id='quantity' />");
            writer.Write("<img id='transferQuantity' src='{0}' />", ResourcesManager.GetImage("Information.gif"));
            writer.Write("<img id='cancelTransfer' src='{0}' />", ResourcesManager.GetImage("Error.gif"));
			writer.Write("</div></div>");

			writer.Write("<div id='quantityCargoSelector' class='optionMenu hidden'>");
			writer.Write("<div class='optionMenuTitle'>{0}</div>", LanguageManager.Instance.Get("InsertQuantity"));
			writer.Write("<div class='optionMenuText'><input type='text' id='quantityCargo' />");
            writer.Write("<img id='transferCargoQuantity' src='{0}' />", ResourcesManager.GetImage("Information.gif"));
			writer.Write("<img id='cancelCargoTransfer' src='{0}' />", ResourcesManager.GetImage("Error.gif"));
			writer.Write("</div></div>");
		}

		#endregion Protected
	}
}
