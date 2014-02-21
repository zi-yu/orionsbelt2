using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class StrikeBack : ISpecialMove {

		#region Fields

		private static readonly StrikeBack strikeBack = new StrikeBack();

		#endregion Fields

		#region Fields

		private static PositionType Convert(PositionType p) {
			switch (p) {
				case PositionType.N:
					return PositionType.S;
				case PositionType.S:
					return PositionType.N;
				case PositionType.W:
					return PositionType.E;
				default:
					return PositionType.W;
			}
		}

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return strikeBack; }
		}

		#endregion Public

		#region ISpecialMove Members

		public void ResolveMove(IBattleInfo battleInfo, IElement unit, IElement target) {
			if (battleInfo.SectorRawHasElement(unit.Coordinate)) {
				if( target.Unit.Catapult ) {
					if( !AttackChecker.CanAttack(battleInfo,unit,target)) {
						return;
					}
				}
				if( !unit.CanBeMoved ) {
					return;
				}
				
				PositionType p = Convert(target.Position);
				int unitDistance = AttackUtils.Distance(unit, target);
				if (unitDistance <= unit.Unit.Range && unit.Position == p ) {
					battleInfo.AddTurnMessage(
						new StrikeBackMessage(
							battleInfo.Id,
							battleInfo.CurrentTurn,
							unit.Unit.Name
							)
						);

					unit.ResolveAttackCycle(battleInfo, target, false);
				}
			}
		}

		#endregion

		#region Constructor

		private StrikeBack() { }

		#endregion Constructor

	}
}
