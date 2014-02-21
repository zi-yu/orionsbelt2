using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("mt")]
	public class MystBattle : Myst {

        public MystBattle() {
			PosAttackMoves.Add(Rebound.Instance);
            
		}

    };
}
