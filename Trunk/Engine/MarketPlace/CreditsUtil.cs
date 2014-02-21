using System;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using Loki.DataRepresentation;

namespace OrionsBelt.Engine.MarketPlace
{
    public class CreditsUtil
    {
        #region Public Methods

        public static int GetTax(int value)
        {
            if (value > 1700)
            {
                return Convert.ToInt32(Math.Ceiling(value * 0.08));
            }
            return Convert.ToInt32(Math.Ceiling(value * ((-2.5 * value / 250) + 25) / 100));
        }

        public static int GetValueWithoutTax(int value)
        {
            if (value > 1700)
            {
                return value - Convert.ToInt32(Math.Ceiling(value * 0.08));
            }
            return value - Convert.ToInt32(Math.Ceiling(value * ((-2.5 * value / 250) + 25) / 100));
        }

        public static int GetNextBid(int value)
        {
            if (value > 1500)
            {
                return value + Convert.ToInt32(Math.Ceiling(value * 0.05));
            }
            return value + Convert.ToInt32(Math.Ceiling(value * ((-2.0 * value / 200) + 20) / 100));
        }

        public static void ReferrerPayment(Principal principal, int orionsReceived)
        {
            if(principal.ReferrerId <= 0)
            {
                return;
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                int prize = Convert.ToInt32(orionsReceived*0.1);
                Principal referrer =
                    persistance.TypedQuery("select e from SpecializedPrincipal e where e.Id={0}", principal.ReferrerId)[0];
                referrer.Credits += prize;
                persistance.Update(referrer);
                TransactionManager.ReferalTransaction(principal, referrer, orionsReceived, prize, persistance);
            }
        }

        /// <summary>
        /// Give orions for voting
        /// </summary>
        /// <param name="principal">Principal that will receive the orions</param>
        /// <param name="orionsReceived">Number of orions that will be increment</param>
        public static void VotingReward(Principal principal, int orionsReceived)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                persistance.StartTransaction();
                principal.Credits += orionsReceived;
                TransactionManager.VotingTransaction(principal, orionsReceived, persistance);
                persistance.CommitTransaction();
            }
        }

        public static void QuickReferralReward(IPersistanceSession session, Principal principal, int orionsReceived)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance(session))
            {
                principal.Credits += orionsReceived;
                TransactionManager.QuickReferralTransaction(principal, orionsReceived, persistance);
            }
        }

        #endregion Public Methods
    }
}
