using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.TournamentCore.TournamentCreators
{
    public class Ladder4Creator : LadderBase, ILadderCreator
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
            base.ValidateData(players, fleet, makeValidations, 4, true);
        }

        /// <summary>
        /// Update LadderInfo information
        /// </summary>
        /// <param name="info">LadderInfo list</param>
        /// <param name="battleId">Id of the battle</param>
        /// <returns></returns>
        public void PutPlayersInBattle(IList<Principal> info, int battleId)
        {

            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                info[0].Team.IsInBattle = battleId;
                info[2].Team.IsInBattle = battleId;
                persistance.Update(info[0].Team);
                persistance.Update(info[2].Team);
            }
        }

        #endregion
    }
}
