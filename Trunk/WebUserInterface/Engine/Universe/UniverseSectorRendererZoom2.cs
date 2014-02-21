using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
	public class UniverseSectorRendererZoom2 : UniverseBaseRenderer {

		#region Control Events

		public static void Render(TextWriter writer, SectorCoordinate center ) {
			SectorInformationContainer container = UniverseUtils.GetUniverseWithSectorInformation(center, 18, 30);
			SetCenterCoordinate(container.StartCoordinate, 9, 15);
			RenderRightMenu(writer,2);
			writer.Write("<table id='universeTable{0}' class='universe2'><tbody>", container.Level);
            RenderContent(writer, container, 30);
            writer.Write("</tbody></table>");
            RenderBottomMenu(writer);
            RenderUniverseElementsJson(writer, container);
			RenderMenu(writer);
		}

		#endregion Control Events
			
	}
}
