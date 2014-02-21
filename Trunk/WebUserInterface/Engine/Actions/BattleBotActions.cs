using System.Collections.Generic;
using System.IO;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Exceptions;
using OrionsBelt.WebUserInterface.WebBattle;
using System.Web;

namespace OrionsBelt.WebUserInterface.Engine {
	public class BattleBotActions : ActionBase {

		#region Fields

		private readonly int battleId;
		private readonly IBattleInfo battleInfo;

		#endregion Fields

        #region Private

		protected int GetId() {
			string strid = HttpContext.Current.Request.QueryString["id"];
			int id = -1;
            if (!string.IsNullOrEmpty(strid)){
			    if( int.TryParse(strid, out id) ) {
                    return id;
			    }
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

		private IBattleOwner GetOwner() {
			string ownerId = HttpContext.Current.Request.QueryString["botId"];
			//IE Hack
			if (!string.IsNullOrEmpty(ownerId)) {
				try {
					int id = int.Parse(ownerId);
					IBattlePlayer player = battleInfo.GetPlayerByBotId(id);
					if(player != null ) {
						return player.Owner;
					}
				}catch{}
			}
			
			return null;
		}

        private bool VerifyOwnerShip(){
            string ownerId = HttpContext.Current.Request.QueryString["botId"];
            string code = HttpContext.Current.Request.QueryString["verificationCode"];
            if (!string.IsNullOrEmpty(ownerId) && !string.IsNullOrEmpty(code)){
                int id;
                if( int.TryParse(ownerId,out id)) {
                    IList<Principal> principals = Hql.StatelessQuery<Principal>("select p from SpecializedPrincipal p where p.Id = :id and p.Password = :pass",Hql.Param("id",id),Hql.Param("pass",code));
                    return principals.Count > 0;
                }
            }
            return false;
        }

		#endregion Private

		#region Delegates

		private void BotDeploy() {
            if (VerifyOwnerShip()){
                IBattleOwner owner = GetOwner();
                if(owner != null ){
                    string moves = GetMoves();
				    Result result = BattleManager.DeployUnits(owner, moves, battleInfo);
				    BattleUtilities.ClearBattleMessagesCache(battleId);
					if(result.Ok){
						HttpContext.Current.Response.Write("0");
					}
			    }
            }else{
                WriteOwnerShipError();
            }
		}
        
		private void BotBattle() {
            if (VerifyOwnerShip()){
                int botId = int.Parse(HttpContext.Current.Request.QueryString["botId"]);
                IBattleOwner player = battleInfo.CurrentBattlePlayer.Owner;
                if( player.BotId == botId) {
                    string moves = GetMoves();
			        Result result = BattleManager.MakeMoves(battleInfo.CurrentBattlePlayer.Owner, moves, battleInfo);
			        BattleUtilities.ClearBattleMessagesCache(battleId);
					if (result.Ok) {
						HttpContext.Current.Response.Write("0");
					}
                }
            }else{
                WriteOwnerShipError();
            }
		}

		private void BotHasBattles() {
            if (VerifyOwnerShip()){
			    int botId = int.Parse(HttpContext.Current.Request.QueryString["botId"]);
			    List<IBattleInfo> battle = BattlePersistance.GetBotBattles(botId);
			    foreach (IBattleInfo info in battle) {
				    BattleManager.AlertBot(info);
			    }
            }else{
                WriteOwnerShipError();
            }
		}

        private void BotGetBattles(){
            if (VerifyOwnerShip()){
                int botId = int.Parse(HttpContext.Current.Request.QueryString["botId"]);
                List<IBattleInfo> battle = BattlePersistance.GetBotBattles(botId);
                StringWriter writer = new StringWriter();
                if (battle!= null){
                    writer.Write("<Battles>");
                    foreach (IBattleInfo info in battle){
                        if (info.IsDeployTime) {
                            writer.Write(ConvertBattleToXML.UnitToDeploy(info,botId));
                        }else {
                            writer.Write(ConvertBattleToXML.Convert(info,botId));
                        }
                    }
                    writer.Write("</Battles>");
                }else {
					writer.Write("<Battles/>");
                }
                HttpContext.Current.Response.Write(writer);
            }else{
                WriteOwnerShipError();
            }
        }


		#endregion Delegates

		#region Writers

		private static string WriteBotResult(Result result) {
			if (result.Ok) {
				return "1";
			}

			StringWriter writer = new StringWriter();
			foreach (ResultItem resultItem in result.Failed) {
				writer.WriteLine(resultItem.Log());
			}
			return string.Format("0:{0}", writer);
		}

         private void WriteOwnerShipError(){
            HttpContext.Current.Response.Write("Invalid Credentials");	
        }

		#endregion Writers

		#region Constructor

		public BattleBotActions() {
			battleId = GetId();
            if (battleId > 0 ) {
			    battleInfo = BattleUtilities.GetBattle(battleId);
            }

			actions["botdeploy"] = BotDeploy;
			actions["botbattle"] = BotBattle;
			actions["botHasBattles"] = BotHasBattles;
            actions["botGetBattles"] = BotGetBattles;
		}

		#endregion Constructor


	}
}
