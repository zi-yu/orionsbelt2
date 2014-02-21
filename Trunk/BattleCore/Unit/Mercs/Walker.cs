using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("wk")]
	public class WalkerBattle : Walker {

        public WalkerBattle() {
			PosAttackMoves.Add(InfestationAttack.Instance);
            PosAttackMoves.Add(Replicator.Instance);
            bonus[OrionsBelt.RulesCore.Enum.UnitCategory.Heavy.ToString()] = new AttackBonus(2000);
        }

    };
}
