using System.Collections.Generic;
using BotHandler.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace BotHandler{
    public class UnitMappings{

        #region Fields

        private static readonly IUnitInfo[] unitsById;
		private static readonly Dictionary<string, short> unitId = new Dictionary<string, short>();
        private static readonly Dictionary<string, IUnitInfo> unitsByCode = new Dictionary<string, IUnitInfo>();
		private static readonly Dictionary<MovementType, short[,]> allMoves = new Dictionary<MovementType, short[,]>();
        private static readonly char[] possiblePositions = new char[]{'N','S','W','E'};
        
        #endregion Fields

        #region Properties

        public static IUnitInfo[] UnitsById{
            get { return unitsById; }
        }

        public static Dictionary<string, IUnitInfo> UnitsByCode{
            get { return unitsByCode; }
        }

		public static Dictionary<string, short> UnitId {
            get { return unitId; }
        }

		//public static Dictionary<MovementType, short[,]> AllMoves {
		//    get { return allMoves; }
		//}

        public static char[] PossiblePositions {
            get { return possiblePositions; }
        }

        #endregion Properties

        #region Private

		private static short[,] GetAllMovementTypeArray(MovementType movementType) {
			switch (movementType) {
				case MovementType.All:
					return new short[,] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 }, { 1, -1 }, { 1, 0 }, { 1, 1 } };
				case MovementType.Diagonal:
					return new short[,] { { -1, -1 }, { -1, 1 }, { 1, -1 }, { 1, 1 } };
				case MovementType.Front:
					return new short[,] { { -1, 0 } };
				case MovementType.Normal:
					return new short[,] { { -1, 0 }, { 0, -1 }, { 0, 1 }, { 1, 0 } };
                case MovementType.AllFront:
                    return new short[,] { { -1, -1 }, { -1, 0 }, { -1, 1 }, { 0, -1 }, { 0, 1 } };
                case MovementType.DiagonalFront:
                    return new short[,] { { -1, -1 }, { -1, 1 } };
				default:
					return new short[0,0];
			}
		}


		#endregion Private

        #region Public

        public static IUnitInfo GetUnit( int i ) {
            return unitsById[i];
        }

        public static IUnitInfo GetUnit(string code){
            return unitsByCode[code];
        }

        public static IEnumerable<Coordinate> GetPossibleUnitCoordinates(Element element){
			short[,] m = GetMoveByPosition(element.Direction,element.Unit.MovementType);
			for (int w = 0; w < m.Length / 2; ++w) {
				short newX = (short)(element.Coordinate.X + m[w, 0]);
				short newY = (short)(element.Coordinate.Y + m[w, 1]);
				if (Coordinate.IsCoordinateValid(newX,newY)) {
					yield return new Coordinate(newX,newY);
				}
			}
        }

		public static short GetUnitId(Element element) {
            return unitId[element.Code];
        }

        public static IEnumerable<string> GetRotations(Element element)
        {
            string[] rotations = { "N", "S", "E", "W"};
            foreach (string rotation in rotations) {
                if (rotation != element.Direction) {
                    yield return rotation;
                }
            }
        }

		public static short[,] GetMoveByPosition(string direction, MovementType movementType) {
			if (movementType == MovementType.Front) {
				switch (direction) {
					case "N":
						return allMoves[movementType];
					case "S":
						return new short[,] { { 1, 0 } };
					case "W":
						return new short[,] { { 0, -1 } };
					default:
						return new short[,] { { 0, 1 } };
				}
			}
			return allMoves[movementType];
		}

        #endregion Public

        #region Constructor

        static UnitMappings(){
			short i = 0;
            unitsById = new IUnitInfo[OrionsBelt.BattleCore.Unit.Units.Count];
            foreach( IUnitInfo unit in OrionsBelt.BattleCore.Unit.Units ){
                unitsById[i] = unit;
                unitsByCode.Add(unit.Code, unit);
                UnitId.Add(unit.Code,i);
                ++i;
            }

            allMoves.Add(MovementType.All, GetAllMovementTypeArray(MovementType.All));
            allMoves.Add(MovementType.Diagonal, GetAllMovementTypeArray(MovementType.Diagonal));
            allMoves.Add(MovementType.Front, GetAllMovementTypeArray(MovementType.Front));
            allMoves.Add(MovementType.None, GetAllMovementTypeArray(MovementType.None));
            allMoves.Add(MovementType.Normal, GetAllMovementTypeArray(MovementType.Normal));
        }

        #endregion Constructor

    }
}
