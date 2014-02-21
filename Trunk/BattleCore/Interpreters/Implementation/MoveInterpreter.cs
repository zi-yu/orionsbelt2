using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("m")]
	internal class MoveInterpreter : InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo ) {
			return new MoveInterpreter(info, battleInfo);
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

			//Validate the owner of the element
			if( element.Owner.PlayerNumber != BattleInfo.CurrentBattlePlayer.PlayerNumber ) {
				return new InvalidUnitToMove(items[0]);
			}

			//Validate the Destiny element (if it exists)
			IElement dstElement = BattleInfo.SectorGetElement(dst);
			if( dstElement != null ) {
				if( !dstElement.Unit.Name.Equals( element.Unit.Name ) ||
					dstElement.Owner.PlayerNumber != BattleInfo.CurrentBattlePlayer.PlayerNumber
					) {
					return new InvalidDestiny(items[1]);
				}
			}

			//Validate the quantity
			ResultItem resultItem = ParseQuantity(element, items[2]);
			if( resultItem != null ) {
				return resultItem;
			}

			src = BattleInfo.PositionConverter.ConvertCoordinateToBase(src);
			dst = BattleInfo.PositionConverter.ConvertCoordinateToBase(dst);

			//Validate the type of movement
			if( !element.ValidateMove(src, dst) ) {
				return new InvalidMovement( element.Unit.Name, items[0], items[1]);
			}

			return null;
		}

		private ResultItem MoveGridToGrid( string[] items ) {
			IBattleCoordinate src = new BattleCoordinate(items[0]);
			IBattleCoordinate dst = new BattleCoordinate(items[1]);
			
			int quantity = int.Parse(items[2]);

			BattleInfo.SectorMove(src, dst, quantity);

			IElement element = BattleInfo.SectorGetElement(dst);
			IBattleCoordinate originCoordinate = BattleInfo.PositionConverter.ConvertCoordinateToBase(src);

			BattleInfo.AddTurnMessage(
				new MoveMessage(
					BattleInfo.Id,
					BattleInfo.CurrentTurn,
					element.Quantity,
					element.Unit.Name,
					originCoordinate,
					element.Coordinate
				)
			);

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
			if( e != null ) {
				int quant = int.Parse( items[2] );
				if( quant == e.Quantity ) {
					return e.Unit.MovementCost;
				}
				return e.Unit.MovementCost*2;
			}

			return base.MoveCost( );
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

		public MoveInterpreter() { }

		public MoveInterpreter( string info, BattleInfo battleInfo )
			: base(info, battleInfo) { }

		

		#endregion Constructor
		
	}
}