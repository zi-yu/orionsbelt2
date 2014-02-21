
using OrionsBelt.Generic;
namespace OrionsBelt.BattleCore {
	public class InvalidNumberOfParameters : ResultItem {

		#region Constructor

		public InvalidNumberOfParameters( int expected, int obtained ) {
			parameters = new string[] { expected.ToString(), obtained.ToString() };
			log = "Invalid number of parameters. Expected '{0}' but was '{1}'";
		}

		#endregion Constructor

	}
}
