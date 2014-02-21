using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("ArenaScore")]
	internal class ArenaScore : BaseScore {

		#region Constructor

		public ArenaScore( ){}

		public ArenaScore(IBattleInfo battleInfo)
			: base(battleInfo)
			{}

		#endregion Constructor

		#region IFactory Members

		public override object create( object args ) {
			return new ArenaScore((IBattleInfo) args);
		}

		#endregion IFactory Members
		
	}
}
