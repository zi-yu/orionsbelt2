using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBeltTests.UniverseTests {

	[TestFixture]
	public class CoordinateTests {

		[Test]
		public void LowerTestCoordinate() {
			Coordinate c1 = new Coordinate(5, 20);
			Coordinate c2 = new Coordinate(10, 20);

			Assert.IsTrue(c1 < c2);

			c1 = new Coordinate(20, 10);

			Assert.IsFalse(c1 < c2);

			c2 = new Coordinate(20, 11);

			Assert.IsTrue(c1 < c2);
		}

		[Test]
		public void UpperTestCoordinate() {
			Coordinate c1 = new Coordinate(5, 20);
			Coordinate c2 = new Coordinate(10, 20);

			Assert.IsTrue(c2 > c1);

			c1 = new Coordinate(20, 10);

			Assert.IsFalse(c2 > c1);

			c2 = new Coordinate(20, 11);

			Assert.IsTrue(c2 > c1);

		}

		[Test]
		public void EqualTestCoordinate() {
			Coordinate c1 = new Coordinate(10, 20);
			Coordinate c2 = new Coordinate(10, 20);

			Assert.IsTrue(c1 == c2);

			c1 = new Coordinate(20, 10);

			Assert.IsFalse(c1 == c2);
		}

		[Test]
		public void DifferentTestCoordinate() {
			Coordinate c1 = new Coordinate(5, 20);
			Coordinate c2 = new Coordinate(10, 20);

			Assert.IsTrue(c1 != c2);

			c1 = new Coordinate(20, 10);

			Assert.IsTrue(c1 != c2);

			c1 = new Coordinate(10, 20);

			Assert.IsFalse(c1 != c2);
		}

		[Test]
		public void HammingDistanceBetweenSectors() {
			List<CoordinateDistance> coordinates = new List<CoordinateDistance>(8);

			Coordinate destinySector = new Coordinate(4,2);
			Coordinate destinySystem = new Coordinate(11, 11);

			Coordinate system11_10 = new Coordinate(11, 10);
			Coordinate system12_10 = new Coordinate(12, 10);
			Coordinate system12_11 = new Coordinate(12, 11);

			coordinates.Add(new CoordinateDistance(system11_10, new Coordinate(7, 9), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system11_10, new Coordinate(7, 10), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(7, 1), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system12_10, new Coordinate(1, 9), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system12_10, new Coordinate(2, 9), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system12_10, new Coordinate(2, 10), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system12_11, new Coordinate(2, 1), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(system12_11, new Coordinate(1, 1), destinySystem, destinySector));

			coordinates.Sort(new HammingDistanceComparer());

			Assert.AreEqual(7,coordinates[0].CurrentSector.X);
			Assert.AreEqual(1,coordinates[0].CurrentSector.Y);
			Assert.AreEqual(11,coordinates[0].CurrentSystem.X);
			Assert.AreEqual(11,coordinates[0].CurrentSystem.Y);

			Assert.AreEqual(0, coordinates[0].HammingSystemDistance);
			Assert.AreEqual(3.1622776601683795d, coordinates[0].HammingSectorDistance);

			Assert.AreEqual(10,coordinates[1].HammingSystemDistance);
			Assert.AreEqual(1,coordinates[1].HammingSectorDistance);

			Assert.AreEqual(10,coordinates[2].HammingSystemDistance);
			Assert.AreEqual(2,coordinates[2].HammingSectorDistance);
		}

		[Test]
		public void HammingDistanceInSameSectors() {
			List<CoordinateDistance> coordinates = new List<CoordinateDistance>(8);

			Coordinate destinySector = new Coordinate(4, 2);
			Coordinate destinySystem = new Coordinate(11, 11);

			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(5, 1), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(5, 2), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(5, 3), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(6, 1), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(6, 3), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(7, 1), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(7, 2), destinySystem, destinySector));
			coordinates.Add(new CoordinateDistance(destinySystem, new Coordinate(7, 3), destinySystem, destinySector));

			coordinates.Sort(new HammingDistanceComparer());

			Assert.AreEqual(5, coordinates[0].CurrentSector.X);
			Assert.AreEqual(2, coordinates[0].CurrentSector.Y);
			
			Assert.AreEqual(0, coordinates[0].HammingSystemDistance);
			Assert.AreEqual(1, coordinates[0].HammingSectorDistance);

			Assert.AreEqual(0, coordinates[1].HammingSystemDistance);
			Assert.AreEqual(1.4142135623730952d, coordinates[1].HammingSectorDistance);

			Assert.AreEqual(0, coordinates[2].HammingSystemDistance);
			Assert.AreEqual(1.4142135623730952d, coordinates[2].HammingSectorDistance);
		}

		[Test]
		public void SectorNeighbourTest() {
			Coordinate sector = new Coordinate(2, 2);
			SectorCoordinate current = new SectorCoordinate(1, 1, 2, 2);

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(current);

			SectorCoordinate newCurrent = coordinates[0];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(1, newCurrent.Sector.X);
			Assert.AreEqual(1, newCurrent.Sector.Y);

			newCurrent = coordinates[1];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(1, newCurrent.Sector.X);
			Assert.AreEqual(2, newCurrent.Sector.Y);

			newCurrent = coordinates[2];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(1, newCurrent.Sector.X);
			Assert.AreEqual(3, newCurrent.Sector.Y);

			newCurrent = coordinates[3];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(2, newCurrent.Sector.X);
			Assert.AreEqual(1, newCurrent.Sector.Y);

			newCurrent = coordinates[4];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(2, newCurrent.Sector.X);
			Assert.AreEqual(3, newCurrent.Sector.Y);

			newCurrent = coordinates[5];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(3, newCurrent.Sector.X);
			Assert.AreEqual(1, newCurrent.Sector.Y);

			newCurrent = coordinates[6];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(3, newCurrent.Sector.X);
			Assert.AreEqual(2, newCurrent.Sector.Y);

			newCurrent = coordinates[7];
			Assert.AreEqual(current.System, newCurrent.System);
			Assert.AreEqual(3, newCurrent.Sector.X);
			Assert.AreEqual(3, newCurrent.Sector.Y);

		}

		[Test]
		public void SectorNeighbourTest2Limits() {
			Coordinate sector = new Coordinate(1, 1);
			SectorCoordinate current = new SectorCoordinate(1, 1, 1, 1);

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(current);

			SectorCoordinate newCurrent = coordinates.Find(delegate(SectorCoordinate c){return c.Sector.X == sector.X - 1 && c.Sector.Y == sector.Y - 1; });
			Assert.IsNull(newCurrent);

			newCurrent = coordinates.Find(delegate(SectorCoordinate c){ return c.Sector.X == sector.X - 1 && c.Sector.Y == sector.Y; });
			Assert.IsNull(newCurrent);

			newCurrent = coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X && c.Sector.Y == sector.Y - 1; });
			Assert.IsNull(newCurrent);

			current = new SectorCoordinate(1, 37, 1, 10);
			coordinates = SectorUtils.GetPossibleCoordinates(current);
			sector = new Coordinate(1, 10);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X + 1 && c.Sector.Y == sector.Y + 1; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X - 1 && c.Sector.Y == sector.Y; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X && c.Sector.Y == sector.Y+1; });
			Assert.IsNull(newCurrent);


			sector = new Coordinate(7, 1);
			current = new SectorCoordinate(37, 1, 7, 1);
			coordinates = SectorUtils.GetPossibleCoordinates(current);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X && c.Sector.Y == sector.Y - 1; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X+1 && c.Sector.Y == sector.Y - 1; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X + 1 && c.Sector.Y == sector.Y; });
			Assert.IsNull(newCurrent);

			sector = new Coordinate(7, 10);
			current = new SectorCoordinate(37, 37, 7, 10);
			coordinates = SectorUtils.GetPossibleCoordinates(current);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X && c.Sector.Y == sector.Y + 1; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X+1 && c.Sector.Y == sector.Y + 1; });
			Assert.IsNull(newCurrent);

			coordinates.Find(delegate(SectorCoordinate c) { return c.Sector.X == sector.X + 1 && c.Sector.Y == sector.Y; });
			Assert.IsNull(newCurrent);
		}

		[Test]
		public void SectorNeighbourTestBetweenSystems() {
			Coordinate sector = new Coordinate(7, 10);
			SectorCoordinate current = new SectorCoordinate(1, 1, 7, 10);

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(current);

			SectorCoordinate newCurrent = coordinates[7];
			Assert.AreEqual(2, newCurrent.System.X);
			Assert.AreEqual(2, newCurrent.System.Y);
			Assert.AreEqual(1, newCurrent.Sector.X);
			Assert.AreEqual(1, newCurrent.Sector.Y);

			newCurrent = coordinates[4];
			Assert.AreEqual(1, newCurrent.System.X);
			Assert.AreEqual(2, newCurrent.System.Y);
			Assert.AreEqual(7, newCurrent.Sector.X);
			Assert.AreEqual(1, newCurrent.Sector.Y);

			newCurrent = coordinates[6]; ;
			Assert.AreEqual(2, newCurrent.System.X);
			Assert.AreEqual(1, newCurrent.System.Y);
			Assert.AreEqual(1, newCurrent.Sector.X);
			Assert.AreEqual(10, newCurrent.Sector.Y);
		}

		[Test]
		public void SurroundingCoordinates1() {
			SectorCoordinate center = new SectorCoordinate(1, 1, 2, 3);
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 2)));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 3)));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 4)));

			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 2, 2)));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 2, 4)));

			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 2)));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 3)));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 4)));

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(center);
			Assert.AreEqual(8, coordinates.Count);
		}

		[Test]
		public void SurroundingCoordinates2() {
			SectorCoordinate center = new SectorCoordinate(1, 1, 2, 3);
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 1), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 2), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 3), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 4), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 5), 2));

			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 2, 1), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 2, 2), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 2, 4), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 1, 5), 2));

			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 1), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 2), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 3), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 4), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 3, 5), 2));

			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 4, 1), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 4, 2), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 4, 3), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 4, 4), 2));
			Assert.IsTrue(SectorUtils.IsInRange(center, new SectorCoordinate(1, 1, 4, 5), 2));

			List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(center, 2);
			Assert.AreEqual(19, coordinates.Count);
		}

		[Test]
		public void GetStartCoordinate() {
			SectorCoordinate current = new SectorCoordinate(1, 1, 7, 10);

			//CoordinateRangeCalculator.GetStartSystemAndSector()

		}
	}

}
