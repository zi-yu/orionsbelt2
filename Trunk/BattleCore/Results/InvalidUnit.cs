
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidUnit : ResultItem {

		#region Constructor

		public InvalidUnit( string unitName ) {
			parameters = new string[] { unitName };
			log = "Invalid Unit: {0}";
		}

		#endregion Constructor

	}
}
