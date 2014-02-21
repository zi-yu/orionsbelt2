using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringBlueMatterContainerToPirateBayLevel9 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 27; }
        }

		public override int TargetTransactions {
			get {return 7;}
		}

        protected override int TargetQuestLevel {
            get { return 9; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
                yield return new ResourceQuantity(BlueMatter.Resource, 2);
                yield return new ResourceQuantity(BlueMatterContainer.Resource, 5);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("BlueMatterContainer", 5);
            data.QuestIntConfig.Add("BlueMatter", 2);

            data.QuestIntProgress.Add("BlueMatterContainer", 0);
            data.QuestIntProgress.Add("BlueMatter", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 7000);
                dic.Add(Prismal.Resource, 7000);
                dic.Add(Argon.Resource, 7000);
                return dic;
            }
        }

		#endregion Private
	};

}

