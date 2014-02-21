using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.TournamentCore.TournamentCreators
{
    public class Regicide4Creator : TournamentBase, ITournament4Creator
    {

        #region ITournamentCreator Members

        public Tournament CreateTournament(string name, string prize, int credits, int fleetId, bool isPublic, bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo)
        {
            ValidateData(minPlayers, maxPlayers, fleetId);
            Tournament tour;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.Create();
                CreateBaseTournament(tour, name, prize, credits, fleetId, isPublic, isSurvival, turnTime, subTime, maxPlayers, minPlayers, toPlayoff, maxElo, minElo);
                tour.TournamentType = BattleType.Regicide4.ToString();
                persistance.Update(tour);
                persistance.Flush();
            }
            return tour;
        }

        public PrincipalTournament RegistTeam(TeamStorage team, int tournamentId)
        {
            return RegistTeamBase(team, tournamentId);
        }

        public bool IsTeamRegisted(TeamStorage team, int tournamentId)
        {
            return IsTeamRegistedBase(team, tournamentId);
        }       

        /// <summary>
        /// Generate Groups for tournament.
        /// </summary>
        /// <param name="players">List of player in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <returns></returns>
        public List<List<TeamStorage>> GenerateTeamGroups(IList<PrincipalTournament> players, int stage)
        {
            return base.GenerateTeamGroupsBase(players, stage);
        }

        public IList<Battle> BattlesFromLastStage(int tournamentId)
        {
            return base.BattlesFromLastStageBase(tournamentId);
        }

        public bool IsInGroupStage(int tournamentId)
        {
            return base.IsInGroupStageBase(tournamentId);
        }

        public IList<PlayersGroupStorage> GetGroups(int tournamentId)
        {
            return base.GetGroupsBase(tournamentId);
        }

        public List<List<TeamStorage>> GetTeamDuos(IList<PrincipalTournament> principals)
        {
            return base.GetTeamDuosBase(principals);
        }

        public List<List<TeamStorage>> GetTeamDuos(IList<Battle> battles)
        {
            return base.GetTeamDuosBase(battles);
        }
        
        public int GetMaxBattleSequenceNumber(int tournamentId)
        {
            return base.GetMaxBattleSequenceNumberBase(tournamentId);
        }

        public bool IsToBeginPlayoffs(Tournament tournament)
        {
            return base.IsToBeginPlayoffsBase(tournament);
        }

        public IList<PrincipalTournament> GetGroupTeamsThatPass(Tournament tournament)
        {
            return base.GetGroupTeamsThatPassBase(tournament);
        }

        public int GetLastGroupStage(int tournamentId)
        {
            return base.GetLastGroupStageBase(tournamentId);
        }

        public IDictionary<PrincipalTournament, int> EndTournament(Tournament tournament, Battle battle)
        {
            return EndTournamentBase(tournament, battle);
        }

        public void EndTournament(Tournament tournament, IList<PrincipalTournament> prins)
        {
            EndTournamentBase(tournament, prins);
        }

        public int GetLastStageUnfinishBatlleNum(Tournament tour)
        {
            return base.GetLastStageUnfinishBatlleNumBase(tour);
        }

        public int GetLastGroupStageUnfinishBatlleNum(Tournament tour)
        {
            return base.GetLastGroupStageUnfinishBatlleNumBase(tour);
        }
        #endregion
    }
}
