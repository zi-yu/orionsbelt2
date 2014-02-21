using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.TournamentCreators;
using System;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class AnnihalationCreatorTests : BaseTests
    {

        private static Principal p1;
        private static Tournament t1;
        private static Battle b1;
        private static List<Principal> prins = new List<Principal>();
        private static List<PrincipalTournament> pts = new List<PrincipalTournament>();
        private static List<Battle> battles = new List<Battle>();
        private static List<PlayerBattleInformation> infos = new List<PlayerBattleInformation>();

        private static void InitData()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                p1 = persistance.Create();
            }

            ITournamentCreator creator = new AnnihalationCreator();
            t1 = creator.CreateTournament("test", "test", 0, 1, true, false, 144, 0, 64, 0, 32, 0, 0);
        }

        private static void PrepareBattles(int battlesNumber)
        {
            pts = new List<PrincipalTournament>();
            prins = new List<Principal>();
            battles = new List<Battle>();
            infos = new List<PlayerBattleInformation>();

            for (int iter = 0; iter < battlesNumber*2; ++iter)
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    p1 = persistance.Create();
                    persistance.Update(p1);
                    prins.Add(p1);
                }
                using (IPlayerBattleInformationPersistance persistance = Persistance.Instance.GetPlayerBattleInformationPersistance())
                {
                    PlayerBattleInformation info = persistance.Create();
                    info.Owner = p1.Id;
                    if (iter % 2 == 0)
                        info.HasLost = false;
                    else
                        info.HasLost = true;
                    persistance.Update(info);
                    infos.Add(info);
                }
            }

            for (int iter = 0; iter < battlesNumber; ++iter)
            {
                using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance())
                {
                    b1 = persistance.Create();
                    b1.SeqNumber = NumericUtils.GetDouble((iter + 1) + ",4");

                    b1.PlayerInformation.Add(infos[iter*2]);
                    b1.PlayerInformation.Add(infos[iter * 2 +1]);

                    battles.Add(b1);
                }

            }
        }

        private static void PrepareTournament(int playersNumber)
        {
            ITournamentCreator creator = new AnnihalationCreator();
            t1 = creator.CreateTournament("test", "test", 0, 1, true, false, 144, 1440, 0, 0, 32, 0, 0);
            pts = new List<PrincipalTournament>();
            for (int iter = 0; iter < playersNumber; ++iter)
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    p1 = persistance.Create();
                    p1.EloRanking = playersNumber - iter;
                    persistance.Update(p1);
                }

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    PrincipalTournament pt = persistance.Create();
                    pt.Principal = p1;
                    pt.Tournament = t1;
                    pts.Add(pt);
                    persistance.Update(pt);
                }
            }
            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                foreach (PrincipalTournament pt in pts)
                {
                    t1.Regists.Add(pt);
                }
                persistance.Update(t1);
            }

            creator.GenerateGroups(pts, 0);
        }

        [Test]
        public void CreateTournament_Fail_StartConditions()
        {
            try
            {
                ITournamentCreator creator = new AnnihalationCreator();
                creator.CreateTournament("test", "test", 0, 1, true, false, 144, 1000,64,65, 32, 0,0);
                Assert.Fail("Should send an exception"); 
            }catch(TournamentException){}
        }

        [Test]
        public void CreateTournament_Fail_NoFleet()
        {
            try
            {
                ITournamentCreator creator = new AnnihalationCreator();
                creator.CreateTournament("test", "test", 0, 0, true, false, 144, 0, 64,0, 32,0 ,0);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
        }

        [Test]
        public void CreateTournament_Sucess()
        {
                ITournamentCreator creator = new AnnihalationCreator();
                Tournament tour = creator.CreateTournament("test", "test", 0, 1, true, false, 144, 0, 64,0, 32,0 ,0);
                Assert.IsTrue(0 != tour.Id);
        }

        [Test]
        public void RegistPlayer_Fail_TournamentNotExists()
        {
            try
            {
                ITournamentCreator creator = new AnnihalationCreator();
                InitData();
                creator.RegistPlayer(p1, 1000);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
            
        }

        [Test]
        public void RegistPlayer_Fail_TournamentAlreadyStart()
        {
            try
            {
                ITournamentCreator creator = new AnnihalationCreator();
                InitData();
                t1.StartTime = DateTime.Now.AddDays(1);
                creator.RegistPlayer(p1, t1.Id);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
        }

        [Test]
        public void RegistPlayer_Fail_TournamentAlreadyEnd()
        {
            try
            {
                ITournamentCreator creator = new AnnihalationCreator();
                InitData();
                t1.EndDate = DateTime.Now.AddDays(1); ;
                creator.RegistPlayer(p1, t1.Id);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
        }

        [Test]
        [ExpectedException(typeof(TournamentException))]
        public void RegistPlayer_Fail_NoCredits()
        {

            ITournamentCreator creator = new AnnihalationCreator();
            InitData();
            t1.StartTime = t1.CreatedDate;
            t1.EndDate = t1.CreatedDate;
            t1.CostCredits = 1000;
            p1.Credits = 500;
            creator.RegistPlayer(p1, t1.Id);

        }

        [Test]
        public void RegistPlayer_Sucess()
        {

            ITournamentCreator creator = new AnnihalationCreator();
            InitData();
            t1.StartTime = t1.CreatedDate;
            t1.EndDate = t1.CreatedDate;
            creator.RegistPlayer(p1, t1.Id);
            IList<PrincipalTournament> tour;
            using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
            {
                tour = persistance.SelectByTournament(t1);
            }
            Assert.IsTrue(tour.Count > 0);
        }
        /*
        [Test]
        public void RegistPlayer_Fail_PlayerAlreadyRegisted()
        {
            try{
                ITournamentCreator creator = new AnnihalationCreator();
                InitData();
                creator.RegistPlayer(p1, t1.Id);
                IList<PrincipalTournament> tour;
                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    tour = persistance.SelectByTournament(t1);
                }
                Assert.IsTrue(tour.Count > 0);
                creator.RegistPlayer(p1, t1.Id);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
        }
        
        [Test]
        public void GenerateGroups8Players_Sucess()
        {
            PrepareTournament(8);
            Assert.IsTrue(t1.Groups.Count == 1);
            Assert.IsTrue(t1.Groups[0].GroupNumber == 0);
            Assert.IsTrue(t1.Groups[0].PlayersIds == "|8||7||6||5||4||3||2||1|");
            
        }

        [Test]
        public void GenerateGroups53Players_Sucess()
        {
            PrepareTournament(53);
            Assert.IsTrue(t1.Groups.Count == 6);
        }
        [Test]
        public void GenerateGroups5000Players_Sucess()
        {
            PrepareTournament(5000);
            Console.WriteLine(DateTime.Now.TimeOfDay);
            Console.WriteLine(DateTime.Now.TimeOfDay);
            Assert.IsTrue(t1.Groups.Count == 500);
        }
        */
        [Test]
        public void GetPrincipalDuos_Fail_WrongNumberPlayers()
        {
            try
            {
                PrepareTournament(5);
                ITournamentCreator creator = new AnnihalationCreator();
                creator.GetPrincipalDuos(t1.Regists);
                Assert.Fail("Should send an exception");
            }catch(TournamentException){}
        }

        [Test]
        public void GetPrincipalDuos_Sucess_PrincipalTournament()
        {
            PrepareTournament(6);
            ITournamentCreator creator = new AnnihalationCreator();
            List<List<Principal>> principals = creator.GetPrincipalDuos(t1.Regists);

            Assert.AreEqual(3,principals.Count);
            Assert.AreEqual(t1.Regists[0].Principal.Id, principals[0][0].Id);
            Assert.AreEqual(t1.Regists[5].Principal.Id, principals[0][1].Id);
            Assert.AreEqual(t1.Regists[1].Principal.Id, principals[1][0].Id);
            Assert.AreEqual(t1.Regists[4].Principal.Id, principals[1][1].Id);
            Assert.AreEqual(t1.Regists[2].Principal.Id, principals[2][0].Id);
            Assert.AreEqual(t1.Regists[3].Principal.Id, principals[2][1].Id);
        }

        [Test]
        public void GetPrincipalDuos_Fail_WrongNumberBattles()
        {
            try
            {
                PrepareBattles(5);
                ITournamentCreator creator = new AnnihalationCreator();
                creator.GetPrincipalDuos(battles);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }
           
        }

        [Test]
        public void GetPrincipalDuos_Fail_WrongSeqNumber()
        {
            try
            {
                PrepareBattles(8);
                battles[0].SeqNumber = NumericUtils.GetDouble("122,4");
                ITournamentCreator creator = new AnnihalationCreator();
                creator.GetPrincipalDuos(battles);
                Assert.Fail("Should send an exception");
            }
            catch (TournamentException) { }

        }

        [Test]
        public void GetPrincipalDuos_Sucess_Battle()
        {

            PrepareBattles(8);
            ITournamentCreator creator = new AnnihalationCreator();
            List<List<Principal>> principals = creator.GetPrincipalDuos(battles);

            Assert.AreEqual(4, principals.Count);
            Assert.AreEqual(prins[0].Id, principals[0][0].Id);
            Assert.AreEqual(prins[2].Id, principals[0][1].Id);
            Assert.AreEqual(prins[4].Id, principals[1][0].Id);
            Assert.AreEqual(prins[6].Id, principals[1][1].Id);
            Assert.AreEqual(prins[8].Id, principals[2][0].Id);
            Assert.AreEqual(prins[10].Id, principals[2][1].Id);
            Assert.AreEqual(prins[12].Id, principals[3][0].Id);
            Assert.AreEqual(prins[14].Id, principals[3][1].Id);
        }

        [Test]
        public void IsToBeginPlayoffs_True()
        {/*
            PrepareTournament(8);
            ITournamentCreator creator = new AnnihalationCreator();
            Assert.IsTrue(creator.IsToBeginPlayoffs(t1));
          */
        }

        [Test]
        public void IsToBeginPlayoffs_False()
        {
            /*
            PrepareTournament(101);
            ITournamentCreator creator = new AnnihalationCreator();
            Assert.IsFalse(creator.IsToBeginPlayoffs(t1));
             * */
        }
    }
}
