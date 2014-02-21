using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("p")]
	public class BattlePanther: Panther {

		#region Constructor

		public BattlePanther() {
			PosAttackMoves.Add(Rebound.Instance );
		}

		#endregion Constructor
		
	}
}
