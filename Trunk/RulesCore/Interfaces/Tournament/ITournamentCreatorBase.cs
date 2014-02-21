using System.Collections.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces
{
    /// <summary>
    /// Core function for create tournaments
    /// </summary>
    public interface ITournamentCreatorBase
    {
        /// <summary>
        /// Creates a tournament
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
        /// <returns>The created Tournament</returns>
        OrionsBelt.Core.Tournament CreateTournament(string name, string prize, int credits, int fleetId, bool isPublic, 
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo);

        /// <summary>
        /// Get the last stage battles
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        IList<Battle> BattlesFromLastStage(int tournamentId);

        /// <summary>
        /// Indicates if a tournament already enter in playoff stages
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>boolean if true is in group stage</returns>
        bool IsInGroupStage(int tournamentId);

        /// <summary>
        /// Gets groups that are active (groups last stage)
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>The list of groups</returns>
        IList<PlayersGroupStorage> GetGroups(int tournamentId);

        /// <summary>
        /// Gets the max Sequence Number for a tournament
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Max sequence number</returns>
        int GetMaxBattleSequenceNumber(int tournamentId);

        /// <summary>
        /// Indicates if is ready to begin an eliminatory stage
        /// </summary>
        /// <param name="tournament">Tournament to analyse</param>
        /// <returns>boolean if true is in group stage</returns>
        bool IsToBeginPlayoffs(Tournament tournament);

        /// <summary>
        /// Get the last stage of group fase
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        int GetLastGroupStage(int tournamentId);

        /// <summary>
        /// End the tournament, updating stats
        /// </summary>
        /// <param name="tournament">Tournament</param>
        /// <param name="battle">Final tournament battle</param>
        /// <returns>A list with [Principal, prize]</returns>
        IDictionary<PrincipalTournament, int> EndTournament(Tournament tournament, Battle battle);

        /// <summary>
        /// End the tournament, updating stats
        /// </summary>
        /// <param name="tournament">Tournament</param>
        /// <param name="prins">Order principals in the final group</param>
        void EndTournament(Tournament tournament, IList<PrincipalTournament> prins);

        /// <summary>
        /// Get the last stage number of unfinish battles (only playoff stage)
        /// </summary>
        /// <param name="tour">Tournament to analyse</param>
        /// <returns>Number of unfinish battles</returns>
        int GetLastStageUnfinishBatlleNum(Tournament tour);

        /// <summary>
        /// Get the last group stage number of unfinish battles (only group stage)
        /// </summary>
        /// <param name="tour">Tournament to analyse</param>
        /// <returns>Number of unfinish battles</returns>
        int GetLastGroupStageUnfinishBatlleNum(Tournament tour);
        
    }
}
