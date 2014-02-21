using System;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public abstract class PositionConversionBase : IPositionConversion {

		#region Fields

		private readonly int numberOfPlayers;
		private static readonly BattleCoordinate coordinate0 = new BattleCoordinate(0,0);
		private static readonly BattleCoordinate coordinate01 = new BattleCoordinate(0, 1);
		private static readonly BattleCoordinate coordinate9 = new BattleCoordinate(9,9);
		private static readonly BattleCoordinate coordinate91 = new BattleCoordinate(9, 1);

		#endregion Fields

		#region Properties

		protected BattleCoordinate ResolveUltimateCoordinate(IBattleCoordinate coordinate) {
			if( numberOfPlayers == 2 ) {
				if( coordinate.Equals(coordinate0) ) {
					return coordinate9;
				}
				if (coordinate.Equals(coordinate9)) {
					return coordinate0;
				}
				if (coordinate.Equals(coordinate01)) {
					return coordinate91;
				}
				if (coordinate.Equals(coordinate91)) {
					return coordinate01;
				}
			}
			return null;
		}

		#endregion

		#region Abstract Methods

		/// <summary>
		/// Converts the passed position into the Base format (Player 1 format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		public virtual PositionType ConvertPositionToBase( PositionType position ) {
			return position;
		}

		/// <summary>
		/// Converts the passed position into the Player format (Player X format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		public virtual PositionType ConvertPositionToSpecific( PositionType position ) {
			return position;
		}

		/// <summary>
		/// Converts the passed position into the Player format (Player X format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		public virtual string ConvertPositionToSpecific( string position ) {
			PositionType p = (PositionType) Enum.Parse(typeof(PositionType), position);
			return ConvertPositionToSpecific(p).ToString();
		}

		/// <summary>
		/// Converts the passed coordinate into the Base format (Player 1 format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		public virtual IBattleCoordinate ConvertCoordinateToBase( IBattleCoordinate coordinate ) {
			return coordinate;
		}

		/// <summary>
		/// Converts the passed coordinate into the Player format (Player X format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		public virtual IBattleCoordinate ConvertCoordinateToSpecific( IBattleCoordinate coordinate ) {
			return coordinate;
		}

		/// <summary>
		/// Converts the passed coordinate into the Player format (Player X format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		public virtual string ConvertCoordinateToSpecific( string coordinate ) {
			return ConvertCoordinateToSpecific(new BattleCoordinate(coordinate)).ToString();
		}

		#endregion Abstract Methods

		#region Public

		protected int MaxCoordinateValue {
			get{
				if( numberOfPlayers == 2) {
					return 9;
				}
				return 13;
			}
		}

		#endregion Public

		#region Constructor

		public PositionConversionBase( int numberOfPlayers ) {
			this.numberOfPlayers = numberOfPlayers;
		}

		#endregion Constructor
	}
}
