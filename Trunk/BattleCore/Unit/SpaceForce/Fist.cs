using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("ft")]
    public class FistBattle : Fist {

        public FistBattle() {
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
