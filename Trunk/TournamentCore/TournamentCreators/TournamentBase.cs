
using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.TournamentCore.Exceptions;
using System.Collections;

namespace OrionsBelt.TournamentCore.TournamentCreators
{
    public abstract class TournamentBase
    {
        #region Protected Methods

        protected int GetLastGroupStageUnfinishBatlleNumBase(Tournament tour)
        {
            int toReturn = 0;

            string lastStage =
                NumericUtils.GetDouble("0," + GetLastGroupStageBase(tour.Id), ",").ToString().Replace(',', '.');

            IList<Battle> list;
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                list = persistance.TypedQuery("from SpecializedBattle b where b.TournamentNHibernate.Id = {0} and b.SeqNumber = {1}", tour.Id, lastStage);
            }   
            foreach (Battle battle in list)
            {
                if (!battle.HasEnded)
                {
                    ++toReturn;
                }
            }

            return toReturn;
        }

        protected void ValidateData(int minPlayers, int maxPlayers, int fleetId)
        {
            if (maxPlayers < minPlayers && maxPlayers != 0)
            {
                throw new TournamentException("Maximum number of players can't can't be less that the minimum.");
            }

            if (0 == fleetId)
            {
                throw new TournamentException("No fleet defined to this tournament.");
            }
        }

        protected void CreateBaseTournament(Tournament tour,string name, string prize, int credits, int fleetId, bool isPublic, 
            bool isSurvival, int turnTime, int subTime, int maxPlayers, int minPlayers, int toPlayoff, int maxElo, int minElo)
        {
            tour.Name = name;
            tour.Prize = prize;
            tour.CostCredits = credits;
            tour.FleetId = fleetId;
            tour.IsPublic = isPublic;
            tour.IsSurvival = isSurvival;
            tour.TurnTime = turnTime;
            tour.SubscriptionTime = subTime;
            tour.MaxPlayers = maxPlayers;
            tour.MinPlayers = minPlayers;
            tour.NPlayersToPlayoff = toPlayoff;
            tour.StartTime = DateTime.Now;
            tour.EndDate = tour.StartTime;
            tour.MaxElo = maxElo;
            tour.MinElo = minElo;
            tour.WarningTick = 0;
            tour.IsCustom = true;
        }

        protected PrincipalTournament RegistPlayerBase(Principal player, int tournamentId)
        {
            IList<Tournament> tour = ValidateRegistration(tournamentId, player);

            return RegistPlayer(player, tour);
        }

        protected PrincipalTournament RegistTeamBase(TeamStorage team, int tournamentId)
        {
            IList<Tournament> tour = ValidateRegistration(tournamentId, team);

            return RegistTeam(team, tour);
        }

        protected bool IsPlayerRegistedBase(Principal principal, int tournamentId)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                IList<PrincipalTournament> prinInTour = persistance.TypedQuery("from SpecializedPrincipalTournament as pt where pt.TournamentNHibernate.Id={0} and pt.PrincipalNHibernate.Id={1}",
                                                                            tournamentId, principal.Id);
                if(prinInTour.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        protected bool IsTeamRegistedBase(TeamStorage team, int tournamentId)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                IList<PrincipalTournament> prinInTour = persistance.TypedQuery("from SpecializedPrincipalTournament as pt where pt.TeamNHibernate.Id={0} and pt.PrincipalNHibernate.Id={1}",
                                                                            tournamentId, team.Id);
                if (prinInTour.Count > 0)
                {
                    return true;
                }
                return false;
            }
        }

        /// <summary>
        /// Generate Groups for tournament
        /// </summary>
        /// <param name="players">List of player in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <returns>A list that contains a list of Pricipals for each group</returns>
        protected List<List<Principal>> GenerateGroupsBase(IList<PrincipalTournament> players, int stage)
        {
            int groupNum = GetGroupNum(players);

            List<List<PrincipalTournament>> pots = GetPots(players, groupNum);

            Tournament tour = players[0].Tournament;

            List<PlayersGroupStorage> groups = new List<PlayersGroupStorage>(groupNum);
            List<List<Principal>> principals = new List<List<Principal>>(groupNum);
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                InitGroup(groupNum, persistance, stage, tour, groups);

                foreach(PlayersGroupStorage group in groups)
                {
                    List<Principal> principalGroup = new List<Principal>();
                    foreach(List<PrincipalTournament> potPlayers in pots)
                    {
                        if (potPlayers.Count == 0)
                            break;
                        PrincipalTournament pt = GetRandomAndRemove(potPlayers);
                        
                        InitGroupPoints(stage, pt);
                        Principal curr = pt.Principal;
                        if(!Server.IsInTests)
                            group.PlayersIds += string.Format("|{0}|", curr.Id);
                        else
                            group.PlayersIds += string.Format("|{0}|", curr.EloRanking);

                        principalGroup.Add(curr);
                    }
                    Console.WriteLine("Group {0}: {1}",group.GroupNumber,group.PlayersIds);
                    principals.Add(principalGroup);

                    persistance.Update(group);
                    //tour.Groups.Add(group);
                }
                persistance.Flush();
            }
            /*
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                persistance.Update(tour);
                persistance.Flush();
            }
             */
            return principals;
        }

        /// <summary>
        /// Generate Groups for teams tournament
        /// </summary>
        /// <param name="players">List of teams in the tournament, sorted descending by Eloranking</param>
        /// <param name="stage">The stage in the tournament</param>
        /// <returns>A list that contains a list of teams for each group</returns>
        protected List<List<TeamStorage>> GenerateTeamGroupsBase(IList<PrincipalTournament> players, int stage)
        {
            int groupNum = GetGroupNum(players);

            List<List<PrincipalTournament>> pots = GetPots(players, groupNum);

            Tournament tour = players[0].Tournament;

            List<PlayersGroupStorage> groups = new List<PlayersGroupStorage>(groupNum);
            List<List<TeamStorage>> teams = new List<List<TeamStorage>>(groupNum);
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                InitGroup(groupNum, persistance, stage, tour, groups);

                foreach (PlayersGroupStorage group in groups)
                {
                    List<TeamStorage> teamGroup = new List<TeamStorage>();
                    foreach (List<PrincipalTournament> potPlayers in pots)
                    {
                        if (potPlayers.Count == 0)
                            break;
                        PrincipalTournament pt = GetRandomAndRemove(potPlayers);

                        InitGroupPoints(stage, pt);
                        TeamStorage curr = pt.Team;
                        if (!Server.IsInTests)
                            group.PlayersIds += string.Format("|{0}|", curr.Id);
                        else
                            group.PlayersIds += string.Format("|{0}|", curr.EloRanking);

                        teamGroup.Add(curr);
                    }
                    Console.WriteLine("Group {0}: {1}", group.GroupNumber, group.PlayersIds);
                    teams.Add(teamGroup);

                    persistance.Update(group);
                    //tour.Groups.Add(group);
                }
                persistance.Flush();
            }
            /*
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                persistance.Update(tour);
                persistance.Flush();
            }
             */
            return teams;
        }


        /// <summary>
        /// Get the list os principals for the next playoff stage
        /// </summary>
        /// <param name="principals">List of player order by group position</param>
        /// <returns>A list that contains a list of Pricipals for each battle</returns>
        protected List<List<Principal>> GetPrincipalDuosBase(IList<PrincipalTournament> principals)
        {
            if(principals.Count%2 != 0)
            {
                throw new TournamentException("Wrong number of principals to generate playoffs");
            }

            List<List<Principal>> toReturn = new List<List<Principal>>(principals.Count / 2);

            for (int iter = 0; iter < principals.Count / 2; ++iter )
            {
                List<Principal> pair = new List<Principal>(2);
                pair.Add(principals[iter].Principal);
                pair.Add(principals[principals.Count-iter-1].Principal);
                toReturn.Add(pair);
            }
            return toReturn;
        }

        /// <summary>
        /// Get the list of teams for the next playoff stage
        /// </summary>
        /// <param name="principals">List of player order by group position</param>
        /// <returns>A list that contains a list of Teams for each battle</returns>
        protected List<List<TeamStorage>> GetTeamDuosBase(IList<PrincipalTournament> principals)
        {
            if (principals.Count % 2 != 0)
            {
                throw new TournamentException("Wrong number of principals to generate playoffs");
            }

            List<List<TeamStorage>> toReturn = new List<List<TeamStorage>>(principals.Count / 2);

            for (int iter = 0; iter < principals.Count / 2; ++iter)
            {
                List<TeamStorage> pair = new List<TeamStorage>(2);
                pair.Add(principals[iter].Team);
                pair.Add(principals[principals.Count - iter - 1].Team);
                toReturn.Add(pair);
            }

            return toReturn;
        }

        /// <summary>
        /// Get the list os principals for the next playoff stage
        /// </summary>
        /// <param name="battles">Battles of the previous stage</param>
        /// <returns>A list that contains a list of Pricipals for each battle</returns>
        protected List<List<Principal>> GetPrincipalDuosBase(IList<Battle> battles)
        {
            if (battles.Count % 2 != 0)
            {
                throw new TournamentException("Wrong number of principals to generate playoffs");
            }
            List<List<Principal>> toReturn = new List<List<Principal>>(battles.Count/2);

            int processedPlayers = 0;
            for (int iter = 1; processedPlayers < battles.Count; ++iter )
            {
                Principal player = GetBattlePrincipal(iter, battles);
                if(null != player)
                {
                    Principal player2 = GetBattlePrincipal(++iter, battles);
                    if(null == player2)
                    {
                        throw new TournamentException(string.Format("Can't find oponent for principal {0}", player.Id));
                    }
                    List<Principal> pair = new List<Principal>(2);
                    pair.Add(player);
                    pair.Add(player2);
                    toReturn.Add(pair);
                    processedPlayers += 2;
                }
            }
            return toReturn;
        }

        /// <summary>
        /// Get the list of teams for the next playoff stage
        /// </summary>
        /// <param name="battles">Battles of the previous stage</param>
        /// <returns>A list that contains a list of teams for each battle</returns>
        protected List<List<TeamStorage>> GetTeamDuosBase(IList<Battle> battles)
        {
            if (battles.Count % 2 != 0)
            {
                throw new TournamentException("Wrong number of principals to generate playoffs");
            }
            List<List<TeamStorage>> toReturn = new List<List<TeamStorage>>(battles.Count / 2);

            int processedPlayers = 0;
            for (int iter = 1; processedPlayers < battles.Count; ++iter)
            {
                TeamStorage team = GetBattleTeam(iter, battles);

                if (null != team)
                {
                    List<TeamStorage> pair = new List<TeamStorage>(2);
                    TeamStorage team2 = GetBattleTeam(++iter, battles);
                    if (null != team2)
                    {
                        pair.Add(team2);
                        //throw new TournamentException(string.Format("Can't find oponent for principal {0}", team.Id));
                    }
                    else
                    {
                        pair.Add(null);
                    }
                    
                    pair.Add(team); 
                    toReturn.Add(pair);
                    processedPlayers += 2;
                }
            }
            return toReturn;
        }

        protected void EndTournamentBase(Tournament tournament, IList<PrincipalTournament> prins)
        {
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tournament.EndDate = DateTime.Now;
                persistance.Update(tournament);
            }

            int stage = GetLastGroupStageBase(tournament.Id);

            int prize = 1250;
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                persistance.StartTransaction();

                prins[0].EliminatedInFase = "Winner";
                prins[0].Principal.Credits += Convert.ToInt32(prize * 0.4);
                prins[0].HasEliminated = true;
                persistance.Update(prins[0]);

                prins[1].EliminatedInFase = "Stage" + (stage + 1);
                prins[1].Principal.Credits += Convert.ToInt32(prize * 0.3);
                prins[1].HasEliminated = true;
                persistance.Update(prins[1]);

                prins[2].EliminatedInFase = "Stage" + (stage + 1);
                prins[2].Principal.Credits += Convert.ToInt32(prize * 0.2);
                prins[2].HasEliminated = true;
                persistance.Update(prins[2]);

                prins[3].EliminatedInFase = "Stage" + (stage + 1);
                prins[3].Principal.Credits += Convert.ToInt32(prize * 0.1);
                prins[3].HasEliminated = true;
                persistance.Update(prins[3]);

                for(int iter = 4; iter < prins.Count; ++iter)
                {
                    prins[iter].EliminatedInFase = "Stage" + (stage + 1);
                    prins[iter].HasEliminated = true;
                    persistance.Update(prins[iter]); 
                }

                persistance.CommitTransaction();
            }
        }

        protected IDictionary<PrincipalTournament,int> EndTournamentBase(Tournament tournament, Battle battle)
        {
            IDictionary<PrincipalTournament, int> toReturn = new Dictionary<PrincipalTournament, int>();
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tournament.EndDate = DateTime.Now;
                persistance.Update(tournament);
            }
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                foreach (PlayerBattleInformation information in battle.PlayerInformation)
                {
                    IList<PrincipalTournament> principal;
                    if (tournament.TournamentType == "TotalAnnihalation" ||
                        tournament.TournamentType == "Domination" ||
                        tournament.TournamentType == "Regicide")
                    {
                        principal = persistance.TypedQuery(
                            "from SpecializedPrincipalTournament e where e.PrincipalNHibernate.Id = {0} and e.TournamentNHibernate.Id = {1}",
                            information.Owner, battle.Tournament.Id);
                    }
                    else
                    {
                        principal = persistance.TypedQuery(
                            "from SpecializedPrincipalTournament e where e.TeamNHibernate.Name = '{0}' and e.TournamentNHibernate.Id = {1}",
                            information.TeamName, battle.Tournament.Id);
                    }

                    
                    using (IPrincipalTournamentPersistance persistance2 = Persistance.Instance.GetPrincipalTournamentPersistance(persistance))
                    {
                        persistance2.StartTransaction();
                        if (information.HasLost)
                        {
                            int prize = 250;
                            if (!tournament.IsCustom)
                            {
                                prize = 0;
                            }
                            principal[0].EliminatedInFase = "Final" + 1;
                            principal[0].Principal.Credits += prize;
                            toReturn.Add(principal[0], prize);
                        }
                        else
                        {
                            int prize = 1000;
                            if (!tournament.IsCustom)
                            {
                                prize = 0;
                            }
                            principal[0].EliminatedInFase = "Winner";
                            principal[0].Principal.Credits += prize;
                            toReturn.Add(principal[0], prize);
                        }
                        persistance2.CommitTransaction();

                        principal[0].HasEliminated = true;
                        principal[0].EliminatedInBattleId = battle.Id;
                        persistance.Update(principal[0]);
                    }
                }
                persistance.Flush();
            }
            return toReturn;
        }

        /// <summary>
        /// Get the last stage of the tournament. 0 means group stage
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        protected int GetLastStage(int tournamentId)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                IList list = persistance.Query("select max(b.SeqNumber) from SpecializedBattle b where b.TournamentNHibernate.Id = {0}", tournamentId);
                
                if(list[0] == null)
                {
                    return -1;
                }

                double res = (double) list[0];
                if (0 == Math.Floor(res))
                {
                    return 0; 
                }
                return NumericUtils.GetDecimalPart(res);
            }
        }

        /// <summary>
        /// Get the last stage of the tournament. 0 means group stage
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        protected int GetLastGroupStageBase(int tournamentId)
        {
            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                IList ret = persistance.Query("select max(g.EliminatoryNumber) from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0}", tournamentId);
                return Convert.ToInt32(ret[0]);
            }
        }

        /// <summary>
        /// Gets the max Sequence Number for a tournament
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Max sequence number</returns>
        protected int GetMaxBattleSequenceNumberBase(int tournamentId)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                IList list = persistance.Query("select max(b.SeqNumber) from SpecializedBattle b where b.TournamentNHibernate.Id = {0}", tournamentId);
                double res = (double)list[0];
                return (int) res;
            }
        }

        /// <summary>
        /// Get the last stage battles (only playoff stage)
        /// </summary>
        /// <param name="tournamentId">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        protected IList<Battle> BattlesFromLastStageBase(int tournamentId)
        {
            IList<Battle> toReturn = new List<Battle>();
            int lastStage = GetLastStage(tournamentId);

            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
            {
                IList<Battle> list = persistance.TypedQuery("from SpecializedBattle b where b.TournamentNHibernate.Id = {0} and b.SeqNumber >= 1", tournamentId);
                foreach (Battle battle in list)
                {
                    int stage = NumericUtils.GetDecimalPart(battle.SeqNumber);
                    if(stage == lastStage)
                    {
                        toReturn.Add(battle);
                    }
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Get the last stage number of unfinish battles (only playoff stage)
        /// </summary>
        /// <param name="tour">Tournament to analyse</param>
        /// <returns>Number that represents the stage</returns>
        protected int GetLastStageUnfinishBatlleNumBase(Tournament tour)
        {
            IList<Battle> battles = BattlesFromLastStageBase(tour.Id);
            int toReturn = 0;
            foreach (Battle battle in battles)
            {
                if(!battle.HasEnded)
                {
                    ++toReturn;
                }
            }

            return toReturn;
        }


        protected bool IsInGroupStageBase(int tournamentId)
        {
            return GetLastStage(tournamentId) == 0;
        }

        protected IList<PlayersGroupStorage> GetGroupsBase(int tournamentId)
        {
            int stage = GetLastGroupStageBase(tournamentId);

            using (IPlayersGroupStoragePersistance persistance = Persistance.Instance.GetPlayersGroupStoragePersistance())
            {
                return persistance.TypedQuery("from SpecializedPlayersGroupStorage g where g.TournamentNHibernate.Id = {0} and g.EliminatoryNumber={1}", tournamentId, stage);
            }
        }

        protected bool IsToBeginPlayoffsBase(Tournament tournament)
        {
            if(tournament.NumberPassGroup != 0)
            {
                return false;
            }
            int playerToPass = GetGroupsBase(tournament.Id).Count * 3;
            return playerToPass <= tournament.NPlayersToPlayoff;
        }

        protected IList<PrincipalTournament> GetGroupTeamsThatPassBase(Tournament tournament)
        {
            IList<PlayersGroupStorage> groups = GetGroupsBase(tournament.Id);
            int stage = GetLastGroupStageBase(tournament.Id);
            List<List<GroupPlayer>> groupList = TournamentUtil.GetTeamsByGroupOrdered(groups, stage, tournament.Id);
            List<PrincipalTournament> orderedPlayers = PutListsInOne(groupList, tournament);

            int playerToPass = groups.Count * 3;
            if (IsToBeginPlayoffsBase(tournament))
            {
                int playerRequired = 2;
                while (playerRequired < playerToPass)
                {
                    playerRequired *= 2;
                }
                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    for (int iter = playerRequired; iter < orderedPlayers.Count; ++iter)
                    {
                        orderedPlayers[iter].HasEliminated = true;
                        orderedPlayers[iter].EliminatedInFase = "Stage" + (stage+1) ;
                        persistance.Update(orderedPlayers[iter]);
                    }
                    persistance.Flush();
                }

                return orderedPlayers.GetRange(0, playerRequired);
            }
            else
            {

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    for (int iter = playerToPass; iter < orderedPlayers.Count; ++iter)
                    {
                        orderedPlayers[iter].HasEliminated = true;
                        orderedPlayers[iter].EliminatedInFase = "Stage" + (stage + 1);
                        persistance.Update(orderedPlayers[iter]);
                    }
                    persistance.Flush();
                }

                return orderedPlayers.GetRange(0, playerToPass);
            }
        }

        protected IList<PrincipalTournament> GetGroupPlayerThatPassBase(Tournament tournament, List<List<GroupPlayer>> groupList)
        {
        	IList<PlayersGroupStorage> groups = GetGroupsBase(tournament.Id);
            int stage = GetLastGroupStageBase(tournament.Id);
            List<List<GroupPlayer>> tempGroupList = TournamentUtil.GetPlayersByGroupOrdered(groups, stage, tournament.Id);
            groupList.AddRange(tempGroupList);
            List<PrincipalTournament> orderedPlayers = PutListsInOne(tempGroupList, tournament);

            int playerToPass = groups.Count * 3;

            if(tournament.NumberPassGroup != 0)
            {
                int playerToPassPerGroup = tournament.NumberPassGroup;
                playerToPass = groups.Count*playerToPassPerGroup < 10 ? 10 : groups.Count*playerToPassPerGroup;
            }

            
			if(IsToBeginPlayoffsBase(tournament))
        	{
				int playerRequired = 2;
				while(playerRequired<playerToPass) {
					playerRequired *= 2;
				}
                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                   for(int iter = playerRequired; iter < orderedPlayers.Count; ++iter)
                   {
                       orderedPlayers[iter].HasEliminated = true;
                       orderedPlayers[iter].EliminatedInFase = "Stage" + (stage + 1);
                       persistance.Update(orderedPlayers[iter]);
                   }
                    persistance.Flush();
                }

				return orderedPlayers.GetRange(0, playerRequired);
        	}else {

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    for (int iter = playerToPass; iter < orderedPlayers.Count; ++iter)
                    {
                        orderedPlayers[iter].HasEliminated = true;
                        orderedPlayers[iter].EliminatedInFase = "Stage" + (stage + 1);
                        persistance.Update(orderedPlayers[iter]);
                    }
                    persistance.Flush();
                }

				return orderedPlayers.GetRange(0, playerToPass);
			}
        }

        #endregion Protected Methods

        #region Private Methods


        private void InitGroupPoints(int stage, PrincipalTournament pt)
        {
            using (IGroupPointsStoragePersistance persistance2 = Persistance.Instance.GetGroupPointsStoragePersistance())
            {
                GroupPointsStorage points = persistance2.Create();
                points.Pontuation = 0;
                points.Wins = 0;
                points.Losses = 0;
                points.Regist = pt;
                points.Stage = stage;
                persistance2.Update(points);
            }
        }

        private void InitGroup(int groupNum, IPlayersGroupStoragePersistance persistance, int stage, Tournament tour, List<PlayersGroupStorage> groups)
        {
            for (int iter = 0; iter < groupNum; ++iter)
            {
                PlayersGroupStorage group = persistance.Create();
                group.EliminatoryNumber = stage;
                group.GroupNumber = iter;
                group.Tournament = tour;
                groups.Add(group);
            }
        }

        private List<PrincipalTournament> PutListsInOne(List<List<GroupPlayer>> groupList, Tournament tournament) 
		{
            List<PrincipalTournament> toReturn = new List<PrincipalTournament>();

            SortByPositionAndAdd(groupList, tournament, toReturn);
            SortLastsAndAdd(groupList,tournament, toReturn);

            return toReturn;
		}

        private void SortLastsAndAdd(List<List<GroupPlayer>> groupList, Tournament tournament, List<PrincipalTournament> toReturn)
        {
            int playersToPass = tournament.NumberPassGroup != 0 ? tournament.NumberPassGroup : 3;

            List<GroupPlayer> toSort;
            toSort = new List<GroupPlayer>();
            foreach (List<GroupPlayer> list in groupList)
            {
                for (int iter = playersToPass; iter < list.Count; ++iter)
                {
                    toSort.Add(list[iter]);
                }
            }
            toSort.Sort();
            foreach (GroupPlayer player in toSort)
            {
                toReturn.Add(player.Player);
            }
        }

        private void SortByPositionAndAdd(List<List<GroupPlayer>> groupList,Tournament tournament, List<PrincipalTournament> toReturn)
        {
            List<GroupPlayer> toSort;
            int playersToPass = tournament.NumberPassGroup != 0 ? tournament.NumberPassGroup : 3;
            for (int iter = 0; iter < playersToPass; ++iter)
            {
                toSort = new List<GroupPlayer>();
                foreach (List<GroupPlayer> list in groupList)
                {
                    toSort.Add(list[iter]);
                }
                toSort.Sort();

                foreach (GroupPlayer player in toSort)
                {
                    toReturn.Add(player.Player);
                }
            }
        }

        private static Principal GetBattlePrincipal(int identToTest, IList<Battle> battles)
        {
            Principal toReturn = null;
            foreach(Battle battle in battles)
            {
                int identifier = (int) battle.SeqNumber;
                int stage = NumericUtils.GetDecimalPart(battle.SeqNumber);
                if(identToTest == identifier)
                {
                    foreach (PlayerBattleInformation information in battle.PlayerInformation)
                    {
                        if(!information.HasLost)
                        {
                            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                            {
                                IList<Principal> principal = persistance.SelectById(information.Owner);
                                toReturn = principal[0];
                            }
                        }
                        else
                        {
                            if (!Server.IsInTests)
                            {
                                using (
                                    IPrincipalTournamentPersistance persistance =
                                        Persistance.Instance.GetPrincipalTournamentPersistance())
                                {
                                    IList<PrincipalTournament> principal = persistance.TypedQuery(
                                        "from SpecializedPrincipalTournament e where e.PrincipalNHibernate.Id = {0} and e.TournamentNHibernate.Id = {1}",
                                        information.Owner, battle.Tournament.Id);
                                    principal[0].HasEliminated = true;
                                    principal[0].EliminatedInFase = "Final" + stage;
                                    principal[0].EliminatedInBattleId = battle.Id;
                                    persistance.Update(principal[0]);
                                    persistance.Flush();
                                }
                            }
                        }
                    }
                    return toReturn;
                }
            }
            return null;
        }

        private static TeamStorage GetBattleTeam(int identToTest, IList<Battle> battles)
        {
            TeamStorage toReturn = null;
            foreach (Battle battle in battles)
            {
                int identifier = (int)battle.SeqNumber;
                int stage = NumericUtils.GetDecimalPart(battle.SeqNumber);
                if (identToTest == identifier)
                {
                    foreach (PlayerBattleInformation information in battle.PlayerInformation)
                    {
                        if (!information.HasLost)
                        {
                            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
                            {
                                IList<TeamStorage> team = persistance.SelectByName(information.TeamName);
                                if(team.Count == 0)
                                {
                                    return null;
                                }
                                toReturn = team[0];
                            }
                        }
                        else
                        {
                            if (!Server.IsInTests)
                            {
                                using (
                                    IPrincipalTournamentPersistance persistance =
                                        Persistance.Instance.GetPrincipalTournamentPersistance())
                                {
                                    IList<PrincipalTournament> principal = persistance.TypedQuery(
                                        "from SpecializedPrincipalTournament e where e.TeamNHibernate.Name = '{0}' and e.TournamentNHibernate.Id = {1}",
                                        information.TeamName, battle.Tournament.Id);
                                    principal[0].HasEliminated = true;
                                    principal[0].EliminatedInFase ="Final"+stage;
                                    persistance.Update(principal[0]);
                                    persistance.Flush();
                                }
                            }
                        }
                    }
                    return toReturn;
                }
            }
            return null;
        }

        static readonly Random r = new Random();
        private static T GetRandomAndRemove<T>(IList<T> list)
        {
            int idx = 0; 
            if(list.Count > 1)
                idx = r.Next(list.Count - 1);
            T toReturn = list[idx];
            list.RemoveAt(idx);
            return toReturn;
        }

        private static PrincipalTournament RegistPlayer(Principal player, IList<Tournament> tour)
        {
            PrincipalTournament newOne;
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                persistance.StartTransaction();
                newOne = persistance.Create();
                newOne.HasEliminated = false;
                newOne.Principal = player;
                newOne.Tournament = tour[0];
                persistance.Update(newOne);

                if (0 < tour[0].CostCredits)
                {
                    using (
                        IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        player.Credits -= tour[0].CostCredits;
                        persistance2.Update(player);
                    }
                }

                using (ITournamentPersistance persistance2 = Persistance.Instance.GetTournamentPersistance(persistance))
                {
                    tour[0].Regists.Add(newOne);
                    persistance2.Update(tour[0]);
                    
                }
                persistance.CommitTransaction();
            }

            return newOne;
        }

        private static PrincipalTournament RegistTeam(TeamStorage team, IList<Tournament> tour)
        {
            PrincipalTournament newOne;
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                newOne = persistance.Create();
                newOne.HasEliminated = false;
                newOne.Team = team;
                newOne.Tournament = tour[0];
                persistance.Update(newOne);

                if (0 < tour[0].CostCredits)
                {
                    using (
                        IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                    {
                        team.Principals[0].Credits -= tour[0].CostCredits/2;
                        team.Principals[1].Credits -= tour[0].CostCredits/2;
                        persistance2.Update(team.Principals[0]);
                        persistance2.Update(team.Principals[1]);
                    }
                }

                using (ITournamentPersistance persistance2 = Persistance.Instance.GetTournamentPersistance(persistance))
                {
                    //tour[0].Principals.Add(newOne);
                    persistance2.Update(tour[0]);
                    persistance2.Flush();
                }
            }

            return newOne;
        }

        private static IList<Tournament> ValidateRegistration(int tournamentId, Principal player)
        {
            IList<Tournament> tour;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.SelectById(tournamentId);

                if (tour[0].PaymentsRequired > 0)
                {
                    long count = persistance.ExecuteScalar("select count(e) from SpecializedPayment e where e.VerifyState='Verified' and e.PrincipalId={0} and(e.Parameters<>'PARTIAL' or e.Parameters is null)",
                        player.Id);

                    if (tour[0].PaymentsRequired > count)
                    {
                        throw new PaymentException(tour[0].PaymentsRequired.ToString());
                    }
                }

                if (tour.Count == 0)
                {
                    throw new TournamentException("Is not a valid tournament.");
                }
                
                if (tour[0].CreatedDate != tour[0].EndDate || tour[0].CreatedDate != tour[0].StartTime)
                {
                    throw new TournamentException(string.Format("This tournament is no longer in registation fase. BeginDate:{0} EndDate:{1} StartTime:{2}", tour[0].CreatedDate, tour[0].EndDate, tour[0].StartTime));
                }
                
                if ((tour[0].MaxElo != 0 && tour[0].MaxElo < player.EloRanking) || 
                    (tour[0].MinElo != 0 && tour[0].MinElo > player.EloRanking))
                {
                    throw new ELOException("The elo of the player is not allowed");
                }

                if (tour[0].CostCredits > player.Credits)
                {
                    throw new OrionsException("Not enough credits.");
                }

                if (tour[0].MaxPlayers <= tour[0].Regists.Count && 0 != tour[0].MaxPlayers)
                {
                    throw new SoldOutException("Tournament sold out");
                }

                
                /*
                foreach (PrincipalTournament principal in tour[0].Principals)
                {
                    if(principal.Principal.Id == player.Id)
                    {
                        throw new TournamentException("This player is already in the tournament.");
                    }
                }
                 */

                using (IPrincipalTournamentPersistance persistance2 = Persistance.Instance.GetPrincipalTournamentPersistance(persistance))
                {
                    long count = persistance2.ExecuteScalar("select count(e) from SpecializedPrincipalTournament e where e.PrincipalNHibernate.Id = {0} and e.TournamentNHibernate.Id = {1}", player.Id, tour[0].Id);
                    if (count != 0)
                    {
                        throw new TournamentException("This player is already in the tournament.");
                    }
                }

                
            }
            return tour;
        }

        private static IList<Tournament> ValidateRegistration(int tournamentId, TeamStorage team)
        {
            IList<Tournament> tour;
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.SelectById(tournamentId);

                if (tour.Count == 0)
                {
                    throw new TournamentException("Is not a valid tournament.");
                }

                if (tour[0].CreatedDate != tour[0].EndDate || tour[0].CreatedDate != tour[0].StartTime)
                {
                    throw new TournamentException(string.Format("This tournament is no longer in registation fase. BeginDate:{0} EndDate:{1} StartTime:{2}", tour[0].CreatedDate, tour[0].EndDate, tour[0].StartTime));
                }

                if (tour[0].CostCredits > team.Principals[0].Credits / 2 || tour[0].CostCredits > team.Principals[1].Credits / 2)
                {
                    throw new TournamentException("Not enough credits.");
                }

                using (IPrincipalTournamentPersistance persistance2 = Persistance.Instance.GetPrincipalTournamentPersistance(persistance))
                {
                    long count = persistance2.ExecuteScalar("select count(e) from SpecializedPrincipalTournament e where e.TeamNHibernate.Id = {0} and e.TournamentNHibernate.Id = {1}", team.Id, tour[0].Id);
                    if (count != 0)
                    {
                        throw new TournamentException("This team is already in the tournament.");
                    }
                }
            }
            return tour;
        }

        private static List<List<PrincipalTournament>> GetPots(IList<PrincipalTournament> players, int groupNum)
        {
            List<List<PrincipalTournament>> pots = new List<List<PrincipalTournament>>(10);
            List<PrincipalTournament> pot = new List<PrincipalTournament>(groupNum);
            for (int iter = 0; iter < players.Count; ++iter)
            {
                if (0 == iter % groupNum && 0 != iter)
                {
                    pots.Add(pot);
                    pot = new List<PrincipalTournament>(groupNum);
                }
                pot.Add(players[iter]);
            }
            pots.Add(pot);
            return pots;
        }

        private static int GetGroupNum(ICollection<PrincipalTournament> players)
        {
            int groupNum = players.Count / 10;

            if (0 != players.Count % 10)
            {
                ++groupNum;
            }
            return groupNum;
        }


        #endregion Private Methods


    }
}
