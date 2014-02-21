using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
	public class AttackAndDestroy3TechMercFleets : MercBattleBase {

		#region BaseQuestInfo Implementation

		public override int TargetLevel {
			get { return 18; }
		}

		public override int ScoreReward {
			get { return 12000; }
		}

		public override string MobName {
			get { return "Tech Mercs"; }
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 4500);
                dic.Add(Radon.Resource, 4500);
                dic.Add(Prismal.Resource, 4500);
                dic.Add(Argon.Resource, 4500);
                dic.Add(Cryptium.Resource, 4500);
                return dic;
            }
        }

		#endregion BaseQuestInfo Implementation

    };

}
