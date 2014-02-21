using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore;
using DesignPatterns.Attributes;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Quest that checks if the player has a market
    /// </summary>
    [NoAutoRegister]
    public abstract class MarketCheck : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return false; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Merchant; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        protected abstract int Count { get;}

        public override int ScoreReward {
            get {
                return Count * 1000;
            }
        }

        public override Dictionary<Profession, int> ProfessionPoints  {
            get {
                Dictionary<Profession, int> dic = new Dictionary<Profession, int>();
                dic.Add(Profession.Merchant, Count * 10);
                return dic;
            }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            IPlayer player = data.Player;

            int sum = 0;
            foreach (UniverseSpecialSector sector in player.SpecialSectors) {
                if (sector.Type == "Market") {
                    ++sum;
                }
            }

            if (sum >= Count) {
                return Result.Success;
            }

            return Result.Fail;
        }

        #endregion BaseQuestInfo Implementation

    };

}
