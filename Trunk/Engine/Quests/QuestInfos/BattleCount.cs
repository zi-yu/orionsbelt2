using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Counts won battles
    /// </summary>
    public class BattleCount : BaseQuestInfo, IBattleQuest {

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

        protected virtual BattleMode TargetBattleMode {
            get { return BattleMode.Battle;  }
        } 

        protected override Result DoCanComplete(IQuestData data)
        {
            if (data.QuestIntProgress["Count"] < data.QuestIntConfig["Count"]) {
                return Result.Fail;
            }
            return Result.Success;
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Battle; }
        }

        protected override void PrepareData(QuestData data)
        {
            data.QuestIntConfig.Add("Count", TargetBattleCount);
            data.QuestIntProgress.Add("Count", 0);
        }

        public virtual int TargetBattleCount {
            get { return 1; }
        }

        public virtual bool OnlyForWinner {
            get { return false;  }
        }

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, int quantity)
        {
            QuestData quest = QuestManager.CreateEmpty(typeof(BattleCount), name);

            quest.QuestIntConfig.Add("Count", quantity);
            quest.QuestIntProgress.Add("Count", 0);

            return quest;
        }

        #endregion Static Utils

        #region IBattleQuest Members

        public void Process(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers, bool won)
        {
            if (battle != null && battle.BattleMode != TargetBattleMode) {
                return;
            }

            if (data.Percentage >= 100) {
                return;
            }

            if (!SpecificCheck(data, battle, winners, loosers)) {
                return;
            }

            if (!OnlyForWinner) {
                Increment(data);
                return;
            }

            if (OnlyForWinner && IsMatch(data.Player, winners)) {
                Increment(data);
            }
        }

        protected virtual bool SpecificCheck(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers)
        {
            return true;
        }

        private bool IsMatch(IPlayer player, IEnumerable<IPlayerOwner> winners)
        {
            foreach (IPlayerOwner powner in winners) {
                IPlayer winner = powner.Player;
                if (winner.Id == player.Id) {
                    return true;
                }
            }
            return false;
        }

        protected virtual void Increment(IQuestData data)
        {
            ++data.QuestIntProgress["Count"];

            double total = data.QuestIntConfig["Count"];
            double actual = data.QuestIntProgress["Count"];

            data.Percentage = Math.Round(actual / total * 100);
            OnBattleIncremented(data);
        }

        protected virtual void OnBattleIncremented(IQuestData data)
        {
        }

        #endregion

    };

}
