
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidMovement : ResultItem {

		#region Constructor

		public InvalidMovement( string unitName, string src, string dst ) {
			parameters = new string[] { unitName, src, dst };
			log = "Cannot move the unit '{0}' from '{1}' to '{2}'. The type of movement does not allow it.";
		}

		#endregion Constructor

	}
}
