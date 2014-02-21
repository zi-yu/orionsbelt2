using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;

namespace OrionsBelt.RulesCore.Interfaces
{
    /// <summary>
    /// Core function for create tournaments
    /// </summary>
    public interface ILadderCreator
    {
        /// <summary>
        /// Creates a Ladder battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="makeValidations">Create battle with or without validations</param>
        /// <returns></returns>
        void ValidateData(List<Principal> players, IFleetInfo fleet, bool makeValidations);

        /// <summary>
        /// Update LadderInfo information
        /// </summary>
        /// <param name="info">LadderInfo list</param>
        /// <param name="battleId">Id of the battle</param>
        /// <returns></returns>
        void PutPlayersInBattle(IList<Principal> info, int battleId);

    }
}
