using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class Triple: ISpecialMove {

		#region Fields

		private static readonly Triple triple = new Triple();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return triple; }
		}

		#endregion Public

		#region Private

		private static void RightDamage(IBattleInfo battleInfo, IElement target, IElement unit, int tripleDamage) {
			IBattleCoordinate rightCoordinate = target.Coordinate.RightCoordinate(unit.Position, battleInfo.NumberOfPlayers);
			if (battleInfo.SectorRawHasElement(rightCoordinate)) {
				IElement rightElement = battleInfo.SectorRawGetElement(rightCoordinate);
				if (unit.Owner.PlayerNumber != rightElement.Owner.PlayerNumber) {
					int totalDefense = rightElement.GetDefense(battleInfo.Terrain, unit.Unit);
					int unitsDestroyed = AttackUtils.ResolveDamage(tripleDamage, totalDefense, battleInfo, rightElement);
					battleInfo.BattleStatistics.UpdateStatistics(unit.Owner, target.Owner, rightElement.Unit, unitsDestroyed);

					battleInfo.AddTurnMessage(
						new TripleAttackRightMessage(
							battleInfo.Id,
							battleInfo.CurrentTurn,
							tripleDamage,
							unitsDestroyed,
							rightElement.Unit.Name
							)
						);
				}
			}
		}

		private static void LeftDamage(IBattleInfo battleInfo, IElement target, IElement unit, int tripleDamage) {
			IBattleCoordinate leftCoordinate = target.Coordinate.LeftCoordinate(unit.Position, battleInfo.NumberOfPlayers);
			if (battleInfo.SectorRawHasElement(leftCoordinate)) {
				IElement leftElement = battleInfo.SectorRawGetElement(leftCoordinate);
				if (unit.Owner.PlayerNumber != leftElement.Owner.PlayerNumber) {
					int totalDefense = leftElement.GetDefense(battleInfo.Terrain, unit.Unit);
					int unitsDestroyed = AttackUtils.ResolveDamage(tripleDamage, totalDefense, battleInfo, leftElement);
					battleInfo.BattleStatistics.UpdateStatistics(unit.Owner, target.Owner, leftElement.Unit, unitsDestroyed);

					battleInfo.AddTurnMessage(
						new TripleAttackLeftMessage(
							battleInfo.Id,
							battleInfo.CurrentTurn,
							tripleDamage,
							unitsDestroyed,
							leftElement.Unit.Name
							)
						);
				}
			}
		}


		#endregion Private

		#region ISpecialMove Members

		public void ResolveMove(IBattleInfo battleInfo, IElement unit, IElement target) {
			int totalDamage = AttackUtils.GetTotalDamage(battleInfo, unit, target);

			int tripleDamage = (totalDamage / 2);

			LeftDamage(battleInfo, target, unit, tripleDamage);
			RightDamage(battleInfo, target, unit, tripleDamage);
		}

		#endregion ISpecialMove Members

		#region Constructor

		private Triple() { }

		#endregion Constructor
	}
}
