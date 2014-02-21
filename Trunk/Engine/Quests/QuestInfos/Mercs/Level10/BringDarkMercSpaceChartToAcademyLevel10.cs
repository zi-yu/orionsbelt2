using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringDarkMercSpaceChartToAcademyLevel10 : MercQuest {

		#region Properties

		protected override int TargetQuestLevel {
			get { return 10; }
		}

		public override int TargetLevel {
			get { return 33; }
		}

		public override int TargetTransactions {
			get { return 1; }
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
			get { yield return new ResourceQuantity(DarkMercSpaceChart.Resource, 1); }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("DarkMercSpaceChart", 1);
			data.QuestIntProgress.Add("DarkMercSpaceChart", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 15000);
                dic.Add(Radon.Resource, 15000);
                dic.Add(Prismal.Resource, 15000);
                dic.Add(Argon.Resource, 15000);
                dic.Add(Cryptium.Resource, 15000);
                dic.Add(Titan.Resource, 30);
                return dic;
            }
        }

        #endregion Public
	};

}
