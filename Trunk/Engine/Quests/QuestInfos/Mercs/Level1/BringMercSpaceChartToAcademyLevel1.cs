using System;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringMercSpaceChartToAcademyLevel1 : MercQuest {

		#region Properties

		public override int TargetLevel {
			get { return 5; }
		}

		public override int Bonus {
			get { return 7; }
		}

		public override int TargetTransactions {
			get { return 1; }
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
			get { yield return new ResourceQuantity(MercSpaceChart.Resource, 1); }
		}

		public override Dictionary<IResourceInfo, int> IntrinsicRewards {
			get {
				Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
				dic.Add(Sentry.Resource, 50);
                dic.Add(Radon.Resource, 2500);
				return dic;
			}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("MercSpaceChart", 1);
			data.QuestIntProgress.Add("MercSpaceChart", 0);
		}

		#endregion Private
	};

}
