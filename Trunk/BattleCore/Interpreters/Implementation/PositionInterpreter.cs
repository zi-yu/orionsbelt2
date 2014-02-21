using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("p")]
	internal class PositionInterpreter : InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo) {
			return new PositionInterpreter(info, battleInfo);
		}

		#endregion Factory Methods

		#region Private

		/// <summary>
		/// Check if the positioning is ok
		/// </summary>
		/// <param name="items">Indexes: 0 - name of the unit, 1 - destiny, 2  - quantity.</param>
		private ResultItem PositioningCheck( string[] items ) {
			IElement elem = BattleInfo.InitialContainer.GetElement(items[0]);
			if( elem == null ) {
				return new InvalidUnit(items[0]);
			}

			ResultItem resultItem = CheckMoveData(elem, items[1], items[2]);
			if( resultItem != null ) {
				return resultItem;
			}

			if( !MoveChecker.CheckPositioning(BattleInfo.NumberOfPlayers, new BattleCoordinate(items[1]), elem.Position) ) {
				return new InvalidCoordinate(items[1]);
			}

			return null;
		}

		/// <summary>
		/// Checks the infomation of the element to move
		/// </summary>
		private ResultItem CheckMoveData( IElement e, string dst, string quant ) {
			IBattleCoordinate dstCoord;
			try {
				dstCoord = new BattleCoordinate(dst);
			} catch( CoordinateException ce ) {
				return new InvalidCoordinate(ce.Message);
			}

			IElement a = BattleInfo.SectorGetElement(dstCoord);
			if( a != null && !a.Unit.Name.Equals(e.Unit.Name) ) {
				return new CoordinateAlreadyHasAUnit(dstCoord);
			}

			int q;
			if( !int.TryParse(quant, out q) ) {
				return new InvalidQuantity(quant, e.Unit.Name);
			}

			if( e.Quantity < q || q < 1 ) {
				return new InvalidUnitPositioning(e.Unit.Name, quant);
			}

			return null;
		}

		/// <summary>
		/// Moves the element form the source container into the Battle Field
		/// </summary>
		private ResultItem MoveSrcToGrid( string[] items ) {
			IElement elem = BattleInfo.InitialContainer.GetElement(items[0]);
			if( elem == null ) {
				return new InvalidElement(items[0]);	
			}

			IBattleCoordinate dst = new BattleCoordinate(items[1]);
			elem.Owner = BattleInfo.CurrentBattlePlayer;
			elem.Coordinate = dst;

			int quant = int.Parse(items[2]);

			BattleInfo.SectorSrcMove(elem, quant);

			return null;			
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Checks if the move can be correctly made
		/// </summary>
		/// <returns>A result item with the result</returns>
		public override ResultItem CheckMove() {
			string[] items = Move.Split('-');

			if( BattleInfo.IsDeployTime ) {
				return PositioningCheck( items );
			}

			return new PlayerAlreadyPositioned( BattleInfo.CurrentBattlePlayer.Name );
		}

		/// <summary>
		/// Executes the movement
		/// </summary>
		public override ResultItem Interpretate( ) {
			string[] items = Move.Split( '-' );

			return MoveSrcToGrid( items );
		}

		#endregion Public

		#region Constructor

		public PositionInterpreter() { }

		public PositionInterpreter( string info, BattleInfo battleInfo )
			: base(info, battleInfo) {
		}

		#endregion	Constructor

	}
}