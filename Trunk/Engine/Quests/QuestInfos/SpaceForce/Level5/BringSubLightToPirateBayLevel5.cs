using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSubLightToPirateBayLevel5 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 14; }
        }

		public override int TargetTransactions {
			get {return 5;}
		}

        protected override int TargetQuestLevel {
            get { return 5; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SubLightEngines.Resource, 5);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SubLightEngines", 5);
            data.QuestIntProgress.Add("SubLightEngines", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 4500);
                dic.Add(Prismal.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

