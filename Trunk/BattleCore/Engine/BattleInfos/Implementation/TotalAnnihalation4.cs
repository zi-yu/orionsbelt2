using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("TotalAnnihalation4")]
	public class TotalAnnihalation4: BattleInfo4Players {

		#region Private

		/// <summary>
		/// Gather all the players in battle
		/// </summary>
		/// <returns>The list of player currently in battle</returns>
		private List<IBattlePlayer> GatherBattlePlayers() {
			List<IBattlePlayer> players = new List<IBattlePlayer>();
			foreach( IElement element in board.Values ) {
				IBattlePlayer current = element.Owner;
				if( !players.Contains(current) ) {
					players.Add(current);
				}
			}
			return players;
		}

		/// <summary>
		/// Checks all the players to check if they already lost
		/// </summary>
		/// <param name="currentPlayers">The list of player currently in battle</param>
		private void ResolvePlayersDefeat( List<IBattlePlayer> currentPlayers ) {
			foreach( IBattlePlayer player in Players ) {
				if( !currentPlayers.Contains(player) ) {
					RemovePlayerUnits(player);
					player.HasLost = true;
				}
			}
		}

		/// <summary>
		/// Checks if the team has won
		/// </summary>
		/// <param name="currentPlayers">The list of player currently in battle</param>
		/// <returns>True if the team has one. False if there is more than a team in play</returns>
		private static bool CheckIfTeamHasWon( List<IBattlePlayer> currentPlayers ) {
			int team = -1;
			foreach( IBattlePlayer player in currentPlayers ) {
				if( team == -1 ) {
					team = player.TeamNumber;
					continue;
				}
				if( player.TeamNumber != team ) {
					return false;
				}
			}
			return true;
		}

		#endregion

		#region Overriden Methods

		/// <summary>
		/// Verifies if the battle has ended
		/// </summary>
		/// <returns>True if the battle has ended. False Otherwise</returns>
		public override bool HasEnded() {
			if( !AllPlayersPositioned ) {
				return false;
			}

			if( !Battle.HasEnded ) {
				List<IBattlePlayer> currentPlayers = GatherBattlePlayers();
				ResolvePlayersDefeat(currentPlayers);
				return CheckIfTeamHasWon(currentPlayers);
			}
			return true;
		}

		#endregion Overriden Methods

		#region Constructor

		public TotalAnnihalation4(){}

		public TotalAnnihalation4( IBattle battle ) : base(battle) {
			BattleType = OrionsBelt.RulesCore.Enum.BattleType.TotalAnnihalation4;
		}

		#endregion Constructor

		#region IFactory

		public override object create( object args ) {
			return new TotalAnnihalation4((IBattle) args);
		}

		#endregion IFactory
	}
}
