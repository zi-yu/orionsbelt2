using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class AttackChecker {
		
		#region Fields

		private static readonly Dictionary<PositionType, CheckAttack> attackCheck = new Dictionary<PositionType, CheckAttack>();
		private delegate bool CheckAttack( IBattleInfo info, IElement element, IElement dstElement );

		#endregion Fields

		#region Private

		private static bool CheckPathVert( IBattleInfo info, int stat, int src, int dst, bool catapult ) {
			for( int i = src; i < dst; ++i ) {
				if( info.SectorRawHasElement(new BattleCoordinate(i + "_" + stat)) && !catapult ) {
					return false;
				}
			}
			return true;
		}

		private static bool CheckPathHoriz( IBattleInfo info, int stat, int src, int dst, bool catapult ) {
			for( int i = src; i < dst; ++i ) {
				if( info.SectorRawHasElement(new BattleCoordinate(stat + "_" + i)) && !catapult ) {
					return false;
				}
			}
			return true;
		}

		private static bool CheckAttackN( IBattleInfo info, IElement element, IElement dstElement ) {
			IBattleCoordinate src = element.Coordinate;
			IBattleCoordinate dst = dstElement.Coordinate;
			int range = element.Unit.Range;

			int v = src.X - range;

			if ( v <= 0 && dst.X == 0 && dst.Y == 0 ) {
			    return CheckPathVert(info, src.Y, dst.X + 1, src.X, element.Unit.Catapult);
			}

			if( CheckPathVert(info, src.Y, dst.X + 1, src.X, element.Unit.Catapult) ) {
				bool first = dst.X < src.X && dst.X >= v;
				if (src.Y == 9 && info.NumberOfPlayers == 2) {
					return first;
				}
				return first && src.Y == dst.Y;
			}
			return false;
		}

		private static bool CheckAttackS( IBattleInfo info, IElement element, IElement dstElement ) {
			IBattleCoordinate src = element.Coordinate;
			IBattleCoordinate dst = dstElement.Coordinate;
			int range = element.Unit.Range;

			int v = src.X + range;
			
			if( CheckPathVert(info, src.Y, src.X + 1, dst.X, element.Unit.Catapult) ) {
				bool first = dst.X > src.X && dst.X <= v;
				if ((src.Y == 0 || src.Y == 9 || dst.Y == 0 || dst.Y == 9) && info.NumberOfPlayers == 2) {
					return first;
				}
				return first && src.Y == dst.Y;
			}
			return false;
		}

		private static bool CheckAttackW( IBattleInfo info, IElement element, IElement dstElement ) {
			IBattleCoordinate src = element.Coordinate;
			IBattleCoordinate dst = dstElement.Coordinate;
			int range = element.Unit.Range;

			int v = src.Y - range;
			if( CheckPathHoriz(info, src.X, dst.Y + 1, src.Y, element.Unit.Catapult) ) {
				return dst.Y < src.Y && dst.Y >= v && src.X == dst.X;
			}
			return false;
		}

		private static bool CheckAttackE( IBattleInfo info, IElement element, IElement dstElement ) {
			IBattleCoordinate src = element.Coordinate;
			IBattleCoordinate dst = dstElement.Coordinate;
			int range = element.Unit.Range;

			int v = src.Y + range;
			if( CheckPathHoriz(info, src.X, src.Y + 1, dst.Y, element.Unit.Catapult) ) {
				return dst.Y > src.Y && dst.Y <= v && src.X == dst.X;
			}
			return false;
		}

		#endregion Private

		#region Public

		public static bool CanAttack( IBattleInfo info, IElement element, IElement dstElement ) {
			return attackCheck[element.Position](info, element, dstElement);
		}

		#endregion Public

		#region Constructor

		static AttackChecker() {
			attackCheck.Add(PositionType.N, CheckAttackN);
			attackCheck.Add(PositionType.S, CheckAttackS);
			attackCheck.Add(PositionType.E, CheckAttackE);
			attackCheck.Add(PositionType.W, CheckAttackW);
		}

		#endregion Constructor
	}
}
