using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.RulesCore.Results;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Exceptions;
using OrionsBelt.WebUserInterface.WebBattle;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	public class BattleActions : ActionBase {

		#region Fields

		private readonly int battleId;
		private readonly IBattleInfo battleInfo;
		private readonly IBattleOwner battleOwner;
		private readonly IBattlePlayer battlePlayer;

		#endregion Fields

		#region Delegates

		private void Move() {
			string moves = GetMoves();
			Result result;
			if( battlePlayer != null && battlePlayer.IsTurn ) {
				result = BattleManager.MakeMoves(battleOwner, moves, battleInfo);
			}else {
				result = new Result( new NotYourTurn() );
			}

			BattleUtilities.ClearBattleMessagesCache(battleId);
			WriteResult(result);
			WriteBattle();
		}

		private void Deploy() {
			string moves = GetMoves();
			Result result = BattleManager.DeployUnits(battleOwner, moves, battleInfo);
			WriteResult(result);
			WriteDeploy();
		}

		private void GiveUp() {
			if (!battlePlayer.HasGaveUp) {
				BattleManager.GiveUp(battleOwner, battleInfo);
				BattleUtilities.ClearBattleMessagesCache(battleId);
			} else {
				WriteResult( new Result(new AlreadyGaveUp()) );
			}

			if (battleInfo.HasEnded()) {
				WriteEndBattle();
			} else {
				WriteBattle();
			}
		}


		#endregion Delegates

		#region Private

		protected int GetId() {
			string strid = HttpContext.Current.Request.QueryString["id"];
			int id;
			if( !int.TryParse(strid, out id) ) {
				throw new BattleExceptionUI(LanguageManager.Instance.Get("InvalidBattleId"));
			}
			return id;
		}

		private string GetMoves() {
			string moves = HttpContext.Current.Request.QueryString["moves"];
			//IE Hack
			bool isNullorEmpty = string.IsNullOrEmpty(moves);
			bool isEmpty = !isNullorEmpty && moves.Equals("empty");
			if (isNullorEmpty || isEmpty) {
				return string.Empty;
			}
			return moves;
		}

		#endregion Private

		#region Writers

		private void WriteDeploy() {
			if (battleInfo.NumberOfPlayers == 2) {
				HttpContext.Current.Response.Write(new BattleRenderer2Positioning(battleInfo, battleOwner).Render());
			} else {
				HttpContext.Current.Response.Write(new BattleRenderer4Positioning(battleInfo, battleOwner).Render());
			}
		}

		private void WriteBattle() {
			if (battleInfo.NumberOfPlayers == 2) {
				HttpContext.Current.Response.Write(new BattleRenderer2(battleInfo, battleOwner).Render());
			} else {
				HttpContext.Current.Response.Write(new BattleRenderer4(battleInfo, battleOwner).Render());
			}
		}

		private void WriteEndBattle() {
			if (battleInfo.NumberOfPlayers == 2) {
				HttpContext.Current.Response.Write(new BattleEndRenderer2(battleInfo, battleOwner).Render());
			} else {
				HttpContext.Current.Response.Write(new BattleEndRenderer4(battleInfo, battleOwner).Render());
			}
		}

		#endregion Writers

		#region Constructor

		public BattleActions() {
			battleId = GetId();
			battleInfo = BattleUtilities.GetBattle(battleId);
			battleOwner = BattleOwnerWeb.Get(battleInfo);
			battlePlayer = battleInfo.GetPlayer(battleOwner);

			actions["battle"] = Move;
			actions["deploy"] = Deploy;
			actions["giveUp"] = GiveUp;
		}

		#endregion Constructor


	}
}
