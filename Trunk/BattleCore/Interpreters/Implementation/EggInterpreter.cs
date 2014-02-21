using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("e")]
	internal class EggInterpreter : InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo ) {
			return new EggInterpreter(info, battleInfo);
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

			if( items.Length > 1 ) {
				return new InvalidNumberOfParameters(1, items.Length);
			}

			//Validate Coordinates
			IBattleCoordinate dst;
			try {
				dst= new BattleCoordinate(items[0]);
			}catch( CoordinateException ce ) {
				return new InvalidCoordinate(ce.Message);
			}
			
			//Validate the Destiny element (if it exists)
			IElement dstElement = BattleInfo.SectorGetElement(dst);
			if( dstElement != null ) {
				return new InvalidDestiny(items[0]);
			}

			return null;
		}

		private void SendEggMessage(IElement element) {
			IBattleCoordinate dstCoordinate = BattleInfo.PositionConverter.ConvertCoordinateToBase(element.Coordinate);
			BattleInfo.AddTurnMessage(
				new EggPlacedMessage(
					BattleInfo.Id,
					BattleInfo.CurrentTurn,
					dstCoordinate
				)
			);
		}

		private void AddCoolDown() {
			IElement ultimate = BattleInfo.SectorGetElement(new BattleCoordinate(9, 9));
			ultimate.Cooldown = ultimate.Unit.CoolDown;
			ultimate.AddEffect(new CoolDown(ultimate, ultimate.Unit.CoolDown));
		}

		private ResultItem CreateInGrid(string[] items) {
			IBattleCoordinate dst = new BattleCoordinate(items[0]);
			IElement element = new Element(new BattleEgg(), 1, BattleInfo.CurrentBattlePlayer);
			element.Position = PositionType.N;
			element.Coordinate = dst;
			element.AddEffect( new Hatch(element) );
			BattleInfo.SectorInsertElement(element);

			AddCoolDown();
			return null;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Check the cost of the current move depending of the type of the unit
		/// </summary>
		/// <returns>The movement cost of the unit</returns>
		public override int MoveCost() {
			return 4;
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

			return CreateInGrid( items );
		}

		#endregion

		#region Constructor

		public EggInterpreter() { }

		public EggInterpreter(string info, BattleInfo battleInfo)
			: base(info, battleInfo) { }

		#endregion Constructor
		
	}
}