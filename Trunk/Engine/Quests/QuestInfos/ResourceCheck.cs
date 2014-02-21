using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using DesignPatterns.Attributes;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has a resource quantity
    /// </summary>
    public class ResourceCheck : BaseQuestInfo {

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

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;
            IResourceInfo target = RulesUtils.GetResource(data.QuestStringConfig["Resource"]);
            int quantity = data.QuestIntConfig["Quantity"];
            int level = data.QuestIntConfig["Level"];

            int availableQuantity = player.GetQuantity(target);
            if (availableQuantity >= quantity ) {
                return Result.Success;
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, IResourceInfo info, int quantity)
        {
            return Create(name, info, quantity, 1);
        }

        public static IQuestData Create(string name, IResourceInfo info, int quantity, int level)
        {
            QuestData quest = QuestManager.CreateEmpty(typeof(ResourceCheck), name);

            quest.QuestStringConfig.Add("Resource", info.Name);
            quest.QuestIntConfig.Add("Quantity", quantity);
            quest.QuestIntConfig.Add("Level", level);

            return quest;
        }

        #endregion Static Utils

    };

}
