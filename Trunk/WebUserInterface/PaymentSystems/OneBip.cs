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
    public class OneBip : PaymentBase
    {
        private static readonly string hashMixer = "VT}[=5w^;k@1]8";
        
        #region IPayment Interface

        public override string Mail
        {
            get { return "610369"; }
            //get { return ConfigurationManager.AppSettings["sandboxMail"]; }
        }

        public override string Url
        {
            get { return ConfigurationManager.AppSettings["onebipUrl"]; }
            //get { return ConfigurationManager.AppSettings["sandboxUrl"]; }
        }

        public override bool IsValidQuantity(double quantity)
        {
            if (quantity == 200 || quantity == 400)
                return true;
            return false;
        }

        protected override int GetOrions(double payMoney)
        {
            if (payMoney == 200)
            {
                return 400;
            }
            if (payMoney == 400)
            {
                return 900;
            }

            return 0;
        }

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
            OneBipData(tw);
			OneBipGenericData(tw, principal, currency, paymentDescription);
            return tw.ToString();
        }

        /// <summary>
        /// Validate the request
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <returns>Validation result</returns>
        public override bool IsValidRequest(Dictionary<string, string> parameters, string request)
        {
            if (!VerifyHash(parameters, request))
                return false;

            if (!VerifyQuantity(parameters, request))
                return false;

            if (!VerifyCurrency(parameters, request))
                return false;

            if (!VerifyTransactionId(parameters, request))
                return false;

            return true;
        }

        public override void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            MakePayment(parameters, message, parameters["principal"], null);
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

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(parameters["principal"]);
                    retry.Method = PaymentMethodEnum.OneBip.ToString();
                    retry.Request = message;
                    retry.RequestId = parameters["payment_id"];
                    retry.Ammount = (Convert.ToInt32(parameters["original_price"])/100).ToString();
 
                }
                retry.VerifyState = "Verified";
                retry.Response = response;

                persistance.Update(retry);
                Principal payer;
                int orions = GetOrions(Convert.ToDouble(parameters["original_price"]));
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance())
                {
                    payer = persistance2.SelectById(retry.PrincipalId)[0];
                    payer.Credits += orions;
                    persistance2.Update(payer);
                }

                TransactionManager.PaymentTransaction(payer, retry, orions, Convert.ToDouble(parameters["original_price"])/100, persistance);

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

        #region Validations

        private static bool VerifyTransactionId(IDictionary<string, string> info, string request)
        {
            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(p) from SpecializedPayment p where p.RequestId = :id and p.Method='OneBip'", Hql.Param("id", info["payment_id"])));

            if (0 < total)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["principal"]);
                    p.Method = PaymentMethodEnum.OneBip.ToString();
                    p.Request = request;
                    p.RequestId = info["payment_id"];
                    p.Ammount = info["original_price"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = "RepeatedId";
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyHash(IDictionary<string, string> info, string request)
        {

            string concat = string.Format("{0}{1}{2}{3}", info["principal"], info["item_code"], info["mils"], hashMixer);
            
            string hash = FormsAuthentication.HashPasswordForStoringInConfigFile(concat, "sha1");
            if (info["inspect"] != hash)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["principal"]);
                    p.Method = PaymentMethodEnum.OneBip.ToString();
                    p.Request = request;
                    p.RequestId = info["payment_id"];
                    p.Ammount = info["original_price"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("{0} != {1}", info["inspect"], hash);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyCurrency(IDictionary<string, string> info, string request)
        {
            if (PaymentUtils.CurrencyToPaypal[CurrencyEnum.Euro] != info["original_currency"])
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["principal"]);
                    p.Method = PaymentMethodEnum.OneBip.ToString();
                    p.Request = request;
                    p.RequestId = info["payment_id"];
                    p.Ammount = info["original_price"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidCurrency:{0}", info["original_currency"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private bool VerifyQuantity(IDictionary<string, string> info, string request)
        {
            double aux;
            if (!Double.TryParse(info["original_price"], out aux) || !IsValidQuantity(Convert.ToDouble(info["original_price"])))
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["principal"]);
                    p.Method = PaymentMethodEnum.OneBip.ToString();
                    p.Request = request;
                    p.RequestId = info["payment_id"];
                    p.Ammount = info["original_price"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidAmmount:{0}", info["original_price"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        #endregion Validations


        private static void OneBipGenericData(TextWriter tw, Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription)
        {
        	string cost = paymentDescription.Cost.ToString();
            //Logger.Debug("Cost value = {0}", cost);
        	cost = (Convert.ToDouble(cost.Replace(',', '.'))*100).ToString();
            int mils = DateTime.Now.Millisecond;
            string value = String.Format("{0}{1}{2}{3}", principal.Id, paymentDescription.Data, mils, hashMixer);
            string inspect = FormsAuthentication.HashPasswordForStoringInConfigFile(value, "sha1");
            tw.Write("<input name='command' type='hidden' value='standard_pay' />");
            tw.Write("<input name='site_id' type='hidden' value='2422' />");
            tw.Write("<input name='item_code' type='hidden' value='{0}' />", paymentDescription.Data);
            tw.Write("<input name='item_name' type='hidden' value='{0} Orions' />", paymentDescription.Amount+paymentDescription.Bonus);
			tw.Write("<input name='price' type='hidden' value='{0}' />", cost);
            //tw.Write("<input name='lang' type='hidden' value='{0}' />", LanguageManager.CurrentLanguage);
            tw.Write("<input name='currency' type='hidden' value='{0}' />", PaymentUtils.CurrencyToPaypal[currency]);
            tw.Write("<input name='return_url' type='hidden' value='{0}{1}' />",
                Server.Properties.BaseUrl, ConfigurationManager.AppSettings["confirmationUrl"]);
            tw.Write("<input name='notify_url' type='hidden' value='{0}{1}' />",
                Server.Properties.BaseUrl, ConfigurationManager.AppSettings["onebipNotificationUrl"]);
            tw.Write("<input name='cancel_url' type='hidden' value='{0}{1}' />",
                Server.Properties.BaseUrl, "Account/NotOk.aspx");
            //tw.Write("<input name='logo_url' type='hidden' value='{0}' />", Combine(ResourcesManager.ImagesCommonPath, ConfigurationManager.AppSettings["logoUrl"]));
            tw.Write("<input name='logo_url' type='hidden' value='{0}' />",  ConfigurationManager.AppSettings["logoUrl"]);

            tw.Write("<input name='custom[mils]' type='hidden' value='{0}' />", mils);
            tw.Write("<input name='custom[inspect]' type='hidden' value='{0}' />", inspect);

            tw.Write("<input name='customer_firstname' type='hidden' value='{0}' />", principal.DisplayName);
            tw.Write("<input name='customer_email' type='hidden' value='{0}' />", principal.Email);
            //tw.Write("<input name='debug' type='hidden' value='{0}' />", ConfigurationManager.AppSettings["oneBipDebug"]);
            //tw.Write("<input name='remote_txid' type='hidden' value='{0}' />", principal.Id);
            tw.Write("<input name='custom[principal]' type='hidden' value='{0}' />", principal.Id);
             
			//string buttonImage = ConfigurationManager.AppSettings["defaultButton"];
        	//string buttonImage = ResourcesManager.GetPaymentsImage("PaymentBackground");
			tw.Write("<div class='chooseAmmount'><div class='paymentDescription'>");
			tw.Write("<div class='cost'>{0}: {1}€</div>", LanguageManager.Instance.Get("Cost"), paymentDescription.Cost);
            tw.Write("<div>{0}: {1}  <b>+</b></div>", LanguageManager.Instance.Get("Orions"), paymentDescription.Amount);
			tw.Write("<div>{0}: {1}</div>", LanguageManager.Instance.Get("BonusOrions"), paymentDescription.Bonus);
			tw.Write("</div></div>");


			tw.Write("<div class='paymentButton'><input type='submit' class='button' value='{0}' /></div></div></form>", LanguageManager.Instance.Get("OrderNow"));
        }

        private void OneBipData(TextWriter tw)
        {
            tw.Write("<form action='{0}' method='post'>", Url);
            tw.Write("<input name='username' type='hidden' value='{0}' />", Mail);
        }


        #endregion Private Methods

    }
}
