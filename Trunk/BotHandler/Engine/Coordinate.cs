using System.Collections;
using System.Collections.Generic;
namespace BotHandler.Engine{

    public class Coordinate : IComparer<Coordinate>{
        #region Private
        
		private short x;
		private short y;
    	private static readonly Coordinate defaultCoordinate = new Coordinate(-1, -1);

        #endregion Private

        #region Properties

		public short X {
            get { return x; }
            set { x = value; }
        }

		public short Y {
            get { return y; }
            set { y = value; }
        }

    	public static Coordinate DefaultCoordinate {
    		get { return defaultCoordinate; }
    	}

    	#endregion Properties

        #region Public

        public static bool IsCoordinateValid(int x, int y) {
			return x >= 1 && x <= 8 && y >= 1 && y <= 8;
		}

		
        #endregion Public

        #region Overriden

        public override string ToString()
        {
            return string.Format("{0}_{1}", X, Y);
        }

        public override int GetHashCode(){
            return x * 1000 + y * 10;
        }

        public override bool Equals(object obj){
            Coordinate a = obj as Coordinate;
            if ( a != null){
                return X == a.X && Y == a.Y;
            }
            return false;
        }

        #endregion Overriden

		#region Constructor

		public Coordinate(short x, short y) {
			X = x;
			Y = y;
		}

		#endregion Constructor



        #region IComparer<Coordinate> Members

        public int Compare(Coordinate x, Coordinate y){
            if (x.X == y.X && x.Y == y.Y){
                return 0;
            }
            if (x.X > y.X && x.Y > y.Y){
                return 1;
            }
            return -1;
        }

        #endregion
    }
}
