using System;
using System.Collections.Generic;

namespace OrionsBelt.RulesCore.Common {
    
    /// <summary>
    /// Represents a location in the universe
    /// </summary>
    public class Coordinate : IComparable<Coordinate>, IComparer<Coordinate> {

		#region Fields

		private static readonly Coordinate dummy = new Coordinate(-1, -1);
		private static readonly Coordinate privateSectorCoordinate = new Coordinate(0, 0);
		private static readonly char[] separator = new char[] { '_' };
    	private int x;
    	private int y;
		private static readonly Random coordinateRandom = new Random((int)DateTime.Now.Ticks);

		#endregion Fields

        #region Public Static ELements

        public static readonly Coordinate MinCoordinate = new Coordinate(1, 1);
        public static readonly Coordinate MaxCoordinate = new Coordinate(7, 10);
        public static readonly int MaxXValue = 37;
        public static readonly int MaxYValue = 37;

        #endregion Elements

		#region Properties

		public int X {
			get { return x; }
			set { x = value; }
		}

		public int Y {
			get { return y; }
			set { y = value; }
		}

    	public static Coordinate PrivateSectorCoordinate {
    		get { return privateSectorCoordinate; }
    	}

    	public static Coordinate Dummy {
    		get { return dummy; }
    	}

    	#endregion Properties

		#region Public

		/// <summary>
		/// verifies if the coordinate is inside the passed limits
		/// </summary>
		/// <param name="start">Start Coordinate</param>
		/// <param name="end">EndCoordinate</param>
		public bool IsInLimits( Coordinate start , Coordinate end) {
			return X >= start.X && Y >= start.Y && X <= end.X && Y <= end.Y;
		}

		public override string ToString() {
			return string.Format("{0}_{1}",X,Y);
		}

		public override bool Equals(object obj) {
			if (obj != null && obj is Coordinate) {
				Coordinate c = obj as Coordinate;
				return this == c;
			}
			return false;
		}

		public override int GetHashCode() {
			return X*100 + Y;
		}

		/// <summary>
		/// Hamming distance between this coordinate and the passed coordinate
		/// </summary>
		/// <param name="coordinate">Coordinate to calculate the hamming distance</param>
		/// <returns>an integer with the hamming distance</returns>
		public double Hamming( Coordinate coordinate) {
			return Math.Sqrt( Math.Pow(Math.Abs(X - coordinate.X),2) + Math.Pow(Math.Abs(Y - coordinate.Y),2) );
		}

		/// <summary>
		/// Calculates a random coordinate between 
		/// </summary>
		/// <param name="topX">Top X Coordinate</param>
		/// <param name="topY">Top Y Coordinate</param>
		/// <param name="bottomX">Bottom X Coordinate</param>
		/// <param name="bottomY">Bottom Y Coordinate</param>
		/// <returns>The coordinate</returns>
		public static Coordinate GenerateRandomCoordinate(int topX, int topY, int bottomX, int bottomY ) {
			int newX = coordinateRandom.Next(topX, bottomX + 1);
			int newY = coordinateRandom.Next(topY, bottomY + 1);
			return new Coordinate(newX, newY);
		}

        public bool IsValid(){
            if ( X < 1 || X > MaxXValue || Y < 1 || Y > MaxYValue ){
                return false;
            }
            return true;
        }

		public bool IsValidSector() {
			if (X < 1 || X > 7 || Y < 1 || Y > 10) {
				return false;
			}
			return true;
		}

		/// <summary>
		/// Verifies if the passed coordinate is a private system
		/// </summary>
		/// <returns>True if the coordinate is from a private system</returns>
		public bool IsPrivateSystem() {
			return X == 0 && Y == 0;
		}

		#endregion Public

		#region IComparable<Coordinate> Members

		public int CompareTo(Coordinate other) {
			if (X == other.X && Y == other.Y) {
				return 0;
			}

			if (X < other.X) {
				return -1;
			}

			int hthis = X*100 + Y;
			int hOther = other.X*100 + other.Y;

			return hthis < hOther ? -1 : 1;
		}

		#endregion IComparable<Coordinate> Members

		#region IComparer<Coordinate> Members

		public int Compare(Coordinate c1, Coordinate c2) {
			return c1.CompareTo(c2);
		}

		#endregion IComparer<Coordinate> Members

		#region Operator Overloading

		public static bool operator <(Coordinate c1, Coordinate c2) {
			return c1.CompareTo(c2) == -1;
		}

		public static bool operator >(Coordinate c1, Coordinate c2) {
			return c1.CompareTo(c2) == 1;
		}

		public static bool operator <=(Coordinate c1, Coordinate c2) {
			return !(c1 > c2);
		}

		public static bool operator >=(Coordinate c1, Coordinate c2) {
			return !(c1 < c2);
		}

		public static bool operator ==(Coordinate c1, Coordinate c2) {
			if (Equals(c1, null) && Equals(c2, null)) {
				return true;
			}
			if (Equals(c1, null) || Equals(c2, null)) {
				return false;
			}

			return c1.CompareTo(c2) == 0; 
		}

		public static bool operator !=(Coordinate c1, Coordinate c2) {
			return !(c1 == c2);
		}

		#endregion Operator Overloading

		#region Constructor

		public Coordinate( int x, int y) {
			X = x;
			Y = y;
		}

		public Coordinate(string coord) {
			string[] coords = coord.Split(separator, StringSplitOptions.RemoveEmptyEntries);
			if (coords.Length != 2 || !int.TryParse(coords[0], out x) || !int.TryParse(coords[1], out y)) {
				throw new RulesException("Invalid coordinate '{0}'",coord);
			}
		}

		#endregion Constructor

	};
}
