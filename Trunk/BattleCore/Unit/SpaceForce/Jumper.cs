using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("jp")]
    public class JumperBattle : Jumper {

        public JumperBattle() {
			PosAttackMoves.Add(RemoveAbilityAttack.Instance);
		}
    };
}
