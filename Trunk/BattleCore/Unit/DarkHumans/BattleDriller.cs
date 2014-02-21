using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("d")]
	public class BattleDriller: Driller {

		#region Constructor

        public BattleDriller()
        {
            PosAttackMoves.Add(Triple.Instance);
		}

		#endregion Constructor

	};
}
