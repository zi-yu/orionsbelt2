using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Language.WebComponents.Controls;
using Language.Core;
using System.Collections;
using Language.WebComponents;
using Loki.DataRepresentation;
using Language.DataAccessLayer;
using System.IO;

namespace Language.WebUserInterface.Controls {

    public class LanguageStats : Control {

        #region Rendering

        private string file;

        public string ReportFile
        {
            get {
                if (!string.IsNullOrEmpty(file)) {
                    return file;
                }
                return "Report.html";
            }
            set { file = value; }
        }
	

        protected override void Render(HtmlTextWriter writer)
        {
            string dir = LanguageManager.LanguageDirectory;
            dir = Path.Combine(dir, "..");
            dir = Path.Combine(dir, "Metrics");
            string file = Path.Combine(dir, ReportFile);
            if (File.Exists(file)) {
                writer.Write(File.ReadAllText(file));
            }
        }

        #endregion Rendering

    };
}
