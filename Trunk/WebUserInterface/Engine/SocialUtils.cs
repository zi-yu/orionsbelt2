
using System;
using System.IO;
using System.Web;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine {

	public static class SocialUtils {

        #region Facebook

        public static string FacebookKey {
            get { return "b91bd6ce0d021e14e7c7b1b073828c75"; }
        }

        public static string GetPublishToFacebook(string title, string body, string link, string image, string imageLink)
        {
            using (StringWriter writer = new StringWriter()) {
                PublishToFacebook(writer, title, body, link, image, imageLink);
                return writer.ToString();
            }
        }

        public static void PublishToFacebook(TextWriter writer, string title, string body, string link, string image, string imageLink)
        {
            writer.Write("<script src='http://static.ak.connect.facebook.com/js/api_lib/v0.4/FeatureLoader.js.php/en_US' type='text/javascript'></script><script type='text/javascript'>FB.init('{0}');</script>", FacebookKey);
            writer.Write("<script type='text/javascript'>");
            writer.Write("function callPublish(msg, attachment, action_link) {");
            writer.Write("FB.ensureInit(function () {");
            writer.Write("FB.Connect.streamPublish('', attachment, action_link);");
            writer.Write("});");
            writer.Write("}</script>");
            writer.Write("<a href='' onclick=\"callPublish('',{{'name':'{0}','href':'{1}','description':'{2}','media':[{{'type':'image','src':'{3}','href':'{4}'}}]}},null);return false;\" title='{5}'><img src='{6}/Community/ShareFB.png' alt='{5}' /></a>",
                    title, link, body, image, imageLink, LanguageManager.Localize("PublishToFacebook"), ResourcesManager.ImagesCommonPath
                );
        }

        #endregion Facebook

        #region Twitter

        public static string GetPublishToTwitter(string status)
        { 
            using (StringWriter writer = new StringWriter()) {
                PublishToTwitter(writer, status);
                return writer.ToString();
            }
        }

        public static void PublishToTwitter(TextWriter writer, string status)
        {
            writer.Write("<a href='http://twitter.com/?status={0}' title='{2}'><img src='{1}/Community/ShareTwitter.png' alt='{2}' /></a>", 
                    HttpUtility.UrlEncode(status),
                    ResourcesManager.ImagesCommonPath,
                    LanguageManager.Localize("PublishToTwitter")
                );
        }

        #endregion Twitter

    };
}
