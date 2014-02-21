using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
	public class PrivateSectorRenderer : UniverseBaseRenderer {

		#region Private

		private static void RenderContent(TextWriter writer, SectorInformationContainer container) {
			Coordinate system = container.SystemCoordinates[0];
			int counter = 0;
			writer.Write("<tr>");
			foreach (SectorInformation sector in container.GetSystemInformation(system)) {
				if (counter == 10) {
					writer.Write("</tr><tr>");
					counter = 0;
				}
				RenderImage(writer, sector);
				++counter;
			}
			writer.Write("</tr>");
		}

		#endregion Private

		#region Control Events

		public static void Render(TextWriter writer) {
			SectorInformationContainer container = UniverseUtils.GetPrivateUniverse();
			RenderRightMenu(writer,true,0);
			writer.Write("<div id='privateUniverse'><table id='universeTable' class='universePrivate'><tbody>");
			RenderContent(writer, container);
			writer.Write("</tbody></table></div>");
			RenderBottomMenu(writer);
            writer.Write("<script type='text/javascript'>");
			writer.Write(container.FleetsToJson());
			writer.Write(container.PlanetsToJson());
			writer.Write(container.BattlesToJson());
			writer.Write(container.MarketsToJson());
			writer.Write(container.ArenasToJson());
			writer.Write(container.BeaconsToJson());
			writer.Write(container.PrivateWormholesToJson());
            writer.Write(container.AcademiesToJson());
            writer.Write(container.PirateBaysToJson());
			writer.Write(container.RelicsToJson());
			writer.Write("</script>");
			
			RenderMenu(writer);
		}

		

		#endregion Control Events
			
	}
}
