using System;
using System.Collections.Generic;
using System.Text;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Core;
using OrionsBelt.TournamentCore.Exceptions;
using System.Collections;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.TournamentCore
{
    public static class TournamentUtil
    {
        #region private fields

        //private static readonly Dictionary<TournamentMode, TournamentMode> forbiddenModeCombinations;

        #endregion private fields

        #region public fields

        public static readonly int gamesNumberPower = 20;
        public static readonly int rakingPower = 200;
        public static readonly int battlePointsPower = 1000;

        public static readonly int daysOfRestTime = 1;
        public static readonly int daysOfStoppedTime = 1;

        #endregion public fields

        #region Ctor
 /*
        static TournamentUtil()
        {
           
            forbiddenModeCombinations = new Dictionary<TournamentMode, TournamentMode>();
            forbiddenModeCombinations.Add(TournamentMode.Ladder, TournamentMode.Survival | TournamentMode.Normal | 
                                            TournamentMode.Private | TournamentMode.Masters | TournamentMode.Rookies);
            forbiddenModeCombinations.Add(TournamentMode.Normal, TournamentMode.Survival | TournamentMode.Ladder |
                                            TournamentMode.Masters | TournamentMode.Rookies);
            forbiddenModeCombinations.Add(TournamentMode.Survival, TournamentMode.Ladder | TournamentMode.Normal );
            forbiddenModeCombinations.Add(TournamentMode.Masters, TournamentMode.Rookies | TournamentMode.Normal |
                                            TournamentMode.Private | TournamentMode.Ladder);
            forbiddenModeCombinations.Add(TournamentMode.Rookies, TournamentMode.Masters | TournamentMode.Normal |
                                            TournamentMode.Private | TournamentMode.Ladder);
            forbiddenModeCombinations.Add(TournamentMode.Private, TournamentMode.Masters | TournamentMode.Rookies |
                                            TournamentMode.Public | TournamentMode.Ladder);
            forbiddenModeCombinations.Add(TournamentMode.Public, TournamentMode.Private);
            forbiddenModeCombinations.Add(TournamentMode.OneVsOne, TournamentMode.TwoVsTwo);
            forbiddenModeCombinations.Add(TournamentMode.TwoVsTwo, TournamentMode.OneVsOne);
        }
        
        public static Dictionary<TournamentMode, TournamentMode> ForbiddenModeCombinations
        {
            get { return forbiddenModeCombinations; }
        }
        */
        #endregion Ctor

        #region public methods

        /// <summary>
        /// Calculate the win probability for both players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <returns>Returns in the position 0, player one probability, and in the position 1 player two probability</returns>
        public static double[] WinProbability(Principal player1, Principal player2)
        {
            double[] toReturn = new double[2];
            toReturn[0] = CalcProbability(player1.EloRanking, player2.EloRanking);
            toReturn[1] = 1 - toReturn[0];
            return toReturn;
        }

        /// <summary>
        /// Calculate new ELO ranking for the players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="battleType">Battle type</param>
        /// <returns></returns>
        public static void CalcElo(IBattleResult player1, IBattleResult player2, BattleType battleType)
        {
            CalcEloOneVsOne(player1, player2, battleType);
        }

        /// <summary>
        /// Calculate new ELO ranking for the players/teams
        /// </summary>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        /// <param name="battleType">Battle type</param>
        /// <returns></returns>
        public static void CalcElo(List<IBattleResult> player1, List<IBattleResult> player2, BattleType battleType)
        {
            if(player1.Count == 0 || player2.Count == 0)
            {
                throw new ELOException(player1.Count, player2.Count);
            }

            if (player1.Count == 1 || player2.Count == 1)
            {
                CalcEloOneVsOne(player1[0], player2[0], battleType);
            }
            else
            {
                TeamEloCalc(player1, player2, battleType);
                TeamStorage ts1 = player1[0].Player.Team;
                TeamStorage ts2 = player2[0].Player.Team;

                using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
                {
                    PrincipalStats stats1 = GetUpdatedStats(ts1, persistance);
                    PrincipalStats stats2 = GetUpdatedStats(ts2, persistance);

                    if (stats1.MaxElo == ts1.EloRanking ||
                        stats1.MinElo == ts1.EloRanking ||
                        stats2.MaxElo == ts2.EloRanking ||
                        stats2.MinElo == ts2.EloRanking)
                    {
                        ts1.MyStatsId = stats1.Id;
                        ts2.MyStatsId = stats2.Id;
                    }
                }
                
                using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
                {
                    persistance.Update(ts1);
                    persistance.Update(ts2);
                }

            }
            
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
            if (player1.Count == 0 || player2.Count == 0)
            {
                throw new StatsException(player1.Count, player2.Count);
            }

            if (player1.Count == 1 || player2.Count == 1)
            {
                UpdateOneVsOneStats(player1[0], player2[0], battleInfo);
            }
            else
            {
                UpdateTeamVsTeamStats(player1[0], player2[0], battleInfo);

            }

        }

        private static void UpdateTeamVsTeamStats(IBattleResult player1, IBattleResult player2, IBattleInfo info)
        {

            IList<PrincipalStats> pStats = new List<PrincipalStats>(2);

            string[] array = new string[2];
            array[0] = string.Format("select e from SpecializedPrincipalStats e where e.Id={0}",
                                         player1.Player.Team.MyStatsId);
            array[1] = string.Format("select e from SpecializedPrincipalStats e where e.Id={0}",
                                         player2.Player.Team.MyStatsId);
            GetPrincipalStats(array, player1, pStats);

            using (IBattleStatsPersistance persistance = Persistance.Instance.GetBattleStatsPersistance())
            {
                IList<BattleStats> bStats = GetBattleStats(pStats, info.BattleType, persistance);
                UpdateBattleStat(player1, info, persistance, bStats[0]);
                UpdateBattleStat(player2, info, persistance, bStats[1]);
            }
        }

        private static void UpdateOneVsOneStats(IBattleResult player1, IBattleResult player2, IBattleInfo info)
        {
  
            IList<PrincipalStats> pStats = new List<PrincipalStats>(2);
            
            string[] array = new string[2];
            array[0] = string.Format("select e from SpecializedPrincipalStats e where e.Id={0}",
                                         player1.Player.MyStatsId);
            array[1] = string.Format("select e from SpecializedPrincipalStats e where e.Id={0}",
                                         player2.Player.MyStatsId);
            GetPrincipalStats(array, player1, pStats);

            using (IBattleStatsPersistance persistance = Persistance.Instance.GetBattleStatsPersistance())
            {
                IList<BattleStats> bStats = GetBattleStats(pStats, info.BattleType, persistance);
                UpdateBattleStat(player1, info, persistance, bStats[0]);
                UpdateBattleStat(player2, info, persistance, bStats[1]);
            }
        }

        private static void UpdateBattleStat(IBattleResult player1, IBattleInfo info, IPersistance<BattleStats> persistance, BattleStats bStat)
        {
            if(!player1.HasLost)
            {
                bStat.Wins += 1;
            }
            else
            {
                bStat.Defeats += 1;
                if(info.HasGiveUp)
                {
                    bStat.GiveUps += 1;
                }
            }
            persistance.Update(bStat);
        }

        private static IList<BattleStats> GetBattleStats(ICollection<PrincipalStats> pStats, BattleType battleType, IPersistance<BattleStats> persistance)
        {
            IList<BattleStats> toReturn = new List<BattleStats>(pStats.Count);

            foreach (PrincipalStats stat in pStats)
            {
                bool got = false;
                foreach (BattleStats bStats in stat.BattleStats)
                {
                    if(bStats.Type == battleType.ToString())
                    {
                        toReturn.Add(bStats);
                        got = true;
                        break;
                    }
                }
                if(!got)
                {
                    BattleStats newOne = persistance.Create();
                    newOne.Stats = stat;
                    newOne.Type = battleType.ToString();
                    newOne.GiveUps = 0;
                    newOne.Defeats = 0;
                    newOne.Wins = 0;
                    toReturn.Add(newOne);
                }
            }
            return toReturn;
        }

        private static void GetPrincipalStats(IEnumerable<string> array, IBattleResult player1, ICollection<PrincipalStats> pStats)
        {
            using (
                IPrincipalStatsPersistance persistance =
                    Persistance.Instance.GetPrincipalStatsPersistance())
            {
                IList stats = persistance.MultiQuery(array, new Dictionary<string, object>());

                foreach (IList result in stats)
                {
                    if(result.Count == 0)
                    {
                        PrincipalStats stat = persistance.Create();
                        stat.MaxElo = player1.Player.EloRanking;
                        stat.MinElo = player1.Player.EloRanking;
                        stat.MaxLadder = player1.Player.LadderPosition;
                        stat.MinLadder = player1.Player.LadderPosition;
                        stat.NumberPlayedBattles = 1;
                        persistance.Update(stat);
                        player1.Player.MyStatsId = stat.Id;
                    }
                    else
                    {
                        pStats.Add((PrincipalStats)result[0]);
                    }
                }
            }
        }

        /// <summary>
        /// Calculate new Ladder ranking for the players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <returns></returns>
        public static void CalcLadderResult(IBattlePlayer player1, IBattlePlayer player2)
        {
            IList<Principal> info;

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                info = persistance.TypedQuery("from SpecializedPrincipal where Principalid={0} or Principalid={1}", player1.Owner.Id, player2.Owner.Id);
            }

            UpdateListPlayersOnLadders(player1, player2, info);
        }

        /// <summary>
        /// Calculate new Ladder ranking for the players
        /// </summary>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        /// <returns></returns>
        public static void CalcLadderResult(IList<IBattlePlayer> player1, IList<IBattlePlayer> player2)
        {
            if (player1.Count == 0 || player2.Count == 0)
            {
                throw new ListCountException(player1.Count, player2.Count, 0);
            }

            if (player1.Count == 1 || player2.Count == 1)
            {
                CalcLadderResult(player1[0], player2[0]);
            }else
            {
                Principal p1, p2;
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    IList<Principal> list = persistance.SelectById(player1[0].Owner.Id);
                    p1 = list[0];
                    list = persistance.SelectById(player2[0].Owner.Id);
                    p2 = list[0];
                }

                IList<TeamStorage> info;
                using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
                {
                    info =
                        persistance.TypedQuery(
                            "from SpecializedTeamStorage where TeamStorageId={0} or TeamStorageId={1}",
                            p1.Team.Id, p2.Team.Id);
                }
            

                UpdateListPlayersOnLadders(player1[0], player2[0], info);
            }
        }

        /// <summary>
        /// Method created for tests. Update the objects in the list
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="info">Ojects LadderInfo to be updated based on the previous parameters. Must have only and just only 2 elements</param>
        /// <returns></returns>
        public static void UpdateListPlayersOnLadders(IBattlePlayer player1, IBattlePlayer player2, IList<Principal> info)
        {
            Principal lower;
            Principal higher;
            bool higherWon;
            if(info[0].LadderPosition < info[1].LadderPosition)
            {
                higher = info[0];
                lower = info[1];
            }
            else
            {
                higher = info[1];
                lower = info[0];
            }

            if(lower.Id == player1.Owner.Id)
            {
                higherWon = player1.HasLost;
            }
            else
            {
                higherWon = player2.HasLost;
            }

            UpdateLadderInfo(higher, lower, higherWon);
        }

        /// <summary>
        /// Method created for tests. Update the objects in the list
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="info">Ojects LadderInfo to be updated based on the previous parameters. Must have only and just only 2 elements</param>
        /// <returns></returns>
        public static void UpdateListPlayersOnLadders(IBattlePlayer player1, IBattlePlayer player2, IList<TeamStorage> info)
        {
            TeamStorage lower;
            TeamStorage higher;
            bool higherWon;
            if (info[0].LadderPosition < info[1].LadderPosition)
            {
                higher = info[0];
                lower = info[1];
            }
            else
            {
                higher = info[1];
                lower = info[0];
            }

            if (lower.Id == player1.Owner.Id)
            {
                higherWon = player1.HasLost;
            }
            else
            {
                higherWon = player2.HasLost;
            }

            UpdateLadderInfo(higher, lower, higherWon);
        }

        /// <summary>
        /// Calculate the group points won if is a group battle
        /// </summary>
        /// <param name="battle">Battle</param>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        public static void CalcGroupPoints(Battle battle, IBattlePlayer player1, IBattlePlayer player2)
        {
            if(null == battle.Group)
            {
                return;
            }

            int stage = battle.Group.EliminatoryNumber;
            Tournament tour = battle.Group.Tournament;
            int pId1 = player1.Owner.Id;
            int pId2 = player2.Owner.Id;
            int p1Score = player1.WinScore;
            int p2Score = player2.WinScore;

            UpdateGroupPoints(tour, stage, pId1, pId2, p1Score, p2Score, player1.HasLost);
        }

        /// <summary>
        /// Calculate the group points won if is a group battle
        /// </summary>
        /// <param name="battle">Battle</param>
        /// <param name="player1">Team 1</param>
        /// <param name="player2">Team 2</param>
        public static void CalcGroupPoints(Battle battle, IList<IBattlePlayer> player1, IList<IBattlePlayer> player2)
        {
            if (null == battle.Group)
            {
                return;
            }

            int stage = battle.Group.EliminatoryNumber;
            Tournament tour = battle.Group.Tournament;
            string pId1 = player1[0].TeamName;
            string pId2 = player2[0].TeamName;
            int p1Score = player1[0].WinScore + player1[1].WinScore;
            int p2Score = player2[0].WinScore + player2[1].WinScore;

            bool t1HasLost = true;
            if (!player1[0].HasLost || !player1[1].HasLost)
            {
                t1HasLost = false;
            }

            UpdateTeamGroupPoints(tour, stage, pId1, pId2, p1Score, p2Score, t1HasLost);
        }

        /// <summary>
        /// Get player by tournament group, order by points
        /// </summary>
        /// <param name="groups">DB group object</param>
        /// <param name="stage">Stage of the tournament</param>
        /// <param name="tourId">Tournament identifier</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<List<GroupPlayer>> GetPlayersByGroupOrdered(IList<PlayersGroupStorage> groups, int stage, int tourId)
        {
            return GetPlayersByGroupOrdered(groups, stage, tourId, 0);
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
            List<List<GroupPlayer>> toReturn = new List<List<GroupPlayer>>(groups.Count);
            int start = (page)*10;
            int processed = 0;
            int count = 0;
            for (int iter = 0; iter < groups.Count && count < 10; ++iter)
            {
                if (groups[iter].EliminatoryNumber != stage)
                {
                    continue;
                }

                if (processed < start)
                {
                    ++processed;
                }
                else
                {
                    string[] ids =
                        groups[iter].PlayersIds.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    IList players;
                    string ors = BuildIdsOr(ids, false);
                    string[] array = new string[2];
                    array[0] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PointsNHibernate points where e.TournamentNHibernate.Id={1} and points.Stage={2} and ({0})",
                                                 ors, tourId,stage);
                    array[1] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PrincipalNHibernate princs where e.TournamentNHibernate.Id={1} and ({0})",
                                                 ors, tourId);
                    using (
                        IPrincipalTournamentPersistance persistance =
                            Persistance.Instance.GetPrincipalTournamentPersistance())
                    {
                        players = persistance.MultiQuery(array, new Dictionary<string, object>());
                    }

                    SortAndAddGroup((IList)players[0], stage, toReturn);
                    ++count;
                }
            }

            return toReturn;
        }

        /// <summary>
        /// Get player by tournament group, order by points
        /// </summary>
        /// <param name="group">DB group object</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<GroupPlayer> GetPlayersByGroupOrdered(IList<PlayersGroupStorage> group)
        {
            List<GroupPlayer> toReturn = new List<GroupPlayer>();

            for (int iter = 0; iter < group.Count; ++iter)
            {

                string[] ids =
                    group[iter].PlayersIds.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                IList players;
                string ors = BuildIdsOr(ids, false);
                string[] array = new string[2];
                array[0] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PointsNHibernate points where e.TournamentNHibernate.Id={1} and ({0})",
                                             ors, group[iter].Tournament.Id);
                array[1] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PrincipalNHibernate princs where e.TournamentNHibernate.Id={1} and ({0})",
                                             ors, group[iter].Tournament.Id);
                using (
                    IPrincipalTournamentPersistance persistance =
                        Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    players = persistance.MultiQuery(array, new Dictionary<string, object>());
                }

                SortAndAddGroup((IList)players[0], group[iter].EliminatoryNumber, toReturn);            
            }

            return toReturn;
        }

        /// <summary>
        /// Get teams by tournament group, order by points
        /// </summary>
        /// <param name="group">DB group object</param>
        /// <returns>A list of list groups order by points</returns>
        public static List<GroupPlayer> GetTeamsByGroupOrdered(IList<PlayersGroupStorage> group)
        {
            List<GroupPlayer> toReturn = new List<GroupPlayer>();

            for (int iter = 0; iter < group.Count; ++iter)
            {

                string[] ids =
                    group[iter].PlayersIds.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                IList players;
                string ors = BuildIdsOr(ids, true);
                string[] array = new string[2];
                array[0] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PointsNHibernate points where e.TournamentNHibernate.Id={1} and ({0})",
                                             ors, group[iter].Tournament.Id);
                array[1] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PrincipalNHibernate princs where e.TournamentNHibernate.Id={1} and ({0})",
                                             ors, group[iter].Tournament.Id);
                using (
                    IPrincipalTournamentPersistance persistance =
                        Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    players = persistance.MultiQuery(array, new Dictionary<string, object>());
                }

                SortAndAddGroup((IList)players[0], group[iter].EliminatoryNumber, toReturn);              
            }

            return toReturn;
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
            List<List<GroupPlayer>> toReturn = new List<List<GroupPlayer>>(groups.Count);
            int start = (page) * 10;
            int processed = 0;
            int count = 0;
            for (int iter = 0; iter < groups.Count && count < 10; ++iter)
            {
                if (groups[iter].EliminatoryNumber != stage)
                {
                    continue;
                }

                if (processed < start)
                {
                    ++processed;
                }
                else
                {
                    string[] ids =
                        groups[iter].PlayersIds.Split(new char[] {'|'}, StringSplitOptions.RemoveEmptyEntries);
                    IList players;
                    string ors = BuildIdsOr(ids, true);
                    string[] array = new string[2];
                    array[0] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PointsNHibernate points where e.TournamentNHibernate.Id={1} and ({0})",
                                                 ors, tourId);
                    array[1] = string.Format("select e from SpecializedPrincipalTournament e inner join fetch e.PrincipalNHibernate princs where e.TournamentNHibernate.Id={1} and ({0})",
                                                 ors, tourId);
                    using (
                        IPrincipalTournamentPersistance persistance =
                            Persistance.Instance.GetPrincipalTournamentPersistance())
                    {
                        players = persistance.MultiQuery(array, new Dictionary<string, object>());
                    }

                    SortAndAddGroup((IList)players[0], stage, toReturn);
                    ++count;
                }
            }

            return toReturn;
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
            return GetTeamsByGroupOrdered(groups,  stage,  tourId,0);
        }

        #endregion public methods

        #region private methods

        /// <summary>
        /// Build a query of ors
        /// </summary>
        /// <param name="ids">The ids to put in the query</param>
        /// <param name="isTeam">Indicates if is ids of team or principal</param>
        /// <returns>The string with the query</returns>
        private static string BuildIdsOr(string[] ids, bool isTeam)
        {
            string idField;
            if (isTeam)
            {
                idField = " e.TeamNHibernate.Id=";
            }
            else
            {
                idField = " e.PrincipalNHibernate.Id=";
            }
            StringBuilder toReturn = new StringBuilder();
            for (int iter = 0; iter < ids.Length; ++iter)
            {
                toReturn.Append(idField);
                toReturn.Append(ids[iter]);
                if (iter + 1 < ids.Length)
                    toReturn.Append(" or ");
            }
            return toReturn.ToString();
        }

        private static void SortAndAddGroup(IList players, int stage, ICollection<List<GroupPlayer>> toReturn)
        {
            List<GroupPlayer> group = new List<GroupPlayer>(10);
            foreach (PrincipalTournament player in players)
            {
                group.Add(new GroupPlayer(player, stage, players.Count));
            }
            group.Sort();
            toReturn.Add(group);
        }

        private static void SortAndAddGroup(IList players, int stage, List<GroupPlayer> toReturn)
        {
            foreach (PrincipalTournament player in players)
            {
                toReturn.Add(new GroupPlayer(player, stage, players.Count));
            }
            toReturn.Sort();
        }

        private static void UpdateTeamGroupPoints(IEntity tour, int stage, string teamName1, string teamName2, int p1Score, int p2Score, bool t1HasLost)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                IList<PrincipalTournament> pts =
                    persistance.TypedQuery(
                        "select e from SpecializedPrincipalTournament e where e.TournamentNHibernate.Id = {0} and (e.TeamNHibernate.Name = '{1}' or e.TeamNHibernate.Name = '{2}')",
                        tour.Id, teamName1, teamName2);

                if (pts.Count != 2)
                {
                    throw new TournamentException("Must find 2 PrincipalTournament");
                }

                if (pts[0].Team.Name == teamName1)
                {
                    SetGroupPoints(pts[0], p1Score, pts[1], p2Score, stage,t1HasLost, persistance);
                }
                else
                {
                    SetGroupPoints(pts[1], p1Score, pts[0], p2Score, stage,t1HasLost, persistance);
                }
            }
        }

        private static void UpdateGroupPoints(IEntity tour, int stage, int principalId1, int principalId2, int p1Score, int p2Score, bool p1HasLost)
        {
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                IList<PrincipalTournament> pts =
                    persistance.TypedQuery(
                        "select e from SpecializedPrincipalTournament e where e.TournamentNHibernate.Id = {0} and (e.PrincipalNHibernate.Id = {1} or e.PrincipalNHibernate.Id = {2})",
                        tour.Id, principalId1, principalId2);

                if(pts.Count != 2)
                {
                    throw new TournamentException("Must find 2 PrincipalTournament");
                }

                if(pts[0].Principal.Id == principalId1)
                {
                    SetGroupPoints(pts[0], p1Score, pts[1], p2Score, stage, p1HasLost, persistance);
                }
                else
                {
                    SetGroupPoints(pts[1], p1Score, pts[0], p2Score, stage, p1HasLost, persistance);
                }
            }
        }

        private static void SetGroupPoints(PrincipalTournament pt1, int p1Score, PrincipalTournament pt2, int p2Score, int stage, bool p1HasLost, IPersistanceSession session)
        {
            using (IGroupPointsStoragePersistance persistance = Persistance.Instance.GetGroupPointsStoragePersistance(session))
            {
                foreach (GroupPointsStorage point in pt1.Points)
                {
                    if(point.Stage == stage)
                    {
                        point.Pontuation += p1Score;
                        if (!p1HasLost)
                        {
                            point.Wins += 1;
                        }
                        else
                        {
                            point.Losses += 1;
                        }
                        persistance.Update(point);
                        break;
                    }
                }

                foreach (GroupPointsStorage point in pt2.Points)
                {
                    if (point.Stage == stage)
                    {
                        point.Pontuation += p2Score;
                        if (p1HasLost)
                        {
                            point.Wins += 1;
                        }
                        else
                        {
                            point.Losses += 1;
                        }
                        persistance.Update(point);
                        break;
                    }
                }
            }
        }

        /// <summary>
        /// Update both LadderInfo
        /// </summary>
        /// <param name="higher">Principal in a better position on ladder</param>
        /// <param name="lower">Principal in a worser position on ladder</param>
        /// <param name="higherWon">True if the higher principal won</param>
        /// <returns></returns>
        private static void UpdateLadderInfo(Principal higher, Principal lower, bool higherWon)
        {
            if (higherWon)
            {
                higher.RestUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(1)));
                lower.StoppedUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
            }
            else
            {
                int temp = higher.LadderPosition;
                higher.LadderPosition = lower.LadderPosition;
                UpdateLadderStats(higher);
                lower.LadderPosition = temp;
                UpdateLadderStats(lower);
                higher.StoppedUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(1)));
            }

        	higher.IsInBattle = 0;
			lower.IsInBattle = 0;

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.Update(higher);
                persistance.Update(lower);
            }
        }

        private static void UpdateLadderStats(Principal principal)
        {
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                IList<PrincipalStats> stats = persistance.SelectById(principal.MyStatsId);

                if(stats.Count == 0)
                {
                    PrincipalStats stat = persistance.Create();
                    stat.MaxElo = 1000;
                    stat.MinElo = 1000;
                    stat.MaxLadder = principal.LadderPosition;
                    stat.MinLadder = principal.LadderPosition;
                    stat.NumberPlayedBattles = 1;
                    persistance.Update(stat);
                    principal.MyStatsId = stat.Id;
                }
                else
                {
                    stats[0].MinLadder = Math.Max(stats[0].MinLadder, principal.LadderPosition);
                    stats[0].MaxLadder = Math.Min(stats[0].MaxLadder, principal.LadderPosition);
                    stats[0].NumberPlayedBattles += 1;
                    persistance.Update(stats[0]);
                }
            }
        }

        /// <summary>
        /// Update both LadderInfo
        /// </summary>
        /// <param name="higher">Principal in a better position on ladder</param>
        /// <param name="lower">Principal in a worser position on ladder</param>
        /// <param name="higherWon">True if the higher principal won</param>
        /// <returns></returns>
        private static void UpdateLadderInfo(TeamStorage higher, TeamStorage lower, bool higherWon)
        {
            if (higherWon)
            {
                higher.RestUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(1)));
                lower.StoppedUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(3)));
            }
            else
            {
                int temp = higher.LadderPosition;
                higher.LadderPosition = lower.LadderPosition;
                lower.LadderPosition = temp;
                higher.StoppedUntil = Clock.Instance.EndTickByDelay(Clock.Instance.ConvertToTicks(TimeSpan.FromDays(1)));
            }

            higher.IsInBattle = 0;
            lower.IsInBattle = 0;

            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                persistance.Update(higher);
                persistance.Update(lower);
            }
        }

        /// <summary>
        /// Calculate new Elo for 1vs1
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="type">Battle Type</param>
        /// <returns>Points win or lost</returns>
        private static void EloCalc(IBattleResult player1, IBattleResult player2, BattleType type)
        {
            double elo = Math.Round(player1.Player.EloRanking +
                                    2 * (CalcGamesPoints(player1) *
                                       (CalcBattlePoints(player1, player2, type) -
                                        2 * CalcProbability(player1.Player.EloRanking,
                                                        player2.Player.EloRanking)
                                       )
                                      )
                );

            if (elo > 900 || player1.Player.EloRanking < elo)
            {
                player1.Player.EloRanking = Convert.ToInt32(elo);
            }

            elo = Math.Round(player2.Player.EloRanking +
                             2 * (CalcGamesPoints(player2) *
                                (CalcBattlePoints(player2, player1, type) -
                                 2 * CalcProbability(player2.Player.EloRanking,
                                                 player1.Player.EloRanking)
                                )
                               )
                );
            if (elo > 900 || player2.Player.EloRanking < elo)
            {
                player2.Player.EloRanking = Convert.ToInt32(elo);
            }
        }

        /// <summary>
        /// Calculate que new Elo for both Teams
        /// </summary>
        /// <param name="team1">Team 1</param>
        /// <param name="team2">Team 2</param>
        /// <param name="battleType">Battle type</param>
        /// <returns></returns>
        private static void TeamEloCalc(IList<IBattleResult> team1, IList<IBattleResult> team2, BattleType battleType)
        {
            int eloTeam1 = team1[0].Player.Team.EloRanking;
            int eloTeam2 = team2[0].Player.Team.EloRanking;


            double elo = Math.Round(eloTeam1 +
                        2 * (CalcGamesPoints(team1) *
                           (CalcBattlePoints(team1, team2, battleType) -
                            2 * CalcProbability(eloTeam1,
                                            eloTeam2)
                           )
                          )
            );

            if (elo > 900 || elo > team1[0].Player.Team.EloRanking)
            {
                team1[0].Player.Team.EloRanking = Convert.ToInt32(elo);

            }
            team1[0].Player.Team.NumberPlayedBattles += 1;
            elo = Math.Round(eloTeam2 +
                             2 * (CalcGamesPoints(team2) *
                                (CalcBattlePoints(team2, team1, battleType) -
                                 2 * CalcProbability(eloTeam2,
                                                 eloTeam1)
                                )
                               )
                );
            if (elo > 900 || elo > team2[0].Player.Team.EloRanking)
            {
                team2[0].Player.Team.EloRanking = Convert.ToInt32(elo);

            }
            team2[0].Player.Team.NumberPlayedBattles += 1;
        }


        /// <summary>
        /// Calculate que new Elo for both Players
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="battleType">Battle type</param>
        /// <returns></returns>
        private static void CalcEloOneVsOne(IBattleResult player1, IBattleResult player2, BattleType battleType)
        {

            EloCalc(player1, player2, battleType);

            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                PrincipalStats stats1 = GetUpdatedStats(player1, persistance);
                PrincipalStats stats2 = GetUpdatedStats(player2, persistance);

                if (stats1.MaxElo == player1.Player.EloRanking ||
                    stats1.MinElo == player1.Player.EloRanking ||
                    stats2.MaxElo == player2.Player.EloRanking ||
                    stats2.MinElo == player2.Player.EloRanking)
                { 
                    player1.Player.MyStatsId = stats1.Id;
                    player2.Player.MyStatsId = stats2.Id;    
                }
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {

                persistance.Update(player1.Player);
                persistance.Update(player2.Player);
            }

        }

        /// <summary>
        /// Gets PrincipalStats and update it if necessary. If doesn't exists creates a new.
        /// </summary>
        /// <param name="player1">Owner to get stats</param>
        /// <param name="persistance">Persistance object</param>
        /// <returns>The stats updated for the Principal</returns>
        private static PrincipalStats GetUpdatedStats(IBattleResult player1, IPrincipalStatsPersistance persistance)
        {
            IList<PrincipalStats> stats1 = persistance.SelectById(player1.Player.MyStatsId);
            if (stats1.Count == 0)
            {
                PrincipalStats new1 = persistance.Create();
                new1.MaxElo = 1000;
                new1.MinElo = 1000;
                new1.NumberPlayedBattles = 0;
                new1.MaxLadder = player1.Player.LadderPosition;
                new1.MinLadder = player1.Player.LadderPosition;
                stats1.Add(new1);
            }
            stats1[0].MaxElo = Math.Max(stats1[0].MaxElo, player1.Player.EloRanking);
            stats1[0].MinElo = Math.Min(stats1[0].MinElo, player1.Player.EloRanking);
            stats1[0].NumberPlayedBattles += 1;
            persistance.Update(stats1);
            return stats1[0];
        }

        /// <summary>
        /// Gets PrincipalStats and update it if necessary. If doesn't exists creates a new.
        /// </summary>
        /// <param name="team">Owner to get stats</param>
        /// <param name="persistance">Persistance object</param>
        /// <returns>The stats updated for the Principal</returns>
        private static PrincipalStats GetUpdatedStats(TeamStorage team, IPrincipalStatsPersistance persistance)
        {
            IList<PrincipalStats> stats1 = persistance.SelectById(team.MyStatsId);
            if (stats1.Count == 0)
            {
                PrincipalStats new1 = persistance.Create();
                new1.MaxElo = 1000;
                new1.MinElo = 1000;
                new1.NumberPlayedBattles = 0;
                new1.MaxLadder = team.LadderPosition;
                new1.MinLadder = team.LadderPosition;
                stats1.Add(new1);
            }
            stats1[0].MaxElo = Math.Max(stats1[0].MaxElo, team.EloRanking);
            stats1[0].MinElo = Math.Min(stats1[0].MinElo, team.EloRanking);
            stats1[0].NumberPlayedBattles += 1;
            persistance.Update(stats1);
            return stats1[0];
        }
/*
        /// <summary>
        /// Gets PrincipalStats and update it if necessary. If doesn't exists creates a new.
        /// </summary>
        /// <param name="player1">Player 1 with the new Elo</param>
        /// <param name="player2">Player 2 with the new Elo</param>
        /// <param name="p1prevElo">Old Elo for Player 1</param>
        /// <param name="p2prevElo">Old Elo for Player 2</param>
        /// <returns></returns>
        private static void CalcAllianceElo(IBattleResult player1, IBattleResult player2, int p1prevElo, int p2prevElo)
        {
            if (null != player1.Player.Alliance)
            {
                player1.Player.Alliance.EloRanking += player1.Player.EloRanking - p1prevElo;
                player1.Player.Alliance.MaxElo =
                    Math.Max(player1.Player.Alliance.EloRanking, player1.Player.Alliance.MaxElo);
                player1.Player.Alliance.MinElo =
                    Math.Min(player1.Player.Alliance.EloRanking, player1.Player.Alliance.MinElo);

            }

            if (null != player2.Player.Alliance)
            {
                player2.Player.Alliance.EloRanking += player2.Player.EloRanking - p2prevElo;
                player2.Player.Alliance.MaxElo =
                    Math.Max(player2.Player.Alliance.EloRanking, player2.Player.Alliance.MaxElo);
                player2.Player.Alliance.MinElo =
                    Math.Min(player2.Player.Alliance.EloRanking, player2.Player.Alliance.MinElo);
            }
		  
        }
*/
        /// <summary>
        /// Calculate the win probability for player 1
        /// </summary>
        /// <param name="elo1">Player 1 elo</param>
        /// <param name="elo2">Player 2 elo</param>
        /// <returns>Win probability for player 1</returns>
        private static double CalcProbability(int elo1, int elo2)
        {
            return (1/(1 + Math.Pow(10,(double)(elo2-elo1)/rakingPower)));
        }

        /// <summary>
        /// Calculate the elo points win, only conditionated by the battle
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <param name="player2">Player 2</param>
        /// <param name="type">Battle Type</param>
        /// <returns>Points win or lost</returns>
        private static double CalcBattlePoints(IBattleResult player1, IBattleResult player2, BattleType type)
        {
            if(!player1.HasLost)
            {
                int winningPoints = player1.ScoreMade;
                if(type == BattleType.Regicide || type == BattleType.Regicide4)
                {
                    winningPoints -= 10000;
                }
                double win = (2 + 0.5 * (winningPoints - player2.ScoreMade) / battlePointsPower);
                return win > 4 ? 4 : win;
            }


            double lost = (-1 - 0.5 * (player2.ScoreMade - player1.ScoreMade) / battlePointsPower);
            return lost < -2 ? -2 : lost;
        }

        /// <summary>
        /// Calculate the elo points win, only conditionated by the battle
        /// </summary>
        /// <param name="team1">Team 1</param>
        /// <param name="team2">Team 2</param>
        /// <param name="type">Battle Type</param>
        /// <returns>Points win or lost</returns>
        private static double CalcBattlePoints(IList<IBattleResult> team1, IEnumerable<IBattleResult> team2, BattleType type)
        {
            int team1Score = 0;
            int team2Score = 0;

            foreach (IBattleResult result in team1)
            {
                team1Score += result.ScoreMade;
            }

            foreach (IBattleResult result in team2)
            {
                team2Score += result.ScoreMade;
            }

            if (!team1[0].HasLost)
            {
                int winningPoints = team1Score;
                if (type == BattleType.Regicide || type == BattleType.Regicide4)
                {
                    winningPoints -= 20000;
                }
                double win = (2 + 0.5 * (winningPoints - team2Score) / battlePointsPower);
                return win > 4 ? 4 : win;
            }

            double lost = (-1 - 0.5 * (team2Score - team1Score) / battlePointsPower);
            return lost < -2 ? -2 : lost;
        }

        /// <summary>
        /// Calculate the elo points win or lost, only conditionated by the number of games
        /// </summary>
        /// <param name="player1">Player 1</param>
        /// <returns>Points conditionated by the number of games</returns>
        private static double CalcGamesPoints(IBattleResult player1)
        {
            IList<PrincipalStats> stats;
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                stats = persistance.SelectById(player1.Player.MyStatsId);
            }

            int battleNumber = 0;
            if(0 < stats.Count)
            {
                battleNumber = stats[0].NumberPlayedBattles;
            }

            double calc1 = (double)gamesNumberPower / (10 + battleNumber);
            return 1 + calc1;
        }

        /// <summary>
        /// Calculate the elo points win or lost, only conditionated by the number of games
        /// </summary>
        /// <param name="team">Team to be analysed</param>
        /// <returns>Points conditionated by the number of games</returns>
        private static double CalcGamesPoints(IList<IBattleResult> team)
        {
            double calc1 = (double)gamesNumberPower / (10 + team[0].Player.Team.NumberPlayedBattles);
            return 1 + calc1;
        }

        

        #endregion private methods

        public static IList<PrincipalTournament> GetPrincipalRegistsByElo(Tournament tour)
        {
            using (
                    IPrincipalTournamentPersistance persistance =
                        Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    return persistance.TypedQuery("select pt from SpecializedPrincipalTournament pt inner join pt.PrincipalNHibernate p where pt.TournamentNHibernate.Id={0} order by p.EloRanking desc", tour.Id);
                }
        }

        public static IList<PrincipalTournament> GetTeamRegistsByElo(Tournament tour)
        {
            using (
                    IPrincipalTournamentPersistance persistance =
                        Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                return persistance.TypedQuery("select pt from SpecializedPrincipalTournament pt inner join pt.TeamNHibernate p where pt.TournamentNHibernate.Id={0} order by p.EloRanking desc", tour.Id);
            }
        }
    }
}