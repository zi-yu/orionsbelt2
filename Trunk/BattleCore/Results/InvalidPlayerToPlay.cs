using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class InvalidPlayerToPlay : ResultItem {

		#region Constructor

		public InvalidPlayerToPlay( IBattleOwner player ) {
			parameters = new string[] { player.Name };
			log = "The player '{0}' cannot play. Is not his turn.";
		}

		#endregion Constructor

	}
}
