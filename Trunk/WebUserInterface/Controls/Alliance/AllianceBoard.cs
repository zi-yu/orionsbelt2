using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using System.IO;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AllianceBoard : Control {

        #region Properties

        private string type;

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        #endregion Properties

        #region Events

        protected override void Render(HtmlTextWriter mainwriter)
        {
            if (!AllianceWebUtils.CurrentPlayerBelongsToCurrentAlliance && Type == "Private") {
                return;
            }

            using (StringWriter writer = new StringWriter()) {

                string dir = GetDir();
                string file = Path.Combine(dir, string.Format("Alliance{0}_{1}.html", AllianceWebUtils.Current.Storage.Id, Type));
                if (!File.Exists(file)) {
                    return;
                }

                string content = File.ReadAllText(file);
                writer.Write("<div class='allianceBoard{0}'>", Type);
                writer.Write(content);
                writer.Write("</div>");

                string title = string.Format("<h2>{0}</h2>", LanguageManager.Instance.Get(string.Format("{0}Board", Type)));

                Border.RenderMedium("allianceBoard",mainwriter, title, writer.ToString());
            }
        }

        public static string GetDir()
        {
            string dir = Path.Combine(LanguageManager.LanguageDirectory, "..");
            dir = Path.Combine(dir, "Data");
            dir = Path.Combine(dir, "Alliances");

            Directory.CreateDirectory(dir);
            return dir;
        }

        #endregion Events

    };

}
