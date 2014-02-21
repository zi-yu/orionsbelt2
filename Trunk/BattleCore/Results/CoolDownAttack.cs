
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {
	public class CoolDownAttack : ResultItem {

		#region Constructor

		public CoolDownAttack(IElement element) {
			parameters = new string[] { element.Unit.Name, element.Cooldown.ToString() };
			log = "Unit '{0}' cannot attack. It has a cooldown of {1} turn(s).";
		}

		#endregion Constructor

	}
}
