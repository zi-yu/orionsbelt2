using System;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringSpaceForceUniformAlphaToPirateBayLevel1 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 4; }
        }

		public override int TargetTransactions {
			get {return 10;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(SpaceForceUniformAlpha.Resource, 10);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("SpaceForceUniformAlpha", 10);

            data.QuestIntProgress.Add("SpaceForceUniformAlpha", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 2500);
                return dic;
            }
        }

		#endregion Private
	};

}

