using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("b")]
	public class BattleBlackWidow: BlackWidow {

		#region Constructor

		public BattleBlackWidow() {

			PosAttackMoves.Add(InfestationAttack.Instance);
			PosAttackMoves.Add(ParalyseAttack.Instance);
		}

		#endregion Constructor
	}
}
