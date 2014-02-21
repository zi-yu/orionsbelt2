using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidQuantity : ResultItem {

		#region Constructor

		public InvalidQuantity( string value, string unitName ) {
			parameters = new string[] { value, unitName };
			log = "{0} is an invalid quantity for the unit '{1}'";
		}

		#endregion Constructor

	}
}
