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

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class EntityPersistanceTests: BaseTests {

        #region IPlayer

        [Test]
        public void TestPlayerPersistance()
        {
            IPlayer player = EngineUtils.RichPlayer;
            IResourceInfo res = Gold.Resource;

            int gold = player.GetQuantity(res);
            player.AddQuantity(res, 500);

            Assert.AreEqual(gold+500, player.GetQuantity(res));

            GameEngine.ProcessPlayer(player);

            IPlayer reloaded = PlayerConversion.ConvertToPlayer(player.Storage);

            Assert.AreEqual(player.GetQuantity(res), reloaded.GetQuantity(res));
        }

        [Test]
        public void TestPlayerIntrinsics()
        {
            IPlayer player = EngineUtils.EmptyPlayer;
            IResourceInfo res = Gold.Resource;

            player.AddQuantity(res, 5000);
            Assert.AreEqual(5000, player.GetQuantity(res));

            GameEngine.ProcessPlayer(player);

            PlayerUtils.Refresh(player);

            Assert.AreEqual(5000, player.GetQuantity(res));
        }

        #endregion IPlayer

    };
}