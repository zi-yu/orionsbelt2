using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("rp")]
	public class BattleRaptor: Raptor {

		#region Constructor

		public BattleRaptor() {
			bonus[UnitCategory.Light.ToString()] = new AttackBonus(1000);
		}

		#endregion Constructor

	}
}
