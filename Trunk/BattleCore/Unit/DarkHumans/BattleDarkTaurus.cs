using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("dt")]
	public class BattleDarkTaurus: DarkTaurus {

		#region Constructor

        public BattleDarkTaurus()
        {
			PosAttackMoves.Add(Rebound.Instance);
			PosAttackMoves.Add(Triple.Instance);
		}

		#endregion Constructor

	};
}
