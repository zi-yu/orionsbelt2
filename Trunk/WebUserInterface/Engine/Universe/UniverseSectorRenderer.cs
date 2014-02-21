using System.Collections.Generic;
using System.IO;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Engine {
	public class UniverseSectorRenderer : UniverseBaseRenderer {

		#region Fields

		private delegate void ZoomLevelDelegate(TextWriter writer, SectorCoordinate coordinate);
		private static readonly Dictionary<int, ZoomLevelDelegate> zoomLevel = new Dictionary<int, ZoomLevelDelegate>();

		#endregion Fields

		#region Delegates

		private static void ZoomLevel0(TextWriter writer, SectorCoordinate coordinate) {
			UniverseSectorRendererZoom0.Render(writer, coordinate);
		}

		private static void ZoomLevel1(TextWriter writer, SectorCoordinate coordinate) {
			UniverseSectorRendererZoom1.Render(writer, coordinate);
		}

		private static void ZoomLevel2(TextWriter writer, SectorCoordinate coordinate) {
			UniverseSectorRendererZoom2.Render(writer, coordinate);
		}

		private static void ZoomLevel3(TextWriter writer, SectorCoordinate coordinate) {
			UniverseSectorRendererZoom3.Render(writer, coordinate);
		}

		#endregion Delegates

		#region Private

		#endregion Private

		#region Control Events

		public static void Render( TextWriter writer ) {
			SectorCoordinate coordinate = CenterCoordinate.Current.Center;
			Render(writer, coordinate);
		}


		public static void Render(TextWriter writer, SectorCoordinate coordinate) {
			writer.Write("<div id='universe'>");

			if (coordinate.System.IsPrivateSystem()) {
                SetPrivateZoneTutorial(writer);
				PrivateSectorRenderer.Render(writer);
			} else {
                SetHotZoneTutorial(writer);
				zoomLevel[ZoomLevel.Level](writer, coordinate);
			}

			writer.Write("</div>");
		}

        private static void SetHotZoneTutorial(TextWriter writer)
        {
            TutorialManager.Current = Tutorial.HotZone;
            writer.Write("<script type='text/javascript'>window.overrideTutorial=\"HotZone\";</script>");
        }

        private static void SetPrivateZoneTutorial(TextWriter writer)
        {
            TutorialManager.Current = Tutorial.PrivateZone;
            writer.Write("<script type='text/javascript'>window.overrideTutorial=\"PrivateZone\";</script>");
        }

		public static void AjaxRender(TextWriter writer, SectorCoordinate coordinate) {
			if (coordinate.System.IsPrivateSystem()) {
				PrivateSectorRenderer.Render(writer);
			} else {
				zoomLevel[ZoomLevel.Level](writer, coordinate);
			}
		}

		#endregion Control Events

		#region Constructor

		static UniverseSectorRenderer() {
			zoomLevel[0] = ZoomLevel0;
			zoomLevel[1] = ZoomLevel1;
			zoomLevel[2] = ZoomLevel2;
			zoomLevel[3] = ZoomLevel3;
		}

		#endregion Constructor
			
	}
}
