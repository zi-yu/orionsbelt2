using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Quests;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Engine.Alliances;
using System.Collections.Generic;
using OrionsBelt.Engine.Common;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class AllianceTests : BaseTests {

        #region Subscription Tests

        [Test]
        public void Subscription_PlayerAsksJoin()
        {
            IAlliance alliance = EngineUtils.DummyAlliance;
            IPlayer player = EngineUtils.EmptyPlayer;

            AllianceManager.RegisterSubscription(alliance, player);

            IList<Interaction> interactions = AllianceManager.GetInteractions(alliance);

            Assert.AreEqual(1, interactions.Count, "There should be 1 interaction");

            Interaction loaded = interactions[0];

            Assert.IsFalse(alliance.Storage.Transient, "Alliance not persisted");
            Assert.IsFalse(player.Storage.Transient, "player not persisted");
            Assert.IsFalse(loaded.Transient, "loaded not persisted");

            Assert.AreEqual("AllianceSubscription",loaded.Type);
            Assert.AreEqual("Alliance", loaded.InteractionContext);
            Assert.AreEqual(false, loaded.Response);
            Assert.AreEqual(false, loaded.Resolved);
            Assert.AreEqual(alliance.Storage.Id, loaded.Target);
            Assert.AreEqual(player.Id, loaded.Source);
        }

        [Test]
        public void Subscription_AllianceAccepts()
        {
            IAlliance alliance = EngineUtils.DummyAlliance;
            IPlayer player = EngineUtils.EmptyPlayer;

            AllianceManager.RegisterSubscription(alliance, player);
            IList<Interaction> interactions = AllianceManager.GetInteractions(alliance);
            Interaction interaction = interactions[0];

            InteractionType.ResolveSuccess(interaction, alliance.Storage);

            player = PlayerUtils.GetPlayerById(interaction.Source);

            Assert.IsTrue(player.HasAlliance, "Player should have alliance");
            Assert.AreEqual(alliance.Storage.Id, player.Alliance.Storage.Id, "alliance id don't match");
            Assert.IsTrue(interaction.Resolved, "Interaction should be resolved");
            Assert.IsTrue(interaction.Response, "response should be true");
            Assert.AreEqual(player.AllianceRank, AllianceRank.Member, "Player should be member");
        }

        [Test]
        public void Subscription_AllianceRejects()
        {
            IAlliance alliance = EngineUtils.DummyAlliance;
            IPlayer player = EngineUtils.EmptyPlayer;
            bool hadAlliance = player.HasAlliance;

            AllianceManager.RegisterSubscription(alliance, player);
            IList<Interaction> interactions = AllianceManager.GetInteractions(alliance);
            Interaction interaction = interactions[0];

            InteractionType.ResolveFail(interaction, alliance.Storage);

            player = PlayerUtils.GetPlayerById(interaction.Source);

            Assert.AreEqual(hadAlliance, player.HasAlliance, "Player should have alliance");
            Assert.IsTrue(interaction.Resolved, "Interaction should be resolved");
            Assert.IsFalse(interaction.Response, "response should be false");
        }

        #endregion Subscription Tests

        #region Creation Tests

        [Test]
        public void Create_Alliance()
        {
            IPlayer player = EngineUtils.EmptyPlayer;

            Result result = AllianceManager.CanCreateAlliance(player);

            Assert.IsFalse(player.HasAlliance, "Player should not have an alliance");
            Assert.IsTrue(result.Ok, "player should be able to create an alliance to tun the rest of the test");

            AllianceManager.CreateAlliance(player, "Player Alliance", "Alliance Tag", "Alliance Description");

            Assert.IsTrue(player.HasAlliance, "Player should have an alliance");
            Assert.AreEqual(player.Alliance.Storage.Name, "Player Alliance");
            Assert.AreEqual(player.AllianceRank, AllianceRank.Admiral, "Player should be admiral");
        }

        #endregion Creation Tests

        #region Leave Tests

        [Test]
        public void Leave_Forced()
        {
            //
            // Create alliance
            //
            IPlayer admiral = EngineUtils.EmptyPlayer;
            AllianceManager.CreateAlliance(admiral, "Player Alliance", "Alliance Tag", "Alliance Description");

            //
            // Add member
            //
            IAlliance alliance = admiral.Alliance; ;
            IPlayer player = EngineUtils.EmptyPlayer;

            AllianceManager.RegisterSubscription(alliance, player);
            IList<Interaction> interactions = AllianceManager.GetInteractions(alliance);
            Interaction interaction = interactions[0];
            InteractionType.ResolveSuccess(interaction, alliance.Storage);

            player = PlayerUtils.GetPlayerById(interaction.Source);

            //
            // Remove Member
            //
            AllianceManager.KickPlayer(alliance, player, EngineUtils.EmptyPlayer);

            //
            // Tests
            //

            Assert.IsFalse(player.HasAlliance, "Player should be out of the alliance");
            Assert.AreEqual(player.AllianceRank, AllianceRank.None, "Player should not have rank");
        }

        [Test]
        public void Leave_Alliance()
        {
            //
            // Create alliance
            //
            IPlayer admiral = EngineUtils.EmptyPlayer;
            AllianceManager.CreateAlliance(admiral, "Player Alliance", "Alliance Tag", "Alliance Description");

            //
            // Add member
            //
            IAlliance alliance = admiral.Alliance; ;
            IPlayer player = EngineUtils.EmptyPlayer;

            AllianceManager.RegisterSubscription(alliance, player);
            IList<Interaction> interactions = AllianceManager.GetInteractions(alliance);
            Interaction interaction = interactions[0];
            InteractionType.ResolveSuccess(interaction, alliance.Storage);

            player = PlayerUtils.GetPlayerById(interaction.Source);

            //
            // Remove Member
            //
            AllianceManager.LeaveAlliance(player);

            //
            // Tests
            //

            Assert.IsFalse(player.HasAlliance, "Player should be out of the alliance");
            Assert.AreEqual(player.AllianceRank, AllianceRank.None, "Player should not have rank");

        }
            
        #endregion Leave Tests

        #region Diplomacy Tests

        [Test]
        public void Diplomacy_Add()
        {
            IAlliance alliance1 = EngineUtils.DummyAlliance;
            IAlliance alliance2 = EngineUtils.DummyAlliance;

            AllianceManager.AddDiplomaticRelation(alliance1, alliance2, AllianceDiplomacyLevel.War);

            IList<AllianceDiplomacy> diplomacy = AllianceManager.GetDiplomaticRelations(alliance1);
            Assert.AreEqual(1, diplomacy.Count, "There should be one relation");

            IList<AllianceDiplomacy> diplomacy2 = AllianceManager.GetDiplomaticRelations(alliance2);
            Assert.AreEqual(1, diplomacy2.Count, "There should be one relation");

            AllianceDiplomacy dip = AllianceManager.GetDiplomaticRelation(alliance1, alliance2);
            Assert.IsNotNull(dip, "Dip should not be null");
            Assert.AreEqual(AllianceDiplomacyLevel.War.ToString(), dip.Level, "Wrong level");
        }

        [Test]
        public void Diplomacy_DefaultRelation()
        {
            IAlliance alliance1 = EngineUtils.DummyAlliance;
            IAlliance alliance2 = EngineUtils.DummyAlliance;

            AllianceDiplomacyLevel level = AllianceManager.GetDiplomaticRelationLevel(alliance1, alliance2);

            Assert.AreEqual(AllianceDiplomacyLevel.Neutral, level);
        }

        [Test]
        public void Diplomacy_Change()
        {
            IAlliance alliance1 = EngineUtils.DummyAlliance;
            IAlliance alliance2 = EngineUtils.DummyAlliance;

            AllianceManager.AddDiplomaticRelation(alliance1, alliance2, AllianceDiplomacyLevel.War);

            AllianceManager.ChangeDiplomaticRelation(alliance1, alliance2, AllianceDiplomacyLevel.NonAgressionPact);

            AllianceDiplomacyLevel level = AllianceManager.GetDiplomaticRelationLevel(alliance1, alliance2);

            Assert.AreEqual(AllianceDiplomacyLevel.NonAgressionPact, level);
        }

        #endregion Diplomacy Tests

    };
}