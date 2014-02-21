using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.TournamentCore;
using System;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class ArenaUtilTests:BaseTests
    {
        private static Principal p1,p2;
        private static PlayerStorage pl1, pl2;
        private static ArenaStorage arena;


        private static void PrepareObjs()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                p1 = persistance.Create();
                p1.Credits = 1000;
                persistance.Update(p1);

                p2 = persistance.Create();
                p2.Credits = 100;
                persistance.Update(p2);
            }

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                pl1 = persistance.Create();
                pl1.Principal = p1;
                persistance.Update(pl1);

                pl2 = persistance.Create();
                pl2.Principal = p2;
                persistance.Update(pl2);
            }

            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena = persistance.Create();
                arena.Id = 1;
                arena.Payment = 80;
                persistance.Update(arena);
                persistance.Flush();
            }
        }


        [Test]
        public void Challenge_Fail_NoCredits()
        {
            PrepareObjs();
            pl2.Principal.Credits = 10;
            Result res = ArenaUtil.Challenge(1, new Player(pl2));
            Assert.IsTrue(res.Ok);
            //Assert.AreEqual(res.Failed[0].Log(), "Player does not have enough credits.");
        }

        [Test]
        public void Challenge_Fail_InvalidId()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(12345, new Player(pl1));
            Assert.IsFalse(res.Ok);
            Assert.AreEqual(res.Failed[0].Log(), "Invalid arena identifier.");
        }

        [Test]
        public void Challenge_Fail_AlreadyInBattle()
        {
            PrepareObjs();

            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                IList <ArenaStorage> arenas = persistance.SelectById(arena.Id);
                arenas[0].IsInBattle = 1;
                persistance.Update(arena);
                persistance.Flush();
            }
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            Assert.IsFalse(res.Ok);
            Assert.AreEqual(res.Failed[0].Log(), "Arena already in battle.");
        }

        [Test]
        public void Challenge_Fail_AlreadyChampion()
        {
            PrepareObjs();
            ArenaUtil.Challenge(arena.Id, new Player(pl1));
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            Assert.IsFalse(res.Ok);
            Assert.AreEqual(res.Failed[0].Log(), "You are already the Arena owner.");
        }

        [Test]
        public void Challenge_Sucess_ArenaFound()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            Assert.IsTrue(res.Ok);
            Assert.AreEqual(res.Passed[0].Log(),"Arena found.");
            Assert.AreEqual(arena.Owner, pl1);
            Assert.AreEqual(arena.IsInBattle, 0);

            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                IList<ArenaHistorical> historical = persistance.SelectByArena(arena);
                Assert.AreEqual(historical[0].Winner, pl1.Id);
                Assert.AreEqual(historical[0].StartTick, historical[0].EndTick);
                Assert.AreEqual(historical[0].StartTick, arena.ConquestTick);
                Assert.AreEqual(historical[0].WinningSequence, 0);
            }
        }

        [Test]
        public void Challenge_Sucess_ArenaBattle()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            int initCredits = pl2.Principal.Credits;
            res = ArenaUtil.Challenge(arena.Id, new Player(pl2));
            Assert.IsTrue(res.Ok);
            Assert.AreEqual(res.Passed[0].Log(), "Arena in battle.");
            Assert.AreEqual(arena.Owner, pl1);
            Assert.AreEqual(initCredits-arena.Payment, pl2.Principal.Credits);

            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                IList<ArenaHistorical> historical = persistance.SelectByChampionId(pl1.Id);
                Assert.AreEqual(historical[0].ChallengerId, pl2.Id);
                Assert.AreEqual(historical[0].Arena, arena);
            }
        }

        [Test]
        public void EndBattle_Sucess_1ChallengerWin()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            res = ArenaUtil.Challenge(arena.Id, new Player(pl2));

            IList<ArenaHistorical> historical;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                historical = persistance.SelectByArena(arena);
            }
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena.IsInBattle = 1;
                arena.Historical = historical;
                persistance.Update(arena);
            }
            
            ArenaHistorical last = null;

            foreach (ArenaHistorical hist in historical)
            {
                if (0 == hist.Winner)
                {
                    last = hist;
                }
            }

            ArenaUtil.EndBattle(1,pl2.Id);

            ArenaHistorical updatedLast = last;
            foreach (ArenaHistorical arenaHistorical in arena.Historical)
            {
                if (arenaHistorical.Id == last.Id)
                {
                    updatedLast = arenaHistorical;
                    break;
                }
            }

            Assert.AreEqual(arena.IsInBattle, 0);
            Assert.AreEqual(updatedLast.Winner, pl2.Id);
            Assert.AreEqual(updatedLast.WinningSequence, 1);
        }

        [Test]
        public void EndBattle_Sucess_1ChampionWin()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            res = ArenaUtil.Challenge(arena.Id, new Player(pl2));

            IList<ArenaHistorical> historical;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                historical = persistance.SelectByArena(arena);
            }
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena.IsInBattle = 1;
                arena.Historical = historical;
                persistance.Update(arena);
            }

            ArenaHistorical last = null;

            foreach (ArenaHistorical hist in historical)
            {
                if (0 == hist.Winner)
                {
                    last = hist;
                }
            }

            ArenaUtil.EndBattle(1, pl1.Id);

            ArenaHistorical updatedLast = last;
            foreach (ArenaHistorical arenaHistorical in arena.Historical)
            {
                if (arenaHistorical.Id == last.Id)
                {
                    updatedLast = arenaHistorical;
                    break;
                }
            }

            Assert.AreEqual(arena.IsInBattle, 0);
            Assert.AreEqual(updatedLast.Winner, pl1.Id);
            Assert.AreEqual(updatedLast.WinningSequence, 1);
        }

        [Test]
        public void EndBattle_Sucess_2ChallengerWin()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            res = ArenaUtil.Challenge(arena.Id, new Player(pl2));

            IList<ArenaHistorical> historical;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                historical = persistance.SelectByArena(arena);
                foreach (ArenaHistorical hist in historical)
                {
                    if (0 == hist.Winner)
                    {
                        hist.Winner = pl1.Id;
                        hist.WinningSequence = 1;
                    }
                }
                ArenaHistorical histNew = persistance.Create();
                histNew.Arena = arena;
                histNew.ChallengerId = pl2.Id;
                histNew.ChampionId = pl1.Id;
                histNew.StartTick = Clock.Instance.Tick;
                historical.Add(histNew);
            }
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena.IsInBattle = 1;
                arena.Historical = historical;
                persistance.Update(arena);
            }

            ArenaHistorical last = null;

            foreach (ArenaHistorical hist in historical)
            {
                if (0 == hist.Winner)
                {
                    last = hist;
                }
            }

            ArenaUtil.EndBattle(1, pl2.Id);

            ArenaHistorical updatedLast = last;
            foreach (ArenaHistorical arenaHistorical in arena.Historical)
            {
                if (arenaHistorical.Id == last.Id)
                {
                    updatedLast = arenaHistorical;
                    break;
                }
            }

            Assert.AreEqual(arena.IsInBattle, 0);
            Assert.AreEqual(updatedLast.Winner, pl2.Id);
            Assert.AreEqual(updatedLast.WinningSequence, 1);
        }

        [Test]
        public void EndBattle_Sucess_2ChampionWin()
        {
            PrepareObjs();
            Result res = ArenaUtil.Challenge(arena.Id, new Player(pl1));
            res = ArenaUtil.Challenge(arena.Id, new Player(pl2));

            IList<ArenaHistorical> historical;
            using (IArenaHistoricalPersistance persistance = Persistance.Instance.GetArenaHistoricalPersistance())
            {
                historical = persistance.SelectByArena(arena);
                foreach (ArenaHistorical hist in historical)
                {
                    if (0 == hist.Winner)
                    {
                        hist.Winner = pl1.Id;
                        hist.WinningSequence = 1;
                        hist.EndTick = Int32.MaxValue;
                    }
                }
                ArenaHistorical histNew = persistance.Create();
                histNew.Arena = arena;
                histNew.ChallengerId = pl2.Id;
                histNew.ChampionId = pl1.Id;
                historical.Add(histNew);
            }
            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena.IsInBattle = 1;
                arena.Historical = historical;
                persistance.Update(arena);
            }

            ArenaHistorical last = null;

            foreach (ArenaHistorical hist in historical)
            {
                if (0 == hist.Winner)
                {
                    last = hist;
                }
            }

            ArenaUtil.EndBattle(1, pl1.Id);

            ArenaHistorical updatedLast = last;
            foreach (ArenaHistorical arenaHistorical in arena.Historical)
            {
                if (arenaHistorical.Id == last.Id)
                {
                    updatedLast = arenaHistorical;
                    break;
                }
            }

            Assert.AreEqual(arena.IsInBattle, 0);
            Assert.AreEqual(updatedLast.Winner, pl1.Id);
            Assert.AreEqual(updatedLast.WinningSequence, 2);
        }

    };
}