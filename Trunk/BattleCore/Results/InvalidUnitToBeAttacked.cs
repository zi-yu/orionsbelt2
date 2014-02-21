using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidUnitToBeAttacked : ResultItem {

		#region Constructor

		public InvalidUnitToBeAttacked( string coord ) {
			parameters = new string[] { coord };
			log = "Cannot attack the unit at coordinate '{0}'. The unit is yours.";
		}

		#endregion Constructor

	}
}
