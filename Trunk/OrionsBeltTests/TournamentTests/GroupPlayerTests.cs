using System;
using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.BattleCore;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore;
using OrionsBelt.Engine;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.TournamentCreators;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class GroupPlayerTests: BaseTests
    {
        private static Principal p1;
        private static Tournament t1;
        private static List<Principal> prins = new List<Principal>();
        private static List<PrincipalTournament> pts = new List<PrincipalTournament>();

        private static void PrepareTournament(int playersNumber)
        {
            ITournamentCreator creator = new AnnihalationCreator();
            t1 = creator.CreateTournament("test", "test", 0, 1, true, false, 144, 1440, 0,0, 32,0,0);
            pts = new List<PrincipalTournament>();
            for (int iter = 0; iter < playersNumber; ++iter)
            {
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    p1 = persistance.Create();
                    p1.EloRanking = playersNumber - iter;
                    persistance.Update(p1);
                }

                GroupPointsStorage gp, gp2;
                using (IGroupPointsStoragePersistance persistance = Persistance.Instance.GetGroupPointsStoragePersistance())
                {
                    gp = persistance.Create();
                    gp2 = persistance.Create();
                    gp.Pontuation = 1000+iter;
                    gp2.Pontuation = 2000-iter;
                    gp.Stage = 1;
                    gp2.Stage = 2;
                }

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    PrincipalTournament pt = persistance.Create();
                    pt.Principal = p1;
                    pt.Tournament = t1;
                    pt.Points.Add(gp);
                    pt.Points.Add(gp2);
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
        public void GroupPlayer_Ctor_Fail()
        {
            try
            {
                PrepareTournament(4);
                GroupPlayer grP = new GroupPlayer(t1.Regists[0], 3, 1);
                Assert.Fail("Should send an exception");
            }
            catch (Exception) { }
        }

        [Test]
        public void GroupPlayer_Ctor_Sucess()
        {

            PrepareTournament(4);
            foreach (PrincipalTournament pt in t1.Regists)
            {
                GroupPlayer grP = new GroupPlayer(pt, 2,1);
                Assert.IsTrue(grP.Points > 1990);
            }

            foreach (PrincipalTournament pt in t1.Regists)
            {
                GroupPlayer grP = new GroupPlayer(pt, 1,1);
                Assert.IsTrue(grP.Points < 1010);
            }
        }

        [Test]
        public void GroupPlayer_Compare_Sucess()
        {

            PrepareTournament(4);
            List<GroupPlayer> gps = new List<GroupPlayer>();
            foreach (PrincipalTournament pt in t1.Regists)
            {
                GroupPlayer grP = new GroupPlayer(pt, 2, t1.Regists.Count);
                gps.Add(grP);
            }

            gps.Sort();
            int points = gps[0].Points;
            foreach (GroupPlayer gp in gps)
            {
                Assert.LessOrEqual(gp.Points,points);
                points = gp.Points;
            }

            gps = new List<GroupPlayer>();
            foreach (PrincipalTournament pt in t1.Regists)
            {
                GroupPlayer grP = new GroupPlayer(pt, 1, t1.Regists.Count);
                gps.Add(grP);
            }

            gps.Sort();
            points = gps[0].Points;
            foreach (GroupPlayer gp in gps)
            {
                Assert.LessOrEqual(gp.Points, points);
                points = gp.Points;
            }

        }

    } ;
}