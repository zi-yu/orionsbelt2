using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class RemoveAbilityAttack: ISpecialMove {

		#region Fields

		private static readonly RemoveAbilityAttack removeAbilityAttack = new RemoveAbilityAttack();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return removeAbilityAttack; }
		}

		#endregion Public

		#region ISpecialMove Members

		public void ResolveMove(IBattleInfo battleInfo, IElement unit, IElement target) {
			if( battleInfo.SectorRawHasElement(target.Coordinate) ) {
				target.CanUseSpecialAbilities = false;
				target.AddEffect(new RemoveAbility(target));

				battleInfo.AddTurnMessage(new RemoveAbilityMessage(battleInfo.Id, battleInfo.CurrentTurn, target.Coordinate.ToString()));
			}
		}

		#endregion ISpecialMove Members

		#region Constructor

		private RemoveAbilityAttack() { }

		#endregion Constructor
	}
}
