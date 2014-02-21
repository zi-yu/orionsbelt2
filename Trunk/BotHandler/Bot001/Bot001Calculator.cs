using System;
using System.IO;
using BotHandler.Engine;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;

namespace BotHandler{
    public class Bot001Calculator{

        #region Fields

		protected Node parentNode;
        protected Node cheapestNode;
        protected readonly List<Node> allNodes = new List<Node>();
		protected static readonly string move = "m:{0}_{1}-{2}_{3}-{4};";
        protected static readonly string battle = "b:{0}_{1}-{2}_{3};";
        protected static readonly string rotation = "r:{0}_{1}-{2}-{3};";
		protected readonly bool canAttack = true;
        protected int turn;
		protected readonly Terrain terrain;

        #endregion Fields

        #region Private
		
		public static bool IsCoordinateValid(int x, int y) {
			return x >= 0 && x <= 7 && y >= 0 && y <= 7;
		}

		protected static bool IsValid(int newX, int newY, int newCost){
            return IsCoordinateValid(newX,newY) && newCost < 7;
        }

		protected static string GetMove(int i, int j, int newX, int newY, int p) {
			return string.Format(move, i + 1, j + 1, newX + 1, newY + 1, p);
		}

        protected static string GetRotation(int i, int j, char position, char newPosition){
            return string.Format(rotation, i + 1, j + 1, position, newPosition);
        }

		protected static string GetAttack(int i, int j, int newX, int newY) {
			return string.Format(battle, i + 1, j + 1, newX + 1, newY + 1);
		}

        protected bool Exists(Node newNode){
			if (ExistsInParent(newNode)) {
				return true;
			}
        	
			Node found = allNodes.Find(delegate(Node n) { return n.GetHashCode() == newNode.GetHashCode(); });
        	return found != null;
        	//return allNodes.Contains(newNode);
        }

		protected static bool ExistsInParent(Node newNode) {
			if (newNode.Parent != null && newNode.Parent.Children != null) {
				foreach( Node n in newNode.Parent.Children) {
					if( newNode.Equals(n)) {
						return true;
					}
				}
			}
			return false;
		}

		protected static Node CreateNewNode(Node parent, SimpleElement[,] board, short i, short j, SimpleElement curr, int newX, int newY, int newCost) {
            SimpleElement[,] newBoard = DeepCloneBoard(board);
			SimpleElement e = newBoard[newX, newY];
			if( e == null ) {
				newBoard[newX, newY] = new SimpleElement(curr.Id, curr.Quantity, curr.Direction);
			}else {
				newBoard[newX, newY].Quantity += curr.Quantity;
			}
            newBoard[i, j] = null;
            
            return new Node(parent, newBoard, newCost, GetMove(i, j, newX, newY, curr.Quantity),new Coordinate(i,j));
        }

        protected Coordinate[] CanAttack(SimpleElement[,] board, short x, short y, IUnitInfo unit) {
			if( canAttack ) {
			    Coordinate[] possibleCoordinates = null;
			    for(int w = 0; w < UnitMappings.PossiblePositions.Length; ++w) {
			        char position = UnitMappings.PossiblePositions[w];
			        Coordinate c = SimpleAttackChecker.CanAttack(board, x, y, unit, position);
                    if( c != null ) {
                        if( possibleCoordinates == null ) {
                            possibleCoordinates = new Coordinate[4];
                        }
                        possibleCoordinates[w] = c;
                    }
			    }
			    return possibleCoordinates;
			}
            return null;
        }

		protected static SimpleElement[,] DeepCloneBoard(SimpleElement[,] board) {
			SimpleElement[,] newBoard = new SimpleElement[8,8];
			for (short i = 0; i < 8; ++i) {
				for (short j = 0; j < 8; ++j) {
					SimpleElement curr = board[i, j];
					if (curr != null) {
						newBoard[i, j] = curr.DeepClone();
					}
				}
			}
			return newBoard;
		}

        protected Node Attack(Node parent, SimpleElement curr, SimpleElement[,] board, IUnitInfo unit, int x, int y, Coordinate target, char newDirection){
        	SimpleElement[,] newBoard = DeepCloneBoard(board);
        	
            SimpleElement e = newBoard[target.X,target.Y];
			if (e.HasBeenAttack && e.UnitsDestroyed >= e.Quantity) {
				return null;
			}

        	short id;
			if(e.CanBeMoved) {
				id = (short)(e.Id - 10000);	
			}else {
				id = (short)(e.Id - 1000);
			}

            IUnitInfo targetUnit = UnitMappings.GetUnit(id);
			int destroyed = (unit.GetAttack(terrain, targetUnit) * curr.Quantity) / targetUnit.GetDefense(terrain, unit);
        	int quantityDestroyed;
            if( destroyed >= e.Quantity ) {
            	quantityDestroyed = e.Quantity;
            	e.UnitsDestroyed = e.Quantity;
            }else {
            	quantityDestroyed = destroyed;
				e.UnitsDestroyed = (short)(e.Quantity - destroyed);
            }
			e.HasBeenAttack = true;
			

        	newBoard[x, y].Id += 10000;
            int cost = parent.Cost;
            StringWriter moveStr = new StringWriter();
            if( curr.Direction != newDirection ) {
                moveStr.Write(GetRotation(x, y, curr.Direction, newDirection));
                cost += 1;
            }
            cost += unit.AttackCost;
            moveStr.Write(GetAttack(x, y, target.X, target.Y));

			return new Node(parent, newBoard, cost, moveStr.ToString(), quantityDestroyed * targetUnit.UnitValue);
        }

		protected void MoveSimpleElement(Node parent, SimpleElement[,] board, short i, short j) {
            SimpleElement curr = board[i, j];
            
            if( curr.CanBeMoved) {
            	return;
            }
            IUnitInfo unit = UnitMappings.GetUnit(curr.Id);
			Coordinate[] possibleAttacks = CanAttack(board, i, j, unit);
			
			if (possibleAttacks != null && parent.Cost < 6) {
                for (int w = 0; w < possibleAttacks.Length; ++w) {
                    char newPosition = UnitMappings.PossiblePositions[w];
                    if( newPosition != curr.Direction ) {
                        if( parent.Cost + 2 > 6) {
                            continue;
                        }
                    }
                    Coordinate attack = possibleAttacks[w];
                    if( attack!= null){ 
                        Node n = Attack(parent, curr, board, unit, i, j, attack, newPosition  );
						if( n != null ) {
							AddNode(parent, n);
						}
                    }
                }
            }

            if ( curr.Id >= 0 && curr.Id < 1000){
				short[,] moves = UnitMappings.GetMoveByPosition(curr.Direction.ToString(), unit.MovementType);
                for( int w = 0; w < moves.Length/2; ++w ) {
                    int newX = i + moves[w, 0];
					int newY = j + moves[w, 1];
					int newCost = parent.Cost + unit.MovementCost;
					if( IsValid(newX,newY,newCost) && parent.CheckValidCoordinate(newX,newY) ) {
						SimpleElement e = board[newX, newY];
						if( e == null || e.Id == curr.Id){
							Node n = CreateNewNode(parent,board, i, j, curr, newX, newY, newCost);
							AddNode(parent,n);
						}
					}
                }
            }
        }

        protected void AddNode(Node parent, Node n){
            if (Exists(n)){
                --Node.NodeCount;
                GC.ReRegisterForFinalize(n);
                return;
            }
            allNodes.Add(n);
            if (n.NodeValue == cheapestNode.NodeValue && n.Cost > cheapestNode.Cost) {
				cheapestNode = n;
			}
			if (IsCheapest(n) ) {
				cheapestNode = n;
			}
            parent.AddChildren(n);
        }

        protected bool IsCheapest(Node n){
            if( cheapestNode == null ) {
                return true;
            }
            return n.NodeValue > cheapestNode.NodeValue;
        }

        protected void FillTree(Node parent) {
            SimpleElement[,] board = parent.Board;
			for (short i = 0; i < 8; ++i) {
				for (short j = 0; j < 8; ++j) {
					SimpleElement curr = board[i, j];
					if( curr!= null && curr.Id < 1000 ) {
						MoveSimpleElement(parent, board,i,j);
					}
                }
            }
        	ExpandChildren(parent);
        }

		protected void ExpandChildren(Node parent) {
			if( parent.Children!= null) {
				foreach (Node children in parent.Children) {
					FillTree(children);
				}
			}
		}

		protected static string GetMovesFromNode(Node cheapestNode) {
			if (cheapestNode.Parent == null) {
				return string.Empty;
			}
			return GetMovesFromNode(cheapestNode.Parent) + cheapestNode.Move;
		}


        #endregion Private

        #region Public

        public virtual string Calculate(SimpleElement[,] initialBoard){
			parentNode = cheapestNode = new Node(initialBoard);
            Console.WriteLine("Calculating moves...");
			FillTree(parentNode);
            Console.WriteLine("Calculating moves DONE");
        	return GetMovesFromNode(cheapestNode);
        }
		
		#endregion Public

		#region Constructor

		public Bot001Calculator(Terrain terrain) {
			this.terrain = terrain;
		}

		public Bot001Calculator(int turn, Terrain terrain) {
            this.turn = turn;
			canAttack = turn > 1;
			this.terrain = terrain;
		}

		#endregion Constructor
	}
}
