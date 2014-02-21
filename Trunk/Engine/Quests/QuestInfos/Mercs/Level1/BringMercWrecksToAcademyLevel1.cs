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
	public class BringMercWrecksToAcademyLevel1 : MercQuest {

		#region Properties

		public override int TargetLevel {
			get { return 1; }
		}

		public override int Bonus {
			get { return 2; }
		}

		public override int TargetTransactions {
			get { return 10; }
		}

		public override IEnumerable<IResourceQuantity> MustHaveResources {
			get {
				yield return new ResourceQuantity(PlasmaConduit.Resource, 6);
				yield return new ResourceQuantity(ElectricCircuit.Resource, 4);
			}
		}

		#endregion Properties

		#region Private

		protected override void PrepareData(QuestData data) {
			data.QuestIntConfig.Add("PlasmaConduit", 6);
			data.QuestIntConfig.Add("ElectricCircuit", 4);

			data.QuestIntProgress.Add("PlasmaConduit", 0);
			data.QuestIntProgress.Add("ElectricCircuit", 0);
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