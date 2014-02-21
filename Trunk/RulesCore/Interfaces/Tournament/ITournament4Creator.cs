using System.Collections.Generic;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces
{
    /// <summary>
    /// Core function for create single tournaments
    /// </summary>
    public interface ITournament4Creator : ITournamentCreatorBase
    {
        /// <summary>
        /// Get the list of teams for the next playoff stage
        /// </summary>
        /// <param name="principals">List of player order by group position</param>
        /// <returns>A list that contains a list of Teams for each battle</returns>
        List<List<TeamStorage>> GetTeamDuos(IList<PrincipalTournament> principals);

        /// <summary>
        /// Get the list os teams for the next playoff stage
        /// </summary>
        /// <param name="battles">Battles of the previous stage</param>
        /// <returns>A list that contains a list of Pricipals for each battle</returns>
        List<List<TeamStorage>> GetTeamDuos(IList<Battle> battles);

        /// <summary>
        /// Regists a player
        /// </summary>
        /// <param name="team">Team to be register</param>
        /// <param name="tournamentId">The id of th tournament to do the registration</param>
        /// <returns>Register info</returns>
        PrincipalTournament RegistTeam(TeamStorage team, int tournamentId);

        /// <summary>
        /// Test if team is registed
        /// </summary>
        /// <param name="team">Team to be tested</param>
        /// <param name="tournamentId">The id of th tournament to do the registration</param>
        /// <returns>True if the team is already in the tournament</returns>
        bool IsTeamRegisted(TeamStorage team, int tournamentId);

        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="players">List of teams in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <returns>A list that contains a list of teams for each group</returns>
        List<List<TeamStorage>> GenerateTeamGroups(IList<PrincipalTournament> players, int stage);

        /// <summary>
        /// Gets the teams that will pass to next stage, order by classification
        /// </summary>
        /// <param name="tournament">Tournament to analyse</param>
        /// <returns>List of PrincipalTournament Elements</returns>
        IList<PrincipalTournament> GetGroupTeamsThatPass(Tournament tournament);
    }
}
