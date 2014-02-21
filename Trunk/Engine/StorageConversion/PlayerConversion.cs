using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using NHibernate.Mapping;
using OrionsBelt.Engine.Universe;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.Engine.Resources;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.Generic;
using System.IO;
using OrionsBelt.Engine.Common;

namespace OrionsBelt.Engine {

    /// <summary>
    /// Converts PlayerStorage to/from IPlayer
    /// </summary>
    public static class PlayerConversion {

        #region Load/Store Methods

        public static IPlayer ConvertToPlayer(PlayerStorage storage)
        {
            return new Player(storage, false);
        }

        public static void SetPlayer(IPlayer player, PlayerStorage playerStorage)
        {
            player.Storage = playerStorage;
            player.Name = playerStorage.Name;
            player.LastProcessedTick = playerStorage.LastProcessedTick;
            player.Limits = ParseLimits(playerStorage.IntrinsicLimits);
            player.IntrinsicQuantities = ParseLimits(playerStorage.IntrinsicQuantities);
            player.QuestContextLevel = ParseQuestContextLevel(playerStorage.QuestContextLevel);
        	player.Score = playerStorage.Score;
            player.PlanetLevel = playerStorage.PlanetLevel;
        	player.HomePlanetId = playerStorage.HomePlanetId;
            player.PirateRanking = playerStorage.PirateRanking;
            player.Active = playerStorage.Active;
            player.IsPrimary = playerStorage.IsPrimary;
            player.ActivatedInTick = playerStorage.ActivatedInTick;
            player.BountyRanking = playerStorage.BountyRanking;
            player.MerchantRanking = playerStorage.MerchantRanking;
            player.GladiatorRanking = playerStorage.GladiatorRanking;
            player.ColonizerRanking = playerStorage.ColonizerRanking;
			player.UltimateWeaponLevel = playerStorage.UltimateWeaponLevel;
            player.Services = ParseServices(playerStorage.Services);
            player.UltimateWeaponCooldown = playerStorage.UltimateWeaponCooldown;
			player.Avatar = playerStorage.Avatar;
            player.IsGeneralActive = playerStorage.IsGeneralActive;
            player.GeneralId = playerStorage.GeneralId;
            player.GeneralName = playerStorage.GeneralName;
            player.GeneralFriendlyName = playerStorage.GeneralFriendlyName;
            player.ForumRole = playerStorage.ForumRole;
            player.TotalPosts = playerStorage.TotalPosts;
            player.ForumSignature = playerStorage.Signature;

            SetPlayerRace(player, playerStorage);

            player.IsDirty = false;
        }

        private static List<ServiceType> ParseServices(string raw)
        {
            if (string.IsNullOrEmpty(raw)) {
                return null;
            }
            string[] parts = raw.Split(';');
            List<ServiceType> list = new List<ServiceType>();
            foreach (string part in parts) {
                if (string.IsNullOrEmpty(part)) {
                    continue;
                }
                ServiceType type = (ServiceType)Enum.Parse(typeof(ServiceType), part);
                list.Add(type);
            }
            return list;
        }

        private static Dictionary<QuestContext, int> ParseQuestContextLevel(string raw)
        {
            Dictionary<QuestContext, int> dic = new Dictionary<QuestContext, int>();

            if (string.IsNullOrEmpty(raw)){
                return dic;
            }

            string[] resources = raw.Split(PlanetConversion.ResourceSeparator, StringSplitOptions.RemoveEmptyEntries);
            foreach (string rawMod in resources) {
                string[] parts = rawMod.Split(PlanetConversion.ModSeparator, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length != 2) {
                    throw new EngineException("Expected two parts on string `{0}'", rawMod);
                }
                QuestContext context = (QuestContext)Enum.Parse(typeof(QuestContext), parts[0]);
                int value = int.Parse(parts[1]);
                dic[context] = value;
            }

            return dic;
        }

        private static void SetPlayerRace(IPlayer player, PlayerStorage playerStorage)
        {
            if (string.IsNullOrEmpty(playerStorage.Race)) {
                player.RaceInfo = null;
            } else {
                player.RaceInfo = RaceInfo.Get(playerStorage.Race);
            }
        }

        public static void SetPlayerAlliance(IPlayer player, PlayerStorage playerStorage)
        {
            if (playerStorage.Alliance != null) {
                player.Alliance = AllianceManager.PrepareAlliance(playerStorage.Alliance);
                player.AllianceRank = (AllianceRank)Enum.Parse(typeof(AllianceRank), playerStorage.AllianceRank);
            } else {
                player.Alliance = null;
                player.AllianceRank = OrionsBelt.RulesCore.Enum.AllianceRank.None;
            }
        }

		private static void SetPlayerResources(IPlayer player, PlayerStorage storage)
        {
            ResourceUtils.ClearResources(player);
            List<IPlanetResource> list = new List<IPlanetResource>();
            foreach (PlanetResourceStorage rs in storage.Resources) {
                IResourceInfo info = RulesUtils.GetResource(rs.Type);
                IPlanetResource resource = PlanetResource.Create(info, 0);
                resource.Owner = player;
                list.Add(resource);
                PlanetResourceConversion.SetResource(resource, rs);
            }

            foreach (IPlanetResource resource in list) {
                player.AddResource(resource);
            }
        
        }

        public static void SetPlayerPlanets(IPlayer player, PlayerStorage playerStorage, IList<IPlanet> planets)
        {
            IList<PlanetStorage> list = null;
            planets.Clear();
            if (Server.IsInTests) {                 
                list = playerStorage.Planets;
            } else {
                list = Hql.Query<PlanetStorage>("select p from SpecializedPlanetStorage p left join fetch p.ResourcesNHibernate where p.PlayerNHibernate.Id = :id", Hql.Param("id", playerStorage.Id));
                list = Hql.Unify<PlanetStorage>(list);
            }
            
            foreach (PlanetStorage storage in list) {
				IPlanet planet = PlanetConversion.ConvertToPlanet(storage, player);
                planets.Add(planet);
                planet.IsDirty = false;
            }

            ((List<IPlanet>)planets).Sort(delegate(IPlanet p1, IPlanet p2) {
                if (p1.Info.HotZone == p2.Info.HotZone) {
                    return p1.Name.CompareTo(p2.Name);
                }
                if (p1.Info.HotZone) {
                    return 1;
                }
                return -1;
            });

        }

        public static void SetPlayerPlanets(IPlayer player, PlayerStorage playerStorage)
        {
            SetPlayerPlanets(player, playerStorage, player.Planets);
        }

        internal static void SetStorage(PlayerStorage storage, IPlayer player)
        {
            player.Storage = storage;

            storage.LastProcessedTick = player.LastProcessedTick;
            storage.Name = player.Name;
            storage.IntrinsicLimits = LimitsRepresentation(player.Limits);
            storage.IntrinsicQuantities = LimitsRepresentation(player.IntrinsicQuantities);
            storage.QuestContextLevel = QuestContextRepresentation(player.QuestContextLevel);
        	storage.Score = player.Score;
			storage.HomePlanetId = player.HomePlanetId;
            storage.PlanetLevel = player.PlanetLevel;
            storage.PirateRanking = player.PirateRanking;
            storage.Active = player.Active;
            storage.IsPrimary = player.IsPrimary;
            storage.ActivatedInTick = player.ActivatedInTick;
            storage.BountyRanking = player.BountyRanking;
            storage.MerchantRanking = player.MerchantRanking;
            storage.GladiatorRanking = player.GladiatorRanking;
            storage.Services = ServicesReprensentation(player.Services);
            storage.ColonizerRanking = player.ColonizerRanking;
			storage.UltimateWeaponLevel = player.UltimateWeaponLevel;
            storage.UltimateWeaponCooldown = player.UltimateWeaponCooldown;
			storage.Avatar = player.Avatar;
            storage.IsGeneralActive = player.IsGeneralActive;
            storage.GeneralId = player.GeneralId;
            storage.GeneralName = player.GeneralName;
            storage.GeneralFriendlyName = player.GeneralFriendlyName;
            storage.ForumRole = player.ForumRole;
            storage.TotalPosts = player.TotalPosts;
            storage.Signature = player.ForumSignature;
                

            SetStorageRace(storage, player);
			
			if (player.AllianceLoaded) {
				storage.AllianceRank = player.AllianceRank.ToString();
				if (player.HasAlliance) {
					player.Alliance.PrepareStorage();
					storage.Alliance = player.Alliance.Storage;
				}
				else {
					storage.Alliance = null;
					storage.AllianceRank = player.AllianceRank.ToString();
				}
			}

        	if (player.Principal != null) {
				storage.Principal = player.Principal;				
			}
        }

        private static string ServicesReprensentation(List<ServiceType> list)
        {
            if (list == null || list.Count == 0) {
                return null;
            }
            using (TextWriter writer = new StringWriter()) {
                foreach (ServiceType type in list) {
                    writer.Write("{0};", type);
                }
                return writer.ToString();
            }
        }

        private static string QuestContextRepresentation(Dictionary<QuestContext, int> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0) {
                return null;
            }

            using (TextWriter writer = new StringWriter()) {
                foreach (KeyValuePair<QuestContext, int> pair in dictionary) {
                    writer.Write("{0}:{1};", pair.Key, pair.Value);
                }

                return writer.ToString();
            }
        }

        private static void SetStorageRace(PlayerStorage storage, IPlayer player)
        {
            if (player.RaceInfo != null) {
                storage.Race = player.RaceInfo.Race.ToString();
            } else {
                storage.Race = null;
            }
        }

        private static string LimitsRepresentation(Dictionary<IResourceInfo, int> dictionary)
        {
            return PlanetConversion.ModifiersRepresentation(dictionary);
        }

        public static void SetStoragePlanets(PlayerStorage playerStorage, IPlayer player)
        {
            playerStorage.Planets.Clear();
            foreach (IPlanet planet in player.Planets) {
                PlanetStorage storage = PlanetConversion.ConvertToStorage(planet);
                storage.Player = playerStorage;
                playerStorage.Planets.Add(storage);
            }
        }

        public static PlayerStorage ConvertToStorage(IPlayer player)
        {
            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance()) {
                PlayerStorage storage = persistance.Create();
                SetStorage(storage, player);
                return storage;
            }
        }

        public static Dictionary<IResourceInfo, int> ParseLimits(string limits)
        {
            return PlanetConversion.ParseModifiers(limits);
        }

		public static List<IFleetInfo> LoadPlayerFleets(IPlayer player) {
			return FleetPersistance.LoadPlayerMoveableFleets(player);
		}

		public static List<IFleetInfo> LoadAllPlayerFleets(Player player) {
			return FleetPersistance.LoadPlayerFleets(player);
		}

		public static List<IFleetInfo> LoadAllPlayerPlanetFleets(Player player) {
			return FleetPersistance.LoadPlayerPlanetsFleets(player);
		}

        public static void SetPlayerRelics(Player player, PlayerStorage playerStorage, List<SectorCoordinate> relics){
            if (relics.Count > 0 ){
                relics.Clear();
            }
            IList<SectorStorage> list = Hql.Query<SectorStorage>("select p from SpecializedSectorStorage p where p.OwnerNHibernate.Id = :id and ( p.Type = 'RelicSector' || p.Type = 'RelicBattleSector')", Hql.Param("id", playerStorage.Id));
            foreach (SectorStorage storage in list){
                SectorCoordinate coord = new SectorCoordinate(storage.SystemX, storage.SystemY, storage.SectorX, storage.SectorY);
                relics.Add(coord);
            }
        }

        #endregion Load/Store Methods

        #region Quests

        internal static IList<IQuestData> LoadQuests(IPlayer player)
        {
            List<IQuestData> list = new List<IQuestData>();

            IList<QuestStorage> storages = null;
            if (Server.IsInTests){
                storages = player.Storage.Quests;
            } else {
                storages = Hql.Query<QuestStorage>("select quest from SpecializedQuestStorage quest where quest.PlayerNHibernate.Id = :id and quest.Completed = 0", Hql.Param("id", player.Id));
            }

            foreach (QuestStorage storage in storages) {
                IQuestData data = QuestConversion.ConvertStorageToQuest(storage);
                data.Player = player;
                list.Add(data);
            }
            return list;
        }

        #endregion Quests

    };

}
