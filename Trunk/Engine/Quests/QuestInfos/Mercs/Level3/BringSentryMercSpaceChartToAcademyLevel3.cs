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
	public class BringSentryMercSpaceChartToAcademyLevel3 : MercQuest {

		#region Properties

		public override int TargetLevel {
			get { return 11; }
		}

		public override int Bonus {
			get { return 7; }
		}

		public override int TargetTransactions {
			get { return 1; }
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
			get { yield return new ResourceQuantity(SentryMercSpaceChart.Resource, 1); }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("SentryMercSpaceChart", 1);
			data.QuestIntProgress.Add("SentryMercSpaceChart", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 3500);
                dic.Add(Reaper.Resource, 50);
                return dic;
            }
        }

        #endregion Public
	};

}
