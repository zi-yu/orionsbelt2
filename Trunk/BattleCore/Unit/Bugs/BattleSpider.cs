using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("sp")]
	public class BattleSpider: Spider {

		#region Constructor

        public BattleSpider()
        {
            DefenseMoves.Add(StrikeBack.Instance);
			PosAttackMoves.Add(ParalyseAttack.Instance);
		}

		#endregion Constructor

	};
}
