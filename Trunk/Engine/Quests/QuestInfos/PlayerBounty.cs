using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Specialized;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Counts won battles
    /// </summary>
    public class PlayerBounty : AttackPlayer  {

        #region Base Implementation

        public override bool IsExclusive{
            get { return false; }
        }

        public override bool CanAcceptMultiple {
            get { return true;  }
        }

        public override bool IsAvailable(IPlayer player)
        {
            return true;
        }

        protected override void DoComplete(IQuestData data)
        {
            base.DoComplete(data);
            data.Player.Score += GetDataScore(data);
            data.Player.BountyRanking += data.QuestIntConfig["Level"] * 10;
            ExtraCompleteLogic(data);
        }

        protected virtual void ExtraCompleteLogic(IQuestData data)
        {
            IPlayer target = PlayerUtils.GetPlayerById(data.QuestIntConfig["TargetPlayerId"]);
            if (target.Score > target.PlanetLevel * 10000) {
                int toRemove = GetDataScore(data) / 2;
                target.Score -= toRemove;
                Messenger.Add(new BountyCollectedOnYouMessage(data.QuestIntConfig["TargetPlayerId"], data.Player.Name, toRemove));
                GameEngine.Persist(target);
            }
        }

        public override int GetDataScore(IQuestData data)
        {
            return GetScoreReward(data.QuestIntConfig["Level"]);
        }

        public override void PrepareDataFromArgs(IQuestData data, NameValueCollection col)
        {
            base.PrepareDataFromArgs(data, col);
            Messenger.Add(new BountyAcceptedMessage(data.QuestIntConfig["TargetPlayerId"], data.Player.Name),true);
        }

        #endregion Base Implementation

        #region Static

        private static int BaseScorePerLevel {
            get { return 232; }
        }

        public static int GetScoreReward(int level)
        {
            return level * level * BaseScorePerLevel;
        }

        #endregion Static

    };

}
