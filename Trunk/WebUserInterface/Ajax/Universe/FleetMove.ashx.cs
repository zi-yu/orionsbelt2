using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Universe {

	public class FleetMove : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["Type"];
			if (!string.IsNullOrEmpty(type)) {
				FleetMoveActions a = new FleetMoveActions();
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
