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
	public class BringSentryReactorToAcademyLevel3 : MercQuest {

        #region Properties

        public override int TargetLevel {
            get { return 8; }
        }

        public override int Bonus {
            get { return 5;  }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(SentryReactor.Resource, 2);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SentryReactor", 2);
            data.QuestIntProgress.Add("SentryReactor", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 3500);
                return dic;
            }
        }

        #endregion Public
	};

}
