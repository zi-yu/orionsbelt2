using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("sk")]
	public class BattleSeeker: Seeker {

		#region Constructor

        public BattleSeeker()
        {
            bonus[OrionsBelt.RulesCore.Enum.UnitCategory.Medium.ToString()] = new AttackBonus(500);
		}

		#endregion Constructor

	};
}
