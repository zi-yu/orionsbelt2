using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.TournamentCore.TournamentCreators
{
    public class LadderCreator : LadderBase, ILadderCreator
    {
        #region ITournamentCreator Members


        /// <summary>
        /// Creates a Ladder battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="makeValidations">Create battle with or without validations</param>
        /// <returns>Player's LadderInfo</returns>
        public void ValidateData(List<Principal> players, IFleetInfo fleet, bool makeValidations)
        {
            base.ValidateData(players, fleet, makeValidations, 2, false);
        }

        /// <summary>
        /// Update LadderInfo information
        /// </summary>
        /// <param name="info">LadderInfo list</param>
        /// <param name="battleId">Id of the battle</param>
        /// <returns></returns>
        public void PutPlayersInBattle(IList<Principal> info, int battleId)
        {
            base.BasePutPlayersInBattle(info, battleId);
        }

        #endregion
    }
}
