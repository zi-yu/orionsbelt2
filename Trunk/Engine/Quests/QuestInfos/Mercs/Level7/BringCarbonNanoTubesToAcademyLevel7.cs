using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringCarbonNanoTubesToAcademyLevel7 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get { return 7; }
		}

        public override int TargetLevel {
            get { return 21; }
        }

		public override int TargetTransactions {
			get {return 3;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(CarbonNanoTube.Resource, 3);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("CarbonNanoTube", 3);
			data.QuestIntProgress.Add("CarbonNanoTube", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 5500);
                dic.Add(Cryptium.Resource, 5500);
                return dic;
            }
        }

        #endregion Public
	};

}
