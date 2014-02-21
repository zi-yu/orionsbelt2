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
    public class BringSpaceCriminalListAlphaToPirateBayLevel1 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 5; }
        }

		public override int TargetTransactions {
			get {return 1;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(CriminalListAlpha.Resource, 1);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("CriminalListAlpha", 1);

            data.QuestIntProgress.Add("CriminalListAlpha", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Cryptium.Resource, 2500);
                return dic;
            }
        }

		#endregion Private
	};

}

