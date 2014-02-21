using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.SessionState;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace Bots {

	public class GetRegisteredBattle : IHttpHandler, IRequiresSessionState {

		#region Private

		private static IList<PendingBotRequest> GetPendingBotRequest(string botName, string verificationCode) {
			using (IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance()) {
				IList<PendingBotRequest> pendingBotRequests = persistance.TypedQuery("select p from SpecializedPendingBotRequest p where p.Code = '{0}' and p.BotName = '{1}'", verificationCode, botName);
				if (pendingBotRequests.Count > 0) {
					return pendingBotRequests;
				}
			}
			return null;
		}

		#endregion Private

		public void ProcessRequest(HttpContext context) {
			string botCode = context.Request.QueryString["botCode"];
			string botName = context.Request.QueryString["botName"];

			if( !string.IsNullOrEmpty(botName) ) {
				IList<PendingBotRequest> pendingBotRequests = GetPendingBotRequest(botName, botCode);
				if( pendingBotRequests!= null) {
					StringWriter writer = new StringWriter();
					writer.Write("<Battles>");
					foreach (PendingBotRequest request in pendingBotRequests) {
						writer.Write(request.Xml);
					}
					writer.Write("</Battles>");
					context.Response.Write(writer.ToString());
				}
			}
			context.Response.Write(string.Empty);
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
