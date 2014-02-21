using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Specialized;
using OrionsBelt.Engine.Common;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Counts raids
    /// </summary>
    public class RaidPlanet : BaseQuestInfo, IBattleQuest, IRaidQuest {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return true; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            if (data.QuestIntProgress["Raids"] < data.QuestIntConfig["Raids"]) {
                return Result.Fail;
            }
            return Result.Success;
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Pirate; }
        }

        protected override void PrepareData(QuestData data)
        {
            data.QuestIntConfig.Add("Raids", TargetRaidCount);
            data.QuestIntProgress.Add("Raids", 0);
        }

        public virtual int TargetRaidCount {
            get { return 1; }
        }


        #endregion BaseQuestInfo Implementation

        #region IBattleQuest Members

        public void Process(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers, bool won)
        {
            if (battle != null && battle.BattleMode != BattleMode.Battle) {
                return;
            }

            if(battle.IsBattleInPlanet && battle.IsPlanetPillage && won) {
                Increment(data);
            }
        }

        #endregion

        #region Utils

        private static void Increment(IQuestData data)
        {
            if (data.Percentage >= 100) {
                return;
            }

            ++data.QuestIntProgress["Raids"];

            double total = data.QuestIntConfig["Raids"];
            double actual = data.QuestIntProgress["Raids"];

            data.Percentage = Math.Round(actual / total * 100);
        }

        #endregion Utils

        #region IRaidQuest Members

        public void Process(IQuestData data, IPlayer winner, IPlayer looser)
        {
            Increment(data);
        }

        #endregion
    };

}
