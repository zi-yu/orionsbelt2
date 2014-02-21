
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace Bots {
	public static class Utils {

		#region Private

		private static readonly Random random = new Random((int)DateTime.Now.Ticks);

		#endregion Private

		#region Public

		public static string GetResponse(IAsyncResult ar) {
			HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
			return GetResponse(request);
		}

		public static string GetResponse(HttpWebRequest request) {
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			return reader.ReadToEnd();
		}

		public static List<BotCredential> GetBotCredentials() {
			List<BotCredential> handlers = HttpContext.Current.Cache["BotCredentials"] as List<BotCredential>;
			if (handlers == null) {
				using (IBotCredentialPersistance persistances = Persistance.Instance.GetBotCredentialPersistance()) {
					handlers = new List<BotCredential>(persistances.Select());
					HttpContext.Current.Cache["BotCredentials"] = handlers;
				}
			}
			return handlers;
		}

		public static List<BotHandler> GetBotHandlers() {
			List<BotHandler> handlers = HttpContext.Current.Cache["BotHandlers"] as List<BotHandler>;
			if (handlers == null) {
				using (IBotHandlerPersistance persistances = Persistance.Instance.GetBotHandlerPersistance()) {
					handlers = new List<BotHandler>(persistances.Select());
					HttpContext.Current.Cache["BotHandlers"] = handlers;
				}
			}
			return handlers;
		}

		public static BotHandler GetRandomBotHandler() {
			IList<BotHandler> handlers = GetBotHandlers();
			int idx = random.Next(0, handlers.Count);
			return handlers[idx];
		}

		public static int GetRandomCode(string botName) {
			IList<BotHandler> handlers = GetBotHandlers();
			bool notFound = true;
			while (notFound) {
				int idx = random.Next(0, handlers.Count);
				if (handlers[idx].Name.Equals(botName)){
					return handlers[idx].Code;
				}
			}
			return 0;
		}

		public static BotCredential GetBotCredentials(string botName) {
			List<BotCredential> handlers = GetBotCredentials();
			return handlers.Find(delegate(BotCredential b) { return b.Name == botName; });
		}

		public static void DeleteBotPendingRequest(string botCode, string battleId, HttpContext context) {
			using (IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance()) {
                persistance.StartTransaction();
                string query = string.Format("from SpecializedPendingBotRequest p where p.BattleId = {0} and p.Code = {1}", battleId, botCode);
                context.Response.Write("\nQuery" + query);
                int result = persistance.Delete(query);
                context.Response.Write("\nDeleted" + result + " entries");
                persistance.CommitTransaction();
			}
		}

		#endregion Public
	}
}
