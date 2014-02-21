using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has Darkness Hall level 2
    /// </summary>
    public class BuildDarknessHallQuest : HomePlanetFacilityCheck
    {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 5; }
        }

        public override int TargetLevel {
            get { return 1; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.DarkHumans; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return DarknessHall.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 2; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("BuildDevotionSanctuaryQuest"),
                    QuestManager.GetQuestType("BuildTitaniumExtractorQuest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
