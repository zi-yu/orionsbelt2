using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringTechMercSpaceChartToAcademyLevel7 : MercQuest {

		#region Properties

		protected override int TargetQuestLevel {
			get { return 7; }
		}

		public override int TargetLevel {
			get { return 23; }
		}

		public override int TargetTransactions {
			get { return 1; }
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
			get { yield return new ResourceQuantity(TechMercSpaceChart.Resource, 1); }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("TechMercSpaceChart", 1);
			data.QuestIntProgress.Add("TechMercSpaceChart", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
               
                dic.Add(Prismal.Resource, 5500);
                dic.Add(Argon.Resource, 5500);
                return dic;
            }
        }

        #endregion Public
	};

}
