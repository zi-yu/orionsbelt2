using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Net;
using Loki.Generic;

namespace OrionsBelt.WebComponents {
    public class FacebookRest {

        #region Fields

        private static string url = "http://api.facebook.com/restserver.php";

        #endregion Fields

        #region WebRequest

        private static string WebRequest(string parameters) {
            try {
                HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(url);

                SetRequestParams(request);

                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(parameters);
                writer.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();

                string content;
                using (Stream responseStream = response.GetResponseStream()) {
                    using (StreamReader reader = new StreamReader(responseStream)) {
                        content = reader.ReadToEnd();
                    }
                }

                return content;
            } catch (Exception ex) {
                throw;
            }
            return null;
        }

        private static void SetRequestParams(HttpWebRequest request) {
            request.Timeout = 500000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
        }

        #endregion

        #region Private

        private static string CurrentUserInfoPostData() {
            return UserInfoPostData(FacebookSession.Instance.UserId.ToString());
        }

        private static string UserInfoPostData(string userIds) {

            FacebookRestMethod restMethod = new FacebookRestMethod("Users.getInfo");
            restMethod.AddParameter("api_key",FacebookSession.ApplicationKey);
            restMethod.AddParameter("call_id",DateTime.Now.Millisecond.ToString());
            restMethod.AddParameter("v","1.0");
            restMethod.AddParameter("uids",userIds);
            restMethod.AddParameter("fields", "uid,first_name,last_name,locale,pic_square,contact_email,website");
            restMethod.AddParameter("session_key", FacebookSession.Instance.SessionKey);

            restMethod.AddParameter("sig", restMethod.GetSig());

            return restMethod.GetPostData();
        }

        private static string IsFan() {
            FacebookRestMethod restMethod = new FacebookRestMethod("Pages.isFan");
            restMethod.AddParameter("api_key",FacebookSession.ApplicationKey);
            restMethod.AddParameter("call_id",DateTime.Now.Millisecond.ToString());
            restMethod.AddParameter("v","1.0");
            restMethod.AddParameter("sig", restMethod.GetSig());
            return restMethod.GetPostData();
        }
        
        #endregion Private

        #region Public

        public static FacebookUser GetCurrentUserInfo() {
            return GetUserInfo(FacebookSession.Instance.UserId);
        }

        public static FacebookUser GetUserInfo(long userid) {
            string xml = null;
            try {
                if (FacebookSession.HasSession) {
                    xml = WebRequest(CurrentUserInfoPostData());
                    FacebookUserArray user = SerializerUtils.Import<FacebookUserArray>(xml);
                    if (user != null && user.FacebookUsers.Count > 0) {
                        return user.FacebookUsers[0];
                    }
                }
                return null;
            } catch(Exception ex) {
                throw new Exception(xml, ex);
            }
        }

        public static string IsFan(long userid) {
            if (FacebookSession.HasSession) {
                return WebRequest(IsFan());
            }
            return null;
        }

        #endregion Publiv

    }
}
