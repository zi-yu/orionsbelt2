using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class Quest : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["Type"];
			if (!string.IsNullOrEmpty(type)) {
				QuestsActions a = new QuestsActions();
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
