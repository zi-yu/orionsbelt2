using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceCriminalListBetaToPirateBayLevel3 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 11; }
        }

		public override int TargetTransactions {
			get {return 1;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CriminalListBeta.Resource, 1);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CriminalListBeta", 1);

            data.QuestIntProgress.Add("CriminalListBeta", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 3500);
                return dic;
            }
        }

		#endregion Private
	};

}

