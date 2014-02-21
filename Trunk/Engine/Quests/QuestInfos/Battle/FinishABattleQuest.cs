using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has finished a battle
    /// </summary>
    public class FinishABattleQuest : BattleCount {

        #region BaseQuestInfo Implementation

        public override int OrionsReward
        {
            get { return 150; }
        }

        public override int TargetLevel {
            get { return 0; }
        }

        public override QuestContext Context{
            get {
                return QuestContext.Battle;
            }
        }

        protected override BattleMode TargetBattleMode {
            get { return BattleMode.Battle;  }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards {
            get {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 200);
                return dic;
            }
        }

        public override IList<IQuestInfo> Dependencies  {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("FindPrivateWormHoleQuest"),
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
