using System.Collections;
using System.Web;
using System.Web.SessionState;
using OrionsBelt.DataAccessLayer;

namespace Bots {
	public class UnregisterBot : IHttpHandler, IRequiresSessionState {
		public void ProcessRequest(HttpContext context) {
			string botName = context.Request.QueryString["botName"];
			int botCode = int.Parse(context.Request.QueryString["botCode"]);

			using (IBotHandlerPersistance persistance = Persistance.Instance.GetBotHandlerPersistance()) {
				IList results = persistance.Query("select b from SpecializedBotHandler b where b.Name = '{0}' and b.Code = {1} ", botName, botCode);
				if (results.Count == 1) {
					persistance.Delete("from SpecializedBotHandler b where b.Name = '{0}' and b.Code = {1}", botName, botCode);
					persistance.Flush();
					context.Response.Write("0");
				}else {
					context.Response.Write("1");
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
