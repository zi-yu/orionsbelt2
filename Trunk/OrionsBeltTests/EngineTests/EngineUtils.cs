using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using NUnit.Framework;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Engine;
using System.Reflection;
using OrionsBelt.RulesCore.Races;
using System.IO;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.UniverseInfo;
using OrionsBelt.Engine.Quests;
using OrionsBelt.Engine.Alliances;

namespace OrionsBeltTests.EngineTests {
    
    internal class EngineUtils  {

        #region Player Utils

        public static Principal NewPrincipal {
            get {
                return Persistance.Create<Principal>();
            }
        }

        public static Player RichPlayer {
            get {
                Player player = new Player();
                player.RaceInfo = RaceInfo.Get(Race.LightHumans);
                player.LastProcessedTick = Clock.Instance.Tick;
                player.AddToLimit(null, 50000);
                Clock.Instance.Advance();
                PlayerUtils.Current = player;
                
                ResourceUtils.InitializeIntrinsic(player, 1000);

                PlayerConversion.ConvertToStorage(player);
                PlayerUtils.Update(player);
                return player;
            }
        }

		private static Player CreatePlayer( Race race ) {
			Player player = new Player();
			player.RaceInfo = RaceInfo.Get(race);
			player.AddToLimit(null, 50000);
			player.LastProcessedTick = Clock.Instance.Tick;
			player.Principal = NewPrincipal;
			Clock.Instance.Advance();
			PlayerUtils.Current = player;
			PlayerUtils.Update(player);
			return player;
		}

        public static Player EmptyPlayer {
            get {
            	return CreatePlayer(Race.LightHumans);
            }
        }

		public static Player EmptyBugPlayer {
			get {
				return CreatePlayer(Race.Bugs);
			}
		}

		public static Player EmptyDarkPlayer {
			get {
				return CreatePlayer(Race.DarkHumans);
			}
		}

        public static Planet EmptyPlayerPlanet {
            get {
                Player player = EmptyPlayer;
                PlayerUtils.Current = player;
                Planet planet = new Planet(player, "Zen");
                PlayerUtils.Update(player);
                return planet;
            }
        }

        public static Planet RichPlayerPlanet {
            get {
                Player player = RichPlayer;
                PlayerUtils.Current = player;
                Planet planet = new Planet(player, "Zen");
                planet.AddToModifier(Gold.Resource, 100);
                PlayerUtils.Update(player);
				planet.Location = new SectorCoordinate(0,0,1,1);
				FleetInfo info = new FleetInfo("Defense", true, planet.Location);
            	info.Owner = player;
            	info.CurrentPlanet = planet;
				planet.AddFleet(info);
                return planet;
            }
        }

        #endregion Player Utils

        #region Resource Creation

        public static IPlanetResource GetResource(Type type)
        {
            Planet planet = new Planet();
            PlanetResource resource = new PlanetResource(planet, type);

            return resource;
        }

        internal static IPlanetResource GetResource(IResourceOwner iPlanet, Type type, int level)
        {
            PlanetResource resource = new PlanetResource(type);

            resource.Owner = iPlanet;
            resource.Level = level;
            resource.AttachToOwner();

            return resource;
        }

        internal static PlanetResourceStorage GetPlanetResourceStorage()
        {
            using (IPlanetResourceStoragePersistance persistance = Persistance.Instance.GetPlanetResourceStoragePersistance())
            {
                return persistance.Create();
            }
        }

        internal static void AssertResultTrue(OrionsBelt.Generic.Result result)
        {
            Assert.IsTrue(result.Ok, "Result should succeed - {0}", result.Log());
        }

        internal static void AssertResultFalse(OrionsBelt.Generic.Result result)
        {
            Assert.IsTrue(!result.Ok, "Result should fail - {0}", result.Log());
        }

        private static Random random = new Random();

        public static Random Rand {
            get { return random; }
        }
	

        #endregion Resource Creation

        #region Generic Resource Utils

        public static IPlanetResource GetRandomPlanetResource(IResourceInfo info)
        {
            PlanetResource resource = new PlanetResource(info);

            resource.Level = Rand.Next(0, 10);
            resource.Quantity = Rand.Next(0, 1000);
            resource.State = GetRandomResourceState();

            return resource;
        }

        public static ResourceState GetRandomResourceState()
        {
            int n = Rand.Next(0, 5);
            switch (n)
            {
                case 0: return ResourceState.Available;
                case 4: return ResourceState.Running;
                default: return ResourceState.Available;
            }
        }

        internal static int GetTotalResourcesCount(IResourceOwner owner)
        {
            int sum = 0;
            foreach (ResourceList list in owner.Resources.Values) {
                sum += list.Count;
            }
            return sum;
        }

        #endregion Generic Resource Utils

        #region Actions

        public static TimedActionStorage GetTimedActionStorage(string actionName, Visibility visibility, int endTick)
        {
            using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance())
            {
                TimedActionStorage storage = persistance.Create();
                storage.Name = actionName;
                storage.EndTick = endTick;
                persistance.Update(storage);
                return storage;
            }
        }

        #endregion Actions

        #region Quests

        public static IQuestData DummyQuest {
            get { return new QuestData(); }
        }

        public static void RandomFillQuest(IQuestData quest)
        {
            RandomFill(quest);

            quest.Info = QuestManager.GetQuestType("BattleCount");

            foreach (IResourceInfo resource in RulesUtils.GetResources(ResourceType.Intrinsic)) {
                quest.Reward.Add(resource, Rand.Next());
                quest.QuestIntConfig.Add(resource.Name, Rand.Next());
                quest.QuestIntProgress.Add(resource.Name, Rand.Next());
                quest.QuestStringConfig.Add(resource.Name, Rand.Next().ToString());
                quest.QuestStringProgress.Add(resource.Name, Rand.Next().ToString());
            }
        }

        public static void RandomFillQuest(QuestStorage storage)
        {
            RandomFill(storage);

            storage.Type = "BattleCount";

            storage.DeadlineTick = Clock.Instance.Tick + 100;
            storage.StartTick = Clock.Instance.Tick;
            storage.IsTemplate = false;
            storage.Name = "Random Quest";
            storage.Percentage = Rand.NextDouble() * 100;
            storage.Player = PlayerUtils.Current.Storage;

            storage.Reward = GetResourceIntCollection();
            storage.QuestIntProgress = GetResourceIntCollection();
            storage.QuestIntConfig = GetResourceIntCollection();
            storage.QuestStringConfig = GetResourceStringCollection();
            storage.QuestStringProgress = GetResourceStringCollection();
        }

        #endregion Quests

        #region Generic

        public static void RandomFillPlanet(PlanetStorage storage)
        {
            RandomFill(storage);

            storage.Modifiers = GetResourceIntCollection();
            storage.Richness = GetResourceIntCollection();
            storage.Info = PlanetInfo.GetRandomHotZone().Identifier;
            storage.Terrain = TerrainInfo.GetRandom().Terrain.ToString();
        }

        private static string GetResourceIntCollection()
        {
            using (TextWriter writer = new StringWriter()) {

                foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                    writer.Write("{0}:{1};", info.Name, Rand.Next());
                }

                return writer.ToString();
            }
        }

        private static string GetResourceStringCollection()
        {
            using (TextWriter writer = new StringWriter()) {

                foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                    writer.Write("{0}:{1};", info.Name, Rand.Next().ToString());
                }

                return writer.ToString();
            }
        }

        public static void RandomFillPlanet(IPlanet planet)
        {
            RandomFill(planet);

            planet.Info = PlanetInfo.GetRandomHotZone();
            planet.Terrain = TerrainInfo.GetRandom();

            foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                planet.AddToModifier(info, Rand.Next());
            }

            foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                planet.SetRichness(info, Rand.Next());
            }
        }

        public static void RandomFillPlayer(IPlayer player)
        {
            RandomFill(player);
            foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                player.SetLimit(info, 10000);
            }
        }

        public static void RandomFillPlayer(PlayerStorage storage)
        {
            RandomFill(storage);
            storage.AllianceRank = "None";
            storage.Race = Race.LightHumans.ToString();
            using (TextWriter writer = new StringWriter()) {
                foreach (IIntrinsicInfo info in RulesUtils.GetIntrinsicResources()) {
                    writer.Write("{0}:{1};", info.Name, Rand.Next());
                }

                storage.IntrinsicLimits = writer.ToString();
                storage.IntrinsicQuantities = writer.ToString();
            }
        }

        public static void RandomFill(object obj)
        {
            Type type = obj.GetType();
            foreach (PropertyInfo info in type.GetProperties( BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.SetProperty  )) {
                if (EngineUtils.TargetProperty(info)){
                    object val = GetDummyValue(info.PropertyType);
                    info.SetValue(obj, val, null);
                }
            }
        }

        private static IEnumerable<PropertyInfo> GetIntrinsicProperties(object back, object face)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public static bool TargetProperty(PropertyInfo info)
        {
            if (!info.CanWrite) {
                return false;
            }

            if (info.Name == "Name" && info.DeclaringType.Name.Contains("Action"))  {
                return false;
            }

            if (info.Name == "QuestContextLevel" && info.DeclaringType.Name.Contains("Player"))  {
                return false;
            }

            if (info.Name == "Type" && info.DeclaringType.Name.Contains("PlanetResource"))  {
                return false;
            }

            if (info.Name == "ProductionFactor" && info.DeclaringType.Name.Contains("Player"))  {
                return false;
            }

            if (info.Name == "IsTemplate" && info.DeclaringType.Name.Contains("PlanetResource")) {
                return false;
            }

            return TargetType(info.PropertyType);
        }

        public static bool TargetType(Type type)
        {
            return type.IsPrimitive || type == typeof(string) || type.IsEnum;
        }

        internal static object GetDummyValue(Type type)
        {
            if (type == typeof(int)) {
                return Rand.Next();
            }

            if (type == typeof(double)) {
                return (double)Rand.Next();
            }

            if (type == typeof(string)) {
                return Rand.Next().ToString();
            }

            if (type == typeof(bool)) {
                return Rand.Next() % 2 == 0;
            }

            if (type == typeof(ResourceState)) {
                return ResourceState.UnAvailable;
            }

            if (type == typeof(AllianceRank)) {
                return AllianceRank.Admiral;
            }

            if (type == typeof(RaceInfo)) {
                return RaceInfo.Get(Race.LightHumans);
            }

            throw new Exception(string.Format("Can't get random value for {0}", type.Name));
        }

        #endregion Generic

        #region Alliances

        public static IAlliance DummyAlliance {
            get {
                Alliance alliance = new Alliance();

                alliance.PrepareStorage();

                alliance.Storage.Name = "Dummy Alliance";
                alliance.Storage.OpenToNewMembers = true;

                using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance()) {
                    persistance.Update(alliance.Storage);
                }

                return alliance;
            }
        }

        #endregion Alliances

        #region Battles

        public static IBattleInfo GetDummyBattle()
        {
            IFleetInfo fleet = new FleetInfo("Waza");
            fleet.Add("Rain", 3);
            int id = BattleManager.CreateBattle(new IPlayer[] { EmptyPlayer, EmptyPlayer }, new IFleetInfo[] { fleet, fleet }, Terrain.Desert);
            return BattlePersistance.GetBattle(id);
        }

        #endregion Battles

    };

}
