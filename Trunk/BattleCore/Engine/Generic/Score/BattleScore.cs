using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("BattleScore")]
	public class BattleScore : BaseScore {

		#region Fields

		private readonly ScoreTeamTopContainer container = new ScoreTeamTopContainer();
		private readonly ScoreTeamVictoryContainer victorycontainer = new ScoreTeamVictoryContainer();

		#endregion Fields

		#region Private

		/// <summary>
		/// Calculates the score of one unit
		/// </summary>
		/// <param name="unit">Unit that is destroyed</param>
		/// <param name="quantity">Quantity destroyed</param>
		/// <returns>The total value of the destruction</returns>
		private static int CalculateUnitScore( IUnitInfo unit, int quantity ) {
            return unit.UnitValue * quantity;
		}


		/// <summary>
		/// Calculate the total unit cost of the destroyed units by the passed player
		/// </summary>
		/// <param name="current">Player to get the score from</param>
		/// <returns>The total value of the destroyed units</returns>
		private int CalculateTotalUnitValue( IBattlePlayer current ) {
			int total = 0;
			Dictionary<IUnitInfo, int> unitsDestroyed = battleInfo.BattleStatistics.GetDestroyedUnits(current);
			foreach( KeyValuePair<IUnitInfo, int> pair in unitsDestroyed ) {
				total += CalculateUnitScore(pair.Key, pair.Value);
			}
			return total;
		}

		/// <summary>
		/// Calculate the total unit value of the units destroyed by other players
		/// </summary>
		/// <param name="current">Player to get the score from</param>
		/// <returns>The total value of the destroyed units</returns>
		private int CalculateTotalDestroyedUnitValue( IBattlePlayer current ) {
			int total = 0;
			Dictionary<IUnitInfo, int> unitsDestroyed = battleInfo.BattleStatistics.GetDestroyedUnitsByOthers(current);
			foreach( KeyValuePair<IUnitInfo, int> pair in unitsDestroyed ) {
				total += CalculateUnitScore(pair.Key, pair.Value);
			}
			return total;
		}

		#region Modifiers

		/// <summary>
		/// Calculates the victory score in case the current player loses
		/// </summary>
		/// <param name="current">Player which the win score is going to be claculated</param>
		/// <returns>Value of the score in case the player loses</returns>
		private int CalculateWinScore( IBattlePlayer current ) {
			int totalUnitValue = CalculateTotalUnitValue(current);
            return totalUnitValue > 10000 ? 10000 : totalUnitValue;
		}

		/// <summary>
		/// Calculates the victory score in case the current player Wins
		/// </summary>
		/// <param name="current">Player which the lose score is going to be claculated</param>
		/// <returns>Value of the score in case the player wins</returns>
		private int CalculateLoseScore( IBattlePlayer current ) {
			int totalUnitValue = CalculateTotalDestroyedUnitValue(current);
		    return totalUnitValue > 10000 ? 10000 : totalUnitValue;
		}

		#endregion Modifiers

		#endregion Private

		#region Public

		/// <summary>
		/// Calculates the partial score, the score vefore the game ends
		/// </summary>
		/// <param name="allPlayers">Other Players in combat</param>
		/// <returns>The total value with the modifiers applied</returns>
		public override void SetPlayersScore( List<IBattlePlayer> allPlayers ) {
			container.AddPlayers(allPlayers);
			victorycontainer.AddPlayers(allPlayers);

			foreach( IBattlePlayer current in allPlayers ) {
				current.WinScore = CalculateWinScore(current);
				current.LoseScore = CalculateLoseScore(current);
			}
		}

		#endregion Public

		#region Constructor

		public BattleScore( ){}

		public BattleScore( IBattleInfo battleInfo ):base(battleInfo)
			{}

		#endregion Constructor

		#region IFactory Members

		public override object create( object args ) {
			return new BattleScore((IBattleInfo) args);
		}

		#endregion IFactory Members
		
	}
}
