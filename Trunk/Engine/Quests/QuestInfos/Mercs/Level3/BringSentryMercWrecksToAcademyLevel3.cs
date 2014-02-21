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
	public class BringSentryMercWrecksToAcademyLevel3 : MercQuest {

        #region Properties

        public override int TargetLevel {
            get { return 7; }
        }

        public override int Bonus {
            get { return 2;  }
        }

		public override int TargetTransactions {
			get {return 9;}
		}

        protected override int TargetQuestLevel {
            get { return 3; }
        }
        
		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(AirVent.Resource, 5);
				yield return new ResourceQuantity(ExhaustionSystem.Resource, 4);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("AirVent", 5);
			data.QuestIntConfig.Add("ExhaustionSystem", 4);

			data.QuestIntProgress.Add("AirVent", 0);
			data.QuestIntProgress.Add("ExhaustionSystem", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Argon.Resource, 3500);
                return dic;
            }
        }

        #endregion Public
	};

}
