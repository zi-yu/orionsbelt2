using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.PaymentSystems;

namespace OrionsBelt.WebUserInterface.Account
{
    public class Check : System.Web.UI.Page {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            TextWriter tw = new StringWriter();

            Dictionary<string, string> reqInfo = new Dictionary<string, string>(HttpContext.Current.Request.Form.AllKeys.Length);
            foreach (string key in HttpContext.Current.Request.Form.AllKeys)
            {
                string val = HttpContext.Current.Request.Form[key];
                //tw.WriteLine("{0} : {1};", key, val);
                tw.Write("{0}={1}&", key, HttpUtility.UrlEncode(val));
                reqInfo.Add(key,val.ToUpper());
            }
            Logger.Debug(LogType.IPN, tw.ToString());

            IPayment payment = new Paypal();
            if (!payment.IsValidRequest(reqInfo, tw.ToString()))
            {
                return;
            }
            tw.Write("cmd=_notify-validate");
            payment.SendValidation(reqInfo, tw.ToString(), null);
            //SendMessage("test_ipn=1&payment_type=echeck&payment_date=09%3a18%3a38+Dec.+23%2c+2008+PST&payment_status=Completed&address_status=confirmed&payer_status=verified&first_name=John&last_name=Smith&payer_email=buyer%40paypalsandbox.com&payer_id=TESTBUYERID01&address_name=John+Smith&address_country=United+States&address_country_code=US&address_zip=95131&address_state=CA&address_city=San+Jose&address_street=123%2c+any+street&business=seller%40paypalsandbox.com&receiver_email=seller%40paypalsandbox.com&receiver_id=TESTSELLERID1&residence_country=US&item_name=something&item_number=AK-1234&quantity=1&shipping=3.04&tax=2.02&mc_currency=USD&mc_fee=0.44&mc_gross=12.34&txn_type=web_accept&txn_id=3812231718&notify_version=2.1&custom=xyz123&invoice=abc1234&charset=windows-1252&verify_sign=AFcWxV21C7fd0v3bYYYRCpSSRl31AY4QbIIyXkBuHBA1-b4MKzmi1QMx&cmd=_notify-validate");
        }

    };
}
