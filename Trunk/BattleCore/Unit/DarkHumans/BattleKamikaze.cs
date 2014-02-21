using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("k")]
	public class BattleKamikaze: Kamikaze {

		#region Constructor

        public BattleKamikaze()
        {
		}

		#endregion Constructor

	};
}
