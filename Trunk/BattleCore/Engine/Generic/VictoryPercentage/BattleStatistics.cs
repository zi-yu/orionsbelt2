using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class BattleStatistics : IBattleStatistics {

		#region Fields

		private readonly Dictionary<IBattlePlayer, IPlayerStatistics> statistics = new Dictionary<IBattlePlayer, IPlayerStatistics>();
		private static readonly ModifierContainer modifierContainer = new ModifierContainer();

		#endregion Fields

		#region Private

		/// <summary>
		/// Get's the total of all players except the passed by parameter
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Total number of units of all players except the passed by parameter</returns>
		public int GetPartialTotal( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber || battlePlayer.TeamNumber == owner.TeamNumber ) {
					continue;
				}
				total += statistics[battlePlayer].TotalUnits;
			}
			return total;
		}

		private int GetPercentage( IBattlePlayer owner, int total ) {
			int totalUnits = GetPartialTotal(owner);
			if( totalUnits == 0 ) {
				return 0;
			}

			return total / totalUnits;
		}

		private IPlayerStatistics GetPlayerStatistics( int playerNumber ) {
			foreach (IBattlePlayer player in statistics.Keys) {
				if( player.PlayerNumber == playerNumber ) {
					return statistics[player];
				}
			}
			return null;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Other players except the owner have Heavy units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Heavy Units</returns>
		public bool HeavyExists( IBattlePlayer owner ) {
			return HeavyPercentage(owner) != 0;
		}

		/// <summary>
		/// Other players except the owner have Medium units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Medium Units</returns>
		public bool MediumExists( IBattlePlayer owner ) {
			return MediumPercentage(owner) != 0;
		}

		/// <summary>
		/// Other players except the owner have Light units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Light Units</returns>
		public bool LightExists( IBattlePlayer owner ) {
			return LightPercentage( owner ) != 0;
		}

		/// <summary>
		/// Other players except the owner have  Air units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have  Air Units</returns>
		public bool AirExists( IBattlePlayer owner ) {
			return AirPercentage( owner ) != 0;
		}

		/// <summary>
		/// Other players except the owner have Ground units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Ground Units</returns>
		public bool GroundExists( IBattlePlayer owner ) {
			return GroundPercentage( owner ) != 0;
		}

		/// <summary>
		/// Other players except the owner have Water units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Water Units</returns>
		public bool WaterExists( IBattlePlayer owner ) {
			return WaterPercentage( owner ) != 0;
		}

		/// <summary>
		/// Other players except the owner have Organic units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Organic Units</returns>
		public bool OrganicExists( IBattlePlayer owner ) {
			return OrganicPercentage( owner ) != 0;
		}

		/// <summary>
		/// Other players except the owner have Heavy units
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>True if other players have Heavy Units</returns>
		public bool MechanicExists( IBattlePlayer owner ) {
			return MechanicalPercentage( owner ) != 0;
		}

		/// <summary>
		/// Number of Heavy units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Heavy units</returns>
		public int HeavyPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].HeavyCount;
			}
			return GetPercentage(owner, total);
		}

		

		/// <summary>
		/// Number of Medium units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Medium units</returns>
		public int MediumPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].MediumCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of Light units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Light units</returns>
		public int LightPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].LightCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of Air units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Air units</returns>
		public int AirPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].AirUnitsCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of  Ground units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of  Ground units</returns>
		public int GroundPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].GroundUnitsCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of Heavy units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Heavy units</returns>
		public int WaterPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].WaterUnitsCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of Organic units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Organic units</returns>
		public int OrganicPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].OrganicCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Number of Mechanical units of the specified player
		/// </summary>
		/// <param name="owner">Current Player</param>
		/// <returns>Number of Mechanical units</returns>
		public int MechanicalPercentage( IBattlePlayer owner ) {
			int total = 0;
			foreach( IBattlePlayer battlePlayer in statistics.Keys ) {
				if( owner.PlayerNumber == battlePlayer.PlayerNumber ) {
					continue;
				}
				total += statistics[battlePlayer].MechanicCount;
			}
			return GetPercentage(owner, total);
		}

		/// <summary>
		/// Adds a new unit
		/// </summary>
		public void Add( IBattlePlayer owner, IElement element ) {
			statistics[owner].Add(element);
		}

		/// <summary>
		/// Add a Player
		/// </summary>
		public void AddPlayer( IBattlePlayer player ) {
			if( !statistics.ContainsKey(player) ) {
				statistics.Add(player, new PlayerStatistics());
			}
		}

		/// <summary>
		/// Get the bonus to increment the unit value
		/// </summary>
		public int GetIncrement( IBattlePlayer owner, int Count ) {
			if( Count == 0 ) {
				return 0;
			}
			return (int)modifierContainer.GetModifier(Count);
		}

		/// <summary>
		/// Updates the statistics of the current battle
		/// </summary>
		/// <param name="attacker">Player that is attacking</param>
		/// <param name="attacked">Player that is attacked</param>
		/// <param name="unit">Unit destroyed</param>
		/// <param name="quantity">Quantity Destroyed</param>
		public void UpdateStatistics( IBattlePlayer attacker, IBattlePlayer attacked, IUnitInfo unit, int quantity ) {
			statistics[attacker].AddDestroyedUnit(unit, quantity);
			statistics[attacked].RemoveUnit(unit, quantity);
			statistics[attacked].AddDestroyedUnitByOtherPlayer(unit, quantity);
		}
		
		/// <summary>
		/// Gets the number of the destroyed units the the player
		/// </summary>
		/// <param name="current">Player to get the statistic from</param>
		/// <returns>Dictionary with all the units and the destroyed quantities</returns>
		public Dictionary<IUnitInfo, int> GetDestroyedUnits( IBattlePlayer current ) {
			return statistics[current].UnitsDestroyed;
		}


		/// <summary>
		/// Gets the number of the destroyed units the the player
		/// </summary>
		/// <param name="current">Player to get the statistic from</param>
		/// <returns>Dictionary with all the units and the destroyed quantities</returns>
		public Dictionary<IUnitInfo, int> GetDestroyedUnitsByOthers( IBattlePlayer current ) {
			return statistics[current].UnitsDestroyedByOthers;
		}

		/// <summary>
		/// Parse statistics
		/// </summary>
		public void Parse( string unitsDestroyed ) {
			if( !string.IsNullOrEmpty(unitsDestroyed) ) {
				string[] battlePlayersStatistics = unitsDestroyed.Split('$');

				foreach (string stats in battlePlayersStatistics) {
					if( !string.IsNullOrEmpty(stats) ) {
						ParsePlayer(stats);
					}
				}
			}
		}

		/// <summary>
		/// Parses the player information about the destoyed units
		/// </summary>
		/// <param name="stats"></param>
		private void ParsePlayer(string stats) {
			string[] statsSplited = stats.Split('#');

			int playerNumber;
			if( int.TryParse(statsSplited[0], out playerNumber) ) {
				IPlayerStatistics s = GetPlayerStatistics(playerNumber);
				s.Parse(statsSplited[1]);
			}
		}

		#endregion Public

		#region Object Implementation

		/// <summary>
		/// Converts a PlayerStatistics object into it's string representation
		/// </summary>
		/// <returns>The string representation of this object</returns>
		public override string ToString() {
			StringBuilder builder = new StringBuilder();

			foreach (KeyValuePair<IBattlePlayer, IPlayerStatistics> pair in statistics) {
				builder.AppendFormat("{0}#{1}$",pair.Key.PlayerNumber,pair.Value);
			}

			return builder.ToString();
		}

		#endregion Object Implementation

		#region Constructor

		static BattleStatistics() {
			modifierContainer.Add(0, 20, 1);
			modifierContainer.Add(20, 40, 2);
			modifierContainer.Add(40, 60, 3);
			modifierContainer.Add(60, 80, 4);
			modifierContainer.Add(80, 100, 5);
		}

		#endregion Constructor

	}
}
