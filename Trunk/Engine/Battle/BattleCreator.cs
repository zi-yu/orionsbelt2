using System;
using System.Collections.Generic;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.Engine {
	internal static class BattleCreator {

		#region Fields

		private static readonly Random random = new Random((int) DateTime.Now.Ticks);
		private static readonly Terrain[] terrains = new Terrain[] { Terrain.Desert, Terrain.Forest, Terrain.Ice, Terrain.Rock, Terrain.Terrest, Terrain.Water };
		private static readonly TimeSpan defaultTimespan = TimeSpan.FromDays(1);
		private static readonly int defaultTimeouts = 3;

		#endregion Fields

		#region Properties

		public static TimeSpan DefaultTimespan{
			get { return defaultTimespan; }
		}

		#endregion Properties

		#region Utils

		/// <summary>
		/// Get's a number between 0 and numberOfPlayers-1 that represents the first player to play
		/// </summary>
		/// <param name="numberOfPlayers">Number of players in the battle</param>
		/// <returns>A number between 0 and numberOfPlayers-1</returns>
		private static int GetRandomPlayer( int numberOfPlayers ) {
			return random.Next(0, numberOfPlayers);
		}

		/// <summary>
		/// Gets the Id of the player that will start playing the game
		/// </summary>
		/// <param name="team1">Team 1 of Players that will enter the battle</param>
		/// <param name="team2">Team 2 of Players that will enter the battle</param>
		/// <returns></returns>
        private static Principal GetRandomPlayer(TeamStorage team1, TeamStorage team2)
        {
			
            if(team1 == null)
			{
			    return team2.Principals[0];
			}

            if (team2 == null)
            {
                return team1.Principals[0];
            }

            int i = GetRandomPlayer(team1.Principals.Count + team2.Principals.Count);
			if( i > 1 ) {
                return team2.Principals[i - 2];
			}

            return team1.Principals[i];
		}

		/// <summary>
		/// Gets a list with the same fleet in each position
		/// </summary>
		/// <param name="numberOfPlayers">number of times the fleet must be added</param>
		/// <param name="fleet">Fleet to add</param>
		/// <returns>List with all the fleets</returns>
		private static List<Fleet> GetStaticFleetList( int numberOfPlayers, Fleet fleet ) {
			List<Fleet> fleets = new List<Fleet>();
			for( int i = 0; i < numberOfPlayers; ++i ) {
				fleets.Add(fleet);
			}
			return fleets;
		}

        /// <summary>
        /// Gets a list with the same fleet in each position
        /// </summary>
        /// <param name="fleet">Fleet to add</param>
        /// <param name="opponent">Opponent fleet to add</param>
        /// <returns>List with all the fleets</returns>
        private static List<Fleet> GetStaticFleetList( Fleet fleet, Fleet opponent)
        {
            List<Fleet> fleets = new List<Fleet>();
            fleets.Add(opponent);
            fleets.Add(fleet);
            return fleets;
        }

		/// <summary>
		/// Creates a List of Fleet objects based on the passed FleetInfo
		/// </summary>
		/// <param name="fleet">FleetInfo with the information of the fleet</param>
		/// <param name="numberOfPlayers">Number of players in the battle</param>
		/// <param name="updateFleet"> If the fleet is to be updated during the battle</param>
		/// <returns>List with all the Fleet objects</returns>
		private static List<Fleet> CreateAndGetFleetList( IFleetInfo fleet, int numberOfPlayers, bool updateFleet ) {
			if (fleet.IsDirty) {
				fleet.PrepareStorage();
				fleet.UpdateStorage();
			}
			Fleet f = fleet.Storage;
			if( updateFleet ) {
				CreateFleet(f);
			}
			return GetStaticFleetList(numberOfPlayers, f);
        }

        /// <summary>
        /// Creates a List of Fleet objects based on the passed FleetInfo
        /// </summary>
        /// <param name="fleet">Player 1 units in the battle</param>
        /// <param name="opponent">Opponent's Units in the battle</param>
        /// <param name="updateFleet"> If the fleet is to be updated during the battle</param>
        /// <returns>List with all the Fleet objects</returns>
        private static List<Fleet> CreateAndGetFleetList(IFleetInfo fleet, IFleetInfo opponent, bool updateFleet)
        {
            if (fleet.IsDirty)
            {
                fleet.PrepareStorage();
                fleet.UpdateStorage();
            }
            Fleet f = fleet.Storage;
            if (updateFleet)
            {
                CreateFleet(f);
            }

            if (opponent.IsDirty)
            {
                opponent.PrepareStorage();
                opponent.UpdateStorage();
            }
            Fleet f2 = opponent.Storage;
            if (updateFleet)
            {
                CreateFleet(f2);
            }
            return GetStaticFleetList(f,f2);
        }

        /// <summary>
		/// Creates a List of Fleet objects based on the passed List of FleetInfos
		/// </summary>
		/// <param name="fleetInfos"> LFleetInfo with the information of the fleet</param>
		/// <param name="updateFleet"> If the fleet is to be updated during the battle</param>
		/// <returns>List with all the Fleet objects</returns>
		private static List<Fleet> CreateAndGetFleetList( IEnumerable<IFleetInfo> fleetInfos, bool updateFleet  ) {
			List<Fleet> fleets = new List<Fleet>();
			foreach( IFleetInfo info in fleetInfos ) {
				if( info.IsDirty) {
					info.PrepareStorage();
					info.UpdateStorage();
				}
				Fleet f = info.Storage;
				if( updateFleet ) {
					CreateFleet(f);
				}
				fleets.Add(f);
			}
			return fleets;
		}

        private static List<Fleet> GetFleetList(IEnumerable<IFleetInfo> fleetInfos) {
			List<Fleet> fleets = new List<Fleet>();
			foreach( IFleetInfo info in fleetInfos ) {
				if (info.IsDirty) {
					info.PrepareStorage();
					info.UpdateStorage();
				}
				fleets.Add(info.Storage);
			}
			return fleets;
		}


		#endregion Utils

		#region Database Creation

		/// <summary>
		/// Creates a fleet for the battle
		/// </summary>
		/// <param name="fleet">Fleet to create</param>
		/// <returns>Object that represents the fleet in the database</returns>
		private static void CreateFleet( Fleet fleet ) {
			using( IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance() ) {
				persistance.Update(fleet);
			}
		}

        /// <summary>
        /// Fills the Batte information of one player
        /// </summary>
        /// <param name="battle">Object that represents the battle in the database</param>
        /// <param name="team"></param>
        /// <param name="fleets">Fleet of the owner</param>
        /// <param name="updateFleet">
        /// true if the fleet is to be updated in the end of the battle. 
        /// Tournament and friendly fleet are not updated, so this value must be false
        /// </param>
        /// <param name="teamNumber">Number of the team</param>
        private static void FillBattlePlayerInformation(Battle battle, TeamStorage team, IList<Fleet> fleets, bool updateFleet, int teamNumber) {
            for (int i = 0; i < team.Principals.Count; ++i) {
                IBattleOwner owner = new PrincipalOwner(team.Principals[i]);
                FillBattlePlayerInformation(battle, owner, fleets[i], teamNumber, updateFleet, team.Name);
            }
        }

        /// <summary>
        /// Fills the Batte information of one player
        /// </summary>
        /// <param name="battle">Object that represents the battle in the database</param>
        /// <param name="owner">Owner of this battle Information</param>
        /// <param name="fleet">Fleet of the owner</param>
        /// <param name="teamNumber">id of the team</param>
        /// <param name="updateFleet">
        /// true if the fleet is to be updated in the end of the battle. 
        /// Tournament and friendly fleet are not updated, so this value must be false
        /// </param>
        private static void FillBattlePlayerInformation(Battle battle, IBattleOwner owner, Fleet fleet, int teamNumber, bool updateFleet) {
            FillBattlePlayerInformation(battle, owner, fleet, teamNumber, updateFleet, string.Empty);
        }

		/// <summary>
		/// Fills the Batte information of one player
		/// </summary>
		/// <param name="battle">Object that represents the battle in the database</param>
		/// <param name="owner">Owner of this battle Information</param>
		/// <param name="fleet">Fleet of the owner</param>
		/// <param name="teamNumber">Id of the team</param>
		/// <param name="updateFleet">
		/// true if the fleet is to be updated in the end of the battle. 
		/// Tournament and friendly fleet are not updated, so this value must be false
		/// </param>
        /// <param name="teamName">Name of the team</param>
		private static void FillBattlePlayerInformation( Battle battle, IBattleOwner owner, Fleet fleet, int teamNumber, bool updateFleet, string teamName ) {
			using( IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance() ) {
				PlayerBattleInformation playerBattleInformation = persistance.Create();
				playerBattleInformation.InitialContainer = fleet.Units;
				playerBattleInformation.Battle = battle;
				playerBattleInformation.HasPositioned = false;
				playerBattleInformation.HasLost = false;
				playerBattleInformation.HasGaveUp = false;
				playerBattleInformation.TeamNumber = teamNumber;
				playerBattleInformation.Owner = owner.Id;
				playerBattleInformation.UpdateFleet = updateFleet;
				playerBattleInformation.FleetId = fleet.Id;
			    playerBattleInformation.Name = owner.Name;
			    playerBattleInformation.TeamName = teamName;
				playerBattleInformation.UltimateUnit = fleet.UltimateUnit;

				if (!battle.BattleMode.Equals(BattleMode.Tournament)) {
					playerBattleInformation.BotId = owner.BotId;
				}

				battle.TimeoutsAllowed = defaultTimeouts;
				
				battle.PlayerInformation.Add(playerBattleInformation);

				persistance.Update(playerBattleInformation);
			}
		}

        private static bool CheckVacations(IList<IBattleOwner> players){
            foreach (IBattleOwner player in players){
                if (player.IsOnVacations) {
                    return true;
                }
            }
            return false;
        }

        private static bool CheckVacations(IList<Principal> principals){
            foreach (Principal principal in principals){
                if (principal.VacationStartTick > 0) {
                    return true;
                }
            }
            return false;
        }

		private static void CreateAction( Battle battle, bool someoneOnVacation, int ticks ) {
            BattleTimeout timeout = ActionUtils.RegisterBattleTimeout(battle.Id, ticks);
            if (someoneOnVacation) {
                timeout.EndTick = -timeout.EndTick;
            }
            timeout.PrepareStorage();
			timeout.UpdateStorage();
			battle.TimedAction.Add(timeout.Storage);
			timeout.Storage.Battle = battle;
		}

		/// <summary>
		/// Create a new battle extension
		/// </summary>
		/// <param name="battle"></param>
		private static void FillBattleExtension( Battle battle ) {
			using( IBattleExtentionPersistance persistance = Persistance.Instance.GetBattleExtentionPersistance() ) {
				BattleExtention extension = persistance.Create();
				extension.BattleFinalStates = string.Empty;
				extension.BattleMovements = string.Empty;

				battle.BattleExtension.Add(extension);
				extension.Battle = battle;

				persistance.Update(extension);
			}
		}


		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="players">Players in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">ShortType of the batle</param>
		/// <param name="mode">Mode of the battle (Friendly, Tournament, Battle)</param>
		/// <param name="updateFleet">if the fleet is updated in the end of the battle</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateBattle( IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type, BattleMode mode, bool updateFleet ) {
			Terrain terrain = terrains[random.Next(0, 6)];
			return CreateBattle(players, fleets, type, mode, updateFleet, terrain, false, false);
		}

		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="players">Players in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">Type of the batle</param>
		/// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
		/// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
		/// <param name="session">Session</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateBattle(IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type, BattleMode mode, bool updateFleet, IPersistanceSession session) {		
			Terrain terrain = terrains[random.Next(0, 6)];
			return CreateBattle(players, fleets, type, mode, string.Empty, false, terrain, 0, false, false, session);
		}


		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="players">Players in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">Type of the batle</param>
		/// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
		/// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
		/// <param name="terrain">Terrain used in the battle</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateBattle(IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type, BattleMode mode, bool updateFleet, Terrain terrain, bool isToConquer, bool isInPlanet) {
			return CreateBattle(players, fleets, type, mode, string.Empty, updateFleet, terrain, 0, isToConquer, isInPlanet);
		}


		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="players">Players in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">Type of the batle</param>
		/// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="updateFleet">if the fleet is updated in the end of the battle</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="persistance">A persistance object</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateTournamentBattle(IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type,
            BattleMode mode, TournamentMode tournamentMode, bool updateFleet, double sequenceNumber, IPersistanceSession persistance, Core.Tournament tournament)
        {
			Terrain terrain = terrains[random.Next(0, 6)];
			return CreateBattle(players, fleets, type, mode, tournamentMode.ToString(), updateFleet, terrain, sequenceNumber, false, false,persistance);
		}

        /// <summary>
        /// Creates a Battle
        /// </summary>
        /// <param name="players">Players in the battle</param>
        /// <param name="fleets">Fleets in the battle</param>
        /// <param name="type">Type of the batle</param>
        /// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
        /// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
        /// <param name="updateFleet">if the fleet is updated in the end of the battle</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <returns>The object that represents the battle in the database</returns>
        private static Battle CreateTournamentBattle(IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type,
            BattleMode mode, TournamentMode tournamentMode, bool updateFleet, double sequenceNumber, Core.Tournament tournament)
        {
            Terrain terrain = terrains[random.Next(0, 6)];
            return CreateBattle(players, fleets, type, mode, tournamentMode.ToString(), updateFleet, terrain, sequenceNumber, false, false);
        }

		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="players">Players in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">Type of the batle</param>
		/// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
		/// <param name="terrain">Terrain used in the battle</param>
		/// <param name="sequenceNumber">Tournament sequence number</param>
        /// <param name="sessionPersistance">A persistance object</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateBattle( IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type, BattleMode mode, 
            string tournamentMode, bool updateFleet, Terrain terrain, double sequenceNumber, bool isToConquer, bool isInPlanet,
            IPersistanceSession sessionPersistance) 
        {
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance(sessionPersistance) ) {
				Battle battle = persistance.Create();
                
				battle.PlayerInformation = new List<PlayerBattleInformation>();

				IBattleOwner player = players[GetRandomPlayer(players.Count)];
				battle.CurrentPlayer = player.Id;
				if (mode != BattleMode.Tournament) {
					battle.CurrentBot = player.BotId;
				}
				battle.CurrentTurn = 1;
				battle.HasEnded = false;
				battle.IsDeployTime = true;
				battle.IsToConquer = isToConquer;
				battle.IsInPlanet = isInPlanet;
				battle.BattleType = type.ToString();
				battle.BattleMode = mode.ToString();
				battle.Terrain = terrain.ToString();
				battle.TournamentMode = tournamentMode;
				battle.SeqNumber = sequenceNumber;
				battle.TimeoutsAllowed = defaultTimeouts;

				persistance.Update(battle);

				for( int i = 0; i < players.Count; ++i ) {
					FillBattlePlayerInformation(battle, players[i], fleets[i], i + 1, updateFleet);
				}

                CreateAction(battle, CheckVacations(players), Clock.Instance.ConvertToTicks(DefaultTimespan));

				FillBattleExtension(battle);

				return battle;
			}
		}

        /// <summary>
        /// Creates a Battle
        /// </summary>
        /// <param name="players">Players in the battle</param>
        /// <param name="fleets">Fleets in the battle</param>
        /// <param name="type">Type of the batle</param>
        /// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
        /// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
        /// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
        /// <param name="terrain">Terrain used in the battle</param>
        /// <param name="sequenceNumber">Tournament sequence number</param>
        /// <returns>The object that represents the battle in the database</returns>
        private static Battle CreateBattle(IList<IBattleOwner> players, IList<Fleet> fleets, BattleType type, BattleMode mode, string tournamentMode, bool updateFleet, Terrain terrain, double sequenceNumber, bool isToConquer, bool isInPlanet){
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()){
                Battle battle = CreateBattle(players, fleets, type, mode, tournamentMode, updateFleet, terrain, sequenceNumber, isToConquer, isInPlanet, persistance);
                if(!Server.IsChronos){
					persistance.Flush();
				}
                return battle;
            }
        }

		/// <summary>
		/// Creates a Battle
		/// </summary>
		/// <param name="team1">Team 1 of Players that enter in the battle</param>
		/// <param name="team2">Team 2 of Players that enter in the battle</param>
		/// <param name="fleets">Fleets in the battle</param>
		/// <param name="type">Type of the batle</param>
		/// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="tournament">Tournament associated</param>
		/// <returns>The object that represents the battle in the database</returns>
		private static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IList<Fleet> fleets, BattleType type, 
            BattleMode mode, TournamentMode tournamentMode, bool updateFleet, double sequenceNumber,Core.Tournament tournament) 
        {
			Terrain terrain = terrains[random.Next(0, 6)];
			using( IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance() ) {
                Battle battle = CreateTournamentBattle(team1, team2, fleets, type, mode, tournamentMode, updateFleet, sequenceNumber, persistance, tournament);
				if (!Server.IsChronos) {
					persistance.Flush();
				}
				return battle;
			}
		}

        /// <summary>
        /// Creates a Battle
        /// </summary>
        /// <param name="team1">Team 1 of Players that enter in the battle</param>
        /// <param name="team2">Team 2 of Players that enter in the battle</param>
        /// <param name="fleets">Fleets in the battle</param>
        /// <param name="type">Type of the batle</param>
        /// <param name="mode">Mode of the battle (Frindly, Tournament, Battle)</param>
        /// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
        /// <param name="updateFleet">If the fleet is updated in the end of the battle</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="session">A persistance session</param>
        /// <returns>The object that represents the battle in the database</returns>
        private static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, 
            IList<Fleet> fleets, BattleType type, BattleMode mode, TournamentMode tournamentMode,
            bool updateFleet, double sequenceNumber, IPersistanceSession session, Core.Tournament tournament)
        {
            Terrain terrain = terrains[random.Next(0, 6)];
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance(session))
            {
                Battle battle = persistance.Create();

                battle.PlayerInformation = new List<PlayerBattleInformation>();
                Principal p = GetRandomPlayer(team1, team2);
            	battle.CurrentPlayer = p.Id;
				if(p.IsBot) {
					battle.CurrentBot = p.Id;
				}

                battle.CurrentTurn = 1;
                battle.HasEnded = false;
                battle.IsDeployTime = true;
                battle.IsTeamBattle = true;
                battle.IsToConquer = false;
                battle.IsInPlanet = false;
                battle.BattleType = type.ToString();
                battle.BattleMode = mode.ToString();
                battle.Terrain = terrain.ToString();
                battle.TournamentMode = tournamentMode.ToString();
                battle.SeqNumber = sequenceNumber;
                battle.TimeoutsAllowed = defaultTimeouts;

                persistance.Update(battle);
                bool vacations = false;
                if (team1 != null)
                {
                    FillBattlePlayerInformation(battle, team1, fleets, updateFleet, 1);

                    vacations |= CheckVacations(team1.Principals);
                }
                if (team2 != null)
                {
                    FillBattlePlayerInformation(battle, team2, fleets, updateFleet, 2);
                    vacations |= CheckVacations(team2.Principals);
                }

                FillBattleExtension(battle);

                int ticks;
                if (tournament != null && tournament.TurnTime > 0) {
                    ticks = tournament.TurnTime;
                }else {
                    ticks = Clock.Instance.ConvertToTicks(DefaultTimespan);
                }

                CreateAction(battle, vacations, ticks);

                return battle;
            }
        }

	    #endregion Creation

		#region Public

		/// <summary>
		/// Creates a normal game battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleetInfos">Fleets of each player</param>
		/// <param name="terrain">Type of the battle terrain</param>
		/// <param name="isToConquer">if the planet is to conquer at the end of the battle</param>
		/// <returns>Identifier of the battle</returns>
		public static int CreateBattle( List<IBattleOwner> players, IList<IFleetInfo> fleetInfos, Terrain terrain, bool isToConquer, bool isInPlanet ) {
			foreach (IFleetInfo info in fleetInfos) {
				info.IsInBattle = true;
			}

			List<Fleet> fleets = GetFleetList(fleetInfos);

			Battle battle = CreateBattle(players, fleets, BattleType.TotalAnnihalation, BattleMode.Battle, true, terrain, isToConquer, isInPlanet);
			return battle.Id;
		}

		/// <summary>
		/// Creates a Friendly battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleet">Units that enter the battle</param>
		/// <param name="type">Type of the battle</param>
		/// <returns>Identifier of the battle</returns>
		public static int CreateFriendlyBattle( List<IBattleOwner> players, IFleetInfo fleet, BattleType type ) {
			List<Fleet> fleets = CreateAndGetFleetList(fleet, players.Count, false);

			Battle battle = CreateBattle(players, fleets, type, BattleMode.Friendly, false);
			return battle.Id;
		}


		/// <summary>
		/// Creates a Friendly battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleet">Units that enter the battle</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="terrain">Type of the battle terrain</param>
		/// <returns>Identifier of the battle</returns>
		public static int CreateFriendlyBattle(List<IBattleOwner> players, IFleetInfo fleet, BattleType type, Terrain terrain) {
			List<Fleet> fleets = CreateAndGetFleetList(fleet, players.Count, false);

			Battle battle = CreateBattle(players, fleets, type, BattleMode.Friendly, false, terrain, false, false);
			return battle.Id;
		}

        /// <summary>
        /// Creates a Friendly battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Player 1 units in the battle</param>
        /// <param name="opponent">Opponent's Units in the battle</param>
        /// <param name="type">Type of the battle</param>
        /// <returns>Identifier of the battle</returns>
        public static int CreateFriendlyBattle(List<IBattleOwner> players, IFleetInfo fleet, IFleetInfo opponent, BattleType type)
        {
            List<Fleet> fleets = CreateAndGetFleetList(fleet, opponent, false);

            Battle battle = CreateBattle(players, fleets, type, BattleMode.Friendly, false);
            return battle.Id;
        }

        /// <summary>
        /// Creates a Friendly battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Units that enter the battle</param>
        /// <returns>Identifier of the battle</returns>
        public static int CreateArenaBattle(List<IBattleOwner> players, IFleetInfo fleet, BattleType type){
            List<Fleet> fleets = CreateAndGetFleetList(fleet, players.Count, false);

			Battle battle = CreateBattle(players, fleets, type, BattleMode.Arena, false, Terrain.Arena, false, false);
            return battle.Id;
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleetInfos">Fleets of each player</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <returns>Object that represents the battle</returns>
		public static Battle CreateTournamentBattle(List<IBattleOwner> players, List<IFleetInfo> fleetInfos, BattleType type, TournamentMode tournamentMode, Core.Tournament tournament ) {
            return CreateTournamentBattle(players, fleetInfos, type, tournamentMode, false, tournament);
		}


		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="team1">Team 1 of Players that will enter the battle</param>
		/// <param name="team2">Team 2 of Players that will enter the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, Core.Tournament tournament) {
            return CreateTournamentBattle(team1, team2, fleet, type, tournamentMode, false, tournament);
		}

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="persistance">A persistance object</param>
		/// <returns>Object that represents the battle</returns>
		public static Battle CreateTournamentBattle(List<IBattleOwner> players, IFleetInfo fleet, BattleType type,
            TournamentMode tournamentMode, double sequenceNumber, IPersistanceSession persistance, Core.Tournament tournament)
        {
			List<Fleet> fleets = CreateAndGetFleetList(fleet, players.Count, false);

            Battle battle = CreateTournamentBattle(players, fleets, type, BattleMode.Tournament, tournamentMode, false, sequenceNumber, persistance, tournament);
			return battle;
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(List<IBattleOwner> players, IFleetInfo fleet, BattleType type,
            TournamentMode tournamentMode, double sequenceNumber, Core.Tournament tournament)
        {
            List<Fleet> fleets = CreateAndGetFleetList(fleet, players.Count, false);

            Battle battle = CreateTournamentBattle(players, fleets, type, BattleMode.Tournament, tournamentMode, false, sequenceNumber, tournament);
            return battle;
        }

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="players">Players that enter in the battle</param>
		/// <param name="fleetInfos">Fleets of each player</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="updateFleet"> If the fleet is to be updated during the battle</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(List<IBattleOwner> players, List<IFleetInfo> fleetInfos, BattleType type, TournamentMode tournamentMode, bool updateFleet, Core.Tournament tournament) {
			List<Fleet> fleets = CreateAndGetFleetList(fleetInfos, updateFleet);
            Battle battle = CreateTournamentBattle(players, fleets, type, BattleMode.Tournament, tournamentMode, updateFleet, 0, tournament);
			return battle;
		}


		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="team1">Team 1 of Players that will enter the battle</param>
		/// <param name="team2">Team 2 of Players that will enter the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="updateFleet"> If the fleet is to be updated during the battle</param>
		/// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, bool updateFleet, Core.Tournament tournament) {
		    int count = 0;

            if(team1 != null)
            {
                count += team1.Principals.Count;
            }

            if (team2 != null)
            {
                count += team2.Principals.Count;
            }
            
            List<Fleet> fleets = CreateAndGetFleetList(fleet, count, updateFleet);

            Battle battle = CreateTournamentBattle(team1, team2, fleets, type, BattleMode.Tournament, tournamentMode, updateFleet, 0, tournament);
			return battle;
		}

		/// <summary>
		/// Creates a Tournament battle
		/// </summary>
		/// <param name="team1">Team 1 of Players that will enter the battle</param>
		/// <param name="team2">Team 2 of Players that will enter the battle</param>
		/// <param name="fleet">Unique fleet, equal for all the players</param>
		/// <param name="type">Type of the battle</param>
		/// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
		/// <param name="sequenceNumber">Trounament sequence number</param>
        /// <param name="persistance">A persistance object</param>
		/// <returns>Object that represents the battle</returns>
		public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet,
            BattleType type, TournamentMode tournamentMode, double sequenceNumber, IPersistanceSession persistance, Core.Tournament tournament) 
        {
            int count = 0;

            if (team1 != null)
            {
                count += team1.Principals.Count;
            }

            if (team2 != null)
            {
                count += team2.Principals.Count;
            }
			List<Fleet> fleets = CreateAndGetFleetList(fleet, count, false);

			Battle battle = CreateTournamentBattle(team1, team2, fleets, type, BattleMode.Tournament, tournamentMode,
                false, sequenceNumber, persistance, tournament);
			return battle;
		}

        /// <summary>
        /// Creates a Tournament battle
        /// </summary>
        /// <param name="team1">Team 1 of Players that will enter the battle</param>
        /// <param name="team2">Team 2 of Players that will enter the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="type">Type of the battle</param>
        /// <param name="tournamentMode">Mode of the tournament (Normal,Laddeer,Survival)</param>
        /// <param name="sequenceNumber">Trounament sequence number</param>
        /// <returns>Object that represents the battle</returns>
        public static Battle CreateTournamentBattle(TeamStorage team1, TeamStorage team2, IFleetInfo fleet, BattleType type, TournamentMode tournamentMode, double sequenceNumber, Core.Tournament tournament)
        {
            int count = 0;

            if (team1 != null)
            {
                count += team1.Principals.Count;
            }

            if (team2 != null)
            {
                count += team2.Principals.Count;
            }
            List<Fleet> fleets = CreateAndGetFleetList(fleet, count, false);

            Battle battle = CreateTournamentBattle(team1, team2, fleets, type, BattleMode.Tournament, tournamentMode, false, sequenceNumber, tournament);
            return battle;
        }

		public static Battle CreateCampaignBattle(List<IBattleOwner> players, List<IFleetInfo> fleetInfos, BattleType type, IPersistanceSession session) {
			List<Fleet> fleets = GetFleetList(fleetInfos);
			return CreateBattle(players, fleets, type, BattleMode.Campaign, false, session);
		}

		#endregion Public

    }
}