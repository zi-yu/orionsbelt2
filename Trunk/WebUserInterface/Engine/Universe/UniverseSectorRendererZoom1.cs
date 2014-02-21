using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
		public class UniverseSectorRendererZoom1 : UniverseBaseRenderer {

		#region Control Events

		public static void Render(TextWriter writer, SectorCoordinate center ) {
            SectorInformationContainer container = UniverseUtils.GetUniverseWithSectorInformation(center, 36, 60);
			SetCenterCoordinate(container.StartCoordinate, 18, 30);
            RenderRightMenu(writer,1);
			writer.Write("<table id='universeTable{0}' class='universe1'><tbody>", container.Level);
            RenderContent(writer, container, 60);
            writer.Write("</tbody></table>");
            RenderBottomMenu(writer);
            RenderUniverseElementsJson(writer, container);
			RenderMenu(writer);
		}

		#endregion Control Events
			
	}
}
