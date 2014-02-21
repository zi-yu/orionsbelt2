using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Specialized;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Creates a Bounty template
    /// </summary>
    public class CustomPlayerBountyTemplate : BaseQuestInfo {

        #region BaseQuestInfo Implementation

        public override bool IsProgressive {
            get { return true; }
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.BountyHunter; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        public override Dictionary<Profession, int> ProfessionPoints  {
            get {
                Dictionary<Profession, int> dic = new Dictionary<Profession, int>();
                dic.Add(Profession.BountyHunter, 10);
                return dic;
            }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            return Result.Fail;
        }

        public override void PrepareDataFromArgs(IQuestData data, NameValueCollection col)
        {
            base.PrepareDataFromArgs(data, col);
            data.IsTemplate = true;
            data.IsProgressive = true;
            data.Name = col["TargetName"];

            data.QuestStringConfig.Add("TargetName", col["TargetName"]);
            data.QuestStringConfig.Add("SourceName", col["SourceName"]);

            data.QuestIntConfig.Add("SourceId", int.Parse(col["SourceId"]));
            data.QuestIntConfig.Add("TargetId", int.Parse(col["TargetId"]));

            data.QuestIntConfig.Add("Reward", int.Parse(col["Reward"]));
            data.QuestIntConfig.Add("Points", int.Parse(col["Points"]));

            data.QuestIntProgress["TotalPoints"] = 0;
        }

        #endregion BaseQuestInfo Implementation

    };

}
