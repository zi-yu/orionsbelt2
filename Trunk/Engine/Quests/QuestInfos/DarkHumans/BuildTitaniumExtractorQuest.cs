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
    /// Quest that checks if the player has Serium Extractor
    /// </summary>
    public class BuildTitaniumExtractorQuest : HomePlanetFacilityCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 5; }
        }

        public override int TargetLevel {
            get { return 0; }
        }

        public override RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.PMQuestAux; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.DarkHumans; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return TitaniumExtractor.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 1; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
