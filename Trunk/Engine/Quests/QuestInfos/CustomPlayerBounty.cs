using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Specialized;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Counts won battles
    /// </summary>
    public class CustomPlayerBounty : PlayerBounty {

        #region Base Implementation

        protected override void PrepareData(QuestData data)
        {
            base.PrepareData(data);
            data.QuestIntProgress.Add("Points", 0);

        }

        protected override bool SpecificCheck(IQuestData data, IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers)
        {
            foreach (IPlayerOwner owner in loosers) {
                IPlayer player = owner.Player;
                if (player.Id == data.QuestIntConfig["TargetId"]) {
                    int lostPoints = battle.GetPlayer(owner).LoseScore;
                    data.QuestIntProgress["Points"] += lostPoints;
                    data.QuestIntProgress["LastPoints"] = lostPoints;
                    return true;
                }
            }
            return false;
        }

        protected override void ExtraCompleteLogic(IQuestData data)
        {
            // do nothing
        }

        protected override void OnBattleIncremented(IQuestData data)
        {
            base.OnBattleIncremented(data);
            int templateId = data.QuestIntConfig["Template"];

            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                QuestStorage storage = persistance.Select(templateId);
                IQuestData template = QuestConversion.ConvertStorageToQuest(storage);
                template.QuestIntProgress["TotalPoints"] += data.QuestIntProgress["LastPoints"];
                template.Percentage = Convert.ToDouble(template.QuestIntProgress["TotalPoints"]) / Convert.ToDouble(template.QuestIntConfig["Points"]) * 100;
                if (template.Percentage > 100) {
                    template.Percentage = 100;
                }
                template.UpdateStorage();
                persistance.Update(template.Storage);
            }
        }

        public override int GetDataScore(IQuestData data)
        {
            return data.QuestIntConfig["Reward"] / 10;
        }

        public override bool IsExclusive {
            get { return false; }
        }

        #endregion Base Implementation

        #region Static

        public static int AcademyTake {
            get { return 7; }
        }

        #endregion Static

    };

}
