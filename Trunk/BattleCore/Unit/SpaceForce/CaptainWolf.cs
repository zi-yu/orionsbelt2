using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("cw")]
	public class CaptainWolfBattle : CaptainWolf {

        public CaptainWolfBattle() {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
