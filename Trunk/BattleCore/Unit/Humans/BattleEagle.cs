using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("e")]
	public class BattleEagle: Eagle {

		#region Constructor

		public BattleEagle() {
			bonus[UnitCategory.Medium.ToString()] = new AttackBonus(400);
			bonus[UnitCategory.Heavy.ToString()] = new DefenseBonus(400);
		}

		#endregion Constructor
	}
}
