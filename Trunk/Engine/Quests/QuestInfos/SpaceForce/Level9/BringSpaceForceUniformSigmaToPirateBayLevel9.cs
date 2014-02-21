using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceUniformSigmaToPirateBayLevel9 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 28; }
        }

		public override int TargetTransactions {
			get {return 6;}
		}

        protected override int TargetQuestLevel {
            get { return 9; }
        }

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SpaceForceUniformSigma.Resource, 6);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SpaceForceUniformSigma", 6);
            data.QuestIntProgress.Add("SpaceForceUniformSigma", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 7000);
                dic.Add(Argon.Resource, 7000);
                dic.Add(Cryptium.Resource, 7000);
                return dic;
            }
        }

		#endregion Private
	};

}

