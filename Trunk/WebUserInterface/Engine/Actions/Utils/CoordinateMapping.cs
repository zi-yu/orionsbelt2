using System;
using System.Collections.Generic;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Engine {
	public class CoordinateMapping {

		#region Fields

		private delegate SectorCoordinate CoordinateChooser(SectorCoordinate current, int moveFactor);
		private static readonly Dictionary<string, CoordinateChooser> mapping = new Dictionary<string, CoordinateChooser>();
		private static readonly int movementFactor = 4;

		#endregion Fields

		#region Private

		private static int CheckXCoordinate(int s) {
			if( s < 1 ) {
				return 1;
			}
			if( s > Coordinate.MaxXValue ) {
				return Coordinate.MaxXValue;
			}
			return s;
		}

		private static int CheckYCoordinate(int s) {
			if (s < 1) {
				return 1;
			}
			if (s > Coordinate.MaxYValue) {
				return Coordinate.MaxYValue;
			}
			return s;
		}

		#endregion

		#region Delegates

		private static SectorCoordinate ParseACoordinate(SectorCoordinate current, int moveFactor) {
			SectorCoordinate b = ParseBCoordinate(current, moveFactor);
			SectorCoordinate d = ParseDCoordinate(current, moveFactor);
			return new SectorCoordinate(b.System.X,d.System.Y,b.Sector.X,d.Sector.Y);
		}

		private static SectorCoordinate ParseBCoordinate(SectorCoordinate current, int moveFactor) {
			int s = current.System.X - (moveFactor / 7);
			int sx = current.Sector.X - (moveFactor % 7);
			if (sx < 0) {
				s -= 1;
				sx = 7 + sx;
			}
			return new SectorCoordinate(CheckXCoordinate(s), current.System.Y, sx, current.Sector.Y);
		}

		private static SectorCoordinate ParseCCoordinate(SectorCoordinate current, int moveFactor) {
			SectorCoordinate b = ParseBCoordinate(current, moveFactor);
			SectorCoordinate e = ParseECoordinate(current, moveFactor);
			return new SectorCoordinate(b.System.X, e.System.Y, b.Sector.X, e.Sector.Y);
		}

		private static SectorCoordinate ParseDCoordinate(SectorCoordinate current, int moveFactor) {
			int s = current.System.Y - (moveFactor / 10);
			int sy = current.Sector.Y - (moveFactor % 10);
			if( sy  < 0 ) {
				s -= 1;
				sy = 10 + sy;
			}

			return new SectorCoordinate(current.System.X, CheckYCoordinate(s), current.Sector.X, sy);
		}

		private static SectorCoordinate ParseECoordinate(SectorCoordinate current, int moveFactor) {
			int s = current.System.Y + (moveFactor / 10);
			int sy = current.Sector.Y + (moveFactor % 10);
			if (sy > 10) {
				s += 1;
				sy-= 10;
			}
			return new SectorCoordinate(current.System.X, CheckYCoordinate(s), current.Sector.X, sy);
		}

		private static SectorCoordinate ParseFCoordinate(SectorCoordinate current, int moveFactor) {
			SectorCoordinate g = ParseGCoordinate(current, moveFactor);
			SectorCoordinate d = ParseDCoordinate(current, moveFactor);
			return new SectorCoordinate(g.System.X, d.System.Y, g.Sector.X, d.Sector.Y);
		}

		private static SectorCoordinate ParseGCoordinate(SectorCoordinate current, int moveFactor) {
			int s = current.System.X + (moveFactor / 7);
			int sx = current.Sector.X + (moveFactor % 7);
			if (sx > 7) {
				s += 1;
				sx-= 7;
			}
			return new SectorCoordinate(CheckXCoordinate(s), current.System.Y, sx, current.Sector.Y);
		}

		private static SectorCoordinate ParseHCoordinate(SectorCoordinate current, int moveFactor) {
			SectorCoordinate g = ParseGCoordinate(current, moveFactor);
			SectorCoordinate e = ParseECoordinate(current, moveFactor);
			return new SectorCoordinate(g.System.X, e.System.Y, g.Sector.X, e.Sector.Y);
		}

		#endregion Delegates

		#region Public

		public static SectorCoordinate GetCoordinate(string coordinateCode, SectorCoordinate coordinate) {
			int factor = (4 - ZoomLevel.Level) * movementFactor;
			return mapping[coordinateCode](coordinate,factor);
		}

		public static SectorCoordinate GetCenterCoordinateFromStartCoordinate(SectorCoordinate coordinate, int xGap, int yGap) {
			SectorCoordinate g = ParseGCoordinate(coordinate, xGap);
			SectorCoordinate e = ParseECoordinate(coordinate, yGap);
			return new SectorCoordinate(g.System.X, e.System.Y, g.Sector.X, e.Sector.Y);
		}

		#endregion Public

		#region Constructor

		static CoordinateMapping() {
			mapping["a"] = ParseACoordinate;
			mapping["b"] = ParseBCoordinate;
			mapping["c"] = ParseCCoordinate;
			mapping["d"] = ParseDCoordinate;
			mapping["e"] = ParseECoordinate;
			mapping["f"] = ParseFCoordinate;
			mapping["g"] = ParseGCoordinate;
			mapping["h"] = ParseHCoordinate;
		}

		#endregion Constructor
	}
}
