using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Loki.DataRepresentation;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine  {
	public static class BattleManager {

		#region Bot

		private static void CallBack(IAsyncResult ar) {
		}

		private static void MakeRequest(int battleId, IBattlePlayer bot, string data) {
			string param = string.Format("botName={0}&botId={1}&battleId={2}&data={3}", bot.Owner.BotName, bot.Owner.BotId,battleId, data);
			HttpWebRequest request = (HttpWebRequest)WebRequest.CreateDefault(new Uri(bot.Owner.BotUrl));
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			byte[] formData = UTF8Encoding.UTF8.GetBytes(param);
			request.ContentLength = param.Length;

			using (Stream post = request.GetRequestStream()) {
				post.Write(formData, 0, formData.Length);
			}

			request.BeginGetResponse(CallBack, request);
		}

		private static void AlertBotToDeploy(IBattleInfo battleInfo) {
			IBattlePlayer bot = battleInfo.Players.Find(delegate(IBattlePlayer player) { return player.Owner.IsBot; });
			string data = ConvertBattleToXML.UnitToDeploy(battleInfo, bot.Owner.BotId);
			MakeRequest(battleInfo.Id, bot, data);
		}

		private static void AlertBotToPlay(IBattleInfo battleInfo) {
			string data = ConvertBattleToXML.Convert(battleInfo, battleInfo.CurrentBattlePlayer.Owner.BotId);
			MakeRequest(battleInfo.Id, battleInfo.CurrentBattlePlayer, data);
		}
		
		private static bool AnyBot(IBattleInfo battleInfo) {
			foreach(IBattlePlayer player in battleInfo.Players) {
				if( player.Owner.IsBot ) {
					return true;
				}
			}
			return false;
		}

		#endregion Bot

		#region Private

        private static void SendEndBattleMessage(IBattleInfo battleInfo) {
			List<IBattlePlayer> winners = battleInfo.GetBattlePlayerWinners();
			if (winners.Count > 0 ) {
				if( battleInfo.IsTeamBattle  ) {
					battleInfo.AddTurnMessage(new EndTeamBattleMessage(battleInfo.Id, battleInfo.CurrentTurn, winners[0].TeamName));
				}else {
					battleInfo.AddTurnMessage(new EndBattleMessage(battleInfo.Id, battleInfo.CurrentTurn, winners[0].Name));
				}
			}
        }

		private static void BattleEndResolver( IBattleInfo battleInfo ) {
			if( battleInfo.HasEnded() ) {
                SendEndBattleMessage(battleInfo);
				battleInfo.EndBattle();
				EndBattleUtils.UpdateEndBattleFleets(battleInfo);
				EndBattleUtils.ProcessRanking(battleInfo);
				EndBattleUtils.ProcessEndBattle(battleInfo);
                EndBattleUtils.SendEndBattleMessages(battleInfo);
			}
		}

		private static Result ResolveMovements( IBattleOwner current, IBattleInfo battleInfo, string movements, bool deploy ) {
			Interpreter interpreter = new Interpreter(current, battleInfo);
			Result result = interpreter.Interpretate(movements);
			if( result.Ok ) {
				if( !deploy ) {
					battleInfo.ResolveEffects();
					battleInfo.BattleFinalUpdate(movements);
					battleInfo.AddTurnMessage(new EndTurnMessage(battleInfo.Id, battleInfo.CurrentTurn, current.Name));
					BattleEndResolver(battleInfo);
					battleInfo.SetNextPlayer();
				}else {
					battleInfo.AddTurnMessage(new DeployMessage(battleInfo.Id, battleInfo.CurrentTurn, current.Name));
				}
			}
			return result;
		}

		private static Result MakeDeployMoves( IBattleOwner current, string movements, IBattleInfo battleInfo ) {
			using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance() ) {
			    persistance.StartTransaction();

				IBattlePlayer currentBattlePlayer = battleInfo.CurrentBattlePlayer;
				battleInfo.UpdateCurrentPlayer(current);

				Logger.Info(current.Name, string.Empty, LogType.Generic, "BattleId:", battleInfo.Id, "Battle Movements:", movements);
				Result r = ResolveMovements(current, battleInfo, movements, true);
				battleInfo.CurrentBattlePlayer = currentBattlePlayer;
				if (r.Ok) {
					BattlePersistance.UpdateBattle(battleInfo);
				}
				persistance.CommitTransaction();
				if ( !current.IsBot && AnyBot(battleInfo) ) {
					AlertBotToDeploy(battleInfo);
				}
				if (current.IsBot && battleInfo.CurrentBattlePlayer.Owner.Id == current.Id) {
					AlertBotToPlay(battleInfo);
				}
				return r;
			}
		}

		private static Result MakeBattleMoves( IBattleOwner current, string movements, IBattleInfo battleInfo ) {			
			if( battleInfo.HasEnded() ) {
				Logger.Info(current.Name, "Battle", "User tried to make a move at the end of the game");
				return new Result(new BattleEnded());
			}

			if( current.Id != battleInfo.CurrentBattlePlayer.Owner.Id ) {
				return new Result(new InvalidPlayerToPlay(current));
			}

			using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance()) {
				persistance.StartTransaction();
				
				Logger.Info(current.Name, string.Empty, LogType.Generic, "BattleId:", battleInfo.Id, "Battle Movements:", movements);
				Result r = ResolveMovements(current, battleInfo, movements, false);
				if (r.Ok) {
					BattlePersistance.UpdateBattle(battleInfo);
				}

				persistance.CommitTransaction();
				if (!battleInfo.HasEnded() && battleInfo.CurrentBattlePlayer.Owner.IsBot) {
					AlertBotToPlay(battleInfo);
				}
				return r;
			}
		}

		/// <summary>
		/// Resolves a Timeout when the player didn't positioned
		/// </summary>
		private static void ResolveDeployTimeout(IBattleInfo battleInfo) {
			foreach (IBattlePlayer player in battleInfo.Players) {
				int x = battleInfo.NumberOfPlayers == 2 ? 8 : 12;
				int y = battleInfo.NumberOfPlayers == 2 ? 1 : 3;
				int startY = y;
				int max = battleInfo.NumberOfPlayers == 2 ? 9 : 11;

				if (!player.HasPositioned) {
					StringBuilder builder = new StringBuilder();
					foreach (IElement element in player.InitialContainer.InitialUnits) {
						if (y == max) {
							--x;
							y = startY;
						}
						builder.AppendFormat("p:{0}-{1}_{2}-{3};", element.Unit.Code, x, y++, element.Quantity);
					}
					DeployUnits(player.Owner, builder.ToString(), battleInfo);
				}
			}
		}

		/// <summary>
		/// Choose the player to give the timeout to
		/// </summary>
		/// <param name="battleInfo">Battle Core Wrapper</param>
		/// <returns>IBattlePlayer of the player that gave the timeout</returns>
		private static IBattlePlayer GetTimeoutPlayer(IBattleInfo battleInfo) {
			if (battleInfo.IsDeployTime) {
				foreach (IBattlePlayer player in battleInfo.Players) {
					if (!player.HasPositioned) {
						return player;
					}
				}
			}
			return battleInfo.CurrentBattlePlayer;
		}

		#endregion Private

		#region Public

		#region Battle Actions

		#region Deploy Units

		/// <summary>
		/// Obtains an object that represents the battle
		/// </summary>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Object that implements IBattleInfo an represents the battle in the core</returns>
		public static IBattleInfo GetBattle( int battleId ) {
			return BattlePersistance.GetBattle(battleId);
		}

		/// <summary>
		/// Obtains an object that represents the battle
		/// </summary>
		/// <param name="battle">object that represents the battle in the Database</param>
		/// <returns>Object that implements IBattleInfo an represents the battle in the core</returns>
		public static IBattleInfo GetBattle( Battle battle ) {
			return BattlePersistance.ConvertToBattleInfo(battle);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( Principal principal, string movements, int battleId ) {
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeDeployMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IPlayer player, string movements, int battleId ) {
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeDeployMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IBattleOwner battleOwner, string movements, int battleId ) {
			return MakeDeployMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( Principal principal, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IPlayer player, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IBattleOwner battleOwner, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( Principal principal, string movements, IBattleInfo battleInfo ) {
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IPlayer player, string movements, IBattleInfo battleInfo ) {
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Positionate the units and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result DeployUnits( IBattleOwner battleOwner, string movements, IBattleInfo battleInfo ) {
			return MakeDeployMoves(battleOwner, movements, battleInfo);
		}

		#endregion Deploy Units

		#region Make Moves

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( Principal principal, string movements, int battleId ) {
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeBattleMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IPlayer player, string movements, int battleId ) {
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeBattleMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IBattleOwner battleOwner, string movements, int battleId ) {
			return MakeBattleMoves(battleOwner, movements, BattlePersistance.GetBattle(battleId));
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Object with the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( Principal principal, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Object with the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IPlayer player, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battle">Object with the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IBattleOwner battleOwner, string movements, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}
		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( Principal principal, string movements, IBattleInfo battleInfo ) {
			IBattleOwner battleOwner = BattleOwner.Get(principal);
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="player">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IPlayer player, string movements, IBattleInfo battleInfo ) {
			IBattleOwner battleOwner = BattleOwner.Get(player);
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="movements">Movements to make</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static Result MakeMoves( IBattleOwner battleOwner, string movements, IBattleInfo battleInfo ) {
			return MakeBattleMoves(battleOwner, movements, battleInfo);
		}

		#endregion Make Moves

		#region Bot

		public static void AlertBot(IBattleInfo battleInfo ) {
			if( battleInfo.IsDeployTime) {
				AlertBotToDeploy(battleInfo);
			}else {
				AlertBotToPlay(battleInfo);
			}
		}
		
		#endregion Bot

		#region Give Up

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static void GiveUp( Principal principal, int battleId ) {
			GiveUp( new PrincipalOwner(principal), battleId );
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="principal">Owner that's going to make the moves</param>
		/// <param name="battle">Object with the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static void GiveUp( Principal principal, Battle battle ) {
			GiveUp(new PrincipalOwner(principal), battle);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="battleId">Id of the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static void GiveUp( IBattleOwner battleOwner, int battleId ) {
			GiveUp( battleOwner, BattlePersistance.GetRawBattle(battleId));
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="battle">Object with the battle</param>
		/// <returns>Result object with the results of the movement</returns>
		public static void GiveUp( IBattleOwner battleOwner, Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			GiveUp(battleOwner, battleInfo);
		}

		/// <summary>
		/// Makes the movements and saves the battle in the database (if no error occurs)
		/// </summary>
		/// <param name="battleOwner">Owner that's going to make the moves</param>
		/// <param name="battleInfo">Object that represents the battle in the core</param>
		/// <returns>Result object with the results of the movement</returns>
		public static void GiveUp( IBattleOwner battleOwner, IBattleInfo battleInfo ) {
			battleInfo.GiveUp(battleOwner);
		    battleInfo.HasGiveUp = true;
			BattleEndResolver(battleInfo);
			BattlePersistance.UpdateBattle(battleInfo);
            Persistance.Flush();
		}
		
		#endregion Give Up

		#region Timeouts

		public static bool Timeout(int battleId) {
			Battle battle = BattlePersistance.GetRawBattle(battleId,false);
			return Timeout(battle);
		}

		public static bool Timeout( Battle battle ) {
			IBattleInfo battleInfo = BattlePersistance.ConvertToBattleInfo(battle);
			if( battleInfo.HasEnded() ) {
				return true;
			}

    		IBattlePlayer battlePlayer = GetTimeoutPlayer(battleInfo);
            if( battlePlayer.Owner.IsOnVacations ) {
                using (ITimedActionStoragePersistance persistance = Persistance.Instance.GetTimedActionStoragePersistance()) {

                    Logger.Info(LogType.Battle, string.Format("{0} - Extended Timeout of more 10 ticks. Battle Id: {0}; Tick {1}", battle.Id, Clock.Instance.Tick));
                    battleInfo.Battle.TimedAction[0].EndTick = (Clock.Instance.Tick + 10)*-1;
                    persistance.Update(battleInfo.Battle.TimedAction[0]);
                }
                return false;
            }

		    ++battlePlayer.Timeouts;


			if (battlePlayer.Timeouts >= battle.TimeoutsAllowed) {
				battleInfo.CurrentBattlePlayer = battlePlayer;
				ResolveDeployTimeout(battleInfo);
				battleInfo.Timeout();
				bool hasEnded = battleInfo.HasEnded();
				if (hasEnded) {
					BattleEndResolver(battleInfo);
				}
				Messenger.Add(new LastTimeoutMessage(battleInfo.Id, battleInfo.CurrentTurn, battlePlayer.Name));
				BattlePersistance.UpdateBattle(battleInfo);
                Logger.Info(LogType.Battle, string.Format("{0} - Final Timeout in battle Id {0}. Tick {1}", battle.Id, Clock.Instance.Tick));
				return hasEnded;
			}
		
			/*if( battleInfo.IsDeployTime) {
				--playerBattleInformation.Timeouts;
				Messenger.Add(new DeployTimeoutMessage(battleInfo.Id, battleInfo.CurrentTurn, playerBattleInformation.Name));
				ResolveDeployTimeout(battleInfo);
			}else{*/
			Messenger.Add(new TimeoutMessage(battleInfo.Id, battleInfo.CurrentTurn, battlePlayer.Name));
			battlePlayer.UpdatePlayerBattleInfo();
			BattlePersistance.UpdatePlayerBattleInformation(battlePlayer.PlayerBattleInformation);
            Logger.Info(LogType.Battle, string.Format("{0} - Timeout in battle Id {0}. Tick {1}", battle.Id, Clock.Instance.Tick));
			//}
			return false;
		}

		#endregion Timeouts

		#endregion Battle Actions
		
		#region Battle Creation

		/// <summary>
		/// Creates a Normal game Battle
		/// </summary>
		/// <param name="players">Players that participate in the battle</param>
		/// <param name="fleets">Fleets to enter in the battle</param>
		/// <param name="terrain">ShortType of the battle terrain</param>
		/// <returns>Id of the battle</returns>
		public static int CreateBattle(IList<IPlayer> players, IList<IFleetInfo> fleets, Terrain terrain) {
			List<IBattleOwner> owners = BattleOwner.Convert(players);
			return BattleCreator.CreateBattle(owners, fleets, terrain, false, false);
		}

		/// <summary>
		/// Creates a Normal game Battle between 2 fleets
		/// </summary>
		/// <param name="player1">Player that started the battle</param>
		/// <param name="fleet1">Fleet of the player that started the attack</param>
		/// <param name="player2">Player that is being attacked</param>
		/// <param name="fleet2">Fleet of the player that is being attacked</param>
		/// <param name="terrain"></param>
		/// <returns>Id of the battle</returns>
		public static int CreateBattleBetweenFleets(IPlayer player1, IFleetInfo fleet1, IPlayer player2, IFleetInfo fleet2, Terrain terrain) {
			return CreateBattle(player1, fleet1, player2, fleet2, terrain, false, false);
		}

		/// <summary>
		/// Creates a Normal game Battle between a fleet and a planet
		/// </summary>
		/// <param name="player1">Player that started the battle</param>
		/// <param name="fleet1">Fleet of the player that started the attack</param>
		/// <param name="player2">Player that is being attacked</param>
		/// <param name="fleet2">Fleet of the player that is being attacked</param>
		/// <param name="terrain"></param>
		/// <returns>Id of the battle</returns>
		public static int CreateBattleInPlanet(IPlayer player1, IFleetInfo fleet1, IPlayer player2, IFleetInfo fleet2, Terrain terrain, bool isToConquer) {
			return CreateBattle(player1, fleet1, player2, fleet2, terrain, isToConquer, true);
		}

		/// <summary>
		/// Creates a Normal game Battle
		/// </summary>
		/// <param name="player1">Player that started the battle</param>
		/// <param name="fleet1">Fleet of the player that started the attack</param>
		/// <param name="player2">Player that is being attacked</param>
		/// <param name="fleet2">Fleet of the player that is being attacked</param>
		/// <param name="terrain"></param>
		/// <param name="isToConquer">If the planet is to conquer</param>
		/// <param name="isInPlanet">is the battle is in a planet</param>
		/// <returns>Id of the battle</returns>
		public static int CreateBattle(IPlayer player1, IFleetInfo fleet1, IPlayer player2, IFleetInfo fleet2, Terrain terrain, bool isToConquer, bool isInPlanet) {
			if( fleet1.IsInBattle || fleet2.IsInBattle ) {
				return 0;
			}
			
			//if( fleet1.CanBattle(fleet2) ) {
				List<IPlayer> players = new List<IPlayer>();
				players.Add(player1);
				players.Add(player2);

				List<IFleetInfo> fleets = new List<IFleetInfo>();
				fleets.Add(fleet1);
				fleets.Add(fleet2);

				List<IBattleOwner> owners = BattleOwner.Convert(players);
				return BattleCreator.CreateBattle(owners, fleets, terrain, isToConquer, isInPlanet);
			//}


			//if( fleet1.IsStronger(fleet2)) {
			//    FleetPersistance.DeleteFleet(fleet2);
			//}else {
			//    FleetPersistance.DeleteFleet(fleet1);
			//}

			//return -1;
		}

		/// <summary>
		/// Creates a Friendly Battle
		/// </summary>
		/// <param name="players">Players that participate in the battle</param>
		/// <param name="units">Units in the battle</param>
		/// <param name="type">Type of the battle</param>
		/// <returns>Id of the battle</returns>
		public static int CreateFriendlyBattle( IList<Principal> players, IFleetInfo units, BattleType type ) {
			List<IBattleOwner> owners = BattleOwner.Convert(players);
			return BattleCreator.CreateFriendlyBattle(owners, units, type);
		}

        /// <summary>
        /// Creates a Friendly Battle
        /// </summary>
        /// <param name="players">Players that participate in the battle</param>
        /// <param name="units">Player 1 units in the battle</param>
        /// <param name="opponent">Opponent's Units in the battle</param>
        /// <param name="type">Type of the battle</param>
        /// <returns>Id of the battle</returns>
        public static int CreateFriendlyBattle(IList<Principal> players, IFleetInfo units, IFleetInfo opponent, BattleType type)
        {
            List<IBattleOwner> owners = BattleOwner.Convert(players);
            return BattleCreator.CreateFriendlyBattle(owners, units, opponent, type);
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
		/// <returns>Object that represents the battle</returns>
		public static Battle CreateTournamentBattle(IList<Principal> players, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, Core.Tournament tournament) {
			return CreateTournamentBattle(players, fleet, type, tournamentMode, 0, tournament);
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
        /// <param name="persistance">A persistance object</param>
        /// <returns>Object that represents the battle (need to be flush)</returns>
        public static Battle CreateTournamentBattle(IList<Principal> players, IFleetInfo fleet,
            BattleType type, TournamentMode tournamentMode, IPersistanceSession persistance, Core.Tournament tournament)
        {
            return CreateTournamentBattle(players, fleet, type, tournamentMode, 0,persistance, tournament);
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="team1">Fisrt team of players that enter in the battle</param>
		/// <param name="team2">Fisrt team of players that enter in the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, Core.Tournament tournament) {
            return CreateTournamentBattle(team1, team2, fleet, type, tournamentMode,0, tournament);
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="team1">Fisrt team of players that enter in the battle</param>
        /// <param name="team2">Fisrt team of players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
        /// <param name="persistance">A persistance object</param>
        /// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet,
            BattleType type, TournamentMode tournamentMode, IPersistanceSession persistance, Core.Tournament tournament)
        {
            return CreateTournamentBattle(team1, team2, fleet, type, tournamentMode, 0, persistance, tournament);
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(IList<Principal> players, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, double sequenceNumber, Core.Tournament tournament) {
			List<IBattleOwner> owners = BattleOwner.Convert(players);
			return BattleCreator.CreateTournamentBattle(owners, fleet, type, tournamentMode, sequenceNumber, tournament);
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="persistance">A persistance object</param>
        /// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(IList<Principal> players, IFleetInfo fleet,
            BattleType type, TournamentMode tournamentMode, double sequenceNumber, IPersistanceSession persistance, Core.Tournament tournament)
        {
            List<IBattleOwner> owners = BattleOwner.Convert(players);
            return BattleCreator.CreateTournamentBattle(owners, fleet, type, tournamentMode, sequenceNumber, persistance, tournament);
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="team1">Fisrt team of players that enter in the battle</param>
		/// <param name="team2">Fisrt team of players that enter in the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, double sequenceNumber, Core.Tournament tournament) {
			return BattleCreator.CreateTournamentBattle(team1, team2, fleet, type, tournamentMode, sequenceNumber, tournament);
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="team1">Fisrt team of players that enter in the battle</param>
        /// <param name="team2">Fisrt team of players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tourname (Normal, Ladder or Survival)</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="persistance">A persistance object</param>
        /// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet,
            BattleType type, TournamentMode tournamentMode, double sequenceNumber, IPersistanceSession persistance, Core.Tournament tournament)
        {
            return BattleCreator.CreateTournamentBattle(team1, team2, fleet, type, tournamentMode, sequenceNumber, persistance, tournament);
        }

        /// <summary>
        /// Creates a Friendly Battle
        /// </summary>
        /// <param name="players">Players that participate in the battle</param>
        /// <param name="units">Units in the battle</param>
        /// <param name="type">Type of the battle</param>
        /// <returns>Id of the battle</returns>
        public static int CreateArenaBattle(IList<IPlayer> players, IFleetInfo units, BattleType type){
            List<IBattleOwner> owners = BattleOwner.Convert(players);
            return BattleCreator.CreateArenaBattle(owners, units, type);
        }

        /// <summary>
        /// Creates a campaign battle
        /// </summary>
        /// <param name="principal">The principal</param>
        /// <param name="principalFleet">The principal's fleet</param>
        /// <param name="botName">The bot's name</param>
        /// <param name="botFleet">The bot's fleet</param>
        /// <returns>The battle</returns>
        public static Battle CreateCampaignBattle(Principal principal, string principalFleet, string botName, string botFleet, IPersistanceSession session)
        {
			List<Principal> players = new List<Principal>();
			players.Add(principal);
			players.Add(Generals.GetGeneralByName(botName));

			List<IFleetInfo> fleets = new List<IFleetInfo>();
			fleets.Add(new FleetInfo("Campaign", principal, principalFleet));
			fleets.Add(new FleetInfo("Campaign", Generals.GetGeneralByName(botName), botFleet));

			List<IBattleOwner> owners = BattleOwner.Convert(players);

        	return BattleCreator.CreateCampaignBattle(owners, fleets, BattleType.TotalAnnihalation,session);
        }

		#endregion Battle Creation

		#region Battle Utilities

		public static IBattleOwner GetBattleOwner( Principal principal ) {
			return BattleOwner.Get(principal);
		}

		public static IBattleOwner GetBattleOwner( IPlayer player ) {
			return BattleOwner.Get(player);
		}

		#endregion Battle Utilities
		
		#endregion Public

    }
}
