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
    /// Quest that checks if the player has an extractor
    /// </summary>
    public class OwnExtractorLevel5 : ExtractorCheck {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 9; }
        }

        protected override int TargetExtractorLevel {
            get { return 5; }
        }

        public override IList<IQuestInfo> Dependencies {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("Colonize1HotLevel9Quest")
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
