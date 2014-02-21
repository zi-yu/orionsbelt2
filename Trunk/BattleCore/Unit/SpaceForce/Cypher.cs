using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("cp")]
    public class CypherBattle : Cypher {

        public CypherBattle() {
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
