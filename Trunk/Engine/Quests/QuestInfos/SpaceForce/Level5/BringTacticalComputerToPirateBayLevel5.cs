using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// 
    /// </summary>
    public class BringTacticalComputerToPirateBayLevel5 : SpaceForceQuest {

        #region Properties

        public override int TargetLevel {
            get { return 13; }
        }

		public override int TargetTransactions {
			get {return 5;}
		}

        protected override int TargetQuestLevel {
            get { return 5; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(TacticalComputer.Resource, 5);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
            data.QuestIntConfig.Add("TacticalComputer", 5);

            data.QuestIntProgress.Add("TacticalComputer", 0);
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 4500);
                dic.Add(Prismal.Resource, 4500);
                return dic;
            }
        }

		#endregion Private
	};

}

