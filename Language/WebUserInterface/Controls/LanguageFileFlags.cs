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

namespace Language.WebUserInterface.Controls {

    public class LanguageFileFlags : Control {

        #region Rendering

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (Locale locale in ProjectFile.GetLocales()) {
                if (ProjectFile.CanEditLocale(locale)) {
                    writer.Write("<th><img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' alt='{0}' title='{0}' /></th>", locale.Name);
                }
            }
        }

        #endregion Rendering

    };
}
