using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceUniformBetaToPirateBayLevel3 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 10; }
        }

		public override int TargetTransactions {
			get {return 10;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SpaceForceUniformBeta.Resource, 10);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SpaceForceUniformBeta", 10);

            data.QuestIntProgress.Add("SpaceForceUniformBeta", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 3500);
                return dic;
            }
        }

		#endregion Private
	};

}

