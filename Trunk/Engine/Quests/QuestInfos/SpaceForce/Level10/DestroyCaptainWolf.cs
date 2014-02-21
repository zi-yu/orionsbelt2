using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
    public class DestroyCaptainWolf : SpaceForceBattleBase {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 36; }
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
				dic.Add(CaptainWolf.Resource,1);
				return dic;
			}
		}

        public override int TargetBattleCount {
            get { return 1; }
        }

		public override string MobName {
			get { return "Captain Wolf";}
		}

        #endregion BaseQuestInfo Implementation

    };

}
