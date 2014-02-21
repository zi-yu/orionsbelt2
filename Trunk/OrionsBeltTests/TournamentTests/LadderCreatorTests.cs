using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.TournamentCore.TournamentCreators;

namespace OrionsBeltTests.TournamentTests
{
    [TestFixture]
    public class LadderCreatorTests : BaseTests
    {
        private static Principal p1, p2, p3, p4;
        private static Fleet f1;

        private static void InitData()
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                p1 = persistance.Create();
                p2 = persistance.Create();
                p3 = persistance.Create();
                p4 = persistance.Create();

                p1.LadderActive = true;
                p2.LadderActive = true;
                p3.LadderActive = true;
                p4.LadderActive = true;

                p1.IsInBattle = 0;
                p2.IsInBattle = 0;
                p3.IsInBattle = 0;
                p4.IsInBattle = 0;

                p1.LadderPosition = 1;
                p2.LadderPosition = 2;
                p3.LadderPosition = 3;
                p4.LadderPosition = 4;

                persistance.Update(p1);
                persistance.Update(p2);
                persistance.Update(p3);
                persistance.Update(p4);
            }

            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                f1 = persistance.Create();
                f1.Name = "Test";
                f1.PrincipalOwner = p1;
            }
        }

        #region CreateTournament

        [Test]
        public void CreateTournament_Fail_NumberPlayers()
        {
            try
            {
                InitData();
                ILadderCreator creator = new LadderCreator();
                IFleetInfo fleet = new FleetInfo(f1, false);
                List<Principal> list = new List<Principal>();
                creator.ValidateData(list,fleet,true);
                Assert.Fail("Should send an exception"); 
            }catch(ListCountException){}
        }

        [Test]
        public void CreateTournament4_Fail_NumberPlayers()
        {
            try
            {
                InitData();
                ILadderCreator creator = new Ladder4Creator();
                IFleetInfo fleet = new FleetInfo(f1, false);
                List<Principal> list = new List<Principal>();
                list.Add(p1);
                list.Add(p2);

                creator.ValidateData(list, fleet,true);
                Assert.Fail("Should send an exception");
            }
            catch (ListCountException) { }
        }

        #endregion CreateTournament
    }
}
