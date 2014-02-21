using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.BattleCore {

	[FactoryKey("n")]
	public class BattleNova: Nova {

		#region Constructor

		public BattleNova() {
			bonus[UnitType.Organic.ToString()] = new AttackBonus(4000);
		}

		#endregion Constructor

	}
}
