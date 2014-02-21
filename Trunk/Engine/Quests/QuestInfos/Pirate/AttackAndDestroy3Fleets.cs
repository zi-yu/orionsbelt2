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
    public class AttackAndDestroy3Fleets : BattleCount {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 0; }
        }

        public override int ScoreReward { 
            get {
                return 3500;
            }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards  {
            get {
                int value = TargetBattleCount * 500;
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, value);
                dic.Add(Radon.Resource, value);
                dic.Add(Prismal.Resource, value);
                dic.Add(Argon.Resource, value);
                dic.Add(Cryptium.Resource, value);
                return dic;
            }
        }

        public override QuestContext Context{
            get {
                return QuestContext.Pirate;
            }
        }

        protected override BattleMode TargetBattleMode {
            get { return BattleMode.Battle; }
        }

        public override int TargetBattleCount {
            get { return 3; }
        }

        public override bool OnlyForWinner {
            get { return true;  }
        }

        public override Dictionary<Profession, int> ProfessionPoints {
            get {
                Dictionary<Profession, int> dic = new Dictionary<Profession, int>();

                dic.Add(Profession.Pirate, 20);

                return dic;
            }
        }

        protected override bool SpecificCheck(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers)
        {
            return !battle.IsBattleInPlanet;
        }

        public override IList<IQuestInfo> Dependencies  {
            get {
                return new IQuestInfo[] { 
                    QuestManager.GetQuestType("FinishABattleQuest"),
                };
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
