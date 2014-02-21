using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Engine.Common;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public static class Universe {

		#region Fields

		private static readonly Dictionary<Coordinate,ISystem> universe = new Dictionary<Coordinate, ISystem>();
		private static readonly Dictionary<int, ISystem> privateUniverse = new Dictionary<int, ISystem>();
		private static readonly List<FleetSector> fleets = new List<FleetSector>();
        private static readonly List<FleetSector> allfleets = new List<FleetSector>();
		private static readonly List<FleetSector> botFleets = new List<FleetSector>();
		private static readonly Dictionary<int, FogOfWarContainer> fogsOfWar = new Dictionary<int, FogOfWarContainer>();

		#endregion Fields

		#region Properties

		public static Dictionary<Coordinate,ISystem> AllUniverse {
			get{ return universe; }
		}

		public static Dictionary<int, ISystem> PrivateUniverses {
			get { return privateUniverse; }
		}

		public static List<FleetSector> FleetsInMovement {
			get { return fleets; }
		}

        public static List<FleetSector> PrivateFleetsInMovement{
            get { return fleets.FindAll(delegate(FleetSector f) { return f.Coordinate.System.X == 0; }); }
        }

		public static List<FleetSector> BotFleets {
			get { return botFleets; }
		}

        public static List<FleetSector> AllFleets {
            get { return allfleets; }
		}

		#endregion Properties

		#region Private

		#region LoadUniverse

		private static ISystem GetHotZoneSystem(ISector sector) {
			if (!universe.ContainsKey(sector.SystemCoordinate)) {
				ISystem system = new System(sector.SystemCoordinate, sector.Level);
				universe.Add(sector.SystemCoordinate, system);
				return system;
			} 
			return universe[sector.SystemCoordinate];
		}

		private static ISystem GetPrivateSystem(ISector sector) {
			if (!privateUniverse.ContainsKey(sector.Owner.Id)) {
				ISystem system = new System(sector.SystemCoordinate, sector.Level, sector.Owner);
				privateUniverse.Add(sector.Owner.Id, system);
				return system;
			} 
			return privateUniverse[sector.Owner.Id];
		}

		private static ISystem GetSystem(ISector sector) {
			if (sector.SystemCoordinate.IsPrivateSystem()) {
				return GetPrivateSystem(sector);
			}
			return GetHotZoneSystem(sector);
		}

		private static void AddFleetSector(ISector sector) {
			if (sector is FleetSector) {
				FleetSector s = (FleetSector)sector;
			    s.GetBattleFleet().Location = s.Coordinate;
				if (sector.GetBattleFleet().IsBot && !sector.IsMoving) {
					botFleets.Add(s);
				}
				if (sector.IsMoving) {
					fleets.Add(s);
				}
			    allfleets.Add(s);
			}
		}

		private static void AddNormalSectors(ISystem system) {
			AddNormalSectors(system, null);
		}

		private static void AddNormalSectors(ISystem system, IPlayer owner ) {
			foreach (Coordinate s in SectorUtils.GenerateSectorCoordinates()) {
				if (!system.HasSector(s)) {
					NormalSector normal = new NormalSector(system.Coordinate, s, system.Level);
					normal.Owner = owner;
					system.AddSector(normal);
				}
			}
		}

		private static void AddNormalSectors() {
			foreach (ISystem system in universe.Values) {
				AddNormalSectors(system);
			}

			foreach (ISystem system in privateUniverse.Values) {
				AddNormalSectors(system, system.Owner);
			}
		}

		private static void LoadFogOfWar() {
			DateTime start = DateTime.Now;
			IList<FogOfWarStorage> fogStorage = UniversePersistance.GetAllFogOfWar();
			foreach( FogOfWarStorage fogOfWar in fogStorage) {
				if( fogOfWar.Owner != null){
					int id = fogOfWar.Owner.Id;
					if(!fogsOfWar.ContainsKey(id)) {
						fogsOfWar.Add(fogOfWar.Owner.Id,new FogOfWarContainer());
					}
					fogsOfWar[id].AddFogOfWar(fogOfWar);
				}
			}
			Console.WriteLine(" » FogOfWar took {0}ms to load", (DateTime.Now - start).TotalMilliseconds);
		}

        private static void LoadPrivateFogOfWar() {
			DateTime start = DateTime.Now;
			IList<FogOfWarStorage> fogStorage = UniversePersistance.GetPrivateFogOfWar();
			foreach( FogOfWarStorage fogOfWar in fogStorage) {
				if( fogOfWar.Owner != null){
					int id = fogOfWar.Owner.Id;
					if(!fogsOfWar.ContainsKey(id)) {
						fogsOfWar.Add(fogOfWar.Owner.Id,new FogOfWarContainer());
					}
					fogsOfWar[id].AddFogOfWar(fogOfWar);
				}
			}
			Console.WriteLine(" » Private FogOfWar took {0}ms to load", (DateTime.Now - start).TotalMilliseconds);
		}

		#endregion LoadUniverse

		/// <summary>
		/// Finds an available sector around the passed coordinate
		/// </summary>
		private static Sector GetSurroundAvailableCoordinate(SectorCoordinate coordinate, IPlayer owner, bool loadOwner) {
			List<ISector> sectors;

			if (universe.Count > 0) {
				List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(coordinate, 10);
				sectors = GetSectors(coordinates, owner);
			} else {
				if (coordinate.System.IsPrivateSystem()) {
					ISystem system = owner.PrivateSystem;
					sectors = new List<ISector>(system.Sectors.Values);
				} else {
					if (loadOwner) {
						sectors = UniverseUtils.GetUniverseWithSector(coordinate);	
					}else {
						sectors = UniverseUtils.GetUniverseWithSectorWithoutPlayer(coordinate);
					}
				}
			}

			HammingSectorComparer hammingSectorComparer = new HammingSectorComparer(coordinate);

			sectors.Sort(hammingSectorComparer);
			foreach (Sector sector in sectors) {
				if (SectorUtils.IsSpace(sector)) {
					return sector;
				}
			}
			return null;
		}

		#endregion Private

		#region Public

		/// <summary>
		/// Adds a new system to the universe
		/// </summary>
		/// <param name="system"></param>
		public static void AddSystem(System system) {
			universe.Add(system.Coordinate, system);
		}

		/// <summary>
		/// Replaces a Sector
		/// </summary>
		/// <param name="sector">Fleets sector to swap</param>
		public static void ReplaceSector(ISector sector) {
			ISystem s = GetSystem(sector);
			s.RemoveSector(sector.SectorCoordinate);
			s.AddSector(sector);
		}

		#region Get

		public static ISystem GetSystem(Coordinate coordinate) {
			if( universe.ContainsKey(coordinate)) {
				return universe[coordinate];
			}
			throw new EngineException("System {0} should exist", coordinate);
		}

		public static ISystem GetPrivateSystem(int ownerId) {
			if (privateUniverse.ContainsKey(ownerId)) {
				return privateUniverse[ownerId];
			}
			return null;
		}

        /// <summary>
        /// Gets a Sector
        /// </summary>
		/// <param name="coordinate">Coordinate of the system</param>
        /// <returns></returns>
        public static ISector GetSector(SectorCoordinate coordinate){
            return GetSector(null, coordinate.System, coordinate.Sector);
        }
        
		/// <summary>
		/// Gets a Sector
		/// </summary>
		/// <param name="systemCoordinate">Coordinate of the system</param>
		/// <param name="sectorCoordinate">Coordinate of the sector</param>
		/// <returns></returns>
		public static ISector GetSector(Coordinate systemCoordinate, Coordinate sectorCoordinate) {
			return GetSector(null, systemCoordinate, sectorCoordinate);
		}


		/// <summary>
		/// Gets a Sector
		/// </summary>
		/// <param name="player">Current Player </param>
		/// <param name="systemCoordinate">Coordinate of the system</param>
		/// <param name="sectorCoordinate">Coordinate of the sector</param>
		/// <returns></returns>
		public static ISector GetSector(IPlayer player, Coordinate systemCoordinate, Coordinate sectorCoordinate) {
			if (player != null && systemCoordinate.IsPrivateSystem()) {
				return player.GetSector(sectorCoordinate);
			}
			if (universe.ContainsKey(systemCoordinate)) {
				return universe[systemCoordinate].GetSector(sectorCoordinate);
			}

			return new NormalSector(systemCoordinate, sectorCoordinate,player);
		}

        /// <summary>
		/// Gets a Sector
		/// </summary>
        /// <param name="coordinates">List of coordinates to retrieve</param>
        /// <param name="player">Current Player </param>
		/// <returns></returns>
        public static List<ISector> GetSectors(List<CoordinateDistance> coordinates, IPlayer player){
            if (coordinates[0].CurrentSystem.IsPrivateSystem()){
				return player.GetSectors(coordinates);
			}
			List<ISector> sectors = new List<ISector>();
			foreach (CoordinateDistance coord in coordinates) {
				ISector sector = GetSector(coord.CurrentSystem, coord.CurrentSector);
				sectors.Add(sector);
        	}
        	return sectors;
		}

		/// <summary>
		/// Gets a list of Sectors
		/// </summary>
		/// <param name="coordinates">List of coordinates to retrieve</param>
		/// <returns></returns>
		public static List<ISector> GetSectors(List<SectorCoordinate> coordinates) {
			return GetSectors(coordinates, null);
		}

		/// <summary>
		/// Gets a list of Sectors
		/// </summary>
		/// <param name="coordinates">List of coordinates to retrieve</param>
		/// <param name="player">Current Player </param>
		/// <returns></returns>
		public static List<ISector> GetSectors(List<SectorCoordinate> coordinates, IPlayer player) {
			if (coordinates[0].System.IsPrivateSystem()) {
				return player.GetSectors(coordinates);
			}
			List<ISector> sectors = new List<ISector>();
			foreach (SectorCoordinate coord in coordinates) {
				ISector sector = GetSector(coord.System, coord.Sector);
				sectors.Add(sector);
			}
			return sectors;
		}

		#endregion Get
		
		#region Remove, Replace and Swap

		/// <summary>
		/// Swaps the 2 sectors
		/// </summary>
		/// <param name="fleetSector">Fleets sector to swap</param>
		/// <param name="sector">Normal sector to swap</param>
		public static void SwapSectors(FleetSector fleetSector, ISector sector) {
			ISystem s = GetSystem(fleetSector);
			ISystem s1 = GetSystem(sector);
			
			s.RemoveSector(fleetSector.SectorCoordinate);
			s1.RemoveSector(sector.SectorCoordinate);

			SectorCoordinate c = fleetSector.Coordinate;
			fleetSector.Coordinate = sector.Coordinate;
			sector.Coordinate = c;

			s1.AddSector(fleetSector);
			s.AddSector(sector);

            if (sector.Coordinate.System.IsPrivateSystem()){
                sector.Owner = fleetSector.Owner;
            }

			if( sector is ResourceSector ) {
				if( sector.Resource != null){
					fleetSector.GetBattleFleet().AddCargo(sector.Resource);
					Messenger.Add(new CatchResourcesMessage(fleetSector.Owner.Id, sector.Resource.Quantity, sector.Resource.Resource.Name));
				}
				UniversePersistance.RemoveSector(sector);
			}
		}

		/// <summary>
		/// Removes the passed sector
		/// </summary>
		/// <param name="sector">The sector to remove</param>
		public static void RemoveSector(ISector sector) {
			if (universe.ContainsKey(sector.SystemCoordinate)) {
				ISystem system = universe[sector.SystemCoordinate];
				system.RemoveSector(sector.SectorCoordinate);
				UniversePersistance.RemoveSector(sector);
			}
		}
		
		#endregion Remove, Replace and Swap

		/// <summary>
		/// Finds an available sector around the passed coordinate
		/// </summary>
		public static Sector GetSurroundAvailableCoordinate(SectorCoordinate coordinate, IPlayer owner) {
			return GetSurroundAvailableCoordinate(coordinate, owner, true);
		}

		/// <summary>
		/// Finds an available sector around the passed coordinate
		/// </summary>
		public static Sector GetSurroundAvailableCoordinateInBattle(SectorCoordinate coordinate, IPlayer owner) {
			return GetSurroundAvailableCoordinate(coordinate, owner, false);
		}

		public static void Clear() {
			universe.Clear();
			privateUniverse.Clear();
			fleets.Clear();
			fogsOfWar.Clear();
		}

		public static void LoadUniverse() {
			Clear();
			DateTime start = DateTime.Now;
			List<ISector> sectors = UniversePersistance.LoadAllSectorsInUniverse();

            List<ISector> repeatedSectors = new List<ISector>();
			foreach (ISector sector in sectors) {
				ISystem system = GetSystem(sector);
                if (!system.HasSector(sector.Coordinate.Sector)) {
                    system.AddSector(sector);
                    AddFleetSector(sector);
                }else{
                    repeatedSectors.Add(sector);
                }
			}
            ResolveRepeatedSectors(repeatedSectors);
			Console.WriteLine("\n » Universe took {0}ms to load", (DateTime.Now - start).TotalMilliseconds);
			AddNormalSectors();
			LoadFogOfWar();
		}

        public static void LoadPrivateUniverse() {
			Clear();
			DateTime start = DateTime.Now;
			List<ISector> sectors = UniversePersistance.LoadAllSectorsInUniverse();

            List<ISector> repeatedSectors = new List<ISector>();
			foreach (ISector sector in sectors) {
				ISystem system = GetSystem(sector);
                if (!system.HasSector(sector.Coordinate.Sector)){
				    system.AddSector(sector);
				    AddFleetSector(sector);
                }else {
                    repeatedSectors.Add(sector);
                }
			}
            ResolveRepeatedSectors(repeatedSectors);

            Console.WriteLine("\n » Private Universe took {0}ms to load", (DateTime.Now - start).TotalMilliseconds);
			AddNormalSectors();
            LoadPrivateFogOfWar();
		}
		
		/// <summary>
		/// Gets the fog of war of the player with the specified id
		/// </summary>
		/// <param name="ownerId">Owner of the fog of war</param>
		/// <returns></returns>
		internal static FogOfWarContainer GetFogOfWar( int ownerId ) {
			if( fogsOfWar.ContainsKey(ownerId)) {
				return fogsOfWar[ownerId];
			}
			FogOfWarContainer f = new FogOfWarContainer();
			fogsOfWar.Add(ownerId,f);
			return f;
		}

		#endregion Public

        #region Repeated Sectors Hack

        private static void ResolveRepeatedSectors(List<ISector> repeatedSectors){
            foreach (ISector sector in repeatedSectors)
            {
                Console.WriteLine("\n » Processing repeated sector '{0}'", sector.Coordinate);
                ISystem system = GetSystem(sector);
                SectorCoordinate sectorCoordinate = GetFreeCoordinate(system, sector);
                if (sector is FleetSector) {
                    try{
                        IFleetInfo fleetInfo = sector.GetBattleFleet();
                        sector.Coordinate = sectorCoordinate;
                        system.AddSector(sector);
                        AddFleetSector(sector);    
                    }catch (EngineException) {
                        Console.WriteLine("\n » Processing repeated sector '{0}'", sector.Coordinate);
                        UniversePersistance.RemoveSector(sector);
                    }
                }else {
                    sector.Coordinate = sectorCoordinate;
                    system.AddSector(sector);
                }
                
                Console.WriteLine("\n » Processing done. New coordinate:  '{0}'", sector.Coordinate);
            }
        }

        private static SectorCoordinate GetFreeCoordinate(ISystem system, ISector sector) {
            return GetFreeCoordinate(system, sector, 1);
        }

	    private static SectorCoordinate GetFreeCoordinate(ISystem system, ISector sector, int distanceArround){
            List<SectorCoordinate> coordinates = SectorUtils.GetPossibleCoordinates(sector.Coordinate, distanceArround);
            foreach (SectorCoordinate coordinate in coordinates) {
                if( !system.HasSector(coordinate.Sector) ) {
                    return coordinate;
                }
            }
            return GetFreeCoordinate(system, sector, distanceArround + 1);
        }

        #endregion Repeated Sectors Hack

    }
}
