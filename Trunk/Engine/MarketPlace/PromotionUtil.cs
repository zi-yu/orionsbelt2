using System;
using System.Collections.Generic;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.Engine.MarketPlace
{
    public class PromotionUtil
    {

        #region Public Methods

        /// <summary>
        /// Create a promotion
        /// </summary>
        /// <param name="owner">Principal that required the promotion. Can be null</param>
        /// <param name="name">Promotion name</param>
        /// <param name="begin">Promotion beginning</param>
        /// <param name="end">Promotion ends</param>
        /// <param name="rType">Revenue type</param>
        /// <param name="revenue">Revenue value</param>
        /// <param name="pType">Promotion type</param>
        /// <param name="rangeBegin">If promotion type needs a begin value</param>
        /// <param name="rangeEnd">If promotion type needs a end value</param>
        /// <param name="promoCode">If promotion type needs a especific value</param>
        /// <param name="bType">Bonus type</param>
        /// <param name="bonus">Bonus value</param>
        /// <param name="description">Internal description</param>
        /// <returns>The success or insuccess of the operation</returns>     
        public static bool CreatePromotion(int owner, string name, DateTime begin, DateTime end, string rType,
            double revenue, string pType, int rangeBegin, int rangeEnd, int promoCode, string bType, int bonus, string description)
        {
            if (0 == owner)
            {
                return CreatePromotion(null, name, begin, end, rType,
                                       revenue, pType, rangeBegin, rangeEnd, promoCode, bType, bonus, description);
            }

            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                return CreatePromotion(persistance.SelectById(owner)[0], name, begin, end, rType,
                                       revenue, pType, rangeBegin, rangeEnd, promoCode, bType, bonus, description);
            }
        }


        /// <summary>
        /// Create a promotion
        /// </summary>
        /// <param name="owner">Principal that required the promotion. Can be null</param>
        /// <param name="name">Promotion name</param>
        /// <param name="begin">Promotion beginning</param>
        /// <param name="end">Promotion ends</param>
        /// <param name="rType">Revenue type</param>
        /// <param name="revenue">Revenue value</param>
        /// <param name="pType">Promotion type</param>
        /// <param name="rangeBegin">If promotion type needs a begin value</param>
        /// <param name="rangeEnd">If promotion type needs a end value</param>
        /// <param name="promoCode">If promotion type needs a especific value</param>
        /// <param name="bType">Bonus type</param>
        /// <param name="bonus">Bonus value</param>
        /// <param name="description">Internal description</param>
        /// <returns>The success or insuccess of the operation</returns>     
        public static bool CreatePromotion(Principal owner, string name, DateTime begin, DateTime end, string rType,
            double revenue, string pType, int rangeBegin, int rangeEnd, int promoCode, string bType, int bonus, string description)
            
        {
            if (rangeBegin > rangeEnd || end < DateTime.Now || end < begin)
            {
                return false;
            }
            using (IPromotionPersistance persistance = Persistance.Instance.GetPromotionPersistance())
            {
                Promotion prom = persistance.Create();
                prom.Name = name;
                if (null != owner)
                {
                    prom.Owner = owner;
                }
                prom.BeginDate = begin;
                prom.EndDate = end;
                prom.RevenueType = rType;
                prom.Revenue = revenue;
                prom.PromotionType = pType;
                prom.RangeBegin = rangeBegin;
                prom.RangeEnd = rangeEnd;
                prom.PromotionCode = promoCode;
                prom.BonusType = bType;
                prom.Bonus = bonus;
                prom.Description = description;
                if(begin > DateTime.Now)
                {
                    prom.Status = PromotionStatusType.Pending.ToString();
                }
                else
                {
                    prom.Status = PromotionStatusType.Active.ToString();
                }
                persistance.Update(prom);
                persistance.Flush();
            }
            return true;
        }

        /// <summary>
        /// Verify if is a promotion and give it
        /// </summary>
        /// <param name="serials">Payment serial numbers</param>
        /// <param name="principalId">Payer identifier</param>
        /// <returns>If a promotion has given</returns>     
        public static bool VerifyPromotion(int[] serials, int principalId)
        {
            
            using (IPromotionPersistance persistance = Persistance.Instance.GetPromotionPersistance())
            {
                IList<Promotion> promotions =
                    persistance.TypedQuery("select e from SpecializedPromotion e left join fetch e.ActivationsNHibernate where e.PromotionType='Range' and e.Status='Active'");

                foreach (Promotion promotion in promotions)
                {
                    foreach (int serial in serials)
                    {
                        if(promotion.RangeBegin <= serial && promotion.RangeEnd >= serial)
                        {
                            promotion.Uses += 1;
                            persistance.Update(promotion);

                            bool detected = false;
                            foreach (ActivatedPromotion activation in promotion.Activations)
                            {
                                if (activation.Code == serial.ToString())
                                {
                                    detected = true;
                                    break;
                                }
                            }
                            if(detected)
                            {
                                continue;
                            }


                            Principal prin;
                            using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance(persistance))
                            {
                                prin = persistance2.SelectById(principalId)[0];
                                if (promotion.Bonus > 0)
                                {
                                    prin.Credits += promotion.Bonus;
                                    persistance2.Update(prin);
                                    TransactionManager.PromotionTransaction(prin,promotion.Bonus,promotion);
                                }
                            }
                            

                            using (IActivatedPromotionPersistance persistance2 = Persistance.Instance.GetActivatedPromotionPersistance(persistance))
                            {
                                ActivatedPromotion act = persistance2.Create();
                                act.Code = serial.ToString();
                                act.Principal = prin;
                                act.Promotion = promotion;
                                act.Used = true;
                                persistance2.Update(act);
                                
                            }
                            persistance.Flush();
                            return true;
                        }
                    }
                }
                persistance.Flush();
            }
            
            return false;
        }

        #endregion Public Methods

    }
}
