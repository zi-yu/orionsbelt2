using System;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has colonized all private zone planets
    /// </summary>
    public class GetAllPrivateZoneResources : BaseQuestInfo
    {

        #region BaseQuestInfo Implementation

        public override int OrionsReward {
            get { return 50; }
        }

        public override int TargetLevel {
            get { return 0; }
        }

        public override bool IsProgressive
        {
            get { return false; }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance())
            {
                long count = persistance.ExecuteScalar(
                    "select count(e) from SpecializedSectorStorage e where e.SystemX=0 and e.Type='ResourceSector' and e.OwnerNHibernate.Id={0}",
                    player.Id);

                if(count == 0)
                {
                    return Result.Success;
                }
            }


            return Result.Fail;
        }

        public override QuestContext Context
        {
            get { return QuestContext.Merchant; }
        }

        public override IRaceInfo TargetRace
        {
            get { return null; }
        }

        #endregion BaseQuestInfo Implementation

    };

}
