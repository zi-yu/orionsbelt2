using System.Web;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax {

	public class Fleet : IHttpHandler, IRequiresSessionState {

		public void ProcessRequest(HttpContext context) {
            if (WebUtilities.HasBattles && WebUtilities.HasUniverseBattles) {
                return;
            }
            string type = context.Request.QueryString["Type"];
            if (!string.IsNullOrEmpty(type)) {
                FleetActions a = new FleetActions();
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
