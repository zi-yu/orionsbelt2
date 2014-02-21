using System;
using System.Collections.Generic;
using System.IO;
using BotHandler.Engine;

namespace BotHandler {
    public class Node{

        #region Fields

        private SimpleElement[,] board;
        private int nodeValue = 0;
        private int cost;
    	private Node parent;
    	private List<Node> children;
    	private string move;
    	private Coordinate lastSrc;
		public static long NodeCount = 0;
		//private string representation;
        private int hash = 0;
        
        #endregion Fields

        #region Properties

        public int NodeValue{
            get { return nodeValue; }
            set { nodeValue = value; }
        }

        public SimpleElement[,] Board {
            get { return board; }
            set { board = value; }
        }

        public int Cost{
            get { return cost; }
            set { cost = value; }
        }

		public Node Parent {
			get { return parent; }
			set { parent = value; }
		}

    	public string Move {
    		get { return move; }
    		set { move = value; }
    	}

		public Coordinate LastSrc {
			get { return lastSrc; }
			set { lastSrc = value; }
		}

    	public List<Node> Children {
    		get { return children; }
    		set { children = value; }
    	}

    	//public string Representation {
		//    get {return representation; }
		//}

        #endregion Properties

        #region Private

        private int GetIntRepresentation(){
            int result = 0;
            for (int i = 0; i < 8; ++i){
                for (int j = 0; j < 8; ++j){
                    SimpleElement e = Board[i, j];
                    if (e != null){
                        result += (100*i + 10*j) + e.GetHashCode();
                    }
                }
            }
			return cost * 10000 + result + NodeValue;

        }

        #endregion Private

        #region Public

		public void AddChildren(Node node) {
			if( Children == null ) {
				Children = new List<Node>();
			}
			Children.Add(node);
		}

		public bool CheckValidCoordinate(int x, int y) {
			if (lastSrc == null ) {
				return true;
			}
			return x != lastSrc.X && y != lastSrc.Y;
		}

        public override int GetHashCode(){
            if (hash==0) {
                hash = GetIntRepresentation();     
            }
            return hash;
			//return board.GetHashCode();
        }

        public override bool Equals(object obj){
            return hash == obj.GetHashCode();
        }

        #endregion Public

        #region Constructor

        public Node(Node parent, SimpleElement[,] board, int cost, string move, Coordinate lastSrc){
            Board = board;
            Cost = cost;
        	Parent = parent;
        	Move = move;
        	this.lastSrc = lastSrc;
			++NodeCount;
            //representation = GetRepresentation();
        }

        public Node(Node parent, SimpleElement[,] board, int cost, string move, int nodeValue) {
			Board = board;
			Cost = cost;
			Parent = parent;
			this.nodeValue = nodeValue + parent.NodeValue;
			Move = move;
			++NodeCount;
			//representation = GetRepresentation();
		}

        public Node(SimpleElement[,] board){
            Board = board;
            Cost = 0;
        	++NodeCount;
			//representation = GetRepresentation();
        }

        #endregion Constructor

    }
}
