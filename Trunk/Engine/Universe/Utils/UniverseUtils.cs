using System.Collections.Generic;
using System.IO;
using System.Text;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Common;
using OrionsBelt.Engine.Universe;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine.Universe {
	public static class UniverseUtils {

		#region Fields

		private delegate SectorInformation GetSectorInformation(ISector sector, IPlayer player);
		private static readonly Dictionary<string, GetSectorInformation> sectorInformationMapping = new Dictionary<string, GetSectorInformation>();

		#endregion Fields

		#region Sector Information Delegates

		private static SectorInformation CreateFleetSectorInformation(ISector sector, IPlayer player) {
			return new FleetSectorInformation(sector);
		}

		private static SectorInformation CreatePlanetSectorInformation(ISector sector, IPlayer player) {
			return new PlanetSectorInformation(sector);
		}

		private static SectorInformation CreateBattleFleetSectorInformation(ISector sector, IPlayer player) {
			return new BattleFleetSectorInformation(sector);
		}

		private static SectorInformation CreateWormHoleSectorInformation(ISector sector, IPlayer player) {
			return new WormHoleSectorInformation(sector);
		}

		private static SectorInformation CreateDefaultSectorInformation(ISector sector, IPlayer player) {
			return new SectorInformation(sector);
		}

		private static SectorInformation CreateMarketSectorInformation(ISector sector, IPlayer player) {
			return new MarketSectorInformation(sector);
		}

		private static SectorInformation CreateArenaSectorInformation(ISector sector, IPlayer player) {
			return new ArenaSectorInformation(sector);
		}

		private static SectorInformation CreateBattlePlanetSectorInformation(ISector sector, IPlayer player) {
			return new BattlePlanetSectorInformation(sector);
		}

		private static SectorInformation CreateBugsWormHoleSectorInformation(ISector sector, IPlayer player) {
			return new BugsWormHoleSectorInformation(sector);
		}

		private static SectorInformation CreateBeaconSectorInformation(ISector sector, IPlayer player) {
			return new BeaconSectorInformation(sector,player);
		}

		private static SectorInformation CreateAcademySectorInformation(ISector sector, IPlayer player) {
			return new AcademySectorInformation(sector);
		}

		private static SectorInformation CreatePirateBaySectorInformation(ISector sector, IPlayer player) {
			return new PirateBaySectorInformation(sector);
		}

		private static SectorInformation CreateRelicSectorInformation(ISector sector, IPlayer player) {
			return new RelicSectorInformation(sector);
		}

		private static SectorInformation CreateBattleRelicSectorInformation(ISector sector, IPlayer player) {
			return new BattleRelicSectorInformation(sector);
		}

		#endregion Sector Information Delegates

		#region Private

		#region Json Utils

		private static void FillSystemJson(StringBuilder builder, List<SectorInformation> list) {
			bool first = true;
			foreach (SectorInformation information in list) {
				if (!first) {
					builder.AppendFormat(",{0}", information.ToJson());
				} else {
					builder.Append(information.ToJson());
					first = false;
				}
			}
		}

		private static string GetJson(SectorInformationContainer sectorInformationContainer) {
			StringBuilder builder = new StringBuilder();
			builder.Append("var UniverseInfo = { ");

			bool first = true;
			foreach (Coordinate systemCoordinate in sectorInformationContainer.SystemCoordinates) {
				if (first) {
					builder.AppendFormat("'{0}':{{", systemCoordinate);
					first = false;
				} else {
					builder.AppendFormat(",'{0}':{{", systemCoordinate);
				}
				List<SectorInformation> list = sectorInformationContainer.GetSystemInformation(systemCoordinate);
				FillSystemJson(builder, list);
				builder.Append("}");
			}
			builder.Append("}");

			return builder.ToString();
		}

		#endregion Json Utils

		private static SectorInformationContainer FillSectorInformationContainer(IEnumerable<ISector> sectors) {
			return FillSectorInformationContainer(sectors, PlayerUtils.Current);
		}

		private static SectorInformationContainer FillSectorInformationContainer(IEnumerable<ISector> sectors, IPlayer player) {
			SectorInformationContainer sectorInformationContainer = new SectorInformationContainer();
			
			foreach (ISector sector in sectors) {
				SectorInformation information;
				string sectorType = sector.GetType().Name;
				if( TestEmptyFleetSector(sector) ) {
					NormalSector normalSector = new NormalSector(sector.SystemCoordinate, sector.SectorCoordinate);
					information = CreateDefaultSectorInformation(normalSector, player);
				}else{
					if (sectorInformationMapping.ContainsKey(sectorType)) {
						information = sectorInformationMapping[sectorType](sector, player);
					} else {
						information = CreateDefaultSectorInformation(sector, player);
					}
				}
				sectorInformationContainer.Add(information);
				if( sectorInformationContainer.Level == 0 ) {
					sectorInformationContainer.Level = sector.Level;
				}
			}
			return sectorInformationContainer;
		}

		/// <summary>
		/// Failsafe
		/// </summary>
		/// <param name="sector"></param>
		private static bool TestEmptyFleetSector(ISector sector) {
			if (sector is FleetSector) {
				try {
					sector.GetBattleFleet();
				} catch (EngineException e) {
					UniversePersistance.RemoveSector(sector);
					Persistance.Flush();
					Logger.Error("Compromised Fleet Sector erased! {0}", e);
					return true;
				}
			}
			return false;
		}

		private static void SetFogOfWar(SectorInformationContainer sectorInformationContainer) {
			FogOfWarContainer container = FogOfWarUtils.GetFogOfWar(sectorInformationContainer);
			foreach (SectorInformation sectorInformation in sectorInformationContainer.OrderedSectors) {
				if( sectorInformation.HasFogOfWar() ) {
					container.AddVisibleCoordinates(sectorInformation);
				}
			}

			SetSectorVisibility(sectorInformationContainer, container, PlayerUtils.Current);
			ResolveBeacons(sectorInformationContainer.OrderedSectors, PlayerUtils.Current);
		}

		private static void SetFogOfWar(SectorInformationContainer sectorInformationContainer, IPlayer owner) {
			FogOfWarContainer container = Universe.GetFogOfWar(owner.Id);
			foreach (SectorInformation sectorInformation in sectorInformationContainer.OrderedSectors) {
				if (sectorInformation.HasFogOfWar(owner)) {
					container.AddVisibleCoordinates(sectorInformation);
				}
			}

			SetSectorVisibility(sectorInformationContainer, container, owner);
			ResolveBeacons(sectorInformationContainer.OrderedSectors, owner);
		}

		private static void SetSectorVisibility(SectorInformationContainer sectorInformationContainer, FogOfWarContainer container, IPlayer player) {
			bool buyNoUndiscoveredUniverse = player.HasService(ServiceType.BuyNoUndiscoveredUniverse);
			bool buyFullLineOfSight = player.HasService(ServiceType.BuyFullLineOfSight);
			foreach (SectorInformation sectorInformation in sectorInformationContainer.OrderedSectors) {
				sectorInformation.Visibility = container.GetVisibility(sectorInformation);

				if (sectorInformation.Visibility is Discovered || sectorInformation.Visibility is Undiscovered) {
					if( buyNoUndiscoveredUniverse && buyFullLineOfSight ) {
						sectorInformation.Visibility = FleetVisible.Instance;
						continue;
					}
					if (sectorInformation.Visibility is Discovered && buyFullLineOfSight) {
						sectorInformation.Visibility = FleetVisible.Instance;
						continue;
					}
					if (sectorInformation.Visibility is Undiscovered && buyNoUndiscoveredUniverse) {
						sectorInformation.Visibility = Discovered.Instance;
						continue;
					}
				}
			}
		}

		private static void ResolveBeacons(List<SectorInformation> list, IPlayer owner) {
			List<SectorInformation> beacons = list.FindAll(delegate(SectorInformation s) { return s is BeaconSectorInformation; });
			foreach (SectorInformation beacon in beacons) {
				if( beacon.Owner.Id != owner.Id) {
					AddBeaconVisibleCoordinates(beacon, list);
				}
			}
		}

		private static void AddBeaconVisibleCoordinates(SectorInformation currentSector, List<SectorInformation> elements) {
			int w = currentSector.WidthVisibility * 2 + 1;
			int h = currentSector.HeightVisibility * 2 + 1;

			SectorCoordinate start = CoordinateRangeCalculator.GetStartSystemAndSectorVisibility(currentSector.Coordinate.System, currentSector.Coordinate.Sector, currentSector.HeightVisibility, currentSector.WidthVisibility);
			foreach (SectorCoordinate coordinate in CoordinateRangeCalculator.GetPossibleCoordinates(start, h, w)) {
				SectorInformation sector = elements.Find(
					delegate(SectorInformation s) {
						return s.Coordinate.Equals(coordinate);
					}
				);
				if (sector != null) {
					UniverseVisibility curr = sector.Visibility;
					if( !(curr is Undiscovered || curr is Discovered) ) {
						sector.Visibility = curr.EvalImportance(currentSector.VisibleToken);	
					}
				}
			}
		}

		private static SectorInformationContainer GetSectorInformationContainer(IEnumerable<ISector> sectors) {
			return GetSectorInformationContainer(sectors, true);
		}

		private static SectorInformationContainer GetSectorInformationContainer(IEnumerable<ISector> sectors, bool getFogOfWar) {
			SectorInformationContainer sectorInformationContainer = FillSectorInformationContainer(sectors);
			if (getFogOfWar) {
				SetFogOfWar(sectorInformationContainer);
			} else {
				sectorInformationContainer.SetAllVisible();
			}
			sectorInformationContainer.SortAll();
			return sectorInformationContainer;
		}


		#endregion Private

		#region Public

		/// <summary>
		/// Obtains the part of the universe centered in the passed coordinates
		/// </summary>
		/// <param name="coordinate">Coordinate of the system and sector to center the view</param>
		/// <returns>Que surrounding area</returns>
		public static List<ISector> GetUniverseWithSector(SectorCoordinate coordinate) {
			SectorCoordinateContainer sectorInformationContainer = GetCoordinateRange(coordinate.System, coordinate.Sector);
			return UniversePersistance.GetSectors(sectorInformationContainer);
		}

		/// <summary>
		/// Obtains the part of the universe centered in the passed coordinates
		/// </summary>
		/// <param name="coordinate">Coordinate of the system and sector to center the view</param>
		/// <returns>Que surrounding area</returns>
		public static List<ISector> GetUniverseWithSectorWithoutPlayer(SectorCoordinate coordinate) {
			SectorCoordinateContainer sectorInformationContainer = GetCoordinateRange(coordinate.System, coordinate.Sector);
			return UniversePersistance.GetSectors(sectorInformationContainer,false);
		}

		/// <summary>
		/// Obtains the a container with all the coordinates surrounding the passed cordinates
		/// </summary>
		/// <param name="system">Coordinate of the system to center the view</param>
		/// <param name="sector">Coordinate of the sector to center the view</param>
		/// <returns>Que surrounding area</returns>
		public static SectorCoordinateContainer GetCoordinateRange(Coordinate system, Coordinate sector) {
			return GetCoordinateRange(system, sector, 9, 15);
		}

		/// <summary>
		/// Obtains the a container with all the coordinates surrounding the passed cordinates
		/// </summary>
		/// <param name="system">Coordinate of the system to center the view</param>
		/// <param name="sector">Coordinate of the sector to center the view</param>
		/// <param name="x">Number of X squares to retrive (vertical)</param>
		/// <param name="y">Number of Y squares to retrive (horizontal)</param>
		/// <returns>Que surrounding area</returns>
		public static SectorCoordinateContainer GetCoordinateRange(Coordinate system, Coordinate sector, int x, int y ) {
			int x2 = x/2;
			int y2 = y/2;
			SectorCoordinate startInfo = CoordinateRangeCalculator.GetStartSystemAndSector(system, sector, x2, y2);
			SectorCoordinateContainer sectorInformationContainer = new SectorCoordinateContainer();
			sectorInformationContainer.StartCoordinate = new SectorCoordinate(startInfo.System.X, startInfo.System.Y, startInfo.Sector.X, startInfo.Sector.Y);
			foreach (SectorCoordinate information in CoordinateRangeCalculator.GetPossibleCoordinates(startInfo, x, y)) {
				sectorInformationContainer.Add(information);
			}
			sectorInformationContainer.ExceptionCoordinate = new SectorCoordinate(system, sector);
			return sectorInformationContainer;
		}

		/// <summary>
		/// Gets the private Universe
		/// </summary>
		/// <returns>The private universe</returns>
		public static SectorInformationContainer GetPrivateUniverse() {
			ISystem system = PlayerUtils.Current.PrivateSystem;
			return GetSectorInformationContainer(system.Sectors.Values);
		}

		/// <summary>
		/// Obtains the part of the universe centered in the passed coordinates
		/// </summary>
		/// <param name="coordinate">Coordinate of the system and sector to center the view</param>
		/// <returns>Que surrounding area</returns>
		public static SectorInformationContainer GetUniverseWithSectorInformation(SectorCoordinate coordinate) {
			return GetUniverseWithSectorInformation(coordinate, 9, 15);
		}

		/// <summary>
		/// Obtains the part of the universe centered in the passed coordinates
		/// </summary>
		/// <param name="coordinate">Coordinate of the system and sector to center the view</param>
		/// <param name="x">Number of X squares to retrive (vertical)</param>
		/// <param name="y">Number of Y squares to retrive (horizontal)</param>
		/// <returns>Que surrounding area</returns>
		public static SectorInformationContainer GetUniverseWithSectorInformation(SectorCoordinate coordinate, int x, int y ) {
			SectorCoordinateContainer sectorInformationContainer = GetCoordinateRange(coordinate.System, coordinate.Sector,x, y);
			List<ISector> sectors = UniversePersistance.GetSectors(sectorInformationContainer);
			SectorInformationContainer container = GetSectorInformationContainer(sectors);
			container.StartCoordinate = sectorInformationContainer.StartCoordinate;
			return container;
		}

        /// <summary>
        /// Obtains a SectorInformationContainer with all the arenas,markets and wormholes discovered 
        /// and with all the fleets and planets of the owner in the hot zone
        /// </summary>
        /// <param name="owner">Owner of the special sector</param>
        /// <returns>Container with all the special sectors</returns>
        public static SectorInformationContainer GetUniverseWithSpecialSectorsInformation(IPlayer owner) {
            List<ISector> sectors = UniversePersistance.GetSpecialSectors(owner);
            return GetSectorInformationContainer(sectors,false);
        }

		/// <summary>
		/// get's the sectorInformation given the sectors.
		/// </summary>
		/// <param name="sectors">sectors to convert</param>
		/// <param name="owner">current player</param>
		/// <param name="getFogOfWar">if it'«s to get the fog of war</param>
		/// <returns></returns>
		/// <remarks>Can only be used when the turn is passing</remarks>
		public static SectorInformationContainer GetSectorInformationContainer(IEnumerable<ISector> sectors, IPlayer owner, bool getFogOfWar) {
			SectorInformationContainer sectorInformationContainer = FillSectorInformationContainer(sectors, owner);
			if (getFogOfWar) {
				SetFogOfWar(sectorInformationContainer, owner);
			} else {
				sectorInformationContainer.SetAllVisible();
			}
			sectorInformationContainer.SortAll();
			return sectorInformationContainer;
		}

		/// <summary>
		/// Creates a Sector information with the given sector
		/// </summary>
		/// <param name="sector"></param>
		/// <returns></returns>
		public static SectorInformation CreateSectorInformation(ISector sector) {
			if (PlayerUtils.HasPlayer) {
				return CreateSectorInformation(sector, PlayerUtils.Current);	
			}
			return CreateSectorInformation(sector, null);
		}

		/// <summary>
		/// Creates a Sector information with the given sector
		/// </summary>
		/// <param name="sector">Sector to convert</param>
		/// <param name="player">Current Player</param>
		/// <returns></returns>
		public static SectorInformation CreateSectorInformation(ISector sector,IPlayer player) {
			SectorInformation information;
			string sectorType = sector.GetType().Name;
			if (sectorInformationMapping.ContainsKey(sectorType)) {
				information = sectorInformationMapping[sectorType](sector, player);
			} else {
				information = CreateDefaultSectorInformation(sector, player);
			}
			return information;
		}

		/// <summary>
		/// Converts a list of resources to it' string representation
		/// </summary>
		/// <param name="resources"></param>
		/// <returns></returns>
		public static string ConvertToString(List<IResourceQuantity> resources) {
            using (StringWriter writer = new StringWriter()) {
                writer.Write(resources[0].ToString());
                for (int i = 1; i < resources.Count; ++i) {
                    writer.Write(", {0}", resources[i]);
                }
                return writer.ToString();
            }
		}

		#endregion Public

		#region Constructor

		static UniverseUtils() {
			sectorInformationMapping["FleetSector"] = CreateFleetSectorInformation;
			sectorInformationMapping["PlanetSector"] = CreatePlanetSectorInformation;
			sectorInformationMapping["FleetBattleSector"] = CreateBattleFleetSectorInformation;
			sectorInformationMapping["WormHoleSector"] = CreateWormHoleSectorInformation;
			sectorInformationMapping["PrivateWormHoleSector"] = CreateWormHoleSectorInformation;
			sectorInformationMapping["MarketSector"] = CreateMarketSectorInformation;
			sectorInformationMapping["ArenaSector"] = CreateArenaSectorInformation;
			sectorInformationMapping["PlanetBattleSector"] = CreateBattlePlanetSectorInformation;
			sectorInformationMapping["BugsWormHoleSector"] = CreateBugsWormHoleSectorInformation;
			sectorInformationMapping["BeaconSector"] = CreateBeaconSectorInformation;
			sectorInformationMapping["AcademySector"] = CreateAcademySectorInformation;
			sectorInformationMapping["PirateBaySector"] = CreatePirateBaySectorInformation;
			sectorInformationMapping["RelicSector"] = CreateRelicSectorInformation;
			sectorInformationMapping["RelicBattleSector"] = CreateBattleRelicSectorInformation;
		}

		#endregion Constructor

		

	}
}
