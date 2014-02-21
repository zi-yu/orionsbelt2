using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class EndBattleDominationTests: BaseInterpreterTests {

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
			string movements = "p:r-11_5-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-11_7-100;";

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

			ValidateFinalState(battle, "0:r-11_5-100-N;1:r-2_6-100-S;2:r-9_2-100-E;3:r-6_11-100-W;");
		}

		#endregion Private Position

		#region Test End Battle Success

		[Test]
		public void EndBattleDomination2Test() {
			Battle battle = GetBattle(BattleType.Domination);
			PositionUnits(battle);

			string movements = "m:7_1-6_2-100;m:6_2-5_3-100;m:5_3-5_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.Greater(battle.PlayerInformation[0].DominationPoints, 0);

			while( battle.CurrentTurn < 38 ) {
				movements = "";
				result = BattleManager.MakeMoves(principals[1], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
				result = BattleManager.MakeMoves(principals[0], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
			}

			movements = "";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.HasEnded);
		}

		[Test]
		public void EndBattleDomination4Test() {
			Battle battle = GetBattle4Players(BattleType.Domination4,BattleMode.Friendly);
			PositionUnits4(battle);

			string movements = "m:11_5-10_5-100;m:10_5-9_5-100;m:9_5-8_5-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));
			Assert.AreEqual(1,battle.PlayerInformation[0].DominationPoints);

			movements = string.Empty;
			while( battle.CurrentTurn < 38 ) {
				result = BattleManager.MakeMoves(principals[1], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
				result = BattleManager.MakeMoves(principals[2], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
				result = BattleManager.MakeMoves(principals[3], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
				result = BattleManager.MakeMoves(principals[0], movements, battle);
				Assert.IsTrue(result.Ok, GetFailedMessages(result));
				Assert.IsTrue(!battle.HasEnded);
			}

			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			result = BattleManager.MakeMoves(principals[2], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			result = BattleManager.MakeMoves(principals[3], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			Assert.IsTrue(battle.HasEnded);
	
		}
		
		#endregion

	}
}
