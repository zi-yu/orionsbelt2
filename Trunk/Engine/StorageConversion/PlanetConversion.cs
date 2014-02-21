using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using System.IO;
using OrionsBelt.RulesCore.UniverseInfo;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Converts PlanetStorage to/from IPlanet
    /// </summary>
    public static class PlanetConversion {

        #region Load/Store Methods

        public static IPlanet ConvertToPlanet(PlanetStorage storage)
        {
            Planet resource = new Planet();
            SetResource(resource, storage);
            return resource;
        }

		public static IPlanet ConvertToPlanet(PlanetStorage storage, IPlayer player){
            Planet resource = new Planet();
			resource.Owner = player;
            SetResource(resource, storage);
            return resource;
        }

		public static IPlanet ConvertToPlanet(PlanetStorage storage, ISector sector) {
			Planet planet = new Planet();
			SetResource(planet, storage, sector);
			return planet;
		}

        public static PlanetStorage ConvertToStorage(IPlanet resource)
        {
        	return ConvertToStorage(resource, true);
        }

		public static PlanetStorage ConvertToStorage(IPlanet resource, bool prepareSector) {
			using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance()) {
				PlanetStorage storage = persistance.Create();
				SetStorage(storage, resource);
				return storage;
			}
		}

		public static void SetStorage(PlanetStorage storage, IPlanet planet) {
			SetStorage(storage, planet, true);
		}

        public static void SetStorage(PlanetStorage storage, IPlanet planet, bool prepareSector )
        {
            planet.Storage = storage;

            storage.Name = planet.Name;
            storage.ProductionFactor = planet.ProductionFactor;
            storage.Score = planet.Score;
            storage.Level = planet.Level;
            storage.FacilityLevel = planet.FacilityLevel;
            storage.LastConquerTick = planet.LastConquerTick;
            storage.LastPillageTick = planet.LastPillageTick;
            storage.Modifiers = ModifiersRepresentation(planet.Modifiers);
            storage.Richness = RichnessRepresentation(planet.Richness);
			storage.IsPrivate = planet.IsPrivate;
			if (planet.HasLocation() ) {
        		storage.SystemX = planet.Location.System.X;
				storage.SystemY = planet.Location.System.Y;
				storage.SectorX = planet.Location.Sector.X;
				storage.SectorY = planet.Location.Sector.Y;
			}
            if (planet.HasOwner) {
                planet.Owner.PrepareStorage();
                storage.Player = planet.Owner.Storage;
            } else {
                storage.Player = null;
            }
			
            if (planet.Terrain == null){
                storage.Terrain = null;
            } else {
                storage.Terrain = planet.Terrain.Terrain.ToString();
            }

            if (planet.Info == null) {
                storage.Info = null;
            } else {
                storage.Info = planet.Info.Identifier;
            }

            SetStorageResources(storage, planet);
			SetFleet(storage, planet);

			if (planet.HasLoadedSector && planet.Sector != null) {
				if (prepareSector && planet.Sector.IsDirty) {
					planet.Sector.PrepareStorage();
					planet.Sector.UpdateStorage();
					Persistance.ResolveTransient(planet.Sector.Storage);
				}
				storage.Sector = planet.Sector.Storage;
			}
        }

		private static void SetFleet(PlanetStorage storage, IPlanet planet) {
			if (storage.Fleets.Count == 0 && planet.HasLocation() ) {
				foreach (IFleetInfo fleet in planet.Fleets) {
					fleet.PrepareStorage();
					fleet.UpdateStorage();
					storage.Fleets.Add(fleet.Storage);	
					fleet.Touch();
				}
			}
		}

        private static string RichnessRepresentation(Dictionary<IResourceInfo, int> dictionary)
        {
            return ModifiersRepresentation(dictionary);
        }

        private static void SetStorageResources(PlanetStorage planetStorage, IPlanet planet)
        {
            planetStorage.Resources.Clear();
            foreach (IPlanetResource resource in ResourceUtils.GetResources(planet)) {
                if (resource.IsTemplate) {
                    continue;
                }
                resource.UpdateStorage();
                PlanetResourceStorage storage = resource.Storage;
                storage.Planet = planetStorage;
                planetStorage.Resources.Add(storage);
            }
        }

        internal static void SetResource(Planet planet, PlanetStorage storage)
        {
            SetBasePlanetProps(planet, storage);
            SetPlanetResources(planet, storage);

			if( planet.Owner == null ) {
        		planet.Owner = PlayerUtils.LoadPlayer(storage.Player);
			}
        }

        private static void SetBasePlanetProps(Planet planet, PlanetStorage storage)
        {
            planet.Storage = storage;

            planet.Name = storage.Name;
            planet.ProductionFactor = storage.ProductionFactor;
            planet.Modifiers = ParseModifiers(storage.Modifiers);
            planet.Richness = ParseRichness(storage.Richness);
            planet.Info = GetInfo(storage.Info);
            planet.Score = storage.Score;
            planet.FacilityLevel = storage.FacilityLevel;
            planet.LastPillageTick = storage.LastPillageTick;
            planet.LastConquerTick = storage.LastConquerTick;
            planet.Level = storage.Level;
            planet.Terrain = GetTerrain(storage.Terrain);
            planet.IsPrivate = storage.IsPrivate;
            planet.Location = new SectorCoordinate(storage.SystemX, storage.SystemY, storage.SectorX, storage.SectorY);

            planet.IsDirty = false;
        }

		internal static void SetResource(Planet planet, PlanetStorage storage, ISector sector) {
            SetBasePlanetProps(planet, storage);
			planet.Owner = sector.Owner;
		    planet.Sector = sector;
		}

		private static ITerrainInfo GetTerrain(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) {
                return null;
            }
            return TerrainInfo.Get(identifier);
        }

        private static IPlanetInfo GetInfo(string identifier)
        {
            if (string.IsNullOrEmpty(identifier)) {
                return null;
            }
            return PlanetInfo.Get(identifier);
        }

        internal static void SetPlanetResources(IPlanet planet, PlanetStorage storage)
        {
            ResourceUtils.ClearResources(planet);
            List<IPlanetResource> list = new List<IPlanetResource>();
            foreach (PlanetResourceStorage rs in storage.Resources) {
                IResourceInfo info = RulesUtils.GetResource(rs.Type);
                IPlanetResource resource = PlanetResource.Create(info, 0);
                resource.Owner = planet;
                list.Add(resource);
                PlanetResourceConversion.SetResource(resource, rs);
            }

            foreach (IPlanetResource resource in list) {
                planet.AddResource(resource);
                resource.IsDirty = false;
            }

            planet.IsDirty = false;
        }

        public static char[] ResourceSeparator = {';'};
        public static char[] ModSeparator = { ':' };

        public static Dictionary<IResourceInfo, int> ParseModifiers(string raw)
        {
            Dictionary<IResourceInfo, int> mods = new Dictionary<IResourceInfo, int>();

            if (string.IsNullOrEmpty(raw)){
                return mods;
            }

            string[] resources = raw.Split(ResourceSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawMod in resources) {
                string[] parts = rawMod.Split(ModSeparator, StringSplitOptions.RemoveEmptyEntries);
                IResourceInfo info = RulesUtils.GetResource(parts[0]);
                int value = int.Parse(parts[1]);
                mods[info] = value;
            }

            return mods;
        }

        public static string ModifiersRepresentation(Dictionary<IResourceInfo, int> mods)
        {
            using (TextWriter writer = new StringWriter()) {

                foreach (KeyValuePair<IResourceInfo, int> pair in mods) {
                    writer.Write("{0}:{1};", pair.Key.Name, pair.Value);
                }

                return writer.ToString();
            }
        }

        public static Dictionary<IResourceInfo, int> ParseRichness(string raw)
        {
            return ParseModifiers(raw);
        }

		#endregion Load/Store Methods

    };

}
