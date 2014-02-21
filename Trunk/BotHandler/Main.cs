using System;
using System.IO;
using System.Net;
using System.Xml.XPath;
using BotHandler.Engine;
using Mono.GetOptions;
using System.Configuration;
using Battle=BotHandler.Engine.Battle;

namespace BotHandler {
	class MainClass : Options {

		#region Main

		public static void Main(string[] args) {
			try {
				DateTime start = DateTime.Now;
				MainClass options = new MainClass();
				if (args.Length == 0) {
                    args = new string[] { "--firingSquadBeta" };
				}
				options.ProcessArgs(args);
				TimeSpan elapsed = DateTime.Now - start;
				Console.WriteLine("#Elapsed: {0} seconds", elapsed.TotalSeconds);
			} catch (Exception e) {
				Console.WriteLine(e);
			}
		}

		#endregion Main

        #region Utils

        private static System.Threading.Timer timer = null;

        [Option("Sets the max execution time", "timeout")]
        public WhatToDoNext SetTimeout(int seconds)
        {
            Console.WriteLine("Setting the max execution time to: {0} seconds at {1}", seconds, DateTime.Now);

            timer = new System.Threading.Timer(delegate(object state) {
                Console.WriteLine("*** Max execution Time reached at {0}! Shutting down...", DateTime.Now);
                Environment.Exit(1);
            }, null, seconds * 1000, System.Threading.Timeout.Infinite);

            return WhatToDoNext.GoAhead;
        }

        #endregion Utils

		#region Private

		private void GenericBotRegister(string botName) {
			HttpWebRequest request = GetRequest("RegisterBot", botName);
			HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

			string response = Utils.GetResponse(webResponse);
			if (!string.IsNullOrEmpty(response) && response.Equals("0")) {
				Console.WriteLine("Bot '{0}' Registered Successfully", botName);
			} else {
				Console.WriteLine("Bot '{0}' was already Registered", botName);
			}
		}

		private void GenericBotUnregister(string botName) {
			HttpWebRequest request = GetRequest("UnregisterBot", botName);
			HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

			string response = Utils.GetResponse(webResponse);
			if (!string.IsNullOrEmpty(response) && response.Equals("0")) {
				Console.WriteLine("Bot '{0}' Unregistered Successfully", botName);
			} else {
				Console.WriteLine("Bot '{0}' was not Registered", botName);
			}
		}

		#endregion Private

		#region Bot001

		protected static void MakeDeploy(Battle battle) {
			Bot001Deploy.Instance.MakeDeploy(battle);
		}

		protected static void MakeMoves(Battle battle) {
			Bot001Moves.Instance.MakeMoves(battle);
		}

		public void ParseResponse(WebResponse webResponse) {
            string response = Utils.GetResponse(webResponse);

			if(!string.IsNullOrEmpty(response)){
				foreach (Battle battle in Utils.GetBattle(response)) {
					if (battle.State.Equals("deploy")) {
						MakeDeploy(battle);
					}
					if (battle.State.Equals("battle")) {
						MakeMoves(battle);
					}
				}
			}
		}

		private static HttpWebRequest GetRequest(string handlerName, string botName) {
			string url = ConfigurationManager.AppSettings["url"];
			string bot001VerificationCode = ConfigurationManager.AppSettings["code"];
			string param = string.Format("{0}{2}.ashx?botName={3}&botCode={1}", url, bot001VerificationCode, handlerName, botName);

            Console.WriteLine("Getting battles via {0}...", param);
			return (HttpWebRequest)WebRequest.CreateDefault(new Uri(param));
		}

		[Option("Bot001", "bot001")]
		public WhatToDoNext Bot001() {
            HttpWebRequest request = GetRequest("GetRegisteredBattle", "Bot001");
            Console.Write("Getting Response...");
            ParseResponse(request.GetResponse());
		    return WhatToDoNext.GoAhead;
		}

		[Option("Bot001 Register", "bot001Register")]
		public WhatToDoNext Bot001Register() {
			GenericBotRegister("Bot001");
			return WhatToDoNext.GoAhead;
		}

		[Option("Bot001 Unregister", "bot001Unregister")]
		public WhatToDoNext Bot001Unregister() {
			GenericBotUnregister("Bot001");
			return WhatToDoNext.GoAhead;
		}

		#endregion Manual

		#region FiringSquad

		protected static void MakeFiringSquadDeploy(Battle battle) {
            Console.WriteLine("[FiringSquad] Calculating deploy...");
			FiringSquadDeploy.Instance.MakeDeploy(battle);
		}

		protected static void MakeFiringSquadMoves(Battle battle) {
            Console.WriteLine("[FiringSquad] Calculating moves...");
			FiringSquadMoves.Instance.MakeMoves(battle);
		}

		public void ParseFiringSquadResponse(WebResponse webResponse) {
			string response = Utils.GetResponse(webResponse);
            Console.WriteLine("Preparing response (length:{0})...", response.Length);
			if (!string.IsNullOrEmpty(response)) {
				foreach (Battle battle in Utils.GetBattle(response)) {
					if (battle.State.Equals("deploy")) {
						MakeFiringSquadDeploy(battle);
					}
					if (battle.State.Equals("battle")) {
						MakeFiringSquadMoves(battle);
					}
				}
			}
		}

		[Option("FiringSquad", "firingSquad")]
		public WhatToDoNext FiringSquad() {
			HttpWebRequest request = GetRequest("GetRegisteredBattle", "FiringSquad");
			ParseFiringSquadResponse(request.GetResponse());
			return WhatToDoNext.GoAhead;
		}

		[Option("FiringSquad Register", "firingSquadRegister")]
		public WhatToDoNext FiringSquadRegister() {
			GenericBotRegister("FiringSquad");
			return WhatToDoNext.GoAhead;
		}

		[Option("FiringSquad Unregister", "firingSquadUnregister")]
		public WhatToDoNext FiringSquadUnregister() {
			GenericBotUnregister("FiringSquad");
			return WhatToDoNext.GoAhead;
		}

		#endregion Firing Squad

		#region FiringSquad Beta

		protected static void MakeFiringSquadBetaDeploy(Battle battle) {
			Console.WriteLine("[FiringSquadBeta] Calculating deploy...");
			FiringSquadBetaDeploy.Instance.MakeDeploy(battle);
		}

		protected static void MakeFiringSquadBetaMoves(Battle battle) {
			Console.WriteLine("[FiringSquadBeta] Calculating moves...");
			FiringSquadBetaMoves.Instance.MakeMoves(battle);
		}

		public void ParseFiringSquadBetaResponse(WebResponse webResponse) {
			string response = Utils.GetResponse(webResponse);
			Console.WriteLine("Preparing response (length:{0})...", response.Length);
			if (!string.IsNullOrEmpty(response)) {
				foreach (Battle battle in Utils.GetBattle(response)) {
					if (battle.State.Equals("deploy")) {
						MakeFiringSquadBetaDeploy(battle);
					}
					if (battle.State.Equals("battle")) {
						MakeFiringSquadBetaMoves(battle);
					}
				}
			}
		}

		[Option("FiringSquad", "firingSquadBeta")]
		public WhatToDoNext FiringSquadBeta() {
			HttpWebRequest request = GetRequest("GetRegisteredBattle", "FiringSquadBeta");
			ParseFiringSquadBetaResponse(request.GetResponse());
			return WhatToDoNext.GoAhead;
		}

		[Option("FiringSquadBeta Register", "firingSquadBetaRegister")]
		public WhatToDoNext FiringSquadBetaRegister() {
			GenericBotRegister("FiringSquadBeta");
			return WhatToDoNext.GoAhead;
		}

		[Option("FiringSquadBeta Unregister", "firingSquadBetaUnregister")]
		public WhatToDoNext FiringSquadBetaUnregister() {
			GenericBotUnregister("FiringSquadBeta");
			return WhatToDoNext.GoAhead;
		}

		#endregion Firing Squad

		#region Pool Servers

		[Option("Pool Servers", "poolServers")]
		public WhatToDoNext PollServers() {
			string url = ConfigurationManager.AppSettings["url"];
			string param = string.Format("{0}PoolServers.ashx", url);
            Console.Write("Pooling {0}... ", param);
			HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(param));
			request.GetResponse();
            Console.Write("Done");
			return WhatToDoNext.GoAhead;
		}

		#endregion Pool Servers

		#region MyRegion

		public void ParseResponse(string response) {
			if (!string.IsNullOrEmpty(response)) {
				XPathNavigator nav = Utils.GetNavigator(response);
				XPathNodeIterator n = nav.Select("Battle");
				n.MoveNext();
				Battle battle = new Battle(n);

				if (battle.State.Equals("battle")) {
					SimpleElement[,] start = battle.GetSimpleRepresentation();
					Bot001Calculator movesCalculator = new Bot001Calculator(battle.Turn, battle.Terrain);
					Console.WriteLine(movesCalculator.Calculate(start));
				}
			}
		}

		[Option("Bot001 Mono Test", "bot001Test")]
		public WhatToDoNext Bot001FileTest() {
			ParseResponse(LoadFile());
			return WhatToDoNext.GoAhead;
		}

		private static string LoadFile() {
			StreamReader reader = new StreamReader("test.xml");
			return reader.ReadToEnd();
		}

		#endregion

	}
}
