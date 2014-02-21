using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has a specified number of planets
    /// </summary>
    [NoAutoRegister]
    public abstract class ArenaCountQuest : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Gladiator; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected abstract int TargetNumberOfArenas {
            get;
        }

        public override Dictionary<Profession, int> ProfessionPoints
        {
            get
            {
                Dictionary<Profession, int> points = new Dictionary<Profession, int>();
                points.Add(Profession.Gladiator, 10 * TargetNumberOfArenas);
                return points;
            }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards
        {
            get
            {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Radon.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Cryptium.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Prismal.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Argon.Resource, 1000 * TargetNumberOfArenas);
                return dic;
            }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            object count = Hql.ExecuteScalar("select count(b) from SpecializedArenaStorage b where b.OwnerNHibernate.Id = :id",
                                           Hql.Param("id", player.Id));

            if (count != null && (long)count >= TargetNumberOfArenas)
            {
                return Result.Success;
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
