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
    /// Quest that checks if the player has a specified number of hot planets
    /// </summary>
    [NoAutoRegister]
    public abstract class HotPlanetsQuest : BaseQuestInfo {

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

        public override int OrionsReward {
            get { return 0; }
        }

        public override int ScoreReward {
            get { return ((TargetPlanetsLevel * TargetPlanetsLevel) + TargetNumberOfPlanets) * 40; }
        }

        public override Dictionary<OrionsBelt.RulesCore.Enum.Profession, int> ProfessionPoints {
            get {
                Dictionary<Profession, int> points = new Dictionary<Profession, int>();
                points.Add(Profession.Colonizer, Convert.ToInt32(Math.Floor(((TargetPlanetsLevel * TargetPlanetsLevel) + TargetNumberOfPlanets) * 1.15)));
                return points;
            }
        }

        protected abstract int TargetNumberOfPlanets {
            get;
        }

        protected abstract int TargetPlanetsLevel {
            get;
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            int sum = 0;

            foreach (IPlanet planet in player.Planets) {
                if (planet.Info.HotZone && planet.Level == TargetPlanetsLevel) {
                    ++sum;
                }
            }

            if (sum >= TargetNumberOfPlanets) {
                return Result.Success;
            }
            
            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
