using System;
using NUnit.Framework;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using System.Threading;
using OrionsBelt.Engine.Actions;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.Core;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using DesignPatterns;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Races;
using System.Reflection;
using Loki.DataRepresentation;
using OrionsBelt.Engine.Quests;
using System.Collections;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ConversionTests: BaseTests  {

        #region Action Load/Store Tests

        [Test]
        public void ConvertActionToStorage_Test()
        {
            foreach (ITimedAction action in GetAllActions()) {
                ConvertActionToStorage(action);
            }
        }

        private static IEnumerable<ITimedAction> GetAllActions()
        {
            foreach (IFactory factory in ActionUtils.GetActionFactories()) {
                yield return (ITimedAction)factory.create(null);
            }
        }

        private void ConvertActionToStorage(ITimedAction action)
        {
            EngineUtils.RandomFill(action);

            TimedActionStorage storage = ActionConversion.ConvertActionToStorage(action);

            ConversionTest<TimedActionStorage>(action, storage, typeof(ITimedAction), typeof(IAction));
        }

        [Test]
        public void ConvertStorageToAction_Test()
        {
            foreach (ITimedAction action in GetAllActions()) {
                TimedActionStorage storage = EngineUtils.GetTimedActionStorage(action.Name, Visibility.Public, 4);
                ConvertStorageToAction(storage);
            }
        }

        private void ConvertStorageToAction(TimedActionStorage storage)
        {
            EngineUtils.RandomFill(storage);
            ITimedAction action = ActionConversion.ConvertStorageToAction(storage);

            ConversionTest<TimedActionStorage>(action, storage, typeof(ITimedAction), typeof(IAction));
        }

        [Test]
        public void TimedAction_Touch()
        {
            foreach(ITimedAction action in GetAllActions() ) {
                TouchTest<TimedActionStorage>(action, typeof(ITimedAction));
            }
        }

        #endregion Action Load/Store Tests

        #region PlanetResource Tests

        [Test]
        public void ConvertStorateToResource_Test()
        {
            PlanetResourceStorage storage = EngineUtils.GetPlanetResourceStorage();
            storage.Type = "Crusader";
            EngineUtils.RandomFill(storage);

            IPlanetResource resource = PlanetResourceConversion.ConvertToResource(storage);

            AssertPlanetResource(storage, resource);

        }

        private void AssertPlanetResource(PlanetResourceStorage storage, IPlanetResource resource)
        {
            ConversionTest<PlanetResourceStorage>(resource, storage, typeof(IPlanetResource));
        }

        [Test]
        public void ConvertResourceToStorage_Test()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            PlanetResource resource = PlanetResource.Create(planet, Crusader.Resource, 23);
            EngineUtils.RandomFill(resource);
            PlanetResourceStorage storage = PlanetResourceConversion.ConvertToStorage(resource);

            ConversionTest<PlanetResourceStorage>(resource, storage, typeof(IPlanetResource));

            Assert.IsNotNull(resource.Storage, "Storage is null");
        }

        [Test]
        public void PlanetResource_Touch()
        {
            TouchTest<PlanetResourceStorage>(PlanetResource.Create(Crusader.Resource, 12), typeof(IPlanetResource));
        }

        #endregion PlanetResource Tests

        #region Planet Tests

        [Test]
        public void RandomFill_Planet()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            EngineUtils.RandomFillPlanet(planet);

            Assert.Greater(planet.Modifiers.Count, 0);

            int sum = 0;

            foreach (int i in planet.Modifiers.Values){
                sum += i;
            }

            Assert.AreNotEqual(0, sum);
        }

        [Test]
        public void ConverPlanetToStorage_Test()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            EngineUtils.RandomFillPlanet(planet);
            PlanetStorage storage = PlanetConversion.ConvertToStorage(planet);

            ComparePlanets(planet, storage);

            Assert.AreEqual(0, storage.Resources.Count);
        }

        private void ComparePlanets(IPlanet planet, PlanetStorage storage)
        {
            ConversionTest<PlanetStorage>(planet, storage, typeof(IPlanet), typeof(IResourceOwner));
            ModifiersComparison(planet, storage);
            RichnessComparison(planet, storage);

            if( planet.Terrain == null ) {
                Assert.IsNull(storage.Terrain);
            } else {
                Assert.AreEqual(planet.Terrain.Terrain.ToString(), storage.Terrain);
            }

            if (planet.Info == null){
                Assert.IsNull(storage.Info);
            } else {
                Assert.AreEqual(planet.Info.Identifier, storage.Info);
            }

        }

        private void RichnessComparison(IPlanet planet, PlanetStorage storage)
        {
            Dictionary<IResourceInfo, int> fromStorage = PlanetConversion.ParseRichness(storage.Richness);

            Assert.AreEqual(planet.Richness.Count, fromStorage.Count);
            foreach (KeyValuePair<IResourceInfo, int> pair in fromStorage){
                Assert.AreEqual(pair.Value, planet.GetRichness(pair.Key), "Failed for {0}", pair.Key);
            }
        }

        private void ModifiersComparison(IPlanet planet, PlanetStorage storage)
        {
            Dictionary<IResourceInfo, int> fromStorage = PlanetConversion.ParseModifiers(storage.Modifiers);

            Assert.AreNotEqual(0, fromStorage.Count, "No resources on storage. Planet has: {0}", planet.Modifiers.Count);
            Assert.AreEqual(planet.Modifiers.Count, fromStorage.Count);
            foreach (KeyValuePair<IResourceInfo, int> pair in fromStorage){
                Assert.AreEqual(pair.Value, planet.GetModifier(pair.Key), "Failed for {0}", pair.Key);
            }
        }

        [Test]
        public void TestParseModifiers_Empty()
        {
            Assert.AreEqual(0, PlanetConversion.ParseModifiers(string.Empty).Count);
        }

        [Test]
        public void TestParseModifiers()
        {
            string raw = "Gold:-1;Uranium:100;";
            Dictionary<IResourceInfo, int> fromStorage = PlanetConversion.ParseModifiers(raw);

            Assert.AreEqual(-1, fromStorage[Gold.Resource]);
            Assert.AreEqual(100, fromStorage[Uranium.Resource]);
        }

        [Test]
        public void ConverStorageToPlanet_Test()
        {
            PlanetStorage storage = PlanetConversion.ConvertToStorage(EngineUtils.RichPlayerPlanet);
            EngineUtils.RandomFillPlanet(storage);
            IPlanet planet = PlanetConversion.ConvertToPlanet(storage);

            ComparePlanets(planet, storage);

            Assert.AreEqual(storage.Resources.Count, EngineUtils.GetTotalResourcesCount(planet), "Resource Count");
        }

        [Test]
        public void Planet_Touch()
        {
            TouchTest<PlanetStorage>(EngineUtils.RichPlayerPlanet, typeof(IPlanet));
        }

        #endregion Planet Tests

        #region Persistance/Conversion Tests

        [Test]
        public void ConverQuestToStorage_Test()
        {
            IQuestData quest = EngineUtils.DummyQuest;
            EngineUtils.RandomFillQuest(quest);
            QuestStorage storage = QuestConversion.ConvertQuestToStorage(quest);

            CompareQuests(storage, quest);
        }

        [Test]
        public void ConverStorageToQuest_Test()
        {
            PlayerUtils.Current = EngineUtils.RichPlayer;

            QuestStorage storage = QuestConversion.ConvertQuestToStorage(EngineUtils.DummyQuest);
            EngineUtils.RandomFillQuest(storage);
            IQuestData data = QuestConversion.ConvertStorageToQuest(storage);

            CompareQuests(storage, data);

        }

        private void CompareQuests(QuestStorage storage, IQuestData data)
        {
            Assert.IsNotNull(data.Info, "quest data has no quest type");

            ConversionTest<QuestStorage>(data, storage, typeof(IQuestData));

            CompareDics(data.Reward, QuestConversion.ConvertRewardToDic(storage.Reward));
            CompareDics(data.QuestIntConfig, QuestConversion.ConvertIntDicToDic(storage.QuestIntConfig));
            CompareDics(data.QuestIntProgress, QuestConversion.ConvertIntDicToDic(storage.QuestIntProgress));
            CompareDics(data.QuestStringProgress, QuestConversion.ConvertStringDicToDic(storage.QuestStringProgress));
            CompareDics(data.QuestStringConfig, QuestConversion.ConvertStringDicToDic(storage.QuestStringConfig));

            Assert.AreEqual(data.Info.Name, storage.Type, "Quest type difer");
        }

        private void CompareDics(IDictionary d1, IDictionary d2)
        {
            Assert.AreEqual(d1.Count, d2.Count, "Count difeer");

            foreach (object obj in d1.Keys) {
                object val1 = d1[obj];
                object val2 = d2[obj];

                Assert.AreEqual(val1, val2, "Dic value for key {0} difeer", obj);
            }
        }

        [Test]
        public void Quest_Touch()
        {
            TouchTest<QuestStorage>(EngineUtils.DummyQuest, typeof(IQuestData));
        }

        #endregion Persistance/Conversion

        #region Player Tests

        [Test]
        public void TestParseLimits_Empty()
        {
            Assert.AreEqual(0, PlayerConversion.ParseLimits(string.Empty).Count);
        }

        [Test]
        public void TestParseLimits()
        {
            string raw = "Gold:-1;Uranium:100;";
            Dictionary<IResourceInfo, int> fromStorage = PlayerConversion.ParseLimits(raw);

            Assert.AreEqual(-1, fromStorage[Gold.Resource]);
            Assert.AreEqual(100, fromStorage[Uranium.Resource]);
        }

        [Test]
        public void ConvertPlayerToStorage_Test()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            IPlayer player = planet.Owner;
            EngineUtils.RandomFillPlayer(player);

            GameEngine.Persist(player);
            PlayerStorage storage = PlayerConversion.ConvertToStorage(player);

            ConversionTest<PlayerStorage>(player, storage, typeof(IPlayer));
            LimitsCheck(player, storage);
        }

        private void LimitsCheck(IPlayer player, PlayerStorage storage)
        {
            Dictionary<IResourceInfo, int> limits = PlayerConversion.ParseLimits(storage.IntrinsicLimits);
            Assert.AreEqual(player.Limits.Count, limits.Count);

            foreach (KeyValuePair<IResourceInfo, int> pair in limits) {
                int actual = player.GetLimit(pair.Key);
                Assert.AreEqual(pair.Value, actual, pair.Key.Name);
            }
        }

        [Test]
        public void ConvertStorageToPlayer_Test()
        {
            Planet planet = EngineUtils.RichPlayerPlanet;
            IPlayer original = planet.Owner;
            PlayerStorage storage = PlayerConversion.ConvertToStorage(original);

            EngineUtils.RandomFillPlayer(storage);

            IPlayer player = PlayerConversion.ConvertToPlayer(storage);

            ConversionTest<PlayerStorage>(player, storage, typeof(IPlayer));
            LimitsCheck(player, storage);

            Assert.AreEqual(player.Planets.Count, storage.Planets.Count, "Planet Count");
        }

        [Test]
        public void Player_Touch()
        {
            TouchTest<PlayerStorage>(EngineUtils.RichPlayer, typeof(IPlayer));
        }

        #endregion Player Tests

        #region Object Conversion Utils

        private void ConversionTest<T>(IBackToStorage<T> back, IEntity storage, params Type[] face)
        {
            foreach (PropertyInfo info in GetMirrorProperties<T>(back, face)) {
                object objectValue = info.GetValue(back, null);
                if( objectValue != null ) {
                    objectValue = objectValue.ToString();
                }
                PropertyInfo other = GetStorageProperty(storage.GetType(), info);

                object storageValue = other.GetValue(storage, null);
                if (storageValue != null) {
                    storageValue = storageValue.ToString();
                }
                Assert.AreEqual(objectValue, storageValue, "Matching values expected for {0}.{1} and {2}.{3} ({4})", back.GetType().Name, info.Name, storage.GetType().Name, other.Name, back);
            }
        }

        private PropertyInfo GetStorageProperty(Type type, PropertyInfo info)
        {
            PropertyInfo other = type.GetProperty(info.Name);
            Assert.IsNotNull(other, "No `{0}' propery found in {1}", info.Name, type.Name);
            return other;
        }

        private IEnumerable<PropertyInfo> GetMirrorProperties<T>(IBackToStorage<T> back, params Type[] face)
        {
            return GetTouchableProperties<T>(back, face);
        }

        #endregion Object Conversion Utils

        #region Touch Tests Utils

        private void TouchTest<T>(IBackToStorage<T> back, Type face)
        {
            foreach (PropertyInfo info in GetTouchableProperties(back, face)) {
                back.IsDirty = false;
                info.SetValue(back, GetDummyObject(info), null);
                Assert.IsTrue(back.IsDirty, "Property {1}.{0} should make the object dirty", info.Name, back.GetType().Name);
            }
        }

        private object GetDummyObject(PropertyInfo info)
        {
            return EngineUtils.GetDummyValue(info.PropertyType);
        }

        private IEnumerable<PropertyInfo> GetTouchableProperties<T>(IBackToStorage<T> back, params Type[] faces)
        {
            foreach(Type face in faces ) {
                foreach (PropertyInfo info in face.GetProperties( BindingFlags.FlattenHierarchy | BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty )) {
                    if (EngineUtils.TargetProperty(info)){
                        yield return back.GetType().GetProperty(info.Name);
                    }
                }
            }
        }

        [Test]
        public void CheckPropertyTypes()
        {
            Assert.IsTrue(EngineUtils.TargetType(typeof(string)));
            Assert.IsTrue(EngineUtils.TargetType(typeof(int)));
            Assert.IsTrue(EngineUtils.TargetType(typeof(char)));
            Assert.IsTrue(EngineUtils.TargetType(typeof(double)));
            Assert.IsTrue(EngineUtils.TargetType(typeof(ResourceState)));

            Assert.IsFalse(EngineUtils.TargetType(typeof(Planet)));
        }

        #region Util Class

        private class RandomFillUtil
        {
            private int myVar;

            public int IntProperty
            {
                get { return myVar; }
                set { myVar = value; }
            }

            private double doubleP;

            public double DoubleProperty
            {
                get { return doubleP; }
                set { doubleP = value; }
            }

            private string sprop;

            public string StringProperty
            {
                get { return sprop; }
                set { sprop = value; }
            }

            private bool bprop;

            public bool BoolProperty
            {
                get { return bprop; }
                set { bprop = value; }
            }
	
        };

        #endregion Util Class

        [Test]
        public void CheckRandomFill()
        {
            RandomFillUtil util = new RandomFillUtil();
            EngineUtils.RandomFill(util);

            Assert.AreNotSame(0, util.IntProperty);
            Assert.AreNotSame(0, util.DoubleProperty);
            Assert.AreNotSame(null, util.StringProperty);
            Assert.AreNotSame(string.Empty, util.StringProperty);
        }

        #endregion Touch Tests Utils

    };
}