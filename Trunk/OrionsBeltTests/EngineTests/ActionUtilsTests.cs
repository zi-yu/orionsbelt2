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

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class ActionUtilsTests: BaseTests  {

        #region GetActionByName

        [Test]
        public void GetActionByName_SmokeTest()
        {
            Assert.AreEqual("DoNothing", ActionUtils.GetActionByName("DoNothing").Name);
            Assert.AreEqual("AutoRepeatableDoNothing", ActionUtils.GetActionByName("AutoRepeatableDoNothing").Name);
        }

        [Test]
        public void GetActionByName_TestAll()
        {
            foreach (IFactory factory in ActionUtils.GetActionFactories()) {
                Assert.IsNotNull(factory.create(null));
            }
        }

        #endregion GetActionByName

    };
}