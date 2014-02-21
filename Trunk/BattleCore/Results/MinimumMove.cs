
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class MinimumMove : ResultItem {

		#region Constructor

		public MinimumMove( string minUnits, string unitName, string quantityMoved ) {
			parameters = new string[] { minUnits, unitName, quantityMoved };
			log = "Minimum Move: You must move at least '{0}' {1}'s. You moved '{2}'.";
		}

		#endregion Constructor

	}
}
