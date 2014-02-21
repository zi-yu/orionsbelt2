using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.TournamentCreators;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class TournamentManagerTests : BaseTests
    {

        private static Principal p1;
        private static Tournament t1;
        private static List<PrincipalTournament> pts = new List<PrincipalTournament>();
        private static FleetInfo fleetInfo = new FleetInfo("Fleet1");

        private static void CreateTournament()
        {
            ITournamentCreator creator = new AnnihalationCreator();
            t1 = creator.CreateTournament("test", "test", 0, 1, true, false, 144, 1440, 0,0, 32,0,0);
        }
 
        private static void PrepareTournament(int playersNumber)
        {
            fleetInfo = new FleetInfo("Fleet1");
            fleetInfo.Add("Eagle", 75);
            fleetInfo.Add("DarkRain", 100);
            fleetInfo.Add("Spider", 50);
            fleetInfo.Add("Bozer", 50);
            fleetInfo.Add("Pretorian", 100);
            fleetInfo.Add("Raptor", 75);
            fleetInfo.Add("Vector", 100);
            fleetInfo.Add("DarkTaurus", 50);

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

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    PrincipalTournament pt = persistance.Create();
                    pt.Principal = p1;
                    pt.Tournament = t1;
                    pts.Add(pt);
                }
            }
        }

        [Test]
        public void GetFleet_Sucess()
        {
            FleetInfo info = TournamentManager.GetFleet(1000,true);
            Assert.AreEqual(8, info.Units.Count);
            Assert.IsTrue(info.HasUltimateUnit);
        }

        /*
        [Test]
        public void GenerateGroups8Players_Sucess()
        {
            PrepareTournament(8);
            TournamentManager.BeginTournament(pts,1,fleetInfo,BattleType.TotalAnnihalation);
            Assert.IsTrue(t1.Groups[0].Battles.Count == 28);
            
        }

        [Test]
        public void GenerateGroups10Players_Sucess()
        {
            PrepareTournament(10);
            TournamentManager.BeginTournament(pts, 1, fleetInfo, BattleType.TotalAnnihalation);
            Assert.IsTrue(t1.Groups[0].Battles.Count == 45);

        }

        [Test]
        public void GenerateGroups13Players_Sucess()
        {
            PrepareTournament(13);
            TournamentManager.BeginTournament(pts, 1, fleetInfo, BattleType.TotalAnnihalation);
            Assert.IsTrue(t1.Groups[0].Battles.Count == 21);
            Assert.IsTrue(t1.Groups[1].Battles.Count == 15);
        }

        [Test]
        public void ProcessTournament_Sucess()
        {
            CreateTournament();
            TournamentManager.ProcessTournament(t1.Id);
        }
*/
    }
}
