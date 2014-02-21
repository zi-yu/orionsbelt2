using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("bk")]
	public class BattleBlinker : Blinker{
		#region Constructor

		public BattleBlinker() {
			DefenseMoves.Add(StrikeBack.Instance);
		}

		#endregion Constructor
		
	}
}
