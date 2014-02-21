using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class BotBattle : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["type"];
			if (!string.IsNullOrEmpty(type)) {
				BattleBotActions a = new BattleBotActions();
				a.ProcessActions(type);
			}
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
