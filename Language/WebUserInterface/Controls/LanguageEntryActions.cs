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

namespace Language.WebUserInterface.Controls {

    public class LanguageEntryActions : BaseFieldControl<LanguageEntry> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageEntry t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='EditEntry.aspx?Id={0}&Locale={1}'>Edit</a>", t.Id, GetLanguage());
        }

        private string GetLanguage()
        {
            string loc = Page.Request.QueryString["Locale"];
            if (!string.IsNullOrEmpty(loc)) {
                return loc;
            }

            foreach (Locale locale in ProjectFile.GetLocales()) {
                if (ProjectFile.CanEditLocale(locale)) {
                    return locale.Name;
                }
            }

            return string.Empty;
        }

        #endregion Rendering

    };
}
