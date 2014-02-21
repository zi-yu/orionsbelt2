using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.RulesCore.Common;
using System;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.Engine;
using OrionsBeltTests.EngineTests;

namespace OrionsBeltTests.RulesTests {

    [TestFixture]
    public class UniverseInfoTests : BaseTests {

        #region Terrain

        [Test]
        public void TestTerrain_Creation()
        {
            foreach(Terrain terrain in Enum.GetValues(typeof(Terrain))) {
                ITerrainInfo info = TerrainInfo.Get(terrain);
                Assert.AreEqual(terrain, info.Terrain);
            }
        }

        [Test]
        public void TestTerrain_Richness()
        {
            foreach(Terrain terrain in Enum.GetValues(typeof(Terrain))) {
                ITerrainInfo info = TerrainInfo.Get(terrain);
				foreach (IIntrinsicInfo intrinsic in RulesUtils.GetIntrinsicResources()){
					int richness = info.GetRichness(intrinsic);
                    if (!intrinsic.IsResourceCost) {
                        Assert.AreEqual(richness, 0, "Terrain:{0} Resource:{1}", terrain, intrinsic.Name);
                    }
				}
            }
        }

        #endregion Terrain

        #region Race

        [Test]
        public void TestRace_Creation()
        {
            foreach(Race race in Enum.GetValues(typeof(Race))) {
                if (race == Race.None || race == Race.Global) {
                    continue;
                }
                if (RaceInfo.IsMob(race)){
                    continue;
                }

                IRaceInfo info = RaceInfo.Get(race);
                Assert.AreEqual(race, info.Race);
            }
        }

        [Test]
        public void TestRace_Richness()
        {
            
        }

        #endregion Terrain

        #region PlanetInfos

        [Test]
        public void TestPlanetInfos_ShortIdentifier_Uniqueness()
        {
            Dictionary<string, bool> dic = new Dictionary<string, bool>();
            foreach (IPlanetInfo info in PlanetInfo.GetAllPlanetInfos()) {
                Assert.IsFalse(dic.ContainsKey(info.ShortIdentifier));
                dic.Add(info.ShortIdentifier, true);
            }
        }

        [Test]
        public void TestFacilitySlots_Uniqueness()
        {
            Dictionary<string, IFacilitySlot> infos = new Dictionary<string, IFacilitySlot>();
            foreach (IPlanetInfo info in PlanetInfo.GetAllPlanetInfos()) {
                foreach (IFacilitySlot slot in info.FacilitySlots) {
                    if (infos.ContainsKey(slot.Identifier)) {
                        Assert.Fail("We need unique slot identifier per PlanetInfo, `{0}' is duplicated", slot.Identifier);
                    }
                    infos.Add(slot.Identifier, slot);
                }
                infos.Clear();
            }
        }

        [Test]
        public void TestPlanetAvailable_LightHumansPrivatePlanet()
        {
            IPlayer player = EngineUtils.EmptyPlayer;
            player.RaceInfo = RaceInfo.Get(Race.LightHumans);
            Assert.IsNotNull(PlanetInfo.GetRandomPrivateZone(player));
        }

        #endregion PlanetInfos

    };
}