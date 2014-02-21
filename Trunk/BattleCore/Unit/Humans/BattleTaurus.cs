using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("t")]
	public class BattleTaurus: Taurus {

		#region Constructor

		public BattleTaurus() {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

		#endregion Constructor
	}
}
