using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceUniformGammaToPirateBayLevel5 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 16; }
        }

		public override int TargetTransactions {
			get {return 8;}
		}

        protected override int TargetQuestLevel {
            get { return 5; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SpaceForceUniformGamma.Resource, 8);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SpaceForceUniformGamma", 8);

            data.QuestIntProgress.Add("SpaceForceUniformGamma", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 4500);
                dic.Add(Cryptium.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

