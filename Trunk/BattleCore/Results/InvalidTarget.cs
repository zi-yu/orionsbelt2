using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidTarget : ResultItem {

		#region Constructor

		public InvalidTarget( string coord ) {
			parameters = new string[] { coord };
			log = "Cannot attack the unit at coordinate '{0}'. There is no unit at the location.";
		}

		#endregion Constructor

	}
}
