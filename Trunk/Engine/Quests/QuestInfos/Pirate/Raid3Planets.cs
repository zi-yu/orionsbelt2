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
    /// Quest that checks if the player has raided X planets
    /// </summary>
    public class Raid3Planets : RaidPlanet {

        #region BaseQuestInfo Implementation

        public override int TargetLevel {
            get { return 1; }
        }

        public override int ScoreReward { 
            get {
                return 5500;
            }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards  {
            get {
                int value = TargetRaidCount * 200;
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

        public override int TargetRaidCount {
            get { return 3; }
        }

        public override Dictionary<Profession, int> ProfessionPoints {
            get {
                Dictionary<Profession, int> dic = new Dictionary<Profession, int>();

                dic.Add(Profession.Pirate, 30);

                return dic;
            }
        }

        #endregion BaseQuestInfo Implementation

    };

}
