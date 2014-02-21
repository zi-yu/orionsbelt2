using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("kr")]
	public class BattleKrill: Krill {

		#region Constructor

		public BattleKrill() {
			DefenseMoves.Add(StrikeBack.Instance );
		}

		#endregion Constructor
		
	}
}
