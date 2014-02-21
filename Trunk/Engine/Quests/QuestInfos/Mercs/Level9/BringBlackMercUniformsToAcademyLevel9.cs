using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringBlackMercUniformsToAcademyLevel9 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get { return 9; }
		}

        public override int TargetLevel {
            get { return 28; }
        }

		public override int TargetTransactions {
			get {return 6;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(BlackMercUniform.Resource, 6);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("BlackMercUniform", 6);
            data.QuestIntProgress.Add("BlackMercUniform", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Prismal.Resource, 7000);
                dic.Add(Argon.Resource, 7000);
                dic.Add(Cryptium.Resource, 7000);
                return dic;
            }
        }

        #endregion Public
	};

}
