using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.IO;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebUserInterface.PaysafeWS;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public class Paypal : PaymentBase
    {
        
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
            PayPalData(tw);
			PayPalGenericData(tw, principal, currency, paymentDescription);
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
            if (!VerifyQuantity(parameters, request))
                return false;

            if (!VerifyCurrency(parameters, request))
                return false;

            if (!VerifyMail( parameters, request))
                return false;

            if (!VerifyTransactionId(parameters, request))
                return false;

            if (!VerifyState(parameters, request))
                return false;

            return true;
        }

        /// <summary>
        /// Log a request well recieved but not yet verified
        /// </summary>
        /// <param name="parameters">Request parameters</param>
        /// <param name="request">Request string (paramenters in string)</param>
        /// <param name="exception">Comunication exception</param>
        protected override void WriteNotVerified(Dictionary<string, string> parameters, string request, WebException exception)
        {
            string content;
            using (Stream responseStream = exception.Response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(responseStream))
                {
                    content = reader.ReadToEnd();
                }
            }
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                int parentId = GetParentId(persistance, parameters, "NotVerified",null);

                Payment p = persistance.Create();
                p.PrincipalId = Convert.ToInt32(parameters["item_number"]);
                p.Method = PaymentMethodEnum.PayPal.ToString();
                p.Request = request;
                p.RequestId = parameters["txn_id"];
                p.Ammount = parameters["mc_gross"];
                p.VerifyState = "NotVerified";
                if (0 != parentId)
                {
                    p.ParentPayment = parentId;
                }
                p.Response = content;
                p.Parameters = exception.Status.ToString();
                persistance.Update(p);
                persistance.Flush();
            }
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
                int parentId = GetParentId(persistance, parameters, "Verified", retry);

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(parameters["item_number"]);
                    retry.Method = PaymentMethodEnum.PayPal.ToString();
                    retry.Request = message;
                    retry.RequestId = parameters["txn_id"];
                    retry.Ammount = parameters["mc_gross"];
                    if (0 != parentId)
                    {
                        retry.ParentPayment = parentId;
                    }
                }
                retry.VerifyState = "Verified";
                retry.Response = response;

                persistance.Update(retry);
                Principal payer;
                int orions = GetOrions(Convert.ToDouble(parameters["mc_gross"]));
                using (IPrincipalPersistance persistance2 = Persistance.Instance.GetPrincipalPersistance())
                {
                    payer = persistance2.SelectById(retry.PrincipalId)[0];
                    payer.Credits += orions;
                    persistance2.Update(payer);
                }

                TransactionManager.PaymentTransaction(payer,retry, orions,Convert.ToDouble(parameters["mc_gross"]),persistance);

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
            using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
            {
                int parentId = GetParentId(persistance, parameters, "Invalid", retry);

                if (null == retry)
                {
                    retry = persistance.Create();
                    retry.PrincipalId = Convert.ToInt32(parameters["item_number"]);
                    retry.Method = PaymentMethodEnum.PayPal.ToString();
                    retry.Request = message;
                    retry.Ammount = parameters["mc_gross"];
                    retry.RequestId = parameters["txn_id"];
                    if (0 != parentId)
                    {
                        retry.ParentPayment = parentId;
                    }
                }
                retry.Response = response;
                retry.VerifyState = "Invalid";
                persistance.Update(retry);
                persistance.Flush();
            }
        }


        public override void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            try
            {
                Logger.Debug(LogType.IPN, "Message: " + message);
                bool useWS = Convert.ToBoolean(ConfigurationManager.AppSettings["payPalUseWS"]);
                VerifyResult res;
                if (useWS)
                {
                    PaysafeProxy paysafeWS = new PaysafeProxy();
                    res = paysafeWS.PaypalVerification(Url, message);
                }
                else
                {
                    res = PaypalVerification(Url, message);
                }
                Logger.Debug(LogType.IPN, "Result: " + res.success);
                if (!res.success && null == retry)
                {
                    using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                    {
                        int parentId = GetParentId(persistance, parameters, "NotVerified", null);

                        Payment p = persistance.Create();
                        p.PrincipalId = Convert.ToInt32(parameters["item_number"]);
                        p.Method = PaymentMethodEnum.PayPal.ToString();
                        p.Request = message;
                        p.RequestId = parameters["txn_id"];
                        p.Ammount = parameters["mc_gross"];
                        p.VerifyState = "NotVerified";
                        if (0 != parentId)
                        {
                            p.ParentPayment = parentId;
                        }
                        p.Response = res.result;
                        //p.Parameters = exception.Status.ToString();
                        persistance.Update(p);
                        persistance.Flush();
                    }
                }
                else
                {
                    Logger.Debug(LogType.IPN, "Content: " + res.result);
                    if ("VERIFIED" == res.result)
                    {
                        MakePayment(parameters, message, res.result, retry);
                    }
                    else
                    {
                        MakeInvalid(parameters, message, res.result, retry);
                    }
                    Logger.Debug(LogType.IPN, res.result);
                }
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
            }
        }

        private VerifyResult PaypalVerification(string url, string message)
        {
            VerifyResult toReturn = new VerifyResult();
            toReturn.success = true;
            try
            {
                //Logger.Debug("URL:{0}",Url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
                //Logger.Debug("Passou request");
                SetRequestParams(request);
                //Logger.Debug("Passou params");
                request.ContentLength = message.Length;
                //Logger.Debug("Message: {0}", message);

                using (Stream requestStream = request.GetRequestStream())
                {
                    // Logger.Debug("Request: {0}", requestStream.ToString());
                    using (StreamWriter writer = new StreamWriter(requestStream))
                    {
                        writer.Write(message);
                        //Logger.Debug("writer: {0}", writer.ToString());
                        writer.Close();
                    }
                    requestStream.Close();
                }

                WebResponse response;
                int rentries = 0;
                bool sucess = false;
                while (!sucess && rentries < 3)
                {
                    try
                    {
                        response = request.GetResponse();
                        string content;
                        using (Stream responseStream = response.GetResponseStream())
                        {
                            using (StreamReader reader = new StreamReader(responseStream))
                            {
                                content = reader.ReadToEnd();
                            }
                        }
                        response.Close();
                        sucess = true;
                        toReturn.result = content;
                    }
                    catch (WebException ex)
                    {
                        ++rentries;
                        if (rentries >= 3)
                        {
                            toReturn.success = false;
                            toReturn.result = ex.Message;
                            return toReturn;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                toReturn.success = false;
                toReturn.result = ex.Message;
            }
            return toReturn;
        }

        #endregion IPayment Interface

        #region Private Methods

        #region Validations

        private static bool VerifyTransactionId(IDictionary<string, string> info, string request)
        {
            int total = Convert.ToInt32(Hql.ExecuteScalar("select count(p) from SpecializedPayment p where p.RequestId = :id and p.VerifyState='VERIFIED' and p.Method='PayPal'", Hql.Param("id", info["txn_id"])));

            if (0 < total)
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["item_number"]);
                    p.Method = PaymentMethodEnum.PayPal.ToString();
                    p.Request = request;
                    p.RequestId = info["txn_id"];
                    p.Ammount = info["mc_gross"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = "RepeatedId";
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyState(IDictionary<string, string> info, string request)
        {
            if (info["payment_status"] != "COMPLETED")
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["item_number"]);
                    p.Method = PaymentMethodEnum.PayPal.ToString();
                    p.Request = request;
                    p.RequestId = info["txn_id"];
                    p.Ammount = info["mc_gross"];
                    p.VerifyState = info["payment_status"];
                    p.Parameters = info["pending_reason"];
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private bool VerifyMail(IDictionary<string, string> info, string request)
        {
            if (base.Mail.ToUpper() != info["receiver_email"])
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["item_number"]);
                    p.Method = PaymentMethodEnum.PayPal.ToString();
                    p.Request = request;
                    p.RequestId = info["txn_id"];
                    p.Ammount = info["mc_gross"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidMail:{0}", info["receiver_email"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        private static bool VerifyCurrency(IDictionary<string, string> info, string request)
        {
            if (PaymentUtils.CurrencyToPaypal[CurrencyEnum.Euro] != info["mc_currency"])
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["item_number"]);
                    p.Method = PaymentMethodEnum.PayPal.ToString();
                    p.Request = request;
                    p.RequestId = info["txn_id"];
                    p.Ammount = info["mc_gross"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidCurrency:{0}", info["mc_currency"]);
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
            if (!Double.TryParse(info["mc_gross"], out aux) || !base.IsValidQuantity(Convert.ToDouble(info["mc_gross"])))
            {
                using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                {
                    Payment p = persistance.Create();
                    p.PrincipalId = Convert.ToInt32(info["item_number"]);
                    p.Method = PaymentMethodEnum.PayPal.ToString();
                    p.Request = request;
                    p.RequestId = info["txn_id"];
                    p.Ammount = info["mc_gross"];
                    p.VerifyState = "BadRequest";
                    p.Parameters = string.Format("InvalidAmmount:{0}", info["mc_gross"]);
                    persistance.Update(p);
                    persistance.Flush();
                }
                return false;
            }
            return true;
        }

        #endregion Validations

        private static int GetParentId(IPaymentPersistance persistance, IDictionary<string, string> parameters, string state, Payment retry)
        {
            int retryId = 0;
            if(null != retry)
            {
                retryId = retry.Id;
            }
            IList<Payment> prePays = persistance.SelectByRequestId(parameters["txn_id"]);
            int parentId = 0;
            foreach (Payment pay in prePays)
            {
                pay.VerifyState = state;
                if (pay.ParentPayment == 0 && pay.Id != retryId)
                {
                    parentId = pay.Id;
                }
                persistance.Update(pay);
            }
            return parentId;
        }
        
        private static void PayPalGenericData(TextWriter tw, Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription)
        {
        	string cost = paymentDescription.Cost.ToString();
        	cost = cost.Replace(',', '.');
            tw.Write("<input name='item_number' type='hidden' value='{0}' />", principal.Id);
            tw.Write("<input name='no_shipping' type='hidden' value='1' />");
			tw.Write("<input name='amount' type='hidden' value='{0}' />", cost);
            tw.Write("<input name='no_note' type='hidden' value='1' />");
            tw.Write("<input name='currency_code' type='hidden' value='{0}' />", PaymentUtils.CurrencyToPaypal[currency]);
            tw.Write("<input name='notify_url' type='hidden' value='{0}{1}' />", 
                Server.Properties.BaseUrl, ConfigurationManager.AppSettings["notificationUrl"]);
            tw.Write("<input name='return' type='hidden' value='{0}{1}' />", Server.Properties.BaseUrl, ConfigurationManager.AppSettings["confirmationUrl"]);
            //tw.Write("<input name='image_url' type='hidden' value='{0}' />", Combine(ResourcesManager.ImagesCommonPath, ConfigurationManager.AppSettings["logoUrl"]));
            tw.Write("<input name='image_url' type='hidden' value='{0}' />",
                     ConfigurationManager.AppSettings["logoUrl"]);
            tw.Write("<input name='cmd' type='hidden' value='_ext-enter' />");
            tw.Write("<input name='redirect_cmd' type='hidden' value='_xclick' />");
            tw.Write("<input name='quantity' type='hidden' value='1' />");
            tw.Write("<input name=\"item_name\" type=\"hidden\" value=\"Recharge {0}'s Orion's Belt user\" />", principal.DisplayName);
            tw.Write("<input name='charset' type='hidden' value='utf-8' />");
             
			//string buttonImage = ConfigurationManager.AppSettings["defaultButton"];
        	string buttonImage = ResourcesManager.GetPaymentsImage("PaymentBackground");
			tw.Write("<div class='chooseAmmount'><div class='paymentDescription'>");
			tw.Write("<div class='cost'>{0}: {1}€</div>", LanguageManager.Instance.Get("Cost"), paymentDescription.Cost);
            tw.Write("<div>{0}: {1}  <b>+</b></div>", LanguageManager.Instance.Get("Orions"), paymentDescription.Amount);
			tw.Write("<div>{0}: {1}</div>", LanguageManager.Instance.Get("BonusOrions"), paymentDescription.Bonus);
            tw.Write("<div>{0}: {1}</div>", LanguageManager.Instance.Get("Total"), paymentDescription.Amount+paymentDescription.Bonus);
			tw.Write("</div></div>");


			tw.Write("<div class='paymentButton'><input type='submit' class='button' value='{0}' /></div></div></form>", LanguageManager.Instance.Get("OrderNow"));
        }

        private void PayPalData(TextWriter tw)
        {
            tw.Write("<form action='{0}' method='post'>", Url);
            tw.Write("<input name='business' type='hidden' value='{0}' />", Mail);
        }

        #endregion Private Methods

    }
}
