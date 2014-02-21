
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidInterpretationData : ResultItem {

		#region Constructor

		public InvalidInterpretationData( string data ) {
			parameters = new string[] { data };
			log = "Invalid Interpretation Data: {0}";
		}

		#endregion Constructor

	}
}
