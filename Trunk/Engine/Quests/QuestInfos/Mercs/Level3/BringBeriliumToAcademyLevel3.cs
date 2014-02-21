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
	public class BringBeriliumToAcademyLevel3 : MercQuest {

        #region Properties

        public override int TargetLevel {
            get { return 9; }
        }

        public override int Bonus {
            get { return 5;  }
        }

		public override int TargetTransactions {
			get {return 3;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(Berilium.Resource, 3);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("Berilium", 3);
			data.QuestIntProgress.Add("Berilium", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 3500);
                return dic;
            }
        }

        #endregion Public
	};

}
