using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using System.Threading;
using OrionsBelt.Engine.Actions;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.Engine.Universe;
using OrionsBelt.BattleCore;
using OrionsBelt.WebUserInterface.WebBattle;
using OrionsBeltTests.BattleCoreTests;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class QuestsTests : BaseInterpreterTests {

        #region Persistance Tests

        [Test]
        public void Persistance_Test()
        {
            IResourceInfo res = Gold.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;
            IQuestData quest = ResourceCheck.Create("Get 1000 Gold", res, 1000);
            player.AddQuest(quest);

            GameEngine.Persist(player);

            PlayerStorage playerStorage = player.Storage;
            QuestStorage questStorage = quest.Storage;

            Assert.IsFalse(questStorage.Transient, "Should be persisted");
            Assert.IsFalse(playerStorage.Transient, "Should be persisted");

            Assert.IsNotNull(questStorage.Player, "Quest should have player");
            Assert.AreEqual(playerStorage.Id, questStorage.Player.Id, "Invalid player refenrece");
        }

        #endregion Persistance Tests

        #region ResourceCheck Tests

        [Test]
        public void ResourceCheck_CanComplete()
        {
            IResourceInfo res = Gold.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;
            IQuestData quest = ResourceCheck.Create("Get 1000 Gold", res, 1000);
            player.AddQuest(quest);

            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available yet");

            player.SetQuantity(res, 1000);

            Assert.IsTrue(quest.CanComplete().Ok, "Quest objective is available");
        }

        [Test]
        public void ResourceCheck_Complete()
        {
            IResourceInfo res = Gold.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;
            IQuestData quest = ResourceCheck.Create("Get 1000 Gold", res, 1000);
            QuestManager.AddReward(quest, res, 1000);
            player.AddQuest(quest);

            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available yet");

            player.SetQuantity(res, 1000);

            Assert.IsTrue(quest.CanComplete().Ok, "Quest objective is available");

            quest.Complete();

            Assert.AreEqual(2000, player.GetQuantity(res), "Quest reward not resolved");
            Assert.IsFalse(quest.CanComplete().Ok, "Quest already completed,should fail");
        }

        #endregion ResourceCheck Tests

        #region ResourceExchange Tests

        [Test]
        public void ResourceExchange_CanComplete()
        {
            IResourceInfo res = Gold.Resource;
            IResourceInfo tit = Titanium.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;

            IQuestData quest = ResourceExchange.Create("Get 1000 Gold in exchange for 1000 titanium", tit, 1000);
            QuestManager.AddReward(quest, res, 1000);
            player.AddQuest(quest);

            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available yet");

            player.SetQuantity(tit, 1000);
            Assert.AreEqual(1000, player.GetQuantity(tit),"Titanium not match");
            Assert.AreEqual(0, player.GetQuantity(res), "Gold not match");

            Assert.IsTrue(quest.CanComplete().Ok, "Quest objective is available");
        }

        [Test]
        public void ResourceExchange_Complete()
        {
            IResourceInfo res = Gold.Resource;
            IResourceInfo tit = Titanium.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;

            IQuestData quest = ResourceExchange.Create("Get 1000 Gold in exchange for 1000 titanium", tit, 1000);
            QuestManager.AddReward(quest, res, 1000);
            player.AddQuest(quest);

            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available yet");

            player.SetQuantity(tit, 1000);
            Assert.AreEqual(1000, player.GetQuantity(tit), "Titanium not match");
            Assert.AreEqual(0, player.GetQuantity(res), "Gold not match");

            Assert.IsTrue(quest.CanComplete().Ok, "Quest objective is available");

            quest.Complete();

            Assert.AreEqual(0, player.GetQuantity(tit), "Titanium not match");
            Assert.AreEqual(1000, player.GetQuantity(res), "Gold not match");
            Assert.IsFalse(quest.CanComplete().Ok, "Quest already completed,should fail");
        }

        #endregion ResourceExchange Tests

        #region BattleCount Tests

        [Test]
        public void BattleCount_Complete_Simulation()
        {
            IResourceInfo res = Gold.Resource;
            IPlayer player = EngineUtils.EmptyPlayer;

            IQuestData quest = BattleCount.Create("Get 1000 Gold after two battles", 2);
            QuestManager.AddReward(quest, res, 1000);
            player.AddQuest(quest);

            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available yet");

            AddTwoBattles(player);

            Assert.IsTrue(quest.CanComplete().Ok, "Quest objective is available");

            quest.Complete();

            Assert.AreEqual(1000, player.GetQuantity(res), "Quest reward not resolved");
            Assert.IsFalse(quest.CanComplete().Ok, "Quest objective not available anymore");
        }

        private void AddTwoBattles(IPlayer player)
        {
            IQuestData data = player.Quests[0];
            data.QuestIntProgress["Count"] = 2;
        }

        #endregion BattleCount Tests

        #region AttackPlayer Tests

        [Test]
        public void AttackPlayer_Complete_Simulation()
        {
            IPlayer player = EngineUtils.EmptyPlayer;
            IPlayer target = EngineUtils.EmptyPlayer;
            target.PlanetLevel = 2;
            IPlayer dummy = EngineUtils.EmptyPlayer;

            AttackPlayer quest = (AttackPlayer) QuestManager.GetQuestType("PlayerBounty");
            IQuestData data = quest.AddToPlayer(player);
            AttackPlayer.SetTargetPlayer(data, target);

            Assert.IsFalse(data.CanComplete().Ok, "Quest objective not available yet");

            IBattleInfo battleInfo = new TotalAnnihalation();
            battleInfo.BattleMode = BattleMode.Battle;

            quest.Process(data, battleInfo, GetPlayerOwner(player), GetPlayerOwner(dummy), true);
            Assert.IsFalse(data.CanComplete().Ok, "Quest objective not available yet");

            quest.Process(data, battleInfo, GetPlayerOwner(target), GetPlayerOwner(player), false);
            Assert.IsFalse(data.CanComplete().Ok, "Quest objective not available yet");

            quest.Process(data, battleInfo, GetPlayerOwner(player), GetPlayerOwner(target), true);
            Assert.IsTrue(data.CanComplete().Ok, "Quest objective is available");

            data.Complete();

            Assert.AreEqual(PlayerBounty.GetScoreReward(target.PlanetLevel), player.Score);
        }

        private static IPlayerOwner[] GetPlayerOwner(IPlayer player)
        {
            return new IPlayerOwner[] { new PlayerOwner(player) };
        }

        #endregion AttackPlayer Tests

        #region RaidPlanet Tests

        [Test]
        public void Raid3Planets_Complete_Simulation()
        {
            IPlayer player = EngineUtils.EmptyPlayer;
            IPlayer target = EngineUtils.EmptyPlayer;
            IPlayer dummy = EngineUtils.EmptyPlayer;

            IQuestInfo info = QuestManager.GetQuestType("Raid3Planets");
            IQuestData data = info.AddToPlayer(player);
            IBattleInfo battleInfo = EngineUtils.GetDummyBattle();

            player.SetQuestContextLevel(QuestContext.Pirate, 1);
            Assert.IsTrue(info.IsAvailable(player));

            Result result = data.CanComplete();
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessRaid(player, target);
            Assert.AreEqual(1, data.QuestIntProgress["Raids"]);
            result = data.CanComplete();
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessBattle(battleInfo, GetPlayerOwner( player ), GetPlayerOwner( target ));
            Assert.AreEqual(1, data.QuestIntProgress["Raids"]);
            result = data.CanComplete();
            Assert.IsFalse(result.Ok, result.Log());

            battleInfo.Battle.IsInPlanet = true;
            battleInfo.Battle.IsToConquer = true;
            QuestManager.ProcessBattle(battleInfo, GetPlayerOwner( player ), GetPlayerOwner(target));
            Assert.AreEqual(1, data.QuestIntProgress["Raids"]);
            result = data.CanComplete();
            Assert.IsFalse(result.Ok, result.Log());

            battleInfo.Battle.IsInPlanet = true;
            battleInfo.Battle.IsToConquer = false;
            QuestManager.ProcessBattle(battleInfo, GetPlayerOwner( player ), GetPlayerOwner( target ));
            Assert.AreEqual(2, data.QuestIntProgress["Raids"]);
            result = data.CanComplete();
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessBattle(battleInfo, GetPlayerOwner( player ), GetPlayerOwner( target ));
            Assert.AreEqual(3, data.QuestIntProgress["Raids"]);
            result = data.CanComplete();
            Assert.IsTrue(result.Ok, result.Log());
        }

        #endregion AttackPlayer Tests

        #region FinishABattleQuest

        [Test]
        public void FinishABattleQuest_Test()
        {
            IPlayer winner = EngineUtils.EmptyPlayer;
            IPlayer looser = EngineUtils.EmptyPlayer;

            IQuestInfo quest = QuestManager.GetQuestType("FinishABattleQuest");
            quest.AddToPlayer(winner);
            quest.AddToPlayer(looser);

            Assert.AreEqual(1, winner.Quests.Count);
            Assert.AreEqual(1, looser.Quests.Count);

            IQuestData winnerData = winner.Quests[0];
            IQuestData looserData = looser.Quests[0];

            Result result = quest.CanComplete(winnerData);
            Assert.IsFalse(result.Ok, result.Log());
            result = quest.CanComplete(looserData);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessBattle(null, GetPlayerOwner( winner ), GetPlayerOwner( looser ));

            Assert.AreEqual(100, winnerData.Percentage);
            Assert.AreEqual(100, looserData.Percentage);

            result = quest.CanComplete(winnerData);
            Assert.IsTrue(result.Ok, result.Log());
            result = quest.CanComplete(looserData);
            Assert.IsTrue(result.Ok, result.Log());

            quest.Complete(winnerData);
            quest.Complete(looserData);

            Assert.AreEqual(200, winner.GetQuantity(Astatine.Resource));
        }

        #endregion FinishABattleQuest

        #region Find Markets Quests

        [Test]
        public void FindOneMarketQuestTest()
        {
            IQuestInfo quest = QuestManager.GetQuestType("FindOneMarketQuest");
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "FindOneMarketQuestTest", RaceInfo.Get(Race.LightHumans));
            player.SetQuestContextLevel(QuestContext.Merchant, 1);
            IQuestData data = new QuestData();
            data.Player = player;

            Assert.IsTrue(quest.IsAvailable(player));
            Result result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            UniverseSpecialSector marketSector = Persistance.Create<UniverseSpecialSector>();
            marketSector.Type = "Market";
            player.SpecialSectors.Add(marketSector);

            result = quest.CanComplete(data);
            Assert.IsTrue(result.Ok, result.Log());
        }

        #endregion Find Markets Quests

        #region Trade Route Quests

        [Test]
        public void FirstTradeRouteQuestTest()
        {
            IQuestInfo quest = QuestManager.GetQuestType("FirstTradeRouteQuest");
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "FirstTradeRouteQuestTest", RaceInfo.Get(Race.LightHumans));
            player.SetQuestContextLevel(QuestContext.Merchant, 2);
            quest.AddToPlayer(player);

            IQuestData data = player.Quests[0];

            Assert.IsTrue(quest.IsAvailable(player));
            Result result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessTradeRoute(null, player, new ResourceQuantity(Tools.Resource, 1));

            result = quest.CanComplete(data);
            Assert.IsTrue(result.Ok, result.Log());
        }

        [Test]
        public void FirstTradeRouteQuestTest_HigherLevelResources()
        {
            IQuestInfo quest = QuestManager.GetQuestType("FirstTradeRouteQuest");
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "FirstTradeRouteQuestTest_HigherLevelResources", RaceInfo.Get(Race.LightHumans));
            player.SetQuestContextLevel(QuestContext.Merchant, 2);
            quest.AddToPlayer(player);

            IQuestData data = player.Quests[0];

            Assert.IsTrue(quest.IsAvailable(player));
            Result result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessTradeRoute(null, player, new ResourceQuantity(Alcohol.Resource, 1));

            result = quest.CanComplete(data);
            Assert.IsTrue(result.Ok, result.Log());
        }

        [Test]
        public void BringToolsAndSuppliesToMarketLevel3Test()
        {
            IQuestInfo quest = QuestManager.GetQuestType("BringToolsAndSuppliesToMarketLevel3");
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "BringToolsAndSuppliesToMarketLevel3", RaceInfo.Get(Race.LightHumans));
            player.SetQuestContextLevel(QuestContext.Merchant, 5);
            IQuestData data = quest.AddToPlayer(player);

            Market market = Persistance.Create<Market>();
            market.Level = 1;

            Assert.IsTrue(quest.IsAvailable(player));
            Result result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessTradeRoute(market, player, new ResourceQuantity(Tools.Resource, 1), new ResourceQuantity(Supplies.Resource, 1));
            result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            market.Level = 3;

            QuestManager.ProcessTradeRoute(market, player, new ResourceQuantity(Supplies.Resource, 1));
            result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessTradeRoute(market, player, new ResourceQuantity(Tools.Resource, 1));
            result = quest.CanComplete(data);
            Assert.IsFalse(result.Ok, result.Log());

            QuestManager.ProcessTradeRoute(market, player, new ResourceQuantity(Tools.Resource, 1), new ResourceQuantity(Supplies.Resource, 1));
            result = quest.CanComplete(data);
            Assert.IsTrue(result.Ok, result.Log());
        }

        #endregion Trade Route Quests

		#region Mobs QUests

		#region Mercs

		[Test]
		public void BringMercWrecksToAcademyLevel1() {
			IQuestInfo quest = QuestManager.GetQuestType("BringMercWrecksToAcademyLevel1");
			IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "BringMercWrecksToAcademyLevel1", RaceInfo.Get(Race.LightHumans));
			player.SetQuestContextLevel(QuestContext.Mercs, 1);
			IQuestData data = quest.AddToPlayer(player);

			Assert.IsTrue(quest.IsAvailable(player));
			Result result = quest.CanComplete(data);
			Assert.IsFalse(result.Ok, result.Log());

			SectorCoordinate c = new SectorCoordinate(new Coordinate(1, 1), new Coordinate(6, 6));

			QuestManager.ProcessMobs(c, player, new ResourceQuantity(PlasmaConduit.Resource, 6), new ResourceQuantity(ElectricCircuit.Resource, 2));
			result = quest.CanComplete(data);
			Assert.IsFalse(result.Ok, result.Log());
			
			c.Sector.X = 1;
			c.Sector.Y = 1;

			QuestManager.ProcessMobs(c, player, new ResourceQuantity(PlasmaConduit.Resource, 10), new ResourceQuantity(ElectricCircuit.Resource, 4));
			result = quest.CanComplete(data);
			Assert.IsTrue(result.Ok, result.Log());
		}

		#endregion Mercs

		#endregion Mobs Quests

    };
}