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

    public class IntergalacticUnits : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            WriteUnit(writer, "Raptor");
            WriteUnit(writer, "Panther");

            WriteUnit(writer, "Kamikaze");
            WriteUnit(writer, "Eagle");

            WriteUnit(writer, "Vector");
            WriteUnit(writer, "Spider");

            WriteUnit(writer, "Fenix");
            WriteUnit(writer, "Taurus");
        }

        private static void WriteUnit(HtmlTextWriter writer, string unitName)
        {
            writer.Write("<a title='{1}' href='http://manual.orionsbelt.eu/{0}/Unit/{1}.aspx'><img src='http://resources.orionsbelt.eu/Images/Common/Units/{2}.png' alt='{1}' /></a>&nbsp;",
                    LanguageManager.CurrentLanguage, unitName, unitName.ToLower()
                );
        }

        #endregion Rendering

    };

}
