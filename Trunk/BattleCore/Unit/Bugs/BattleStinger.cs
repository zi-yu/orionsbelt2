using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("sg")]
	public class BattleStinger: Stinger {

		#region Constructor

        public BattleStinger()
        {
            PosAttackMoves.Add(Replicator.Instance);
            bonus[OrionsBelt.RulesCore.Enum.UnitCategory.Light.ToString()] = new AttackBonus(1000);
		}

		#endregion Constructor

	};
}
