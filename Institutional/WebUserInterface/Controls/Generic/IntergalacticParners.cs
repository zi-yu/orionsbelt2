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

    public class IntergalacticPartners : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<ul>");
            writer.Write("<li><a href='http://www.onrpg.com' title='Free mmorpg'><img src='http://resources.orionsbelt.eu/Images/Partners/onrpg_logo_freemmorpg.png' alt='Free mmorpg' /></a></li>");
            writer.Write("<li><a href='http://www.freebrowsergamer.com/' title='free browser gamer'><img style='width:212px' src='http://resources.orionsbelt.eu/Images/Partners/freebrowsergamer-logo.png' alt='free browser gamer' /></a></li>");
            writer.Write("<li><a href='http://www.pdmfc.com' title='PDMFC'><img src='http://www.almansur.net/images/logo_pdm.png' alt='PDM' /></a></li>");
            writer.Write("</ul>");
        }

        #endregion Rendering

    };

}
