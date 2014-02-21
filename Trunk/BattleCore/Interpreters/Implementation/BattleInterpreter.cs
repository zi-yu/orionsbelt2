using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("b")]
	internal class BattleInterpreter: InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo ) {
			return new BattleInterpreter(info, battleInfo);
		}

		#endregion Factory Methods
	
		#region Private

		private ResultItem AttackCheck( string[] items ) {
			if( !BattleInfo.AllPlayersPositioned ) {
				return new AllPlayersMustBePositioned();
			}

			if( BattleInfo.Battle.CurrentTurn == 1 ) {
				return new FirstAttack();
			}

			IBattleCoordinate src, dst;
			try {
				src = new BattleCoordinate(items[0]);
				dst = new BattleCoordinate(items[1]);
			} catch( CoordinateException ce ) {
				return new InvalidCoordinate(ce.Message);
			}

			//validate the source element
			IElement element = BattleInfo.SectorGetElement(src);
			if( element == null ) {
				return new InvalidElement(items[0]);
			}

			if (element.Cooldown > 0 ) {
				return new CoolDownAttack(element);
			}

			//Validate the owner of the element
			if( element.Owner.PlayerNumber != BattleInfo.CurrentBattlePlayer.PlayerNumber ) {
				return new InvalidUnitToAttack(items[0]);
			}

			//Validate the Target element
			IElement dstElement = BattleInfo.SectorGetElement(dst);
			if( dstElement != null ) {
				//Validate the owner of the element
				if( dstElement.Owner.PlayerNumber == BattleInfo.CurrentBattlePlayer.PlayerNumber ) {
					return new InvalidUnitToBeAttacked(items[1]);
				}

				//Validate the owner of the element
				if( dstElement.Owner.TeamNumber == BattleInfo.CurrentBattlePlayer.TeamNumber ) {
					return new SameTeam(dst);
				}

				if( !AttackChecker.CanAttack(BattleInfo, element, dstElement) ) {
					return new InvalidAttack(element.Coordinate.ToString(), dstElement.Coordinate.ToString());
				}
			}

			return null;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Check the cost of the current move depending of the type of the unit
		/// </summary>
		/// <returns>The movement cost of the unit</returns>
		public override int MoveCost() {
			string[] items = Move.Split( '-' );
			IElement e = BattleInfo.SectorGetElement( new BattleCoordinate(items[0]) );
			return e.Unit.AttackCost;
		}

		/// <summary>
		/// Checks if the move can be correctly made
		/// </summary>
		/// <returns>A result item with the result</returns>
		public override ResultItem CheckMove() {
			string[] items = Move.Split('-');

			return AttackCheck(items);
		}

		/// <summary>
		/// Executes the movement
		/// </summary>
		public override ResultItem Interpretate() {
			string[] items = Move.Split( '-' );

			IBattleCoordinate src = new BattleCoordinate(items[0]);
			IBattleCoordinate dst = new BattleCoordinate(items[1]);

			IElement element = BattleInfo.SectorGetElement(src);
			IElement target = BattleInfo.SectorGetElement(dst);
			if( target != null) {
				element.ResolveAttackCycle(BattleInfo, target, true);
			}

			return null;
		}

		#endregion

		#region Constructor

		public BattleInterpreter() { }

		public BattleInterpreter( string info, BattleInfo battleInfo )
			: base(info, battleInfo) { }

		#endregion Constructor
	}
}