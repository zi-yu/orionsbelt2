using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using Loki.DataRepresentation;
using OrionsBelt.Engine;
using OrionsBeltTests;
using NUnit.Framework;
using OrionsBelt.RulesCore.Common;
using System;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Rules;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.Generic;

namespace OrionsBeltTests.EngineTests {

    [TestFixture]
    public class RulesTests : BaseTests {

        #region Dependency

        [Test]
        public void TestDependency()
        {
            Result result;
            IPlanetResource hall = EngineUtils.GetResource(typeof(DarknessHall));
            RuleArgs args = RuleArgs.Create(hall, ResourceState.Available, 2);

            Dependency dep = Dependency.Get(typeof(DarknessHall), 2, typeof(TitaniumExtractor), 1);
            result = dep.CanProcess(args);
            Assert.IsFalse(result.Ok, "Dependency should fail! {0}", result.Log());

            IPlanetResource resource = EngineUtils.GetResource(hall.Owner, typeof(TitaniumExtractor), 0);
            result = dep.CanProcess(args);
            Assert.IsFalse(result.Ok, "Dependency should fail! {0}", result.Log());

            hall.Owner.GetResource(TitaniumExtractor.Resource).Level = 1;
            hall.Owner.GetResource(TitaniumExtractor.Resource).Quantity = 1;
            hall.Owner.GetResource(TitaniumExtractor.Resource).State = ResourceState.Running;
            result = dep.CanProcess(args);
            Assert.IsTrue(result.Ok, "Dependency should succeed! {0}", result.Log());

            hall.Owner.GetResource(TitaniumExtractor.Resource).Level = 2;
            result = dep.CanProcess(args);
            Assert.IsTrue(result.Ok, "Dependency should succeed! {0}", result.Log());
        }

        #endregion Dependency

        #region Cost

        [Test]
        public void Test_Cost_CanProcess()
        {
            IPlanetResource hall = EngineUtils.GetResource(typeof(DarknessHall));
            Cost cost = Cost.Get(typeof(Gold), 100, 2, 2);

            RuleArgs args = RuleArgs.Create(EngineUtils.EmptyPlayer, new PlanetResource(), ResourceState.InQueue, 1, 100);
            Result result = cost.CanProcess(args);
            Assert.IsFalse(result.Ok, "Should fail, no resources to queue {0}", result.Log());

            args = RuleArgs.Create(EngineUtils.RichPlayer, new PlanetResource(), ResourceState.InQueue, 1, 100);
            args.Player.AddQuantity(Gold.Resource, 200000);
            result = cost.CanProcess(args);
            Assert.IsTrue(result.Ok, "Should succeed, there are resources to queue {0}", result.Log());
        }

        [Test]
        public void Test_Cost_Process()
        {
            ExecuteCost(1);
        }

        [Test]
        public void Test_Cost_Process_WithQuantity()
        {
            ExecuteCost(10);
        }

        [Test]
        public void Test_Cost_Process_ZeroQuantity()
        {
            ExecuteCost(0);
        }

        private static void ExecuteCost(int quantity)
        {
            OrionsBelt.Engine.Resources.Player player = EngineUtils.RichPlayer;
            Cost cost = Cost.Get(typeof(Gold), 100, 2, 2);

            int beforeCost = ResourceUtils.GetResourceQuantity(player, typeof(Gold));
            int costPrice = cost.GetCost(1);
            RuleArgs args = RuleArgs.Create(player, new PlanetResource(), ResourceState.InQueue, 1, 100);
            args.Quantity = quantity;
            cost.Process(args);

            int afterCost = ResourceUtils.GetResourceQuantity(player, typeof(Gold));

            Assert.AreEqual(beforeCost - costPrice * quantity, afterCost, "Cost not working. BeforeCost:{0} Price:{1} AfterCost:{2} Quantity:{3}", beforeCost, costPrice, afterCost, quantity);
        }

        [Test]
        public void Test_Cost_Undo()
        {
            int quantity = 1;
            OrionsBelt.Engine.Resources.Player player = EngineUtils.RichPlayer;
            Cost cost = Cost.Get(typeof(Gold), 100, 2, 2);

            int beforeCost = ResourceUtils.GetResourceQuantity(player, typeof(Gold));
            int costPrice = cost.GetCost(1);
            RuleArgs args = RuleArgs.Create(player, new PlanetResource(), ResourceState.InQueue, 1, 100);
            args.Quantity = quantity;

            cost.Process(args);
            cost.Undo(args);

            int afterCost = ResourceUtils.GetResourceQuantity(player, typeof(Gold));

            Assert.AreEqual(beforeCost, afterCost, "Undo not working. BeforeCost:{0} Price:{1} AfterCost:{2} Quantity:{3}", beforeCost, costPrice, afterCost, quantity);            
        }

        #endregion Cost

        [Test]
        public void AreTradeSpecific()
        {
            IList<IIntrinsicInfo> resources = RulesUtils.GetTradeResources();

            foreach (IIntrinsicInfo info in resources)
            {
                Assert.IsTrue(info.IsTradeRouteSpecific);
            }
            Assert.AreEqual(8, resources.Count);

        }


    };
}