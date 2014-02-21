using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("hp")]
	public class BattleHiveProtector: HiveProtector {

		#region Constructor

        public BattleHiveProtector()
        {
            DefenseMoves.Add(StrikeBack.Instance);
		}

		#endregion Constructor

	};
}
