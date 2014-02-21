using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("so")]
	public class ScourgeBattle : Scourge {

		public ScourgeBattle() {
			PosAttackMoves.Add(Rebound.Instance);
            
		}

    };
}
