
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidNumberOfMoves : ResultItem {

		#region Constructor

		public InvalidNumberOfMoves( string maxNumberOfMoves, string numberOfMoves ) {
			parameters = new string[] { maxNumberOfMoves, numberOfMoves };
			log = "Invalid Number of Moves. User used '{1}' when the maximum is '{0}'";
		}

		#endregion Constructor

	}
}
