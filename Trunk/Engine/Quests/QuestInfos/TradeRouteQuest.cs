using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Base trade routes quest
    /// </summary>
    public class TradeRouteQuest : BaseQuestInfo, ITradeRouteQuest {

        #region BaseQuestInfo Implementation

        public override int ScoreReward  {
            get { return TargetTransactions * 500 * Bonus; }
        }

        public override bool IsProgressive {
            get { return true; }
        }

        public override int TargetLevel {
            get { return -1; }
        }

        public override IRaceInfo TargetRace {
            get { return null; }
        }

        public virtual int Ticks {
            get { return -1; }
        }

        public virtual int TargetTransactions {
            get { return 1; }
        }

        public virtual int TargetResourceLevel {
            get { return 1; }
        }

        public virtual int Bonus {
            get { return 1;  }
        }

        protected virtual int TargetMarketLevel {
            get { return -1; }
        }

        protected override Result DoCanComplete(IQuestData data)
        {
            if (data.QuestIntProgress["Count"] < data.QuestIntConfig["Count"]) {
                return Result.Fail;
            }
            return Result.Success;
        }

        public override OrionsBelt.RulesCore.Enum.QuestContext Context {
            get { return OrionsBelt.RulesCore.Enum.QuestContext.Merchant; }
        }

        protected override void PrepareData(QuestData data)
        {
            data.QuestIntConfig.Add("Count", TargetTransactions);
            data.QuestIntProgress.Add("Count", 0);
            if (Ticks > 0) {
                data.DeadlineTick = Clock.Instance.Tick + Ticks;
            }
        }

        public override Dictionary<Profession, int> ProfessionPoints  {
            get {
                Dictionary<Profession, int> dic = new Dictionary<Profession, int>();
                dic.Add(Profession.Merchant, TargetTransactions * 30);
                return dic;
            }
        }

        public override Dictionary<IResourceInfo, int> IntrinsicRewards  {
            get {
                int value = TargetTransactions * 100 * TargetResourceLevel * Bonus;
                Dictionary<IResourceInfo, int> dic = new Dictionary<IResourceInfo, int>();
                dic.Add(Astatine.Resource, value);
                dic.Add(Radon.Resource, value);
                dic.Add(Prismal.Resource, value);
                dic.Add(Argon.Resource, value);
                dic.Add(Cryptium.Resource, value);
                return dic;
            }
        }

        protected override void DoComplete(IQuestData data)
        {
            base.DoComplete(data);
            OnAbandon(data);
        }

        public override void OnAbandon(IQuestData data)
        {
            foreach (IFleetInfo info in data.Player.Fleets) {
                if (info.Cargo == null) {
                    continue;
                }
                foreach (KeyValuePair<IResourceInfo, int> pair in new Dictionary<IResourceInfo, int>(info.Cargo))  {
                    if (pair.Key.IsTradeRouteSpecific) {
                        info.Cargo.Remove(pair.Key);
                        info.Touch();
                    }
                }
                GameEngine.Persist(info);
            }
        }

        #endregion BaseQuestInfo Implementation

        #region Static Utils

        public static IQuestData Create(string name, int quantity)
        {
            QuestData quest = QuestManager.CreateEmpty(typeof(TradeRouteQuest), name);

            quest.QuestIntConfig.Add("Count", quantity);
            quest.QuestIntProgress.Add("Count", 0);

            return quest;
        }

        #endregion Static Utils

        #region ITradeRouteQuest Members

        public void Process(Market market, IQuestData data, params IResourceQuantity[] resources)
        { 
            if (data.Percentage >= 100) {
                return;
            }

            if (data.DeadlineTick > 0 && Clock.Instance.Tick > data.DeadlineTick) {
                return;
            }

            if (InvalidMarketLevel(market)) {
                return;
            }

            if (MustHaveResources != null && !IsMatch(MustHaveResources, resources)) {
                return;
            }

            if (!HasCorrectResourceLevel(resources)) {
                return;
            }

            Increment(data);
        }

        protected virtual bool InvalidMarketLevel(Market market)
        {
            return TargetMarketLevel > 0 && market.Level != TargetMarketLevel;
        }

        private bool IsMatch(IEnumerable<IResourceQuantity> filter, IResourceQuantity[] resources)
        {
			foreach (IResourceQuantity info in filter) {
                bool found = false;
                foreach (IResourceQuantity res in resources) {
                    if (res.Resource.Name == info.Resource.Name) {
                        found = true;
                        break;
                    }
                }
                if (!found) {
                    return false;
                }
            }
            return true;
        }

        private bool HasCorrectResourceLevel(IResourceQuantity[] resources)
        {
            if (TargetResourceLevel > 0) {
                return true;
            }
            foreach (IResourceQuantity res in resources) {
                if (res.Resource.StartLevel == TargetResourceLevel) {
                    return true;
                }
            }
            return false;
        }

        private static void Increment(IQuestData data)
        {
            ++data.QuestIntProgress["Count"];

            double total = data.QuestIntConfig["Count"];
            double actual = data.QuestIntProgress["Count"];

            data.Percentage = Math.Round(actual / total * 100);
        }

        #endregion ITradeRouteQuest

    };

}
