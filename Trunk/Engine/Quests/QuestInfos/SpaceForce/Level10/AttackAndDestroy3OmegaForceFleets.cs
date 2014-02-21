using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using System.Collections.Generic;
namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
    public class AttackAndDestroy3OmegaForceFleets : SpaceForceBattleBase {

		#region BaseQuestInfo Implementation

		public override int TargetLevel {
			get { return 30; }
		}

		public override int ScoreReward {
			get { return 20000; }
		}

		public override string MobName {
			get { return "Omega Force"; }
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
