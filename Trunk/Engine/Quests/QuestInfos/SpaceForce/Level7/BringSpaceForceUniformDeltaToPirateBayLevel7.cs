using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceUniformDeltaToPirateBayLevel7: SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 22; }
        }

		public override int TargetTransactions {
			get {return 8;}
		}

        protected override int TargetQuestLevel {
            get { return 7; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SpaceForceUniformDelta.Resource, 8);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SpaceForceUniformDelta", 8);

            data.QuestIntProgress.Add("SpaceForceUniformDelta", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 4500);
                dic.Add(Astatine.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

