using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceWrecksToPirateBayLevel10 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 31; }
        }

		public override int TargetTransactions {
			get {return 6;}
		}

        protected override int TargetQuestLevel {
            get { return 10; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(PositronCannon.Resource, 3);
                yield return new ResourceQuantity(FistTargettingSystem.Resource, 3);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("PositronCannon", 3);
            data.QuestIntConfig.Add("FistTargettingSystem", 3);

            data.QuestIntProgress.Add("PositronCannon", 0);
            data.QuestIntProgress.Add("FistTargettingSystem", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Prismal.Resource, 8000);
                dic.Add(Argon.Resource, 8000);
                dic.Add(Astatine.Resource, 8000);
                dic.Add(Cryptium.Resource, 8000);
                dic.Add(Radon.Resource, 8000);
                return dic;
            }
        }

		#endregion Private
	};

}

