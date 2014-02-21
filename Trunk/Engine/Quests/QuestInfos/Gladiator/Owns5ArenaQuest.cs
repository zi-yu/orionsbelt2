using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has colonized oneaditional planet
    /// </summary>
    public class Owns5ArenaQuest : ArenaCountQuest
    {

        #region BaseQuestInfo Implementation

        protected override int TargetNumberOfArenas {
            get { return 5; }
        }

        public override int TargetLevel
        {
            get { return 4; }
        }

        public override IRaceInfo TargetRace
        {
            get
            {
                return RaceInfo.LightHumans;
            }
        }


        public override Dictionary<IResourceInfo, int> IntrinsicRewards
        {
            get
            {
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Samurai.Resource, 500);
                dic.Add(Astatine.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Radon.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Cryptium.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Prismal.Resource, 1000 * TargetNumberOfArenas);
                dic.Add(Argon.Resource, 1000 * TargetNumberOfArenas);
                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
