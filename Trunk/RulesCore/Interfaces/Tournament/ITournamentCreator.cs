using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.Generic;

namespace OrionsBelt.RulesCore.Interfaces
{
    /// <summary>
    /// Core function for create single tournaments
    /// </summary>
    public interface ITournamentCreator : ITournamentCreatorBase
    {
        /// <summary>
        /// Get the list os principals for the next playoff stage
        /// </summary>
        /// <param name="principals">List of player order by group position</param>
        /// <returns>A list that contains a list of Pricipals for each battle</returns>
        List<List<Principal>> GetPrincipalDuos(IList<PrincipalTournament> principals);

        /// <summary>
        /// Get the list os principals for the next playoff stage
        /// </summary>
        /// <param name="battles">Battles of the previous stage</param>
        /// <returns>A list that contains a list of Pricipals for each battle</returns>
        List<List<Principal>> GetPrincipalDuos(IList<Battle> battles);

        /// <summary>
        /// Regists a player
        /// </summary>
        /// <param name="principal">Principal to be register</param>
        /// <param name="tournamentId">The id of th tournament to do the registration</param>
        /// <returns>Register info</returns>
        PrincipalTournament RegistPlayer(Principal principal, int tournamentId);

        /// <summary>
        /// Test is player is registed
        /// </summary>
        /// <param name="principal">Principal to be register</param>
        /// <param name="tournamentId">The id of th tournament to do the registration</param>
        /// <returns>True if the player is already in the tournament</returns>
        bool IsPlayerRegisted(Principal principal, int tournamentId);

        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="players">List of player in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <returns>A list that contains a list of Pricipals for each group</returns>
        List<List<Principal>> GenerateGroups(IList<PrincipalTournament> players, int stage);

        /// <summary>
        /// Gets the players that will pass to next stage, order by classification
        /// </summary>
        /// <param name="tournament">Tournament to analyse</param>
        /// <returns>List of PrincipalTournament Elements</returns>
        IList<PrincipalTournament> GetGroupPlayerThatPass(Tournament tournament, List<List<GroupPlayer>> groupList);
    }
}
