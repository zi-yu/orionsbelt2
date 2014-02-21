using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Engine.Forum {
    public class ForumSmilies {

        #region Fields

        private static Dictionary<string, string> smilies = new Dictionary<string, string>();

        #endregion

        #region Public

        public static string GetSmilies() {
            using (StringWriter writer = new StringWriter()) {
                writer.Write("<ul id='smilies'>");
                foreach (string smile in smilies.Keys) {
                    writer.Write("<li><a href='javascript:Forum.insertAtCursor(\"postTextArea\",\"{2}\");'><img src='{0}' alt='{1}' title='{1}'/></a></li>", ResourcesManager.GetForumSmilePath(smile), LanguageManager.Localize(smile), smilies[smile]);
                }
                writer.Write("</ul>");
                return writer.ToString();
            }
        }

        #endregion Public

        #region Constructor

        static ForumSmilies() {
            smilies.Add("VeryHappy",":D");
            smilies.Add("Happy",":)");
            smilies.Add("Sad",":(");
            smilies.Add("Surprised",":o");
            smilies.Add("Shocked",":shock:");
            smilies.Add("Confused",":s");
            smilies.Add("Cool","8)");
            smilies.Add("Laughing",":lol:");
            smilies.Add("Mad",":x");
            smilies.Add("Cheeky", ":P");
            smilies.Add("RedFace",":red:");
            smilies.Add("Cry",":cry:");
            smilies.Add("Twisted",":twisted:");
            smilies.Add("Neutral",":|");
            smilies.Add("Wink",":wink:");
        }

        #endregion Constructor

    }
}
