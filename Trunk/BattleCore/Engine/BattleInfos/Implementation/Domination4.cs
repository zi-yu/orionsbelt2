using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("Domination4")]
	public class Domination4: BattleInfo4Players {

		#region Fields

		private readonly DominationTeamContainer dominationTeamContainer = new DominationTeamContainer();
		private readonly int totalNumberOfTurns;

		#endregion Fields

		#region Private

		/// <summary>
		/// Increments the Domination points IFacilityInfo there is a unit
		/// in the passed coordinate
		/// </summary>
		/// <param name="x">Value X of the coordinate</param>
		/// <param name="y">Value Y of the coordinate</param>
		private void IncrementDominationPoints( int x, int y ) {
			BattleCoordinate c = new BattleCoordinate(x, y);
			if( SectorRawHasElement( c ) ) {
				IElement e = SectorRawGetElement(c);
				if( e.Owner.PlayerNumber == CurrentBattlePlayer.PlayerNumber ) {
					++CurrentBattlePlayer.DominationPoints;
				}
			}
		}

		#endregion Private

		#region Overriden Methods

		/// <summary>
		/// Verifies if the battle has ended
		/// </summary>
		/// <returns></returns>
		public override bool HasEnded() {
			if( !AllPlayersPositioned ) {
				return false;
			}

			if( totalNumberOfTurns >= CurrentTurn ) {
				return false;
			}
			
			foreach( IBattlePlayer p in Players ) {
				dominationTeamContainer.AddPlayer(p);
			}

			return dominationTeamContainer.ResolveResult(this);
		}

		/// <summary>
		/// Updates the movements made, the next player to play and the victory percentage
		/// </summary>
		/// <param name="movements">movements made</param>
		public override void BattleFinalUpdate( string movements ) {
			base.BattleFinalUpdate(movements);
			IncrementDominationPoints(5, 5);
			IncrementDominationPoints(5, 8);
			IncrementDominationPoints(8, 5);
			IncrementDominationPoints(8, 8);
		}

		#endregion Overriden Methods

		#region Constructor

		public Domination4() { }

		public Domination4( IBattle battle ) : base(battle) {
			BattleType = RulesCore.Enum.BattleType.Domination4;
			totalNumberOfTurns = Players.Count*10;
		}

		#endregion Constru

		#region IFactory

		public override object create( object args ) {
			return new Domination4((IBattle) args);
		}

		#endregion IFactory

	}
}
