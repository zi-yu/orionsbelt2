using System;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class PositionInterpreterTests: BaseInterpreterTests {

		#region Tests

		[Test]
		public void PositionSuccessTest() {
			Battle battle = GetBattle();
			string movements = "p:r-8_1-50;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
		}

		[Test]
		public void BothPlayersPositionSuccessTest() {
			Battle battle = GetBattle();
			string movements = "p:r-8_1-50;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			Assert.AreEqual(2, battle.BattleExtension[0].BattleFinalStates.Split('|').Length);
		}

		[Test]
		public void NotAllUnitsPositionedTest() {
			Battle battle = GetBattle();
			string movements = "p:r-8_1-25;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is MustPositionAllTheUnits, "Result should have the type 'MustPositionAllTheUnits'");
			
			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void MoreUnitsTest() {
			Battle battle = GetBattle();
			string movements = "p:r-8_1-50;p:r-7_2-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidUnitPositioning, "Result should have the type 'InvalidUnitPositioning'");

			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void NotExistintUnitTest() {
			Battle battle = GetBattle();
			string movements = "p:asfdg-8_1-50;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidUnit, "Result should have the type 'InvalidUnit'");
			
			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void OutOfBoardPositioningTest() {
			Battle battle = GetBattle();
			string movements = "p:r-10_1-50;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidCoordinate, "Result should have the type 'InvalidCoordinate'");

			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void InvalidSyntaxInMovesTest() {
			Battle battle = GetBattle();
			string movements = "p:r-10_1-50|p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidInterpretationData, "Result should have the type 'InvalidCoordinate'");

			Console.WriteLine(GetFailedMessages(result));
		}


		[Test]
		public void DeployToTheSameTest() {
			Battle battle = GetBattle();
			battle.PlayerInformation[0].InitialContainer += ";c-100";

			string movements = "p:r-8_1-100;p:c-8_1-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Failed[0] is CoordinateAlreadyHasAUnit, "Result should have type 'CoordinateAlreadyHasAUnit'");
		}

		#endregion Tests
	}
}
