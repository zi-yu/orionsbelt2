using System.IO;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
	public class UniverseSectorRendererZoom3 : UniverseBaseRenderer {

		#region Control Events

		public static void Render(TextWriter writer, SectorCoordinate center ) {
			SectorInformationContainer container = UniverseUtils.GetUniverseWithSectorInformation(center);
			SetCenterCoordinate(container.StartCoordinate, 4, 7);
            RenderRightMenu(writer,3);
			writer.Write("<table id='universeTable{0}' class='universe3'><tbody>", container.Level);
            RenderContent(writer, container, 15);
            writer.Write("</tbody></table>");
		    RenderBottomMenu(writer);
            RenderUniverseElementsJson(writer, container);
			RenderMenu(writer);
		}

		#endregion Control Events
			
	}
}
