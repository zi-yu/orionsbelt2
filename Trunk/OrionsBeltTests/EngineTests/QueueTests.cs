using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Races;
using System.Collections.Generic;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class QueueTests : BaseTests {

        #region Generic Tests

        [Test]
        public void CanQueueTest_Basic_EmptyPlanet()
        {
            Planet planet = EngineUtils.EmptyPlayerPlanet;
            planet.AddQuantity(Gold.Resource, 100);
            planet.AddQuantity(Titanium.Resource, 100);
            Result result = planet.CanQueue(PlanetResource.Create(planet, typeof(DarknessHall), 1));
            Assert.IsTrue(result.Ok, "Unexpected CanQueue Error: Space:{0} {1}", planet.TotalQueueSpace, result.Log());
        }

        [Test]
        public void CanQueueTest_Basic_RichPlanet()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            planet.AddQuantity(Gold.Resource, 100);
            planet.AddQuantity(Titanium.Resource, 100);
            Result result = planet.CanQueue(PlanetResource.Create(planet, typeof(DarknessHall), 1));
            Assert.IsTrue(result.Ok, "Unexpected CanQueue Error: Space:{0} {1}", planet.TotalQueueSpace, result.Log());
        }

        [Test]
        public void CanQueueTest_ResourceState()
        {
            ResourceStateVerification(ResourceState.InQueue, false);
            ResourceStateVerification(ResourceState.InConstruction, false);
            ResourceStateVerification(ResourceState.Complete, false);
            ResourceStateVerification(ResourceState.UnAvailable, false);

            ResourceStateVerification(ResourceState.Available, true);
            ResourceStateVerification(ResourceState.Running, true);
        }

        private static void ResourceStateVerification(ResourceState state, bool expected)
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            planet.AddQuantity(Gold.Resource, 100);
            planet.AddQuantity(Titanium.Resource, 100);
            IPlanetResource res = PlanetResource.Create(planet, typeof(DarknessHall), 1);
            res.State = state;
            Result result = planet.CanQueue(res);
            Assert.AreEqual(expected, result.Ok, "Unexpected CanQueue Error: State:{2} Space:{0} {1}", planet.TotalQueueSpace, result.Log(), state);
        }

        [Test]
        public void TestEnqueue()
        {
            Planet planet = EngineUtils.EmptyPlayerPlanet;
            planet.SetQuantity(QueueSpace.Resource, 2);
            planet.SetQuantity(Gold.Resource, 1000);
            planet.SetQuantity(Titanium.Resource, 1000);

            Enqueue(planet, DarknessHall.Resource, 1);
            Enqueue(planet, DarknessHall.Resource, 1);

            PlanetResource res = PlanetResource.Create(planet, DarknessHall.Resource, 1);
            int usedQueueSpace = planet.GetUsedQueueSpace(ResourceType.Facility);

            Result result = planet.CanQueue(res);
            Assert.IsFalse(result.Ok, "There should be NO queue space to queue. QueueSpace: {0} {1}", planet.TotalQueueSpace, result.Log());
        }

        private IPlanetResource Enqueue(Planet planet, IResourceInfo info, int quantity)
        {
            return Enqueue(planet, info, quantity, null);
        }

        private IPlanetResource Enqueue(Planet planet, IResourceInfo info, int quantity, IFacilitySlot slot)
        {
            PlanetResource res = PlanetResource.Create(info, quantity);
            res.Slot = slot;
            res.State = ResourceState.Running;
            int usedQueueSpace = planet.GetUsedQueueSpace(info.Type);

            Result result = planet.CanQueue(res);
            Assert.IsTrue(result.Ok, "There should exist queue space to queue. QueueSpace: {0} {1}", planet.TotalQueueSpace, result.Log());
            IPlanetResource queued = planet.Enqueue(res);

            Assert.AreEqual(usedQueueSpace + 1, planet.GetUsedQueueSpace(info.Type), "Queued a resource but que count is the same");

            return queued;
        }

        private IPlanetResource Enqueue(Planet planet, IPlanetResource res, int level)
        {
            res.Level = level;
            int usedQueueSpace = planet.GetUsedQueueSpace(res.Info.Type);

            Result result = planet.CanQueue(res);
            Assert.IsTrue(result.Ok, "There should exist queue space to queue. QueueSpace: {0} {1}", planet.TotalQueueSpace, result.Log());
            IPlanetResource queued = planet.Enqueue(res);

            Assert.AreEqual(usedQueueSpace + 1, planet.GetUsedQueueSpace(res.Info.Type), "Queued a resource but que count is the same");
            return queued;
        }

        [Test]
        public void Test_Order_Basic()
        {
            Planet planet = EngineUtils.EmptyPlayerPlanet;
            planet.Info = PlanetInfo.Get("LightHumansPrivatePlanet");
            planet.SetQuantity(QueueSpace.Resource, 100);
            planet.AddQuantity(Energy.Resource, 100000);
            planet.AddQuantity(Mithril.Resource, 100000);
            planet.AddQuantity(Serium.Resource, 100000);
            planet.AddQuantity(Radon.Resource, 100000);
            planet.AddQuantity(Argon.Resource, 100000);
            planet.AddQuantity(Astatine.Resource, 100000);

            planet.AddFacility("UnitYard", UnitYard.Resource);
            IPlanetResource resource = planet.GetFacility(planet.Info.GetSlot("UnitYard"));
            resource.Level = 500;

            Enqueue(planet, Crusader.Resource, 1);
            Enqueue(planet, Crusader.Resource, 2);
            Enqueue(planet, Pretorian.Resource, 3);

            Assert.AreEqual(0, planet.GetQuantity(Crusader.Resource), "There should be 0 crusaders");
            Assert.AreEqual(0, planet.GetQuantity(Pretorian.Resource), "There should be 0 Pretorian");
            Assert.AreEqual(0, planet.GetQueueList(ResourceType.Facility).Count, "Facility queue should be empty");
            Assert.AreEqual(0, planet.GetQueueList(ResourceType.Intrinsic).Count, "Intrinsic queue should be empty");
            Assert.AreEqual(3, planet.GetQueueList(ResourceType.Unit).Count, "Invalid queue count");

            IList<IPlanetResource> list = planet.GetQueueList(ResourceType.Unit);
            for(int i = 0; i < 3; ++i ) {
                Assert.AreEqual(i+1, list[i].Quantity, "Error in queue order");
            }
        }

        [Test]
        public void Dequeue_Basic()
        {
            Planet planet = EngineUtils.EmptyPlayerPlanet;
            planet.AddQuantity(Gold.Resource, 100);
            planet.AddQuantity(Titanium.Resource, 100);
            planet.SetQuantity(QueueSpace.Resource, 2);

            IPlanetResource res1 = Enqueue(planet, DarknessHall.Resource, 1);
            Assert.AreEqual(1, planet.GetUsedQueueSpace(ResourceType.Facility), "Invalid queue count");

            planet.Dequeue(res1);
            Assert.AreEqual(0, planet.GetUsedQueueSpace(ResourceType.Facility), "Invalid queue count");            
        }

        [Test]
        public void GetNextResourceToProduction_Test()
        {
            Planet planet = EngineUtils.EmptyPlayerPlanet;
            planet.Info = PlanetInfo.Get("LightHumansPrivatePlanet");
            planet.SetQuantity(QueueSpace.Resource, 100);
            planet.AddQuantity(Energy.Resource, 100000);
            planet.AddQuantity(Mithril.Resource, 100000);
            planet.AddQuantity(Serium.Resource, 100000);
            planet.AddQuantity(Radon.Resource, 100000);
            planet.AddQuantity(Argon.Resource, 100000);
            planet.AddQuantity(Astatine.Resource, 100000);

            planet.AddFacility("UnitYard", UnitYard.Resource);
            IPlanetResource resource = planet.GetFacility(planet.Info.GetSlot("UnitYard"));
            resource.Level = 500;

            Enqueue(planet, Crusader.Resource, 2);
            Enqueue(planet, Pretorian.Resource, 3);

            Assert.AreEqual(Crusader.Resource, QueueUtils.GetNextResourceToProduction(planet, ResourceType.Unit).Info, "Wrong queue to production order");

        }

        #endregion Generic Tests

        #region Facility Slot Tests

        [Test]
        public void FacilitySlot_Dequeue()
        {
            IPlayer player = GameEngine.CreatePlayer(EngineUtils.NewPrincipal, "Facility_Slot_Dequeue", RaceInfo.Get(Race.LightHumans));
            IPlanet planet = player.GetHomePlanet();
            planet.AddQuantity(Energy.Resource, 1000);
            planet.AddQuantity(Serium.Resource, 1000);
            IResourceInfo info = SolarPanel.Resource;
            IFacilitySlot slot = planet.Info.GetSlot("Resource1");
            
            IPlanetResource newResource = PlanetResource.Create(info, 1);
            newResource.Slot = slot;
            
            Result result = planet.CanQueue(newResource);
            Assert.IsTrue(result.Ok, "We need to be able to build the facility : {0}", result.Log());
            planet.Enqueue(newResource);
            GameEngine.Persist(planet);

            IPlanetResource queuedResource = planet.GetQueueList(ResourceType.Facility)[0];
            planet.Dequeue(queuedResource);
            GameEngine.Persist(planet);

            IPlanetResource resource = planet.GetFacility(slot);
            Assert.IsNull(resource, "There should be no resource");
        }

        #endregion Facility Slot Tests

    };
}