using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("m")]
	public class BattleMaggot: Maggot {

		#region Constructor

		public BattleMaggot()
        {
            PosAttackMoves.Add(BombAttack.Instance);
		}

		#endregion Constructor

	};
}
