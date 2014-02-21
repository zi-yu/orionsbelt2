using System;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class TimeoutTests: BaseInterpreterTests {

		#region Private Position

		private void PositionUnits( Battle battle ) {
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-7_1-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:c-7_8-100;p:r-7_7-100;";

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_1-100-N;1:c-2_1-100-S;1:r-2_2-100-S;");
		}

		private void PositionUnits4( Battle battle ) {
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-11_5-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:c-11_8-100;p:r-11_7-100;";

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-11_9-100;";

			result = BattleManager.DeployUnits(principals[2], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-11_7-100;";

			result = BattleManager.DeployUnits(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-11_5-100-N;1:c-2_5-100-S;1:r-2_6-100-S;2:r-9_2-100-E;3:r-6_11-100-W;");
		}

		#endregion Private Position

		#region Test End Battle Success

		[Test]
		[Ignore]
		public void BattlePositionTimeout() {
			Battle battle = GetBattle();
			BattleManager.Timeout(battle);

			Assert.IsFalse(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);

			Assert.IsFalse(battle.IsDeployTime);

			ValidateFinalState(battle, ";0:r-8_1-100-N;1:r-1_8-100-S");
		}

		[Test]
		public void BattleTimeoutWithoutDeploy() {
			Battle battle = GetBattle();

			string movements = "p:r-7_1-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			BattleManager.Timeout(battle);
			BattleManager.Timeout(battle);
			BattleManager.Timeout(battle);

			Assert.IsFalse(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[0].HasGaveUp);
			Assert.IsTrue(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasGaveUp);
		}

		[Test]
		public void BattleTimeout2() {
			Battle battle = GetBattle();
			PositionUnits(battle);
			
			BattleManager.Timeout(battle);

			Assert.IsFalse(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsFalse(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[0].HasGaveUp);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasGaveUp);

			Assert.Less(battle.PlayerInformation[0].WinScore,battle.PlayerInformation[1].WinScore);
			Console.WriteLine("Score Player 1: {0}", battle.PlayerInformation[0].WinScore);
			Console.WriteLine("Score Player 2: {0}", battle.PlayerInformation[1].WinScore);
			
			Assert.IsTrue(battle.HasEnded);
		}

		[Test]
		public void BattleTimeout4() {
			Battle battle = GetBattle4Players();
			PositionUnits4(battle);

			string movements = "m:11_5-10_5-100;m:10_5-9_5-100;m:9_5-8_5-100;m:8_5-7_5-100;m:7_5-6_5-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:11_8-7_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			Assert.AreEqual(0,battle.PlayerInformation[0].WinScore);
			Assert.Greater(battle.PlayerInformation[1].WinScore, 0);
			Assert.AreEqual(0, battle.PlayerInformation[2].WinScore);
			Assert.AreEqual(0, battle.PlayerInformation[3].WinScore);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			Assert.AreEqual(0, battle.PlayerInformation[0].WinScore);
			Assert.Greater(battle.PlayerInformation[1].WinScore, 0);
			Assert.AreEqual(0, battle.PlayerInformation[2].WinScore);
			Assert.Greater(battle.PlayerInformation[3].WinScore, 0);
			Assert.Greater(battle.PlayerInformation[1].WinScore, battle.PlayerInformation[3].WinScore);
			
			movements = "m:11_7-10_7-100;m:10_7-9_7-100;m:9_7-8_7-100;m:8_7-7_7-100;m:7_7-6_7-100;m:6_7-5_6-100;";
			result = BattleManager.MakeMoves(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:11_8-7_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);
			
			BattleManager.Timeout(battle);

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsTrue(battle.PlayerInformation[3].HasLost);
			
			Assert.IsTrue(battle.HasEnded);
		}

		#endregion

	}
}
