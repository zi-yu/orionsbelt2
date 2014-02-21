using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class InfestationAttack: ISpecialMove {

		#region Fields

		private static readonly InfestationAttack infestationAttack = new InfestationAttack();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return infestationAttack; }
		}

		#endregion Public 

		#region ISpecialMove Members

		public void ResolveMove( IBattleInfo battleInfo, IElement unit, IElement target ) {
			if( battleInfo.SectorRawHasElement(target.Coordinate) ) {
				int damage = unit.Unit.Attack*unit.Quantity;
				target.AddEffect(new Infestation(target, unit.Owner.PlayerNumber, damage));

				battleInfo.AddTurnMessage(new InfestationMessage(battleInfo.Id, battleInfo.CurrentTurn, target.Coordinate.ToString()));
			}
		}

		#endregion ISpecialMove Members

		#region Constructor

		private InfestationAttack() { }

		#endregion Constructor

	}
}
