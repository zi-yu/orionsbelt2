using System;
using System.Collections.Generic;
using System.Web;
using System.Web.SessionState;

using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Collections;

namespace Bots {
	
	public class RegisterBattle : IHttpHandler, IRequiresSessionState {
		public void ProcessRequest(HttpContext context) {
			string botName = context.Request.Form["botName"];
			int botId = int.Parse(context.Request.Form["botId"]);
			int battleId = int.Parse(context.Request.Form["battleId"]);
			string xml = context.Request.Form["data"];

			using( IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance() ) {
                IList results = persistance.Query("select p from SpecializedPendingBotRequest p where p.BattleId = {0} and p.BotName = '{1}' and botId = {2}", battleId, botName, botId);
                if( results.Count == 0 ){ 
                    persistance.StartTransaction();
				    PendingBotRequest p = persistance.Create();
				    p.BotName = botName;
				    p.BotId = botId;
				    p.BattleId = battleId;
				    p.Code = Utils.GetRandomCode(botName);
				    p.Xml = xml;
				    persistance.Update(p);
				    persistance.CommitTransaction();
                }
			}
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
