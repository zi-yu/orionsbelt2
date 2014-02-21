using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class ConvertToPlayer4: PositionConversionBase {

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
			int x = MaxCoordinateValue - coordinate.Y;
			int y = coordinate.X;

			return new BattleCoordinate(x, y);
		}

		public override IBattleCoordinate ConvertCoordinateToSpecific( IBattleCoordinate coordinate ) {
			int x = coordinate.Y;
			int y = MaxCoordinateValue - coordinate.X;

			return new BattleCoordinate(x, y);
		}

		#endregion

		#region Constructor

		static ConvertToPlayer4() {
			positionConversionToBase[PositionType.N] = PositionType.W;
			positionConversionToBase[PositionType.S] = PositionType.E;
			positionConversionToBase[PositionType.W] = PositionType.S;
			positionConversionToBase[PositionType.E] = PositionType.N;

			positionConversionToSpecific[PositionType.N] = PositionType.E;
			positionConversionToSpecific[PositionType.S] = PositionType.W;
			positionConversionToSpecific[PositionType.W] = PositionType.N;
			positionConversionToSpecific[PositionType.E] = PositionType.S;
		}

		public ConvertToPlayer4( int numberOfPlayers )
			: base(numberOfPlayers) { }


		#endregion Constructor

	}
}
