using System;
using System.Collections.Generic;
using System.Text;
using DesignPatterns;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using System.Web;
using System.Collections.Specialized;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic.Messages;

namespace OrionsBelt.Engine.Quests {

    /// <summary>
    /// Handles Quests
    /// </summary>
    public static class QuestManager {

        #region Factories

        private static FactoryContainer factories = new FactoryContainer(typeof(BaseQuestInfo));

        public static IQuestInfo GetQuestType(string name)
        {
            return (IQuestInfo)factories.create(name);
        }

        public static IEnumerable<IQuestInfo> GetQuests(IPlayer player)
        {
            foreach (IQuestInfo info in factories.Values) {
                if (info.TargetLevel >= 0 && info.IsAvailable(player)) {
                    yield return info;
                }
            }
        }

        public static List<IQuestInfo> GetQuests(QuestContext context)
        {
            List<IQuestInfo> list = new List<IQuestInfo>();
            foreach (IQuestInfo info in factories.Values) {
                if (info.TargetLevel >= 0 && info.Context == context) {
                    list.Add(info);
                }
            }
            return list;
        }

        public static List<IQuestInfo> GetProgressiveQuests()
        {
            List<IQuestInfo> list = new List<IQuestInfo>();
            foreach (IQuestInfo info in factories.Values) {
                if (info.IsProgressive) {
                    list.Add(info);
                }
            }
            return list;
        }

        #endregion Factories

        #region Static Utils

        public static QuestData CreateEmpty(Type type)
        {
            return CreateEmpty(type, null);
        }

        public static QuestData CreateEmpty(Type type, string name)
        {
            QuestData quest = new QuestData();

            quest.Info = QuestManager.GetQuestType(type.Name);
            quest.IsProgressive = quest.Info.IsProgressive;
            quest.Name = name;
            quest.StartTick = Clock.Instance.Tick;

            return quest;
        }

        public static void AddReward(IQuestData quest, IResourceInfo res, int quantity)
        {
            quest.Reward.Add(res, quantity);
        }

        public static int GetMaxLevel(QuestContext context)
        {
            int max = int.MinValue;

            foreach (IQuestInfo quest in GetQuests(context)) {
                if (quest.TargetLevel > max) {
                    max = quest.TargetLevel;
                }
            }

            return max;
        }

        public static IQuestInfo GetQuest(QuestContext context, int targetLevel)
        {
            foreach (IQuestInfo quest in GetQuests(context)) {
                if (quest.TargetLevel == targetLevel) {
                    return quest;
                }
            }
            throw new EngineException("No quest level {0} found at context {1}", targetLevel, context);
        }

        public static IQuestInfo GetQuest(QuestContext context, IRaceInfo race, int targetLevel)
        {
            foreach (IQuestInfo quest in GetQuests(context)) {
                if (quest.TargetLevel == targetLevel && quest.TargetRace == race) {
                    return quest;
                }
            }
            return null;
        }

        public static IEnumerable<IQuestInfo> GetQuests()
        {
            foreach (IQuestInfo info in factories.Values) {
                if (info.TargetLevel >= 0) {
                    yield return info;
                }
            }
        }

        #endregion Static Utils

        #region Process Quests

        public static void ProcessTradeRoute(Market market, IPlayer player, params IResourceQuantity[] resources)
        { 
            foreach (IQuestData data in player.Quests) {
                ITradeRouteQuest tradeQuest = data.Info as ITradeRouteQuest;
                if (tradeQuest != null) {
                    tradeQuest.Process(market, data, resources);
                }
            }
        }

		public static void ProcessBattle(IBattleInfo battle, IEnumerable<IPlayerOwner> winners, IEnumerable<IPlayerOwner> loosers)
        {
			foreach (PlayerOwner playerOwner in winners) {
				foreach (IQuestData data in playerOwner.Player.Quests) {
                    IBattleQuest battleQuest = data.Info as IBattleQuest;
                    if (battleQuest != null) {
                        battleQuest.Process(data, battle, winners, loosers, true);
                    }
                }
            }
			foreach (PlayerOwner playerOwner in loosers) {
				foreach (IQuestData data in playerOwner.Player.Quests) {
                    IBattleQuest battleQuest = data.Info as IBattleQuest;
                    if (battleQuest != null) {
                        battleQuest.Process(data, battle, winners, loosers, false);
                    }
                }
            }
        }

        public static void ProcessRaid(IPlayer winner, IPlayer looser)
        {
            foreach (IQuestData data in winner.Quests) {
                IRaidQuest raidQuest = data.Info as IRaidQuest;
                if (raidQuest != null) {
                    raidQuest.Process(data, winner, looser);
                }
            }
        }

		public static void ProcessMobs(SectorCoordinate dropBuildingCoordinate, IPlayer player, params IResourceQuantity[] resources) {
			foreach (IQuestData data in player.Quests) {
				IMobsQuest tradeQuest = data.Info as IMobsQuest;
				if (tradeQuest != null) {
					tradeQuest.Process(dropBuildingCoordinate, data, resources);
				}
			}
		}

        #endregion Process Quests

        #region XHTML

        public static void WriteInfoSpecificRewards(System.IO.TextWriter writer, IQuestInfo info, bool includeOrions, bool includeUl)
        {
            if (includeUl) {
                writer.Write("<ul>");
            }
            if (includeOrions && info.OrionsReward != 0) {
                writer.Write("<li>{0} : +{1}</li>", LanguageManager.Instance.Get("Orions"), info.OrionsReward);
            }
            if (includeOrions && info.ScoreReward != 0) {
                writer.Write("<li>{0} : +{1}</li>", LanguageManager.Instance.Get("Score"), info.ScoreReward);
            }
            if (info.ProfessionPoints != null) {
                foreach (KeyValuePair<Profession, int> pair in info.ProfessionPoints) {
                    writer.Write("<li>{0} : +{1}</li>", LanguageManager.Instance.Get(pair.Key.ToString()), pair.Value);
                }
            }
            if (info.IntrinsicRewards != null) {
                foreach (KeyValuePair<IResourceInfo, int> pair in info.IntrinsicRewards) {
                    writer.Write("<li>{0} : +{1}</li>", LanguageManager.Instance.Get(pair.Key.Name), pair.Value);
                }
            }
            if (includeUl) {
                writer.Write("</ul>");
            }
        }

        #endregion XHTML

        #region Create Bounties
        
        public static void CreateCustomBounty(IPlayer source, IPlayer target, int points, int reward)
        {
            IQuestInfo info = QuestManager.GetQuestType("CustomPlayerBountyTemplate");

            NameValueCollection coll = new NameValueCollection();
            coll.Add("TargetId", target.Id.ToString());
            coll.Add("TargetName", target.Name.ToString());
            coll.Add("SourceId", source.Id.ToString());
            coll.Add("SourceName", source.Name);
            coll.Add("Points", points.ToString());
            coll.Add("Reward", reward.ToString());

            IQuestData data = new QuestData();
            data.Info = info;
            info.PrepareDataFromArgs(data, coll);

            data.PrepareStorage();
            data.UpdateStorage();

            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                persistance.StartTransaction();

                persistance.Update(data.Storage);
                RemoveOrions(source.Principal, reward, persistance);
                TransactionManager.CreateBountyTransaction(source.Principal, target, reward, persistance);

                persistance.CommitTransaction();
            }
        }

        private static void RemoveOrions(Principal principal, int orions, IPersistanceSession session)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session)) {
                principal.Credits -= orions;
                persistance.Update(principal);
            }
        }

        public static IQuestData AcceptCustomBounty(IPlayer hunter, IQuestData template)
        {
            IQuestInfo info = QuestManager.GetQuestType("CustomPlayerBounty");
            IQuestData data = info.AddToPlayer(hunter);
            
            data.Info = info;
            data.QuestIntConfig = template.QuestIntConfig;
            data.QuestIntConfig.Add("Count", int.MaxValue);
            data.QuestIntConfig.Add("Template", template.Storage.Id);
            data.QuestStringConfig = template.QuestStringConfig;
            data.Name = template.Storage.Id.ToString();
            data.IsProgressive = true;

            data.PrepareStorage();
            data.UpdateStorage();

            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                persistance.StartTransaction();

                Messenger.Add(new BountyAcceptedMessage(data.QuestIntConfig["TargetId"], hunter.Name), persistance);
                persistance.Update(data.Storage);

                persistance.CommitTransaction();
            }

            return data;
        }

        internal static void ProcessCustomBountyQuest(IQuestData template)
        {
            if (template.Percentage <= 99) {
                return;
            }
            IList<QuestStorage> raw = Hql.Query<QuestStorage>("select quest from SpecializedQuestStorage quest inner join fetch quest.PlayerNHibernate player inner join fetch player.PrincipalNHibernate principal where quest.Name = :id", Hql.Param("id", template.Storage.Id));
            IList<IQuestData> quests = QuestConversion.ConvertStorageToQuest(raw);

            double totalPoints = 0;
            foreach (IQuestData curr in quests) {
                totalPoints += curr.QuestIntProgress["Points"];
            }

            if (totalPoints == 0) {
                totalPoints = template.QuestIntConfig["Points"];
            }

            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {

                persistance.StartTransaction();

                CompleteBountyQuest(template, persistance);

                foreach (IQuestData data in quests) {
                    double dataPoints = data.QuestIntProgress["Points"];
                    double percentage = dataPoints / totalPoints;
                    AddBountyScore(data.Storage.Player, percentage, persistance);
                    AddOrionsReward(data, percentage * GetRealVountyReward(template), template.QuestStringConfig["TargetName"], persistance);
                    CompleteBountyQuest(data, persistance);
                }

                persistance.CommitTransaction();
            }
        }

        private static void AddBountyScore(PlayerStorage playerStorage, double percentage, IPersistanceSession session)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance(session)) {
                playerStorage.BountyRanking += Convert.ToInt32( percentage * 100 );
                persistance.Update(playerStorage);
            }
        }

        private static void CompleteBountyQuest(IQuestData template, IQuestStoragePersistance persistance)
        {
            template.Completed = true;
            template.Percentage = 100;
            template.UpdateStorage();
            persistance.Update(template.Storage);
        }

        private static void AddOrionsReward(IQuestData data, double raw, string targetName, IPersistanceSession session)
        {
            int reward = Convert.ToInt32(raw);
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session)) {
                data.Storage.Player.Principal.Credits += reward;
                persistance.Update(data.Storage.Player.Principal);
            }
            TransactionManager.GiveBountyRewardTransaction(data.Storage.Player.Principal, reward, targetName, session);
            if (reward > 0) {
                Messenger.Add(new BountyRewardWonMessage(data.Storage.Player.Principal.Id, targetName, reward), session);
            } else {
                Messenger.Add(new BountyRewardMissedMessage(data.Storage.Player.Principal.Id, targetName, reward), session);
            }
        }

        public static double GetRealVountyReward(IQuestData data)
        {
            double total = data.QuestIntConfig["Reward"];
            double academyTake = CustomPlayerBounty.AcademyTake;
            academyTake /= 100;
            academyTake = 1 - academyTake;
            return total * academyTake;
        }

        public static void AbandonCustomBounty(IPlayer player, IQuestData template)
        {
            using (IQuestStoragePersistance persistance = Persistance.Instance.GetQuestStoragePersistance()) {
                persistance.StartTransaction();
                persistance.Delete("from SpecializedQuestStorage q where q.Name = '{0}' and q.PlayerNHibernate.Id = {1}", template.Storage.Id, player.Id);
                persistance.CommitTransaction();
            }
        }

        #endregion Create Bounties

    };

}
