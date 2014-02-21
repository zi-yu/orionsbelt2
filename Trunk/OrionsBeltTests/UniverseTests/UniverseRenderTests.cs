using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;

namespace OrionsBeltTests.UniverseTests {

	[TestFixture]
	public class UniverseRenderTests : BaseTests{

		#region Tests

		[Test]
		public void TestSector1_1Render() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(1, 1), new Coordinate(2, 3));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(1,list[0].Sector.X);
			Assert.AreEqual(1,list[0].Sector.Y);
		}

		[Test]
		public void TestSector1_1Render1() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(1, 1), new Coordinate(7, 7));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(3, list[0].Sector.X);
			Assert.AreEqual(1, list[0].Sector.Y);
		}

		[Test]
		public void TestSector1_37Render() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(1, 37), new Coordinate(2, 8));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(1, list[0].Sector.X);
			Assert.AreEqual(5, list[0].Sector.Y);

			Assert.AreEqual(1, list[0].System.X);
			Assert.AreEqual(36, list[0].System.Y);
		}

		[Test]
		public void TestSector1_37Render2() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(1, 37), new Coordinate(5, 8));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(1, list[0].Sector.X);
			Assert.AreEqual(5, list[0].Sector.Y);

			Assert.AreEqual(1, list[0].System.X);
			Assert.AreEqual(36, list[0].System.Y);
		}

		[Test]
		public void TestSector37_1Render() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(37, 1), new Coordinate(5, 3));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);
			Assert.AreEqual(5, list[0].Sector.X);
			Assert.AreEqual(1, list[0].Sector.Y);

			Assert.AreEqual(36, list[0].System.X);
			Assert.AreEqual(1, list[0].System.Y);
		}

		[Test]
		public void TestSector37_1Render2() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(37, 1), new Coordinate(3, 10));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(6, list[0].Sector.X);
			Assert.AreEqual(3, list[0].Sector.Y);

			Assert.AreEqual(36, list[0].System.X);
			Assert.AreEqual(1, list[0].System.Y);
		}

		[Test]
		public void TestSector37_37Render() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(37, 37), new Coordinate(2, 3));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);
			Assert.AreEqual(5, list[0].Sector.X);
			Assert.AreEqual(6, list[0].Sector.Y);

			Assert.AreEqual(36, list[0].System.X);
			Assert.AreEqual(36, list[0].System.Y);
		}

		[Test]
		public void TestSector37_37Render2() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(37, 37), new Coordinate(7, 10));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(5, list[0].Sector.X);
			Assert.AreEqual(5, list[0].Sector.Y);

			Assert.AreEqual(36, list[0].System.X);
			Assert.AreEqual(36, list[0].System.Y);
		}

		[Test]
		public void TestSectorRightBorderRender() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(26, 37), new Coordinate(3, 8));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(6, list[0].Sector.X);
			Assert.AreEqual(5, list[0].Sector.Y);

			Assert.AreEqual(25, list[0].System.X);
			Assert.AreEqual(36, list[0].System.Y);
		}

		[Test]
		public void TestSectorBottomBorderRender() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(37, 8), new Coordinate(7, 2));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(5, list[0].Sector.X);
			Assert.AreEqual(5, list[0].Sector.Y);

			Assert.AreEqual(36, list[0].System.X);
			Assert.AreEqual(7, list[0].System.Y);
		}

		[Test]
		public void TestSectorLeftBorderRender() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(20, 1), new Coordinate(2, 3));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(5, list[0].Sector.X);
			Assert.AreEqual(1, list[0].Sector.Y);

			Assert.AreEqual(19, list[0].System.X);
			Assert.AreEqual(1, list[0].System.Y);
		}

		[Test]
		public void TestSectorTopBorderRender() {
			SectorCoordinateContainer container = UniverseUtils.GetCoordinateRange(new Coordinate(1, 14), new Coordinate(2, 3));
			List<SectorCoordinate> list = container.GetSystemInformation(container.SystemCoordinates[0]);

			Assert.AreEqual(1, list[0].Sector.X);
			Assert.AreEqual(6, list[0].Sector.Y);

			Assert.AreEqual(1, list[0].System.X);
			Assert.AreEqual(13, list[0].System.Y);
		}

		#endregion Tests

	}
}
