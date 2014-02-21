using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.Universe {
	public static class UniversePersistance {

		#region Fields

		private static readonly List<WormHoleCount> wormHoleCount = new List<WormHoleCount>();
		private static List<SectorStorage> wormHoles = null;

		#endregion Fields

		#region Properties

		public static List<SectorStorage> AllWormHoles {
			get {
				if (wormHoles == null) {
					wormHoles = GetAllWormHoles();
				}
				return wormHoles;
			}
		}

		#endregion

		#region Private

		private static string GetWhere(SectorCoordinateContainer container) {
			StringBuilder builder = new StringBuilder();
			builder.Append("where ");
			Coordinate systemStart = container.SystemCoordinates[0];
			Coordinate systemEnd = container.SystemCoordinates[container.SystemCoordinates.Count-1];

			builder.AppendFormat("(s.SystemX >= {0} and s.SystemY >= {1} and s.SystemX <= {2} and s.SystemY <= {3}) ", systemStart.X, systemStart.Y, systemEnd.X,systemEnd.Y);
			return builder.ToString();
		}

		#region Loads

		private static ISystem LoadSectors(Coordinate coordinate, List<SectorStorage> sectors) {
			return LoadSectors(null, coordinate, sectors);
		}

		private static ISystem LoadSectors(IPlayer owner, Coordinate coordinate, List<SectorStorage> sectors) {
			ISystem system = new System(coordinate, 1);

			foreach (Coordinate sectorCoordinate in SectorUtils.GenerateSectorCoordinates()) {
				SectorStorage sectorStorage = sectors.Find(delegate(SectorStorage ss) {
					return sectorCoordinate.X == ss.SectorX && sectorCoordinate.Y == ss.SectorY;
				});
				ISector s;
				if (sectorStorage != null) {
					s = SectorUtils.LoadSector(sectorStorage);
				} else {
					s = new NormalSector(coordinate, sectorCoordinate, system.Level);
					s.Owner = owner;
				}
				system.AddSector(s);
			}
			if (sectors.Count != 0) {
				system.Level = sectors[0].Level;
			}

			return system;
		}

		/// <summary>
		/// Converts a list of SectorStorage objects into a list of Sector objects
		/// </summary>
		private static List<ISector> LoadSectors(SectorCoordinateContainer container, List<SectorStorage> sectors) {
			List<ISector> list = new List<ISector>();
			foreach (SectorCoordinate c in container.OrderedSectors) {
				SectorStorage sector = sectors.Find(delegate(SectorStorage st) {
					return st.SystemX == c.System.X &&
							st.SystemY == c.System.Y &&
							st.SectorX == c.Sector.X &&
							st.SectorY == c.Sector.Y;
				});
				ISector s;
				if (sector != null) {
					s = SectorUtils.LoadSector(sector);
				} else {
					s = new NormalSector(c.System, c.Sector);
				}
				list.Add(s);
			}

			return list;
		}

        /// <summary>
		/// Converts a list of SectorStorage objects into a list of Sector objects
		/// </summary>
        private static List<ISector> LoadSectors(IEnumerable fleetSectors, IEnumerable planetSectors, IEnumerable marketsSectors, IEnumerable arenasSectors, IEnumerable specialSectors){
			List<ISector> list = new List<ISector>();

			foreach (SectorStorage fleet in fleetSectors) {
                ISector s = SectorUtils.LoadSector(fleet);
				list.Add(s);
			}

            foreach (SectorStorage planet in planetSectors){
				ISector s = SectorUtils.LoadSector(planet);
				list.Add(s);
			}

            foreach (UniverseSpecialSector sector in specialSectors){
                SectorStorage sct = GetElementSector(sector.SystemX, sector.SystemY, sector.SectorX, sector.SectorY, marketsSectors, arenasSectors);
                if (sct == null) {
                    sct = sector.Sector;
                }
                ISector s = SectorUtils.LoadSector(sct);
				list.Add(s);
			}

			return list;
		}

        private static SectorStorage GetElementSector(int x,int y,int sx, int sy, IEnumerable marketsSectors, IEnumerable arenasSectors){
            foreach (SectorStorage m in marketsSectors){
                if ( m.SystemX == x && m.SystemY == y && m.SectorX == sx && m.SectorY == sy ) {
                    return m;
                }
            }

            foreach (SectorStorage m in arenasSectors){
                if ( m.SystemX == x && m.SystemY == y && m.SectorX == sx && m.SectorY == sy ) {
                    return m;
                }
            }

            return null;
        }

		private static void LoadWormHoles() {
			IList<WormHolePlayers> wormHolesCount = GetWormHolesCount();
			if (wormHolesCount != null) {
				for (int i = 0; i < AllWormHoles.Count; ++i) {
                    if (AllWormHoles[i].Level == 1) {
                        WormHoleCount count = new WormHoleCount(AllWormHoles[i], wormHolesCount[i]);
                        wormHoleCount.Add(count);
                    }
				}
			}
		}

		#endregion Loads

		/// <summary>
		/// Gets an available wormhole
		/// </summary>
		/// <returns></returns>
		private static ISector GetHotZoneWormHole() {
			if (wormHoleCount == null || wormHoleCount.Count == 0) {
				LoadWormHoles();
			}
			foreach (WormHoleCount whc in wormHoleCount) {
				if (whc.Count < 70) {
					++whc.WormHolePlayers.PlayerCount;
					SaveWormHolePlayers(whc.WormHolePlayers);
					return new WormHoleSector(whc.WormHole);
				}
			}
			return null;
		}

		private static IList GetSectorsFromDB() {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				//string[] hql = new string[2];
				string hql = "select s from SpecializedSectorStorage s left join s.OwnerNHibernate o where (s.SystemX <> 0) or (s.SystemX = 0 and o.UpdatedDate > '{0}')";
				//hql[1] = string.Format("select s from SpecializedSectorStorage s left join s.OwnerNHibernate o where ", DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd hh:mm:ss"));
				return persistance.Query(hql, DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd hh:mm:ss"));

				//List<object> list = new List<object>();
			//list.Add(Hql.StatelessQuery<SectorStorage>("select s from SpecializedSectorStorage s where s.SystemX <> 0"));
			//list.Add(Hql.StatelessQuery<SectorStorage>("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate o where s.SystemX = 0 and o.UpdatedDate > :date", Hql.Param("date", "DateTime.Now.AddMonths(-1)")));

			//return list;
			}
		}
		
		private static IList GetSectorsFromDB(string where, string planetWhere) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {

				string[] hql = new string[9];
				hql[0] = string.Format("select s from SpecializedSectorStorage s left join fetch s.FleetsNHibernate {0}", where);
				hql[1] = string.Format("select s from SpecializedSectorStorage s left join fetch s.PlanetsNHibernate p {0}", where);
				hql[2] = string.Format("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate p left join fetch p.FleetsNHibernate {0}", where);
                
				//hql[2] = string.Format("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate left join fetch s.OwnerNHibernate.AllianceNHibernate {0}", where);
				hql[3] = string.Format("select s from SpecializedSectorStorage s left join fetch s.ArenasNHibernate {0}", where);
				hql[4] = string.Format("select s from SpecializedSectorStorage s left join fetch s.MarketsNHibernate {0}", where);
				hql[5] = string.Format("select a from SpecializedAllianceStorage a inner join fetch a.DiplomacyANHibernate");
				hql[6] = string.Format("select a from SpecializedAllianceStorage a inner join fetch a.DiplomacyBNHibernate");
				hql[7] = string.Format("select s from SpecializedPlanetStorage s inner join fetch s.FleetsNHibernate {0}", planetWhere);
                hql[8] = string.Format("select s from SpecializedSectorStorage s left join fetch s.OwnerNHibernate p left join fetch p.PrincipalNHibernate {0}", where);
				return persistance.MultiQuery(hql, new Dictionary<string, object>());
			}
		}

		private static IList GetSectorsFromDBWithoutOwner(string where) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {

				string[] hql = new string[4];
				hql[0] = string.Format("select s from SpecializedSectorStorage s left join fetch s.FleetsNHibernate {0}", where);
				hql[1] = string.Format("select s from SpecializedSectorStorage s left join fetch s.PlanetsNHibernate {0}", where);
				hql[2] = string.Format("select s from SpecializedSectorStorage s left join fetch s.ArenasNHibernate {0}", where);
				hql[3] = string.Format("select s from SpecializedSectorStorage s left join fetch s.MarketsNHibernate {0}", where);
				return persistance.MultiQuery(hql, new Dictionary<string, object>());
			}
		}

        #endregion Private

        #region System and Sector Managment

		/// <summary>
		/// Loads all the sectors in the universe the Universe
		/// </summary>
		/// <returns></returns>
		public static List<ISector> LoadAllSectorsInUniverse() {
			if( Server.IsInTests) {
				using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
					List<SectorStorage> sectors = (List<SectorStorage>)persistance.Select();
					return LoadSectors(sectors);
				}	
			}

			Console.WriteLine("\n » Starting to load Universe...");
			DateTime start = DateTime.Now;
			IList allSectors = GetSectorsFromDB();
			//IList<SectorStorage> allSectorsClean = Hql.Unify(SectorUtils.ConvertToList<SectorStorage>((IEnumerable)allSectors[0]));

            Console.WriteLine("\n » Universe took {0}ms to get from DB. Loaded Sectors: {1}", (DateTime.Now - start).TotalMilliseconds, allSectors.Count);

			start = DateTime.Now;
			List<ISector> s = LoadSectors(allSectors);

			Console.WriteLine("\n » Universe took {0}ms to load into ISector Objects", (DateTime.Now - start).TotalMilliseconds);

			return s;
		}

        /// <summary>
        /// Load the system with the specified coordinate
        /// </summary>
        /// <param name="coordinate"></param>
        public static ISystem LoadSystem(Coordinate coordinate)
        {
			List<SectorStorage> sectors;
			if( Server.IsInTests) {
				sectors = new List<SectorStorage>();
				using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
					IList<SectorStorage> allSector = persistance.Select();
					foreach (SectorStorage storage in allSector) {
						if( storage.SystemX == coordinate.X && storage.SystemY == coordinate.Y ) {
							sectors.Add(storage);
						}
					}
				}
				return LoadSectors(coordinate, sectors);
			}

			string where = string.Format("where s.SystemX = {0} and s.SystemY = {1}", coordinate.X, coordinate.Y);
        	IList a  = GetSectorsFromDB(where, where);

			List<SectorStorage> allSectorsClean = (List<SectorStorage>)Hql.Unify(SectorUtils.ConvertToList<SectorStorage>((IEnumerable)a[0]));
        	return LoadSectors(coordinate, allSectorsClean);
		}

		/// <summary>
		/// Converts a list of SectorStorage objects into a list of Sector objects
		/// </summary>
		/// <param name="sectors"></param>
		/// <returns></returns>
		public static List<ISector> LoadSectors(IEnumerable sectors) {
			List<ISector> list = new List<ISector>();
			foreach (SectorStorage sector in sectors) {
				ISector s = SectorUtils.LoadSector(sector);
				list.Add(s);
			}
			return list;
		}

		/// <summary>
		/// Gets a Hot Zone Sector
		/// </summary>
		public static ISector GetSector(SectorCoordinate coordinate) {
			return GetSector(null, coordinate.System, coordinate.Sector);
		}

		/// <summary>
		/// Gets a Hot Zone Sector
		/// </summary>
		public static ISector GetSector(Coordinate systemCoordinate, Coordinate sectorCoordinate) {
			return GetSector(null, systemCoordinate, sectorCoordinate);
		}

		/// <summary>
		/// Gets a Hot Zone Sector
		/// </summary>
		public static ISector GetSector(IPlayer owner, Coordinate systemCoordinate, Coordinate sectorCoordinate) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				if (Server.IsInTests) {
					IList<SectorStorage> allSector = persistance.Select();
					foreach (SectorStorage storage in allSector) {
						if (storage.SystemX == systemCoordinate.X && storage.SystemY == systemCoordinate.Y && storage.SectorX == sectorCoordinate.X && storage.SectorY == sectorCoordinate.Y) {
							return SectorUtils.LoadSector(storage);
						}
					}
					return null;
				}

				Dictionary<string, object> args = new Dictionary<string, object>();
				args.Add("systemX", systemCoordinate.X);
				args.Add("systemY", systemCoordinate.Y);
				args.Add("sectorX", sectorCoordinate.X);
				args.Add("sectorY", sectorCoordinate.Y);

				string query = "select s from SpecializedSectorStorage s left join fetch s.FleetsNHibernate where s.SystemX = :systemX and s.SystemY = :systemY and s.SectorX = :sectorX and s.SectorY = :sectorY";
							
				if( owner != null ) {
					query += " and s.OwnerNHibernate = :player";
					args.Add("player", owner.Storage.Id);
				}

				IList<SectorStorage> sectors = Hql.Query<SectorStorage>(query, args);
				if (sectors.Count > 0) {
					return SectorUtils.LoadSector(sectors[0]);
				}
				return null;
			}
		}

		/// <summary>
		/// Get a list of sectors
		/// </summary>
		/// <param name="container"></param>
		/// <returns></returns>
		public static List<ISector> GetSectors(SectorCoordinateContainer container) {
			return GetSectors(container,true);
		}

		/// <summary>
		/// Get a list of sectors
		/// </summary>
		/// <param name="container"></param>
		/// <returns></returns>
		public static List<ISector> GetSectors(SectorCoordinateContainer container, bool loadOwner) {
			if (Server.IsInTests) {
				List<ISector> sectors = new List<ISector>();
				foreach (Coordinate coordinate in container.SystemCoordinates) {
					List<SectorCoordinate> c = container.GetSystemInformation(coordinate);
					foreach (SectorCoordinate sectorCoordinate in c) {
						ISector s = Universe.GetSector(sectorCoordinate.System, sectorCoordinate.Sector);
						sectors.Add(s);
					}
				}
				return sectors;
			} else {
				string where = GetWhere(container);
				IList sectors;
				if( loadOwner ) {
					sectors = GetSectorsFromDB(where,where);	
				}else {
					sectors = GetSectorsFromDBWithoutOwner(where);
				}
				
				return LoadSectors(container, SectorUtils.ConvertToList<SectorStorage>((IList)sectors[0]));
			}
		}

        /// <summary>
		/// Get a list of spacial sectors (Markets, arenas and wormholes found by the user) and all
		/// the fleets and planets in the hot zone
		/// </summary>
		/// <returns></returns>
        public static List<ISector> GetSpecialSectors(IPlayer owner){
			if (!Server.IsInTests) {
                using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()){
                    Dictionary<string, object> param = new Dictionary<string, object>();
                    param.Add("player", owner.Id);
                    string[] hql = new string[5];
					hql[0] = "select s from SpecializedSectorStorage s left join fetch s.FleetsNHibernate where s.OwnerNHibernate.Id = :player and s.SystemX != 0 and s.Type = 'FleetSector'";
					hql[1] = "select s from SpecializedSectorStorage s left join fetch s.PlanetsNHibernate where s.OwnerNHibernate.Id = :player and s.SystemX != 0 and s.Type = 'PlanetSector'";
                    hql[2] = "select s from SpecializedSectorStorage s left join fetch s.MarketsNHibernate where s.Type = 'MarketSector'";
                    hql[3] = "select s from SpecializedSectorStorage s left join fetch s.ArenasNHibernate where s.Type = 'ArenaSector'";
					hql[4] = "select s from SpecializedUniverseSpecialSector s left join fetch s.SectorNHibernate where s.OwnerNHibernate.Id = :player";
                    IList list = persistance.MultiQuery(hql, param);
                    return LoadSectors((IEnumerable)list[0], (IEnumerable)list[1],(IEnumerable)list[2],(IEnumerable)list[3],(IEnumerable)list[4]);
                }
			}
            return new List<ISector>();
		}

        

		/// <summary>
		/// Load the system with the specified coordinate
		/// </summary>
		/// <param name="player">player that owns the system</param>
		public static ISystem LoadPrivateSystem(IPlayer player) {
			string where = string.Format("where s.SystemX = 0 and s.SystemY = 0 and s.OwnerNHibernate.Id = {0}", player.Storage.Id);
			string planetWhere = string.Format("where s.SystemX = 0 and s.SystemY = 0 and s.PlayerNHibernate.Id = {0}", player.Storage.Id);
			IList sectors = GetSectorsFromDB(where, planetWhere);
			return LoadSectors(player, Coordinate.PrivateSectorCoordinate, SectorUtils.ConvertToList<SectorStorage>((IList)sectors[0]));
		}


		/// <summary>
		/// Removes the passed sector
		/// </summary>
		public static void RemoveSector(ISector sector) {
			using (ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				if (sector.Storage != null ) {
					persistance.Delete(sector.Storage.Id);
				}
			}
		}

		#endregion System and Sector Manipulation

		#region SpecialSectores

		/// <summary>
		/// Adds a new discovered sector to the user
		/// </summary>
		/// <param name="player">Owner of the fleet</param>
		/// <param name="sector">Sector that represents the wormhole</param>
        /// <param name="type">Special sector type</param>
		public static bool AddSpecialSector(IPlayer player, ISector sector, SpecialSectorType type) {
            using (IUniverseSpecialSectorPersistance persistance = Persistance.Instance.GetUniverseSpecialSectorPersistance()){
                IList<UniverseSpecialSector> sectores = persistance.TypedQuery("select w from SpecializedUniverseSpecialSector w where w.OwnerNHibernate.Id = {0} and w.SystemX = {1} and w.SystemY = {2} and w.SectorX = {3} and w.SectorY = {4} and w.Type='{5}'", 
                    player.Storage.Id, sector.SystemCoordinate.X, sector.SystemCoordinate.Y, sector.SectorCoordinate.X, sector.SectorCoordinate.Y, type.ToString());

                if (sectores.Count == 0 && sectores.Count == 0 && sector.SectorCoordinate.X > 0 && sector.SectorCoordinate.Y > 0){
                    UniverseSpecialSector w = persistance.Create();
                    w.SystemX = sector.SystemCoordinate.X;
                    w.SystemY = sector.SystemCoordinate.Y;
                    w.SectorX = sector.SectorCoordinate.X;
                    w.SectorY = sector.SectorCoordinate.Y;
                    w.Type = type.ToString();
                    w.Owner = player.Storage;
                    w.Sector = sector.Storage;

                    persistance.Update(w);
                    player.SpecialSectors.Add(w);

                    return true;
				}
				return false;
			}
		}

		/// <summary>
		/// Adds a new wormhole to the list of wormholes
		/// </summary>
		/// <param name="player">Owner of the fleet</param>
		public static bool AddPrivateWormHole(IPlayer player) {
			if( player.SpecialSectors.Count == 1 ) {
				ISector sector = GetHotZoneWormHole();
				return AddSpecialSector(player, sector, SpecialSectorType.Wormhole);
			}
			return false;
		}

		/// <summary>
		/// Gets all the wormholes in the universe
		/// </summary>
		/// <returns>A list of sectorStorage that represent the wormholes</returns>
		public static List<SectorStorage> GetAllWormHoles() {
			using ( ISectorStoragePersistance persistance = Persistance.Instance.GetSectorStoragePersistance()) {
				return (List<SectorStorage>)persistance.SelectByType("WormHoleSector");
			}
		}

		/// <summary>
		/// Gets all the wormholes in the universe
		/// </summary>
		/// <returns>A list of sectorStorage that represent the wormholes</returns>
		public static IList<WormHolePlayers> GetWormHolesCount() {
			using (IWormHolePlayersPersistance persistance = Persistance.Instance.GetWormHolePlayersPersistance()) {
				return persistance.Select();
			}
		}

		/// <summary>
		/// Saves the object WormHolePlayers, object that contains the number of player per wormhole
		/// </summary>
		/// <param name="wormHolePlayers"></param>
		public static void SaveWormHolePlayers(WormHolePlayers wormHolePlayers) {
			using (IWormHolePlayersPersistance persistance = Persistance.Instance.GetWormHolePlayersPersistance()) {
				persistance.Update(wormHolePlayers);
				persistance.Flush();
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="player">Current Player</param>
		/// <param name="system">Coordinate of the system</param>
		public static SectorCoordinate GetWormHoleCoordinate(IPlayer player, Coordinate system) {
			if (system.IsPrivateSystem()) {
                UniverseSpecialSector result = player.SpecialSectors.Find(delegate(UniverseSpecialSector s) { return s.SystemX == system.X && s.SystemY == system.Y && s.Type == SpecialSectorType.Wormhole.ToString(); });
				if (result != null) {
					return new SectorCoordinate(system, new Coordinate(result.SectorX, result.SectorY));
				}
			} else {
				SectorStorage result = AllWormHoles.Find(delegate(SectorStorage s) { return s.SystemX == system.X && s.SystemY == system.Y; });
				if (result != null) {
					return new SectorCoordinate(system, new Coordinate(result.SectorX, result.SectorY));
				}
			}
			return null;
        }

        #endregion SpecialSectores

        #region FogOfWar

        /// <summary>
		/// Gets all the fogs of war of all players
		/// </summary>
		/// <returns></returns>
		public static IList<FogOfWarStorage> GetAllFogOfWar() {
			using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()) {
				return fogPersistance.TypedQuery("select f from SpecializedFogOfWarStorage f left join f.OwnerNHibernate");
			}
		}

        /// <summary>
        /// Gets all the fogs of war of all players
        /// </summary>
        /// <returns></returns>
        public static IList<FogOfWarStorage> GetPrivateFogOfWar(){
            using (IFogOfWarStoragePersistance fogPersistance = Persistance.Instance.GetFogOfWarStoragePersistance()){
                return fogPersistance.TypedQuery("select f from SpecializedFogOfWarStorage f left join f.OwnerNHibernate where f.SystemX = 0");
            }
        }

		#endregion FogOfWar

	}
}
