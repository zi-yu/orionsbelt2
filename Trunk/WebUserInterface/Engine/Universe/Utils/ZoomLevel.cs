
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {
	public static class ZoomLevel {

		private static readonly string zoomLevel = "ZoomLevel";

		public static int Level {
			get {
				if (State.HasSession(zoomLevel)) {
					return State.GetSessionInt(zoomLevel);	
				}
				State.SetSession(zoomLevel, 0);
				return 0;
			}
			set {
				State.SetSession(zoomLevel, value);
			}
		}

		public static int MaximumLevel {
			get { return 3; }
		}

		public static int MinimumLevel {
			get { return 0; }
		}

	}
}
