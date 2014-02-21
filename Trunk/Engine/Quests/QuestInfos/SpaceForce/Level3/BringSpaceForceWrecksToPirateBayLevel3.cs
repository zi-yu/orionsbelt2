using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
    public class BringSpaceForceWrecksToPirateBayLevel3 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 7; }
        }

		public override int TargetTransactions {
			get {return 7;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(MystPropulsionSystem.Resource, 4);
                yield return new ResourceQuantity(MystTargetingSystem.Resource, 3);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("MystPropulsionSystem", 4);
            data.QuestIntConfig.Add("MystTargetingSystem", 3);

            data.QuestIntProgress.Add("MystPropulsionSystem", 0);
            data.QuestIntProgress.Add("MystTargetingSystem", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 3500);
                return dic;
            }
        }

		#endregion Private
	};

}

