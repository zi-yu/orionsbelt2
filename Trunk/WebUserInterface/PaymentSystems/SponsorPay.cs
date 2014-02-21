using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Web.Security;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.IO;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public class SponsorPay : PaymentBase
    {
        private static readonly string hashMixer = "VT}[=5w^;k@1]8";
        
        #region IPayment Interface



        /// <summary>
        /// Gets the string for a button with a paypal request
        /// </summary>
        /// <param name="principal">Principal that will do the payment</param>
        /// <param name="currency">Currency of the payment</param>
		/// <param name="paymentDescription">Payment Description</param>
        /// <returns>String representing the code that make a request</returns>
		public override string Render(Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription)
        {
            TextWriter tw = new StringWriter();
            tw.WriteLine("<iframe width='100%' height='600' src='http://iframe.sponsorpay.com/?appid={1}&uid={0}'></iframe>",
                principal.Id, ConfigurationManager.AppSettings["applicationID"]);
            return tw.ToString();
        }

        /// <summary>
        /// Validate the request
        /// </summary>
        /// <param name="info">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <returns>Validation result</returns>
        public override bool IsValidRequest(Dictionary<string, string> info, string request)
        {
            if (!VerifyHash(info, request))
            {
                return false;
            }

            if (!VerifyTransactionId(info, request))
            {
                return false;
            }
            return true;
        }

        public override void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            MakePayment(parameters, message, parameters["uid"], null);
            //Afectar as tabelas de payment, transaction e por orions no principal
            
        }

        /// <summary>
        /// Log a request well recieved but not yet verified
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <param name="exception">Comunication exception</param>
        protected override void WriteNotVerified(Dictionary<string, string> parameters, string request, WebException exception)
        {

        }

        /// <summary>
        /// Make all payment process
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="message">Request string (paramenters in string)</param>
        /// <param name="response">Response string</param>
        /// <param name="retry">If is not null is a retry</param>
        protected override void MakePayment(Dictionary<string, string> parameters, string message, string response, Payment retry)
        {
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                persistance.StartTransaction();
                int orions = Convert.ToInt32(WebUtilities.GetDouble(parameters["amount"]));

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(parameters["uid"]);
                    retry.Method = PaymentMethodEnum.SponsorPay.ToString();
                    retry.Request = message;
                    retry.RequestId = parameters["_trans_id_"];
                    retry.Ammount = (Convert.ToDouble(orions) / 200).ToString();
 
                }
                retry.VerifyState = "Verified";
                retry.Response = "VERIFIED";

                persistance.Update(retry);
                Principal payer;
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance())
                {
                    payer = persistance2.SelectById(retry.PrincipalId)[0];
                    payer.Credits += orions;
                    persistance2.Update(payer);
                }

                TransactionManager.PaymentTransaction(payer, retry, orions, Convert.ToDouble(orions) / 200, persistance);

                persistance.CommitTransaction();
                persistance.Flush();
            }
            
        }

        /// <summary>
        /// Make the payment invalid
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="message">Request string (paramenters in string)</param>
        /// <param name="response">Response string</param>
        /// <param name="retry">If is not null is a retry</param>
        protected override void MakeInvalid(Dictionary<string, string> parameters, string message, string response, Payment retry)
        {
            
        }

        #endregion IPayment Interface

        #region Private Methods

        private static bool VerifyHash(Dictionary<string, string> info, string request)
        {
            string concat = string.Format("{0}{1}{2}{3}", hashMixer, info["uid"], info["amount"], info["_trans_id_"].ToLower());

            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(concat, "sha1");
            if (info["sid"] != hash)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["uid"]);
                    p.Method = PaymentMethodEnum.SponsorPay.ToString();
                    p.Request = request;
                    p.RequestId = info["_trans_id_"];
                    p.Ammount = (Convert.ToDouble(info["amount"]) / 200).ToString();
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("{0} != {1}", info["sid"], hash);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyTransactionId(IDictionary<string, string> info, string request)
        {
            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(p) from SpecializedPayment p where p.RequestId = :id and p.Method='SponsorPay'", Hql.Param("id", info["_trans_id_"])));

            if (0 < total)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["uid"]);
                    p.Method = PaymentMethodEnum.SponsorPay.ToString();
                    p.Request = request;
                    p.RequestId = info["_trans_id_"];
                    p.Ammount = (Convert.ToDouble(info["amount"])/200).ToString();
                    p.VerifyState = "BadRequest";
                    p.Parameters = "RepeatedId";
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        #endregion Private Methods

    }
}
