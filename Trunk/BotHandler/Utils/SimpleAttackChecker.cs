
using System.Collections.Generic;
using BotHandler.Engine;
using OrionsBelt.RulesCore.Interfaces;

namespace BotHandler{
    
    public class SimpleAttackChecker{

        #region Fields

		private delegate Coordinate Checker(SimpleElement[,] board, short i, short j, IUnitInfo unit);
        private static Dictionary<char,Checker> mapping = new Dictionary<char, Checker>();

        #endregion Fields

        #region Private

        private static bool IsCoordinateValid(int x, int y){
            return x >= 0 && x <= 7 && y >= 0 && y <= 7;
        }

        #endregion Private

        #region Public

		private static Coordinate CheckN(SimpleElement[,] board, short i, short j, IUnitInfo unit) {
            int r = i - unit.Range;
			r = r < 0 ? 0 : r;
			for (short x = (short)(i - 1); x >= r; --x) {
				if (IsCoordinateValid(x, j)) {
					SimpleElement e = board[x, j];
					if (e != null) {
						if (e.Enemy) {
							return new Coordinate(x,j);
						}
						if( !unit.Catapult) {
							return null;
						}
					}
				}
			}
            return null;
        }

		private static Coordinate CheckS(SimpleElement[,] board, short i, short j, IUnitInfo unit) {
            int r = i + unit.Range;
			r = r > 7 ? 7 : r;
			for (short x = (short)(i + 1); x <= r; ++x) {
				if (IsCoordinateValid(x, j)) {
					SimpleElement e = board[x, j];
					if (e != null) {
						if (e.Enemy) {
							return new Coordinate(x,j);
						}
						if( !unit.Catapult) {
							return null;
						}
					}
				}
			}
            return null;
        }

		private static Coordinate CheckW(SimpleElement[,] board, short i, short j, IUnitInfo unit) {
            int r = j - unit.Range;
			r = r < 0 ? 0 : r;
			for (short y = (short)(j - 1); y >= r; --y) {
				if (IsCoordinateValid(i, y)) {
					SimpleElement e = board[i, y];
					if (e != null) {
						if (e.Enemy) {
							return new Coordinate(i,y);
						}
						if( !unit.Catapult) {
							return null;
						}
					}
				}
			}
            return null;
        }

		private static Coordinate CheckE(SimpleElement[,] board, short i, short j, IUnitInfo unit) {
            int r = j + unit.Range;
			r = r > 7 ? 7 : r;
			for (short y = (short)(j + 1); y <= r; ++y) {
				if (IsCoordinateValid(i, y)) {
					SimpleElement e = board[i, y];
					if (e != null) {
						if (e.Enemy) {
							return new Coordinate(i,y);
						}
						if( !unit.Catapult) {
							return null;
						}
					}
				}
			}
            return null;
        }

        #endregion Public

        #region Public

		public static Coordinate CanAttack(SimpleElement[,] board, short i, short j, IUnitInfo unit, char position) {
            return mapping[position](board, i, j, unit);                       
        }

        #endregion Public

        #region Constructor

        static SimpleAttackChecker() {
            mapping['N'] = CheckN;
            mapping['S'] = CheckS;
            mapping['W'] = CheckW;
            mapping['E'] = CheckE;
        }

        #endregion

    }
}
