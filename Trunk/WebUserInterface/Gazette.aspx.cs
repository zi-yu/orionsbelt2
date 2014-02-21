using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface
{
    public partial class Gazette : System.Web.UI.Page
    {
        #region Fields

        protected Literal content;

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            content.Text = WebUtilities.WriteFrame("http://gazette.orionsbelt.eu/");
        }

        #endregion Events

    };
}
