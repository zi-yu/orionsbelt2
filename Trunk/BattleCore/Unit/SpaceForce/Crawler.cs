using OrionsBelt.BattleCore;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("cr")]
    public class CrawlerBattle : Crawler {

        public CrawlerBattle() {
			PosAttackMoves.Add(InfestationAttack.Instance);
            PosAttackMoves.Add(ParalyseAttack.Instance);
            bonus[OrionsBelt.RulesCore.Enum.UnitCategory.Medium.ToString()] = new AttackBonus(2000);
        }

    };
}
