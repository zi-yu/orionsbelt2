
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidMove : ResultItem {

		#region Constructor

		public InvalidMove( string move) {
			parameters = new string[] { move };
			log = "Invalid Move: {0}";
		}

		#endregion Constructor

	}
}
