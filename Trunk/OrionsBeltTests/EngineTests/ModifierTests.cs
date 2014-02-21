using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ModifierTests: BaseTests {

        #region Set Modifiers 

        [Test]
        public void TestModifiersTouch()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            planet.IsDirty = false;
            planet.AddToModifier(Gold.Resource, 10);
            Assert.IsTrue(planet.IsDirty);
        }

        [Test]
        public void TestSetModifier()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            int count = planet.GetModifier(Gold.Resource);
            planet.AddToModifier(Gold.Resource, 10);

            Assert.AreEqual(10+count, planet.GetModifier(Gold.Resource));
        }

        #endregion Modifiers

        #region Modifiers usage

        [Test]
        public void TestPeriodicIncome_OneTime()
        {
            IResourceInfo res = Gold.Resource;
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            int baseModifier = planet.GetModifier(res);
            int initialQuantity = planet.GetQuantity(res);

            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(initialQuantity + baseModifier, planet.GetQuantity(res));
        }

        [Test]
        public void TestPeriodicIncome_LongDelay()
        {
            IResourceInfo res = Gold.Resource;
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            int baseModifier = planet.GetModifier(res);
            int initialQuantity = planet.GetQuantity(res);
            int turns = 10;

            for( int i = 0; i < turns-1; ++i ) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(initialQuantity + baseModifier * turns, planet.GetQuantity(res));
        }

        [Test]
        public void TestPeriodicIncome_AddingBuilding()
        {
            IResourceInfo res = Gold.Resource;
            IFacilityInfo facility = DevotionSanctuary.Resource;

            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;
             
            IPlanetResource planetResource = planet.Enqueue(PlanetResource.Create(facility, 1));
            int duration = facility.GetBuildDuration(planet, planetResource);
            int initialModifier = planet.GetModifier(res);
            int modifierAfterBuilding = initialModifier + DevotionSanctuary.GetGoldIncome(planetResource);

            GameEngine.ProcessPlayer(player);
            int initialQuantity = planet.GetQuantity(res);

            for (int i = 0; i < duration; ++i) {
                Clock.Instance.Advance();
            }

            for (int i = 0; i < duration; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);
            Assert.AreEqual(1, planet.GetQuantity(facility), "Planet should have 1 DevotionSanctuary");
            Assert.AreEqual(initialQuantity + duration * initialModifier + duration * modifierAfterBuilding, planet.GetQuantity(res));

        }

        [Test]
        public void TestPeriodicIncome_AddingBuildingWithQueue()
        {
            IResourceInfo res = Gold.Resource;
            IFacilityInfo facility = DevotionSanctuary.Resource;

            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            IPlanetResource planetResource = planet.Enqueue(PlanetResource.Create(facility, 1));
            IPlanetResource planetResource2 = planet.Enqueue(PlanetResource.Create(facility, 1));

            int duration = facility.GetBuildDuration(planet, planetResource);
            int initialModifier = planet.GetModifier(res);
            int modifierAfterBuilding = initialModifier + DevotionSanctuary.GetGoldIncome(planetResource);
            int modifierAfterSecondBuilding = modifierAfterBuilding + DevotionSanctuary.GetGoldIncome(planetResource);

            GameEngine.ProcessPlayer(player);
            int initialQuantity = planet.GetQuantity(res);

            for (int i = 0; i < duration * 3; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);
            Assert.AreEqual(2, planet.GetQuantity(facility));

            int expected = initialQuantity + duration * initialModifier + duration * modifierAfterBuilding + duration * modifierAfterSecondBuilding + 1;
            Assert.Greater(expected, planet.GetQuantity(res));

        }


        #endregion Modifiers usage

        #region Limits

        [Test]
        public void TestLimit_Zero()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;
            IResourceInfo res = Gold.Resource;

            player.SetLimit(null, 0);
            planet.SetQuantity(res, 0);
            planet.AddToModifier(res, 1000);

            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(0, player.GetQuantity(res));
        }

        [Test]
        public void TestLimit_None()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;
            IResourceInfo res = Gold.Resource;

            player.SetLimit(res, -1);
            planet.SetQuantity(res, 0);
            planet.AddToModifier(res, 1000);

            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(planet.GetModifier(res), player.GetQuantity(res));
        }

        [Test]
        public void TestLimit_Dirtyness()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            player.UpdateStorage();

            player.Limits = new System.Collections.Generic.Dictionary<IResourceInfo, int>();
            Assert.IsTrue(player.IsDirty);
            player.UpdateStorage();

            player.AddToLimit(Gold.Resource, 100);
            Assert.IsTrue(player.IsDirty);
            player.UpdateStorage();
        }

        #endregion Limits

        #region Richness

        [Test]
        public void TestRichness_Zero()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IResourceInfo res = Gold.Resource;

            planet.SetRichness(res, 0);
            planet.SetQuantity(res, 0);
            planet.AddToModifier(res, 1000);

            GameEngine.ProcessPlayer(planet.Owner);

            Assert.AreEqual(0, planet.GetQuantity(res));
        }

        [Test]
        public void TestRichness_None()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IResourceInfo res = Gold.Resource;

            planet.SetQuantity(res, 0);
            planet.AddToModifier(res, 1000);

            GameEngine.ProcessPlayer(planet.Owner);

            Assert.AreEqual(planet.GetModifier(res), planet.GetQuantity(res));
        }

        [Test]
        public void TestRichness_Double()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IResourceInfo res = Gold.Resource;

            planet.SetRichness(res, 200);
            planet.SetQuantity(res, 0);
            planet.AddToModifier(res, 1000);

            GameEngine.ProcessPlayer(planet.Owner);

            Assert.AreEqual(planet.GetModifier(res) * 2, planet.GetQuantity(res));
        }

        [Test]
        public void TestRichness_Dirtyness()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;

            planet.Richness = new System.Collections.Generic.Dictionary<IResourceInfo, int>();
            Assert.IsTrue(planet.IsDirty);
            planet.UpdateStorage();

            planet.AddToRichness(Gold.Resource, 100);
            Assert.IsTrue(planet.IsDirty);
            planet.UpdateStorage();
        }

        [Test]
        public void TestRichness_Values()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IResourceInfo res = Gold.Resource;

            planet.SetRichness(res, 50);
            planet.AddToModifier(res, 100);

            Assert.AreEqual(planet.GetModifier(res) * 0.5, planet.GetPerTick(res));

            Assert.AreEqual(planet.GetModifier(res) * 0.5, planet.Owner.GetPerTick(res));
        }

        #endregion Richness

    };
}