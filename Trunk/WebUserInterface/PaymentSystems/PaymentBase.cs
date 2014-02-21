using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Net;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Log;

namespace OrionsBelt.WebUserInterface.PaymentSystems
{
    public abstract class PaymentBase: IPayment
    {
        #region IPayment Interface

        public abstract string Render(Principal principal, CurrencyEnum currency, PaymentDescription paymentDescription);

        public abstract bool IsValidRequest(Dictionary<string, string> parameters, string request);
        

        public virtual bool IsValidQuantity(double quantity)
        {
            if (quantity == 2 || quantity == 5 || quantity == 10 || quantity == 20 || quantity == 40)
                return true;
            return false;
        }

        public virtual string Mail
        {
			get { return ConfigurationManager.AppSettings["payPalMail"]; }
            //get { return ConfigurationManager.AppSettings["sandboxMail"]; }
        }

        public virtual string Url
        {
            get { return ConfigurationManager.AppSettings["payPalUrl"]; }
            //get { return ConfigurationManager.AppSettings["sandboxUrl"]; }
        }

        public virtual void SendValidation(Dictionary<string, string> parameters, string message, Payment retry)
        {
            try
            {
                //Logger.Debug("URL:{0}",Url);
                HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(Url);
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
                
                VerifyWithPaymentSystem(request, message, parameters, retry);
                //Logger.Debug("End");
            }
            catch (Exception ex)
            {
                ExceptionLogger.Log(ex);
            }
        }

        #endregion IPayment Interface

        protected abstract void MakePayment(Dictionary<string, string> info, string message, string response, Payment retry);
        protected abstract void MakeInvalid(Dictionary<string, string> info, string message, string response, Payment retry);
        protected abstract void WriteNotVerified(Dictionary<string, string> parameters, string request, WebException exception);

        /// <summary>
        /// Get number of Orions for a payment
        /// </summary>
        /// <param name="payMoney">Money payed</param>
        /// <returns>number of Orions</return
        protected virtual int GetOrions(double payMoney)
        {
            if(payMoney == 2)
            {
                return 600;
            }
            if (payMoney == 5)
            {
                return 1800;
            }
            if (payMoney == 10)
            {
                return 4000;
            }
            if (payMoney == 20)
            {
                return 10000;
            }
            if (payMoney == 40)
            {
                return 25000;
            }
            
            return 0;
        }

        protected virtual void VerifyWithPaymentSystem(WebRequest request, string message, Dictionary<string, string> reqInfo, Payment retry)
        {
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
                    if ("VERIFIED" == content)
                    {
                        MakePayment(reqInfo, message, content, retry);
                        
                    }else
                    {
                        
                        MakeInvalid(reqInfo, message, content, retry);
                        
                    }
                    Logger.Debug(LogType.IPN, content);
                }
                catch (WebException ex)
                {
                    ++rentries;
                    if (rentries >= 3 && null == retry)
                    {
                        WriteNotVerified(reqInfo, message, ex);
                    }
                }
            }
        }

        protected virtual void SetRequestParams(HttpWebRequest request)
        {
            request.Timeout = 500000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Referer = "http://www.orionsbelt.eu";
            request.UserAgent = "Orion's Belt Notifier Bot";
        }

        protected static string Combine(string url1, string url2)
        {
            return string.Format("{0}/{1}", url1, url2);
        }
    }
}
