using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.Engine.Actions;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;

namespace OrionsBelt.WebUserInterface
{
    public class Tests : System.Web.UI.Page
    {
        protected override void OnLoad(EventArgs e){

            using (IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance()) {
                PlanetStorage planet = persistance.TypedQuery(0, 1, "from SpecializedPlanetStorage p inner join fetch p.ResourcesNHibernate")[0];
                foreach (PlanetResourceStorage res in planet.Resources) {
                    Response.Output.Write("<p>{0}</p>", res.Planet.Name);
                }
            }
            
        }
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            try
            {
                string message = "mc_gross=1.99&settle_amount=1.03&protection_eligibility=Ineligible&payer_id=L64KRZSEPW4L6&tax=0.00&payment_date=06%3a58%3a21+Apr+06%2c+2009+PDT&payment_status=Completed&charset=windows-1252&first_name=Test&mc_fee=0.43&exchange_rate=0.660256&notify_version=2.7&custom=&settle_currency=GBP&payer_status=verified&business=busine_1230043909_biz%40orionsbelt.eu&quantity=1&verify_sign=AZSz6Oa-0Gh.17RtufK075.Eb4KAAeMItZDR16mDxFfTyh.I2Eemj45u&payer_email=buyer_1239005030_per%40orionsbelt.eu&txn_id=7TA86353A02206537&payment_type=instant&last_name=User&receiver_email=busine_1230043909_biz%40orionsbelt.eu&payment_fee=&receiver_id=UCXDCKMUK9FH8&txn_type=web_accept&item_name=Recharge+tsousa's+Orion's+Belt+user&mc_currency=EUR&item_number=204&residence_country=US&test_ipn=1&handling_amount=0.00&transaction_subject=Recharge+tsousa's+Orion's+Belt+user&payment_gross=&shipping=0.00&cmd=_notify-validate";
                string url = "https://www.sandbox.paypal.com/cgi-bin/webscr";
                writer.Write("URL:{0}", url);
                System.Net.HttpWebRequest request = (System.Net.HttpWebRequest)System.Net.HttpWebRequest.Create(url);
                writer.Write("Passou request");
                SetRequestParams(request);
                writer.Write("Passou params");
                request.ContentLength = message.Length;
                writer.Write("Message: {0}", message);

                using (System.IO.Stream requestStream = request.GetRequestStream())
                {
                    writer.Write("Request: {0}", requestStream.ToString());
                    using (System.IO.StreamWriter writer2 = new System.IO.StreamWriter(requestStream))
                    {
                        writer2.Write(message);
                        writer.Write("writer: {0}", writer2.ToString());
                        writer2.Close();
                    }
                    requestStream.Close();
                }

                //VerifyWithPaymentSystem(request, message, parameters, retry);
                writer.Write("End");
            }
            catch (System.Exception ex)
            {
                writer.Write(ex);
            }
        }

        protected virtual void SetRequestParams(System.Net.HttpWebRequest request)
        {
            request.Timeout = 500000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            //request.Referer = "http://www.orionsbelt.eu";
            request.UserAgent = "Orion's Belt Notifier Bot";
        }
    }
}
