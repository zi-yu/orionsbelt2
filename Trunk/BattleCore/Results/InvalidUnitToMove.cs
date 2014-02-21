using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidUnitToMove : ResultItem {

		#region Constructor

		public InvalidUnitToMove( string coord ) {
			parameters = new string[] { coord };
			log = "Cannot move the unit at coordinate '{0}'. The unit isn't yours.";
		}

		#endregion Constructor

	}
}
