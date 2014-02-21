using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has colonized all private zone planets
    /// </summary>
    public class ColonizeAllPrivateZonePlanetsQuest : PlanetCountQuest {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 50; }
        }

        public override int TargetLevel {
            get { return 1; }
        }

        protected override int TargetNumberOfPlanets {
            get { return 5; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] {
                    QuestManager.GetQuestType("ColonizeOnePlanetQuest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
