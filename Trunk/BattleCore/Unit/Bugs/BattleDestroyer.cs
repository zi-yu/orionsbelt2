using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("dy")]
	public class BattleDestroyer: Destroyer {

		#region Constructor

        public BattleDestroyer()
        {
			PosAttackMoves.Add(BombAttack.Instance);
		}

		#endregion Constructor

	};
}
