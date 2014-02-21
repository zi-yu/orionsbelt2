using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("tt")]
	public class TitanBattle : Titan {

		public TitanBattle() {
            DefenseMoves.Add(StrikeBack.Instance);
		}

    };
}
