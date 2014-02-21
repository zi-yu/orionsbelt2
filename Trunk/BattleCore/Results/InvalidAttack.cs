using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class InvalidAttack : ResultItem {

		#region Constructor

		public InvalidAttack( string src, string dst ) {
			parameters = new string[] { src, dst };
			log = "Unit at coordinate {0} cannot attack unit at coordinate {1}.Invalid Attack.";
		}

		#endregion Constructor

	}
}
