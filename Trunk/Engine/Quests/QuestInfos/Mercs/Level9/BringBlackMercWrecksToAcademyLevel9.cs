using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringBlackMercWrecksToAcademyLevel9 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get {return 9;}
		}

        public override int TargetLevel {
            get { return 26; }
        }

		public override int TargetTransactions {
			get {return 6;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(ScourgeControlPanel.Resource, 2);
				yield return new ResourceQuantity(WalkerGiroBalancer.Resource, 2);
				yield return new ResourceQuantity(ScourgePropulsionSystem.Resource, 2);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("ScourgeControlPanel", 2);
			data.QuestIntConfig.Add("WalkerGiroBalancer", 2);
			data.QuestIntConfig.Add("ScourgePropulsionSystem", 2);

			data.QuestIntProgress.Add("ScourgeControlPanel", 0);
			data.QuestIntProgress.Add("WalkerGiroBalancer", 0);
			data.QuestIntProgress.Add("ScourgePropulsionSystem", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 7000);
                dic.Add(Prismal.Resource, 7000);
                dic.Add(Argon.Resource, 7000);
                return dic;
            }
        }

        #endregion Public
	};

}
