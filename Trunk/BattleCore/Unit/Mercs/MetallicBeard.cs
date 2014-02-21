using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("mb")]
	public class MetallicBeardBattle : MetallicBeard {

		public MetallicBeardBattle() {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
