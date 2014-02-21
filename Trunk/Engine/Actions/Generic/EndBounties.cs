using OrionsBelt.RulesCore.Enum;
using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Quests;

namespace OrionsBelt.Engine.Actions {

    /// <summary>
    /// Vacation Timeout
    /// </summary>
    public class EndBounties : AutoRepeteAction {

        #region Base Implementation

        public override Visibility Visibility {
            get { return Visibility.Public; }
        }

        public EndBounties()
        {
            Interval = 5;
        }

        protected override void ProcessAction(bool forcedEnd)
        {
            Resolve();
        }

        public static void Resolve()
        {
            Console.Write(" - Fetching finished bounties ");
            IList<QuestStorage> rawQuests = Hql.Query<QuestStorage>("select q from SpecializedQuestStorage q where q.Percentage > 99 and q.Completed = false and q.Type = 'CustomPlayerBountyTemplate' ");
            Console.WriteLine("{0} found", rawQuests.Count);

            IList<IQuestData> quests = QuestConversion.ConvertStorageToQuest(rawQuests);
            foreach (IQuestData quest in quests) {
                QuestManager.ProcessCustomBountyQuest(quest);
            }
        }

        #endregion Base Implementation

    };

}
