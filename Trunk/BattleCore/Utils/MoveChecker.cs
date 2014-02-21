using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class MoveChecker {
		
		#region Fields

		private static readonly Dictionary<string, CheckPosition> positionCheck = new Dictionary<string, CheckPosition>();
		private delegate bool CheckPosition( IBattleCoordinate src, IBattleCoordinate dst, PositionType position );

		#endregion Fields

		#region Public

		public static bool ParsePosition( MovementType movementType, IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			return ( positionCheck[movementType.ToString()] )(src, dst, position);
		}

		public static bool CheckPositioning( int numberOfPlayers, IBattleCoordinate dst, PositionType position ) {
			if( numberOfPlayers == 2 ) {
				if( dst.X != 8 && dst.X != 7 ) {
					return false;
				}

				return true;
			}

			//4 Players
			if( ( dst.X == 12 || dst.X == 11 ) && ( dst.Y > 2 && dst.Y < 11 ) ) {
				return true;
			}

			return false;
		}

		#endregion Public

		#region Position Check

		private static bool CheckFront( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			return ( positionCheck[position.ToString().ToLower()] )(src, dst, position);
		}

		private static bool CheckAll( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.X <= src.X + 1 && dst.X >= src.X - 1 ) {
				if( dst.Y <= src.Y + 1 && dst.Y >= src.Y - 1 ) {
					return true;
				}
			}

			return false;
		}

		private static bool CheckNormal( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.X <= src.X + 1 && dst.X >= src.X - 1 && src.Y == dst.Y ) {
				return true;
			}

			if( dst.Y <= src.Y + 1 && dst.Y >= src.Y - 1 && src.X == dst.X ) {
				return true;
			}

			return false;
		}

		private static bool CheckDiagonal( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.X == src.X + 1 && dst.Y == src.Y + 1 ||
				dst.X == src.X - 1 && dst.Y == src.Y - 1 ||
				dst.X == src.X + 1 && dst.Y == src.Y - 1 ||
				dst.X == src.X - 1 && dst.Y == src.Y + 1 ) {
				return true;
			}

			return false;
		}

		#endregion

		#region Directions Check

		private static bool CheckN( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.X == src.X - 1 && src.Y == dst.Y ) {
				return true;
			}
			return false;
		}
		private static bool CheckS( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.X == src.X + 1 && src.Y == dst.Y ) {
				return true;
			}
			return false;
		}
		private static bool CheckW( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.Y == src.Y - 1 && src.X == dst.X ) {
				return true;
			}
			return false;
		}
		private static bool CheckE( IBattleCoordinate src, IBattleCoordinate dst, PositionType position ) {
			if( dst.Y == src.Y + 1 && src.X == dst.X ) {
				return true;
			}
			return false;
		}

		#endregion

		#region Constructor

		static MoveChecker() {
			positionCheck.Add("All", CheckAll);
			positionCheck.Add("Front", CheckFront);
			positionCheck.Add("Diagonal", CheckDiagonal);
			positionCheck.Add("Normal", CheckNormal);

			positionCheck.Add("n", CheckN);
			positionCheck.Add("s", CheckS);
			positionCheck.Add("e", CheckE);
			positionCheck.Add("w", CheckW);
		}

		#endregion Constructor

	}
}
