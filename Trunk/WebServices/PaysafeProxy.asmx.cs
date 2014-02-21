using System;
using System.ComponentModel;
using System.Configuration;
using System.IO;
using System.Web.Services;
using Paysafecard.Client;
using Configuration=Paysafecard.Client.Configuration;
using System.Net;

namespace WebServiceProject
{
    /// <summary>
    /// Summary description for Service1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ToolboxItem(false)]
    public class PaysafeProxy : WebService
    {

        public struct DispositionData
        {
            public string amount;
            public string currency;
            public DispositionState state;
            public string serials;
        }

        public struct VerifyResult
        {
            public string result;
            public bool success;
        }


        [WebMethod]
        public string CreatePost(double cost,  int principalId, string principalLang, string basePath)
        {
            Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
            string merchantId = config["merchantId"];
            string confCur = config["currency"];
            string businessType = config["businessType"];
            string reportingCriteria = config["reportingCriteria"];
            string amount = string.Format("{0}.00", cost);
            MerchantApi api = new MerchantApi(merchantId, config, config["language"]);
            string merchantTransactionId = api.GenerateMerchantTransactionId();
            string okUrl = string.Format("{0}Account/Ok.aspx?mtid={1}&amount={2}&id={3}", basePath,
                                         merchantTransactionId, cost, principalId);
            string notOkUrl = basePath + "Account/NotOk.aspx";
            api.CreateDisposition(merchantTransactionId, amount, confCur, businessType,
                                  reportingCriteria, okUrl, notOkUrl);
            
            string lang = principalLang;
            if (string.IsNullOrEmpty(lang))
            {
                lang = config["clientLang"];
            }
            return string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}", config["redirect_URL"],
                                       "?currency=", confCur,
                                       "&mid=", merchantId,
                                       "&mtid=", merchantTransactionId,
                                       "&amount=", amount,
                                       "&language=", lang);

            //return string.Format("<form action='{0}' method='post'>", url);

        }

        [WebMethod]
        public DispositionData PaymentVerification(string mtid)
        {
            Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
            string merchantId = config["merchantId"];
            MerchantApi api = new MerchantApi(merchantId, config);
            DispositionStateResult result = api.GetDispositionState(mtid);
            SerialNumbersResult serial = api.GetSerialNumbers(mtid);
            DispositionData data = new DispositionData();
            data.state = result.State;
            data.currency = result.Currency;
            data.amount = result.Amount;
            data.serials = serial.Serialnumbers;
            //throw new PaysafecardException("test", 0);
            return data;
        }

        [WebMethod]
        public void MakeDebit(string mtid, string amount, string currency)
        {
            Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
            string merchantId = config["merchantId"];
            MerchantApi api = new MerchantApi(merchantId, config);
            api.ExecuteDebit(mtid, amount,
                    currency, true);
        }

        [WebMethod]
        public VerifyResult PaypalVerification(string url, string message)
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

        private static void SetRequestParams(HttpWebRequest request)
        {
            request.Timeout = 500000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Referer = "http://www.orionsbelt.eu";
            request.UserAgent = "Orion's Belt Notifier Bot";
        }
    }
}
