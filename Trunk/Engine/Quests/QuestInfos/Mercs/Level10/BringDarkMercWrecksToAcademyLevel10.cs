using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that asks the player to performa a simple trade route
    /// </summary>
	public class BringDarkMercWrecksToAcademyLevel10 : MercQuest {

        #region Properties

		protected override int TargetQuestLevel {
			get {return 10;}
		}

        public override int TargetLevel {
            get { return 31; }
        }

		public override int TargetTransactions {
			get {return 8;}
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
            get {
				yield return new ResourceQuantity(WalkerCore.Resource, 2);
				yield return new ResourceQuantity(TitanControlHelmet.Resource, 2);
				yield return new ResourceQuantity(TitanTargetingSystem.Resource, 2);
				yield return new ResourceQuantity(TitanUnitronCannon.Resource, 2);
            }
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("WalkerCore", 2);
			data.QuestIntConfig.Add("TitanControlHelmet", 2);
			data.QuestIntConfig.Add("TitanTargetingSystem", 2);
			data.QuestIntConfig.Add("TitanUnitronCannon", 2);

			data.QuestIntProgress.Add("WalkerCore", 0);
			data.QuestIntProgress.Add("TitanControlHelmet", 0);
			data.QuestIntProgress.Add("TitanTargetingSystem", 0);
			data.QuestIntProgress.Add("TitanUnitronCannon", 0);
		}

		#endregion Private

        #region Public

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 15000);
                dic.Add(Radon.Resource, 15000);
                dic.Add(Prismal.Resource, 15000);
                dic.Add(Argon.Resource, 15000);
                dic.Add(Cryptium.Resource, 15000);
                return dic;
            }
        }

        #endregion Public
	};

}
