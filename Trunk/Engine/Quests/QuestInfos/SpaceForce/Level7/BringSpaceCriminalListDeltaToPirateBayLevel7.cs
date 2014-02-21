using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceCriminalListDeltaToPirateBayLevel7 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 23; }
        }

		public override int TargetTransactions {
			get {return 1;}
		}

        protected override int TargetQuestLevel {
            get { return 7; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CriminalListDelta.Resource, 1);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CriminalListDelta", 1);

            data.QuestIntProgress.Add("CriminalListDelta", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 4500);
                dic.Add(Radon.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

