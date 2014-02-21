using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("r")]
	public class BattleRain: Rain {

		/// <summary>
		/// The value of the unit in battle with the bonus
		/// </summary>
		public override int GetFinalUnitValue( IBattlePlayer owner, IBattleStatistics statistics ) {
			if( statistics.HeavyExists(owner) ) {
				return UnitValue + statistics.GetIncrement(owner, statistics.HeavyPercentage(owner));
			}
			return UnitValue;
		}

		#region Constructor

		public BattleRain() {
			bonus[UnitCategory.Heavy.ToString()] = new AttackBonus(1200);
		}

		#endregion Constructor

	}
}
