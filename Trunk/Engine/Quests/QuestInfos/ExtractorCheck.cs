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
    /// Quest that checks if the player has an extractor
    /// </summary>
    [NoAutoRegister]
    public abstract class ExtractorCheck : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.PMQuest; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected abstract int TargetExtractorLevel { get; }

        public override int ScoreReward {
            get { return TargetExtractorLevel * 1000; }
        }

        public override Dictionary<OrionsBelt.RulesCore.Enum.Profession, int> ProfessionPoints {
            get {
                Dictionary<Profession, int> points = new Dictionary<Profession, int>();
                points.Add(Profession.Colonizer, TargetExtractorLevel * 10);
                return points;
            }
        }

        public static IResourceInfo ExtractorResource = RulesUtils.GetFacility("Extractor");

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;
            foreach (IPlanet planet in player.Planets) {
                if (!planet.Info.HotZone) {
                    continue;
                }
                if (planet.HasResourceLevel(ExtractorResource, TargetExtractorLevel)) {
                    return Result.Success;
                }   
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
