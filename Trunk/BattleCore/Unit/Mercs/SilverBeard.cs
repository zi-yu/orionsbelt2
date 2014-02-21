using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("sb")]
	public class SilverBeardBattle : SilverBeard {

		public SilverBeardBattle() {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
