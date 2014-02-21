using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
	public class AttackAndDestroy3DarkMercFleets : MercBattleBase {

		#region BaseQuestInfo Implementation

		public override int TargetLevel {
			get { return 30; }
		}

		public override int ScoreReward {
			get { return 25000; }
		}

		public override string MobName {
			get { return "Dark Mercs"; }
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 8000);
                dic.Add(Radon.Resource, 8000);
                dic.Add(Prismal.Resource, 8000);
                dic.Add(Argon.Resource, 8000);
                dic.Add(Cryptium.Resource, 8000);
                return dic;
            }
        }

		#endregion BaseQuestInfo Implementation

    };

}
