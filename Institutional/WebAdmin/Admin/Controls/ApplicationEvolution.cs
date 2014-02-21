using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.IO;
using Loki.Generic;

namespace Institutional.WebAdmin.Admin.Controls {
	public class ApplicationEvolution : Control {
	
		#region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            if (File.Exists(Globals.WebMetricsHtmlReport)) {
                writer.Write(File.ReadAllText(Globals.WebMetricsHtmlReport));
            }
        }

        #endregion Rendering
        
	};
}