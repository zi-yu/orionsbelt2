using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.PaysafeWS;
using Paysafecard.Client;
using PaymentDescription=OrionsBelt.Core.PaymentDescription;
using Principal=OrionsBelt.Core.Principal;
using TextWriter=System.IO.TextWriter;
using System.Configuration;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public class PaySafe : PaymentBase
    {
        
        #region IPayment Interface

        
        public override string Url
        {
            get { return string.Empty; }
            //get { return ConfigurationManager.AppSettings["sandboxUrl"]; }
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

            tw.Write("<div class='chooseAmmount'><div class='paymentDescription'>");
            tw.Write("<div class='cost'>{0}: {1}{2}</div>", LanguageManager.Localize("Cost"), paymentDescription.Cost, paymentDescription.Currency);
            tw.Write("<div>{0}: {1}  <b>+</b></div>", LanguageManager.Localize("Orions"), paymentDescription.Amount);
            tw.Write("<div>{0}: {1}</div>", LanguageManager.Localize("BonusOrions"), paymentDescription.Bonus);
            tw.Write("<div>{0}: {1}</div>", LanguageManager.Localize("Total"), paymentDescription.Amount+paymentDescription.Bonus);
            tw.Write("</div></div>");


            tw.Write("<div class='paymentButton'><form method='post'><input type='submit' class='button' value='{0}' name='b_{1}'/></form></div></div>",
                LanguageManager.Localize("OrderNow"), paymentDescription.Cost);


            //CreatePost(paymentDescription, tw);
            //PaysafeButton(tw, paymentDescription);

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
            if (!VerifyParamCount(parameters, request))
                return false;

            if (!VerifyQuantity(parameters, request))
                return false;

            if (!VerifyPrincipal(parameters, request))
                return false;

            if (!VerifyTransactionId(parameters, request))
                return false;

            if (!PaysafeVerification(parameters, request))
                return false;
            

            return true;
        }

        public override void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            MakePayment(parameters, message, string.Empty, null);
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
            string serials = parameters["serials"];
            string[] pars = serials.Split(';');

            double payedValue = 0;
            string prefix = ConfigurationManager.AppSettings["serialPrefix"];
            for (int iter = 0; iter < pars.Length; ++iter)
            {
                if(pars[iter].StartsWith(prefix))
                {
                    ++iter;
                }
                else
                {
                    payedValue += Convert.ToDouble(pars[++iter]);
                }
            }

            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                persistance.StartTransaction();

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(parameters["id"]);
                    retry.Method = PaymentMethodEnum.PaySafe.ToString();
                    retry.Request = message;
                    retry.RequestId = parameters["mtid"];
                    //retry.Ammount = parameters["amount"];
                    retry.Ammount = payedValue.ToString();

                    if(payedValue < Convert.ToDouble(parameters["amount"]))
                    {
                        retry.Parameters = "PARTIAL";
                    }

                }
                retry.VerifyState = "Verified";
                retry.Response = response;

                persistance.Update(retry);
                Principal payer;
                int orions = GetOrions(Convert.ToDouble(parameters["amount"]));
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance())
                {
                    payer = persistance2.SelectById(retry.PrincipalId)[0];
                    payer.Credits += orions;
                    persistance2.Update(payer);
                }

                TransactionManager.PaymentTransaction(payer, retry, orions, Convert.ToDouble(retry.Ammount), persistance);

                persistance.CommitTransaction();
                persistance.Flush();
            }

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

        private static bool PaysafeVerification(IDictionary<string, string> parameters, string request)
        {

            /*
            Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
            string merchantId = config["merchantId"];
            MerchantApi api = new MerchantApi(merchantId, config);
            DispositionStateResult currentDispositionState = api.GetDispositionState(parameters["mtid"]);
             */

            bool useWS = Convert.ToBoolean(ConfigurationManager.AppSettings["paysafeUseWS"]);

            if (useWS)
            {
                PaysafeProxy paysafeWS = new PaysafeProxy();
                DispositionData currentDispositionState = paysafeWS.PaymentVerification(parameters["mtid"]);

                if (currentDispositionState.state == PaysafeWS.DispositionState.Created)
                {
                    return CreatedError(parameters, request);
                }

                if (currentDispositionState.state == PaysafeWS.DispositionState.Expired)
                {
                    return ExpiredError(parameters, request);
                }
                parameters.Add("serials", currentDispositionState.serials);
                paysafeWS.MakeDebit(parameters["mtid"], currentDispositionState.amount, currentDispositionState.currency);
            }
            else
            {
                Paysafecard.Client.Configuration config = new Paysafecard.Client.Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
                string merchantId = config["merchantId"];
                MerchantApi api = new MerchantApi(merchantId, config);
                DispositionStateResult result = api.GetDispositionState(parameters["mtid"]);
                SerialNumbersResult serial = api.GetSerialNumbers(parameters["mtid"]);

                if (result.State == Paysafecard.Client.DispositionState.Created)
                {
                    return CreatedError(parameters, request);
                }

                if (result.State == Paysafecard.Client.DispositionState.Expired)
                {
                    return ExpiredError(parameters, request);
                }
                parameters.Add("serials", serial.Serialnumbers);

                api.ExecuteDebit(parameters["mtid"], result.Amount, result.Currency, true);

            }

            return true;
        }

        private static bool ExpiredError(IDictionary<string, string> parameters, string request)
        {
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                Payment p = persistance.Create();
                p.PrincipalId = Convert.ToInt32(parameters["id"]);
                p.Method = PaymentMethodEnum.PaySafe.ToString();
                p.Request = request;
                p.RequestId = parameters["mtid"];
                p.Ammount = parameters["amount"];
                p.VerifyState = "BadRequest";
                p.Parameters = "currentDispositionState.State = Expired";
                persistance.Update(p);
                persistance.Flush();
            }
            return false;
        }

        private static bool CreatedError(IDictionary<string, string> parameters, string request)
        {
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                Payment p = persistance.Create();
                p.PrincipalId = Convert.ToInt32(parameters["id"]);
                p.Method = PaymentMethodEnum.PaySafe.ToString();
                p.Request = request;
                p.RequestId = parameters["mtid"];
                p.Ammount = parameters["amount"];
                p.VerifyState = "BadRequest";
                p.Parameters = "currentDispositionState.State = Created";
                persistance.Update(p);
                persistance.Flush();
            }
            return false;
        }


        private static bool VerifyTransactionId(IDictionary<string, string> info, string request)
        {
            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(p) from SpecializedPayment p where p.RequestId = :id and p.Method='PaySafe' and p.VerifyState='Verified'", Hql.Param("id", info["mtid"])));

            if (0 < total)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["id"]);
                    p.Method = PaymentMethodEnum.PaySafe.ToString();
                    p.Request = request;
                    p.RequestId = info["mtid"];
                    p.Ammount = info["amount"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = "RepeatedId";
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
            if (!Double.TryParse(info["amount"], out aux) || !IsValidQuantity(aux))
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["id"]);
                    p.Method = PaymentMethodEnum.PaySafe.ToString();
                    p.Request = request;
                    p.RequestId = info["mtid"];
                    p.Ammount = info["amount"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidAmmount:{0}", info["amount"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyPrincipal(IDictionary<string, string> info, string request)
        {
            if (Utils.Principal.Id.ToString() != info["id"])
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Utils.Principal.Id;
                    p.Method = PaymentMethodEnum.PaySafe.ToString();
                    p.Request = request;
                    p.RequestId = info["mtid"];
                    p.Ammount = info["amount"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("CurrentPrincipal:{0}; RequestPrincipal:{1}", p.PrincipalId, info["id"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyParamCount(ICollection<KeyValuePair<string, string>> info, string request)
        {
            if (info.Count < 3)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Utils.Principal.Id;
                    p.Method = PaymentMethodEnum.PaySafe.ToString();
                    p.Request = request;
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidNumberOfParameters:{0}", info.Count);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        #endregion Validations

        private static void PaysafeButton(TextWriter tw, PaymentDescription paymentDescription)
        {
             
			//string buttonImage = ConfigurationManager.AppSettings["defaultButton"];
        	//string buttonImage = ResourcesManager.GetPaymentsImage("PaymentBackground");
			tw.Write("<div class='chooseAmmount'><div class='paymentDescription'>");
			tw.Write("<div class='cost'>{0}: {1}€</div>", LanguageManager.Localize("Cost"), paymentDescription.Cost);
            tw.Write("<div>{0}: {1}  <b>+</b></div>", LanguageManager.Localize("Orions"), paymentDescription.Amount);
			tw.Write("<div>{0}: {1}</div>", LanguageManager.Localize("BonusOrions"), paymentDescription.Bonus);
			tw.Write("</div></div>");


			tw.Write("<div class='paymentButton'><input type='submit' class='button' value='{0}' /></div></div></form>", LanguageManager.Localize("OrderNow"));
        }

        /*
        private static void CreatePost(PaymentDescription paymentDescription, TextWriter tw)
        {
            try
            {
                PaysafeProxy paysafeWS = new PaysafeProxy();
                string basePath = Server.Properties.BaseUrl;
                string form = paysafeWS.CreatePost(paymentDescription.Cost, Utils.Principal.Id, Utils.Principal.Locale, basePath);
                tw.WriteLine(form);
                /*
                Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
                string merchantId = config["merchantId"];
                string confCur = config["currency"];
                string businessType = config["businessType"];
                string reportingCriteria = config["reportingCriteria"];
                string amount = string.Format("{0}.00", paymentDescription.Cost);
                MerchantApi api = new MerchantApi(merchantId, config, config["language"]);
                string merchantTransactionId = api.GenerateMerchantTransactionId();
                string okUrl = string.Format("{0}?mtid={1}&amount={2}&id={3}", config["okUrl"],
                                             merchantTransactionId, paymentDescription.Cost, Utils.Principal.Id);
                string notOkUrl = config["notOkUrl"];
                api.CreateDisposition(merchantTransactionId, amount, confCur, businessType,
                                      reportingCriteria, okUrl, notOkUrl);

                string lang = Utils.Principal.Locale;
                if (string.IsNullOrEmpty(lang))
                {
                    lang = config["clientLang"];
                }
                string url = string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", config["redirect_URL"],
                                           "?currency=", confCur,
                                           "&mid=", merchantId,
                                           "&mtid=", merchantTransactionId,
                                           "&amount=", amount,
                                           "&language=", lang);

                tw.Write("<form action='{0}' method='post'>", url);
                 
            }
            catch (PaysafecardException pscEx)
            {
                ExceptionLogger.Log(pscEx);
            }
        }
        */

        #endregion Private Methods

    }
}
