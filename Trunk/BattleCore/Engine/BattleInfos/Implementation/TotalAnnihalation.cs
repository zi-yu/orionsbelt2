using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("TotalAnnihalation")]
	public class TotalAnnihalation: BattleInfo2Players {

		#region Private

		/// <summary>
		/// Verifies if this battle has ended.
		/// </summary>
		/// <returns>0-draw, 1-Player 1 won, 2- Player 2 Won, 3-hasn't ended </returns>
		private int HasBattleEnded() {
			int found = 0;

			foreach( IElement element in board.Values ) {
				if( element.Owner.HasGaveUp ) {
					return 3 - element.Owner.TeamNumber;
				}

				if( found != element.Owner.TeamNumber ) {
					found += element.Owner.TeamNumber;
					if( found == 3 ) {
						return found;
					}
				}
			}
			return found;
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

			if( !Battle.HasEnded ) {
				int result = HasBattleEnded();
				if( result == 3 ) {
					return false;
				}
				Players[2 - result].HasLost = true;
			}
			return true;
		}

		#endregion Overriden Methods

		#region Constructor

		public TotalAnnihalation() { }

		public TotalAnnihalation( IBattle battle ) : base(battle) {
			BattleType = OrionsBelt.RulesCore.Enum.BattleType.TotalAnnihalation;
		}

		#endregion Constructor

		#region IFactory

		public override object create( object args ) {
			return new TotalAnnihalation((IBattle) args);
		}

		#endregion IFactory

	}
}
