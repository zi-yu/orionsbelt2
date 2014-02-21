using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBeltTests.BattleCoreTests {
	
	[TestFixture]
	public class ScoreTests: BaseInterpreterTests {

		#region Private Position

		private void PositionUnits( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";c-100";
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-8_1-50;p:r-7_2-50;p:c-8_3-100";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:c-8_8-50;p:c-7_7-50;p:r-7_6-100";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-8_1-50-N;0:r-7_2-50-N;0:c-8_3-100-N;1:c-1_1-50-S;1:c-2_2-50-S;1:r-2_3-100-S;");
		}

		#endregion Private Position

		#region Public
		
		[Test]
		public void ScoreTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:8_3-2_3;m:8_1-7_1-50;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-50-N;0:r-7_2-50-N;0:c-8_3-100-N;1:c-1_1-50-S;1:c-2_2-50-S;");

			Assert.Greater(battle.PlayerInformation[0].WinScore,0);
			//Assert.AreEqual(0, battle.PlayerInformation[0].LoseScore);
			Assert.AreEqual(0, battle.PlayerInformation[1].WinScore);
			//Assert.Less(battle.PlayerInformation[1].LoseScore,0);

			Assert.IsFalse(battle.HasEnded);
		}

		[Test]
		public void VictoryPercentageTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:8_3-2_3;m:8_1-7_1-50;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-50-N;0:r-7_2-50-N;0:c-8_3-100-N;1:c-1_1-50-S;1:c-2_2-50-S;");

			Assert.Greater(battle.PlayerInformation[0].VictoryPercentage, 50);
			Assert.Less(battle.PlayerInformation[1].VictoryPercentage, 50);

			Assert.IsFalse(battle.HasEnded);
		}

		#endregion	Public
	}
}
