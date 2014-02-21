using System;
using System.Configuration;
using System.Net;

namespace BotHandler.Engine {
	public abstract class Deploy{

		#region Fields

		protected string botName;

		#endregion Fields

		#region Private

		protected virtual void MakeDeploy(Battle battle, string deploy) {
			string url = string.Format("{0}ResponseProxy.ashx?type=botdeploy&id={1}&moves={2}&botId={3}&responseUrl={4}&botCode={5}&botName={6}", ConfigurationManager.AppSettings["url"], battle.Id, deploy, battle.CurrentPlayerOwnerBotId, battle.ResponseUrl, ConfigurationManager.AppSettings["code"], botName);

            Console.WriteLine("Sending moves to {0}...", url);
			HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine("Response:");
            Console.WriteLine(Utils.GetResponse(response));
		}

		#endregion Private

		#region Public

	    public abstract void MakeDeploy(Battle battle);
			
		#endregion Public

    }
}
