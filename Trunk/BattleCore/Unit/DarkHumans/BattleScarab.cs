using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("sc")]
	public class BattleScarab: Scarab {

		#region Constructor

        public BattleScarab()
        {
		}

		#endregion Constructor

	};
}
