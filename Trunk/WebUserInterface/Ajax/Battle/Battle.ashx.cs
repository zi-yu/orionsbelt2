using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class Battle : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["type"];
			if ( !string.IsNullOrEmpty(type)) {
				BattleActions a = new BattleActions();
				a.ProcessActions(type);
			}
            WebUtilities.RemoveHasBattles();
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
