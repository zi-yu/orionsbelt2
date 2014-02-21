using System;
using System.Web;
using System.Web.UI;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Info : Page {

        protected AllianceInfoReader reader;
        protected int alliance;
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            string id = HttpContext.Current.Request.QueryString["Id"];
            int intId;
            if (Int32.TryParse(id, out intId))
            {
                reader.AllianceId = intId;
            }
            AllianceMenu.CurrentPage = "List";
        }
    };
}
