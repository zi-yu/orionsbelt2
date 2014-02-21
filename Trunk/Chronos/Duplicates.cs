using System.Collections;
using System.Collections.Generic;
using System.Text;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Chronos
{
    public class Duplicates
    {
        private static readonly IList<int> UntracebleIds = new List<int>();
        private static readonly IDictionary<string, int> typeValue = new Dictionary<string, int>();

        static Duplicates()
        {
            UntracebleIds.Add(202);
            UntracebleIds.Add(203);
            UntracebleIds.Add(204);
            UntracebleIds.Add(205);

            typeValue.Add(DuplicateType.BigBuy.ToString(), 10);
            typeValue.Add(DuplicateType.EqualPassword.ToString(), 10);
            typeValue.Add(DuplicateType.IdenticalMail.ToString(), 25);
            typeValue.Add(DuplicateType.MajorBuys.ToString(), 8);
            typeValue.Add(DuplicateType.QuickBuyout.ToString(), 10);
        }

        #region Public Methods

        public static IList<int>  FindDuplicates()
        {
            IList<int> toReturn = new List<int>();
            QuickBuyouts(toReturn);
            IList<Transaction> transactions;
            using (ITransactionPersistance persistance = Persistance.Instance.GetTransactionPersistance())
            {
                transactions = persistance.TypedQuery(
                        "SELECT t FROM SpecializedTransaction t where t.TransactionContext ='AuctionHouse' and  t.UpdatedDate >'{0}' order by t.PrincipalIdSpend,t.IdentifierGain",
                                    DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss"));
            }
            Console.WriteLine("Number of transactions found: {0}", transactions.Count);
            BigBuys(transactions, toReturn);
            MajorNumberOfTransactions(transactions, toReturn);

            PrincipalCaracteristics(toReturn);

            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                persistance.Flush();
            }
            Console.WriteLine("Data Flushed");
            return toReturn;
        }

        public static void NotifyDuplicates(IList<int> ids)
        {
            string[] array = new string[2];
            string ors = BuildIdsOr(ids);
            array[0] = string.Format("select e from SpecializedPrincipal e where {0}", ors);
            ors = BuildDuplicateIdsOr(ids);
            array[1] = string.Format("select e from SpecializedDuplicateDetection e where e.Verified=0 and ({0})", ors);

            IList players;
            using (IPersistanceSession persistance = Persistance.Instance.GetGenericPersistance())
            {
                players = persistance.MultiQuery(array, new Dictionary<string, object>());

                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                {
                    foreach (Principal principal in (IList) players[0])
                    {
                        int days = new TimeSpan(DateTime.Now.Ticks - principal.CreatedDate.Ticks).Days;
                        int blockPoints = 80 + days;
                        int warnPoint = 50 + days/2;
                        
                        Console.WriteLine("Principal:{0}, WarningPoints:{1}",principal.Name,principal.WarningPoints);
                        if (principal.WarningPoints < blockPoints)
                        {
                            StringBuilder sb = new StringBuilder();
                            int dupPoints = GetPoints(principal.Id, (IList) players[1], sb);
                            Console.WriteLine("Duplicated points:{0}", dupPoints);
                            if (dupPoints >= blockPoints)
                            {
                                Console.WriteLine("User Blocked");
                                if (string.IsNullOrEmpty(principal.DuplicatedIds))
                                {
                                    principal.NumberOfWarnings += 1;
                                }
                                principal.DuplicatedIds += sb.ToString();
                                principal.LastWarningDate = DateTime.Now;
                                principal.Locked = true;
                                principal.WarningPoints = dupPoints;
                                persistance2.Update(principal);
                                continue;
                            }

                            if (dupPoints >= warnPoint && principal.WarningPoints < warnPoint)
                            {
                                Console.WriteLine("User Warned");
                                principal.NumberOfWarnings += 1;
                                principal.DuplicatedIds += sb.ToString();
                                principal.LastWarningDate = DateTime.Now;
                                principal.WarningPoints = dupPoints;
                                persistance2.Update(principal);
                            }
                        }
                    }
                }
                Console.WriteLine("Data Flushed");
                persistance.Flush();
            }
        }

        private static int GetPoints(int pId, IList duplicates, StringBuilder sb)
        {
            int toReturn = 0;

            foreach (DuplicateDetection duplicate in duplicates)
            {
                if (duplicate.Duplicate == pId)
                {
                    sb.Append(string.Format("|{0}|", duplicate.Cheater));
                    toReturn += typeValue[duplicate.FindType];
                    continue;
                }
                if (duplicate.Cheater == pId)
                {
                    sb.Append(string.Format("|{0}|", duplicate.Duplicate));
                    toReturn += typeValue[duplicate.FindType];
                    continue;
                }
            }

            return toReturn;
        }



        
        #endregion Public Methods

        #region Private Methods

        private static string BuildIdsOr(IList<int> ids)
        {
            StringBuilder toReturn = new StringBuilder();
            for (int iter = 0; iter < ids.Count; ++iter)
            {
                toReturn.Append("e.Id=");
                toReturn.Append(ids[iter]);
                if (iter + 1 < ids.Count)
                    toReturn.Append(" or ");
            }
            return toReturn.ToString();
        }

        private static string BuildDuplicateIdsOr(IList<int> ids)
        {
            StringBuilder toReturn = new StringBuilder();
            for (int iter = 0; iter < ids.Count; ++iter)
            {
                toReturn.Append("e.Cheater=");
                toReturn.Append(ids[iter]);
                toReturn.Append(" or ");
                toReturn.Append("e.Duplicate=");
                toReturn.Append(ids[iter]);
                if (iter + 1 < ids.Count)
                    toReturn.Append(" or ");
            }
            return toReturn.ToString();
        }

        private static void PrincipalCaracteristics(ICollection<int> toReturn)
        {
            Console.WriteLine("PrincipalCaracteristics");
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList lasts = persistance.Query(
                    "SELECT e.Id,e.Password,e.Email FROM SpecializedPrincipal e where e.CreatedDate >'{0}'",
                                    DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss"));

                Console.WriteLine("Number of principals registed in last 24h: {0}", lasts.Count);

                IList all = persistance.Query(
                    "SELECT e.Id,e.Password,e.Email FROM SpecializedPrincipal e");

                Console.WriteLine("Number of principals: {0}", all.Count);

                Console.WriteLine("Number of QuickBuyouts found: {0}", all.Count);
                using (IDuplicateDetectionPersistance persistance2 = Persistance.Instance.GetDuplicateDetectionPersistance(persistance))
                {
                    foreach (IList list in lasts)
                    {
                        int id = Convert.ToInt32(list[0]);
                        foreach (IList analysing in all)
                        {
                            int iterId = Convert.ToInt32(analysing[0]);

                            if (UntracebleIds.Contains(id))
                            {
                                break;
                            }
                            if(UntracebleIds.Contains(iterId))
                            {
                                continue;
                            }

                            if (id != iterId && list[1].ToString() == analysing[1].ToString())
                            {
                                DuplicateDetection dup = persistance2.Create();
                                dup.Cheater = iterId;
                                dup.Duplicate = id;
                                dup.FindType = DuplicateType.EqualPassword.ToString();
                                dup.ExtraInfo = list[1].ToString();
                                persistance2.Update(dup);
                                Console.WriteLine("EqualPassword");

                                toReturn.Add(iterId);
                                toReturn.Add(id);
                            }

                            if (id != iterId && MailIdentical(list[2].ToString(), analysing[2].ToString()))
                            {
                                DuplicateDetection dup = persistance2.Create();
                                dup.Cheater = iterId;
                                dup.Duplicate = id;
                                dup.FindType = DuplicateType.IdenticalMail.ToString();
                                dup.ExtraInfo = string.Format("{0} <-> {1}",list[2],analysing[2]);
                                persistance2.Update(dup);
                                Console.WriteLine("IdenticalMail");

                                toReturn.Add(iterId);
                                toReturn.Add(id);
                            }
                        }
                    }

                }
                Console.WriteLine("Updates end in QuickBuyouts");
            }
        }

        private static bool MailIdentical(string mail1, string mail2)
        {
            if (string.IsNullOrEmpty(mail1) || string.IsNullOrEmpty(mail2))
            {
                return false;
            }
            //Console.WriteLine(mail2);
            string main = mail1.Substring(0, mail1.IndexOf('@'));
            string mailTemp = mail2.Substring(0, mail2.IndexOf('@'));
            return mailTemp == main;

        }

        private static void MajorNumberOfTransactions(IList<Transaction> transactions, ICollection<int> toReturn)
        {
            Console.WriteLine("MajorNumberOfTransactions");
            IList<Transaction> lasts = new List<Transaction>();
            using (IDuplicateDetectionPersistance persistance = Persistance.Instance.GetDuplicateDetectionPersistance())
            {
                for (int iter = 0; iter < transactions.Count; ++iter)
                {
                    if (0 == iter)
                    {
                        lasts.Add(transactions[iter]);
                        continue;
                    }

                    if (lasts[0].PrincipalIdSpend != transactions[iter].PrincipalIdSpend)
                    {
                        VerifyAndInsert(lasts, toReturn,persistance);
                        lasts.Clear();
                        lasts.Add(transactions[iter]);
                    }
                    else
                    {
                        lasts.Add(transactions[iter]);
                    }
                }

                VerifyAndInsert(lasts, toReturn, persistance);
            }
            Console.WriteLine("End MajorNumberOfTransactions");
        }

        private static void BigBuys(IList<Transaction> transactions, ICollection<int> toReturn)
        {
            Console.WriteLine("BigBuys");
            int count = 0;
            Transaction last = null;
            using (IDuplicateDetectionPersistance persistance = Persistance.Instance.GetDuplicateDetectionPersistance())
            {
                for (int iter = 0; iter < transactions.Count; ++iter)
                {
                    if (0 == iter)
                    {
                        ++count;
                        last = transactions[iter];
                        continue;
                    }

                    if(last.PrincipalIdSpend != transactions[iter].PrincipalIdSpend)
                    {
                        VerifyAndInsert(count, last,toReturn, persistance);
                        last = transactions[iter];
                        count = 0;
                    }
                    ++count;
                }

                VerifyAndInsert(count, last,toReturn, persistance);
            }
            Console.WriteLine("End BigBuys");
        }

        private static bool IsBigTransaction(Transaction transaction)
        {
            double divider = (transaction.CreditsSpend + transaction.SpendCurrentCredits);
            double value = transaction.CreditsSpend;
            return 0.9 < (value/divider);
        }

        private static bool IsBigTransaction(int value, int total)
        {
            double divider = total;
            return 0.9 < (value / divider);
        }

        private static void QuickBuyouts(ICollection<int> toReturn)
        {
            Console.WriteLine("QuickBuyouts");
            using (IAuctionHousePersistance persistance = Persistance.Instance.GetAuctionHousePersistance())
            {
                IList<AuctionHouse> finds = 
                    persistance.TypedQuery("SELECT e FROM SpecializedAuctionHouse e inner join fetch e.OwnerNHibernate p where e.Begin+5>e.BuyedInTick and e.BuyedInTick>0 and e.UpdatedDate >'{0}'",
                                    DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd hh:mm:ss"));

                Console.WriteLine("Number of QuickBuyouts found: {0}", finds.Count);
                using (IDuplicateDetectionPersistance persistance2 = Persistance.Instance.GetDuplicateDetectionPersistance(persistance))
                {
                    foreach (AuctionHouse find in finds)
                    {
                        if (!UntracebleIds.Contains(find.Owner.Principal.Id))
                        {
                            DuplicateDetection dup = persistance2.Create();
                            dup.Cheater = find.Owner.Principal.Id;
                            Principal bidder;
                            using (IPrincipalPersistance persistance3 = Persistance.Instance.GetPrincipalPersistance(persistance))
                            {
                                bidder = persistance3.TypedQuery("select e from SpecializedPrincipal e inner join e.PlayerNHibernate p where p.Id={0}",find.HigherBidOwner)[0];
                            }
                            dup.Duplicate = bidder.Id;
                            dup.FindType = DuplicateType.QuickBuyout.ToString();
                            dup.ExtraInfo = find.Id.ToString();
                            persistance2.Update(dup);

                            toReturn.Add(find.Owner.Principal.Id);
                            toReturn.Add(bidder.Id);
                        }
                    }
                }
                Console.WriteLine("Updates end in QuickBuyouts");
            }
        }

        private static void VerifyAndInsert(IList<Transaction> lasts, ICollection<int> toReturn, IPersistance<DuplicateDetection> persistance)
        {
            Console.WriteLine("VerifyAndInsert");
            if (1 < lasts.Count)
            {
                int total = 0;
                int id = -1;
                Dictionary<int, int> container = new Dictionary<int, int>();
                foreach (Transaction last in lasts)
                {
                    if (last.IdentifierGain != id)
                    {
                        container.Add(last.IdentifierGain, last.CreditsSpend);
                        id = last.IdentifierGain;
                    }
                    else
                    {
                        container[last.IdentifierGain] += last.CreditsSpend;
                    }
                    total += last.CreditsSpend;
                }
                foreach (KeyValuePair<int, int> pair in container)
                {
                    if (IsBigTransaction(pair.Value, total) &&
                        !UntracebleIds.Contains(pair.Key) &&
                        !UntracebleIds.Contains(lasts[0].PrincipalIdSpend))
                    {
                        DuplicateDetection dup = persistance.Create();
                        dup.Cheater = pair.Key;
                        dup.Duplicate = lasts[0].PrincipalIdSpend;
                        dup.FindType = DuplicateType.MajorBuys.ToString();
                        dup.ExtraInfo = ((double) pair.Value/total).ToString();
                        persistance.Update(dup);
                        Console.WriteLine("Update in VerifyAndInsert, id = {0}", dup.Id);

                        toReturn.Add(pair.Key);
                        toReturn.Add(lasts[0].PrincipalIdSpend);
                    }
                }
            }
        }

        private static void VerifyAndInsert(int count, Transaction last, ICollection<int> toReturn, IPersistance<DuplicateDetection> persistance)
        {
            Console.WriteLine("VerifyAndInsert2");
            if (1 == count && IsBigTransaction(last) &&
                !UntracebleIds.Contains(last.IdentifierGain) &&
                !UntracebleIds.Contains(last.PrincipalIdSpend))      
            {
                Console.WriteLine("Save duplicate of transaction {0}", last.Id);
                DuplicateDetection dup = persistance.Create();
                dup.Cheater = last.IdentifierGain;
                dup.Duplicate = last.PrincipalIdSpend;
                dup.FindType = DuplicateType.BigBuy.ToString();

                double divider = (last.CreditsSpend + last.SpendCurrentCredits);
                double value = last.CreditsSpend;

                dup.ExtraInfo = (value/divider).ToString();

                persistance.Update(dup);
                Console.WriteLine("Update in VerifyAndInsert2, id = {0}", dup.Id);

                toReturn.Add(last.IdentifierGain);
                toReturn.Add(last.PrincipalIdSpend);
            }
        }
        #endregion Private Methods
    }
}
