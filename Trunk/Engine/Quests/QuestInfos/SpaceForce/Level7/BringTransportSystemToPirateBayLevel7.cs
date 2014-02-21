using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringTransportSystemToPirateBayLevel7 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 19; }
        }

		public override int TargetTransactions {
			get {return 4;}
		}

        protected override int TargetQuestLevel {
            get { return 7; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(TransportSystem.Resource, 4);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("TransportSystem", 4);

            data.QuestIntProgress.Add("TransportSystem", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 5500);
                dic.Add(Prismal.Resource, 5500);
                return dic;
            }
        }

		#endregion Private
	};

}

