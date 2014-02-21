using DesignPatterns.Attributes;
using OrionsBelt.BattleCore.Exceptions;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using System;

namespace OrionsBelt.BattleCore {

	[FactoryKey("r")]
	internal class RotationInterpreter : InterpreterBase {

		#region Factory Methods

		protected override object CreateInterpreter( string info, BattleInfo battleInfo ) {
			return new RotationInterpreter(info, battleInfo);
		}

		#endregion Factory Methods

		#region Private

		/// <summary>
		/// Check if the movement is OK
		/// </summary>
		/// <param name="items">Indexes: 0 - Coordinate, 1 - New Position</param>
		private ResultItem RotationCheck( string[] items ) {
			if( !BattleInfo.AllPlayersPositioned ) {
				return new AllPlayersMustBePositioned();
			}

			//Validate Coordinates
			IBattleCoordinate src;
			try {
				src = new BattleCoordinate(items[0]);
			} catch( CoordinateException ce ) {
				return new InvalidCoordinate(ce.Message);
			}

			//validate the source element
			IElement element = BattleInfo.SectorGetElement(src);
			if( element == null ) {
				return new InvalidElement(items[0]);
			}

			string pos = items[1].ToLower();
			if( pos != "n" && pos != "s" && pos != "w" && pos != "e" ) {
				return new InvalidRotation(pos.ToUpper());
			}

			pos = items[2].ToLower();
			if( pos != "n" && pos != "s" && pos != "w" && pos != "e" ) {
				return new InvalidRotation(pos.ToUpper());
			}

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
			return RotationCheck( items );
		}

		/// <summary>
		/// Executes the movement
		/// </summary>
		public override ResultItem Interpretate() {
			string[] items = Move.Split( '-' );

			IBattleCoordinate src = new BattleCoordinate(items[0]);

			IElement element = BattleInfo.SectorGetElement(src);
			string rotation = items[2].ToUpper();

			PositionType positionType = (PositionType) Enum.Parse(typeof(PositionType), rotation );
			element.Position = BattleInfo.PositionConverter.ConvertPositionToBase(positionType);

			BattleInfo.AddTurnMessage(
				new RotationMessage(BattleInfo.Id, BattleInfo.CurrentTurn, element.Coordinate, element.Position)	
			);

			return null;
		}

		#endregion

		#region Constructor

		public RotationInterpreter() { }

		public RotationInterpreter( string info, BattleInfo battleInfo )
			: base(info, battleInfo) { }

		#endregion Constructor
		
	}
}