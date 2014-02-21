using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IPlayerStatistics {

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasHeavy { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasMedium { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasLight { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasAirUnits { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasGroundUnits { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasWaterUnits { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasOrganic { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		bool HasMechanic { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int HeavyCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int MediumCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int LightCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int AirUnitsCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int GroundUnitsCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int WaterUnitsCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int OrganicCount { get; }

		/// <summary>
		/// Has Units
		/// </summary>
		int MechanicCount { get; }

		/// <summary>
		/// Total Units
		/// </summary>
		int TotalUnits { get; }

		/// <summary>
		/// Units destroyed by the player
		/// </summary>
		Dictionary<IUnitInfo, int> UnitsDestroyed { get; }

		/// <summary>
		/// Units destroyed by other players
		/// </summary>
		Dictionary<IUnitInfo, int> UnitsDestroyedByOthers { get; }

		/// <summary>
		/// Adds a new unit
		/// </summary>
		void Add(IElement element);

		/// <summary>
		/// Adds a new unit to the destroyed unit statistics
		/// </summary>
		void AddDestroyedUnit( IUnitInfo unit, int quantity );

		/// <summary>
		/// Removes a unit from the statistics
		/// </summary>
		void RemoveUnit( IUnitInfo unit, int quantity );


		/// <summary>
		/// Adds a unit of the player that has been destroyed
		/// </summary>
		void AddDestroyedUnitByOtherPlayer( IUnitInfo unit, int quantity );
		
		/// <summary>
		/// Parses a string that contains statistics about the units destroyed by a player
		/// </summary>
		/// <param name="stats">statistics to parse</param>
		void Parse( string stats );
	}
}