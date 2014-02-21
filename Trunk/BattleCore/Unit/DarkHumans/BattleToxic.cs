using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("tx")]
	public class BattleToxic: Toxic {

		#region Constructor

        public BattleToxic()
        {
			bonus[UnitType.Organic.ToString()] = new AttackBonus(1000);
		}

		#endregion Constructor

	};
}
