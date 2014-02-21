using System;
using System.IO;
using System.Net;
using System.Web;
using System.Web.SessionState;
using System.Xml.XPath;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;

namespace Bots {

	public class PoolServers : IHttpHandler, IRequiresSessionState {

		#region Fields

        StringWriter writer = new StringWriter();		
				
		#endregion Fields

		#region Inner Class

		private class CallBackInfo {
			public readonly HttpWebRequest Request;
			public readonly BotHandler BotHandler;
			public readonly BotCredential BotCredential;
			public CallBackInfo(HttpWebRequest request, BotHandler botHandler, BotCredential botCredential) {
				Request = request;
				BotHandler = botHandler;
				BotCredential = botCredential;
			}
		}

		#endregion

		#region Private

		private static bool IsBattleRegistered(IPendingBotRequestPersistance persistance, int battleId) {
			IList<PendingBotRequest> list = persistance.SelectByBattleId(battleId);
			return list.Count > 0;
		}

		public static string GetResponse(IAsyncResult ar) {
			HttpWebRequest request = (HttpWebRequest)ar.AsyncState;
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();
			StreamReader reader = new StreamReader(response.GetResponseStream());
			return reader.ReadToEnd();
		}

		public static XPathNavigator GetNavigator(string data) {
			StringReader reader = new StringReader(data);
			XPathDocument doc = new XPathDocument(reader);
			return doc.CreateNavigator();
		}

        private void RegisterResponse(string response, CallBackInfo callBackInfo){
            writer.WriteLine(response);
            XPathNavigator nav = GetNavigator(response);
			XPathNodeIterator iter = nav.Select("Battles/Battle");
			using (IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance()) {
				while (iter.MoveNext()) {
					int battleId = int.Parse(iter.Current.GetAttribute("id", string.Empty));
					if (!IsBattleRegistered(persistance, battleId)) {
						string botName = iter.Current.GetAttribute("botName", string.Empty);
						string xml = iter.Current.OuterXml;
						PendingBotRequest p = persistance.Create();
						p.BotName = botName;
						p.BattleId = battleId;
                        p.BotId = callBackInfo.BotCredential.BotId;
                        p.Code = callBackInfo.BotHandler.Code;
						p.Xml = xml;
						persistance.Update(p);
					} else {
						Console.WriteLine("\t>>Battle {0} already registered", battleId);
					}
				}
					
				persistance.Flush();
			}
		}

		//private static void CallBack(IAsyncResult result) {
        private void CallBack(CallBackInfo callBackInfo){
			//CallBackInfo callBackInfo = (CallBackInfo)result.AsyncState;
			string response = Utils.GetResponse(callBackInfo.Request);

			RegisterResponse(response, callBackInfo);
		}

		#endregion

		public void ProcessRequest(HttpContext context) {
			using(IPendingBotRequestPersistance persistance = Persistance.Instance.GetPendingBotRequestPersistance()) {
				persistance.DeleteAll();
				persistance.Flush();

			}

			foreach (BotCredential bot in Utils.GetBotCredentials()) {
                string url = string.Format("{2}Ajax/Battle/BotBattle.ashx?type=botGetBattles&botId={0}&verificationCode={1}", bot.BotId, bot.VerificationCode, bot.Server);
				HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
                //request.BeginGetResponse(CallBack, new CallBackInfo(request, Utils.GetRandomBotHandler(), bot));
			    CallBack(new CallBackInfo(request, Utils.GetRandomBotHandler(),bot));
                context.Response.Write(writer.ToString());
			}
		}

		public bool IsReusable {
			get {
				return true;
			}
		}
	}
}
