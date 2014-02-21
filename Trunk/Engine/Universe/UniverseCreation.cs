using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore;

namespace OrionsBelt.Engine.Universe {
	public class UniverseCreation {

		#region Fields

        private static readonly List<Coordinate> exceptions = new List<Coordinate>();
		private static readonly Random planetRandom = new Random((int)DateTime.Now.Ticks);
		private static readonly Random wormHoleRandom = new Random((int)DateTime.Now.Ticks);
		private readonly static Random resourcesRandom = new Random((int)DateTime.Now.Ticks);
		private static readonly List<Coordinate> addedWormHoles = new List<Coordinate>();
        private static readonly List<Coordinate> addedMarkets = new List<Coordinate>();
        private static readonly List<Coordinate> addedArenas = new List<Coordinate>();
        private static readonly List<Coordinate> addedAcademys = new List<Coordinate>();
        private static readonly List<Coordinate> addedPirateBays = new List<Coordinate>();
		private static readonly SectorCoordinate homeplanetCoordinate = new SectorCoordinate(0, 0, 2, 2);
        private static int market = -1;
        private static int arena = -1;

		#endregion Fields

		#region Properties

		public static List<Coordinate> AddedWormHoles {
			get { return addedWormHoles; }
		}

        public static List<Coordinate> AddedMarkets
        {
            get { return addedMarkets; }
        }

        public static List<Coordinate> AddedArenas
        {
            get { return addedArenas; }
        }
        public static List<Coordinate> AddedAcademys
        {
            get { return addedAcademys; }
        }
        public static List<Coordinate> AddedPirateBays
        {
            get { return addedPirateBays; }
        }
        
		#endregion Properties

		#region Generate Universe

        private static bool IsNotForbidden(Coordinate coordinate){
            return coordinate.X != 1 && coordinate.Y != 1 && coordinate.X != 7 && coordinate.Y != 10;
        }

		/// <summary>
		/// Generates coordinates within the specified gap
		/// </summary>
		/// <param name="line">line</param>
		/// <param name="maxLineElements">Maximum number of sectos in the x coordinate</param>
		/// <returns>A Enumerable of Coordinates</returns>
		private static IEnumerable<Coordinate> GenerateLimitedCoordinates(int line, int maxLineElements) {
			for (int y = 1; y <= maxLineElements; ++y) {
				yield return new Coordinate(line, y);
			}
		}

		/// <summary>
		/// Generates coordinates within the specified gap
		/// </summary>
		/// <param name="line">line</param>
		/// <returns>A Enumerable of Coordinates</returns>
		private static IEnumerable<Coordinate> GenerateCoordinates(int line) {
			for (int y = 1; y <= Coordinate.MaxYValue; ++y) {
				yield return new Coordinate(line, y);
			}
		}

	    private static bool CanAddWormhole(Coordinate system, Coordinate sector) {
			int value = wormHoleRandom.Next(1, 71);
            if (IsNotForbidden(sector) && value <= 35 && IsWormHole(system) && !AddedWormHoles.Contains(system))
            {
				return true;
			}
			return false;
		}

        private static bool CanAddMarket(Coordinate system, Coordinate sector)
        {
            int value = wormHoleRandom.Next(1, 71);
            if (IsNotForbidden(sector) && value <= 20 && IsMarket(system) && !AddedMarkets.Contains(system))
            {
                return true;
            }
            return false;
        }

        private static bool CanAddArena(Coordinate coordinate)
        {
            int value = wormHoleRandom.Next(1, 71);
            if (value <= 40 && IsArena(coordinate) && !AddedArenas.Contains(coordinate))
            {
                return true;
            }
            return false;
        }
        private static bool CanAddAcademy(Coordinate coordinate)
        {
            int value = wormHoleRandom.Next(1, 71);
            if (value <= 40 && IsAcademy(coordinate) && !AddedAcademys.Contains(coordinate))
            {
                return true;
            }
            return false;
        }
        private static bool CanAddPirateBay(Coordinate coordinate)
        {
            int value = wormHoleRandom.Next(1, 71);
            if (value <= 40 && IsPirateBay(coordinate) && !AddedPirateBays.Contains(coordinate))
            {
                return true;
            }
            return false;
        }

		private static bool CanAddResource() {
			int value = resourcesRandom.Next(1, 100);
			return value <= 2;
		}

        /// <summary>
        /// Verifies if the coordinate can have a market
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static bool IsMarket(Coordinate coordinate)
        {
            if ((coordinate.X % 5 == 1 && coordinate.Y % 5 == 1))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if the coordinate can have a arena
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static bool IsArena(Coordinate coordinate)
        {
            if ((coordinate.X % 8 == 3 && coordinate.Y % 8 == 3))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if the coordinate can have an academy
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static bool IsAcademy(Coordinate coordinate)
        {
            if ((coordinate.X % 3 == 2 && coordinate.Y % 3 == 2))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Verifies if the coordinate can have a pirate bay
        /// </summary>
        /// <param name="coordinate"></param>
        /// <returns></returns>
        private static bool IsPirateBay(Coordinate coordinate)
        {
            if ((coordinate.X % 3 == 0 && coordinate.Y % 3 == 0))
            {
                return true;
            }

            return false;
        }

		/// <summary>
		/// Verifies if the coordinate can have a wormhole
		/// </summary>
		/// <param name="coordinate"></param>
		/// <returns></returns>
		private static bool IsWormHole(Coordinate coordinate) {
			if (exceptions.Contains(coordinate)) {
				return false;
			}

			if ((coordinate.X % 6 == 1 && coordinate.Y % 6 == 1) || (coordinate.X % 6 == 4 && coordinate.Y % 6 == 4)) {
				return true;
			}

			return false;
		}

		/// <summary>
		/// Generates the sectors of a system
		/// </summary>
		/// <param name="system">System to add the sectors to</param>
		private static void GenerateSectors(System system)
		{
		    List<Coordinate> planetCoordinates = GetHotPlanetsCoordinate();
			foreach (Coordinate coordinate in SectorUtils.GenerateSectorCoordinates())
		    {
		        Sector sector;
		        if ( planetCoordinates.Contains(coordinate) )
		        {
					sector = new PlanetSector(system.Coordinate, coordinate, system.Level, false);
		            system.AddSector(sector);
		            continue;
		        }
		        if (CanAddWormhole(system.Coordinate,coordinate))
		        {
		            sector = new WormHoleSector(system.Coordinate, coordinate, system.Level);
		            AddedWormHoles.Add(system.Coordinate);
		            system.AddSector(sector);
		            continue;
		        }
                if (CanAddMarket(system.Coordinate,coordinate))
                {
                    sector = new MarketSector(system.Coordinate, coordinate, system.Level);
                    GameEngine.Persist(sector, true, true);
                    int marketId = MarketUtil.CreateMarket((++market).ToString(),system.Coordinate, coordinate, system.Level, sector);

                    ((MarketSector) sector).MarketId = marketId;
                    GameEngine.Persist(sector, true, true);

                    AddedMarkets.Add(system.Coordinate);
                    system.AddSector(sector);
                    continue;
                }
                if (CanAddAcademy(system.Coordinate))
                {
                    sector = new AcademySector(system.Coordinate, coordinate, system.Level);
                    AddedAcademys.Add(system.Coordinate);
                    system.AddSector(sector);
                    continue;
                }
                if (CanAddPirateBay(system.Coordinate))
                {
                    sector = new PirateBaySector(system.Coordinate, coordinate, system.Level);
                    AddedPirateBays.Add(system.Coordinate);
                    system.AddSector(sector);
                    continue;
                }
                if (CanAddArena(system.Coordinate))
                {
                    int prize = 100;
                    if(system.Level == 7)
                    {
                        prize = 300;
                    }
                    else
                    {
                        if(system.Level == 10)
                        {
                            prize = 500;
                        }
                    }

                    sector = ArenaManager.CreateMYArena((++arena).ToString(), prize, TournamentManager.GetFleet(1000, false), new SectorCoordinate(system.Coordinate, coordinate) );
                    AddedArenas.Add(system.Coordinate);
                    system.AddSector(sector);
                    
                    continue;
                }
		        if (CanAddResource()) {
					sector = new ResourceSector(system.Coordinate, coordinate, system.Level);
					system.AddSector(sector);
					continue;
				}
		    }
		}
	

		#endregion Generate Universe

		#region Generates Private System

		#region Scout Fleet

		private static IFleetInfo CreateScoutFleet(IPlayer owner,Coordinate system, Coordinate sector) {
			FleetInfo fleetInfo = new FleetInfo("Scout",new SectorCoordinate(system,sector));

			switch(owner.RaceInfo.Race) {
				case Race.Bugs:
					fleetInfo.Add("Seeker", 1);
					break;
				case Race.DarkHumans:
					fleetInfo.Add("DarkRain", 1);
					break;
				default:
					fleetInfo.Add("Rain", 1);
					break;
			}
			
			fleetInfo.Movable = true;
			fleetInfo.Owner = owner;
			return fleetInfo;
		}

		private static ISector GenerateScoutFleet(IPlayer owner, Coordinate system, Coordinate sector, int level) {
			IFleetInfo fleetInfo = CreateScoutFleet(owner, system, sector);
			return new FleetSector(system, sector, fleetInfo, level);
		}

		#endregion Scout Fleet

		#region Private Planets

        /// <summary>
        /// Chooses a random basic resource of the race of the player
        /// </summary>
        /// <param name="player">Player to choose the resource from</param>
        /// <returns>A resource</returns>
        private static IResourceQuantity ChooseResource(IPlayer player){
            int r = resourcesRandom.Next(1, 10);
            if( r < 5 ){
                return new ResourceQuantity(player);
            }
            return null;
        }
		
		/// <summary>
		/// Generates the coordinates for the private planets
		/// </summary>
		/// <returns>A List of coordinates</returns>
		private static List<Coordinate> GetPrivatePlanetsCoordinate() {
			List<Coordinate> container = new List<Coordinate>();

			container.Add(new Coordinate(2, 2));
			container.Add(Coordinate.GenerateRandomCoordinate(1, 8, 3, 10));
			container.Add(Coordinate.GenerateRandomCoordinate(2, 4, 5, 7));
			container.Add(Coordinate.GenerateRandomCoordinate(4, 1, 7, 3));
			container.Add(Coordinate.GenerateRandomCoordinate(4, 8, 7, 10));

			return container;
		}

        		/// <summary>
		/// Generates the coordinates for the private planets
		/// </summary>
		/// <returns>A List of coordinates</returns>
		private static List<Coordinate> GetHotPlanetsCoordinate() {
			List<Coordinate> container = new List<Coordinate>();

			container.Add(Coordinate.GenerateRandomCoordinate(1, 1, 3, 5));
			container.Add(Coordinate.GenerateRandomCoordinate(1, 6, 3, 10));
			container.Add(Coordinate.GenerateRandomCoordinate(4, 1, 7, 5));
			container.Add(Coordinate.GenerateRandomCoordinate(4, 6, 7, 10));

			return container;
		}

		private static ISector AddHomePlanet(Coordinate coordinate, System system, IPlayer player) {
			SectorCoordinate location = new SectorCoordinate(system.Coordinate, coordinate);
			PlanetSector planetSector = new PlanetSector(player, system.Coordinate, coordinate, system.Level, true);
			IPlanet planet = PlanetUtils.GeneratePlanet(player, planetSector, location);
			planet.Name = "Home Planet";
			planet.IsPrivate = true;
			planet.Sector = planetSector;
			player.ResolveHomePlanet();
			return planet.Sector;
		}

		private static ISector AddPrivatePlanet(Coordinate coordinate, System system, IPlayer player) {
			return new PlanetSector(player, system.Coordinate, coordinate, system.Level, true);
		}

		private static ISector AddPlanet(Coordinate coordinate, System system, IPlayer player) {
			if (homeplanetCoordinate.Sector == coordinate) {
				return AddHomePlanet(coordinate,  system, player);
			}
			return AddPrivatePlanet(coordinate, system, player);
		}

		#endregion Private Planets

		/// <summary>
		/// Gets the coordinate of the private wormhole
		/// </summary>
		private static Coordinate GetPrivateWormHoleCoordinate() {
			return Coordinate.GenerateRandomCoordinate(6, 4, 7, 7);
		}

		/// <summary>
		/// Generates the sectors of a system
		/// </summary>
		/// <param name="system">System to add the sectors to</param>
		/// <param name="player">Player that owns the system</param>
		private static void GeneratePrivateSectors(System system, IPlayer player) {
			List<Coordinate> planetCoordinates = GetPrivatePlanetsCoordinate();
			Coordinate wormHole = GetPrivateWormHoleCoordinate();

			foreach (Coordinate coordinate in SectorUtils.GenerateSectorCoordinates()) {
				ISector sector = null;
				if( coordinate.X == 1 && coordinate.Y == 1) {
					sector = GenerateScoutFleet(player,system.Coordinate, coordinate, system.Level);
				}else{
					if (planetCoordinates.Contains(coordinate)) {
						sector = AddPlanet(coordinate, system, player);
					} else {
						if (coordinate == wormHole) {
							sector = new PrivateWormHoleSector(system.Coordinate, coordinate, system.Level);
						} else {
							IResourceQuantity rq = ChooseResource(player);
							if(rq != null ) {
								sector = new ResourceSector(system.Coordinate, coordinate, system.Level);
								sector.Resource = rq;
							}
						}
					}
				}
				if(sector != null ) {
					sector.Owner = player;
					system.AddSector(sector);
				}
			}
		}

		/// <summary>
		/// Creates a random universe
		/// </summary>
		public static void CreatePrivateUniverse(IPlayer player) {
			System system = new System(new Coordinate(0, 0), 1, player);
			GeneratePrivateSectors(system, player);
			player.PrivateSystem = system;
		}

		#endregion Generates Private System

		#region Public

		/// <summary>
		/// Creates a random universe
		/// </summary>
		/// <param name="xSize"></param>
		/// <param name="ySize"></param>
		public static void CreateTestUniverse(int xSize, int ySize) {
			foreach (Coordinate coordinate in SectorUtils.GenerateCoordinates(xSize, ySize)) {
				System system = new System(coordinate, SectorUtils.GetLevel(coordinate));
				GenerateSectors(system);
				Universe.AddSystem(system);
			}
			
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				persistance.DeleteAll();

				foreach (Coordinate coordinate in SectorUtils.GenerateCoordinates(xSize, ySize)) {
					ISystem system = Universe.GetSystem(coordinate);
                    if (system.Sectors.Count != 0){
					    foreach (ISector sector in system.Sectors.Values) {
						    GameEngine.Persist(sector, false, true);
					    }
                    }else{
                        ISector sector = new ResourceSector(coordinate, new Coordinate(1, 1), system.Level);
                        system.AddSector(sector);
                        GameEngine.Persist(sector, false, true);
                    }
					Console.WriteLine("\nSystem {0} Created", coordinate);
				}
			}
			CreateWormHoleCount();
		}

		/// <summary>
		/// Creates a random universe
		/// </summary>
		/// <returns>Returns the json representation of the universe</returns>
		public static void CreateUniverse(int line, int maxLineElements) {
			Dictionary<Coordinate,ISystem> systems = new Dictionary<Coordinate, ISystem>();
			foreach (Coordinate coordinate in GenerateLimitedCoordinates(line, maxLineElements)) {
                System system = new System(coordinate, SectorUtils.GetLevel(coordinate));
				GenerateSectors(system);
				systems.Add(coordinate,system);
			}
			
			if (!Server.IsInTests) {
				using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
					persistance.StartTransaction();
					foreach (Coordinate coordinate in GenerateCoordinates(line)) {
						DateTime start = DateTime.Now;
						ISystem system = systems[coordinate];

                        foreach (ISector sector in system.Sectors.Values) {
							GameEngine.Persist(sector, false, true);
						}
						Console.WriteLine(" » Sector Creation Time: {0}s", (DateTime.Now - start).TotalMilliseconds);
					}
					Console.Write(" » Commiting... ");
					persistance.CommitTransaction();
					persistance.Clear();
					Console.WriteLine("Done");
				}
			}
			
		}

		private static void ShowStats() {
			if( !Server.IsInTests){
				Console.WriteLine("FlushCount: {0}", NHibernateUtilities.Statistics.FlushCount);
				
				Console.WriteLine("Queries: {0}", NHibernateUtilities.Statistics.Queries.Length);
				Console.WriteLine("MaxTime: {0}", NHibernateUtilities.Statistics.QueryExecutionMaxTime);
				
				Console.WriteLine("Sessions Open: {0}", NHibernateUtilities.Statistics.SessionOpenCount);
				Console.WriteLine("Sessions Close: {0}", NHibernateUtilities.Statistics.SessionCloseCount);
				
				Console.WriteLine("Insert Count: {0}", NHibernateUtilities.Statistics.EntityInsertCount);
				Console.WriteLine("UpdateCount Count: {0}", NHibernateUtilities.Statistics.EntityUpdateCount);
				Console.WriteLine("Fetch Count: {0}", NHibernateUtilities.Statistics.EntityFetchCount);
				Console.WriteLine("Load Count: {0}", NHibernateUtilities.Statistics.CollectionLoadCount);
				Console.WriteLine("Transaction Count: {0}", NHibernateUtilities.Statistics.TransactionCount);
				Console.WriteLine("Connect Count: {0}", NHibernateUtilities.Statistics.ConnectCount);

				NHibernateUtilities.Statistics.Clear();
			}
		}

		/// <summary>
		/// Creates the count of the wormHoles
		/// </summary>
		public static void CreateWormHoleCount() {
			Console.Write("\nCreating Universe count...");
			using (IWormHolePlayersPersistance p = Persistance.Instance.GetWormHolePlayersPersistance()) {
				IList<WormHolePlayers> list = p.Select();
				if( list.Count == 0) {
					for (int i = 0; i < 80; ++i) {
						WormHolePlayers whc = p.Create();
						whc.PlayerCount = 0;
						p.Update(whc);
					}
					p.Flush();
				}
			}
			Console.WriteLine("DONE");
		}

		public static void GenerateDummyFleets() {
			Universe.LoadUniverse();
			IPlayer player = PlayerUtils.GetPlayerById(98071);

			int i = 0;
			Console.Write("Creating Fleets...");
			foreach (ISystem system in Universe.AllUniverse.Values) {
				foreach (ISector sector in system.Sectors.Values) {
					if ( SectorUtils.IsSpace(sector) && sector.SectorCoordinate.X == 3 && sector.SectorCoordinate.Y == 3) {
						++i;
						IFleetInfo fleetInfo = CreateScoutFleet(player, sector.SystemCoordinate, sector.SectorCoordinate);
						GameEngine.Persist(new FleetSector(sector.SystemCoordinate, sector.SectorCoordinate, fleetInfo, sector.Level),
										   false);
					}
				}
			}
			Console.WriteLine("DONE");
			Console.WriteLine("{0} Fleets Created", i);
			Console.Write("Flushing...");
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				persistance.StartTransaction();
				persistance.CommitTransaction();
			}
			Console.WriteLine("DONE");
		}

		#endregion Public		

		#region Constructor

		static UniverseCreation() {
			exceptions.Add( new Coordinate(16,16));
			exceptions.Add( new Coordinate(16,22));
			exceptions.Add( new Coordinate(19,19));
			exceptions.Add( new Coordinate(22,16));
			exceptions.Add( new Coordinate(22,22));
		}

		#endregion Constructor

	}
}
