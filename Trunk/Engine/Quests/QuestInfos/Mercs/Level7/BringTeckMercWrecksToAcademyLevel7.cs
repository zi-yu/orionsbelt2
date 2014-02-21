using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringTeckMercWrecksToAcademyLevel7 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get {return 7;}
		}

        public override int TargetLevel {
            get { return 19; }
        }

		public override int TargetTransactions {
			get {return 6;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(ReaperCoreSystem.Resource, 3);
				yield return new ResourceQuantity(ScourgeCoreSystem.Resource, 3);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("ReaperCoreSystem", 3);
			data.QuestIntConfig.Add("ScourgeCoreSystem", 3);

			data.QuestIntProgress.Add("ReaperCoreSystem", 0);
			data.QuestIntProgress.Add("ScourgeCoreSystem", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 5500);
                dic.Add(Radon.Resource, 5500);
                return dic;
            }
        }

        #endregion Public
	};

}
