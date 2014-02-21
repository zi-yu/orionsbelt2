using OrionsBelt.Generic;

namespace OrionsBelt.BattleCore {
	public class PlayerAlreadyPositioned : ResultItem {

		#region Constructor

		public PlayerAlreadyPositioned( string playerName ) {
			parameters = new string[] { playerName };
			log = "Player '{0}' already positioned";
		}

		#endregion Constructor


	}
}
