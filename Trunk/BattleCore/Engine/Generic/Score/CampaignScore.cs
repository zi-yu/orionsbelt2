using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.BattleCore {

	[FactoryKey("CampaignScore")]
	internal class CampaignScore : FriendlyScore {

		#region Constructor

		public CampaignScore(){}

		public CampaignScore(IBattleInfo battleInfo)
			: base(battleInfo)
			{}

		#endregion Constructor

		#region IFactory Members

		public override object create( object args ) {
			return new CampaignScore((IBattleInfo)args);
		}

		#endregion IFactory Members
		
	}
}
