using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
	public class DestroySilverBeard : MercBattleBase {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 24; }
        }

        public override int ScoreReward { 
            get { return 50000; }
        }

		public override Dictionary<IResourceInfo, int> IntrinsicRewards {
			get {
				Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
				dic.Add(Astatine.Resource, 12000);
				dic.Add(Radon.Resource, 12000);
				dic.Add(Prismal.Resource, 12000);
				dic.Add(Argon.Resource, 12000);
				dic.Add(Cryptium.Resource, 12000);
				dic.Add(SilverBeard.Resource,1);
				return dic;
			}
		}

        public override int TargetBattleCount {
            get { return 1; }
        }

		public override string MobName {
			get { return "Silver Beard";}
		}

        #endregion BaseQuestInfo Implementation

    };

}
