using System.Collections.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class BombAttack: ISpecialMove {

		#region Fields

		private static readonly BombAttack bombAttack = new BombAttack();

		#endregion Fields

		#region Public

		public static ISpecialMove Instance {
			get { return bombAttack; }
		}

		#endregion Public

		#region Private

		private static void AddCoordinate(List<IBattleCoordinate> coordinates, IBattleCoordinate coordinate) {
			if (!coordinates.Contains(coordinate)){
				coordinates.Add(coordinate);
			}
		}

		private static List<IBattleCoordinate> GetDamageCoodinates(IBattleInfo battleInfo, IElement unit, IElement target) {
			List<IBattleCoordinate> coordinates = new List<IBattleCoordinate>();

			AddCoordinate(coordinates, target.Coordinate.LeftCoordinate(unit.Position, battleInfo.NumberOfPlayers));
			//AddCoordinate(coordinates,target.Coordinate);
			AddCoordinate(coordinates,target.Coordinate.RightCoordinate(unit.Position, battleInfo.NumberOfPlayers));

			AddCoordinate(coordinates,unit.Coordinate.LeftCoordinate(unit.Position, battleInfo.NumberOfPlayers));
			AddCoordinate(coordinates,unit.Coordinate.RightCoordinate(unit.Position, battleInfo.NumberOfPlayers));

			IBattleCoordinate previous = unit.Coordinate.PreviousCoordinate(unit.Position, battleInfo.NumberOfPlayers);
			AddCoordinate(coordinates, previous.LeftCoordinate(unit.Position, battleInfo.NumberOfPlayers));
			AddCoordinate(coordinates, previous);
			AddCoordinate(coordinates, previous.RightCoordinate(unit.Position, battleInfo.NumberOfPlayers));

			return coordinates;
		}

		private static void Damage(IBattleInfo battleInfo, IElement unit, IBattleCoordinate coordinate, int damage) {
			if (battleInfo.SectorRawHasElement(coordinate)) {
				IElement element = battleInfo.SectorRawGetElement(coordinate);

				if (unit.Owner.PlayerNumber != element.Owner.PlayerNumber) {
					int totalDefense = element.GetDefense(battleInfo.Terrain, unit.Unit);
					int unitsDestroyed = AttackUtils.ResolveDamage(damage, totalDefense, battleInfo, element);
					battleInfo.BattleStatistics.UpdateStatistics(unit.Owner, element.Owner, element.Unit, unitsDestroyed);

					battleInfo.AddTurnMessage(
						new BombAttackDamageMessage(
							battleInfo.Id,
							battleInfo.CurrentTurn,
							damage,
							coordinate,
							unitsDestroyed,
							element.Unit.Name						
						)
					);
				}
			}
		}


		#endregion Private

		#region ISpecialMove Members

		public void ResolveMove(IBattleInfo battleInfo, IElement unit, IElement target) {
			int totalDamage = AttackUtils.GetTotalDamage(battleInfo, unit, target);
			List<IBattleCoordinate> coordinates = GetDamageCoodinates(battleInfo, unit, target);

			foreach (IBattleCoordinate coordinate in coordinates) {
				Damage(battleInfo, unit, coordinate, totalDamage);
			}
		}

		#endregion ISpecialMove Members

		#region Constructor

		private BombAttack() { }

		#endregion Constructor
	}
}
