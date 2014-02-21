using System;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.Engine.Universe {
	public static class CoordinateRangeCalculator {

		#region Fields

		private delegate Coordinate GetStartSystemAndCoordinate(SectorCoordinate coordinate, int yGap, int xGap);
		//private static readonly Dictionary<string, GetStartSystemAndCoordinate> mapping = new Dictionary<string, GetStartSystemAndCoordinate>();

		#endregion Fields

		#region Delegates

		//private static Coordinate Coordinate1_1(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Coordinate37_1(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Coordinate1_37(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Coordinate37_37(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Top(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Bottom(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Left(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		//private static Coordinate Right(SectorCoordinate coordinate, int yGap, int xGap) {
			
		//}

		#endregion Delegates

		#region Coordinate Range Calculation

		private static int CheckXCoordinate(int s) {
			if (s < 1) {
				return 1;
			}
			if (s > Coordinate.MaxXValue) {
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

		#region Decrement

		private static SectorCoordinate DecrementX(Coordinate system,Coordinate sector, int xgap) {
			int s = system.X - (xgap / 7);
			int sx = sector.X - (xgap % 7);
			if (sx < 1) {
				s -= 1;
				sx = s < 1? 1 : 7 + sx;
			} else {
				if (s < 1) {
					sx = 1;
				}
			}

			return new SectorCoordinate(CheckXCoordinate(s), 0, sx, 0);
		}

		private static SectorCoordinate DecrementY(Coordinate system, Coordinate sector, int ygap) {
			int s = system.Y - (ygap / 10);
			int sy = sector.Y - (ygap % 10);
			if (sy < 1) {
				s -= 1;
				sy = s < 1 ? 1 : 10 + sy;
			}else {
				if( s < 1 ) {
					sy = 1;
				}
			}
			return new SectorCoordinate(0, CheckYCoordinate(s), 0, sy);
		}

		private static SectorCoordinate Decrement(Coordinate system, Coordinate sector, int x, int y) {
			SectorCoordinate sx = DecrementX(system, sector, x);
			SectorCoordinate sy = DecrementY(system, sector, y);
			return new SectorCoordinate(sx.System.X, sy.System.Y, sx.Sector.X, sy.Sector.Y);
		}

		#endregion Decrement

		#region Increment

		private static SectorCoordinate IncrementX(Coordinate system, Coordinate sector, int xgap) {
			int s = system.X + (xgap / 7);
			int sx = sector.X + (xgap % 7);
			if (sx > 7) {
				s += 1;
				sx = s > Coordinate.MaxXValue ? 7 : sx-7;
			}
			return new SectorCoordinate(s, 0, sx, 0);
		}

		private static SectorCoordinate IncrementY(Coordinate system, Coordinate sector, int ygap) {
			int s = system.Y + (ygap / 10);
			int sy = sector.Y + (ygap % 10);
			if (sy > 10) {
				s += 1;
				sy = s > Coordinate.MaxYValue ? 7 : sy-10;
			}
			return new SectorCoordinate(0, s, 0, sy);
		}

		private static SectorCoordinate Increment(Coordinate system, Coordinate sector, int x,int y) {
			SectorCoordinate sx = IncrementX(system, sector, x);
			SectorCoordinate sy = IncrementY(system, sector, y);
			return new SectorCoordinate(sx.System.X, sy.System.Y, sx.Sector.X, sy.Sector.Y);
		}

		#endregion Increment

		private static int GetSectorCoordinateFactorX(int factor, int value, int xGap) {
			if (factor < 1) {
				return 7 - Math.Abs(factor);
			}
			return value - xGap;
		}

		private static int GetSectorCoordinateFactorY(int factor, int value, int yGap) {
			if (factor < 1) {
				return 10 - Math.Abs(factor);
			}
			return value - yGap;
		}

		private static Coordinate GetStartSector(Coordinate centerSector, int xFactor, int yFactor, int xGap, int yGap) {
			int x = GetSectorCoordinateFactorX(xFactor, centerSector.X, xGap);
			int y = GetSectorCoordinateFactorY(yFactor, centerSector.Y, yGap);
			return new Coordinate(x, y);
		}

		/// <summary>
		/// Gets the value based on the factor.
		/// </summary>
		/// <param name="factor">factor</param>
		/// <param name="value">the value to change</param>
		/// <returns></returns>
		private static int GetCoordinateFactor(int factor, int value) {
			if (factor >= 1) {
				return value;
			}
			return factor < 1 ? value - 1 : value + 1;
		}

		/// <summary>
		/// Get's the start system to render based on the factor calculated
		/// based on the center sector coordinate
		/// </summary>
		/// <param name="centerSystem">System of the center coordinate</param>
		/// <param name="xFactor">Factor of the x coordinate</param>
		/// <param name="yFactor">Factor of the x coordinate</param>
		/// <returns>The coordinate of the first system to render</returns>
		private static Coordinate GetStartSystemVisibility(Coordinate centerSystem, int xFactor, int yFactor) {
			int x = GetCoordinateFactor(xFactor, centerSystem.X);
			int y = GetCoordinateFactor(yFactor, centerSystem.Y);
			return new Coordinate(x, y);
		}

		private static SectorCoordinate AjustAndDecrementCoordinate(SectorCoordinate original, SectorCoordinate coordinate, int xGap, int yGap) {
			int increment = 1;
			if( xGap > 8) {
				increment = -1;
			}

			bool x = false;
			if (coordinate.System.X >= Coordinate.MaxXValue) {
				coordinate.System.X = Coordinate.MaxXValue;
				coordinate.Sector.X = 7;
				x = true;
			}
			bool y = false;
			if (coordinate.System.Y >= Coordinate.MaxYValue) {
				coordinate.System.Y = Coordinate.MaxYValue;
				coordinate.Sector.Y = 10;
				y = true;
			}
			if( x && y ) {
				return Decrement(coordinate.System, coordinate.Sector, (xGap * 2) + increment, (yGap * 2) + increment);
			}
			if( x ) {
				coordinate.System.Y = original.System.Y;
				coordinate.Sector.Y = original.Sector.Y;
				coordinate = Decrement(coordinate.System, coordinate.Sector, (xGap * 2) + increment, yGap);
			}
			if ( y ) {
				coordinate.System.X = original.System.X;
				coordinate.Sector.X = original.Sector.X;
				coordinate = Decrement(coordinate.System, coordinate.Sector, xGap, (yGap * 2) + increment);
			}
			return coordinate;
		}

		#endregion Coordinate Range Calculation

		#region Public

		/// <summary>
		/// Gets the start system and sector to render the current object
		/// </summary>
		/// <param name="system">System of the current object</param>
		/// <param name="sector">Coordinate of the current object</param>
		/// <returns>Sector Information with the superior left corner coordinates (system and sector)</returns>
		public static SectorCoordinate GetStartSystemAndSector(Coordinate system, Coordinate sector) {
			return GetStartSystemAndSector(system,sector,4,7);
		}

		/// <summary>
		/// Gets the start system and sector to render the current object
		/// </summary>
		/// <param name="system">System of the current object</param>
		/// <param name="sector">Coordinate of the current object</param>
		/// <param name="x"></param>
		/// <param name="y"></param>
		/// <returns>Sector Information with the superior left corner coordinates (system and sector)</returns>
		public static SectorCoordinate GetStartSystemAndSector(Coordinate system, Coordinate sector, int x, int y) {
			SectorCoordinate original = new SectorCoordinate(system, sector);
			if ( system.X >= Coordinate.MaxXValue-1 || system.Y >= Coordinate.MaxYValue-1) {
				SectorCoordinate coordinate = Increment(system, sector, x, y);
				if (coordinate.System.X > Coordinate.MaxXValue || coordinate.System.Y > Coordinate.MaxYValue) {
					return AjustAndDecrementCoordinate(original, coordinate,x,y);
				}
			}

			return Decrement(system, sector, x, y);
		}

		/// <summary>
		/// Gets the start system and sector to render the current object
		/// </summary>
		/// <param name="system">System of the current object</param>
		/// <param name="sector">Coordinate of the current object</param>
		/// <param name="xGap">space between the center an the top</param>
		/// <param name="yGap">space between the center an the left</param>
		/// <returns>Sector Information with the superior left corner coordinates (system and sector)</returns>
		public static SectorCoordinate GetStartSystemAndSectorVisibility(Coordinate system, Coordinate sector, int xGap, int yGap) {
			Coordinate startSystem = system;
			Coordinate startSector = sector;
			int xFactor = startSector.X - xGap;
			int yFactor = startSector.Y - yGap;
			startSystem = GetStartSystemVisibility(startSystem, xFactor, yFactor);
			startSector = GetStartSector(startSector, xFactor, yFactor, xGap, yGap);
			return new SectorCoordinate(startSystem, startSector);
		}

		/// <summary>
		/// Get's the possible coordinates based on a start coordinate
		/// </summary>
		/// <param name="coordinate">The coordinate where to start</param>
		/// <param name="yGap">Number of width elements</param>
		/// <param name="xGap">Number of height elements</param>
		/// <returns>All the coordinates of the possible space</returns>
		public static IEnumerable<SectorCoordinate> GetPossibleCoordinates(SectorCoordinate coordinate, int xGap, int yGap) {
			Coordinate system = new Coordinate(coordinate.System.X, coordinate.System.Y);
			int idx = 0;
			for (int j = 0; j < xGap; ++j) {
				int x = coordinate.Sector.X + idx;
				int y = coordinate.Sector.Y;
				for (int i = 1; i < yGap + 1; ++i) {
					if (y > 10) {
						y = 1;
						system.Y += 1;
					}
					yield return new SectorCoordinate(new Coordinate(system.X, system.Y), new Coordinate(x, y));
					++y;
				}
				++idx;
				if (x == 7) {
					++system.X;
					idx = 0;
					coordinate.Sector.X = 1;
				}
				system.Y = coordinate.System.Y;
			}
		}

		#endregion Public

		#region Constructor

		//static CoordinateRangeCalculator2() {

		//}

		#endregion Constructor
	}
}
