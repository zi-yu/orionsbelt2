using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has Solar Panel
    /// </summary>
    public class BuildProtolExtractorQuest : HomePlanetFacilityCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 5; }
        }

        public override int TargetLevel {
            get { return 0; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.Bugs; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return ProtolExtractor.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 1; }
        }

        #endregion BaseQuestInfo Implementation
    };

}
