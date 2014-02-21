using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.Interfaces;
using System.Collections.Generic;
namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
	public class AttackAndDestroy3RogueMercFleets : MercBattleBase {

		#region BaseQuestInfo Implementation

		public override int TargetLevel {
			get { return 12; }
		}

		public override int ScoreReward {
			get { return 9000; }
		}

		public override string MobName {
			get { return "Rogue Mercs"; }
		}

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 3000);
                dic.Add(Radon.Resource, 3000);
                dic.Add(Prismal.Resource, 3000);
                dic.Add(Argon.Resource, 3000);
                dic.Add(Cryptium.Resource, 3000);
                return dic;
            }
        }

		#endregion BaseQuestInfo Implementation


    };

}
