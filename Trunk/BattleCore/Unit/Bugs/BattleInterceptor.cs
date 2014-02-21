using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("it")]
	public class BattleInterceptor: Interceptor {

		#region Constructor

        public BattleInterceptor()
        {
            PosAttackMoves.Add(ParalyseAttack.Instance);
		}

		#endregion Constructor

	};
}
