using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[DesignPatterns.Attributes.FactoryKey("re")]
	public class ReaperBattle : Reaper {

		public ReaperBattle() {
			PosAttackMoves.Add(Triple.Instance);
		}

    };
}
