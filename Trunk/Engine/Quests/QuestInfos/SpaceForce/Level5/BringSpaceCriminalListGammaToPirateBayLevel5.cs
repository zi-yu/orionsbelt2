using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceCriminalListGammaToPirateBayLevel5 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 17; }
        }

		public override int TargetTransactions {
			get {return 1;}
		}

        protected override int TargetQuestLevel {
            get { return 5; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CriminalListGamma.Resource, 1);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CriminalListGamma", 1);

            data.QuestIntProgress.Add("CriminalListGamma", 0);
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

