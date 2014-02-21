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
    /// Counts won battles
    /// </summary>
    public class AttackPlayer : BattleCount {

        #region BaseQuestInfo Implementation

        public override bool OnlyForWinner {
            get { return true;  }
        }

        public static void SetTargetPlayer(IQuestData data, IPlayer player)
        {
            data.QuestIntConfig.Add("TargetPlayerId", player.Id);
            data.QuestIntConfig.Add("Level", player.PlanetLevel);
            data.Name = player.Name;
        }

        protected override bool SpecificCheck(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers)
        {
            foreach (IPlayerOwner powner in loosers) {
                IPlayer looser = powner.Player;
                if (looser.Id == data.QuestIntConfig["TargetPlayerId"]) {
                    return true;
                }
            }
            return false;
        }

        public override void PrepareDataFromArgs(IQuestData data, NameValueCollection col)
        {
            if (col == null) {
                return;
            }

            string raw = col["Target"];
            if (string.IsNullOrEmpty(raw)) {
                throw new EngineException("No target player given");
            }
            int id = int.Parse(raw);

            if (id == data.Player.Id) {
                throw new EngineException("Can't have a bounty on the same player");
            }

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                PlayerStorage storage = persistance.Select(id);
                SetTargetPlayer(data, PlayerUtils.LoadPlayer(storage));
            }
        }

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create()
        {
            QuestData quest = QuestManager.CreateEmpty(typeof(AttackPlayer), string.Empty);
            return quest;
        }

        #endregion Static Utils

    };

}
