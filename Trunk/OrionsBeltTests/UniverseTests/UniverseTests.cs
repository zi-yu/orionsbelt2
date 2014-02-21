using System;
using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBeltTests.EngineTests;

namespace OrionsBeltTests.UniverseTests {

	[TestFixture]
	public class UniverseTests : BaseTests {

		#region Private

		private static IEnumerable<Coordinate> GenerateCoordinates(int xSize, int ySize) {
			for (int x = 1; x <= xSize; ++x) {
				for (int y = 1; y <= ySize; ++y) {
					yield return new Coordinate(x, y);
				}
			}
		}



		private Principal CreatePrincipal(int id, string name, int rank) {
			using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance()) {
				Principal p = persistance.Create();
				p.Id = id;
				p.Name = name;
				p.EloRanking = rank;
				persistance.Update(p);
				return p;
			}
		}

		#endregion Private

		[Test]
		public void CreationTest() {

			Assert.AreEqual(80, UniverseCreation.AddedWormHoles.Count);

			Assert.IsTrue(UniverseCreation.AddedWormHoles.Contains(new Coordinate(1, 1)));
			Assert.IsTrue(UniverseCreation.AddedWormHoles.Contains(new Coordinate(7, 1)));
			Assert.IsTrue(UniverseCreation.AddedWormHoles.Contains(new Coordinate(25, 25)));
			Assert.IsTrue(UniverseCreation.AddedWormHoles.Contains(new Coordinate(31, 13)));
		}

		[Test]
		public void CountSystemsTest() {
			Dictionary<int,int> systemLevelCount = new Dictionary<int, int>();

			foreach (Coordinate coordinate in GenerateCoordinates(37,37)) {
				ISystem system = Universe.GetSystem(coordinate);
				if( !systemLevelCount.ContainsKey(system.Level)) {
					systemLevelCount.Add(system.Level,0);
				}
				systemLevelCount[system.Level] += 1;
			}

			Assert.AreEqual(408, systemLevelCount[1]);
			Assert.AreEqual(336, systemLevelCount[3]);
			Assert.AreEqual(264, systemLevelCount[5]);
			Assert.AreEqual(192, systemLevelCount[7]);
			Assert.AreEqual(120, systemLevelCount[9]);
			Assert.AreEqual(49, systemLevelCount[10]);
		}

		[Test]
		public void CountSectorsTest() {

			Dictionary<int, int> sectorLevelCount = new Dictionary<int, int>();

			foreach (Coordinate coordinate in GenerateCoordinates(37, 37)) {
				ISystem system = Universe.GetSystem(coordinate);
                foreach (Coordinate sectorCoordinate in GenerateCoordinates(7, 10)) {
					ISector sector = system.GetSector(sectorCoordinate);
					if (!sectorLevelCount.ContainsKey(sector.Level)) {
						sectorLevelCount.Add(system.Level, 0);
					}
					sectorLevelCount[system.Level] += 1;
				}
			}

			Assert.AreEqual(28560, sectorLevelCount[1]);
			Assert.AreEqual(23520, sectorLevelCount[3]);
			Assert.AreEqual(18480, sectorLevelCount[5]);
			Assert.AreEqual(13440, sectorLevelCount[7]);
			Assert.AreEqual(8400, sectorLevelCount[9]);
			Assert.AreEqual(3430, sectorLevelCount[10]);
		}

		[Test]
		public void PlanetCount() {
			int planetCount = 0;
			foreach (Coordinate coordinate in GenerateCoordinates(37, 37)) {
				ISystem system = Universe.GetSystem(coordinate);
				foreach( Sector sector in system.Sectors.Values ) {
					if( sector is PlanetSector ) {
						++planetCount;		
					}
				}
			}

			Console.WriteLine("Planets: {0}",planetCount);
		}

		//[Test]
		//public void CreatePrivateUniverse() {
		//    IPlayer player = EngineUtils.EmptyPlayer;
		//    UniverseCreation.CreatePrivateUniverse(player);

		//    OrionsBelt.Engine.Universe.System s = Universe.GetPrivateSystem(player);
		//    Assert.IsNotNull(s);

		//    Coordinate homePlanet = new Coordinate(2,2);

		//    Assert.Greater(player.HomePlanetId, 0);

		//    Sector sector = s.GetSector(homePlanet);
		//    Assert.IsTrue( sector is PlanetSector);
		//    Assert.AreEqual(2,sector.CelestialBodies.Count);
			
		//    PlanetSector planetSector = (PlanetSector)sector;
		//    IPlanet planet = planetSector.GetPlanet();

		//    planet.UpdateStorage();
			
		//    Assert.AreEqual(player.HomePlanetId, planet.Storage.Id);

		//}

		public UniverseTests() {
            if (Universe.AllUniverse.Count==0){
			    UniverseCreation.CreateTestUniverse(37, 37);
			    Universe.LoadUniverse();
            }
		}

	}
}
