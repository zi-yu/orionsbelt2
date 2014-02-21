using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidUnitToAttack : ResultItem {

		#region Constructor

		public InvalidUnitToAttack( string coord ) {
			parameters = new string[] { coord };
			log = "Cannot attack with the unit at coordinate '{0}'. The unit isn't yours.";
		}

		#endregion Constructor

	}
}
