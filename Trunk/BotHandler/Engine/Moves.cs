using System;
using System.Configuration;
using System.Net;

namespace BotHandler.Engine {
	public abstract class Moves {

		#region Fields

		protected string botName;

		#endregion Fields

		#region Private

        protected virtual void MakeMoves(Battle battle, string moves){
			//string param = string.Format("{4}?type=botbattle&id={0}&moves={1}&botId={2}&verificationCode={3}", battle.Id, moves, battle.CurrentPlayerOwnerId, Utils.Bot001VerificationCode,battle.ResponseUrl);

			string url = string.Format("{0}ResponseProxy.ashx?type=botbattle&id={1}&moves={2}&botId={3}&responseUrl={4}&botCode={5}&botName={6}", ConfigurationManager.AppSettings["url"], battle.Id, moves, battle.CurrentPlayerOwnerId, battle.ResponseUrl, ConfigurationManager.AppSettings["code"], botName);

            Console.WriteLine("--");
            Console.WriteLine("Sending moves to {0}...", url);
			HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(url));
			HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            Console.WriteLine("Response:");
            Console.WriteLine(Utils.GetResponse(response));

		}

		#endregion Private

		#region Public

	    public abstract void MakeMoves(Battle battle);

		#endregion Public

    }
}
