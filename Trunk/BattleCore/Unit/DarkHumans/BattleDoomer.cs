using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("doo")]
	public class BattleDoomer: Doomer {

		#region Constructor

        public BattleDoomer()
        {
            PosAttackMoves.Add(Rebound.Instance);
		}

		#endregion Constructor

	};
}
