using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringGreyMatterToPirateBayLevel7 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 21; }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(GreyMatter.Resource, 2);
            }
		}

        protected override int TargetQuestLevel {
            get { return 7; }
        }

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("GreyMatter", 2);
            data.QuestIntProgress.Add("GreyMatter", 0);
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

