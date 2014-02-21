
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidDestiny : ResultItem {

		#region Constructor

		public InvalidDestiny( string coord ) {
			parameters = new string[] { coord };
			log = "Invalid Destiny. The destiny coordinate '{0}' has a unit from diferent type of the one to move.";
		}

		#endregion Constructor

	}
}
