using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[NoAutoRegister]
	public abstract class BattleInfo2Players : BattleInfo {

		#region Properties

		/// <summary>
		/// Number of players in battle
		/// </summary>
		public override int NumberOfPlayers {
			get { return 2; }
		}

		#endregion Properties

		#region BattleInfo Implementation

        protected override void UpdateUltimateUnit(){
            if( HasEnded() ){
                foreach (IBattlePlayer player in Players){
                    if (player.HasLost && player.HasUltimateUnit){
                        BattleStatistics.UpdateStatistics(GetEnemyPlayer(player),player,player.UltimateUnit.Element.Unit,1);
                    }
                }
            }
        }

        protected IBattlePlayer GetEnemyPlayer( IBattlePlayer player) {
	        if( player.PlayerNumber == 1 ) {
		        return Players[0];
	        }
	        return Players[1];
        }

		/// <summary>
		/// Updates the current player when it's position time
		/// </summary>
		/// <param name="battleOwner">Player that is positioning</param>
		public override void UpdateCurrentPlayer( IBattleOwner battleOwner ) {
			if( Players[0].Owner.Id == battleOwner.Id ) {
				currentPlayer = Players[0];
			}else{
				currentPlayer = Players[1];
			}
		}

		/// <summary>
		/// Erases all units from the board that are owned by the passed player
		/// </summary>
		/// <param name="player">Player that has lost</param>
		public override void RemovePlayerUnits( IBattlePlayer player ) {
            IBattlePlayer other = GetEnemyPlayer(player);

			List<IBattleCoordinate> toRemove = new List<IBattleCoordinate>();
			foreach( KeyValuePair<IBattleCoordinate, IElement> pair in board ) {
				if( pair.Value.Owner.PlayerNumber == player.PlayerNumber ) {
					toRemove.Add(pair.Key);
				}
			}
			
			foreach( IBattleCoordinate coordinate in toRemove ) {
				IElement element = board[coordinate];
				if( player.HasGaveUp ) {
					int quantity = element.Quantity;
					element.Quantity = (int)(element.Quantity*0.2);
					if (element.Quantity == 0) {
						SectorRemoveElement(coordinate);
					}
					BattleStatistics.UpdateStatistics(other, player, element.Unit, Math.Abs(element.Quantity - quantity));	
				}else {
					BattleStatistics.UpdateStatistics(other, player, element.Unit, element.Quantity);	
					board.Remove(coordinate);	
				}
			}
		}

		/// <summary>
		/// Get's the next player to play
		/// </summary>
		internal override IBattlePlayer GetNextPlayer() {
			return GetEnemyPlayer(CurrentBattlePlayer);
		}

		#endregion BattleInfo Implementation

		#region Constructor

		public BattleInfo2Players() { }

		public BattleInfo2Players( IBattle battle )
			: base(battle) {}

		#endregion Constructor

	}
}
