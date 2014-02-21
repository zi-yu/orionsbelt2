using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ResourceTests: BaseTests {

        #region Tests

        [Test]
        public void TestResourceStateParsing()
        {
            foreach (ResourceState state in Enum.GetValues(typeof(ResourceState))) {
                ResourceState parsed = ResourceUtils.GetState(state.ToString());
                Assert.AreEqual(state, parsed, "Error getting state. Expecing: {0}, got {1}", state, parsed);
            }
        }

        #endregion Tests

        #region Sanity Tests

        [Test]
        public void ResourceCount()
        {
            Assert.AreEqual(172, RulesUtils.TotalResourceCount, "Invalid TotalResourceCount");
            Assert.AreEqual(23, RulesUtils.TotalFacilityCount, "Invalid TotalFacilityCount");
            Assert.AreEqual(53, RulesUtils.TotalUnitCount, "Invalid TotalUnitCount");
            Assert.AreEqual(96, RulesUtils.TotalIntrinsicCount, "Invalid TotalIntrinsicCount");

            Assert.AreEqual(RulesUtils.TotalResourceCount, 
                RulesUtils.TotalUnitCount + RulesUtils.TotalIntrinsicCount + RulesUtils.TotalFacilityCount,
                RulesUtils.TotalResourceCount
                , "All resources count don't match");
        }

        [Test]
        public void ResourceNames()
        {
            foreach (IResourceInfo info in RulesUtils.GetResources()) {
                IResourceInfo byName = RulesUtils.GetResource(info.Name);
                Assert.IsNotNull(byName, "Resource {0} is Null from GetResource", info.Name);
                
                if (byName is IFacilityInfo) {
                    Assert.IsNotNull(RulesUtils.GetFacility(byName.Name), "Resource {0} is facility but is not recognized by GetFacility");
                }
                if (byName is IUnitInfo) {
                    Assert.IsNotNull(RulesUtils.GetUnit(byName.Name), "Resource {0} is unig but is not recognized by GetUnit");
                }
                if (byName is IIntrinsicInfo) {
                    Assert.IsNotNull(RulesUtils.GetIntrinsic(byName.Name), "Resource {0} is intrinsic but is not recognized by GetIntrinsic");
                }
            }
        }

        [Test]
        public void ResourceComparison()
        {
            // chek if works for true
            foreach (IResourceInfo info in RulesUtils.GetResources()) {
                Assert.IsTrue(info.Equals(RulesUtils.GetResource(info.Name)), "Equals failed for the same resource");
            }
            //check if works for false
            foreach (IResourceInfo info in RulesUtils.GetFacilityResources()) {
                foreach (IResourceInfo other in RulesUtils.GetIntrinsicResources()) {
                    Assert.IsFalse(info.Equals(other), "Equals returned true for two diferent resources");
                }
            }

        }

        #endregion Sanity Tests

        #region Ownership Tests

        [Test]
        public void CheckUnitOwnership()
        {
            CheckResourceOwnership(RulesUtils.GetRandomUnit(), false);
        }

        [Test]
        public void CheckFacilityOwnership()
        {
            CheckResourceOwnership(RulesUtils.GetRandomFacility(), false);
        }

        [Test]
        public void CheckIntrinsicOwnership()
        {
            CheckResourceOwnership(RulesUtils.GetRandomIntrinsic(), true);
        }

        private static void CheckResourceOwnership(IResourceInfo info, bool ruler)
        {
            Player player = new Player();
            Planet planet = new Planet(player, "Zen");
            PlanetResource res = new PlanetResource(planet, info);

            if (ruler){
                Assert.AreEqual(player, ResourceUtils.ResolveOwner(planet, info.Type));
            } else {
                Assert.AreEqual(planet, ResourceUtils.ResolveOwner(planet, info.Type));
            }
        }

        #endregion Ownership Tests

        #region IsTradeRouteSpecific

        [Test]
        public void TestIsTradeRouteSpecific()
        {
            Assert.IsTrue(Tools.Resource.IsTradeRouteSpecific);
            Assert.IsTrue(Supplies.Resource.IsTradeRouteSpecific);

            Assert.IsFalse(Crusader.Resource.IsTradeRouteSpecific);
            Assert.IsFalse(CommandCenter.Resource.IsTradeRouteSpecific);
            Assert.IsFalse(Argon.Resource.IsTradeRouteSpecific);
            Assert.IsFalse(Serium.Resource.IsTradeRouteSpecific);
        }


        #endregion IsTradeRouteSpecific

        #region PlayerResources

        [Test]
        public void PlayerResourcesCtor()
        {
            PlayersResources data = new PlayersResources(1, "xpto", "Serium:19062;Astatine:15127;Energy:6314;QueueSpace:1;Protol:69;Gold:112;Titanium:0;ProductionSpace:1;Uranium:22;Argon:731;Radon:462;Cryptium:2954;Elk:84;Prismal:2539;Mithril:14107;");
            Assert.AreEqual(19062, data.Serium);
            Assert.AreEqual(15127, data.Astatine);
            Assert.AreEqual(6314, data.Energy);
            Assert.AreEqual(1, data.QueueSpace);
            Assert.AreEqual(69, data.Protol);
            Assert.AreEqual(112, data.Gold);
            Assert.AreEqual(0, data.Titanium);
            Assert.AreEqual(1, data.ProductionSpace);
            Assert.AreEqual(22, data.Uranium);
            Assert.AreEqual(731, data.Argon);
            Assert.AreEqual(462, data.Radon);
            Assert.AreEqual(2954, data.Cryptium);
            Assert.AreEqual(84, data.Elk);
            Assert.AreEqual(2539, data.Prismal);
            Assert.AreEqual(14107, data.Mithril);
        }

        #endregion PlayerResources

    };
}