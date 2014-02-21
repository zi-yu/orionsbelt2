using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("Domination")]
	public class Domination: BattleInfo2Players {

		#region Fields

		private static readonly int totalNumberOfTurns = 40;

		#endregion Fields

		#region Private

		/// <summary>
		/// Set's the loser of the battle
		/// </summary>
		private void SetLoser() {
			if( Players[0].DominationPoints > Players[1].DominationPoints ) {
				Players[1].HasLost = true;
			}else {
				Players[0].HasLost = true;
			}
		}
		
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

			if( totalNumberOfTurns > CurrentTurn ) {
				return false;
			}
			if( Players[0].DominationPoints == Players[1].DominationPoints ) {
				return false;
			}

			SetLoser();
			return true;
		}

		/// <summary>
		/// Updates the movements made, the next player to play and the victory percentage
		/// </summary>
		/// <param name="movements">movements made</param>
		public override void BattleFinalUpdate( string movements ) {
			base.BattleFinalUpdate(movements);
			IncrementDominationPoints(3, 3);
			IncrementDominationPoints(5, 4);
			IncrementDominationPoints(4, 5);
			IncrementDominationPoints(6, 6);
		}

		#endregion Overriden Methods

		#region Constructor

		public Domination() { }

		public Domination( IBattle battle ) : base(battle) {
			BattleType = RulesCore.Enum.BattleType.Domination;
		}

		#endregion Constru

		#region IFactory

		public override object create( object args ) {
			return new Domination((IBattle) args);
		}

		#endregion IFactory

	}
}
