using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("bz")]
    public class BattleBozer : Bozer {

		#region Constructor

        public BattleBozer()
        {
            bonus[UnitDisplacement.Air.ToString()] = new AttackBonus(4000);
            DefenseMoves.Add(StrikeBack.Instance);
		}

		#endregion Constructor

	};
}
