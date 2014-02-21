using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("h")]
	public class BattlePretorian: Pretorian {

		#region Constructor

		public BattlePretorian() {
			DefenseMoves.Add(StrikeBack.Instance );
		}

		#endregion Constructor
		
	}
}
