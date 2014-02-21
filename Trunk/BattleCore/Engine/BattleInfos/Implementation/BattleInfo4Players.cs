using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[NoAutoRegister]
	public abstract class BattleInfo4Players : BattleInfo {

		#region Fields

		private readonly int numberOfPlayers;

		#endregion Fields

		#region Properties

		/// <summary>
		/// Number of players in battle
		/// </summary>
		public override int NumberOfPlayers {
			get { return numberOfPlayers; }
		}

		#endregion Properties

		#region Private

        protected override  void UpdateUltimateUnit(){}

	    /// <summary>
		/// Gets the players that are not in the same team of the passed player.
		/// This method is used to increment the desctroyed units when a player (the passed player)
		/// gives up or loses by timeout
		/// </summary>
		/// <param name="player"></param>
		/// <returns></returns>
		private List<IBattlePlayer> GetOtherPlayers( IBattlePlayer player ) {
			List<IBattlePlayer> otherPlayers = new List<IBattlePlayer>();
			foreach( IBattlePlayer p in Players ) {
				if( !p.HasLost && p.PlayerNumber != player.PlayerNumber && p.TeamNumber != player.TeamNumber ) {
					otherPlayers.Add(p);
				}
			}
			return otherPlayers;
		}

		/// <summary>
		/// Splits the destroyed units for the list of players
		/// </summary>
		/// <param name="others"></param>
		/// <param name="player"></param>
		/// <param name="element"></param>
		private void AddDestroyedUnits( List<IBattlePlayer> others, IBattlePlayer player, IElement element ) {
			int value = element.Quantity/others.Count;
			int count = 0;
			for(int i = 0; i < others.Count; ++i ) {
				count += value;
				IBattlePlayer current = others[i];
				if( i == others.Count-1 ) {
					if( element.Quantity > count ) {
						value = count + ( element.Quantity - count );
					}
				}
				BattleStatistics.UpdateStatistics(current, player, element.Unit, value);
			}
		}

		#endregion Private

		#region BattleInfo Implementation

		/// <summary>
		/// Updates the current player when it's position time
		/// </summary>
		/// <param name="battleOwner">Player that is deploying the units</param>
		public override void UpdateCurrentPlayer( IBattleOwner battleOwner ) {
			currentPlayer = Players.Find(delegate( IBattlePlayer p ) { return p.Owner.Id == battleOwner.Id; });
		}

		/// <summary>
		/// Erases all units from the board that are owned by the passed player
		/// </summary>
		/// <param name="player">Player that has lost</param>
		public override void RemovePlayerUnits( IBattlePlayer player ) {
			List<IBattlePlayer> others = GetOtherPlayers(player);

			List<IBattleCoordinate> toRemove = new List<IBattleCoordinate>();
			foreach( KeyValuePair<IBattleCoordinate, IElement> pair in board ) {
				if( pair.Value.Owner.PlayerNumber == player.PlayerNumber ) {
					toRemove.Add(pair.Key);
				}
			}

			foreach( IBattleCoordinate coordinate in toRemove ) {
				IElement element = board[coordinate];
				AddDestroyedUnits(others, player, element);
				board.Remove(coordinate);
			}
		}

		/// <summary>
		/// Get's the next player to play
		/// </summary>
		internal override IBattlePlayer GetNextPlayer() {
			int currentId = currentPlayer.PlayerNumber + 1;
			while( true ) {
				if( currentId == Players.Count ) {
					currentId = 0;
				}
				IBattlePlayer p = Players[currentId];
				if( !p.HasLost ) {
					return p;
				}
				++currentId;
			}
		}

		#endregion BattleInfo Implementation

		#region Constructor

		public BattleInfo4Players() { }

		public BattleInfo4Players( IBattle battle )
			: base(battle) {
			numberOfPlayers = 4;
		}

		public BattleInfo4Players( IBattle battle, int numberOfPlayers )
			: base(battle) {
			this.numberOfPlayers = numberOfPlayers;
		}

		#endregion Constructor

	}
}
