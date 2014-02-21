using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.Engine;
using OrionsBeltTests;
using NUnit.Framework;
using OrionsBelt.RulesCore.Common;
using System;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Generic;
using OrionsBelt.Engine.Common;
using OrionsBeltTests.EngineTests;

namespace OrionsBeltTests.RulesTests {

    [TestFixture]
    public class DurationTests : BaseTests {

        #region ProductionFactor

        [Test]
        [ExpectedException(typeof(EngineException))]
        public void ProductionFactor_Owner_SetPlayer()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            player.ProductionFactor = 100;
        }

        [Test]
        public void ProductionFactor_Owner_SinglePlanet()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            planet.ProductionFactor = 100;
            Assert.AreEqual(100, planet.ProductionFactor);
            Assert.AreEqual(player.ProductionFactor, planet.ProductionFactor);

            planet.ProductionFactor = 60;
            Assert.AreEqual(60, planet.ProductionFactor);
            Assert.AreEqual(player.ProductionFactor, planet.ProductionFactor);
        }

        [Test]
        public void ProductionFactor_Owner_TwoPlanets()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;
            Planet other = new Planet(player, "Zen2");

            planet.ProductionFactor = 100;
            other.ProductionFactor = 100;
            Assert.AreEqual(100, player.ProductionFactor);

            planet.ProductionFactor = 150;
            other.ProductionFactor = 50;
            Assert.AreEqual(100, player.ProductionFactor);

            planet.ProductionFactor = 110;
            other.ProductionFactor = 70;
            Assert.AreEqual(90, player.ProductionFactor);
        }

        #endregion ProductionFactor

        #region Duration

        [Test]
        public void Duration_Intrinsic()
        {
            IResourceInfo info = Gold.Resource;
            Assert.IsFalse(info.IsBuildable);

            int duration = info.GetBuildDuration(EngineUtils.RichPlayerPlanet, PlanetResource.Create(info,100));
            Assert.AreEqual(0, duration);
        }

        [Test]
        public void Duration_Unit()
        {
            IUnitInfo info = Crusader.Resource;
            Assert.IsTrue(info.IsBuildable);
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            planet.ProductionFactor = 50;

            int duration = info.GetBuildDuration(planet, PlanetResource.Create(info, 100));
            Assert.Greater(duration, 0);

            double value = info.UnitValue;
            Assert.AreEqual((100 * Convert.ToInt32(Math.Ceiling(value / 10))) / 2, duration);
        }

        [Test]
        public void Duration_Facility()
        {
            IFacilityInfo info = TitaniumExtractor.Resource;
            Assert.IsTrue(info.IsBuildable);
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            planet.ProductionFactor = 100;

            IPlanetResource res = PlanetResource.Create(info, 100);

            res.Level = 1;
            int duration = info.GetBuildDuration(planet, res);
            Assert.Greater(duration, 0);

            res.Level = 2;
            int duration2 = info.GetBuildDuration(planet, res);
            Assert.Greater(duration2, duration);

        }

        [Test]
        public void Duration_Calculate()
        {
            
            Assert.AreEqual(Cost.Calculate(1, 0, 0.055*6, 2, 0, 1),1,"Level 1 should be:");
            Assert.AreEqual(Cost.Calculate(1, 0, 0.055*6, 2, 0, 2), 3, "Level 2 should be:");
            Assert.AreEqual(Cost.Calculate(1, 0, 0.055*6, 2, 0, 3), 9, "Level 3 should be:");
            Assert.AreEqual(Cost.Calculate(1, 0, 0.055*6, 2, 0, 4), 22, "Level 4 should be:");

            Assert.AreEqual(Cost.CalculateDuration(1, 0, 0.072, 2, 0.072, 1), 0, "Level 1 should be:");
            Assert.AreEqual(Cost.CalculateDuration(1, 0, 0.072, 2, 0.072, 2), 4, "Level 2 should be:");
        }

        #endregion Duration

    };
}