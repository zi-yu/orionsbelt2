using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringMercSiliciumToAcademyLevel1 : MercQuest {

        #region Properties

        public override int TargetLevel {
            get { return 3; }
        }

        public override int Bonus {
            get { return 5;  }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {yield return new ResourceQuantity(Silicium.Resource, 2);}
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 2500);
                return dic;
            }
        }

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("Silicium", 2);
			data.QuestIntProgress.Add("Silicium", 0);
		}

		#endregion Private
	};

}
