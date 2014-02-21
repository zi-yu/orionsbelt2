using System.Collections.Generic;
using NUnit.Framework;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Exceptions;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBeltTests.EngineTests
{
    [TestFixture]
    public class MarketTests : BaseTests
    {
        private static Principal p1, p2;
        private static PlayerStorage pl1, pl2;
        private static IResourceInfo resource;
        private static Market market;
        private static Product pd1, pd2;
        private static IFleetInfo fleet;
        private static Fleet fleetDB;

        private static void PrepareObjs()
        {
            fleet = new FleetInfo("test");
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

            using (IMarketPersistance persistance = Persistance.Instance.GetMarketPersistance())
            {
                market = persistance.Create();
                market.Level = 1;
                market.Products.Add(pd1);
                market.Products.Add(pd2);
                persistance.Update(market);

            }

            using (IFleetPersistance persistance = Persistance.Instance.GetFleetPersistance())
            {
                fleetDB = persistance.Create();
                persistance.Update(fleetDB);

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

            using (IPlayerStoragePersistance persistance = Persistance.Instance.GetPlayerStoragePersistance())
            {
                pl1 = persistance.Create();
                pl1.Principal = p1;
                persistance.Update(pl1);

                pl2 = persistance.Create();
                pl2.Principal = p2;
                persistance.Update(pl2);
            }

            resource = RulesUtils.GetResource("Serium");


            using (IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance())
            {
                persistance.DeleteAll();
            }
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                persistance.DeleteAll();
            }

        }

        [Test]
        public void ComplexAuctionItemCtor_Sucess()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, pl1);
            Assert.IsTrue(item.Time == 144);
            Assert.IsTrue(item.Buyout == 0);
        }

        [Test]
        public void ComplexAuctionItemCtor_Fail_BuyoutBid()
        {
            IAuctionItem item = null;
            try
            {
                PrepareObjs();
                item = new AuctionItem(resource, 100, 100, 5, pl1);
                Assert.Fail("Should send an exception");
            }
            catch (AuctionException)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void ComplexAuctionItemCtor_Fail_Time()
        {
            IAuctionItem item = null;
            try
            {
                PrepareObjs();
                item = new AuctionItem(resource, 100, 100, pl1, -3);
                Assert.Fail("Should send an exception");
            }
            catch (AuctionException)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void ComplexAuctionItemCtor_Fail_LowerBid()
        {
            IAuctionItem item = null;
            try
            {
                PrepareObjs();
                item = new AuctionItem(resource, 100, 1, pl1);
                Assert.Fail("Should send an exception");
            }
            catch (AuctionException)
            {
                Assert.IsNull(item);
            }
        }

        [Test]
        public void PutInAuctionHouse_Sucess()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, pl1);
            IList<AuctionHouse> init, end;
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                init = persistance.Select();
            }
            AuctionHouseUtil.PutInAuction(item, fleet);
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                end = persistance.Select();
            }
            Assert.Greater(end.Count, init.Count);
        }

        [Test]
        public void MakeBid_Fail_NoCredits()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBid(itemId, pl1, 1500);
            Assert.IsTrue("NoCredits" == result);
        }

        [Test]
        public void MakeBid_Fail_InvalidItem()
        {
            PrepareObjs();
            string result = AuctionHouseUtil.MakeBid(12345678, pl1, 120);
            Assert.IsTrue("InvalidItem" == result);
        }

        [Test]
        public void MakeBid_Fail_LowerBid()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBid(itemId, pl1, 20);
            Assert.IsTrue("LowerBid" == result);
        }

        [Test]
        public void MakeBid_Fail_GreaterThanBuyout()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 150, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBid(itemId, pl1, 200);
            Assert.IsTrue("GreaterThanBuyout" == result);
        }

        [Test]
        public void MakeBid_Sucess_1One()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 150, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBid(itemId, pl1, 120);
            Assert.IsTrue("Ok" == result);
            Assert.IsTrue(880 == p1.Credits);
            using (IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance())
            {
                IList<BidHistorical> bids = persistance.SelectByMadeBy(pl1);
                Assert.IsTrue(bids[0].Value == 120);
            }
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                IList<AuctionHouse> auctions = persistance.SelectById(itemId);
                Assert.IsTrue(auctions[0].HigherBidOwner == pl1.Id);
                Assert.IsTrue(auctions[0].CurrentBid == 120);
            }
        }

        [Test]
        public void MakeBid_Sucess_Override()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 150, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBid(itemId, pl1, 120);
            Assert.IsTrue("Ok" == result);

            result = AuctionHouseUtil.MakeBid(itemId, pl2, 121);
            Assert.AreEqual("Ok", result, "The result isn't ok");
            Assert.AreEqual(1000, p1.Credits, "p1.Credits isn't 1000");
            Assert.AreEqual(879, p2.Credits, "p2.Credits isn't 879");

            using (IBidHistoricalPersistance persistance = Persistance.Instance.GetBidHistoricalPersistance())
            {
                IList<BidHistorical> bids = persistance.SelectByMadeBy(pl1);
                Assert.AreEqual(120, bids[0].Value, "bids[0].Value isn't 120");
                Assert.AreEqual(pl1, bids[0].MadeBy, "bids[0].MadeBy isn't pl1");
                bids = persistance.SelectByMadeBy(pl2);
                Assert.AreEqual(121, bids[0].Value, "bids[0].Value isn't 121");
                Assert.AreEqual(pl2, bids[0].MadeBy, "bids[0].MadeBy isn't pl2");
            }
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                IList<AuctionHouse> auctions = persistance.SelectById(itemId);
                Assert.AreEqual(auctions[0].HigherBidOwner, pl2.Id, "auctions[0].HigherBidOwner isn't {0}", pl2.Id);
                Assert.AreEqual(auctions[0].CurrentBid, 121, "auctions[0].CurrentBid isn't 121");
            }
        }

        [Test]
        public void MakeBuyout_Fail_InvalidItem()
        {
            PrepareObjs();
            string result = AuctionHouseUtil.MakeBuyout(12345678, pl1);
            Assert.IsTrue("InvalidItem" == result);
        }

        [Test]
        public void MakeBuyout_Fail_NoCredits()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 2000, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBuyout(itemId, pl1);
            Assert.IsTrue("NoCredits" == result);
        }

        [Test]
        public void MakeBuyout_Fail_NoBuyout()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, pl1);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBuyout(itemId, pl1);
            Assert.IsTrue("NoBuyout" == result);
        }

        [Test]
        public void MakeBuyout_Sucess()
        {
            PrepareObjs();
            IAuctionItem item = new AuctionItem(resource, 100, 100, 200, pl2);
            int itemId = AuctionHouseUtil.PutInAuction(item, fleet);
            string result = AuctionHouseUtil.MakeBuyout(itemId, pl1);
            Assert.IsTrue("Ok" == result);
            Assert.IsTrue(800 == pl1.Principal.Credits);
        }

        [Test]
        public void GetBidTax_Sucess()
        {
            Assert.AreEqual(1, CreditsUtil.GetTax(1));
            Assert.AreEqual(2, CreditsUtil.GetTax(5));
            Assert.AreEqual(3, CreditsUtil.GetTax(9));
            Assert.AreEqual(3, CreditsUtil.GetTax(12));
            Assert.AreEqual(4, CreditsUtil.GetTax(13));
            Assert.AreEqual(4, CreditsUtil.GetTax(16));
            Assert.AreEqual(5, CreditsUtil.GetTax(17));
            Assert.AreEqual(8, CreditsUtil.GetTax(32));
            Assert.AreEqual(9, CreditsUtil.GetTax(33));
            Assert.AreEqual(23, CreditsUtil.GetTax(95));
            Assert.AreEqual(24, CreditsUtil.GetTax(100));
            Assert.AreEqual(150, CreditsUtil.GetTax(1000));
            Assert.AreEqual(156, CreditsUtil.GetTax(1200));
            Assert.AreEqual(157, CreditsUtil.GetTax(1201));
            Assert.AreEqual(150, CreditsUtil.GetTax(1500));
            Assert.AreEqual(149, CreditsUtil.GetTax(1520));
            Assert.AreEqual(136, CreditsUtil.GetTax(1700));
            Assert.AreEqual(160, CreditsUtil.GetTax(2000));
            Assert.AreEqual(320, CreditsUtil.GetTax(4000));
            Assert.AreEqual(321, CreditsUtil.GetTax(4001));
            Assert.AreEqual(400, CreditsUtil.GetTax(5000));
        }

        [Test]
        public void GetNextBid_Sucess()
        {
            Assert.AreEqual(2, CreditsUtil.GetNextBid(1));
            Assert.AreEqual(8, CreditsUtil.GetNextBid(6));
            Assert.AreEqual(11, CreditsUtil.GetNextBid(9));
            Assert.AreEqual(15, CreditsUtil.GetNextBid(12));
            Assert.AreEqual(20, CreditsUtil.GetNextBid(16));
            Assert.AreEqual(39, CreditsUtil.GetNextBid(32));
            Assert.AreEqual(40, CreditsUtil.GetNextBid(33));
            Assert.AreEqual(114, CreditsUtil.GetNextBid(95));
            Assert.AreEqual(119, CreditsUtil.GetNextBid(100));
            Assert.AreEqual(1100, CreditsUtil.GetNextBid(1000));
            Assert.AreEqual(1296, CreditsUtil.GetNextBid(1200));
            Assert.AreEqual(1297, CreditsUtil.GetNextBid(1201));
            Assert.AreEqual(1575, CreditsUtil.GetNextBid(1500));
            Assert.AreEqual(1596, CreditsUtil.GetNextBid(1520));
            Assert.AreEqual(1785, CreditsUtil.GetNextBid(1700));
            Assert.AreEqual(2100, CreditsUtil.GetNextBid(2000));
        }

        [Test]
        public void BuyItem_Fail_NoCredits()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Serium", 100000);
            Assert.IsFalse(result.Ok);
            Assert.AreEqual(result.Failed[0].Log(), "Player does not have enough credits.");
        }

        [Test]
        public void BuyItem_Fail_NoProduct()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Argon", 1);
            Assert.IsFalse(result.Ok);
            Assert.AreEqual(result.Failed[0].Log(), "The product Argon does not exists in this market.");
        }

        [Test]
        public void BuyItem_Fail_NoQuantity()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Prismal", 11);
            Assert.IsFalse(result.Ok);
            Assert.AreEqual(result.Failed[0].Log(), "Not enough product quantity.");
        }

        [Test]
        public void BuyItem_Success_Normal()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Serium", 10);
            Assert.IsTrue(result.Ok);
            Assert.AreEqual(990, p1.Credits);
        }

        [Test]
        public void BuyItem_Success_Rare()
        {
            PrepareObjs();
            Result result = MarketUtil.BuyItem(market, fleetDB, pl1, "Prismal", 5);
            Assert.IsTrue(result.Ok);
            Assert.AreEqual(995, p1.Credits);
        }

        [Test]
        public void NearMarkets_Sucess()
        {
            IList<SectorCoordinate> coords = MarketUtil.GetNearMarkets(new SectorCoordinate(11, 11, 0, 0));
            Assert.AreEqual(8, coords.Count);
            coords = MarketUtil.GetNearMarkets(new SectorCoordinate(1, 1, 0, 0));
            Assert.AreEqual(3, coords.Count);
            coords = MarketUtil.GetNearMarkets(new SectorCoordinate(1, 6, 0, 0));
            Assert.AreEqual(5, coords.Count);
            coords = MarketUtil.GetNearMarkets(new SectorCoordinate(37, 37, 0, 0));
            Assert.AreEqual(3, coords.Count);
            coords = MarketUtil.GetNearMarkets(new SectorCoordinate(37, 11, 0, 0));
            Assert.AreEqual(5, coords.Count);
        }
    }
}
