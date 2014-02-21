using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.PaymentSystems;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Account
{
    public class CheckSponsorPay : System.Web.UI.Page
    {
        protected Literal returned;
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                base.OnLoad(e);
                TextWriter tw = new StringWriter();
                //Logger.Debug(LogType.IPN, "Enter OneBip OnLoad");
                Dictionary<string, string> reqInfo = new Dictionary<string, string>(HttpContext.Current.Request.QueryString.AllKeys.Length);
                foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
                {
                    string val = HttpContext.Current.Request.QueryString[key];
                    //tw.WriteLine("{0} : {1};", key, val);
                    tw.Write("{0}={1}&", key, HttpUtility.UrlEncode(val));
                    reqInfo.Add(key, val.ToUpper());
                }
                Logger.Debug(LogType.IPN, tw.ToString());

                if(reqInfo.Count == 0)
                {
                    Logger.Debug(LogType.IPN, "No query string");
                    returned.Text = "ERROR: No query string";
                    return;
                }

                
                IPayment payment = new SponsorPay();
                if (!payment.IsValidRequest(reqInfo, tw.ToString()))
                {
                    returned.Text = "ERROR: Not a valid request";
                    return;
                }

                payment.SendValidation(reqInfo, tw.ToString(), null);
                returned.Text = "OK";
                
            }catch(Exception ex)
            {
                ExceptionLogger.Log(ex);
                returned.Text = string.Format("ERROR: {0}",ex);
            }
        }

    };
}
