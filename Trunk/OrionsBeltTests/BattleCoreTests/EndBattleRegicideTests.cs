using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class EndBattleRegicideTests: BaseInterpreterTests {

		#region Private Position

		private void PositionUnitsRegicide( Battle battle ) {
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-7_2-100;p:fg-7_1-1";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:c-7_8-100;p:r-7_7-100;p:fg-7_6-1";

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_2-100-N;0:fg-7_1-1-N;1:c-2_1-100-S;1:r-2_2-100-S;1:fg-2_3-1-S;");
		}

		private void PositionUnitsRegicide4( Battle battle ) {
			battle.PlayerInformation[1].InitialContainer += ";c-100";
			
			string movements = "p:fg-11_5-1;p:r-11_4-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[2].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[3].HasPositioned);

			movements = "p:c-11_8-100;p:r-11_7-100;p:fg-11_6-1;";

			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[2].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[3].HasPositioned);

			movements = "p:r-11_8-100;p:fg-11_9-1;";

			result = BattleManager.DeployUnits(principals[2], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[2].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[3].HasPositioned);

			movements = "p:r-11_8-100;p:fg-11_7-1;";

			result = BattleManager.DeployUnits(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[2].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[3].HasPositioned);

			ValidateFinalState(battle, "0:fg-11_5-1-N;0:r-11_4-100-N;1:c-2_5-100-S;1:fg-2_7-1-S;1:r-2_6-100-S;2:fg-9_2-1-E;2:r-8_2-100-E;3:fg-6_11-1-W;3:r-5_11-100-W;");
		}

		#endregion Private Position

		#region Test End Battle Success

		[Test]
		public void EndBattleRegicide2Test() {
			Battle battle = GetBattle(BattleType.Regicide, BattleMode.Friendly);
			PositionUnitsRegicide(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:7_8-2_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.HasEnded);
		}
	
		[Test]
		public void EndBattleTotalRegicide4Test() {
			Battle battle = GetBattle4Players(BattleType.Regicide4, BattleMode.Friendly);
			PositionUnitsRegicide4(battle);

			string movements = "m:11_5-10_5-1;m:10_5-9_5-1;m:9_5-8_5-1;m:8_5-7_5-1;m:7_5-6_5-1;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:11_8-7_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsFalse(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			Assert.AreEqual(0, battle.PlayerInformation[0].WinScore);
			Assert.AreEqual(50000, battle.PlayerInformation[1].WinScore);
			Assert.AreEqual(0, battle.PlayerInformation[2].WinScore);
			Assert.AreEqual(0, battle.PlayerInformation[3].WinScore);

			movements = "m:11_9-10_8-1;m:10_8-9_7-1;m:9_7-8_6-1;";
			result = BattleManager.MakeMoves(principals[2], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:11_7-10_7-1;m:10_7-9_7-1;m:9_7-8_7-1;m:8_7-7_7-1;m:7_7-6_7-1;m:6_7-5_6-1;";
			result = BattleManager.MakeMoves(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:11_8-7_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsFalse(battle.PlayerInformation[3].HasLost);

			movements = string.Empty;
			result = BattleManager.MakeMoves(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:11_8-6_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.PlayerInformation[0].HasLost);
			Assert.IsFalse(battle.PlayerInformation[1].HasLost);
			Assert.IsTrue(battle.PlayerInformation[2].HasLost);
			Assert.IsTrue(battle.PlayerInformation[3].HasLost);

			Assert.IsTrue(battle.HasEnded);
		}

		#endregion

	}
}
