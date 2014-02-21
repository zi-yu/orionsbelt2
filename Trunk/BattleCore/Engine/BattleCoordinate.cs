using System.Collections;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.BattleCore {
	public class BattleCoordinate : IComparer, IBattleCoordinate {

		#region Fields

		private int x;
		private int y;
		private const int MaxCoordinateValue = 13;

		#endregion Fields

		#region Properties

		public int X {
			get { return x; }
			set { x = value; }
		}

		public int Y {
			get { return y; }
			set { y = value; }
		}

		#endregion Properties

		#region Private

		/// <summary>
		/// Validates a battle coordinate
		/// </summary>
		/// <param name="coord">The battle coordinate</param>
		public void ParseCoordinate( string coord ) {
			if( coord.Length < 3 && coord.Length > 5 ) {
				throw new CoordinateException(coord, "Invalid Coordinate Lenght: {0}", coord);
			}

			string[] coordinate = coord.Split('_');

			if( coordinate.Length != 2 ) {
				throw new CoordinateException(coord, "Invalid Lenght: {0}", coordinate.Length);
			}

			if( !int.TryParse(coordinate[0], out x) ) {
				throw new CoordinateException(coord, "Invalid Coordinate. Error parsing X!" );
			}

			if( !int.TryParse(coordinate[1], out y) ) {
				throw new CoordinateException(coord, "Invalid Coordinate. Error parsing Y!");
			}

			if( x < 0 || x > MaxCoordinateValue || y < 0 || y > MaxCoordinateValue ) {
				throw new CoordinateException(coord, "Invalid Coordinate. X or Y is to high( or low).");
			}
		}


		/// <summary>
		/// Tests the sector to see if the increment of x matches a sector of
		/// the ultimate unit
		/// </summary>
		private static IBattleCoordinate SectorTestX( int x, int y, int numberOfPlayers ) {
			if( x == 9 && numberOfPlayers == 2 ) {
				return new BattleCoordinate(9,9);
			}

			if( x == 13 && numberOfPlayers == 4 ) {
				return new BattleCoordinate(13, 13);
			}

			if( x == 0 ) {
				return new BattleCoordinate(0, 0);
			}
			return new BattleCoordinate(x, y);
		}

		/// <summary>
		/// Tests the sector to seed if the increment of y matches a sectos of
		/// the ultimate unit
		/// </summary>
		private static IBattleCoordinate SectorTestY( int x, int y, int numberOfPlayers ) {
			if( y == 9 && numberOfPlayers == 2 ) {
				return new BattleCoordinate(9, 9);
			}

			if( y == 13 && numberOfPlayers == 4 ) {
				return new BattleCoordinate(13, 13);
			}

			if( y == 0 ) {
				return new BattleCoordinate(0, 0);
			}
			return new BattleCoordinate(x, y);
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Gets the coordinate after the current coordinate
		/// </summary>
		public IBattleCoordinate NextCoordinate( PositionType position, int numberOfPlayers ) {
			switch( position ) {
				case PositionType.N:
					return SectorTestX( X-1, Y, numberOfPlayers );
				case PositionType.S:
					return SectorTestX( X+1, Y, numberOfPlayers );
				case PositionType.W:
					return SectorTestY( X, Y-1, numberOfPlayers );
				default:
					return SectorTestY( X, Y+1, numberOfPlayers );
			}
		}

		/// <summary>
		/// Usado no triple attack para o cálculo do sector esquerdo
		/// </summary>
		public IBattleCoordinate LeftCoordinate( PositionType position, int numberOfPlayers ) {
			switch( position ) {
				case PositionType.N:
					return SectorTestX( X, Y-1, numberOfPlayers );
				case PositionType.S:
					return SectorTestX( X, Y+1, numberOfPlayers );
				case PositionType.W:
					return SectorTestY( X+1, Y, numberOfPlayers );
				default:
					return SectorTestY( X-1, Y, numberOfPlayers );
			}
		}

		/// <summary>
		/// Usado no triple attack para o cálculo do sector directo
		/// </summary>
		public IBattleCoordinate RightCoordinate( PositionType position, int numberOfPlayers ) {
			switch( position ) {
				case PositionType.N:
					return SectorTestX( X, Y+1, numberOfPlayers );
				case PositionType.S:
					return SectorTestX( X, Y-1, numberOfPlayers );
				case PositionType.W:
					return SectorTestY( X-1, Y, numberOfPlayers );
				default:
					return SectorTestY( X+1, Y, numberOfPlayers );
			}
		}

		/// <summary>
		/// Used in the Bom Attack to knwo wich is the coordinate 
		/// </summary>
		public IBattleCoordinate PreviousCoordinate(PositionType position, int numberOfPlayers) {
			switch (position) {
				case PositionType.N:
					return SectorTestX(X+1,Y, numberOfPlayers);
				case PositionType.S:
					return SectorTestX(X-1,Y, numberOfPlayers);
				case PositionType.W:
					return SectorTestY(X,Y+1, numberOfPlayers);
				default:
					return SectorTestY(X,Y-1, numberOfPlayers);
			}
		}

		/// <summary>
		/// Clones the current Coordinate
		/// </summary>
		/// <returns></returns>
		public IBattleCoordinate Clone() {
			return new BattleCoordinate(X, Y);
		}

		#endregion

		#region Constructor

		public BattleCoordinate( string coordinate ) {
			ParseCoordinate(coordinate);
		}

		public BattleCoordinate( int x, int y ) {
			X = x;
			Y = y;
		}

		#endregion Constructor

		#region Object Members

		public override string ToString() {
			return string.Format( "{0}_{1}",X,Y);
		}

		public override bool Equals( object obj ) {
			return ToString().Equals(obj.ToString());
		}

		public override int GetHashCode() {
			return ToString().GetHashCode();
		}

		#endregion Object Members

		#region IComparer Members

		public int Compare( object a, object b) {
			return string.Compare(a.ToString(), b.ToString());
		}

		#endregion

	}
}
