using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class Forum : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
            string type = context.Request.QueryString["Type"];
            if (!string.IsNullOrEmpty(type)) {
                ForumActions.ProcessActions(type);
                return;
            }
            type = context.Request.Form["Type"];
            if (!string.IsNullOrEmpty(type)) {
                ForumActions.ProcessActions(type);
            }
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}

}
