using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;

namespace OrionsBeltTests.EngineTests
{
    [TestFixture]
    public class TransactionManagerTests : BaseTests
    {
        private static Principal p1, p2;
        private static PlayerStorage pl1, pl2;
        private static IResourceInfo resource;
        private static Market market;
        private static Product pd1, pd2;
        private static AllianceStorage alliance;
        private static Tournament tour;
        private static ArenaStorage arena;
        private static TeamStorage team;
        private static Fleet fleetDB;
        private static Payment pay;

        private static void PrepareObjs()
        {
            using (IProductPersistance persistance = Persistance.Instance.GetProductPersistance())
            {
                pd1 = persistance.Create();
                pd2 = persistance.Create();

                pd1.Name = "Serium";
                pd1.Price = 15;
                pd1.Quantity = 0;
                pd1.Type = "Intrinsic";

                pd2.Name = "Prismal";
                pd2.Price = 1;
                pd2.Quantity = 10;
                pd2.Type = "Rare";

                persistance.Update(pd1);
                persistance.Update(pd2);
            }

            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleetDB = persistance.Create();
                persistance.Update(fleetDB);

            }

            using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance())
            {
                market = persistance.Create();
                market.Level = 1;
                market.Products.Add(pd1);
                market.Products.Add(pd2);
                persistance.Update(market);
                
            }

            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                tour = persistance.Create();
                tour.CostCredits = 250;
                persistance.Update(tour);

            }

            using (IAllianceStoragePersistance persistance = Persistance.Instance.GetAllianceStoragePersistance())
            {
                alliance = persistance.Create();
                alliance.Orions = 1000;
                persistance.Update(alliance);

            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                p1 = persistance.Create();
                p1.Credits = 1000;
                persistance.Update(p1);

                p2 = persistance.Create();
                p2.Credits = 1000;
                persistance.Update(p2);
            }

            using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
            {
                team = persistance.Create();
                team.Principals.Add(p1);
                team.Principals.Add(p2);
                persistance.Update(team);
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

            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                pay = persistance.Create();

                persistance.Update(pay);
            }

            resource = RulesUtils.GetResource("Serium");



            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                persistance.DeleteAll();
            }
            using (IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance())
            {
                persistance.DeleteAll();
            }
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                persistance.DeleteAll();
            }

            using (IArenaStoragePersistance persistance = Persistance.Instance.GetArenaStoragePersistance())
            {
                arena = persistance.Create();
                arena.Payment = 80;
                persistance.Update(arena);
                persistance.Flush();
            }

        }

        [Test]
        public void AuctionHouseTransaction_Sucess()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 200, pl2);
            int itemId = AuctionHouseUtil.PutInAuction(item, new FleetInfo("teste"));
            string result = AuctionHouseUtil.MakeBuyout(itemId, pl1);
            /*
            IList<AuctionHouse> items;
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                items = persistance.SelectById(itemId);
            }
            TransactionManager.AuctionHouseTransaction(items[0], pl1);
            */
            Assert.IsTrue("Ok" == result);
            Assert.IsTrue(800 == pl1.Principal.Credits);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
				Assert.AreEqual(trans[0].TransactionContext, TransactionContext.AuctionHouse.ToString());
                Assert.AreEqual(trans[0].CreditsGain, CreditsUtil.GetValueWithoutTax(200));
                Assert.AreEqual(trans[0].CreditsSpend, 200);
                Assert.AreEqual(trans[0].GainCurrentCredits, pl2.Principal.Credits);
                Assert.AreEqual(trans[0].IdentifierGain, pl2.Principal.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, pl1.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Player.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, pl1.Principal.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, pl1.Principal.Credits);
            }
        }

        [Test]
        public void PrincipalPaymentTransaction_Sucess()
        {
            PrepareObjs();

            TransactionManager.PaymentTransaction(p1, pay, 750,5);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
				Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Payment.ToString());
                Assert.AreEqual(trans[0].CreditsGain, 750);
                Assert.AreEqual(trans[0].GainCurrentCredits, pl1.Principal.Credits);
                Assert.AreEqual(trans[0].IdentifierGain, pl1.Principal.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.System.ToString());
            }
        }

        [Test]
        public void AlliancePaymentTransaction_Sucess()
        {
            PrepareObjs();

            TransactionManager.PaymentTransaction(alliance, 750);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
				Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Payment.ToString());
                Assert.AreEqual(trans[0].CreditsGain, 750);
                Assert.AreEqual(trans[0].GainCurrentCredits, alliance.Orions);
                Assert.AreEqual(trans[0].IdentifierGain, alliance.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Alliance.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.System.ToString());
            }
        }

        [Test]
        public void MarketTransaction_Sucess()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Serium", 10);
            Assert.IsTrue(result.Ok);
            Assert.AreEqual(990, p1.Credits);

            //TransactionManager.MarketTransaction(market,pl1,10);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
				Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Market.ToString());
                Assert.AreEqual(trans[0].CreditsGain, 10);
                Assert.AreEqual(trans[0].CreditsSpend, 10);
                Assert.AreEqual(trans[0].IdentifierGain, market.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, pl1.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, "Serium");
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Player.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, pl1.Principal.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, pl1.Principal.Credits);
            }
        }

        [Test]
        public void TournamentTransaction_Sucess()
        {
            PrepareObjs();

            TransactionManager.TournamentTransaction(tour, p1);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
				Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Tournament.ToString());
                Assert.AreEqual(trans[0].CreditsGain, tour.CostCredits);
                Assert.AreEqual(trans[0].CreditsSpend, tour.CostCredits);

                Assert.AreEqual(trans[0].IdentifierGain, tour.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, p1.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Tournament.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, p1.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, pl1.Principal.Credits);
            }
        }

        [Test]
        public void TournamentTeamTransaction_Sucess()
        {
            PrepareObjs();

            TransactionManager.TournamentTransaction(tour, team);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.SelectByPrincipalIdSpend(p1.Id);
                Assert.IsTrue(trans.Count == 1);
                Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Tournament.ToString());
                Assert.AreEqual(trans[0].CreditsGain, tour.CostCredits);
                Assert.AreEqual(trans[0].CreditsSpend, tour.CostCredits);

                Assert.AreEqual(trans[0].IdentifierGain, tour.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, p1.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Tournament.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, p1.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, p1.Credits);

                trans = persistance.SelectByPrincipalIdSpend(p2.Id);
                Assert.IsTrue(trans.Count == 1);
                Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Tournament.ToString());
                Assert.AreEqual(trans[0].CreditsGain, tour.CostCredits);
                Assert.AreEqual(trans[0].CreditsSpend, tour.CostCredits);

                Assert.AreEqual(trans[0].IdentifierGain, tour.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, p2.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Tournament.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, p2.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, p2.Credits);
            }
        }

        [Test]
        public void ArenaTransactionChallenge_Sucess()
        {
            PrepareObjs();

            TransactionManager.ArenaChallengeTransaction(arena, pl1);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
                Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Arena.ToString(), "Context");
                Assert.AreEqual(trans[0].CreditsGain, arena.Payment);
                Assert.AreEqual(trans[0].CreditsSpend, arena.Payment);

                Assert.AreEqual(trans[0].IdentifierGain, arena.Id, "ArenaId");
                Assert.AreEqual(trans[0].IdentifierSpend, pl1.Id, "PrincipalId");
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Arena.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Player.ToString());
                Assert.AreEqual(trans[0].PrincipalIdSpend, p1.Id);
                Assert.AreEqual(trans[0].SpendCurrentCredits, pl1.Principal.Credits);
            }
        }

        [Test]
        public void ArenaTransactionEnd_Sucess()
        {
            PrepareObjs();

            arena.Owner = pl1;
            TransactionManager.ArenaEndTransaction(arena);

            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                IList<Transaction> trans = persistance.Select();
                Assert.IsTrue(trans.Count == 1);
                Assert.AreEqual(trans[0].TransactionContext, TransactionContext.Arena.ToString());
                Assert.AreEqual(trans[0].CreditsGain, arena.Payment/2);
                Assert.AreEqual(trans[0].CreditsSpend, arena.Payment/2);

                Assert.AreEqual(trans[0].IdentifierGain, arena.Owner.Principal.Id);
                Assert.AreEqual(trans[0].IdentifierSpend, arena.Id);
                Assert.AreEqual(trans[0].IdentityTypeGain, TransactionIdentifier.Principal.ToString());
                Assert.AreEqual(trans[0].IdentityTypeSpend, TransactionIdentifier.Arena.ToString());
                Assert.AreEqual(trans[0].GainCurrentCredits, arena.Owner.Principal.Credits);
            }
        }
    }
}
