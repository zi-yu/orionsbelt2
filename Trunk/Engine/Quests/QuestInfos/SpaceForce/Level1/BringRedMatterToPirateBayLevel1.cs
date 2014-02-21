using System;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringRedMatterToPirateBayLevel1 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 3; }
        }

		public override int TargetTransactions {
			get {return 2;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(RedMatter.Resource, 2);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("RedMatter", 2);

            data.QuestIntProgress.Add("RedMatter", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Prismal.Resource, 2500);
                return dic;
            }
        }

		#endregion Private
	};

}

