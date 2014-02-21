using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("f")]
	public class BattleFenix: Fenix {

		#region Constructor

		public BattleFenix() {
			PosAttackMoves.Add(Rebound.Instance );
		}

		#endregion Constructor
		
	}
}
