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

    public class Styles : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<link rel='stylesheet' media='screen' type='text/css' href='http://resources.orionsbelt.eu/Styles/v/Engine.css'></link>");

#if DEBUG
            writer.Write("<link rel='stylesheet' media='screen' type='text/css' href='{0}Styles/Style.css'></link>", WebUtilities.ApplicationPath);
#else
            writer.Write("<link rel='stylesheet' media='screen' type='text/css' href='http://resources.orionsbelt.eu/Institutional/Styles/Style.css'></link>");
#endif
        }

        #endregion Rendering

    };

}
