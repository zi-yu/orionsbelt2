using System;
using System.Collections.Generic;
using System.Web;
using System.Configuration;

namespace OrionsBelt.WebComponents {
    /// <summary>
    /// Represents session object for Facebook Connect apps
    /// </summary>
    public class FacebookSession {

        #region MyRegion

        private string sessionKey;
        private long userId;

        #endregion

        #region Properties

        public static string ApplicationKey {
            get { return ConfigurationSettings.AppSettings["FacebookAPIId"]; }
        }

        public static string ApplicationSecret {
            get { return ConfigurationSettings.AppSettings["FacebookSecret"]; }
        }

        public static bool HasSession {
            get { return State.HasItems("FacebookSession"); }
        }

        public static FacebookSession Instance {
            get {
                if (!State.HasItems("FacebookSession")) {
                    Instance = new FacebookSession();
                }
                return (FacebookSession)State.GetItems("FacebookSession"); 
            }
            set { State.SetItems("FacebookSession", value); }
        }

        public string SessionKey { 
			get { return sessionKey;}
			set { sessionKey = value;} 
        }

        public long UserId { 
			get { return userId;}
			set { userId = value;} 
        }

        public bool IsConnected {
            get {
                return (SessionKey != null && UserId != -1);
            }
        }
	    #endregion Properties

        #region Private Methods

        private void PopulateConnectCookieInformation() {
            try {
                SessionKey = GetCookie("session_key");
                UserId = GetUserID();
            } catch {
                throw new Exception("Unable to populate Facebook Connect Session/User cookie information.");
            }
        }

        private long GetUserID() {
            long userID;
            long.TryParse(GetCookie("user"), out userID);
            return userID;
        }

        #endregion Private Methods

        #region Public Methods

        public string GetCookie(string cookieName) {
            string fullCookieName = string.Format("{0}_{1}", ApplicationKey, cookieName);
            if (HttpContext.Current != null
                && HttpContext.Current.Request != null
                && HttpContext.Current.Request.Cookies != null
                && HttpContext.Current.Request.Cookies[fullCookieName] != null) {
                return HttpContext.Current.Request.Cookies[fullCookieName].Value;
            }

            return null;
        }

        public static void CreateSession() {
            FacebookSession.Instance = new FacebookSession();
        }

        #endregion Public Methods

        #region Constructor

        /// <summary>
        /// Creates new FacebookSession object
        /// </summary>
        private FacebookSession() {
            PopulateConnectCookieInformation();
        }

        #endregion Constructor
    }
}
