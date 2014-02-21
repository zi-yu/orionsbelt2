using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class ConvertToPlayer3: PositionConversionBase {

		#region Fields

		protected static Dictionary<PositionType,PositionType> positionConversionToBase = new Dictionary<PositionType, PositionType>();
		protected static Dictionary<PositionType,PositionType> positionConversionToSpecific = new Dictionary<PositionType, PositionType>();

		#endregion Fields

		#region IPositionConversion Members

		public override PositionType ConvertPositionToBase( PositionType position ) {
			return positionConversionToBase[position];
		}

		public override PositionType ConvertPositionToSpecific( PositionType position ) {
			return positionConversionToSpecific[position];
		}

		public override IBattleCoordinate ConvertCoordinateToBase( IBattleCoordinate coordinate ) {
			int x = coordinate.Y;
			int y = MaxCoordinateValue - coordinate.X;

			return new BattleCoordinate(x,y);
		}

		public override IBattleCoordinate ConvertCoordinateToSpecific( IBattleCoordinate coordinate ) {
			int x = MaxCoordinateValue - coordinate.Y;
			int y = coordinate.X;

			return new BattleCoordinate(x, y);
		}

		#endregion

		#region Constructor

		static ConvertToPlayer3() {
			positionConversionToBase[PositionType.N] = PositionType.E;
			positionConversionToBase[PositionType.S] = PositionType.W;
			positionConversionToBase[PositionType.W] = PositionType.N;
			positionConversionToBase[PositionType.E] = PositionType.S;

			positionConversionToSpecific[PositionType.N] = PositionType.W;
			positionConversionToSpecific[PositionType.S] = PositionType.E;
			positionConversionToSpecific[PositionType.W] = PositionType.S;
			positionConversionToSpecific[PositionType.E] = PositionType.N;
		}

		public ConvertToPlayer3( int numberOfPlayers )
			: base(numberOfPlayers) { }

		#endregion Constructor
	}
}
