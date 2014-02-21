using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class ConvertToPlayer2: PositionConversionBase {

		#region Fields

		protected static Dictionary<PositionType,PositionType> positionConversion = new Dictionary<PositionType, PositionType>();

		#endregion Fields

		#region IPositionConversion Members

		public override PositionType ConvertPositionToBase( PositionType position ) {
			return positionConversion[position];
		}

		public override PositionType ConvertPositionToSpecific( PositionType position ) {
			return positionConversion[position];
		}

		public override IBattleCoordinate ConvertCoordinateToBase( IBattleCoordinate coordinate ) {
			BattleCoordinate ultimate = ResolveUltimateCoordinate(coordinate);
			if( ultimate != null ) {
				return ultimate;
			}
			int x = MaxCoordinateValue - coordinate.X;
			int y = MaxCoordinateValue - coordinate.Y;

			return new BattleCoordinate(x,y);
		}

		public override IBattleCoordinate ConvertCoordinateToSpecific( IBattleCoordinate coordinate ) {
			return ConvertCoordinateToBase(coordinate);
		}

		#endregion

		#region Constructor

		static ConvertToPlayer2()  {
			positionConversion[PositionType.N] = PositionType.S;
			positionConversion[PositionType.S] = PositionType.N;
			positionConversion[PositionType.W] = PositionType.E;
			positionConversion[PositionType.E] = PositionType.W;
		}

		public ConvertToPlayer2( int numberOfPlayers )
			: base(numberOfPlayers) {}

		#endregion Constructor
	}
}
