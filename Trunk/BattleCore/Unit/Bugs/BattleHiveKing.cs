using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("hk")]
	public class BattleHiveKing: HiveKing {

		#region Constructor

        public BattleHiveKing()
        {
            PosAttackMoves.Add(InfestationAttack.Instance);
            PosAttackMoves.Add(RemoveAbilityAttack.Instance);
		}

		#endregion Constructor

	};
}
