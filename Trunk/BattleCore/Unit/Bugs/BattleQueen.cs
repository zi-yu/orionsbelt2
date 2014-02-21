using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("q")]
	public class BattleQueen : Queen{
		#region Constructor

		public BattleQueen() {
			DefenseMoves.Add(StrikeBack.Instance);
		}

		#endregion Constructor
	}
}
