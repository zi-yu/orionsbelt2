using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Messages;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.TournamentCreators;
using OrionsBelt.TournamentCore;
using OrionsBelt.Generic.Log;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;

namespace OrionsBelt.Engine.Tournament
{
    public class TournamentManager
    {
        #region static creators

        private static readonly ILadderCreator ladderCreator, ladder4Creator;
        private static readonly ITournamentCreator annihalationCreator, regicideCreator, dominationCreator;
        private static readonly ITournament4Creator annihalation4Creator, regicide4Creator, domination4Creator;

        private static readonly Dictionary<int,int[]> stageGameNumbers = new Dictionary<int, int[]>(5);

        private static readonly Dictionary<string, ITournamentCreator> singleCreators = new Dictionary<string, ITournamentCreator>();
        private static readonly Dictionary<string, ITournament4Creator> teamCreators = new Dictionary<string, ITournament4Creator>();
        private static readonly Dictionary<string, BattleType> mapper = new Dictionary<string, BattleType>();

        #endregion static creators

        #region Ctor

        static TournamentManager()
        {
            ladderCreator = new LadderCreator();
            ladder4Creator = new Ladder4Creator();

            annihalationCreator = new AnnihalationCreator();
            regicideCreator = new RegicideCreator();
            dominationCreator = new DominationCreator();

            annihalation4Creator = new Annihalation4Creator();
            regicide4Creator = new Regicide4Creator();
            domination4Creator = new Domination4Creator();

            singleCreators.Add(BattleType.TotalAnnihalation.ToString(), annihalationCreator);
            singleCreators.Add(BattleType.Regicide.ToString(), regicideCreator);
            singleCreators.Add(BattleType.Domination.ToString(), dominationCreator);

            teamCreators.Add(BattleType.TotalAnnihalation4.ToString(), annihalation4Creator);
            teamCreators.Add(BattleType.Regicide4.ToString(), regicide4Creator);
            teamCreators.Add(BattleType.Domination4.ToString(), domination4Creator);

            mapper.Add(BattleType.TotalAnnihalation.ToString(), BattleType.TotalAnnihalation);
            mapper.Add(BattleType.TotalAnnihalation4.ToString(), BattleType.TotalAnnihalation4);
            mapper.Add(BattleType.Domination.ToString(), BattleType.Domination);
            mapper.Add(BattleType.Domination4.ToString(), BattleType.Domination4);
            mapper.Add(BattleType.Regicide.ToString(), BattleType.Regicide);
            mapper.Add(BattleType.Regicide4.ToString(), BattleType.Regicide4);

            stageGameNumbers.Add(32, new int[] { 1, 17, 25, 9, 13, 29, 21, 5, 7, 23, 31, 15, 11, 27, 19, 3, 4, 20, 28, 12, 16, 32, 24, 8, 6, 22, 30, 14, 10, 26, 18, 2 });
            stageGameNumbers.Add(16, new int[] { 1, 9, 13, 5, 7, 15, 11, 3, 4, 12, 16, 8, 6, 14, 10, 2 });
            stageGameNumbers.Add(8, new int[] { 1, 5, 7, 3, 4, 8, 6, 2 });
            stageGameNumbers.Add(4, new int[] { 1, 3, 4, 2 });
            stageGameNumbers.Add(2, new int[] { 1, 2 });
            stageGameNumbers.Add(1, new int[] { 1 });
        }

        #endregion Ctor

        #region public methods

        /// <summary>
        /// Gets the first eliminatory fase
        /// </summary>
        /// <param name="tournament">Tournament</param>
        /// <returns>The number representing the eliminatory</returns>
        public static int BeginningEliminatory(Core.Tournament tournament)
        {
            if (tournament.NPlayersToPlayoff == tournament.Regists.Count)
            {
                return tournament.NPlayersToPlayoff;
            }
            int regists = tournament.Regists.Count;
            int minPlayoff = tournament.NPlayersToPlayoff;

            int finalPlayers = minPlayoff + 1;
            while (finalPlayers > minPlayoff)
            {
                double groups = Math.Ceiling((double)regists / 10);
                finalPlayers = Convert.ToInt32(groups)*3;
                regists = finalPlayers;
            }

            return NumericUtils.GetNext2Pow(finalPlayers);
        }
        /*
        /// <summary>
        /// Get player by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <param name="stage">Stage of the tournament</param>
        /// <param name="tourId">Tournament identifier</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<List<GroupPlayer>> GetPlayersByGroupOrdered(IList<PlayersGroupStorage> groups, int stage, int tourId)
        {
            return TournamentUtil.GetPlayersByGroupOrdered(groups, stage, tourId);
        }
        */
        /// <summary>
        /// Get player by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        public static List<GroupPlayer> GetPlayersByGroupOrdered(IList<PlayersGroupStorage> groups)
        {
            return TournamentUtil.GetPlayersByGroupOrdered(groups);
        }

        /// <summary>
        /// Get player by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <param name="stage">Stage of the tournament</param>
        /// <param name="tourId">Tournament identifier</param>
        /// <param name="page">Page number</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<List<GroupPlayer>> GetPlayersByGroupOrdered(IList<PlayersGroupStorage> groups, int stage, int tourId, int page)
        {
            return TournamentUtil.GetPlayersByGroupOrdered(groups, stage, tourId, page);
        }

        /// <summary>
        /// Get teams by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <param name="stage">Stage of the tournament</param>
        /// <param name="tourId">Tournament identifier</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<List<GroupPlayer>> GetTeamsByGroupOrdered(IList<PlayersGroupStorage> groups, int stage, int tourId)
        {
            return TournamentUtil.GetTeamsByGroupOrdered(groups, stage, tourId);
        }

        /// <summary>
        /// Get teams by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<GroupPlayer> GetTeamsByGroupOrdered(IList<PlayersGroupStorage> groups)
        {
            return TournamentUtil.GetTeamsByGroupOrdered(groups);
        }

        /// <summary>
        /// Get teams by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <param name="stage">Stage of the tournament</param>
        /// <param name="tourId">Tournament identifier</param>
        /// <param name="page">Page number</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<List<GroupPlayer>> GetTeamsByGroupOrdered(IList<PlayersGroupStorage> groups, int stage, int tourId, int page)
        {
            return TournamentUtil.GetTeamsByGroupOrdered(groups, stage, tourId, page);
        }

        /// <summary>
        /// Creates a Ladder battle
        /// </summary>
        /// <param name="prins">Principal that enter in the battle</param>
        /// <param name="fleetInfo">Unique fleet, equal for all the players</param>
        public static void CreateLadder(List<Principal> prins, FleetInfo fleetInfo)
        {
            ladderCreator.ValidateData(prins, fleetInfo, true);
            Battle battle = BattleManager.CreateTournamentBattle(prins, fleetInfo, BattleType.TotalAnnihalation, TournamentMode.Ladder,null);
            ladderCreator.PutPlayersInBattle(prins, battle.Id);
        }

        /// <summary>
        /// Creates a team Ladder battle
        /// </summary>
        /// <param name="prins">Principal that enter in the battle</param>
        /// <param name="fleetInfo">Unique fleet, equal for all the players</param>
        public static void CreateLadder4(List<Principal> prins, FleetInfo fleetInfo)
        {
            ladder4Creator.ValidateData(prins, fleetInfo, true);

            Battle battle = BattleManager.CreateTournamentBattle(prins[0].Team, prins[2].Team, fleetInfo, BattleType.TotalAnnihalation4, TournamentMode.Ladder, null);
            ladder4Creator.PutPlayersInBattle(prins, battle.Id);
        }

        /// <summary>
        /// Calculate the win probability for both players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <returns>Returns in the position 0, player one probability, and in the position 1 player two probability</returns>
        public static double[] WinProbability(Principal player1, Principal player2)
        {
            return TournamentUtil.WinProbability(player1, player2);
        }

        /// <summary>
        /// Calculate new ELO ranking for the players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="battleType">Battle Type</param>
        /// <returns></returns>
        public static void CalcElo(IBattleResult player1, IBattleResult player2, BattleType battleType)
        {
            TournamentUtil.CalcElo(player1, player2, battleType);
        }

        /// <summary>
        /// Calculate new ELO ranking for the players/teams
        /// </summary>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        /// <param name="battleType">Battle Type</param>
        /// <returns></returns>
        public static void CalcElo(List<IBattleResult> player1, List<IBattleResult> player2, BattleType battleType)
        {
            TournamentUtil.CalcElo(player1, player2, battleType);
        }

        /// <summary>
        /// Update the battle stats players/teams
        /// </summary>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        /// <param name="battleInfo">Battle Type</param>
        /// <returns></returns>
        public static void UpdateStats(List<IBattleResult> player1, List<IBattleResult> player2, IBattleInfo battleInfo)
        {
            TournamentUtil.UpdateStats(player1, player2, battleInfo);
        }

        /// <summary>
        /// Calculate new Ladder ranking for the players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <returns></returns>
        public static void CalcLadderResult(IBattlePlayer player1, IBattlePlayer player2)
        {
            TournamentUtil.CalcLadderResult(player1, player2);
        }

        /// <summary>
        /// Calculate new Ladder ranking for the players
        /// </summary>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        /// <returns></returns>
        public static void CalcLadderResult(IList<IBattlePlayer> player1, IList<IBattlePlayer> player2)
        {
            TournamentUtil.CalcLadderResult(player1, player2);
        }


        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="players">List of player in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">ShortType of tournament</param>
        /// <returns>A list that contains a list of Pricipals for each group</returns>
        public static void BeginTournament(IList<PrincipalTournament> players, int stage, FleetInfo fleetInfo, BattleType battleType,
            Core.Tournament tour)
        {
            List<List<Principal>> principals = null;
            if(battleType == BattleType.TotalAnnihalation || 
                battleType == BattleType.Regicide ||
                battleType == BattleType.Domination)
            {
                principals = annihalationCreator.GenerateGroups(players, stage);
            }
            //Logger.Debug("Grupos gerados", LogType.Tournament);
            IList<PlayersGroupStorage> groups = GetGroups(players, stage);
            CreateGroupBattles(principals, groups, fleetInfo, battleType, stage,tour);
            
        }

        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="players">List of teams in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">Type of tournament</param>
        /// <returns>A list that contains a list of Pricipals for each group</returns>
        public static void BeginTeamTournament(IList<PrincipalTournament> players, int stage, 
            FleetInfo fleetInfo, BattleType battleType, Core.Tournament tour)
        {
            List<List<TeamStorage>> teams = null;
            if (battleType == BattleType.TotalAnnihalation4 ||
                battleType == BattleType.Regicide4 ||
                battleType == BattleType.Domination4)
            {
                teams = annihalation4Creator.GenerateTeamGroups(players, stage);
            }
            //Logger.Debug("Grupos Team Criados", LogType.Tournament);
            IList<PlayersGroupStorage> groups = GetGroups(players, stage);
            CreateGroupBattles(teams, groups, fleetInfo, battleType, stage, tour);
        }

        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="tournamentId">The id of the tournament</param>
        /// <returns></returns>
        public static void BeginTournament(int tournamentId)
        {
            Core.Tournament tour;
            Fleet fleet;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.SelectById(tournamentId)[0];
                tour.StartTime = DateTime.Now;
                using (IFleetPersistance persistance2 = Persistance.Instance.GetFleetPersistance(persistance))
                {
                    fleet = persistance2.SelectById(tour.FleetId)[0];
                }
                persistance.Update(tour);
                persistance.Flush();
            }
            BattleType battleType = mapper[tour.TournamentType];
            
            if (tour.TournamentType == BattleType.TotalAnnihalation.ToString() ||
                tour.TournamentType == BattleType.Regicide.ToString() ||
                tour.TournamentType == BattleType.Domination.ToString())
            {
                BeginSingleTournament(tour, fleet, battleType);
            }
            else
            {
                BeginTeamTournament(tour, fleet, battleType);
            }
            if (tour.IsCustom)
            {
                Messenger.Add(new TournamentStarts(tour.Name), true);
            }
            else
            {
                Messenger.Add(new TournamentStarts(string.Format("{0} {1}", LanguageManager.Instance.Get(tour.Token), tour.TokenNumber), true), true);
            }
        }

        /// <summary>
        /// Advance to the next tournament stage
        /// </summary>
        /// <param name="tournamentId">Tournament to process</param>
        /// <returns></returns>
        public static void ProcessTournament(int tournamentId)
        {
            try
            {
                IList<Core.Tournament> tour;
                using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
                {
                    tour = persistance.SelectById(tournamentId);
                    if (tour.Count == 0)
                    {
                        throw new TournamentException(
                            string.Format("The tournament with id {0} is not a valid tournament", tournamentId));
                    }
                }
                if (tour[0].TournamentType == "TotalAnnihalation" ||
                    tour[0].TournamentType == "Domination" ||
                    tour[0].TournamentType == "Regicide")
                {
                    ProcessSingleTournament(tour[0]);
                }
                else
                {
                    ProcessTeamTournament(tour[0]);
                }
                if (tour[0].IsCustom)
                {
                    Messenger.Add(new TournamentAdvanced(tour[0].Name, tour[0].IsCustom), true);
                }
                else
                {
                    Messenger.Add(new TournamentAdvanced(string.Format("{0} {1}", LanguageManager.Instance.Get(tour[0].Token), tour[0].TokenNumber), tour[0].IsCustom), true);
                }
                
            }

            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
            }
            
        }

        #region Creators
        /// <summary>
        /// Creates an Annihalation tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateAnnihalationTournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = annihalationCreator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if (isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        /// <summary>
        /// Creates a regicide tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateRegicideTournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = regicideCreator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if (isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        /// <summary>
        /// Creates a domination tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateDominationTournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = dominationCreator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if (isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        /// <summary>
        /// Creates an Annihalation 4 tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateAnnihalation4Tournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = annihalation4Creator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if (isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        /// <summary>
        /// Creates an Regicide 4 tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateRegicide4Tournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = regicide4Creator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if (isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        /// <summary>
        /// Creates an Domination 4 tournament
        /// </summary>
        /// <param name="name">Tournament name</param>
        /// <param name="prize">Tournament prize description</param>
        /// <param name="credits">Number of credits required to enter</param>
        /// <param name="fleetId">Fleet's identifier</param>
        /// <param name="isPublic">Is a public tournament or is a private/alliance tournament</param>
        /// <param name="isSurvival">Is a tournament in survival mode</param>
        /// <param name="turnTime">Base number of turns between player's time to play</param>
        /// <param name="subTime">Time of subscription. If 0 is unlimited</param>
        /// <param name="maxPlayers">Number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="minPlayers">Minimum number of player required to begin the tournament. If 0 the condition is not required</param>
        /// <param name="toPlayoff">Number of players required to begin the playoff fase</param>
        /// <param name="maxElo">Player couldn't have an ELO greater than this when made the regist</param>
        /// <param name="minElo">Player couldn't have an ELO lower than this when made the regist</param>
        /// <param name="isCustom">If false is an automatic tornament</param>
        public static Core.Tournament CreateDomination4Tournament(string name, string prize, int credits, int fleetId, bool isPublic,
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo, bool isCustom)
        {
            Core.Tournament toReturn = domination4Creator.CreateTournament(name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
            if(isCustom)
            {
                Messenger.Add(new NewTournament(name), true);
            }
            return toReturn;
        }

        #endregion Creators

        public static PrincipalTournament RegistPlayer(Principal principal, int tournamentId)
        {
            PrincipalTournament toReturn =  annihalationCreator.RegistPlayer(principal, tournamentId);
            Core.Tournament tour;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.SelectById(tournamentId)[0];
                if (0 < tour.CostCredits)
                {
                    TransactionManager.TournamentTransaction(tour, principal, persistance);
                    persistance.Flush();
                }
            }

            StartNewTournament(tour, false); 

            return toReturn;
        }

        private static void StartNewTournament(Core.Tournament tour, bool isTeam)
        {
            if (tour.MaxPlayers == tour.MinPlayers &&
                tour.MaxPlayers == tour.NPlayersToPlayoff &&
                tour.MaxPlayers == tour.Regists.Count)
            {
                int tourNumber = tour.TokenNumber +1;
                

                IFleetInfo units = GetFleet(1000, false);
                units.TournamentFleet = true;
                GameEngine.Persist(units);
                Fleet fleet = units.Storage;
                Core.Tournament t;
                if(TickClock.Instance.Tick%2 == 1)
                {
                    if (isTeam)
                    {
                        t = CreateAnnihalation4Tournament("Automatic Team Annihalation Tournament", "", 0, fleet.Id,
                                                         true, false, tour.TurnTime,
                                                         0, tour.MaxPlayers, tour.MaxPlayers, tour.MaxPlayers, 0, 0, false);
                        t.Token = tour.Token;
                    }
                    else
                    {
                        t = CreateAnnihalationTournament("Automatic Annihalation Tournament", "", 0, fleet.Id,
                                                         true, false, tour.TurnTime,
                                                         0, tour.MaxPlayers, tour.MaxPlayers, tour.MaxPlayers, 0, 0, false);
                        t.Token = tour.Token;
                    }
                }
                else
                {
                    if (isTeam)
                    {
                        t = CreateRegicide4Tournament("Automatic Team Annihalation Tournament", "", 0, fleet.Id,
                                                         true, false, tour.TurnTime,
                                                         0, tour.MaxPlayers, tour.MaxPlayers, tour.MaxPlayers, 0, 0, false);
                        t.Token = tour.Token;
                    }
                    else
                    {
                        t = CreateRegicideTournament("Automatic Regicide Tournament", "", 0, fleet.Id,
                                                     true, false, tour.TurnTime,
                                                     0, tour.MaxPlayers, tour.MaxPlayers, tour.MaxPlayers, 0, 0, false);
                        t.Token = tour.Token;
                    }
                }

                if (t.Token != "XLPartyTournament")
                {
                    Messenger.Add(new NewTournament(string.Format("{0} {1}", LanguageManager.Instance.Get(tour.Token), tour.TokenNumber), true), false);
                }

                t.IsCustom = false;
                t.TokenNumber = tourNumber;
                
                using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
                {
                    persistance.Update(t);
                    persistance.Flush();
                }

                if (t.Token != "XLPartyTournament" || DateTime.Now > (new DateTime(2010, 3, 26, 12, 0, 0)))
                {
                    BeginTournament(tour.Id);
                }
            }
        }

        public static PrincipalTournament RegistTeam(TeamStorage team, int tournamentId)
        {
            PrincipalTournament toReturn = annihalation4Creator.RegistTeam(team, tournamentId);

            Core.Tournament tour;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.SelectById(tournamentId)[0];
                if (0 < tour.CostCredits)
                {
                    TransactionManager.TournamentTransaction(tour, team, persistance);
                    persistance.Flush();
                }
            }

            StartNewTournament(tour,true);

            return toReturn;
        }

        /// <summary>
        /// Calculate the group points won if is a group battle
        /// </summary>
        /// <param name="battle">Battle</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        public static void CalcGroupPoints(Battle battle, IBattlePlayer player1, IBattlePlayer player2)
        {
            TournamentUtil.CalcGroupPoints(battle, player1, player2);
        }

        /// <summary>
        /// Calculate the group points won if is a group battle
        /// </summary>
        /// <param name="battle">Battle</param>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        public static void CalcGroupPoints(Battle battle, IList<IBattlePlayer> player1, IList<IBattlePlayer> player2)
        {
            TournamentUtil.CalcGroupPoints(battle, player1, player2);
        }

        /// <summary>
        /// Gets a random FeetInfo prepared to be used in a tournament/arena/ladder
        /// </summary>
        /// <param name="numberOfShips">Number of ships</param>
        /// <param name="hasUltimate">The fleet to be return have ultimate</param>
        /// <returns>An object FleetInfo</returns>
        public static FleetInfo GetFleet(int numberOfShips, bool hasUltimate)
        {
            return FleetInfo.GetRandom(hasUltimate);
            //FleetInfo info = new FleetInfo("Random");
            //info.TournamentFleet = true;

            //IList<IUnitInfo> units = RulesUtils.GetUnitResources();
            //IList<IUnitInfo> lights = new List<IUnitInfo>();
            //IList<IUnitInfo> mediums = new List<IUnitInfo>();
            //IList<IUnitInfo> heavies = new List<IUnitInfo>();
            //IList<IUnitInfo> ultimates = new List<IUnitInfo>();

            //GetListsByCategory(units, lights, mediums, heavies, ultimates);

            //AddRandomToFleet(info, lights, mediums, heavies, numberOfShips);
            //if (hasUltimate)
            //{
            //    Random rad = new Random();
            //    info.AddUltimate(ultimates[rad.Next(ultimates.Count)].Name);
            //}

            //return info;
        }

        public static void WinOrions(List<IBattleResult> player1, List<IBattleResult> player2, IBattleInfo battleInfo)
        {
            if (player1.Count == 0 || player2.Count == 0)
            {
                throw new ListCountException(player1.Count, player2.Count, 0);
            }

            if (player1.Count == 1 || player2.Count == 1)
            {
                Principal p1;
                if (player1[0].HasLost)
                {
                    p1 = player2[0].Player;
                }
                else
                {
                    p1 = player1[0].Player;
                }

                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    p1.Credits += 5;
                    TransactionManager.TournamentBattleTransaction(5,p1,battleInfo,persistance);
                }
            }
            else
            {
                Principal p1, p2;
                if(player1[0].HasLost)
                {
                    p1 = player2[0].Player;
                    p2 = player2[1].Player;
                }
                else
                {
                    p1 = player1[0].Player;
                    p2 = player1[1].Player;
                }

                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    p1.Credits += 5;
                    p2.Credits += 5;
                    TransactionManager.TournamentBattleTransaction(5, p1, battleInfo, persistance);
                    TransactionManager.TournamentBattleTransaction(5, p2, battleInfo, persistance);
                }
            }
        }

        #endregion public methods

        #region private methods

        private static void AddRandomToFleet(IFleetInfo info, IList<IUnitInfo> lights, IList<IUnitInfo> mediums, IList<IUnitInfo> heavies, int numberOfShips)
        {
            int lNumber = Convert.ToInt32(numberOfShips * 0.3);
            int mNumber = Convert.ToInt32(numberOfShips * 0.4);
            int hNumber = Convert.ToInt32(numberOfShips * 0.3);

            Random rad = new Random();
            for (int iter = 0; iter < 3; ++iter)
            {
                int huNumber = hNumber;
                int muNumber = mNumber;
                if (iter < 2)
                {
                    int luNumber = rad.Next(Convert.ToInt32(lNumber * 0.25), Convert.ToInt32(lNumber * 0.75));
                    lNumber -= luNumber;
                    muNumber = rad.Next(Convert.ToInt32(lNumber * 0.25), Convert.ToInt32(mNumber * 0.75));
                    mNumber -= muNumber;

                    huNumber = rad.Next(Convert.ToInt32(hNumber * 0.25), Convert.ToInt32(hNumber * 0.75));
                    hNumber -= huNumber;

                    int lIter = rad.Next(0, lights.Count);
                    IUnitInfo lig = lights[lIter];
                    lights.Remove(lig);

                    info.Add(lig, luNumber);
                }

                int mIter = rad.Next(0, mediums.Count);
                IUnitInfo med = mediums[mIter];
                mediums.Remove(med);

                int hIter = rad.Next(0, heavies.Count);
                IUnitInfo hev = heavies[hIter];
                heavies.Remove(hev);

                info.Add(hev, huNumber);
                info.Add(med, muNumber);
            }
        }

        private static void GetListsByCategory(IEnumerable<IUnitInfo> units, ICollection<IUnitInfo> lights, ICollection<IUnitInfo> mediums, ICollection<IUnitInfo> heavies, ICollection<IUnitInfo> ultimates)
        {
            foreach (IUnitInfo unit in units)
            {
                if (UnitCategory.Light == unit.UnitCategory && unit.CanBeSaved)
                {
                    lights.Add(unit);
                    continue;
                }

                if (UnitCategory.Medium == unit.UnitCategory && unit.CanBeSaved)
                {
                    mediums.Add(unit);
                    continue;
                }

                if (UnitCategory.Heavy == unit.UnitCategory && unit.CanBeSaved)
                {
                    heavies.Add(unit);
                    continue;
                }

                if (UnitCategory.Ultimate == unit.UnitCategory && unit.CanBeSaved)
                {
                    ultimates.Add(unit);
                    continue;
                }
            }
        }


        private static void BeginTeamTournament(Core.Tournament tour, Fleet fleet, BattleType battleType)
        {
            if (tour.NPlayersToPlayoff == tour.Regists.Count)
            {
                FleetInfo info = GetFleetInfo(tour);
                IList<PrincipalTournament> princTour = TournamentUtil.GetTeamRegistsByElo(tour);
                List<List<TeamStorage>> teams = annihalation4Creator.GetTeamDuos(princTour);
                CreatePlayoffBattles(teams, 0, info, mapper[tour.TournamentType], tour);
            }
            else
            {
                List<List<TeamStorage>> teams = annihalation4Creator.GenerateTeamGroups(tour.Regists, 0);
                IList<PlayersGroupStorage> groups = GetGroups(tour.Regists, 0);
                CreateGroupBattles(teams, groups, new FleetInfo(fleet), battleType, 0, tour);
            }
        }

        private static void BeginSingleTournament(Core.Tournament tour, Fleet fleet, BattleType battleType)
        {
            if (tour.NPlayersToPlayoff == tour.Regists.Count)
            {
                FleetInfo info = GetFleetInfo(tour);
                IList<PrincipalTournament> princTour = TournamentUtil.GetPrincipalRegistsByElo(tour);
                List<List<Principal>> principals = annihalationCreator.GetPrincipalDuos(princTour);
                CreatePlayoffBattles(principals, 0, info, mapper[tour.TournamentType], tour);
            }
            else
            {
                List<List<Principal>> principals = annihalationCreator.GenerateGroups(tour.Regists, 0);
                IList<PlayersGroupStorage> groups = GetGroups(tour.Regists, 0);
                CreateGroupBattles(principals, groups, new FleetInfo(fleet), battleType, 0,tour);
            }
        }

        private static void ProcessTeamTournament(Core.Tournament tour)
        {
            ITournament4Creator creator = teamCreators[tour.TournamentType];
            FleetInfo info = GetFleetInfo(tour);
            if (creator.IsInGroupStage(tour.Id))
            {
                Console.WriteLine("Is in group stage");
                IList<PrincipalTournament> prins = creator.GetGroupTeamsThatPass(tour);
                if (!creator.IsToBeginPlayoffs(tour))
                {
                    Console.WriteLine("Creating new groups");
                    int lastStage = creator.GetLastGroupStage(tour.Id);
                    BeginTeamTournament(prins, lastStage + 1, info, mapper[tour.TournamentType], tour);
                }
                else
                {
                    Console.WriteLine("Creating playoffs");
                    List<List<TeamStorage>> teams = creator.GetTeamDuos(prins);
                    CreatePlayoffBattles(teams, 0, info, mapper[tour.TournamentType], tour);
                }
            }
            else
            {
                Console.WriteLine("Is not in group stage");
                IList<Battle> battles = creator.BattlesFromLastStage(tour.Id);
                if (battles.Count > 1)
                {
                    Console.WriteLine("Create new playoff fase");
                    List<List<TeamStorage>> teams = creator.GetTeamDuos(battles);
                    int max = creator.GetMaxBattleSequenceNumber(tour.Id);
                    CreatePlayoffBattles(teams, max, info, mapper[tour.TournamentType], tour);
                }
                else
                {
                    Console.WriteLine("End tournament");
                    IDictionary<PrincipalTournament, int> pairs = creator.EndTournament(tour, battles[0]);
                    LogTransactions(pairs, tour);
                }
            }
        }


        private static void ProcessSingleTournament(Core.Tournament tour)
        {
            ITournamentCreator creator = singleCreators[tour.TournamentType];
            FleetInfo info = GetFleetInfo(tour);
            if (creator.IsInGroupStage(tour.Id))
            {
                //Logger.Debug("Is in group stage", LogType.Tournament);
                //Console.WriteLine("Is in group stage");
                List<List<GroupPlayer>> groupList = new List<List<GroupPlayer>>();
                IList<PrincipalTournament> prins = creator.GetGroupPlayerThatPass(tour, groupList);
                GiveMedal(groupList, tour);
                if (!creator.IsToBeginPlayoffs(tour))
                {
                    if (groupList.Count == 1 && tour.NumberPassGroup != 0)
                    {
                        creator.EndTournament(tour, prins);
                        GiveMedal(prins, tour);
                        LogTransactions(prins, tour);
                    }
                    else
                    {
                        //Logger.Debug("Creating new groups", LogType.Tournament);
                        //Console.WriteLine("Creating new groups");
                        int lastStage = creator.GetLastGroupStage(tour.Id);
                        BeginTournament(prins, lastStage + 1, info, mapper[tour.TournamentType],tour);
                    }
                }
                else
                {
                    //Logger.Debug("Creating playoffs", LogType.Tournament);
                    Console.WriteLine("Creating playoffs");
                    List<List<Principal>> principals = creator.GetPrincipalDuos(prins);
                    CreatePlayoffBattles(principals, 0, info, mapper[tour.TournamentType], tour);
                }
            }
            else
            {
                //Logger.Debug("Is not in group stage", LogType.Tournament);
                Console.WriteLine("Is not in group stage");
                IList<Battle> battles = creator.BattlesFromLastStage(tour.Id);
                if (battles.Count > 1)
                {
                    Console.WriteLine("Create new playoff fase");
                    List<List<Principal>> principals = creator.GetPrincipalDuos(battles);
                    int max = creator.GetMaxBattleSequenceNumber(tour.Id);
                    CreatePlayoffBattles(principals, max, info, mapper[tour.TournamentType], tour);
                }
                else
                {
                    Console.WriteLine("End tournament");
                    IDictionary<PrincipalTournament, int> pairs = creator.EndTournament(tour, battles[0]);
                    IList<PrincipalTournament> prinTours = new List<PrincipalTournament>(pairs.Count);
                    foreach (PrincipalTournament key in pairs.Keys)
                    {
                        prinTours.Add(key);
                    }
                    GiveMedal(prinTours, tour);
                    if (tour.IsCustom)
                    {
                        LogTransactions(pairs, tour);
                    }else
                    {
                        Persistance.Flush();
                    }
                }
            }
        }

        private static void GiveMedal(IList<PrincipalTournament> prins, Core.Tournament tour)
        {
            if (prins[0].EliminatedInFase == "Winner")
            {
                MedalManager.Add(prins[0].Principal, (MedalType) Enum.Parse(typeof (MedalType),
                                                                            string.Format("{0}_Winner",
                                                                                          tour.TournamentType)));
                MedalManager.Add(prins[1].Principal, (MedalType) Enum.Parse(typeof (MedalType),
                                                                            string.Format("{0}_RunnerUp",
                                                                                          tour.TournamentType)));
            }
            else
            {
                MedalManager.Add(prins[1].Principal, (MedalType)Enum.Parse(typeof(MedalType),
                                                                            string.Format("{0}_Winner",
                                                                                          tour.TournamentType)));
                MedalManager.Add(prins[0].Principal, (MedalType)Enum.Parse(typeof(MedalType),
                                                                            string.Format("{0}_RunnerUp",
                                                                                          tour.TournamentType)));
            }
        }

        private static void GiveMedal(IDictionary<Principal, int> pairs, Core.Tournament tour)
        {
            IList<Principal> prins = new List<Principal>();
            IList<int> prize = new List<int>();
            foreach (KeyValuePair<Principal, int> pair in pairs)
            {
                prins.Add(pair.Key);
                prize.Add(pair.Value);
            }

            if(prize[0] > prize[1])
            {
                MedalManager.Add(prins[0], (MedalType)Enum.Parse(typeof(MedalType),
                                     string.Format("{0}_Winner", tour.TournamentType)));
                MedalManager.Add(prins[1], (MedalType)Enum.Parse(typeof(MedalType),
                                     string.Format("{0}_RunnerUp", tour.TournamentType)));
            }
            else
            {
                MedalManager.Add(prins[1], (MedalType)Enum.Parse(typeof(MedalType),
                                     string.Format("{0}_Winner", tour.TournamentType)));
                MedalManager.Add(prins[0], (MedalType)Enum.Parse(typeof(MedalType),
                                     string.Format("{0}_RunnerUp", tour.TournamentType)));
            }
        }

        private static void GiveMedal(List<List<GroupPlayer>> groupList, Core.Tournament tour)
        {
            foreach (List<GroupPlayer> groupPlayers in groupList)
            {
                for(int iter = 0; iter < 3; ++iter)
                {
                    MedalManager.Add(groupPlayers[iter].Player.Principal,
                                     (MedalType)Enum.Parse(typeof (MedalType), 
                                     string.Format("{0}_{1}", tour.TournamentType, iter)));
                }
            }
        }

        private static void LogTransactions(IList<PrincipalTournament> prins, Core.Tournament tour)
        {
            int prize = 1250;
            
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                for (int iter = 0; iter <= 3; ++iter)
                {
                    TransactionManager.TournamentPrizeTransaction(Convert.ToInt32(prize * (0.4 - ((double)iter / 10))),
                        prins[iter].Principal, tour, persistance);
                }
                persistance.Flush();
            }
        }

        private static void LogTransactions(IDictionary<PrincipalTournament, int> pairs, Core.Tournament tour)
        {
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                foreach (KeyValuePair<PrincipalTournament, int> pair in pairs)
                {
                    if (pair.Value != 0)
                    {
                        TransactionManager.TournamentPrizeTransaction(pair.Value, pair.Key.Principal, tour, persistance);
                    }
                }
                persistance.Flush();
            }
        }

        private static IList<PlayersGroupStorage> GetGroups(IList<PrincipalTournament> players, int stage)
        {
            IList<PlayersGroupStorage> groups;
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                groups =
                    persistance.TypedQuery(
                        "select e from SpecializedPlayersGroupStorage e where e.EliminatoryNumber={0} and e.TournamentNHibernate.Id={1}",
                        stage, players[0].Tournament.Id);
            }
            return groups;
        }

        /// <summary>
        /// Generate Battles for groups
        /// </summary>
        /// <param name="principals">A list that contains a list of Pricipals for each group</param>
        /// <param name="groups">A list Of the groups</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">The type of tournament that will have this group battles</param>
        /// <param name="stage">Group stage</param>
        /// <returns></returns>
        public static void CreateGroupBattles(IList<List<Principal>> principals, IList<PlayersGroupStorage> groups, 
            IFleetInfo fleetInfo, BattleType battleType, int stage, Core.Tournament tour)
        {
            //Logger.Debug(LogType.Tournament, "Principal Count = {0}; Group Count = {1}", principals.Count, groups.Count);
            Console.WriteLine("Principal Count = {0}; Group Count = {1}", principals.Count, groups.Count);
            if (principals.Count != groups.Count)
            {
                throw new TournamentException("Groups lists must have the same length");
            }
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                for (int iterGroup = 0; iterGroup < principals.Count; ++iterGroup)
                {
                    Console.WriteLine("Generation Group:{0}...", iterGroup);
                    for (int iterPrin1 = 0; iterPrin1 < principals[iterGroup].Count; ++iterPrin1)
                    {
                        for (int iterPrin2 = iterPrin1 + 1; iterPrin2 < principals[iterGroup].Count; ++iterPrin2)
                        {
                            List<Principal> prins = new List<Principal>(2);
                            prins.Add(principals[iterGroup][iterPrin1]);
                            prins.Add(principals[iterGroup][iterPrin2]);
                            //Logger.Debug(LogType.Tournament, "Principal 1 = {0} VS Principal 2 = {1}", principals[iterGroup][iterPrin1].Name, principals[iterGroup][iterPrin2].Name);
                            Battle battle =
                                BattleManager.CreateTournamentBattle(prins, fleetInfo, battleType, TournamentMode.Normal,persistance,tour);

                            //Logger.Debug(LogType.Tournament,"Batalha criada" );
                            battle.Group = groups[iterGroup];
                            battle.Tournament = groups[iterGroup].Tournament;
                            battle.SeqNumber = ((double)stage)/10;
                            persistance.Update(battle);
                            //groups[iterGroup].Battles.Add(battle);
                        }
                    }
                    //persistance.Update(groups[iterGroup]);
                }
                Console.WriteLine("Flushing: {0}", DateTime.Now);
                persistance.Clear();
                Console.WriteLine("End Flush: {0}", DateTime.Now);
            }
        }

        /// <summary>
        /// Generate Battles for team groups
        /// </summary>
        /// <param name="teams">A list that contains a list of teams for each group</param>
        /// <param name="groups">A list Of the groups</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">The type of tournament that will have this group battles</param>
        /// <param name="stage">Group stage</param>
        /// <returns></returns>
        private static void CreateGroupBattles(IList<List<TeamStorage>> teams, IList<PlayersGroupStorage> groups, 
            IFleetInfo fleetInfo, BattleType battleType, int stage, Core.Tournament tour)
        {
            //Logger.Debug("Team Count = {0}; Group Count = {1}", LogType.Tournament, teams.Count, groups.Count);
            if (teams.Count != groups.Count)
            {
                throw new TournamentException("Groups lists must have the same length");
            }
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                for (int iterGroup = 0; iterGroup < teams.Count; ++iterGroup)
                {
                    for (int iterPrin1 = 0; iterPrin1 < teams[iterGroup].Count; ++iterPrin1)
                    {
                        for (int iterPrin2 = iterPrin1 + 1; iterPrin2 < teams[iterGroup].Count; ++iterPrin2)
                        {
                            List<TeamStorage> prins = new List<TeamStorage>(2);
                            prins.Add(teams[iterGroup][iterPrin1]);
                            prins.Add(teams[iterGroup][iterPrin2]);
                            Battle battle =
                                BattleManager.CreateTournamentBattle(prins[0], prins[1], fleetInfo, battleType,
                                TournamentMode.Normal,persistance,tour);

                            battle.Group = groups[iterGroup];
                            battle.Tournament = groups[iterGroup].Tournament;
                            battle.SeqNumber = ((double)stage) / 10;
                            persistance.Update(battle);
                            //groups[iterGroup].Battles.Add(battle);
                        }
                    }
                    //persistance.Update(groups[iterGroup]);
                    persistance.Flush();
                }
            }
        }

        /// <summary>
        /// Generate Battles for playoffs
        /// </summary>
        /// <param name="principals">A list that contains a list of Pricipals for each battle</param>
        /// <param name="baseBattleNumber">Battle sequence number max until the date for the tournament</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">The type of tournament that will have this group battles</param>
        /// <param name="tour">Tournament to be processed</param>
        /// <returns></returns>
        private static void CreatePlayoffBattles(IList<List<Principal>> principals, int baseBattleNumber,
            IFleetInfo fleetInfo, BattleType battleType, Core.Tournament tour)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                persistance.StartTransaction();
                for (int iter = 0; iter < principals.Count; ++iter)
                {
                    double seqNumber;
                    if (0 == baseBattleNumber)
                    {
                        seqNumber =
                            NumericUtils.GetDouble(
                                (stageGameNumbers[principals.Count][iter] + baseBattleNumber) +
                                "," + (principals.Count));
                    }
                    else
                    {
                        seqNumber =
                            NumericUtils.GetDouble(
                                (iter + 1 + baseBattleNumber) +
                                "," + (principals.Count));
                    }
                    Battle battle =
                        BattleManager.CreateTournamentBattle(principals[iter], fleetInfo, battleType,
                                                             TournamentMode.Normal, seqNumber, persistance,tour);
                    battle.Tournament = tour;
                    persistance.Update(battle);
                }
                persistance.CommitTransaction();
            }
        }

        /// <summary>
        /// Generate Battles for teams playoffs
        /// </summary>
        /// <param name="teams">A list that contains a list of teams for each battle</param>
        /// <param name="baseBattleNumber">Battle sequence number max until the date for the tournament</param>
        /// <param name="fleetInfo">Fleet for the battle</param>
        /// <param name="battleType">The type of tournament that will have this group battles</param>
        /// <param name="tour">Tournament to be processed</param>
        /// <returns></returns>
        private static void CreatePlayoffBattles(IList<List<TeamStorage>> teams, int baseBattleNumber,
            IFleetInfo fleetInfo, BattleType battleType, Core.Tournament tour)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                for (int iter = 0; iter < teams.Count; ++iter)
                {
                    double seqNumber =
                        NumericUtils.GetDouble(
                            (stageGameNumbers[teams.Count][iter] + baseBattleNumber) +
                            "," + (teams.Count));
                    Battle battle =
                        BattleManager.CreateTournamentBattle(teams[iter][0], teams[iter][1], fleetInfo, battleType,
                                                             TournamentMode.Normal, seqNumber, persistance,tour);
                    battle.Tournament = tour;
                    persistance.Update(battle);
                }
                persistance.Flush();
            }
        }

        private static FleetInfo GetFleetInfo(Core.Tournament tour)
        {
            FleetInfo info;
            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                IList<Fleet> fleet = persistance.SelectById(tour.FleetId);
                if (fleet.Count == 0)
                {
                    throw new TournamentException(
                        string.Format("The fleet with id {0} is not a valid fleet", tour.FleetId));
                }
                info = new FleetInfo(fleet[0]);
            }
            return info;
        }

        #endregion private methods

    }
}
