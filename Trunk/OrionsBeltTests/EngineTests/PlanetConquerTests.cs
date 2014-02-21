using NUnit.Framework;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class PlanetConquerTests: BaseTests {

        #region Abandon Tests

        [Test]
        public void Planet_Abandon()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Planet_Abandon", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();

            int playerScore = player.Score;
            int planetScore = planet.Score;

            Assert.Greater(planet.Score, 0, "Planet should have score");
            Assert.Greater(player.Score, 0, "Player should have score");

            PlanetUtils.Abandon(player, planet);
            GameEngine.Persist(player);
            GameEngine.Persist(planet);

            Assert.IsFalse(planet.HasOwner, "Planet should not have owner");
            Assert.AreEqual(0, player.Planets.Count, "Player should have 0 planets");
            Assert.AreEqual(playerScore - planetScore, player.Score, "Wrong score");
        }

        #endregion Abandon Tests

        #region Colonize Tests

        [Test]
        public void Planet_Colonize()
        {
			PlanetSector sector = new PlanetSector(new Coordinate(1, 1), new Coordinate(1, 1), 1, false);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Planet_Colonize", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = PlanetUtils.GeneratePlanet(player, sector, new SectorCoordinate(1, 1, 1, 1));

            Assert.IsTrue(planet.HasOwner, "Planet should have owner");
			Assert.AreEqual(2, player.Planets.Count, "Player should have 2 planets");
        }

        #endregion Colonize Tests

        #region Conquer Tests

        [Test]
        public void Planet_Conquer()
        {
			PlanetSector sector = new PlanetSector(new Coordinate(1, 1), new Coordinate(1, 1), 1, false);
			IPlayer player1 = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Planet_Conquer_1", RaceInfo.Get(Race.LightHumans));
            IPlayer player2 = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Planet_Conquer_2", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = PlanetUtils.GeneratePlanet(player1, sector, new SectorCoordinate(1, 1, 1, 1));

            planet.Score += 1000;

            GameEngine.ProcessPlayer(player1);
            GameEngine.ProcessPlayer(player2);

            planet.LastConquerTick = 0;

			PlanetUtils.Conquer(sector, player1, player2);

            GameEngine.ProcessPlayer(player1);
            GameEngine.ProcessPlayer(player2);

            Assert.IsTrue(planet.HasOwner);
            Assert.AreEqual(player2, planet.Owner);

            Assert.AreEqual(1, player1.Planets.Count);
            Assert.AreEqual(2, player2.Planets.Count);

            Assert.Greater(player2.Score, 1000);
            Assert.Less(player1.Score, 1000);

			Assert.AreEqual(planet.DefenseFleet.Owner.Id, player2.Id);
        }

        #endregion Conquer Tests

    };
}