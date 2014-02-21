using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class SameTeam : ResultItem {

		#region Constructor

		public SameTeam(IBattleCoordinate coord) {
			parameters = new string[]{ coord.ToString() };
			log = "Cannot attack unit at coordinate '{0}'. The target is from the same team.";
		}

		#endregion Constructor


	}
}
