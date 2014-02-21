using System;
using System.Net;
using System.Web;
using System.Web.SessionState;
using OrionsBelt.Core;

namespace Bots {

	public class ResponseProxy : IHttpHandler, IRequiresSessionState {

		#region Fields

		private static readonly char[] separator = new char[]{':'};

		#endregion Fields

		#region Inner Class

		struct CallBackInfo {
			public readonly HttpWebRequest Request;
			public readonly string BotCode;
			public readonly string BattleId;
			public readonly HttpContext Context;


			public CallBackInfo(HttpWebRequest request, string botCode, string battleId, HttpContext context) {
				Request = request;
				BotCode = botCode;
				BattleId = battleId;
				Context = context;
			}
		}

		#endregion Inner Class

		#region Private

		//private static void CallBack(IAsyncResult result) {
        private static void CallBack(CallBackInfo callBackInfo){
			//CallBackInfo callBackInfo = (CallBackInfo)result.AsyncState;
			string response = Utils.GetResponse(callBackInfo.Request);
			string[] splitedResponse = response.Split(separator);
            callBackInfo.Context.Response.Write("Response:" + response);
			if( splitedResponse[0].Equals("0") ) {
				//delete da entrada	
				Utils.DeleteBotPendingRequest(callBackInfo.BotCode, callBackInfo.BattleId, callBackInfo.Context);
				callBackInfo.Context.Response.Write("Entry deleted");
			}else {
				callBackInfo.Context.Response.Write("Entry NOT deleted");
			}
		}

		#endregion Private

		#region Public

		public void ProcessRequest(HttpContext context) {
			string type = context.Request.QueryString["type"];
			string moves = context.Request.QueryString["moves"];
			string responseUrl = context.Request.QueryString["responseUrl"];
			string botName = context.Request.QueryString["botName"];
			string botCode = context.Request.QueryString["botCode"];
			string battleId = context.Request.QueryString["id"];
			BotCredential credential = Utils.GetBotCredentials(botName);

			string url = string.Format("{0}?id={5}&type={1}&moves={2}&botId={3}&verificationCode={4}", responseUrl, type, moves, credential.BotId, credential.VerificationCode, battleId);
			context.Response.Write("URL:" + url);
			HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
            CallBack(new CallBackInfo(request, botCode, battleId, context));
			//request.BeginGetResponse(CallBack, new CallBackInfo(request, botCode, battleId,context));
		}

		public bool IsReusable {
			get {
				return true;
			}
		}

		#endregion Public
	}
}
