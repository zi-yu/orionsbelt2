using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringContainersToPirateBayLevel7 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 20; }
        }

		public override int TargetTransactions {
			get {return 9;}
		}

        protected override int TargetQuestLevel {
            get { return 7; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(PositronContainer.Resource, 5);
                yield return new ResourceQuantity(AntiMatterContainer.Resource, 4);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("PositronContainer", 5);
            data.QuestIntConfig.Add("AntiMatterContainer", 4);

            data.QuestIntProgress.Add("PositronContainer", 0);
            data.QuestIntProgress.Add("AntiMatterContainer", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 5500);
                dic.Add(Prismal.Resource, 5500);
                return dic;
            }
        }

		#endregion Private
	};

}

