using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;


namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class RotationInterpreterTests: BaseInterpreterTests {

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

		#endregion Private Position

		#region Test movementTypes

		[Test]
		public void RotationSTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "r:8_1-N-S;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			ValidateFinalState(battle, "0:r-8_1-50-S;0:r-7_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;");
		}

		[Test]
		public void RotationWTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "r:8_1-N-W;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			ValidateFinalState(battle, "0:r-8_1-50-W;0:r-7_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;");
		}

		[Test]
		public void RotationETest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "r:8_1-N-E;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			ValidateFinalState(battle, "0:r-8_1-50-E;0:r-7_2-50-N;1:r-1_8-50-S;1:r-2_7-50-S;");
		}

		[Test]
		public void RotationSToPlayer2Test() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			
			string movements = "";
			BattleManager.MakeMoves(principals[0], movements, battle);

			movements = "r:8_1-N-S;";
			Result result = BattleManager.MakeMoves(principals[1], movements, battle);

			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			ValidateFinalState(battle, "0:r-8_1-50-N;0:r-7_2-50-N;1:r-1_8-50-N;1:r-2_7-50-S;");
		}


		[Test]
		public void InvalidRotationTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			string movements = "r:8_1-N-G;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidRotation, "Result should have the type 'InvalidRotation'");
		}

		#endregion

	}
}
