using System.Web;
using OrionsBelt.Engine;
using OrionsBelt.Generic;
using OrionsBelt.WebUserInterface.Engine;
using System;

namespace OrionsBelt.WebUserInterface.Modules {
	class EngineModule : IHttpModule {

		#region IHttpModule Members

		public void Dispose() {
			
		}

		public void Init(HttpApplication context) {
            context.PostAuthenticateRequest += new System.EventHandler(context_PostAuthenticateRequest);
            context.BeginRequest += new System.EventHandler(context_BeginRequest);

		}

        void context_BeginRequest(object sender, System.EventArgs e)
        {
            string referrer = GetReferrer();
            if (!string.IsNullOrEmpty(referrer)) {
                HttpCookie newCookie = new HttpCookie("Referrer", referrer);
                newCookie.Expires = DateTime.Now.AddDays(3);
                SetDomain(newCookie);
                HttpContext.Current.Response.Cookies.Add(newCookie);
                HttpContext.Current.Items["Referrer"] = referrer;
                return;
            }
            HttpCookie cookie = HttpContext.Current.Request.Cookies["Referrer"];
            if (cookie != null) {
                HttpContext.Current.Items["Referrer"] = cookie.Value;
            }
        }

        private void SetDomain(HttpCookie cookie)
        {
            if (Server.Properties.BaseUrl.Contains("orionsbelt.eu")) {
                cookie.Domain = ".orionsbelt.eu";
            }
        }

        private static string GetReferrer()
        {
            string referrer = HttpContext.Current.Request.QueryString["Referrer"];
            if (string.IsNullOrEmpty(referrer)) {
                referrer = HttpContext.Current.Request.QueryString["ReferrerId"];
            }
            return referrer;
        }

        void context_PostAuthenticateRequest(object sender, System.EventArgs e)
        {
            TimeFormatter.Translator = LanguageParameterTranslator.Instance;
            ManualUtils.Translator = LanguageParameterTranslator.Instance;
        }

		#endregion

		#region Constructor

		static EngineModule() {
			GameEngine.Init();
		}

		#endregion Constructor
	}
}
