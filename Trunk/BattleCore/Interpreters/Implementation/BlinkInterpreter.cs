using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("bk")]
	internal class BlinkInterpreter : InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo ) {
			return new BlinkInterpreter(info, battleInfo);
		}

		#endregion Factory Methods
	
		#region Private

		/// <summary>
		/// Check if the normal movement is OK
		/// </summary>
		/// <param name="items">Indexes: 0 - source, 1 - destiny, 2  - quantity.</param>
		private ResultItem TurnCheck( string[] items ) {
			if( !BattleInfo.AllPlayersPositioned ) {
				return new AllPlayersMustBePositioned();
			}

			if( items.Length > 4 ) {
				return new InvalidNumberOfParameters(4, items.Length);
			}

			//Validate Coordinates
			IBattleCoordinate src,dst;
			try {
				src= new BattleCoordinate(items[0]);
				dst= new BattleCoordinate(items[1]);
			}catch( CoordinateException ce ) {
				return new InvalidCoordinate(ce.Message);
			}
			
			//validate the source element
			IElement element = BattleInfo.SectorGetElement( src );
			if( element == null ) {
				return new InvalidElement(items[0]);
			}

			//Validate the Destiny element (if it exists)
			IElement dstElement = BattleInfo.SectorGetElement(dst);
			if( dstElement != null ) {
				if( !dstElement.Unit.Name.Equals( element.Unit.Name ) ) {
					return new InvalidDestiny(items[1]);
				}
			}

			//Validate the quantity
			ResultItem resultItem = ParseQuantity(element, items[2]);
			if( resultItem != null ) {
				return resultItem;
			}

			//Validate the type of movement
			if( dst.X < 5 ) {
				return new InvalidMovement( element.Unit.Name, items[0], items[1]);
			}

			return null;
		}

		private void SendBlinkMessage(IBattleCoordinate src, IBattleCoordinate dst) {
			IElement element = BattleInfo.SectorGetElement(dst);
			IBattleCoordinate originCoordinate = BattleInfo.PositionConverter.ConvertCoordinateToBase(src);

			BattleInfo.AddTurnMessage(
				new BlinkMessage(
					BattleInfo.Id,
					BattleInfo.CurrentTurn,
					element.Quantity,
					element.Unit.Name,
					originCoordinate,
					element.Coordinate
					)
				);
		}

		private void AddCoolDown() {
			IElement ultimate = BattleInfo.SectorGetElement(new BattleCoordinate(9, 9));
			ultimate.Cooldown = ultimate.Unit.CoolDown;
			ultimate.AddEffect(new CoolDown(ultimate, ultimate.Unit.CoolDown));
		}

		private ResultItem MoveGridToGrid( string[] items ) {
			IBattleCoordinate src = new BattleCoordinate(items[0]);
			IBattleCoordinate dst = new BattleCoordinate(items[1]);
			
			int quantity = int.Parse(items[2]);
			BattleInfo.SectorMove(src, dst, quantity);

			AddCoolDown();
			SendBlinkMessage(src, dst);

			return null;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Check the cost of the current move depending of the type of the unit
		/// </summary>
		/// <returns>The movement cost of the unit</returns>
		public override int MoveCost() {
			return 5;
		}

		/// <summary>
		/// Checks if the move can be correctly made
		/// </summary>
		/// <returns>A result item with the result</returns>
		public override ResultItem CheckMove() {
			string[] items = Move.Split('-');
			return TurnCheck( items );
		}


		/// <summary>
		/// Executes the movement
		/// </summary>
		public override ResultItem Interpretate() {
			string[] items = Move.Split( '-' );

			return MoveGridToGrid( items );
		}

		#endregion

		#region Constructor

		public BlinkInterpreter() { }

		public BlinkInterpreter( string info, BattleInfo battleInfo )
			: base(info, battleInfo) { }

		#endregion Constructor
		
	}
}