
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidUnitPositioning : ResultItem {

		#region Constructor

		public InvalidUnitPositioning( string unitName, string quantity ) {
			parameters = new string[] { unitName, quantity };
			log = "Cannot move {1} {0}s to the board. Not enough units of this type available.";
		}

		#endregion Constructor

	}
}
