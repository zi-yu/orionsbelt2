using System.Collections.Generic;
using System.IO;
using BotHandler.Engine;
using System;

namespace BotHandler {
	public class FiringSquadMoves : Moves {

		#region Fields

		protected static FiringSquadMoves instance = new FiringSquadMoves();

		#endregion Fields

		#region Properties

		public static Moves Instance {
			get { return instance; }
		}

		#endregion Properties

		#region Util Classes

		private class UnitMove {
			public string Raw;
			public int Value;
			public int MovCost;
			public bool HasAttack;
			public bool JustAttack;
			public Coordinate FinalCoordinate;
			public string Identifier;
			public string TargetIdentifier;
			public Element Element;
			public override string ToString() {
				return string.Format("{0} | {1} | {2} | {3}", Raw, Value, MovCost, HasAttack);
			}

		};

		private class UnitMoves : List<UnitMove> { };

		#endregion Util Classes

		#region Private

		private void SendMoves(Battle battle, UnitMoves toRun) {
			TextWriter writer = new StringWriter();

			foreach (UnitMove move in toRun) {
				writer.Write(move.Raw);
			}

			MakeMoves(battle, writer.ToString());
		}

		private static UnitMoves GroupMovesIntoPlay(Battle battle, UnitMoves moves) {
			moves.Sort(SortMoves);
			WriteMoves(moves, string.Format("Total Possible Moves: {0}", moves.Count));

			UnitMoves toRun = new UnitMoves();
			List<string> blockedUnits = new List<string>();
			List<string> invalidCoordinates = new List<string>();
            List<string> targetLog = new List<string>();

			int movPoints = 6;
			foreach (UnitMove move in moves) {
                if (movPoints == 0) {
                    break;
                }
				if (movPoints - move.MovCost < 0) {
                    continue;
				}
				if (move.HasAttack && !battle.CanAttack) {
					continue;
				}
				if (blockedUnits.Contains(move.Identifier)) {
					continue;
				}
				if (invalidCoordinates.Contains(move.FinalCoordinate.ToString())) {
					continue;
				}
                if (move.HasAttack ) {
                    if (targetLog.Contains(move.TargetIdentifier)) {
                        continue;
                    } else {
                        targetLog.Add(move.TargetIdentifier);
                    }
                }
				toRun.Add(move);
				blockedUnits.Add(move.Identifier);
				invalidCoordinates.Add(move.FinalCoordinate.ToString());
				movPoints -= move.MovCost;
			}

			return toRun;

		}

		private static UnitMoves GetMovesForPosition(Battle battle) {
			UnitMoves moves = new UnitMoves();
            foreach (Element element in GetCurrentPlayerBattleElements(battle)) {
				AddMovesForPosition(moves, battle, element, null, element.Coordinate);
			}
			return moves;
		}

        private static IEnumerable<Element> GetCurrentPlayerBattleElements(Battle battle)
        {
            foreach (Element elem in battle.GetCurrentPlayerElements()) {
                if (elem.CanbeMoved) {
                    yield return elem;
                }
            }
        }

		private static void AddMovesForPosition(UnitMoves moves, Battle battle, Element element, string parentMoves, Coordinate finalCoordinate) {
			foreach (Element target in battle.GetElementsThatMayBeAttackedBy(element)) {
				AddAttackMove(battle, moves, element, target, parentMoves, finalCoordinate, false);
			}

			foreach (string rotation in UnitMappings.GetRotations(element)) {
				Element rotated = new Element(element);
				rotated.Direction = rotation;
				string moveCode = string.Format("r:{0}-{1}-{2};", rotated.Coordinate, element.Direction, rotated.Direction);
				if (!string.IsNullOrEmpty(parentMoves)) {
					moveCode = parentMoves + moveCode;
				}
				foreach (Element target in battle.GetElementsThatMayBeAttackedBy(rotated)) {
					AddAttackMove(battle, moves, rotated, target, moveCode, finalCoordinate, true);
				}
			}

		}

		private static void AddMovesFromOtherLocations(Battle battle, UnitMoves moves) {
            foreach (Element element in GetCurrentPlayerBattleElements(battle)) {
				foreach (Coordinate coord in UnitMappings.GetPossibleUnitCoordinates(element)) {
					if (battle.SectorHasElement(coord.X, coord.Y)) {
						continue;
					}

                    Element moved = new Element(element);
                    moved.Coordinate = coord;

                    string moveCode = string.Format("m:{0}-{1}-{2};", element.Coordinate, moved.Coordinate, element.Quantity);

					AddMovesForPosition(moves, battle, moved, moveCode, moved.Coordinate);
                    AddMovementMove(moves, moved, moveCode);
				}
			}
		}

		private static int SortMoves(UnitMove m1, UnitMove m2) {
            if (m1.Value == m2.Value) {
                return m1.MovCost.CompareTo(m2.MovCost);
            }
			return m1.Value.CompareTo(m2.Value) * -1;
		}

		private static int SortByMovType(UnitMove m1, UnitMove m2) {
			return m1.JustAttack.CompareTo(m2.JustAttack) * -1;
		}

        private static void AddMovementMove(UnitMoves moves, Element moved, string moveCode)
        {
            UnitMove move = new UnitMove();

            move.JustAttack = false;
            move.Element = moved;
            move.MovCost = moved.Unit.MovementCost;
            move.Value = moved.Unit.MovementCost - 100;
            move.HasAttack = false;
            move.Raw = moveCode;
            move.Identifier = moved.Identifier;
            move.FinalCoordinate = moved.Coordinate;
            move.TargetIdentifier = string.Empty;

            moves.Add(move);
        }

		private static void AddAttackMove(Battle battle, UnitMoves moves, Element element, Element target, string previousMove, Coordinate finalCoordinate, bool rotated) {
			UnitMove move = new UnitMove();

			move.JustAttack = true;
			move.Element = element;
			move.MovCost = 1;
			move.HasAttack = true;
			move.Value = GetAttackValue(battle, element, target);
			move.Raw = string.Format("b:{0}-{1};", element.Coordinate, target.Coordinate);
			move.Identifier = element.Identifier;
			move.FinalCoordinate = finalCoordinate;
			move.TargetIdentifier = target.Identifier;

			if (!string.IsNullOrEmpty(previousMove)) {
				move.JustAttack = false;
				move.Raw = previousMove + move.Raw;
				move.MovCost += 4;// element.Unit.MovementCost;
				move.Value -= 1;
			}

			if (rotated) {
				move.MovCost += 1;
			}

			moves.Add(move);
		}

		private static int GetAttackValue(Battle battle, Element element, Element target) {
            int damage = element.Unit.Attack * element.Quantity;
            int health = target.Unit.Defense * target.Quantity;
            int value = damage;
            if (damage > health) {
                value = health;
            } else {
                value = damage;
            }
			return value;
		}

		#endregion Private

        #region Log

        private static void Write(string str, params object[] args)
        {
            Console.WriteLine(str, args);
        }

        private static void WriteMoves(UnitMoves moves, string title)
        {
            Write("----------- {0} ----------", title);
            
            foreach (UnitMove move in moves) {
                Write("Elem[{0} - {1}] Target:{2} MovCost:{3} Value:{4} FinalCoord:{5} Raw:{6}", 
                        move.Element, move.Identifier,
                        move.TargetIdentifier,
                        move.MovCost,
                        move.Value,
                        move.FinalCoordinate,
                        move.Raw
                    );
            }
        }

        #endregion Log

        #region Public

        public override void MakeMoves(Battle battle) {
			Write("#######################################");
            Write("\tBattle {0} | {1} vs {2} | Turn: {3}", battle.Id, battle.Players[1].Name, battle.Players[0].Name, battle.Turn);
            Write("#######################################");

			UnitMoves moves = GetMovesForPosition(battle);
			AddMovesFromOtherLocations(battle, moves);

			UnitMoves toRun = GroupMovesIntoPlay(battle, moves);
			WriteMoves(toRun, "Calculated Moves");

			toRun.Sort(SortByMovType);
			WriteMoves(toRun, "Final Ordered Moves");

			SendMoves(battle, toRun);
        }

		#endregion Public

		#region Constructor

		private FiringSquadMoves() {
			botName = "FiringSquad";
        }

        #endregion Constructor
	}
}
