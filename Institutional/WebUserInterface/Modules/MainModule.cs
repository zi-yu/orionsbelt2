using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using Institutional.DataAccessLayer;
using Institutional.WebUserInterface.Controls;
using Institutional.Core;

namespace Institutional.WebUserInterface.Modules {
	public class MainModule : IHttpModule {

		#region IHttpModule Members

		public void Init( HttpApplication context ) {
            context.BeginRequest += new EventHandler(context_CheckUrl);
            context.BeginRequest += new EventHandler(context_CheckReferrals);
		}

		public void Dispose() {}

		#endregion

		#region Events

        void context_CheckUrl(object sender, EventArgs e)
        {
            string[] filters = { 
                "zi-yu",
                "ruler.aspx",
                "userinfo.aspx",
                "wiki/",
                "media.aspx",
                "indexer.aspx",
                "toprulers",
                "/allianceinfo.aspx",
                "/stats.aspx",
                "sendmail",
                "/regist",
                "/ruler/researc"

            };
            foreach (string filter in filters) {
                if (HttpContext.Current.Request.Url.AbsoluteUri.ToLower().Contains(filter)) {
                    HttpContext.Current.Response.Status = "301 Moved Permanently";
                    HttpContext.Current.Response.AddHeader("Location", "http://www.orionsbelt.eu/");
                    return;
                }
            }
        }

        void context_CheckReferrals(object sender, System.EventArgs e)
        {
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Referrer"];
            if (cookie != null) {
                HttpContext.Current.Items["Referrer"] = cookie.Value;
                return;
            }
            string referrer = GetReferrer();
            if (!string.IsNullOrEmpty(referrer)) {
                HttpCookie newCookie = new HttpCookie("Referrer", referrer);
                newCookie.Expires = DateTime.Now.AddDays(3);
                SetDomain(newCookie);
                HttpContext.Current.Response.Cookies.Add(newCookie);
                HttpContext.Current.Items["Referrer"] = referrer;
                return;
            }
        }

        private void SetDomain(HttpCookie cookie)
        {
            cookie.Domain = ".orionsbelt.eu";
        }

        private static string GetReferrer()
        {
            string referrer = HttpContext.Current.Request.QueryString["Referrer"];
            if (string.IsNullOrEmpty(referrer)) {
                referrer = HttpContext.Current.Request.QueryString["ReferrerId"];
            }
            if (!string.IsNullOrEmpty(referrer)) {
                return referrer;
            }

            string referrerUrl = null;
            if (HttpContext.Current.Request.UrlReferrer != null) {
                referrerUrl = HttpContext.Current.Request.UrlReferrer.OriginalString;
            }
            if (string.IsNullOrEmpty(referrerUrl) || 
                    HttpContext.Current.Request.UrlReferrer.Host == HttpContext.Current.Request.Url.Host ) {
                return null;
            }

            referrerUrl = referrerUrl.ToLower();

            foreach (Referral referral in WebUtilities.GetAllReferrals()) {
                if (WebUtilities.IsReferralMatch(referral, referrerUrl)) {
                    return referral.Code.ToString();
                }
            }

            Referral newReferral = WebUtilities.CreateReferral(referrerUrl);
            if (newReferral == null) {
                return null;
            }
            return newReferral.Code.ToString();
        }

		#endregion
	};
}
