using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceCriminalListOmegaToPirateBayLevel10 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 35; }
        }

		public override int TargetTransactions {
			get {return 1;}
		}

        protected override int TargetQuestLevel {
            get { return 10; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CriminalListSigma.Resource, 1);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CriminalListSigma", 1);
            data.QuestIntProgress.Add("CriminalListSigma", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 8000);
                dic.Add(Radon.Resource, 8000);
                dic.Add(Astatine.Resource, 8000);
                dic.Add(Argon.Resource, 8000);
                dic.Add(Prismal.Resource, 8000);
                return dic;
            }
        }

		#endregion Private
	};

}

