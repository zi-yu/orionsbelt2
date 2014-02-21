using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.BattleCore.Translate;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBeltTests.BattleCoreTests {

	[TestFixture]
	public class SpecialAttacksTests: BaseInterpreterTests {

		#region Private Position

		private void PositionUnits( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer += ";e-100;f-100;t-100";
			battle.PlayerInformation[1].InitialContainer += ";e-100;t-100;sp-100";

			string movements = "p:f-7_2-100;p:r-7_3-100;p:e-7_4-100;p:t-7_6-100;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:sp-7_1-100;p:r-7_2-10;p:t-7_3-100;p:r-7_4-10;p:r-7_5-30;p:e-7_7-100;p:r-7_8-50;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:e-7_4-100-N;0:f-7_2-100-N;0:r-7_3-100-N;0:t-7_6-100-N;1:e-2_2-100-S;1:r-2_1-50-S;1:r-2_4-30-S;1:r-2_5-10-S;1:r-2_7-10-S;1:t-2_6-100-S;1:sp-2_8-100-S;");
		}

		private void PositionUnits2( Battle battle ) {
			battle.PlayerInformation[0].InitialContainer = "r-7;t-7";
			battle.PlayerInformation[1].InitialContainer = "r-7;t-7";

			string movements = "p:r-7_1-7;p:t-7_2-7";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:r-7_7-7;p:t-7_8-7";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "0:r-7_1-7-N;0:t-7_2-7-N;1:r-2_2-7-S;1:t-2_1-7-S;");
		}

		private void PositionUnits3(Battle battle) {
			battle.PlayerInformation[0].InitialContainer = "dr-12;t-5;";
			battle.PlayerInformation[1].InitialContainer = "dr-12;t-5;";

			string movements = "p:dr-7_2-6;p:dr-7_3-3;p:dr-7_4-3;p:t-7_6-5;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:dr-7_2-6;p:dr-7_3-3;p:dr-7_4-3;p:t-7_6-5;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "1:dr-2_7-6-S;1:dr-2_6-3-S;1:dr-2_5-3-S;1:t-2_3-5-S;0:dr-7_2-6-N;0:dr-7_3-3-N;0:dr-7_4-3-N;0:t-7_6-5-N;");
		}

		private void PositionUnits4(Battle battle) {
			battle.PlayerInformation[0].InitialContainer = "dr-12;sp-12;e-12;";
			battle.PlayerInformation[1].InitialContainer = "dr-12;sp-12;e-12;";

			//0:sp-7_3-12-N;0:dr-7_5-12-N;0:e-7_6-12-N;

			string movements = "p:sp-7_3-12;p:dr-7_5-12;p:e-7_6-12;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:sp-7_6-12;p:dr-7_3-12;p:e-7_4-12;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "1:dr-2_6-12-S;1:e-2_5-12-S;1:sp-2_3-12-S;0:sp-7_3-12-N;0:dr-7_5-12-N;0:e-7_6-12-N;");
		}

		private void PositionUnits5(Battle battle) {
			battle.PlayerInformation[0].InitialContainer = "dr-12;sp-12;e-12;";
			battle.PlayerInformation[1].InitialContainer = "dr-12;sp-12;e-12;";
		
			string movements = "p:sp-7_5-12;p:dr-7_7-12;p:e-7_6-12;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:sp-7_3-12;p:dr-7_2-12;p:e-7_4-12;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "1:dr-2_7-12-S;1:sp-2_6-12-S;1:e-2_5-12-S;0:sp-7_5-12-N;0:e-7_6-12-N;0:dr-7_7-12-N;");
		}

		private void PositionUnits6(Battle battle) {
			battle.PlayerInformation[0].InitialContainer = "sk-10;it-10;hp-10;dy-10;sg-10;hk-10;hr-10;";
			battle.PlayerInformation[1].InitialContainer = "sk-10;it-10;hp-10;dy-10;sg-10;hk-10;hr-10;";

			string movements = "p:sk-7_1-10;p:it-7_2-10;p:hp-7_3-10;p:dy-7_4-10;p:sg-7_5-10;p:hk-7_6-10;p:hr-7_7-10;";
			Result result = BattleManager.DeployUnits(principals[0], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsFalse(battle.PlayerInformation[1].HasPositioned);

			movements = "p:sk-7_2-10;p:it-7_3-10;p:hp-7_4-10;p:dy-7_5-10;p:sg-7_6-10;p:hk-7_7-10;p:hr-7_8-10;";
			result = BattleManager.DeployUnits(principals[1], movements, battle);
			Assert.IsTrue(result.Ok);
			Assert.IsTrue(battle.PlayerInformation[0].HasPositioned);
			Assert.IsTrue(battle.PlayerInformation[1].HasPositioned);

			ValidateFinalState(battle, "1:sk-2_7-10-S;1:it-2_6-10-S;1:hp-2_5-10-S;1:dy-2_4-10-S;1:sg-2_3-10-S;1:hk-2_2-10-S;1:hr-2_1-10-S;0:sk-7_1-10-N;0:it-7_2-10-N;0:hp-7_3-10-N;0:dy-7_4-10-N;0:sg-7_5-10-N;0:hk-7_6-10-N;0:hr-7_7-10-N;");
		}

		#endregion Private Position

		#region Tests
	
		[Test]
		public void ReboundAndTripleAttackTest() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:7_4-6_4-10;m:6_4-6_3-5;m:7_2-6_2-10;";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:7_6-6_6-100;b:6_6-3_6";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:e-7_4-100-N;0:f-7_2-100-N;0:r-7_3-100-N;0:t-6_6-100-N;1:e-2_2-100-S;1:r-2_1-50-S;1:r-2_4-30-S;1:t-2_6-27-S-3550;1:sp-2_8-100-S;");
		}

		[Test]
		public void Catapult() {
			Battle battle = GetBattle();
			PositionUnits(battle);

			string movements = "m:7_4-6_3-100;m:6_3-5_4-100;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:7_7-6_6-100;m:6_6-5_5-100;";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:5_4-2_4";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:e-5_4-100-N;0:f-7_2-100-N;0:r-7_3-100-N;0:t-7_6-100-N;1:e-4_4-100-S;1:r-2_1-50-S;1:r-2_5-10-S;1:r-2_7-10-S;1:t-2_6-100-S;1:sp-2_8-100-S;");
		}

		[Test]
		public void StrikeBack() {
			Battle battle = GetBattle();
			PositionUnits4(battle);

			BattleInfo b = new TotalAnnihalation(new BattleWrapper(battle));
			IBattlePlayer p = b.Players[1];
			Translater t = new Translater(p);

			string movements = "m:7_6-6_5-12-n;m:6_5-5_4-12-n;m:5_4-4_3-12-n;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = t.TranslateMovements("m:2_5-3_4-12;m:2_6-3_5-12;m:3_5-4_4-12;m:4_4-5_3-12;"); ;
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:4_3-2_3;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "1:dr-5_3-12-S;1:e-3_4-12-S;1:sp-2_3-4-S-1800;0:sp-7_3-12-N;0:dr-7_5-12-N;0:e-4_3-6-N-p#0;");
		}

		[Test]
		public void StrikeBack2() {
			Battle battle = GetBattle();
			PositionUnits5(battle);

			BattleInfo b = new TotalAnnihalation(new BattleWrapper(battle));
			IBattlePlayer p = b.Players[1];
			Translater t = new Translater(p);

			string movements = "m:7_6-6_5-12-n;m:6_5-5_6-12-n;m:7_7-6_7-12-n;m:6_7-5_7-12-n;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "" ;
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:5_7-4_6-12-n;b:5_6-2_6;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "1:dr-2_7-12-S;1:sp-2_6-4-S-1800;1:e-2_5-12-S;0:sp-7_5-12-N;0:e-5_6-12-N;0:dr-4_6-12-N;");
		}

		[Test]
		public void ReboundTest() {
			Battle battle = GetBattle();
			PositionUnits2(battle);

			string movements = "m:7_1-6_1-7;m:6_1-5_1-7;m:5_1-4_1-7;m:4_1-3_1-4;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:7_8-6_8";
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "0:t-7_2-7-N;1:r-2_2-7-S;1:t-2_1-7-S;");
		}
		
		[Test]
		public void TripleAttackTest() {
			Battle battle = GetBattle();
			PositionUnits3(battle);

			BattleInfo b = new TotalAnnihalation(new BattleWrapper(battle));
			IBattlePlayer p = b.Players[1];
			Translater t = new Translater(p);

			string movements = "m:7_6-6_6-5-n;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = t.TranslateMovements("m:2_3-3_3-5;");
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "m:6_6-5_6-5-n;b:5_6-2_6;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "1:t-3_3-5-S;0:dr-7_2-6-N;0:dr-7_3-3-N;0:dr-7_4-3-N;0:t-5_6-5-N;");
		}


		[Test]
		public void BombAttackTest() {
			Battle battle = GetBattle();
			PositionUnits6(battle);

			BattleInfo b = new TotalAnnihalation(new BattleWrapper(battle));
			IBattlePlayer p = b.Players[1];
			Translater t = new Translater(p);

			string movements = "m:7_4-6_5-10-n;m:6_5-5_4-10-n;m:5_4-4_5-10-n;";
			Result result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = t.TranslateMovements("m:2_6-3_5-10;m:3_5-4_4-7;m:4_4-5_5-5;m:2_7-3_6-10;");
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = t.TranslateMovements("m:5_5-4_6-3;m:3_6-4_7-7;m:4_7-5_6-7;");
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = t.TranslateMovements("m:5_6-6_5-5;m:6_5-5_4-5;m:2_3-3_4-10;");
			result = BattleManager.MakeMoves(principals[1], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			movements = "b:4_5-3_5;";
			result = BattleManager.MakeMoves(principals[0], movements, battle);
			Assert.IsTrue(result.Ok, GetFailedMessages(result));

			ValidateFinalState(battle, "1:hp-2_5-10-S;1:dy-2_4-10-S;1:hk-2_2-10-S;1:hr-2_1-10-S;0:sk-7_1-10-N;0:it-7_2-10-N;0:hp-7_3-10-N;0:dy-4_5-10-N;0:sg-7_5-10-N;0:hk-7_6-10-N;0:hr-7_7-10-N;");
		}

		

		#endregion Tests

	}
}
