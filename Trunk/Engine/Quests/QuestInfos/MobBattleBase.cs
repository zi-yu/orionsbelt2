using System.Collections.Generic;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.UniverseInfo;


namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    [NoAutoRegister]
	public abstract class MobBattleBase : BattleCount {

		#region BaseQuestInfo Implementation

		public override Dictionary<IResourceInfo, int> IntrinsicRewards {
			get {
				Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
				dic.Add(Astatine.Resource, 1000);
				dic.Add(Radon.Resource, 1000);
				dic.Add(Prismal.Resource, 1000);
				dic.Add(Argon.Resource, 1000);
				dic.Add(Cryptium.Resource, 1000);
				return dic;
			}
		}

		public override int TargetBattleCount {
			get {return 3;}
		}

		protected override BattleMode TargetBattleMode {
			get { return BattleMode.Battle; }
		}

		public override bool OnlyForWinner {
			get { return true; }
		}

		public virtual string MobName {
			get { return string.Empty; }
		}

		protected override bool SpecificCheck(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers) {
			foreach (IPlayerOwner owner in loosers) {
				if (!RaceInfo.IsMob(owner.Player.RaceInfo.Race) || !owner.Player.Name.Equals(MobName)) {
					return false;
				}
			}
			return !battle.IsBattleInPlanet;
		}

		#endregion BaseQuestInfo Implementation
	};

}
