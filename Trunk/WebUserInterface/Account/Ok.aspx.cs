using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.PaymentSystems;
using Paysafecard.Client;
using System.Web.Services.Protocols;
using Configuration=Paysafecard.Client.Configuration;
using OrionsBelt.Engine.MarketPlace;

namespace OrionsBelt.WebUserInterface.Account
{
    public class Ok : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e)
        {     
            /*
            try
            {
                Configuration config = new Configuration(ConfigurationManager.AppSettings["merchant.properties"]);
                string merchantId = config["merchantId"];
                MerchantApi api = new MerchantApi(merchantId, config);
                DispositionStateResult result = api.GetDispositionState("200982815833262451882423");
                SerialNumbersResult serial = api.GetSerialNumbers("200982815833262451882423");
                //serial.State
                //result.State
                int i = 2;
            }
            catch(Exception ex)
            {
                ErrorBoard.AddLocalizedMessage("FailVerifyRetry");

            }
             */

            //Logger.Debug("enter");
            base.OnLoad(e);
            
            TextWriter tw = new StringWriter();
            //Logger.Debug(HttpContext.Current.Request.QueryString.ToString());
            Dictionary<string, string> reqInfo = new Dictionary<string, string>(HttpContext.Current.Request.QueryString.AllKeys.Length);
            //Logger.Debug("reqInfo");
            foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
            {
                string val = HttpContext.Current.Request.QueryString[key];
                //tw.WriteLine("{0} : {1};", key, val);
                tw.Write("{0}={1}&", key, HttpUtility.UrlEncode(val));
                reqInfo.Add(key,val.ToUpper());
            }
            //Logger.Debug(tw.ToString());
            try
            {
                IPayment payment = new PaySafe();
                if (!payment.IsValidRequest(reqInfo, tw.ToString()))
                {
                    //Logger.Debug("invalid");
                    ErrorBoard.AddLocalizedMessage("PaymentError");
                    return;
                }
                //Logger.Debug("valid");
                tw.Write("serials={0}",reqInfo["serials"]);
                payment.SendValidation(reqInfo, tw.ToString(), null);       
                InformationBoard.AddLocalizedMessage("Thanks");

                //Promotion Verification
                /*Dictionary<string, string> reqInfo = new Dictionary<string, string>();
                reqInfo.Add("id","204");
                reqInfo.Add("serials", "125302500;2.00;111111;5.00");*/
                int pId = Convert.ToInt32(reqInfo["id"]);
                int[] serials = PaymentUtils.GetSerials(reqInfo["serials"]);
                
                PromotionUtil.VerifyPromotion(serials, pId);


            }
            catch (SoapException pscEx)
            {
                string url = Page.Request.Url + "&retry=1";
                if (string.IsNullOrEmpty(Request.QueryString["retry"]))
                {
                    ErrorBoard.AddLocalizedMessage("FailVerify", url);

                    using (IPaymentPersistance persistance = Persistance.Instance.GetPaymentPersistance())
                    {
                        Payment p = persistance.Create();
                        p.PrincipalId = Convert.ToInt32(reqInfo["id"]);
                        p.Method = PaymentMethodEnum.PaySafe.ToString();
                        p.Request = tw.ToString();
                        p.Ammount = reqInfo["amount"];
                        p.RequestId = reqInfo["mtid"];
                        p.VerifyState = "NotVerified";
                        p.Parameters = pscEx.ToString();
                        persistance.Update(p);
                        persistance.Flush();
                    }
                }
                
                ErrorBoard.AddLocalizedMessage("FailVerifyRetry");
                
            }
            //SendMessage("test_ipn=1&payment_type=echeck&payment_date=09%3a18%3a38+Dec.+23%2c+2008+PST&payment_status=Completed&address_status=confirmed&payer_status=verified&first_name=John&last_name=Smith&payer_email=buyer%40paypalsandbox.com&payer_id=TESTBUYERID01&address_name=John+Smith&address_country=United+States&address_country_code=US&address_zip=95131&address_state=CA&address_city=San+Jose&address_street=123%2c+any+street&business=seller%40paypalsandbox.com&receiver_email=seller%40paypalsandbox.com&receiver_id=TESTSELLERID1&residence_country=US&item_name=something&item_number=AK-1234&quantity=1&shipping=3.04&tax=2.02&mc_currency=USD&mc_fee=0.44&mc_gross=12.34&txn_type=web_accept&txn_id=3812231718&notify_version=2.1&custom=xyz123&invoice=abc1234&charset=windows-1252&verify_sign=AFcWxV21C7fd0v3bYYYRCpSSRl31AY4QbIIyXkBuHBA1-b4MKzmi1QMx&cmd=_notify-validate");
        }

    };
}
