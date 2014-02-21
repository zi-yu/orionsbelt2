using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("cf")]
	public class CommanderFoxBattle : CommanderFox {

        public CommanderFoxBattle() {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
