using System;
using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Races;
using OrionsBeltTests.EngineTests;

namespace OrionsBeltTests.UniverseTests {

	[TestFixture]
	public class FleetTests : BaseTests {

		#region Private

        private static FleetSector GetFleetSector(int systemX, int systemY, int sx, int sy){
            return GetFleetSector(systemX, systemY, sx, sy, EngineUtils.EmptyPlayer);
        }

        private static FleetSector GetFleetSector(int systemX, int systemY, int sx, int sy, IPlayer owner){
            ISector sector = GetSector(systemX, systemY, sx, sy, owner);
			FleetSector f = GetFleetSector(sector, owner);
			Universe.ReplaceSector(f);
			GameEngine.Persist(owner);
			return f;
		}

		private static FleetSector GetFleetSector(ISector sector, IPlayer p) {
			IFleetInfo fleetInfo = new FleetInfo("Fleet1");
			fleetInfo.Owner = p;

			FleetSector f = new FleetSector(sector.SystemCoordinate, sector.SectorCoordinate, fleetInfo, sector.Level);

			fleetInfo.Add("Rain", 1);
			
			fleetInfo.Sector = f;
			f.Storage = sector.Storage;
			f.Owner = p;
			f.AddCelestialBody(fleetInfo);
			GameEngine.Persist(f);
			f.Storage.Fleets.Add(fleetInfo.Storage);
			return f;
		}

		private static ResourceSector GetResourceSector(ISector sector) {
			List<IResourceInfo> resources = RulesUtils.GetInstrinsicResources();
			ResourceSector n = new ResourceSector(sector.SystemCoordinate, sector.SectorCoordinate, 1);
			n.Resource = new ResourceQuantity(resources[0], 20);
			return n;
		}

		private static ISector GetSector(int x, int y, int sx, int sy) {
		    return GetSector(x, y, sx, sy, null);
		}
        
        private static ISector GetSector(int x, int y, int sx, int sy,IPlayer p) {
			Coordinate system = new Coordinate(x, y);
			Coordinate sector = new Coordinate(sx, sy);

			return Universe.GetSector(p,system, sector);
		}

		private static ISector GetSector(SectorCoordinate coordinate) {
			return GetSector(coordinate,null);
		}

		private static ISector GetSector(SectorCoordinate coordinate, IPlayer p) {
			return Universe.GetSector(p, coordinate.System, coordinate.Sector);
		}

		private static ISector GetNormalSector(int x, int y ) {
			Coordinate coordinate = new Coordinate(x, y);

			ISystem system = Universe.GetSystem(coordinate);

			foreach( ISector sector in system.Sectors.Values ) {
				if( sector is NormalSector ) {
					return sector;
				}
			}
			return null;
		}

		private static PlanetSector GetRandomPlanet(Coordinate c) {
			ISystem system = UniversePersistance.LoadSystem(c);
			foreach(ISector sector in system.Sectors.Values) {
				if(sector is PlanetSector && sector.Owner == null ) {
					return (PlanetSector)sector;
				}
			}
			return null;
		}

        private static void ClearAllBattles() {
		    using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
		        persistance.DeleteAll();
		    }
		}

		private static void GiveUpBattle() {
		    using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
		        IList<Battle> battles = persistance.Select();
		        int battleCount = battles.Count;
		        IBattleInfo battle = BattleManager.GetBattle(battles[battleCount - 1]);
		        BattleManager.DeployUnits(battle.Players[0].Owner, "p:r-8_1-1", battles[0]);
		        BattleManager.DeployUnits(battle.Players[1].Owner, "p:r-8_1-1", battles[0]);
		        BattleManager.GiveUp(battle.Players[1].Owner, battles[battleCount - 1]);
		    }
		}

		private static PlanetSector ConquerRandomPlanet(FleetSector f1, Coordinate system) {
			PlanetSector planet = GetRandomPlanet(system);
			Assert.IsNull(planet.Owner);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(planet.SystemCoordinate, planet.SectorCoordinate);
			args.ConquerWhenArrive = true;

			f1.OnMove(args);
			while (f1.IsMoving) {
				f1.Turn();
			}

			ISector sector = UniversePersistance.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
			Assert.IsTrue(sector is PlanetSector);
			Assert.AreEqual(1,sector.Storage.Planets.Count);
			Assert.IsNotNull(sector.Owner);
			return (PlanetSector)sector;
		}

		private static void ReplaceSector(ISector sector) {
			ISystem system = Universe.GetSystem(sector.SystemCoordinate);
			system.Sectors.Remove(sector.SectorCoordinate);
			system.Sectors.Add(sector.SectorCoordinate, sector);
		}


		#endregion Private

		[Test]
		public void FleetMovementTest() {
			FleetSector f1 = GetFleetSector(1,1, 2, 3);
			FleetSector f2 = GetFleetSector(1, 1, 7, 10);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate,f1.SectorCoordinate);

			SectorCoordinate destiny = new SectorCoordinate(f2.SystemCoordinate, f2.SectorCoordinate);
			args.Destiny = destiny;
			
			f1.OnMove(args);
			int i = 0;
			while( f1.IsMoving ) {
				f1.Turn();
				++i;
				Assert.AreEqual(args.Destiny,destiny);
			}

			if( i != 25 && i !=29 ) {
				Assert.Fail("Invalid Number of moves: {0}", i);
			}
			
			Assert.AreNotEqual(f1.SectorCoordinate, f2.SectorCoordinate);
			UniversePersistance.LoadSystem(new Coordinate(1,1));
		}

		[Test]
		public void FleetMovementTest2() {
			ISector sector1 = GetSector(1, 1, 2, 3);
			ISector sector2 = GetSector(1, 2, 2, 3);
			if (SectorUtils.IsSpace(sector2)) {
				IPlayer player = EngineUtils.EmptyPlayer;
				FleetSector f1 = GetFleetSector(sector1, player);

				FleetSectorMoveArgs args = new FleetSectorMoveArgs();
				args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
				
				SectorCoordinate destiny = new SectorCoordinate(sector2.SystemCoordinate, sector2.SectorCoordinate);
				args.Destiny = destiny;

				f1.OnMove(args);
				int i = 0;
				while (f1.IsMoving) {
					f1.Turn();
					++i;
					Assert.AreEqual(args.Destiny, destiny);
				}

				if (i != 37 && i!= 41) {
					Assert.Fail("Invalid Number of moves: {0}", i);
				}

				Assert.AreEqual(f1.SectorCoordinate, new Coordinate(2, 3));
			}
		}

		[Test]
		public void FleetMovementWithAttackTest() {
			FleetSector f1 = GetFleetSector(2,1, 3, 3);
			FleetSector f2 = GetFleetSector(2,1, 7,10);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(f2.SystemCoordinate, f2.SectorCoordinate);
			
			args.AttackWhenArrive = true;

			f1.OnMove(args);
			while (f1.IsMoving) {
				f1.Turn();
			}
			ISector sector = Universe.GetSector(null, f2.SystemCoordinate, f2.SectorCoordinate);
			Assert.IsTrue(sector is FleetBattleSector);
			Assert.AreEqual(f1.GetBattleFleet().Sector.Storage.Id, f2.GetBattleFleet().Sector.Storage.Id);

			//GiveUpBattle();
		}

		[Test]
		public void FleetWormHoleTest() {
		    IPlayer p = EngineUtils.EmptyPlayer;
			UniverseCreation.CreatePrivateUniverse(p);
			
            FleetSector f1 = GetFleetSector(0, 0, 1, 1,p);

			ISystem privateSystem = f1.Owner.PrivateSystem;
			Sector privateWormHole = null;
			foreach (Sector sector in privateSystem.Sectors.Values) {
				if (sector is PrivateWormHoleSector) {
					privateWormHole = sector;
					break;
				}
			}

			ISystem s = UniversePersistance.LoadSystem(new Coordinate(1, 7));
			Sector wormHole = null;
			foreach (Sector sector in s.Sectors.Values) {
				if (sector is WormHoleSector) {
					wormHole = sector;
					break;
				}
			}

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(privateWormHole.SystemCoordinate, privateWormHole.SectorCoordinate);
			args.Teletransporting = true;
			args.WormHoleCoordinate = new SectorCoordinate(wormHole.SystemCoordinate, wormHole.SectorCoordinate);

			f1.OnMove(args);
			while (f1.IsMoving) {
			    f1.Turn();
			}
			
			Assert.AreNotEqual(f1.SectorCoordinate, wormHole.SectorCoordinate);

			SectorCoordinate fleetLocation = f1.GetBattleFleet().Location;
			Assert.IsTrue(SectorUtils.IsInRange(wormHole.Coordinate, fleetLocation));
            Assert.IsFalse(fleetLocation.System.IsPrivateSystem());
		}

        [Test]
		public void FleetWormHoleCantPassTest() {
		    IPlayer p = EngineUtils.EmptyPlayer;
			UniverseCreation.CreatePrivateUniverse(p);
			
            FleetSector f1 = GetFleetSector(0, 0, 1, 1,p);

			ISystem privateSystem = f1.Owner.PrivateSystem;
			Sector privateWormHole = null;
			foreach (Sector sector in privateSystem.Sectors.Values) {
				if (sector is PrivateWormHoleSector) {
					privateWormHole = sector;
					break;
				}
			}

			ISystem s = UniversePersistance.LoadSystem(new Coordinate(7, 1));
			Sector wormHole = null;
			foreach (Sector sector in s.Sectors.Values) {
				if (sector is WormHoleSector) {
					wormHole = sector;
					break;
				}
			}

            IFleetInfo fleet = f1.GetBattleFleet();
            fleet.AddCargo( new ResourceQuantity(Alcohol.Resource,10));
            Assert.IsFalse(fleet.CanPassWormHoles);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(privateWormHole.SystemCoordinate, privateWormHole.SectorCoordinate);
			args.Teletransporting = true;
			args.WormHoleCoordinate = new SectorCoordinate(wormHole.SystemCoordinate, wormHole.SectorCoordinate);

			f1.OnMove(args);
			while (f1.IsMoving) {
			    f1.Turn();
			}
			
			SectorCoordinate fleetLocation = f1.GetBattleFleet().Location;
			Assert.IsTrue(fleetLocation.System.IsPrivateSystem());
		}

		[Test]
		public void FleetGatherResourceTest() {
			FleetSector f1 = GetFleetSector(4,1,2, 3);
			
			ISector sector2 = GetSector(4, 1, 2, 4);
			ResourceSector n = GetResourceSector(sector2);
			IResourceInfo resource = n.Resource.Resource;
			ReplaceSector(n);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			SectorCoordinate destiny = new SectorCoordinate(n.SystemCoordinate, n.SectorCoordinate);
			args.Destiny = destiny;

			f1.OnMove(args);
			int i = 0;
			while (f1.IsMoving) {
				f1.Turn();
				++i;
				Assert.AreEqual(args.Destiny, destiny);
			}

			if (i != 1 ) {
				Assert.Fail("Invalid Number of moves: {0}", i);
			}

			Assert.GreaterOrEqual(20, f1.Owner.GetQuantity(resource));
			Assert.AreEqual(f1.SectorCoordinate, sector2.SectorCoordinate);
		}

		[Test]
		public void FleetConquerTest() {
			FleetSector f1 = GetFleetSector(5,1,5, 5);
			ConquerRandomPlanet(f1, new Coordinate(5, 1));
		}

		[Test]
		public void FleetNoConquerTest() {
			FleetSector f1 = GetFleetSector(6,1,4,2);

			PlanetSector planet = GetRandomPlanet( new Coordinate(6,1));
			Assert.IsNull(planet.Owner);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(planet.SystemCoordinate, planet.SectorCoordinate);
			args.ConquerWhenArrive = false;

			f1.OnMove(args);
			while (f1.IsMoving) {
				f1.Turn();
			}

			Assert.IsNull(planet.Owner);
		}

		[Test]
		public void FleetPursuitTest() {
			FleetSector f1 = GetFleetSector(7,1,1, 1);
			FleetSector f2 = GetFleetSector(7,1,1, 3);
			
			ISector sector2 = GetSector(7, 1, 7, 1);
			ResourceSector n = GetResourceSector(sector2);
			ReplaceSector(n);
			
			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(f2.SystemCoordinate, f2.SectorCoordinate);
			args.AttackWhenArrive = true;
			args.Pursuit = true;
			args.FleetToPursuitId = f2.Storage.Id;

			FleetSectorMoveArgs args2 = new FleetSectorMoveArgs();
			args2.Source = new SectorCoordinate(f2.SystemCoordinate, f2.SectorCoordinate);
			SectorCoordinate destiny = new SectorCoordinate(new Coordinate(2, 2), new Coordinate(2, 3));
			args2.Destiny = destiny;
			
			f1.OnMove(args);
			f2.OnMove(args2);
			SectorCoordinate lastF1Coordinate = f1.Coordinate;
			while (f1.IsMoving) {
				f2.Turn();
				f1.FleetSectorMoveArgs.Destiny = f2.Coordinate;
				lastF1Coordinate = f1.Coordinate;
				f1.Turn();
				Assert.AreEqual(args.Destiny, f2.Coordinate);
			}

			Console.WriteLine("F1 Coordinate: {0}", f1.Coordinate);
			Console.WriteLine("F2 Coordinate: {0}", f2.Coordinate);
			ISector sector = Universe.GetSector(f2.Coordinate.System, f2.Coordinate.Sector);
			Assert.IsTrue(sector is FleetBattleSector, "sector 7:1:2:3 should be a FleetBattleSector and is a ",sector.Type);

			sector = Universe.GetSector(lastF1Coordinate.System, lastF1Coordinate.Sector);
			Assert.IsTrue(SectorUtils.IsSpace(sector), "the last f1 sector should be a NormalSector");

			Assert.AreEqual( f1.GetBattleFleet().Sector.Storage.Id, f2.GetBattleFleet().Sector.Storage.Id );
		}

		[Test]
		public void FleetAttackPlanetCOnquerTestNoDefenses() {
			FleetSector f1 = GetFleetSector(8,1,5, 6);
			FleetSector f2 = GetFleetSector(8, 1, 5, 7);

			PlanetSector planet = ConquerRandomPlanet(f1, new Coordinate(8,1));
		    

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(planet.SystemCoordinate, planet.SectorCoordinate);
			args.AttackWhenArrive = true;
			args.ConquerWhenArrive = true;

			f2.OnMove(args);
			while (f2.IsMoving) {
				f2.Turn();
			}

			ISector sector = Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
			Assert.IsTrue(sector is PlanetSector);
			Assert.AreEqual(2, sector.CelestialBodies.Count);
			Assert.AreEqual(sector.Owner.Id, f2.Owner.Id);
		}

		[Test]
		public void FleetAttackPlanetRaidTestNoDefenses() {
			Clock.Instance.Tick = 100;
			FleetSector f1 = GetFleetSector(8, 1, 5, 6);
			f1.Owner.AddQuantity(Argon.Resource, 1000);
			GameEngine.Persist(f1.Owner);
			
			FleetSector f2 = GetFleetSector(8, 1, 5, 7);
			PlanetSector planetSector = ConquerRandomPlanet(f1, new Coordinate(8, 1));
			IPlanet planet = planetSector.GetPlanet();

			int currQuantity = planet.GetQuantity(Argon.Resource);
			Assert.Greater(currQuantity, 0);
			
			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.Destiny = new SectorCoordinate(planetSector.SystemCoordinate, planetSector.SectorCoordinate);
			args.AttackWhenArrive = true;
			args.ConquerWhenArrive = false;

			f2.OnMove(args);
			while (f2.IsMoving) {
				f2.Turn();
			}

			ISector sector = Universe.GetSector(planetSector.SystemCoordinate, planetSector.SectorCoordinate);
			Assert.IsTrue(sector is PlanetSector);
			Assert.AreEqual(2, sector.CelestialBodies.Count);
			Assert.AreNotEqual(sector.Owner.Id, f2.Owner.Id);
			Assert.IsFalse(sector.GetPlanet().CanPillage);

			ISector fleetsector = Universe.GetSector(f2.SystemCoordinate, f2.SectorCoordinate);
			Assert.AreEqual(fleetsector.Owner.Id, f2.Owner.Id);

			Assert.IsNotNull(fleetsector.GetBattleFleet().Cargo);
			Assert.GreaterOrEqual(fleetsector.GetBattleFleet().Cargo.Count, 1);
		}

        [Test]
        public void FleetAttackPlanetTest() {
            FleetSector f1 = GetFleetSector(9,1,6, 6);
			FleetSector f2 = GetFleetSector(9, 1, 6, 7);

            PlanetSector planet = ConquerRandomPlanet(f1, new Coordinate(9,1));
			planet = (PlanetSector)Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
            planet.GetPlanet().DefenseFleet.Add("Rain",1);
			GameEngine.Persist(planet.GetPlanet().DefenseFleet);

            FleetSectorMoveArgs args = new FleetSectorMoveArgs();
            args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
            args.Destiny = new SectorCoordinate(planet.SystemCoordinate, planet.SectorCoordinate);
            args.AttackWhenArrive = true;

            f2.OnMove(args);
            while (f2.IsMoving) {
                f2.Turn();
            }

            ISector sector = Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
            Assert.AreEqual(3,sector.CelestialBodies.Count);
            Assert.AreEqual(sector.CelestialBodies[0].Location, sector.CelestialBodies[1].Location);
            Assert.IsTrue(sector is PlanetBattleSector);
        }

        [Test]
        public void FleetAttackPlanetTest2(){
            ClearAllBattles();

            FleetSector f1 = GetFleetSector(10, 1, 6, 6);
            FleetSector f2 = GetFleetSector(10, 1, 6, 7);

            PlanetSector planet = ConquerRandomPlanet(f1, new Coordinate(10, 1));
            planet = (PlanetSector)Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
        	IPlanet p = planet.GetPlanet();
            p.DefenseFleet.Add("Rain", 1);
			p.Touch();
			GameEngine.Persist(planet.GetPlanet());

            FleetSectorMoveArgs args = new FleetSectorMoveArgs();
            args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
            args.Destiny = new SectorCoordinate(planet.SystemCoordinate, planet.SectorCoordinate);
            args.AttackWhenArrive = true;
			args.ConquerWhenArrive = true;

            f2.OnMove(args);
            while (f2.IsMoving){
                f2.Turn();
            }
            Persistance.Flush();
            ISector sector = Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
            Assert.AreEqual(3, sector.CelestialBodies.Count);
            Assert.AreEqual(sector.CelestialBodies[0].Location, sector.CelestialBodies[1].Location);
            Assert.IsTrue(sector is PlanetBattleSector);
            
            GiveUpBattle();

            sector = Universe.GetSector(planet.SystemCoordinate, planet.SectorCoordinate);
            Assert.AreEqual(2, sector.CelestialBodies.Count);
            Assert.AreEqual(sector.CelestialBodies[0].Location, sector.CelestialBodies[1].Location);
            Assert.IsTrue(sector is PlanetSector);
			Assert.AreEqual(0, sector.GetBattleFleet().Units.Count);
            Assert.AreEqual(sector.Owner.Id, f2.Owner.Id);
        }

		[Test]
        public void CargoTest(){
            FleetSector f1 = GetFleetSector(10,1,7,6);
            IFleetInfo fleet = f1.GetBattleFleet();

            fleet.AddCargo( new ResourceQuantity(Energy.Resource,10));
            fleet.AddCargo( new ResourceQuantity(Mithril.Resource, 10));

            Assert.AreEqual(2, fleet.Cargo.Count);
            Assert.AreEqual(10,fleet.Cargo[Energy.Resource]);
            Assert.AreEqual(10, fleet.Cargo[Mithril.Resource]);

            fleet.RemoveCargo(Energy.Resource);
            Assert.AreEqual(1, fleet.Cargo.Count);
            Assert.AreEqual(10, fleet.Cargo[Mithril.Resource]);

            fleet.UpdateCargo(Mithril.Resource,15);
            Assert.AreEqual(1, fleet.Cargo.Count);
            Assert.AreEqual(15, fleet.Cargo[Mithril.Resource]);

            fleet.EmptyCargo();
            Assert.IsFalse(fleet.HasCargo);
        }

		[Test]
		public void FleetCreateBugWormholeMovementTest() {
			Player player = EngineUtils.EmptyBugPlayer;
			player.UltimateWeaponLevel = 1;
			FleetSector f1 = GetFleetSector(11, 1, 1, 1, player);
			ISector s = GetNormalSector(11, 1);

			FleetSectorMoveArgs args = new FleetSectorMoveArgs();
			args.Source = new SectorCoordinate(f1.SystemCoordinate, f1.SectorCoordinate);
			args.UseUltimateWeapon = true;

			SectorCoordinate destiny = new SectorCoordinate(s.SystemCoordinate, s.SectorCoordinate);
			args.Destiny = destiny;

			f1.OnMove(args);
			while (f1.IsMoving) {
				f1.Turn();
			}

			ISector sector = GetSector(s.Coordinate);
			Assert.IsTrue(sector is BugsWormHoleSector);
		}
		

		#region Constructor

		public FleetTests(){
			UniverseCreation.CreateTestUniverse(37, 37);
			Universe.LoadUniverse();
		}
		 
		#endregion Constructor
		
	}
}
