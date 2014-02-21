using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("TournamentScore")]
	internal class TournamentScore: BaseScore {
		
		#region Constructor
		
		public TournamentScore(){}

		public TournamentScore( IBattleInfo battleInfo ) : base(battleInfo)
			{}

		#endregion Constructor

		#region IFactory Members

		public override object create( object args ) {
			return new TournamentScore((IBattleInfo) args);
		}

		#endregion IFactory Members
	}
}
