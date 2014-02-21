using System;

namespace OrionsBelt.BattleCore.Exceptions {
	public class CoordinateException : BattleException {

		#region Fields

		private string coordinate;

		#endregion Fields

		#region Properties

		public string Coordinate {
			get { return coordinate; }
			set { coordinate = value; }
		}

		#endregion Properties

		#region Constructors

		/// <summary>
        /// DALException constructor
        /// </summary>
        public CoordinateException () {
        }

		/// <summary>
		/// CoordinateException constructor
        /// </summary>
        /// <param name="reason">Exception message</param>
		/// <param name="coordinate">Coordinate</param>
        public CoordinateException( string coordinate, string reason )
			: base(String.Format("Coordinate:{0} ; {1}", coordinate, reason))
        {
			this.coordinate = coordinate;
        }

		/// <summary>
		/// CoordinateException constructor
		/// </summary>
		/// <param name="reason">Exception message</param>
		/// <param name="coordinate">Coordinate</param>
		/// <param name="param">Reason parameters</param>
		public CoordinateException( string coordinate, string reason, params object[] param )
			: base(String.Format("Coordinate:{0} ; {1}", coordinate, string.Format(reason, param))) 
		{
			this.coordinate = coordinate;
		}

        #endregion Constructors
	}
}
