using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.BattleCore {

	[FactoryKey("v")]
	public class BattleVector: Vector {

		#region Constructor

        public BattleVector()
        {
            
		}

		#endregion Constructor

	};
}
