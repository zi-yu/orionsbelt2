using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player is on a particular level
    /// </summary>
    [NoAutoRegister]
    public abstract class PlayerPlanetLevelCheck : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.PMQuest; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected abstract int TargetPlayerLevel { get; }

        public override int ScoreReward {
            get { return TargetPlayerLevel * 1000; }
        }

        public override Dictionary<OrionsBelt.RulesCore.Enum.Profession, int> ProfessionPoints {
            get {
                Dictionary<Profession, int> points = new Dictionary<Profession, int>();
                points.Add(Profession.Colonizer, TargetPlayerLevel * 10);
                return points;
            }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            if (player.PlanetLevel >= TargetPlayerLevel) {
                return Result.Success;
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
