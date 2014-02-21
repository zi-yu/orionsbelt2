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

namespace Institutional.WebUserInterface.Controls {

    public class Scripts : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<script src='http://resources.orionsbelt.eu/Scripts/v/Engine.js' type='text/javascript' ></script>");
			
#if DEBUG
            writer.Write("<script src='Scripts/Script.js' type='text/javascript' ></script>", WebUtilities.ApplicationPath);
#else
            writer.Write("<script src='http://resources.orionsbelt.eu/Institutional/Scripts/Script.js?v={0}' type='text/javascript' ></script>", ConfigurationManager.AppSettings["version"]);
#endif
        }

        #endregion Rendering

    };

}
