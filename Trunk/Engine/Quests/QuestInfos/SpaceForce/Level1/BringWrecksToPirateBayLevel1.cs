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
    public class BringWrecksToPirateBayLevel1 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 1; }
        }

		public override int TargetTransactions {
			get {return 8;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(JumperReactor.Resource, 4);
                yield return new ResourceQuantity(JumperStabilizers.Resource, 4);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("JumperReactor", 4);
            data.QuestIntConfig.Add("JumperStabilizers", 4);

            data.QuestIntProgress.Add("JumperReactor", 0);
            data.QuestIntProgress.Add("JumperStabilizers", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Radon.Resource, 2500);
                return dic;
            }
        }

		#endregion Private
	};

}

