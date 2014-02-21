using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidElement : ResultItem {

		#region Constructor

		public InvalidElement( string coordinate ) {
			parameters = new string[] { coordinate };
			log = "There is no element at coordinate '{0}'.";
		}

		#endregion Constructor

	}
}
