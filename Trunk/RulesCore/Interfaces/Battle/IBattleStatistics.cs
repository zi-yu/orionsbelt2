using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.RulesCore.Interfaces {
	public interface IBattleStatistics {
		
		/// <summary>
		/// Other players except the owner have Heavy units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Heavy Units</returns>
		bool HeavyExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Medium units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Medium Units</returns>
		bool MediumExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Light units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Light Units</returns>
		bool LightExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have  Air units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have  Air Units</returns>
		bool AirExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Ground units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Ground Units</returns>
		bool GroundExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Water units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Water Units</returns>
		bool WaterExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Organic units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Organic Units</returns>
		bool OrganicExists( IBattlePlayer owner );

		/// <summary>
		/// Other players except the owner have Heavy units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Heavy Units</returns>
		bool MechanicExists( IBattlePlayer owner );

		/// <summary>
		/// Number of Heavy units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Heavy units</returns>
		int HeavyPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Medium units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Medium units</returns>
		int MediumPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Light units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Light units</returns>
		int LightPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Air units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Air units</returns>
		int AirPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of  Ground units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of  Ground units</returns>
		int GroundPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Heavy units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Heavy units</returns>
		int WaterPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Organic units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Organic units</returns>
		int OrganicPercentage( IBattlePlayer owner );

		/// <summary>
		/// Number of Mechanical units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Mechanical units</returns>
		int MechanicalPercentage( IBattlePlayer owner );

		/// <summary>
		/// Add new unit
		/// </summary>
		void Add( IBattlePlayer owner, IElement element );

		/// <summary>
		/// Add a Player
		/// </summary>
		void AddPlayer( IBattlePlayer player );

		/// <summary>
		/// Get the increment 
		/// </summary>
		int GetIncrement( IBattlePlayer owner, int Count );

		/// <summary>
		/// Updates the statistc of the current battle
		/// </summary>
		/// <param name="attacker">Player that is attacking</param>
		/// <param name="attacked">Player that is attacked</param>
		/// <param name="unit">Unit destroyed</param>
		/// <param name="quantity">Quantity Destroyed</param>
		void UpdateStatistics( IBattlePlayer attacker, IBattlePlayer attacked, IUnitInfo unit, int quantity );

		/// <summary>
		/// Gets the number of the destroyed units the the player
		/// </summary>
		/// <param name="current">Player to get the statistic from</param>
		/// <returns>Dictionary with all the units and the destroyed quantities</returns>
		Dictionary<IUnitInfo, int> GetDestroyedUnits(IBattlePlayer current);

		/// <summary>
		/// Parse statistics
		/// </summary>
		void Parse( string unitsDestroyed );

		/// <summary>
		/// Gets the number of the destroyed units the the player
		/// </summary>
		/// <param name="current">Player to get the statistic from</param>
		/// <returns>Dictionary with all the units and the destroyed quantities</returns>
		Dictionary<IUnitInfo, int> GetDestroyedUnitsByOthers( IBattlePlayer current );
	}
}