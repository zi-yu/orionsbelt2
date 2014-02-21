using System;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;


namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class MoveInterpreterTests: BaseInterpreterTests {

		#region Private Position

		private void PositionUnits( Battle battle ) {
			string movements = "p:r-8_1-50;p:r-7_2-50;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-8_1-50-N;0:r-7_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;");
		}

		private void PositionUnits2( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";c-100;h-100;f-100;";
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-8_1-50;p:r-7_2-50;p:c-8_3-100;p:h-8_4-100;p:f-8_5-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-8_1-50;p:r-7_2-50;p:c-8_3-100";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-8_1-50-N;0:r-7_2-50-N;0:c-8_3-100-N;0:h-8_4-100-N;0:f-8_5-100-N;1:r-1_8-50-S;1:r-2_7-50-S;1:c-1_6-100-S;");
		}

		#endregion Private Position

		#region Tests

		[Test]
		public void MoveAllRainsSucessTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "m:8_1-7_1-50;m:7_1-6_1-25;m:6_1-5_1-25;m:7_1-8_1-25;m:7_2-6_2-50;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.AreEqual(battle.CurrentPlayer, principals[1].Id);

			ValidateFinalState(battle, "0:r-8_1-25-N;0:r-6_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;0:r-5_1-25-N;");
		}

		[Test]
		public void MoveAllRains2PlayersSucessTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "m:8_1-7_1-50;m:7_1-6_1-25;m:6_1-5_1-25;m:7_1-8_1-25;m:7_2-6_2-50";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.AreEqual(battle.CurrentPlayer, principals[1].Id);

			ValidateFinalState(battle, "0:r-8_1-25-N;0:r-6_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;0:r-5_1-25-N;");

			movements = "m:8_1-7_1-50;m:7_1-6_1-40;m:6_1-5_1-40;m:7_1-8_1-10;m:7_2-6_2-50";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.AreEqual(principals[0].Id, battle.CurrentPlayer);

			ValidateFinalState(battle, "0:r-8_1-25-N;0:r-6_2-50-N;1:r-1_8-10-S;1:r-3_7-50-S;0:r-5_1-25-N;1:r-4_8-40-S;");
		}

		[Test]
		public void ToMuchMovementsTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_1-7_1-50;m:7_1-6_1-25;m:6_1-5_1-25;m:7_1-8_1-25;m:7_2-6_2-50;m:6_2-5_2-50;m:8_3-7_3-100";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidNumberOfMoves, "Result should have the type 'InvalidNumberOfMoves'");
		}

		[Test]
		public void MovementRainAndCrusaderSuccessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_3-7_3-100;m:8_1-7_1-50;m:7_1-6_1-50;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.AreEqual(battle.CurrentPlayer, principals[1].Id);

			ValidateFinalState(battle, "0:r-6_1-50-N;0:r-7_2-50-N;0:c-7_3-100-N;0:h-8_4-100-N;0:f-8_5-100-N;1:r-1_8-50-S;1:r-2_7-50-S;1:c-1_6-100-S;");
		}

		#endregion Tests

		#region Test movementTypes

		[Test]
		public void FrontMovementSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_3-7_3-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
		}

		[Test]
		public void FrontMovementErrorTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_3-8_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			
			Assert.IsFalse(result.Ok);
			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void AllMovementSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_1-8_2-50;m:8_2-7_2-50;m:7_2-7_1-50;m:7_1-8_2-50;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
		}

		[Test]
		public void AllMovementErrorTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_1-7_3-50;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void DiagonalMovementSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_4-7_3-100;m:7_3-6_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
		}

		[Test]
		public void DiagonalMovementErrorTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_4-7_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void NormalMovementSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_5-7_5-100;m:7_5-7_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
		}

		[Test]
		public void NormalMovementErrorTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);
			string movements = "m:8_5-7_5-100;m:7_5-6_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Console.WriteLine(GetFailedMessages(result));
		}

		#endregion

	}
}
