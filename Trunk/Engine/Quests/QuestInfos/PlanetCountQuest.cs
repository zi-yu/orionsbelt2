using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using DesignPatterns.Attributes;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has a specified number of planets
    /// </summary>
    [NoAutoRegister]
    public abstract class PlanetCountQuest : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Colonizer; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected abstract int TargetNumberOfPlanets {
            get;
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            if (player.Planets.Count >= TargetNumberOfPlanets) {
                return Result.Success;
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
