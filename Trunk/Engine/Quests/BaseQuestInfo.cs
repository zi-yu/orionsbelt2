using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using DesignPatterns;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Common;
using System.Collections.Specialized;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Represents quest type
    /// </summary>
    public abstract class BaseQuestInfo : IQuestInfo, IFactory {

        #region IQuestInfo Members

        public string Name {
            get { return GetType().Name; }
        }

        public abstract bool IsProgressive { 
            get;
        }

        public virtual int OrionsReward {
            get { return 0; }
        }

        public virtual int ScoreReward {
            get { return 0; }
        }

        public virtual Dictionary<IResourceInfo, int> IntrinsicRewards {
            get { return null; }
        }

        public virtual IList<IQuestInfo> Dependencies {
            get { return null;  }
        }

        public virtual Dictionary<Profession, int> ProfessionPoints {
            get { return null; }
        }

        public virtual bool IsExclusive {
            get {
                return IsProgressive &&
                    (
                        Context == QuestContext.Pirate ||
                        Context == QuestContext.BountyHunter ||
                        Context == QuestContext.Merchant
                    );
            }
        }

        public virtual bool CanAcceptMultiple {
            get { return false;  }
        }

		public virtual IEnumerable<IResourceQuantity> MustHaveResources {
			get { return null; }
		}

        #endregion

        #region IQuestInfo Methods

        public virtual bool IsAvailable(IPlayer player)
        {
            if (TargetRace != null && TargetRace != player.RaceInfo) {
                return false;
            }
            
            if (Dependencies != null ) {
                foreach (IQuestInfo dep in Dependencies) {
                    int playerLevel = player.GetQuestContextLevel(dep.Context);
                    if (playerLevel < dep.TargetLevel + 1) {
                        return false;
                    }
                }
            }

            return player.ChekQuestLevel(Context, TargetLevel);
        }

        /// <summary>
        /// Checks if the given quest can be completes
        /// </summary>
        /// <param name="quest">The quest</param>
        /// <returns>The result</returns>
        public Result CanComplete(IQuestData quest)
        {
            if (quest != null && quest.Completed) {
                return Result.Fail;
            }
            if (!CanAcceptMultiple && 
                    quest.Player.QuestContextLevel != null && 
                    quest.Player.QuestContextLevel.ContainsKey(Context) && 
                    quest.Player.QuestContextLevel[Context] != TargetLevel) {
                return Result.Fail;
            }
            return DoCanComplete(quest);
        }    

        /// <summary>
        /// Completes the quest
        /// </summary>
        /// <param name="quest">The quest</param>
        public void Complete(IQuestData quest)
        {
            DoComplete(quest);
        }

        public virtual IQuestData AddToPlayer(IPlayer player)
        {
            QuestData data = QuestManager.CreateEmpty(this.GetType());
            PrepareData(data);
            player.AddQuest(data);
            return data;
        }

        public virtual void PrepareDataFromArgs(IQuestData data, NameValueCollection col)
        {
        }

        public virtual int GetDataScore(IQuestData data)
        {
            return 0;
        }

        public virtual void OnAbandon(IQuestData data)
        { 
        }

        #endregion IQuestInfo Methods

        #region To Implement

        protected abstract Result DoCanComplete(IQuestData data);

        protected virtual void DoComplete(IQuestData data)
        {
            ResolveReward(data);
            data.Completed = true;
            data.Player.SetQuestContextLevel(Context, TargetLevel + 1);
        }

        public abstract QuestContext Context { get;}

        public abstract int TargetLevel { get;}

        public abstract IRaceInfo TargetRace { get;}

        private void ResolveReward(IQuestData data)
        {
            foreach (KeyValuePair<IResourceInfo, int> pair in data.Reward){
                data.Player.AddQuantity(pair.Key, pair.Value);
            }
            if( IntrinsicRewards != null ) {
                foreach (KeyValuePair<IResourceInfo, int> pair in IntrinsicRewards){
                    if( pair.Key.Type == ResourceType.Intrinsic ) {
                        data.Player.AddQuantity(pair.Key, pair.Value);
                    } else if( pair.Key.Type == ResourceType.Unit ) {
                        AddUnitsToHomePlanet(data.Player, pair.Key, pair.Value);
                    }
                }
            }
            if (ProfessionPoints != null) {
                foreach (KeyValuePair<Profession, int> pair in ProfessionPoints) {
                    switch (pair.Key) {
                        case Profession.Colonizer: data.Player.ColonizerRanking += pair.Value; break;
                        case Profession.BountyHunter: data.Player.BountyRanking += pair.Value; break;
                        case Profession.Pirate: data.Player.PirateRanking += pair.Value; break;
                        case Profession.Merchant: data.Player.MerchantRanking += pair.Value; break;
                        case Profession.Gladiator: data.Player.GladiatorRanking += pair.Value; break;
                    }
                }
            }
            if (ScoreReward != 0) {
                data.Player.Score += ScoreReward;
            }
            if (OrionsReward != 0) {
                data.Player.Principal.Credits += OrionsReward;
                TransactionManager.QuestTransaction(Name, null, OrionsReward, data.Player);
            }
        }

        private void AddUnitsToHomePlanet(IPlayer player, IResourceInfo resource, int quantity)
        {
            IFleetInfo fleet = player.GetHomePlanet().DefenseFleet;

            if ((resource.AuctionType & AuctionHouseType.Ultimate) != AuctionHouseType.None && resource.AuctionType != AuctionHouseType.None)
            {
                fleet.AddCargo(resource, quantity);
            }
            else
            {
                fleet.Add(resource as IUnitInfo, quantity);
            }
        }

        protected virtual void PrepareData(QuestData data)
        {
        }

        #endregion To Implement

        #region IFactory Members

        object IFactory.create(object args)
        {
            return this;
        }

        #endregion

    };

}
