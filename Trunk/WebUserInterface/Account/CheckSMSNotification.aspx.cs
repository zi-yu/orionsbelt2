using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebUserInterface.PaymentSystems;

namespace OrionsBelt.WebUserInterface.Account
{
    public class CheckSMSNotification : System.Web.UI.Page
    {

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            try
            {
                TextWriter tw = new StringWriter();

                Dictionary<string, string> reqInfo =
                    new Dictionary<string, string>(HttpContext.Current.Request.QueryString.AllKeys.Length);
                foreach (string key in HttpContext.Current.Request.QueryString.AllKeys)
                {
                    string val = HttpContext.Current.Request.QueryString[key];
                    //tw.WriteLine("{0} : {1};", key, val);
                    tw.Write("{0}={1}&", key, HttpUtility.UrlEncode(val));
                    reqInfo.Add(key, val.ToUpper());
                }
                Logger.Info(LogType.SMS, tw.ToString());

                string ip = HttpContext.Current.Request.UserHostAddress;
                if (!string.IsNullOrEmpty(HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]))
                {
                    ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
                }

                /*Logger.Debug("UserHostAddress: {0} X-Forwarded-For: {1} ip: {2} ALL: {3}", HttpContext.Current.Request.UserHostAddress, HttpContext.Current.Request.ServerVariables["X-Forwarded-For"], ip, HttpContext.Current.Request.ServerVariables["ALL_RAW"]);

                foreach(string key in HttpContext.Current.Request.ServerVariables.AllKeys)
                {
                    Logger.Debug("[{0}] = {1}", key, HttpContext.Current.Request.ServerVariables[key]);
                }*/

                IPayment payment = new SMS();
                if (!payment.IsValidRequest(reqInfo, ip))
                {
                    return;
                }
                
                payment.SendValidation(reqInfo, tw.ToString(), null);
                 
            }
            catch (Exception ex)
            {
                Logger.Error(LogType.SMS, ex.Message);
            }
        }

    };
}
