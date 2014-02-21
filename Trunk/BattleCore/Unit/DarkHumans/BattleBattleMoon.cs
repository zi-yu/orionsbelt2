using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("bm")]
	public class BattleBattleMoon : BattleMoon{
		#region Constructor

		public BattleBattleMoon() {
            PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(ResetCoolDown.Instance);
			//DefenseMoves.Add(StrikeBack.Instance);
		}

		#endregion Constructor
		
	}
}
