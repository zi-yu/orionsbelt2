using System;
using System.Collections.Generic;
using System.Text;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;

namespace OrionsBelt.TournamentCore.TournamentCreators
{
    public abstract class LadderBase
    {
        #region public fields

        protected static readonly int maxDifference = 5;

        #endregion public fields

        #region protected methods

        /// <summary>
        /// Creates a Ladder battle
        /// </summary>
        /// <param name="players">Players that enter in the battle</param>
        /// <param name="fleet">Unique fleet, equal for all the players</param>
        /// <param name="makeValidations">Create battle with or without validations</param>
        /// <param name="numberPlayers">Number of players expected</param>
        /// <param name="isTeam">True if is a team battle</param>
        /// <returns></returns>
        protected virtual void ValidateData(List<Principal> players, IFleetInfo fleet, bool makeValidations, int numberPlayers, bool isTeam)
         {
             if (makeValidations)
             {
                 if (numberPlayers != players.Count)
                 {
                     throw new ListCountException(numberPlayers, players.Count);
                 }
                 ValidatePlayers(players, isTeam);
             }
         }
        protected virtual void BasePutPlayersInBattle(IList<Principal> info, int battleId)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                foreach (Principal ladder in info)
                {
                    ladder.IsInBattle = battleId;
                    persistance.Update(ladder);
                }
                persistance.Flush();
            }
        }

        #endregion protected methods

        #region private methods

        private static void ValidatePlayers(IList<Principal> players, bool isTeam)
        {
            StringBuilder where = new StringBuilder();
            where.Append("(1!=1");
            foreach(Principal player in players)
            {
                if (!isTeam)
                {
                    where.AppendFormat(" or PrincipalTeamId={0}", player.Id);
                }else
                {
                    where.AppendFormat(" or PrincipalTeamId={0}", player.Team.Id);
                }
            }
            where.Append(")");
            long count;
            int min, max;
            if (!isTeam)
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    min = Math.Min(players[0].LadderPosition, players[1].LadderPosition);
                    max = Math.Max(players[0].LadderPosition, players[1].LadderPosition);
                    count = persistance.ExecuteScalar("select count(*) from SpecializedPrincipal where LadderActive=true and LadderPosition between {0} and {1}", min, max);
                    --count;
                }
                ValidatePlayerConditions(players);
                ValidateDates(players, min, max);
            }
            else
            {
                using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
                {
                    min = Math.Min(players[0].Team.LadderPosition, players[2].Team.LadderPosition);
                    max = Math.Max(players[0].Team.LadderPosition, players[2].Team.LadderPosition);
                    count =
                        persistance.ExecuteScalar(
                            "select count(*) from SpecializedTeamStorage where LadderActive=true and LadderPosition between {0} and {1}",
                            min, max);
                    --count;
                }
                IList<TeamStorage> teams = new List<TeamStorage>();
                teams.Add(players[0].Team);
                teams.Add(players[2].Team);
                ValidateTeamsConditions(teams);
                ValidateDates(teams, min, max);
            }

            

            if(count > maxDifference)
            {
                throw new LadderException(maxDifference, count);
            }
        }

        private static void ValidateDates(IEnumerable<Principal> info, int min, int max)
        {
            foreach (Principal ladderInfo in info)
            {
                if (min == ladderInfo.LadderPosition && ladderInfo.RestUntil > Clock.Instance.Tick)
                {
                    throw new LadderException(ladderInfo, true);
                }

                if (max == ladderInfo.LadderPosition && ladderInfo.StoppedUntil > Clock.Instance.Tick)
                {
                    throw new LadderException(ladderInfo, false);
                }
            }
        }

        private static void ValidateDates(IEnumerable<TeamStorage> info, int min, int max)
        {
            foreach (TeamStorage ladderInfo in info)
            {
                if (min == ladderInfo.LadderPosition && ladderInfo.RestUntil > Clock.Instance.Tick)
                {
                    throw new LadderException(ladderInfo, true);
                }

                if (max == ladderInfo.LadderPosition && ladderInfo.StoppedUntil > Clock.Instance.Tick)
                {
                    throw new LadderException(ladderInfo, false);
                }
            }
        }


        private static void ValidatePlayerConditions(IEnumerable<Principal> info)
        {
            foreach (Principal ladderInfo in info)
            {
                if(0 != ladderInfo.IsInBattle || !ladderInfo.LadderActive)
                {
                    throw new LadderException(ladderInfo);
                }
            }
        }

        private static void ValidateTeamsConditions(IEnumerable<TeamStorage> info)
        {
            foreach (TeamStorage ladderInfo in info)
            {
                if (0 != ladderInfo.IsInBattle || !ladderInfo.LadderActive)
                {
                    throw new LadderException(ladderInfo);
                }
            }
        }

        #endregion private methods
    }
}
