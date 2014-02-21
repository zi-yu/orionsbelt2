using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringRogueMercWrecksToAcademyLevel5 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get {return 5;}
		}

        public override int TargetLevel {
            get { return 13; }
        }

		public override int TargetTransactions {
			get {return 8;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(NanoProbe.Resource, 5);
				yield return new ResourceQuantity(MedicalKit.Resource, 3);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("NanoProbe", 5);
			data.QuestIntConfig.Add("MedicalKit", 3);

			data.QuestIntProgress.Add("NanoProbe", 0);
			data.QuestIntProgress.Add("MedicalKit", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 4500);
                dic.Add(Radon.Resource, 4500);
                return dic;
            }
        }

        #endregion Public
	};

}
