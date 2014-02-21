using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringCommunicationsArrayToPirateBayLevel5 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 15; }
        }

		public override int TargetTransactions {
			get {return 5;}
		}

        protected override int TargetQuestLevel {
            get { return 5; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CommunicationsArray.Resource, 5);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CommunicationsArray", 5);

            data.QuestIntProgress.Add("CommunicationsArray", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 4500);
                dic.Add(Cryptium.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

