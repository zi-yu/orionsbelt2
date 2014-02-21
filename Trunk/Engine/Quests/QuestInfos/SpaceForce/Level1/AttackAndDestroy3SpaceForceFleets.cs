namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
    public class AttackAndDestroy3SpaceForceFleets : SpaceForceBattleBase {

		#region BaseQuestInfo Implementation

		public override int TargetLevel {
			get { return 0; }
		}

		public override int ScoreReward {
			get { return 3000; }
		}

		public override string MobName {
			get { return "Alpha Force"; }
		}

		#endregion BaseQuestInfo Implementation

    };

}
