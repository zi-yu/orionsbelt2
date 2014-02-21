using System;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.RulesCore.Common {
	public class CoordinateDistance {

		#region Fields

		private readonly Coordinate currentSystem;
		private readonly Coordinate currentSector;
		private readonly Coordinate destinySystem;
		private readonly Coordinate destiny;
		private double hammingSystemDistance;
		private double hammingSectorDistance;
		private int hammingBonus = 0;
		private static readonly Dictionary<char, ClosestCoordinate> closestCoordinate = new Dictionary<char, ClosestCoordinate>();
		delegate Coordinate ClosestCoordinate( Coordinate c, CoordinateDistance current );

		#endregion Fields

		#region Properties

		public double HammingSystemDistance {
			get { return hammingSystemDistance; }
		}

		public double HammingSectorDistance {
			get { return hammingSectorDistance; }
		}

		public Coordinate CurrentSector {
			get { return currentSector; }
		}

		public Coordinate CurrentSystem {
			get { return currentSystem; }
		}

		#endregion Properties

		#region Private

		/// <summary>
		///   a  |   b   |  c   
		/// --------------------
		///   d  |current|  e   
		/// --------------------
		///   f  |   g   |  h   
		/// </summary>
		/// <param name="c">closest system to the target</param>
		/// <returns></returns>
		private char GetSectorKeyword( Coordinate c ) {
			if( CurrentSystem.X - 1 == c.X ) {
				if( CurrentSystem.Y - 1 == c.Y ) {
					return 'a';
				}
				if( CurrentSystem.Y == c.Y ) {
					return 'b';
				}
				return 'c';
			}
			if( CurrentSystem.X + 1 == c.X ) {
				if( CurrentSystem.Y - 1 == c.Y ) {
					return 'f';
				}
				if( CurrentSystem.Y == c.Y ) {
					return 'g';
				}
				return 'h';
			}

			if( CurrentSystem.Y - 1 == c.Y ) {
				return 'd';
			}
			return 'e';
		}

		private static Coordinate SectorAClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			return new Coordinate(1, 1);
		}

		private static Coordinate SectorBClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			current.hammingBonus = Math.Abs(c.Y - current.destiny.Y);
			return new Coordinate(1, c.Y);
		}

		private static Coordinate SectorCClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			return new Coordinate(1, 10);
		}

		private static Coordinate SectorDClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			current.hammingBonus = Math.Abs(c.X - current.destiny.X);
			return new Coordinate(c.X, 1);
		}

		private static Coordinate SectorEClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			current.hammingBonus = Math.Abs(c.X - current.destiny.X);
			return new Coordinate(c.X, 10);
		}

		private static Coordinate SectorFClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			return new Coordinate(7, 1);
		}

		private static Coordinate SectorGClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			current.hammingBonus = Math.Abs(c.Y - current.destiny.Y);
			return new Coordinate(7, c.Y);
		}

		private static Coordinate SectorHClosestCoordinate( Coordinate c, CoordinateDistance current ) {
			return new Coordinate(7, 10);
		}

		/// <summary>
		/// Caclculates the surrond system that is closer to the destiny
		/// </summary>
		/// <returns>The next system the is closer to the destiny</returns>
		private Coordinate GetNextSystem() {
			List<Coordinate> coordinate = new List<Coordinate>();
			coordinate.Add(new Coordinate(CurrentSystem.X - 1, CurrentSystem.Y - 1));
			coordinate.Add(new Coordinate(CurrentSystem.X - 1, CurrentSystem.Y));
			coordinate.Add(new Coordinate(CurrentSystem.X - 1, CurrentSystem.Y + 1));
			coordinate.Add(new Coordinate(CurrentSystem.X, CurrentSystem.Y - 1));
			coordinate.Add(new Coordinate(CurrentSystem.X, CurrentSystem.Y + 1));
			coordinate.Add(new Coordinate(CurrentSystem.X + 1, CurrentSystem.Y - 1));
			coordinate.Add(new Coordinate(CurrentSystem.X + 1, CurrentSystem.Y));
			coordinate.Add(new Coordinate(CurrentSystem.X + 1, CurrentSystem.Y + 1));

			coordinate.Sort(delegate(Coordinate c1, Coordinate c2) {
					double c1H = c1.Hamming(destinySystem);
					double c2H = c2.Hamming(destinySystem);
					return c1H.CompareTo(c2H);
				}
			);

			return coordinate[0];
		}

		private Coordinate GetHammingCoordinate( Coordinate nextSystem ) {
			char keyword = GetSectorKeyword(nextSystem);
			return closestCoordinate[keyword](CurrentSector,this);
		}

		/// <summary>
		/// Calculate the hamming distance between the two sets of coordinates
		/// </summary>
		private void CalculateHammingDistance() {
			hammingSystemDistance = CurrentSystem.Hamming(destinySystem)*10;

			if (CurrentSystem == destinySystem ) {
				hammingSectorDistance = currentSector.Hamming(destiny);
			}else {
				Coordinate nextSystem = GetNextSystem();
				//hammingCoordinate is the most closest coordinate in
				//the current system from the destiny coordinate
				Coordinate hammingCoordinate = GetHammingCoordinate(nextSystem);
				hammingSectorDistance = currentSector.Hamming(hammingCoordinate) + hammingBonus;
			}
		}

		#endregion Private

		#region Constructor

		static CoordinateDistance() {
			closestCoordinate['a'] = SectorAClosestCoordinate;
			closestCoordinate['b'] = SectorBClosestCoordinate;
			closestCoordinate['c'] = SectorCClosestCoordinate;
			closestCoordinate['d'] = SectorDClosestCoordinate;
			closestCoordinate['e'] = SectorEClosestCoordinate;
			closestCoordinate['f'] = SectorFClosestCoordinate;
			closestCoordinate['g'] = SectorGClosestCoordinate;
			closestCoordinate['h'] = SectorHClosestCoordinate;
		}

		public CoordinateDistance(SectorCoordinate current, SectorCoordinate destiny) {
			currentSystem = current.System;
			currentSector = current.Sector;
			destinySystem = destiny.System;
			this.destiny = destiny.Sector;
			CalculateHammingDistance();
		}

		public CoordinateDistance( Coordinate currentSystem, Coordinate currentSector, Coordinate destinySystem, Coordinate destinySector ) {
			this.currentSystem = currentSystem;
			this.currentSector = currentSector;
			this.destinySystem = destinySystem;
			destiny = destinySector;
			CalculateHammingDistance();
		}

		#endregion Constructor
	}
}
