using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore;
using OrionsBelt.Engine;
using OrionsBelt.TournamentCore.Exceptions;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class TournamentUtilTests:BaseTests
    {
        private static Principal p1,p2,p3,p4;
        private static TeamStorage t1, t2;

        private static void InitData()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                p1 = persistance.Create();
                p2 = persistance.Create();
                p3 = persistance.Create();
                p4 = persistance.Create();
            }
        }

        private static void InitTeam()
        {
            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                t1 = persistance.Create();
                t2 = persistance.Create();
            }
        }

        #region WinProbability

        [Test]
        public void WinProbability_Sucess_MustBeEqual()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;

            double[] res = TournamentUtil.WinProbability(p1, p2);
            Assert.AreEqual(res[0], res[1]);
        }

        [Test]
        public void WinProbability_Sucess_MustBe100()
        {
            InitData();

            p1.EloRanking = 1127;
            p2.EloRanking = 7846;

            double[] res = TournamentUtil.WinProbability(p1, p2);
            Assert.AreEqual(1, res[0]+res[1]);
        }

        [Test]
        public void WinProbability_Fail_1Greater2()
        {
            InitData();

            p1.EloRanking = 1200;
            p2.EloRanking = 1300;

            double[] res = TournamentUtil.WinProbability(p1, p2);
            Assert.IsFalse(res[0] > res[1]);
        }

        #endregion WinProbability

        #region CalcElo

        [Test]
        public void CalcElo_Sucess_Player1Win()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);


            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.GreaterOrEqual(p1.EloRanking, p2.EloRanking);
        }

        [Test]
        public void CalcElo_Sucess_Player1DownPlayer2Up()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);


            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.Greater(p1.EloRanking, 1000);
            Assert.Less(p2.EloRanking, 1000);
        }

        [Test]
        public void CalcElo_Sucess_DifBeginRanking()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
           // p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);


            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);


            int elo1 = p1.EloRanking;

            p1.EloRanking = 1500;
            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.LessOrEqual(p1.EloRanking - 1500, elo1 - 1000);
            
        }

        [Test]
        public void CalcElo_Sucess_DifBeginGames()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);


            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            int elo1 = p1.EloRanking;

            //p1.NumberPlayedBattles = 0;
            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.GreaterOrEqual(p1.EloRanking, elo1);

        }

        [Test]
        public void CalcElo_Sucess_DifGamePoints()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);


            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            int elo1 = p1.EloRanking;
            int elo2 = p2.EloRanking;

            b2.ScoreMade = 100;
            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.GreaterOrEqual(p1.EloRanking, elo1);
            Assert.LessOrEqual(p2.EloRanking, elo2);
        }

        [Test]
        public void CalcElo_Sucess_PlayersEquals()
        {
            InitData();

            p1.EloRanking = 1200;
            p2.EloRanking = 1200;
            //p1.NumberPlayedBattles = 50;
            //p2.NumberPlayedBattles = 50;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);

            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.Greater(p1.EloRanking, 1200);
            Assert.Greater(1200, p2.EloRanking);
            p1.EloRanking = 1200;
            p2.EloRanking = 1200;
            //p1.NumberPlayedBattles = 20;
            TournamentUtil.CalcElo(b1, b2, BattleType.TotalAnnihalation);

            Assert.AreNotEqual(p1.EloRanking - 1200, 1200 - p2.EloRanking);
        }

        [Test]
        public void CalcElo_Fail_EmptyList()
        {
            try
            {
                InitData();

                p1.EloRanking = 1000;
                //p1.NumberPlayedBattles = 20;

                IBattleResult b1 = new BattleResult(p1, 4000, false);

                List<IBattleResult> list1 = new List<IBattleResult>();
                list1.Add(b1);

                TournamentUtil.CalcElo(list1, new List<IBattleResult>(), BattleType.TotalAnnihalation);

                Assert.Fail("Should send an exception");
            }
            catch(ELOException)
            {
            }
        }

        [Test]
        public void CalcElo_Sucess_PlayerCreateStats()
        {
            InitData();

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);

            List<IBattleResult> list1 = new List<IBattleResult>();
            list1.Add(b1);
            List<IBattleResult> list2 = new List<IBattleResult>();
            list2.Add(b2);

            TournamentUtil.CalcElo(list1, list2, BattleType.TotalAnnihalation);

            IList<PrincipalStats> stats2;
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                stats2 = persistance.SelectById(list2[0].Player.MyStatsId);
            }
 
            Assert.AreEqual(p2.EloRanking, stats2[0].MinElo);
        }

        [Test]
        public void CalcElo_Sucess_PlayerUpdateStats()
        {
            InitData();
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                PrincipalStats new1 = persistance.Create();
                new1.MaxElo = 1200;
                new1.MinElo = 1100;
                persistance.Update(new1);
                p2.MyStatsId = new1.Id;
                persistance.Flush();
            }

            p1.EloRanking = 1000;
            p2.EloRanking = 1000;
            //p1.NumberPlayedBattles = 20;
            //p2.NumberPlayedBattles = 20;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);

            List<IBattleResult> list1 = new List<IBattleResult>();
            list1.Add(b1);
            List<IBattleResult> list2 = new List<IBattleResult>();
            list2.Add(b2);

            TournamentUtil.CalcElo(list1, list2, BattleType.TotalAnnihalation);

            IList<PrincipalStats> stats2;
            using (IPrincipalStatsPersistance persistance = Persistance.Instance.GetPrincipalStatsPersistance())
            {
                stats2 = persistance.SelectById(list2[0].Player.MyStatsId);
            }

            Assert.AreEqual(p2.EloRanking, stats2[0].MinElo);
        }

        [Test]
        public void CalcElo_Sucess_TeamUpdateStats()
        {
            InitData();
            InitTeam();

            t1.EloRanking = 1500;
            

            t2.EloRanking = 1000;
            

            p1.Team = t1;
            p2.Team = t2;

            IBattleResult b1 = new BattleResult(p1, 4000, false);
            IBattleResult b2 = new BattleResult(p2, 3000, true);
            IBattleResult b3 = new BattleResult(p3, 4000, false);
            IBattleResult b4 = new BattleResult(p4, 100, true);

            List<IBattleResult> list1 = new List<IBattleResult>();
            list1.Add(b1);
            list1.Add(b3);
            List<IBattleResult> list2 = new List<IBattleResult>();
            list2.Add(b2);
            list2.Add(b4);

            TournamentUtil.CalcElo(list1, list2, BattleType.TotalAnnihalation);

            //Assert.AreEqual(p1.Team.EloRanking, p1.Team.MaxElo);
            Assert.Greater(p1.Team.EloRanking, 1500);
            Assert.Less(p2.Team.EloRanking, 1000);
        }

        #endregion CalcElo

        #region CalcLadderResult

        [Test]
        public void CalcLadderResult_Sucess_P1higherP1Win()
        {
            InitData();

            p1.Id = 1;
            p2.Id = 2;
            IBattlePlayer player1 = new BattlePlayer(BattleOwner.Get(p1));
			IBattlePlayer player2 = new BattlePlayer(BattleOwner.Get(p2));
            player1.HasLost = false;
            player2.HasLost = true;

            IList<Principal> info = new List<Principal>(2);
            p1.LadderPosition = 1;
            p1.RestUntil = Clock.Instance.Tick;
            p1.StoppedUntil = Clock.Instance.Tick;

            p2.LadderPosition = 3;
            p2.RestUntil = Clock.Instance.Tick;
            p2.StoppedUntil = Clock.Instance.Tick;

            info.Add(p1);
            info.Add(p2);

            TournamentUtil.UpdateListPlayersOnLadders(player1,player2,info);

            Assert.AreEqual(p1.LadderPosition,1);
            Assert.AreEqual(p2.LadderPosition, 3);
            Assert.IsTrue(p1.RestUntil > Clock.Instance.Tick);
            Assert.IsTrue(p2.StoppedUntil > Clock.Instance.Tick);
        }

        [Test]
        public void CalcLadderResult_Sucess_P1higherP2Win()
        {
            InitData();

            p1.Id = 1;
            p2.Id = 2;
			IBattlePlayer player1 = new BattlePlayer(BattleOwner.Get(p1));
			IBattlePlayer player2 = new BattlePlayer(BattleOwner.Get(p2));
            player1.HasLost = true;
            player2.HasLost = false;

            IList<Principal> info = new List<Principal>(2);
            p1.LadderPosition = 1;
            p1.RestUntil = Clock.Instance.Tick;
            p1.StoppedUntil = Clock.Instance.Tick;

            p2.LadderPosition = 3;
            p2.RestUntil = Clock.Instance.Tick;
            p2.StoppedUntil = Clock.Instance.Tick;

            info.Add(p1);
            info.Add(p2);

            TournamentUtil.UpdateListPlayersOnLadders(player1, player2, info);

            Assert.AreEqual(p1.LadderPosition, 3);
            Assert.AreEqual(p2.LadderPosition, 1);
            Assert.IsFalse(p1.RestUntil > Clock.Instance.Tick);
            Assert.IsFalse(p2.StoppedUntil > Clock.Instance.Tick);
        }

        [Test]
        public void CalcLadderResult_Sucess_P1lowerP1Win()
        {
            InitData();

            p1.Id = 1;
            p2.Id = 2;
			IBattlePlayer player1 = new BattlePlayer(BattleOwner.Get(p1));
			IBattlePlayer player2 = new BattlePlayer(BattleOwner.Get(p2));
            player1.HasLost = false;
            player2.HasLost = true;


            IList<Principal> info = new List<Principal>(2);
            p1.LadderPosition = 3;
            p1.RestUntil = Clock.Instance.Tick;
            p1.StoppedUntil = Clock.Instance.Tick;

            p2.LadderPosition = 1;
            p2.RestUntil = Clock.Instance.Tick;
            p2.StoppedUntil = Clock.Instance.Tick;

            info.Add(p1);
            info.Add(p2);

            TournamentUtil.UpdateListPlayersOnLadders(player1, player2, info);

            Assert.AreEqual(p1.LadderPosition, 1);
            Assert.AreEqual(p2.LadderPosition, 3);
            Assert.IsFalse(p1.RestUntil > Clock.Instance.Tick);
            Assert.IsTrue(p2.StoppedUntil > Clock.Instance.Tick);
        }

        [Test]
        public void CalcLadderResult_Sucess_P1lowerP2Win()
        {
            InitData();

            p1.Id = 1;
            p2.Id = 2;
			IBattlePlayer player1 = new BattlePlayer(BattleOwner.Get(p1));
			IBattlePlayer player2 = new BattlePlayer(BattleOwner.Get(p2));
            player1.HasLost = true;
            player2.HasLost = false;

            IList<Principal> info = new List<Principal>(2);
            p1.LadderPosition = 3;
            p1.RestUntil = Clock.Instance.Tick;
            p1.StoppedUntil = Clock.Instance.Tick;

            p2.LadderPosition = 1;
            p2.RestUntil = Clock.Instance.Tick;
            p2.StoppedUntil = Clock.Instance.Tick;

            info.Add(p1);
            info.Add(p2);
            
            TournamentUtil.UpdateListPlayersOnLadders(player1, player2, info);

            Assert.AreEqual(p1.LadderPosition, 3);
            Assert.AreEqual(p2.LadderPosition, 1);
            Assert.IsTrue(p1.StoppedUntil > Clock.Instance.Tick);
            Assert.IsTrue(p2.RestUntil > Clock.Instance.Tick);
        }

        #endregion CalcLadderResult

    } ;
}