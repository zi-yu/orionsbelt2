using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
	public class DestroyMetallicBeard : MercBattleBase {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 3000; }
        }

        public override int TargetLevel {
            get { return 34; }
        }

        public override int ScoreReward { 
            get { return 100000; }
        }

		public override Dictionary<IResourceInfo, int> IntrinsicRewards {
			get {
				Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
				dic.Add(Astatine.Resource, 25000);
				dic.Add(Radon.Resource, 25000);
				dic.Add(Prismal.Resource, 25000);
				dic.Add(Argon.Resource, 25000);
				dic.Add(Cryptium.Resource, 25000);
				dic.Add(MetallicBeard.Resource,1);
				return dic;
			}
		}

        public override int TargetBattleCount {
            get { return 1; }
        }

		public override string MobName {
			get { return "Metallic Beard";}
		}

        #endregion BaseQuestInfo Implementation

    };

}
