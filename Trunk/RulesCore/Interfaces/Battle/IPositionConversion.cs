using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IPositionConversion {
		/// <summary>
		/// Converts the passed position into the Base format (Player 1 format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		PositionType ConvertPositionToBase(PositionType position);

		/// <summary>
		/// Converts the passed position into the Player format (Player X format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		PositionType ConvertPositionToSpecific(PositionType position);

		/// <summary>
		/// Converts the passed position into the Player format (Player X format).
		/// </summary>
		/// <param name="position">Position to convert</param>
		/// <returns>Converted position</returns>
		string ConvertPositionToSpecific( string position );

		/// <summary>
		/// Converts the passed coordinate into the Base format (Player 1 format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		IBattleCoordinate ConvertCoordinateToBase(IBattleCoordinate coordinate);

		/// <summary>
		/// Converts the passed coordinate into the Player format (Player X format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		IBattleCoordinate ConvertCoordinateToSpecific(IBattleCoordinate coordinate);

		/// <summary>
		/// Converts the passed coordinate into the Player format (Player X format).
		/// </summary>
		/// <param name="coordinate">Coordinate to convert</param>
		/// <returns>Converted Coordinate</returns>
		string ConvertCoordinateToSpecific( string coordinate );
	}
}