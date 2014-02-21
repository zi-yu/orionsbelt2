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
	public class BringReaperControlHelmetToAcademyLevel5 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get {return 5;}
		}

        public override int TargetLevel {
            get { return 15; }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(ReaperControlHelmet.Resource, 2);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("ReaperControlHelmet", 2);
			data.QuestIntProgress.Add("ReaperControlHelmet", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 4500);
                dic.Add(Cryptium.Resource, 4500);
                return dic;
            }
        }

        #endregion Public
	};

}
