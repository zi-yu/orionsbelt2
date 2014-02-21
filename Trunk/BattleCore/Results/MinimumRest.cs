
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class MinimumRest : ResultItem {

		#region Constructor

		public MinimumRest( string maxUnits, string unitName, string quantityMoved ) {
			parameters = new string[] { maxUnits, unitName, quantityMoved };
			log = "Minimum Rest: You must leave at least '{0}' {1}'s. You left '{2}'.";
		}

		#endregion Constructor

	}
}
