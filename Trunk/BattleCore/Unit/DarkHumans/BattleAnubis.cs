using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("a")]
	public class BattleAnubis: Anubis {

		#region Constructor

        public BattleAnubis()
        {
			bonus[UnitCategory.Heavy.ToString()] = new DefenseBonus(1600);
		}

		#endregion Constructor

	};
}
