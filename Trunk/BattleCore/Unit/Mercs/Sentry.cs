using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("st")]
	public class SentryBattle : Sentry {

		public SentryBattle() {
			PosAttackMoves.Add(RemoveAbilityAttack.Instance);
		}
    };
}
