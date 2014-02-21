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
    /// Quest that checks if the player has Command Center level 2
    /// </summary>
    public class BuildCommandCenterQuest : HomePlanetFacilityCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 5; }
        }

        public override int TargetLevel {
            get { return 1; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.LightHumans; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return CommandCenter.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 2; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("BuildSolarPanelQuest"),
                    QuestManager.GetQuestType("BuildSeriumExtractorQuest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
