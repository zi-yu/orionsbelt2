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
    /// Quest that checks if the player has Unit Yard
    /// </summary>
    public class BuildUnitYardQuest : HomePlanetFacilityCheck {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 15; }
        }

        public override int TargetLevel {
            get { return 2; }
        }

        public override IRaceInfo TargetRace {
            get { return RaceInfo.LightHumans; }
        }

        protected override IFacilityInfo TargetFacility {
            get { return UnitYard.Resource; }
        }

        protected override int TargetFacilityLevel {
            get { return 1; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("BuildCommandCenterQuest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
