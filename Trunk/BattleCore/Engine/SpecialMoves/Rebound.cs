using System;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	public class Rebound: ISpecialMove {

		#region Fields

		private static readonly Rebound rebound = new Rebound();

		#endregion Fields

		#region Private

		private static int GetTotalDamage(IElement target, int totalDefense, int totalDamage) {
			double td = totalDamage;
			double result = (target.Unit.Defense * td) / totalDefense;
			totalDamage = (int)result;
			return totalDamage;
		}

		private static int GetReboundDamage(IBattleInfo battleInfo, IElement target, IElement unit) {
		    int bonusDefense = target.GetDefense(battleInfo.Terrain, unit.Unit);
			int totalDefense = bonusDefense * target.Quantity;
			int baseDefense = target.Unit.Defense * target.Quantity;
			int totalDamage = AttackUtils.GetTotalDamage(battleInfo, unit, target);

			if (totalDefense <= baseDefense) {
                //totalDamage = GetTotalDamage(target, bonusDefense, totalDamage);
                //totalDefense = bonusDefense * (target.Quantity - 1) + target.RemainingDefense;
                totalDefense = baseDefense;
			}

			return Math.Abs(totalDamage - totalDefense);
		}

		#endregion Private

		#region Public

		public static ISpecialMove Instance {
			get { return rebound; }
		}

		#endregion Public 

		#region ISpecialMove Members

		public void ResolveMove( IBattleInfo battleInfo, IElement unit, IElement target ) {
			if( !battleInfo.SectorRawHasElement(target.Coordinate) ) {
				int reboundDamage = GetReboundDamage(battleInfo, target, unit);


				IBattleCoordinate nextCoordinate = target.Coordinate.NextCoordinate(unit.Position, battleInfo.NumberOfPlayers);

				if( battleInfo.SectorRawHasElement(nextCoordinate) ) {
					IElement reboundTarget = battleInfo.SectorRawGetElement(nextCoordinate);
					if (unit.Owner.PlayerNumber != reboundTarget.Owner.PlayerNumber) {
						int totalDefense = reboundTarget.GetDefense(battleInfo.Terrain, unit.Unit);
						int unitsDestroyed = AttackUtils.ResolveDamage(reboundDamage, totalDefense, battleInfo, reboundTarget);
						battleInfo.BattleStatistics.UpdateStatistics(unit.Owner, target.Owner, reboundTarget.Unit, unitsDestroyed);

						battleInfo.AddTurnMessage(
								new ReboundMessage(
									battleInfo.Id,
									battleInfo.CurrentTurn,
									reboundDamage, 
									unitsDestroyed, 
									reboundTarget.Unit.Name
								)
						);
					}
				}
			}
		}

		#endregion ISpecialMove Members

		#region Constructor

		private Rebound() { }

		#endregion Constructor

	}
}
