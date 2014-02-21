using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.WebComponents;
using Institutional.Core;
using Institutional.DataAccessLayer;
using System.IO;
using System.Collections.Generic;

namespace Institutional.WebUserInterface.Controls {

    public static class WebUtilities {

        #region Utils

        public static string ApplicationPath {
            get {
                string url = HttpContext.Current.Request.ApplicationPath;
                if (!url.EndsWith("/")) {
                    url += "/";
                }
                return url;
            }
        }

        public static Server CurrentServer {
            get {
                Server server = Persistance.Create<Server>();
                server.Name = "S1";
                server.Url = "http://s1.orionsbelt.eu/";
                return server;
            }
        }

        public static string CurrentServerLoginUrl {
            get { return string.Format("{0}LoginAuto.aspx", CurrentServer.Url); }
        }

        public static string ResourcesUrl {
            get { return "http://resources.orionsbelt.eu/Institutional/"; }
        }

        #endregion Utilities

        #region Links and Referrals

        public static string GetPlayUrl()
        {
            string lang = "en";
            if (State.HasSession("Lang"))
            {
                lang = State.GetSession("Lang").ToString();
            }

            if (State.HasItems("Referrer"))
            {
                return string.Format("{1}Login.aspx{0}&lang={2}", GetReferrer(), CurrentServer.Url, lang);
            }
            else
            {
                return string.Format("{0}Login.aspx?lang={1}", CurrentServer.Url, lang);
            }
        }

        public static string GetPlayUrlProxy()
        {
            return string.Format("{0}GoPlay.aspx", ApplicationPath);
        }

        public static string GetReferrer()
        {
            if (State.HasItems("Referrer")) {
                return string.Format("?Referrer={0}", State.GetItems("Referrer"));
            }

            return string.Empty;
        }

        public static Referral CreateReferral(string referrerUrl)
        {
            lock(referralSync) {
                Uri uri = new Uri(referrerUrl);
                string url = uri.Host.Replace("www.", string.Empty);
                int nextCode = GetNextReferralCode();
                using (IReferralPersistance persistance = Persistance.Instance.GetReferralPersistance()) {
                    persistance.StartTransaction();

                    Referral referral = persistance.Create();

                    referral.Code = nextCode;
                    referral.SourceUrl = uri.AbsolutePath;
                    referral.Filters = string.Format("{0};", url);
                    referral.Name = url;

                    GetAllReferrals().Add(referral);
                    persistance.Update(referral);

                    persistance.CommitTransaction();

                    return referral;
                }
            }
        }

        private static int GetNextReferralCode()
        {
            int max = 0;
            foreach (Referral referral in GetAllReferrals()) {
                if (referral.Code < max) {
                    max = referral.Code;
                }
            }
            return max - 1000;
        }

        public static bool IsReferralMatch(Referral referral, string referrerUrl)
        {
            try {
                
                string[] filters = referral.Filters.Split(';');
                foreach (string filter in filters) {
                    if (!string.IsNullOrEmpty(filter) && referrerUrl.Contains(filter)) {
                        return true;
                    }
                }

                return false;

            } catch {
                return false;
            }
        }

        private static object referralSync = new object();
        public static IList<Referral> GetAllReferrals()
        {
            if (State.HasApplication("AllReferrals") ){
                return (IList<Referral>)State.GetApplication("AllReferrals");
            }
            lock (referralSync) {
                if (State.HasApplication("AllReferrals") ){
                    return (IList<Referral>)State.GetApplication("AllReferrals");
                }
                
                using (IReferralPersistance persistance = Persistance.Instance.GetReferralPersistance()) {
                    IList<Referral> allReferrals;
                    allReferrals = persistance.Select();
                    State.SetApplication("AllReferrals", allReferrals);
                    return allReferrals;
                }
            }
        }

        #endregion Links and Referrals

        #region Screen Shots

        public static List<string> GetPreviewImages(string type)
        {
            if (type == "ScreenShots") {
                return GetScreenShots("ScreenShots");
            }

            if (type == "ArtWork") {
                return GetScreenShots("ArtWork");
            }

            throw new Exception("Can't handle given type: " + type);
        }

        public static List<string> GetScreenShots(string type)
        {
            string dir = GetScreenShotsDir(type);
            List<string> list = new List<string>(Directory.GetFiles(dir, "*.jpg"));

            list.Sort(delegate(string s1, string s2) {
                return new FileInfo(s1).LastWriteTime.CompareTo(new FileInfo(s2).LastWriteTime) * -1;
            });

            List<string> final = new List<string>();
            foreach (string str in list) {
                final.Add(Path.GetFileName(str));
            }

            return final;
        }

        private static string GetScreenShotsDir(string type)
        {
            return Path.Combine(LanguageManager.LanguageDirectory, string.Format("../Images/{0}/", type));
        }

        internal static string GetPreviewImageUrl(string subdir, string image)
        {
#if DEBUG
            return string.Format("{0}Images/{1}/{2}", ApplicationPath, subdir, image);
#else
            return string.Format("{0}Images/{1}/{2}", "http://www.orionsbelt.eu.nyud.net/", subdir, image);
#endif
        }

        #endregion Screen Shots

    };

}
