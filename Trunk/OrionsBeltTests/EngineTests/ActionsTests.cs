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

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ActionTests: BaseTests {

        #region ActionManager Tests

        [Test]
        public void ActionManager_AllPublic()
        {
            IList<TimedActionStorage> list = GetAllPublic();
            ActionManager.ProcessActions(list);

            foreach (TimedActionStorage storage in list) {
                if (storage.Name == "DoNothing") {
                    Assert.AreEqual(2, storage.EndTick);
                } else if( storage.Name == "AutoRepeatableDoNothing" ) {
                    Assert.Greater(storage.EndTick, 2);
                }
            }
        }

        private IList<TimedActionStorage> GetAllPublic()
        {
            List<TimedActionStorage> list = new List<TimedActionStorage>();

            list.Add(EngineUtils.GetTimedActionStorage("DoNothing", Visibility.Public, 2));
            list.Add(EngineUtils.GetTimedActionStorage("AutoRepeatableDoNothing", Visibility.Public, 2));

            return list;
        }

        #endregion ActionManager Tests

        #region Actions

        #region DoNothing

        [Test]
        public void Action_DoNothing()
        {
            DoNothing action = new DoNothing(5, Visibility.Public);
            int tick = action.EndTick;
            Assert.AreEqual(Visibility.Public, action.Visibility);
            Assert.IsFalse(action.Ended, "Should not be ended");
            Assert.IsFalse(action.Executed, "Should not be flagged as executed");
            action.Process();
            Assert.IsTrue(action.Executed, "Should be executed");
            Assert.AreEqual(tick, action.EndTick);
        }

        #endregion DoNothing

        #region AutoRepeatableDoNothing

        [Test]
        public void Action_AutoRepeatableDoNothing()
        {
            AutoRepeatableDoNothing action = new AutoRepeatableDoNothing(5, Visibility.Public);
            int tick = action.EndTick;
            Assert.AreEqual(Visibility.Public, action.Visibility);
            Assert.IsFalse(action.Ended, "Should not be ended");
            Assert.IsFalse(action.Executed, "Should not be flagged as executed");
            action.Interval = 10;
            action.Process();
            Assert.IsTrue(action.Executed, "Should be executed");
            Assert.Greater(action.EndTick, tick);
        }

        #endregion AutoRepeatableDoNothing

        #endregion Actions

    };
}