using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has Unit Yard
    /// </summary>
    public class BuildDominationYardQuest : HomePlanetFacilityCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 15; }
        }

        public override int TargetLevel {
            get { return 2; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.DarkHumans; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return DominationYard.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 1; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("BuildDarknessHallQuest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
