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

    public class LanguageEntryLocalePreview : BaseFieldControl<LanguageEntry> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageEntry t, int renderCount, bool flipFlop)
        {
            string content = string.Empty;
            if (t.Translations != null && t.Translations.Count > 0) {
                content = t.Translations[0].Text;
                if (content.Length > 300) {
                    content = content.Substring(0, 300);
                }
            }
            writer.Write("<span style='color:{1};'>{0}</span>", HttpUtility.HtmlEncode(content), LanguageEntryName.GetStatusColor(t));
        }

        #endregion Rendering

    };
}
