using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("FriendlyScore")]
	internal class FriendlyScore : BaseScore {

		#region Constructor

		public FriendlyScore( ){}

		public FriendlyScore( IBattleInfo battleInfo ) : base(battleInfo)
			{}

		#endregion Constructor

		#region IFactory Members

		public override object create( object args ) {
			return new FriendlyScore((IBattleInfo) args);
		}

		#endregion IFactory Members
		
	}
}
