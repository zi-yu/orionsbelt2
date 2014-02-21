using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Exchanges resources ofr others
    /// </summary>
    public class ResourceExchange : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Merchant; }
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

            foreach (KeyValuePair<string, int> pair in data.QuestIntConfig) {
                IResourceInfo target = RulesUtils.GetResource(pair.Key);
                if (player.GetQuantity(target) < pair.Value) {
                    return Result.Fail;
                }
            }

            return Result.Success;
        }

        protected override void DoComplete(IQuestData data)
        {
            base.DoComplete(data);
            IPlayer player = data.Player;

            foreach (KeyValuePair<string, int> pair in data.QuestIntConfig) {
                IResourceInfo target = RulesUtils.GetResource(pair.Key);
                player.RemoveQuantity(target, pair.Value);
            }
        }

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, IResourceInfo info, int quantity)
        {
            QuestData quest = QuestManager.CreateEmpty(typeof(ResourceExchange), name);

            quest.QuestIntConfig.Add(info.Name, quantity);

            return quest;
        }

        #endregion Static Utils

    };

}
