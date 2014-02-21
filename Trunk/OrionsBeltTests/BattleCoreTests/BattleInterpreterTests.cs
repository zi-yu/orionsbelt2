using System;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class BattleInterpreterTests: BaseInterpreterTests {

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

		private void PositionUnits2( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";f-100;t-100;p-100";
			battle.PlayerInformation[1].InitialContainer += ";f-100;t-100;p-100";

			string movements = "p:r-7_1-30;p:r-7_2-30;p:r-7_3-40;p:f-7_6-100;p:t-7_7-100;p:p-7_8-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-8_6-30;p:r-8_7-30;p:r-8_8-40;p:f-7_6-100;p:t-7_7-100;p:p-7_8-100;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_1-30-N;0:r-7_2-30-N;0:r-7_3-40-N;0:f-7_6-100-N;0:t-7_7-100-N;0:p-7_8-100-N;1:r-1_3-30-S;1:r-1_2-30-S;1:r-1_1-40-S;1:f-2_3-100-S;1:t-2_2-100-S;1:p-2_1-100-S;");
		}

		private void PositionUnits3( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";s-100";
			battle.PlayerInformation[1].InitialContainer += ";s-100";

			string movements = "p:r-7_1-30;p:r-7_2-30;p:r-7_3-40;p:s-7_4-100";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-7_8-30;p:r-7_7-30;p:r-7_6-40;p:s-7_5-100";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_1-30-N;0:r-7_2-30-N;0:r-7_3-40-N;0:s-7_4-100-N;1:r-2_1-30-S;1:r-2_2-30-S;1:r-2_3-40-S;1:s-2_4-100-S;");
		}

		private void PositionUnits4( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";h-100";
			battle.PlayerInformation[1].InitialContainer += ";c-100";

			string movements = "p:r-7_1-30;p:r-7_2-30;p:r-7_3-40;p:h-7_4-100";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-7_8-30;p:r-7_7-30;p:r-7_6-40;p:c-7_5-100";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_1-30-N;0:r-7_2-30-N;0:r-7_3-40-N;0:h-7_4-100-N;1:r-2_1-30-S;1:r-2_2-30-S;1:r-2_3-40-S;1:c-2_4-100-S;");
		}

		#endregion Private Position

		#region Tests
	
		[Test]
		public void AttackRainWithCrusaders6SucessTest() {
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
		}

		[Test]
		public void AttackCrusadersWithRain6SucessTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:8_1-7_2-50;m:7_2-6_2-100;m:6_2-5_2-100;m:5_2-4_2-100;m:4_2-3_2-100;b:3_2-2_2;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-3_2-100-N;0:c-8_3-100-N;1:c-1_1-50-S;1:r-2_3-100-S;");
		}
		
		[Test]
		public void AttackReboundSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);

			string movements = "m:7_1-6_1-15;m:7_2-6_2-15;m:7_3-6_3-15;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-15-N;0:r-7_2-15-N;0:r-7_3-25-N;0:f-7_6-100-N;0:t-7_7-100-N;0:p-7_8-100-N;1:r-1_3-30-S;1:r-1_2-30-S;1:r-1_1-40-S;1:f-2_3-100-S;1:t-2_2-100-S;1:p-2_1-100-S;0:r-6_1-15-N;0:r-6_2-15-N;0:r-6_3-15-N;");

			movements = "b:7_6-3_6";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-15-N;0:r-7_2-15-N;0:f-7_6-100-N;0:t-7_7-100-N;0:p-7_8-100-N;1:r-1_3-30-S;1:r-1_2-30-S;1:r-1_1-40-S;1:f-2_3-100-S;1:t-2_2-100-S;1:p-2_1-100-S;0:r-6_1-15-N;0:r-6_2-15-N;");
		}

		[Test]
		public void AttackTripleSucessTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);

			string movements = "m:7_1-6_1-15;m:7_2-6_2-15;m:7_3-6_3-15;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-15-N;0:r-7_2-15-N;0:r-7_3-25-N;0:f-7_6-100-N;0:t-7_7-100-N;0:p-7_8-100-N;1:r-1_3-30-S;1:r-1_2-30-S;1:r-1_1-40-S;1:f-2_3-100-S;1:t-2_2-100-S;1:p-2_1-100-S;0:r-6_1-15-N;0:r-6_2-15-N;0:r-6_3-15-N;");

			movements = "m:7_7-6_7-100;b:6_7-3_7";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-15-N;0:r-7_3-25-N;0:f-7_6-100-N;0:t-7_7-100-N;0:p-7_8-100-N;1:r-1_3-30-S;1:r-1_2-30-S;1:r-1_1-40-S;1:f-2_3-100-S;1:t-3_2-100-S;1:p-2_1-100-S;");
		}

		[Test]
		[Ignore]
		public void ReplicatorSucessTest() {
			Battle battle = GetBattle();
			PositionUnits3(battle);

			Result result = BattleManager.MakeMoves(principals[0], string.Empty, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			string movements = "m:7_5-6_6-100;m:6_6-5_7-100;m:5_7-4_8-100;m:4_8-3_8-100;b:3_8-2_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_2-30-N;0:r-7_3-40-N;0:s-7_4-100-N;1:r-2_1-30-S;1:r-2_2-30-S;1:r-2_3-40-S;1:s-6_1-130-S;");
		}

		[Test]
		public void StrikeBackSucessTest() {
			Battle battle = GetBattle();
			PositionUnits4(battle);

			string movements = "m:7_4-6_3-100;m:6_3-5_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:7_5-4_5";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:r-7_1-30-N;0:r-7_2-30-N;0:r-7_3-40-N;0:h-5_4-57-N-4200;1:r-2_1-30-S;1:r-2_2-30-S;1:r-2_3-40-S;1:c-2_4-89-S-750;");
		}

		[Test]
		public void InvalidFirstAttackTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "b:8_3-2_3;m:8_1-7_1-50;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);

			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is FirstAttack, "Result should have the type 'FirstAttack'");

			Console.WriteLine(GetFailedMessages(result));
		}


		[Test]
		public void InvalidCrusaderRangeTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);

			movements = "b:8_8-1_8;";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
		
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidAttack, "Result should have the type 'InvalidAttack'");

			Console.WriteLine(GetFailedMessages(result));
		}

		[Test]
		public void InvalidRainRangeTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:7_2-2_2;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsFalse(result.Ok);
			Assert.IsTrue(result.Failed[0] is InvalidAttack, "Result should have the type 'InvalidAttack'");

			Console.WriteLine(GetFailedMessages(result));
		}
		
		#endregion Tests

	}
}
