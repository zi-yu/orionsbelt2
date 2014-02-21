using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Universe {

	public class Universe : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["Type"];
			if (!string.IsNullOrEmpty(type)) {
				UniverseActions a = new UniverseActions();
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
