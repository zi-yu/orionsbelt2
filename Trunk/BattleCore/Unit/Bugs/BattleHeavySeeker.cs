using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("hr")]
	public class BattleHeavySeeker: HeavySeeker {

		#region Constructor

        public BattleHeavySeeker()
        {
		}

		#endregion Constructor

	};
}
