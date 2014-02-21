using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringReaperPropulsionSystemToAcademyLevel5 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get { return 5; }
		}

        public override int TargetLevel {
            get { return 14; }
        }

		public override int TargetTransactions {
			get {return 3;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(ReaperPropulsionSystem.Resource, 3);}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("ReaperPropulsionSystem", 3);
			data.QuestIntProgress.Add("ReaperPropulsionSystem", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 4500);
                dic.Add(Cryptium.Resource, 4500);
                return dic;
            }
        }

        #endregion Public
	};

}
