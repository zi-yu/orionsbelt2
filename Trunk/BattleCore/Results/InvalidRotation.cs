using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidRotation : ResultItem {

		#region Constructor

		public InvalidRotation( string position ) {
			parameters = new string[] { position };
			log = "Invalid Rotation '{0}'.";
		}

		#endregion Constructor

	}
}
