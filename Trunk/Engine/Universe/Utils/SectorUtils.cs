using System;
using System.Collections;
using System.Collections.Generic;

using DesignPatterns;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;

namespace OrionsBelt.Engine.Universe {
	public static class SectorUtils {

		#region Fields

        private static readonly List<UniverseArea> levels = new List<UniverseArea>();
		private static readonly HammingDistanceComparer hammingDistanceComparer = new HammingDistanceComparer();
		public static readonly FactoryContainer SectorFactories = new FactoryContainer(typeof(Sector));
		private static readonly char[] commaSeparator = new char[] { ';' };
		
		#endregion Fields

		#region Private

		private static void AddCoordinate(SectorCoordinate current, ICollection<SectorCoordinate> coordinates) {
			if (current != null) {
				coordinates.Add(current);
			}
		}

		private static void SetSectorToBattle(ISector destiny, ISector source) {
			IFleetInfo attackerFleet = source.GetBattleFleet();
			attackerFleet.IsInBattle = true;
			destiny.AddCelestialBody(attackerFleet);
		}

		private static void SetPlanetToBattle(PlanetBattleSector destiny, PlanetSector source) {
			IFleetInfo attackerFleet = source.GetBattleFleet();
			attackerFleet.IsInBattle = true;
			destiny.AddCelestialBodies(source);
		}

		#endregion Private
		
		#region Public

		#region Coordinate Calculation

		/// <summary>
		/// Verifies if a Fleet has Arrived
		/// </summary>
		/// <param name="coord"></param>
		/// <param name="destiny"></param>
		/// <returns></returns>
		public static bool HasArrived(SectorCoordinate coord, SectorCoordinate destiny) {
            return coord.System == destiny.System && coord.Sector == destiny.Sector;
		}

		/// <summary>
		/// Get's the possible coordinates arround a Coordinate
		/// </summary>
		/// <param name="current">Current coordinate</param>
		/// <param name="destiny">Destiny Coordinate</param>
		/// <returns></returns>
		public static List<CoordinateDistance> GetPossibleCoordinates(SectorCoordinate current, SectorCoordinate destiny) {
			List<CoordinateDistance> coordinates = new List<CoordinateDistance>();
			List<SectorCoordinate> possibleCoordinates = GetPossibleCoordinates(current);
			bool privateSystem = destiny.System.IsPrivateSystem();

			foreach (SectorCoordinate possibleCoordinate in possibleCoordinates ) {
				if ( possibleCoordinate.IsValid(privateSystem) ) {
					CoordinateDistance c = new CoordinateDistance(possibleCoordinate,destiny);
					coordinates.Add(c);
				}
			}

			coordinates.Sort(hammingDistanceComparer);
			return coordinates;
		}

		/// <summary>
		/// Obtains the possible coordinate neighbour of the passed Coordinate. X and Y are coordinates 
		/// resulting of the addition of constants. This method verifies if their are valid and adapts 
		/// them to a correct coordinate. If no coordinate can be obtained, null is retrived
		/// </summary>
		/// <param name="current">Current coordinate</param>
		/// <returns>the neightbour coordinates</returns>
		public static List<SectorCoordinate> GetPossibleCoordinates(SectorCoordinate current) {
			return GetPossibleCoordinates(current, 1);
		}

		/// <summary>
		/// Obtains the possible coordinate neighbour of the passed Coordinate. X and Y are coordinates 
		/// resulting of the addition of constants. This method verifies if their are valid and adapts 
		/// them to a correct coordinate. If no coordinate can be obtained, null is retrived
		/// </summary>
		/// <param name="current">Current coordinate</param>
		/// <param name="distanceArround">Distance around the current coordinate</param>
		/// <returns>the neightbour coordinates</returns>
		public static List<SectorCoordinate> GetPossibleCoordinates(SectorCoordinate current, int distanceArround) {
			int w = distanceArround * 2 + 1;
			int h = distanceArround * 2 + 1;

			bool privateSystem = current.System.IsPrivateSystem();

			List<SectorCoordinate> coordinates = new List<SectorCoordinate>();
			SectorCoordinate start = CoordinateRangeCalculator.GetStartSystemAndSectorVisibility(current.System, current.Sector, distanceArround, distanceArround);
			foreach (SectorCoordinate coordinate in CoordinateRangeCalculator.GetPossibleCoordinates(start, h, w)) {
				if (!coordinate.Equals(current) && coordinate.IsValid(privateSystem)) {
					AddCoordinate(coordinate, coordinates);
				}
			}
			return coordinates;
		}

		/// <summary>
		/// Obtains the possible coordinate neighbour of the passed Coordinate. X and Y are coordinates 
		/// resulting of the addition of constants. This method verifies if their are valid and adapts 
		/// them to a correct coordinate. If no coordinate can be obtained, null is retrived
		/// </summary>
		/// <param name="current">Current coordinate</param>
		/// <param name="distanceArround">Distance around the current coordinate</param>
		/// <returns>the neightbour coordinates</returns>
		public static List<SectorCoordinate> GetAllPossibleCoordinates(SectorCoordinate current, int distanceArround) {
			int w = distanceArround * 2 + 1;
			int h = distanceArround * 2 + 1;

			bool privateSystem = current.System.IsPrivateSystem();

			List<SectorCoordinate> coordinates = new List<SectorCoordinate>();
			SectorCoordinate start = CoordinateRangeCalculator.GetStartSystemAndSectorVisibility(current.System, current.Sector, distanceArround, distanceArround);
			foreach (SectorCoordinate coordinate in CoordinateRangeCalculator.GetPossibleCoordinates(start, h, w)) {
				if (coordinate.IsValid(privateSystem)) {
					AddCoordinate(coordinate, coordinates);
				}
			}
			return coordinates;
		}

		/// <summary>
		/// Get's the first good coordinate availablke
		/// </summary>
		/// <param name="coordinates">List of possible coordinates</param>
		/// <param name="destiny">Destiny Coordinate</param>
		/// <param name="lastCoordinate">Last Coordinate selected</param>
		/// <param name="owner">Owner of the fleet</param>
		/// <returns>Next coordinate where to move</returns>
        public static ISector GetFirstAvailable(List<CoordinateDistance> coordinates, SectorCoordinate destiny, List<SectorCoordinate> lastCoordinate, IPlayer owner){
			List<ISector> sectors = Universe.GetSectors(coordinates,owner);
			foreach (CoordinateDistance coord in coordinates) {
				ISector sector = sectors.Find(delegate(ISector s){
					return s.SystemCoordinate.Equals(coord.CurrentSystem) && s.SectorCoordinate.Equals(coord.CurrentSector);
				});

				if (HasArrived(sector.Coordinate, destiny)){
					return sector;
				}
                                
				if (lastCoordinate != null && lastCoordinate.Count > 0) {
					SectorCoordinate found = lastCoordinate.Find(delegate(SectorCoordinate c){
						return sector.SystemCoordinate == c.System && sector.SectorCoordinate == c.Sector;
					});
					if( found != null){
						continue;
					}
				}

				if (IsSpace(sector)) {
					return sector;
				}
			}
			return null;
		}

		#endregion Coordinate Calculation

        #region FleetSector Utils

        public static void CreateFleetSector(SectorCoordinate coordinate, IPlayer owner, string fleetName){
            CreateFleetSector(coordinate,owner,fleetName,null,true);
        }

		public static void CreateFleetSector(SectorCoordinate coordinate, IPlayer owner, string fleetName, IUnitInfo ultimate){
			CreateFleetSector(coordinate, owner, fleetName, ultimate, true);
        }

		public static void CreateFleetSector(SectorCoordinate coordinate, IPlayer owner, string fleetName, IUnitInfo ultimate, bool persist) {
			Sector sector = Universe.GetSurroundAvailableCoordinate(coordinate, owner);

			IFleetInfo fleetInfo = new FleetInfo(fleetName, owner, false, sector.Coordinate);
			fleetInfo.Movable = true;
			fleetInfo.Location = sector.Coordinate;
			fleetInfo.Owner.AddFleet(fleetInfo);
			fleetInfo.UltimateUnit = ultimate;

			if (sector is ResourceSector) {
				fleetInfo.AddCargo(sector.Resource);
			}

			FleetSector fleet = new FleetSector(sector.Coordinate.System, sector.Coordinate.Sector, fleetInfo, sector.Level);
			fleet.Storage = sector.Storage;
			fleet.Owner = owner;

			GameEngine.Persist(fleet, persist);
			fleetInfo.Id = fleetInfo.Storage.Id;

			if (coordinate.System.IsPrivateSystem()) {
				owner.PrivateSystem.UpdateSector(fleet);
			}
		}

		public static IFleetInfo CreateFleetSectorForBot(SectorCoordinate coordinate, IPlayer owner, string fleetName, int level) {
			IFleetInfo fleetInfo = new FleetInfo(fleetName, owner, false, coordinate);
			fleetInfo.Movable = true;
			fleetInfo.Location = coordinate;
			fleetInfo.Owner.AddFleet(fleetInfo);
			fleetInfo.IsBot = true;
			
			FleetSector fleet = new FleetSector(coordinate.System, coordinate.Sector, fleetInfo, level);
			fleet.Owner = owner;

			GameEngine.Persist(fleet, false,true);
			fleetInfo.Id = fleetInfo.Storage.Id;

			return fleetInfo;
		}

        #endregion FleetSector Utils

        #region Sector Convergion Utils

        /// <summary>
		/// Converts a sector into a sector storage
		/// </summary>
		/// <param name="sector">Sector to convert</param>
		/// <returns>Sector storage with the information of the sector</returns>
		public static SectorStorage ConvertToStorage( Sector sector ) {
			using( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance() ) {
				SectorStorage sectorStorage = persistance.Create();
				sectorStorage.SystemX = sector.SystemCoordinate.X;
				sectorStorage.SystemY = sector.SystemCoordinate.Y;
				sectorStorage.SectorX = sector.SectorCoordinate.X;
				sectorStorage.SectorY = sector.SectorCoordinate.Y;
				sectorStorage.IsStatic = sector.IsStatic;
				sectorStorage.IsConstructing = sector.IsConstructing;
				sectorStorage.IsInBattle = sector.IsInBattle;
				sectorStorage.IsMoving = sector.IsMoving;
				if (sector.Owner != null ) {
					sectorStorage.Owner = sector.Owner.Storage;
				}
				sectorStorage.SubType = sector.SubType;
				sectorStorage.Type = sector.Type;
				sectorStorage.Level = sector.Level;
				return sectorStorage;
			}
		}

		/// <summary>
		/// Updates a sector storage
		/// </summary>
		/// <param name="sectorStorage"></param>
		/// <param name="sector"></param>
		public static void UpdateStorage( SectorStorage sectorStorage, Sector sector) {
			sectorStorage.SystemX = sector.SystemCoordinate.X;
			sectorStorage.SystemY = sector.SystemCoordinate.Y;
			sectorStorage.SectorX = sector.SectorCoordinate.X;
			sectorStorage.SectorY = sector.SectorCoordinate.Y;
			sectorStorage.IsStatic = sector.IsStatic;
			sectorStorage.IsConstructing = sector.IsConstructing;
			sectorStorage.IsInBattle = sector.IsInBattle;
			sectorStorage.IsMoving = sector.IsMoving;
			sectorStorage.SubType = sector.SubType;
			sectorStorage.Type = sector.Type;
			sectorStorage.Level = sector.Level;
			if (sector.Owner != null) {
				sectorStorage.Owner = sector.Owner.Storage;
			}else {
				sectorStorage.Owner = null;
			}
		}

		/// <summary>
		/// Creates a ISector using a sectorstorage
		/// </summary>
		/// <param name="sector"></param>
		/// <returns></returns>
		public static ISector LoadSector(SectorStorage sector) {
			return (Sector)SectorFactories.create(sector.Type, sector);
        }

        /// <summary>
		/// Converts a Sector into a FleetSector
		/// </summary>
		/// <param name="sector"></param>
		/// <param name="fleetInfo"></param>
		/// <returns></returns>
		public static FleetSector ConvertToFleetSector( ISector sector, IFleetInfo fleetInfo ) {
			FleetSector fs = new FleetSector(sector.SystemCoordinate, sector.SectorCoordinate, fleetInfo, sector.Level);
			fs.Storage = sector.Storage;
			fs.Owner = fleetInfo.Owner;
			return fs;
		}

        public static PlanetSector ConvertToPlanetSector(ISector sector){
			PlanetSector ps = new PlanetSector(sector.SystemCoordinate, sector.SectorCoordinate, sector.GetPlanet(), sector.Level, sector.IsPrivate);
            ps.Storage = sector.Storage;

            if (Server.IsInTests){
				Universe.RemoveSector(sector);
				Universe.ReplaceSector(ps);
                GameEngine.Persist(ps, true);
            }
            return ps;
        }

		public static RelicSector ConvertToRelicSector(ISector sector) {
			RelicSector rs = new RelicSector(sector.SystemCoordinate, sector.SectorCoordinate, sector.Level);
			rs.Storage = sector.Storage;

			if (Server.IsInTests) {
				Universe.RemoveSector(sector);
				Universe.ReplaceSector(rs);
				GameEngine.Persist(rs, true, true);
			}
			return rs;
		}

		public static void ConvertPlanetSectorToPlanetBattleSector(FleetSector attacker, PlanetSector attacked, int battleId) {
            PlanetBattleSector pbs = new PlanetBattleSector(attacked.SystemCoordinate, attacked.SectorCoordinate, attacked.Level, battleId);
			SetSectorToBattle(pbs, attacker);
			SetPlanetToBattle(pbs, attacked);
			pbs.Storage = attacked.Storage;
			pbs.Owner = attacked.Owner;

			if (Server.IsInTests) {
				GameEngine.Persist(pbs, true);
			}else {
				GameEngine.Persist(pbs, false, true);
			}

			Universe.ReplaceSector(pbs);
			Universe.RemoveSector(attacker);
		}

		public static void ConvertFleetSectorToFleetBattleSector(FleetSector attacker, FleetSector attacked, int battleId) {
			FleetBattleSector fbs = new FleetBattleSector(attacked.SystemCoordinate, attacked.SectorCoordinate, attacked.Level, battleId);
			SetSectorToBattle(fbs, attacker);
			SetSectorToBattle(fbs, attacked);
		    attacked.IsDirty = false;
			
			fbs.Storage = attacked.Storage;

			GameEngine.Persist(fbs,false,true);

			Universe.RemoveSector(attacker);
			Universe.ReplaceSector(fbs);
		}

		public static void ConvertRelicSectorToRelicBattleSector(FleetSector attacker, RelicSector attacked, int battleId) {
			RelicBattleSector rbs = new RelicBattleSector(attacked.SystemCoordinate, attacked.SectorCoordinate, attacked.Level, battleId);
			SetSectorToBattle(rbs, attacker);
			SetSectorToBattle(rbs, attacked);
			rbs.Storage = attacked.Storage;
			rbs.Owner = attacked.Owner;

			if (Server.IsInTests) {
				GameEngine.Persist(rbs, true);
			} else {
				GameEngine.Persist(rbs, false, true);
			}

			Universe.ReplaceSector(rbs);
			Universe.RemoveSector(attacker);
		}

        #endregion  Sector Convergion Utils

        #region Generic

        /// <summary>
        /// Checks if a coordinate is in range of another coordinate
        /// </summary>
        /// <param name="centerCoordinate">Center Coordinate</param>
        /// <param name="surroundingCoordinate">Coordinate to test if is the surround of the center coordinate</param>
        /// <param name="distance">Distance around the center coordinate</param>
        /// <returns>If the surrounding coordinate is near the center coordinate</returns>
        public static bool IsInRange(SectorCoordinate centerCoordinate, SectorCoordinate surroundingCoordinate, int distance) {
            List<SectorCoordinate> possibleCoordinates = SectorUtils.GetPossibleCoordinates(centerCoordinate, distance);
            SectorCoordinate coord = possibleCoordinates.Find(delegate(SectorCoordinate coordinate) { return coordinate.Equals(surroundingCoordinate); });
            return coord != null;
        }

        /// <summary>
        /// Checks if a coordinate is in range of another coordinate
        /// </summary>
        /// <param name="centerCoordinate">Center Coordinate</param>
        /// <param name="surroundingCoordinate">Coordinate to test if is the surround of the center coordinate</param>
        /// <returns>If the surrounding coordinate is near the center coordinate</returns>
        public static bool IsInRange(SectorCoordinate centerCoordinate, SectorCoordinate surroundingCoordinate) {
            return IsInRange(centerCoordinate, surroundingCoordinate, 1);
        }

        /// <summary>
		/// Generates coordinates within the specified gap
		/// </summary>
		/// <param name="xSize">X Gap</param>
		/// <param name="ySize">Y Fap</param>
		/// <returns>A Enumerable of Coordinates</returns>
		public static IEnumerable<Coordinate> GenerateCoordinates(int xSize, int ySize) {
			for (int x = 1; x <= xSize; ++x) {
				for (int y = 1; y <= ySize; ++y) {
					yield return new Coordinate(x, y);
				}
			}
		}

        /// <summary>
        /// Iterates over hot zone coordinates
        /// </summary>
        /// <returns>All coordinates</returns>
        public static IEnumerable<SectorCoordinate> GetAllHotCoordinates()
        { 
            foreach( Coordinate system in SectorUtils.GenerateCoordinates(37,37) ) {
                foreach ( Coordinate sector in SectorUtils.GenerateSectorCoordinates() ) {
                    yield return new SectorCoordinate(system, sector);
                }
            }
        }

		/// <summary>
		/// Generates coordinates within the specified gap
		/// </summary>
		/// <returns>A Enumerable of Coordinates</returns>
		public static IEnumerable<Coordinate> GenerateSectorCoordinates() {
			return GenerateCoordinates(Coordinate.MaxCoordinate.X, Coordinate.MaxCoordinate.Y);
		}

		/// <summary>
		/// Checks if the given coordinate is a empty space
		/// </summary>
		/// <param name="sector">Sector to test</param>
		/// <returns></returns>
		public static bool IsSpace(ISector sector) {
			return sector is NormalSector || sector is ResourceSector;
		}

		public static List<T> ConvertToList<T>(IEnumerable collection) {
			List<T> list = new List<T>();
			foreach (T t in collection) {
				list.Add(t);
			}
			return list;
        }

		public static bool CoordinateDiscovered(SectorCoordinate destiny) {
			FogOfWarContainer fogOfWar = FogOfWarUtils.GetFogOfWar(PlayerUtils.Current);
			return !(fogOfWar.GetVisibility(destiny) is Undiscovered);
		}

        /// <summary>
        /// Gets the level of the current System
		/// </summary>
		/// <param name="system">System to get the level from</param>
		/// <returns>The level of the System</returns>
		public static int GetLevel(Coordinate system) {
			foreach (UniverseArea area in levels) {
				if (area.ContainsCoordinate(system)) {
					return area.Level;
				}
			}
			return 1;
		}

		public static List<Coordinate> ConvertWaypoints(string waypoints) {
            if (string.IsNullOrEmpty(waypoints)){
                return null;
            }
			List<Coordinate> list = new List<Coordinate>();
			string[] coords = waypoints.Split(commaSeparator,StringSplitOptions.RemoveEmptyEntries);
			foreach (string s in coords) {
				list.Add(new Coordinate(s));
			}
			return list;
		}

        public static string ConvertWaypoints(List<Coordinate> waypoints){
            if (waypoints == null || waypoints.Count == 0){
                return null;
            }
            using (StringWriter writer = new StringWriter()) {
                foreach (Coordinate coord in waypoints) {
                    writer.Write("{0}_{1};", coord.X, coord.Y);
                }
                return writer.ToString();
            }
        }

        #endregion Generic

        #endregion Public

        #region Constructor

        static SectorUtils(){
            levels.Add(new UniverseArea(16, 16, 22, 22, 10));
            levels.Add(new UniverseArea(13, 13, 25, 25, 9));
            levels.Add(new UniverseArea(10, 10, 28, 28, 7));
            levels.Add(new UniverseArea(7, 7, 31, 31, 5));
            levels.Add(new UniverseArea(4, 4, 34, 34, 3));
            levels.Add(new UniverseArea(1, 1, 37, 37, 1));
        }

        #endregion


		
	}
}
