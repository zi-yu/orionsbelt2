using System;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
    public class BringEscapePodToPirateBayLevel1 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 2; }
        }

		public override int TargetTransactions {
			get {return 4;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(EscapePod.Resource, 3);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("EscapePod", 4);

            data.QuestIntProgress.Add("EscapePod", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 2500);
                return dic;
            }
        }

		#endregion Private
	};

}

