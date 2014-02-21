using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Generic;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class PlanetManagementTests: BaseTests {

        #region Sanity Tests

        [Test]
        public void TestCreatedPlanet()
        {
            Player player = new Player();
            Planet planet = new Planet(player, "Alpha");

            Assert.IsNotNull(planet.Owner);
            Assert.AreEqual(1, player.Planets.Count);
        }

        [Test]
        public void TestResourceAllocation()
        {
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            Assert.AreEqual(0, player.Facilities.Count, "Player should not have Facilities");
            Assert.AreEqual(0, player.Units.Count, "Player should not have Units");
        }

        #endregion Sanity Tests

        #region Create Planet

        [Test]
        public void TestGeneratePlanet()
        {
            PlanetSector sector = new PlanetSector(new Coordinate(1, 1), new Coordinate(1, 1), 1, false);
			IPlanet planet = PlanetUtils.GeneratePlanet(EngineUtils.EmptyPlayer, sector, new SectorCoordinate(1, 1, 1, 1));

            Assert.IsTrue(planet.IsDirty);

            GameEngine.Persist(planet);

            Assert.IsFalse(planet.IsDirty);

			Assert.AreEqual(planet.Info.Identifier, sector.GetPlanetInfo().Identifier);
            Assert.AreEqual(planet.Terrain.Terrain, sector.GetTerrainInfo().Terrain);
        }

        #endregion Create Planet

        #region ProductionFactor Tests

        [Test]
        public void TestPlayerPF()
        {
            Player player = new Player();
            Assert.AreEqual(0, player.ProductionFactor);

            Planet planet = new Planet(player, "Alpha");

            Assert.AreEqual(player.ProductionFactor, planet.ProductionFactor);

            Planet planet2 = new Planet(player, "Beta");

            Assert.AreEqual(player.ProductionFactor, (planet.ProductionFactor + planet2.ProductionFactor) / 2);
        }

        [Test]
        [ExpectedException(typeof(EngineException))]
        public void TestPlayerSetPF()
        {
            Player player = new Player();
            player.ProductionFactor = 100;
        }

        #endregion ProductionFactor

        #region Build Units

        [Test]
        public void BuildUnits()
        {
            IUnitInfo unit = Crusader.Resource;
            IPlanet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;

            Assert.AreEqual(1, player.Planets.Count, "Planet Count");

            Assert.AreEqual(0, planet.GetQuantity(unit), "Wrong Crusader quantity");
            Assert.AreEqual(0, planet.GetUsedQueueSpace(ResourceType.Unit), "Wrong used queue space");

            PlanetResource resource = PlanetResource.Create(unit, 300);
            int duration = unit.GetBuildDuration(planet, resource);
            int bdcount = planet.Storage.Resources.Count;
            planet.Enqueue(resource);

            Assert.AreEqual(bdcount + 1, planet.Storage.Resources.Count, "Queue Resource Lost, not persisted to BD");
            Assert.AreEqual(1, planet.GetUsedQueueSpace(ResourceType.Unit));
            Assert.AreEqual(0, planet.GetQuantity(unit), "Wrong Crusader quantity");

            Assert.AreEqual(1, player.Planets.Count, "Planet Count");
            int units = planet.Units.Count;
            GameEngine.ProcessPlayer(player);
            Assert.AreEqual(1, player.Planets.Count, "Planet Count");

            planet = player.Planets[0];
            Assert.AreEqual(units, planet.Units.Count, "Units don't match");

            for (int i = 0; i < duration; ++i) {
                Clock.Instance.Advance();
                Assert.AreEqual(0, planet.GetUsedQueueSpace(ResourceType.Unit), "There should be no resources in queue");
                Assert.AreEqual(1, planet.GetResourcesInProduction(ResourceType.Unit).Count, "There should be 1 resource in production");
                Assert.AreEqual(0, planet.GetQuantity(unit), "Wrong Crusader quantity");
            }

            GameEngine.ProcessPlayer(player);
            planet = player.Planets[0];

            Assert.AreEqual(1, player.Planets.Count, "Planet Count");
            Assert.AreEqual(0, planet.GetUsedQueueSpace(ResourceType.Unit));
            Assert.AreEqual(0, planet.GetResourcesInProduction(ResourceType.Unit).Count, "The unit should be constructed already");
            Assert.AreEqual(300, planet.GetQuantity(unit), "Wrong Crusader quantity");

            Assert.AreEqual(300, planet.DefenseFleet.Units["Crusader"].Quantity, "The crusaders should be at the defense fleet");
        }

        #endregion Build Units        

        #region SetOwner

        [Test]
        public void TestSetOwner() 
        {
			PlanetSector sector = new PlanetSector(new Coordinate(0, 0), new Coordinate(1, 1), 1, true);
			IPlayer player = EngineUtils.EmptyPlayer;
            IPlanet planet = PlanetUtils.GeneratePlanet(EngineUtils.EmptyPlayer, sector,new SectorCoordinate(0,0,1,1));
			
            PlanetUtils.SetOwner(planet, player);

            Assert.AreEqual(1, player.Planets.Count, "Player should have 1 planet");
            Assert.AreEqual(player, planet.Owner, "Planet should have owner");

            GameEngine.Persist(player);
        }

        #endregion SetOwner

        #region HomePlanet

        [Test]
        public void TestNewPlayerHasHomePlanet()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestNewPlayerHasHomePlanet", RaceInfo.Get(Race.LightHumans));
            Assert.IsNotNull(player.GetHomePlanet());
        }

        #endregion HomePlanet

        #region Facilities

        [Test]
        public void Facilities_TestLightHumansInit_IsTemplate()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumansInit_IsTemplate", race);

            IPlanet hp = player.GetHomePlanet();

            Assert.IsFalse(hp.GetResource(CommandCenter.Resource).IsTemplate, "Should not be template");
        }

        [Test]
        public void Facilities_CountForFacilityLevel()
        {
            Assert.IsTrue(RulesUtils.GetResource("CommandCenter").CountsForFacilityLevel);
            Assert.IsTrue(RulesUtils.GetResource("DarknessHall").CountsForFacilityLevel);
            Assert.IsTrue(RulesUtils.GetResource("Nest").CountsForFacilityLevel);

            Assert.IsTrue(RulesUtils.GetResource("Extractor").CountsForFacilityLevel);
        }

        [Test]
        public void Facilities_TestLightHumansInit()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Zen", race);

            IPlanet hp = player.GetHomePlanet();

            IPlanetResource resource = hp.GetFacility(hp.Info.GetSlot("CommandCenter"));
            Assert.IsNotNull(resource, "Planet should have command center");

            Assert.AreEqual(1, resource.Quantity, "Wrong quantity");
            Assert.AreEqual(1, resource.Level, "Wrong level");
            Assert.AreEqual(1, hp.FacilityLevel, "Wrong facility level");

            Assert.AreEqual(500, hp.GetQuantity(Energy.Resource), "Energy Quantity should be 500");

            Assert.AreEqual(1, hp.GetModifier(Energy.Resource), "Energy Mod should be greater than zero");
            Assert.AreEqual(1, hp.GetModifier(Serium.Resource), "Serium Mod should be greater than zero");
            Assert.AreEqual(0, hp.GetModifier(Mithril.Resource), "Mithril Mod should be greater than zero");

            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player)) {
                Assert.Greater(player.GetLimit(info), 0, "Should have limit for {0}", info.Name);
            }
        }

        [Test]
        public void Facilities_TestLightHumans_Rain()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_Rain", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            FleetInfo defenseFleet = new FleetInfo("Waza");
            defenseFleet.IsPlanetDefenseFleet = true;
            planet.AddFleet(defenseFleet);

            IPlanetResource unitYard = planet.GetResource(UnitYard.Resource);
            unitYard.Level = 10;
            unitYard.Quantity = 1;
            unitYard.State = ResourceState.Running;

            planet.Owner.SetQuantity(Serium.Resource, 0);
            planet.Owner.SetQuantity(Energy.Resource, 0);

            IPlanetResource resource = PlanetResource.Create(Rain.Resource, 1);
            Result result = planet.CanQueue(resource);
            Assert.IsFalse(result.Ok, "Should fail, no resources {0}", result.Log());

            planet.Owner.AddQuantity(Serium.Resource, 1000);
            planet.Owner.AddQuantity(Energy.Resource, 1000);

            result = planet.CanQueue(resource);
            Assert.IsTrue(result.Ok, "Should succeed, has resources {0}", result.Log());

            resource.Quantity = 10;
            result = planet.CanQueue(resource);
            Assert.IsFalse(result.Ok, "Should fail, no resources {0} for 10", result.Log());

            planet.Enqueue(resource);

            while (planet.GetResourcesInProduction(ResourceType.Unit).Count > 0 || planet.GetQueueList(ResourceType.Unit).Count > 0) { 
                Clock.Instance.Advance();
                GameEngine.ProcessPlayer(player);
            }

            Assert.IsNotNull(planet.DefenseFleet, "Defense Fleet can't be null");
            Assert.IsTrue(planet.DefenseFleet.HasUnits, "Should have units");
        }

        [Test]
        public void Facilities_TestLightHumans_Capacity()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_Capacity", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();

            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);

            planet.AddToModifier(Energy.Resource, 2000);

            Clock.Instance.Advance();
            Clock.Instance.Advance();

            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(1000, planet.Owner.GetLimit(null), "Limit should be 1000");
            Assert.AreEqual(1000, planet.GetQuantity(Energy.Resource), "Energy shild be limited to 1000");
            
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_LastLevel()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_LastLevel", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            planet.AddFacility("Resource1", SolarPanel.Resource);
            IPlanetResource resource = planet.GetFacility(slot);
            resource.Level = resource.Info.MaxLevel;
            resource.Quantity = 1;
            resource.State = ResourceState.Running;

            Result result = planet.IsUpgradeAvailable(resource);
            Assert.IsFalse(result.Ok, "Should fail, already at max level : {0}", result.Log());
            Assert.AreEqual(1, result.Failed.Count, "Should fail with only one message : {0}", result.Log());
            Assert.AreEqual(typeof(AlreadyAtMaxLevelResult), result.Failed[0].GetType(), "Should be AlreadyAtMaxLevelResult");
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            int energyMod = planet.GetModifier(Energy.Resource);

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);
            Assert.AreEqual(energyMod, planet.GetModifier(Energy.Resource), "Queued facility shouldn't increment mod");
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);
            Assert.IsNotNull(resource, "There is no Solar Panel");
            Assert.AreEqual(slot.Identifier, resource.Slot.Identifier, "Invalid slot");
            Assert.AreEqual(1, resource.Quantity, "Invalid quantity");
            Assert.AreEqual(ResourceState.Running, resource.State, "Invalid State");
            Assert.AreEqual(1, resource.Level, "Invalid level");
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_DestroyOnQueue()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_DestroyOnQueue", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            int energyMod = planet.GetModifier(Energy.Resource);

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);

            result = planet.IsDestroyAvailable(newResource);
            Assert.IsFalse(result.Ok, result.Log());
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_Dequeue()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_Dequeue", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            int initialEnergy = player.GetQuantity(Energy.Resource);
            int initialSerium = player.GetQuantity(Serium.Resource);
            int score = planet.Score;

            planet.Enqueue(newResource);

            Assert.AreEqual(score, planet.Score, "Planet score should be the same");
            Assert.Less(player.GetQuantity(Energy.Resource), initialEnergy, "Energy cost not resolved");
            Assert.Less(player.GetQuantity(Serium.Resource), initialSerium, "Serium cost not resolved");

            IPlanetResource queuedResource = planet.GetQueueList(ResourceType.Facility)[0];
            planet.Dequeue(queuedResource);

            Assert.AreEqual(score, planet.Score, "Planet score should be the same");
            Assert.AreEqual(initialEnergy, player.GetQuantity(Energy.Resource), "Energy no rollbacked");
            Assert.AreEqual(initialSerium, player.GetQuantity(Serium.Resource), "Serium no rollbacked");

            planet.Enqueue(newResource);
            Clock.Instance.Advance();
            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(1, planet.GetResourcesInProduction(ResourceType.Facility).Count, "There should be one resource in construction");

            planet.CancelProduction(planet.GetResourcesInProduction(ResourceType.Facility)[0]);

            Assert.AreEqual(score, planet.Score, "Planet score should be the same");
            Assert.Less(player.GetQuantity(Energy.Resource), initialEnergy, "Energy cost should not be rolledback");
            Assert.Less(player.GetQuantity(Serium.Resource), initialSerium, "Serium cost should not be rolledback");

        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_Removal()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_Removal", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            int energyMod = planet.GetModifier(Energy.Resource);
            int score = planet.Score;

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);
            Assert.AreEqual(energyMod, planet.GetModifier(Energy.Resource), "Queued facility shouldn't increment mod");
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);

            Assert.Greater(planet.Score, score, "Should have gained score with solarpanel");
            Assert.Greater(planet.GetModifier(Energy.Resource), energyMod, "Should have gained energy mod");

            int energyQuantity = planet.GetQuantity(Energy.Resource);

            planet.Destroy(resource);

            Assert.AreEqual(energyMod, planet.GetModifier(Energy.Resource), "Energy mod should rollback");
            Assert.AreEqual(score, planet.Score, "Score should rollback");
            Assert.IsNull(planet.GetFacility(slot), "There should be no solar panel");
            Assert.AreEqual(energyQuantity, planet.GetQuantity(Energy.Resource), "Destroy shouldn't touch resources");
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_Upgrade_Cancel()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_Upgrade_Cancel", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");
            IFacilitySlot slot2 = planet.Info.GetSlot("Resource2");

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);

            IPlanetResource commandCenter = planet.GetResource(CommandCenter.Resource);
            commandCenter.Level = 2;

            planet.Owner.SetQuantity(Energy.Resource, 10000);
            result = planet.IsUpgradeAvailable(resource);
            Assert.IsTrue(result.Ok, "Should pass to proceed with test : {0}", result.Log());

            // test cancel in queue
            ++resource.Level;
            planet.Enqueue(resource);

            planet.Dequeue(resource);
            Assert.AreEqual(1, resource.Level, "Level should be decreased");

            // test cancel in production
            ++resource.Level;
            planet.Enqueue(resource);
            Clock.Instance.Advance();
            GameEngine.ProcessPlayer(player);

            Assert.AreEqual(ResourceState.InConstruction, resource.State);

            planet.CancelProduction(resource);

            Assert.AreEqual(1, resource.Level, "Level should be decreased");
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_Upgrade()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_Upgrade", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");
            IFacilitySlot slot2 = planet.Info.GetSlot("Resource2");

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i) {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);

            IPlanetResource commandCenter = planet.GetResource(CommandCenter.Resource);
            commandCenter.Level = 2;

            planet.Owner.SetQuantity(Energy.Resource, 0);

            result = planet.IsUpgradeAvailable(resource);
            Assert.IsFalse(result.Ok, "Should fail, no resources: {0}", result.Log());

            planet.Owner.SetQuantity(Energy.Resource, 10000);
            result = planet.IsUpgradeAvailable(resource);
            Assert.IsTrue(result.Ok, "Should succeed, has resources: {0}", result.Log());

            IPlanetResource newResource2 = PlanetResource.Create(facility, 1);
            newResource2.Slot = slot2;
            result = planet.CanQueue(newResource2);
            Assert.IsTrue(result.Ok, "Should build this resource to test queue : {0}", result.Log());
            planet.Enqueue(newResource2);

            planet.Owner.SetQuantity(Energy.Resource, 10000);
            result = planet.IsUpgradeAvailable(resource);
            Assert.IsFalse(result.Ok, "Should fail, no queue space: {0}", result.Log());
        }

        [Test]
        public void Facilities_TestLightHumans_SolarPanel_Upgrade_Removal()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_SolarPanel_Upgrade_Removal", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            int energyMod = planet.GetModifier(Energy.Resource);
            int score = planet.Score;

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build solar panel: {0}", result.Log());

            planet.Enqueue(newResource);
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i)
            {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);

            IPlanetResource commandCenter = planet.GetResource(CommandCenter.Resource);
            commandCenter.Level = 2;

            planet.Owner.SetQuantity(Energy.Resource, 0);

            result = planet.IsUpgradeAvailable(resource);
            Assert.IsFalse(result.Ok, "Should fail, no resources: {0}", result.Log());

            planet.Owner.SetQuantity(Energy.Resource, 10000);
            result = planet.IsUpgradeAvailable(resource);
            Assert.IsTrue(result.Ok, "Should succeed, has resources: {0}", result.Log());
            
            IPlanetResource solar = planet.GetFacility(slot);
            ++solar.Level;
            planet.Enqueue(solar);

            while (planet.GetResourcesInProduction(ResourceType.Facility).Count > 0 || planet.GetQueueList(ResourceType.Facility).Count > 0) {
                Clock.Instance.Advance();
                GameEngine.ProcessPlayer(player);
            }

            GameEngine.Persist(player);

            solar = planet.GetFacility(slot);
            Assert.AreEqual(2, solar.Level, "Wrong solar level");

            planet.Destroy(solar);
            solar = planet.GetFacility(slot);
            GameEngine.Persist(player);

            Assert.AreEqual(energyMod, planet.GetModifier(Energy.Resource), "Energy mod should rollback");
            Assert.AreEqual(score, planet.Score, "Score should rollback");
            Assert.IsNull(planet.GetFacility(slot), "There should be no solar panel");

        }

        [Test]
        public void Facilities_TestLightHumans_UnitYard_Dependency()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facilities_TestLightHumans_UnitYard_Dependency", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            IResourceInfo facility = UnitYard.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("UnitYard");
            IFacilitySlot ccSlot = planet.Info.GetSlot("CommandCenter");
            
            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;
            Result result = planet.CanQueue(newResource);
            Assert.IsFalse(result.Ok, "Shoud fail: {0}", result.Log());

            IPlanetResource cc = planet.GetFacility(ccSlot);
            Assert.IsNotNull(cc, "We should have command center");
            ++cc.Level;
            planet.Enqueue(cc);

            result = planet.CanQueue(newResource);
            Assert.IsFalse(result.Ok, "Shoud fail: {0}", result.Log());

        }

        #endregion Facilities

        #region Light Humans

        [Test]
        public void LightHumans_Planet_Dependency_Test()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "LightHumans_FullTest", race);

            IPlanet hp = player.GetHomePlanet();
            
            TestLevel1(hp);
            
            ChangeCommandCenterLevel(hp, 2);
            TestLevel2(hp);

            ChangeCommandCenterLevel(hp, 3);
            TestLevel2(hp); // no changes

            ChangeCommandCenterLevel(hp, 4);
            TestLevel4(hp);

            ChangeCommandCenterLevel(hp, 5);
            TestLevel5(hp);

            ChangeCommandCenterLevel(hp, 6);
            TestLevel5(hp); // no changes

            ChangeCommandCenterLevel(hp, 7);
            TestLevel7(hp);

            ChangeCommandCenterLevel(hp, 8);
            TestLevel8(hp);
        }

        private static void ChangeCommandCenterLevel(IPlanet hp, int level)
        {
            IPlanetResource commandCenter = hp.GetResource(CommandCenter.Resource);
            commandCenter.Level = level;
        }

        private void TestLevel1(IPlanet hp)
        {
            IsFacilityAvailable(hp, CommandCenter.Resource, true);
            IsFacilityAvailable(hp, SolarPanel.Resource, false);
            IsFacilityAvailable(hp, SeriumExtractor.Resource, false);
            IsFacilityAvailable(hp, Silo.Resource, false);
            IsFacilityAvailable(hp, MithrilExtractor.Resource, false);
            IsFacilityAvailable(hp, DeepSpaceScanner.Resource, false);
            IsFacilityAvailable(hp, BlinkerAssembler.Resource, false);

            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, false);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, false);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, false);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, false);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, false);
        }

        private void TestLevel2(IPlanet hp)
        {
            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, true);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, false);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, false);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, false);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, true);
        }

        private void TestLevel4(IPlanet hp)
        {
            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, true);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, false);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, false);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, true);
        }

        private void TestLevel5(IPlanet hp)
        {
            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, true);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, false);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, false);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, true);
        }

        private void TestLevel7(IPlanet hp)
        {
            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, true);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, true);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, false);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, true);
        }

        private void TestLevel8(IPlanet hp)
        {
            IsFacilityAvailableForBuild(hp, CommandCenter.Resource, true);
            IsFacilityAvailableForBuild(hp, SolarPanel.Resource, true);
            IsFacilityAvailableForBuild(hp, SeriumExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, Silo.Resource, true);
            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, true);
            IsFacilityAvailableForBuild(hp, MithrilExtractor.Resource, true);
            IsFacilityAvailableForBuild(hp, BlinkerAssembler.Resource, true);
            IsFacilityAvailableForBuild(hp, UnitYard.Resource, true);
        }

        private void IsFacilityAvailableForBuild(IPlanet hp, IFacilityInfo info, bool expected)
        {
            bool available = hp.IsBuildAvailable(info);

            Assert.AreEqual(expected, available, "Facility {0} Available For Build", info.Name);
        }

        private void IsFacilityAvailable(IPlanet hp, IResourceInfo info, bool expected)
        {
            bool available = hp.IsResourceAvailable(info, 1);

            Assert.AreEqual(expected, available, "Facility {0} Available", info.Name);
        }

        #endregion Light Humans

        #region Cost

        [Test]
        public void Test_SolarPanel_Cost()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Test_SolarPanel_Cost", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            planet.SetQuantity(Energy.Resource, 1000);
            planet.SetQuantity(Serium.Resource, 1000);

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;

            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "We should be able to buy Solar panel");

            planet.Enqueue(newResource);

            Assert.AreEqual(980, planet.GetQuantity(Energy.Resource), "Energy cost not taken");
            Assert.AreEqual(880, planet.GetQuantity(Serium.Resource), "Serium cost not taken");
        }

        #endregion Cost

        #region Destroy

        [Test]
        public void Test_SolarPanel_Destroy()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Test_SolarPanel_Destroy", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            IResourceInfo facility = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");

            int initialModifiers = planet.GetModifier(Energy.Resource);

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;
            planet.AddResource(newResource);

            newResource.OnComplete();

            Assert.Greater(planet.GetModifier(Energy.Resource), initialModifiers, "There should be modifiers");

            planet.Destroy(newResource);

            Assert.AreEqual(initialModifiers, planet.GetModifier(Energy.Resource), "We should have the previous modifier");
        }

        #endregion Destroy

        #region Player Level

        [Test]
        public void TestExtractorBuildWhenUpgradingCC()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestExtractorBuildWhenUpgradingCC", RaceInfo.Get(Race.LightHumans));
            IPlanetInfo planetInfo = PlanetInfo.Get("LightHumansPrivatePlanet");
            IFacilitySlot cc = planetInfo.GetSlot("CommandCenter");

            for (int i = 0; i < PlanetUtils.TotalPlanetsPerPrivateZone - 1; ++i) {
                Planet planet = new Planet(planetInfo, TerrainInfo.Get(Terrain.Desert));
                player.RegisterPlanet(planet);
                ResourceUtils.Initialize(planet);
            }

            Assert.AreEqual(5, player.Planets.Count);

            foreach (IPlanet planet in player.Planets) {
                IFacilityInfo facilityInfo = planet.Info.GetMainFacility();
                IPlanetResource resource = planet.GetResource(facilityInfo);
                resource.State = ResourceState.Running;
                resource.Level = 2;
                resource.Slot = cc;
            }

            Clock.Instance.Advance();
            GameEngine.ProcessPlayer(player);
            Assert.AreEqual(2, player.PlanetLevel, "Player level should be 2");

            IPlanet hp = player.GetHomePlanet();
            IFacilityInfo mf = hp.Info.GetMainFacility();
            IPlanetResource res = hp.GetResource(mf);

            res.State = ResourceState.InConstruction;
            res.Level = 3;
            res.EndTick = int.MaxValue;

            Clock.Instance.Advance();
            GameEngine.ProcessPlayer(player);
            Assert.AreEqual(2, player.PlanetLevel, "Player level should be 2");
        }

        #endregion Player Level

        #region Steal Resources

        [Test]
        public void TestStealResources()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestStealResources", race);
            IPlanet planet = player.GetHomePlanet();

            player.SetQuantity(race.RichResource, 1000);
            planet.Level = 1;

            IList<IResourceQuantity> stolen = planet.StealResources();

            Assert.AreEqual(967, player.GetQuantity(race.RichResource));
            Assert.AreEqual(33, stolen[0].Quantity);
            Assert.AreEqual(race.RichResource, stolen[0].Resource);
        }

        #endregion Steal Resources

        #region Immunities

        [Ignore]
        public void TestConquerImmunity()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestConquerImmunity", race);
            IPlanet planet = player.GetHomePlanet();

            Assert.IsTrue(planet.CanConquer);

            planet.LastConquerTick = Clock.Instance.Tick;

            for (int i = 0; i < PlanetUtils.PlanetConquerDelay; ++i) {
                Assert.IsFalse(planet.CanConquer);
                Clock.Instance.Advance();
            }

            Assert.IsTrue(planet.CanConquer);
        }

        [Test]
        public void TestPillageImmunity()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestPillageImmunity", race);
            IPlanet planet = player.GetHomePlanet();

            Assert.IsTrue(planet.CanPillage);

            planet.LastPillageTick = Clock.Instance.Tick;

            for (int i = 0; i < PlanetUtils.PlanetPillageDelay; ++i) {
                Assert.IsFalse(planet.CanPillage);
                Clock.Instance.Advance();
            }

            Assert.IsTrue(planet.CanPillage);
        }

        [Test]
        public void TestPillageValueWhenImmunity()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestPillageValueWhenImmunity", race);
            IPlanet planet = player.GetHomePlanet();

            player.AddQuantity(race.RichResource, 1000);

            planet.LastPillageTick = Clock.Instance.Tick;

            planet.StealResources();

            Assert.AreEqual(1000, player.GetQuantity(race.RichResource));
        }

        [Test]
        public void TestPillageUpdateTick()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestPillageUpdateTick", race);
            IPlanet planet = player.GetHomePlanet();

            player.AddQuantity(race.RichResource, 5000);

            planet.StealResources();
            Assert.AreEqual(Clock.Instance.Tick, planet.LastPillageTick);
            Assert.IsFalse(planet.CanPillage);
        }

        #endregion Immunities

        #region Fleet Interaction

        [Test]
        public void TestUnloadCargo()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestUnloadCargo", race);
            IPlanet planet = player.GetHomePlanet();
            IFleetInfo fleet = planet.DefenseFleet;
            fleet.AddCargo(new ResourceQuantity(Argon.Resource, 10));
            Assert.IsTrue(fleet.HasCargo);

            int before = player.GetQuantity(Argon.Resource);

            PlanetUtils.UnloadCargo(planet, fleet);

            Assert.AreEqual(before +10, player.GetQuantity(Argon.Resource));
            Assert.IsFalse(fleet.HasCargo);
        }

        [Test]
        public void TestUnloadCargo_WithSupplies()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestUnloadCargo_WithSupplies", race);
            IPlanet planet = player.GetHomePlanet();
            IFleetInfo fleet = planet.DefenseFleet;
            fleet.AddCargo(new ResourceQuantity(Argon.Resource, 10));
            fleet.AddCargo(new ResourceQuantity(Supplies.Resource, 12));
            Assert.IsTrue(fleet.HasCargo);

            int before = player.GetQuantity(Argon.Resource);

            PlanetUtils.UnloadCargo(planet, fleet);

            Assert.AreEqual(before + 10, player.GetQuantity(Argon.Resource));
            Assert.IsTrue(fleet.HasCargo);
            Assert.AreEqual(12, fleet.Cargo[Supplies.Resource]);
            Assert.AreEqual(0, planet.GetQuantity(Supplies.Resource));
        }

        [Test]
        public void TestDropTradeCargo(){
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "TestDropTradeCargo", race);
            IPlanet planet = player.GetHomePlanet();
            IFleetInfo fleet = planet.DefenseFleet;

            fleet.AddCargo(new ResourceQuantity(Argon.Resource, 12));
            fleet.AddCargo(new ResourceQuantity(Alcohol.Resource, 10));
            Assert.IsTrue(fleet.HasCargo);

            Assert.AreEqual(2, fleet.Cargo.Count);
            Assert.AreEqual(10, fleet.GetCargoQuantity(Alcohol.Resource));
            Assert.AreEqual(12, fleet.GetCargoQuantity(Argon.Resource));
            
            PlanetUtils.DropTradeCargo(fleet);
                        
            Assert.AreEqual(1, fleet.Cargo.Count);
            Assert.AreEqual(0,fleet.GetCargoQuantity(Alcohol.Resource));
            Assert.AreEqual(12, fleet.GetCargoQuantity(Argon.Resource));

            Assert.IsTrue(fleet.HasCargo);
        }

        #endregion Fleet Interaction

        #region Ultimate Upgrade

        [Test]
        public void LightHumans_UltimateWeapon_Upgrade_Test()
        {
            IRaceInfo race = RaceInfo.Get(Race.LightHumans);
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "LightHumans_DSSUpgradeTest", race);
            AddResources(player);

            IPlanet hp = player.GetHomePlanet();
            UpgradeCommandCenterToLevel7(hp);

            IsFacilityAvailableForBuild(hp, DeepSpaceScanner.Resource, true);

            Assert.AreEqual(0, player.UltimateWeaponLevel, 0);
            BuildDSS(player, hp);
            Assert.AreEqual(1, player.UltimateWeaponLevel, 1);
            UpgradeDSS(player, hp);
            Assert.AreEqual(2, player.UltimateWeaponLevel, 2);
        }

        private static void AddResources(IPlayer player){
            player.AddToLimit(null, 200000);
            player.AddQuantity(Energy.Resource, 200000);
            player.AddQuantity(Serium.Resource, 200000);
            player.AddQuantity(Mithril.Resource, 200000);
            player.AddQuantity(Argon.Resource, 200000);
            player.AddQuantity(Prismal.Resource, 200000);
            player.AddQuantity(Astatine.Resource, 200000);
            player.AddQuantity(Radon.Resource, 200000);
            GameEngine.Persist(player);
        }

        public void BuildDSS(IPlayer player, IPlanet planet){
            IResourceInfo facility = DeepSpaceScanner.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("DeepSpaceScanner");

            IPlanetResource newResource = PlanetResource.Create(facility, 1);
            newResource.Slot = slot;
            
            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build dss: {0}", result.Log());

            planet.Enqueue(newResource);
            
            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i){
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);
            Assert.IsNotNull(resource, "There is no DSS");
            Assert.AreEqual(slot.Identifier, resource.Slot.Identifier, "Invalid slot");
            Assert.AreEqual(1, resource.Quantity, "Invalid quantity");
            Assert.AreEqual(ResourceState.Running, resource.State, "Invalid State");
            Assert.AreEqual(1, resource.Level, "Invalid level");
        }

        public void UpgradeDSS(IPlayer player, IPlanet planet){
            IResourceInfo facility = DeepSpaceScanner.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("DeepSpaceScanner");
            IPlanetResource newResource = planet.GetFacility(slot);

            newResource.Level = 2;
            
            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "Need to build dss: {0}", result.Log());

            planet.Enqueue(newResource);

            GameEngine.Persist(planet);

            int buildTime = facility.GetBuildDuration(planet, newResource);
            for (int i = 0; i < buildTime * 2; ++i)
            {
                Clock.Instance.Advance();
            }

            GameEngine.ProcessPlayer(player);

            IPlanetResource resource = planet.GetFacility(slot);
            Assert.IsNotNull(resource, "There is no DSS");
            Assert.AreEqual(slot.Identifier, resource.Slot.Identifier, "Invalid slot");
            Assert.AreEqual(1, resource.Quantity, "Invalid quantity");
            Assert.AreEqual(ResourceState.Running, resource.State, "Invalid State");
            Assert.AreEqual(2, resource.Level, "Invalid level");
        }

        private void UpgradeCommandCenterToLevel7(IPlanet hp){
            TestLevel1(hp);

            ChangeCommandCenterLevel(hp, 2);
            TestLevel2(hp);

            ChangeCommandCenterLevel(hp, 3);
            TestLevel2(hp); // no changes

            ChangeCommandCenterLevel(hp, 4);
            TestLevel4(hp);

            ChangeCommandCenterLevel(hp, 5);
            TestLevel5(hp);

            ChangeCommandCenterLevel(hp, 6);
            TestLevel5(hp); // no changes

            ChangeCommandCenterLevel(hp, 7);
            TestLevel7(hp);
        }

        #endregion

    };
}