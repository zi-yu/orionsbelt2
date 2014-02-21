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

    public class LanguageEntryName : BaseFieldControl<LanguageEntry> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageEntry t, int renderCount, bool flipFlop)
        {
            writer.Write("<span style='color:{1};'>{0}</span>", t.Name, GetStatusColor(t));
        }

        public static string GetStatusColor(LanguageEntry t)
        {
            if (t.Translations != null && t.Translations.Count > 0) {
                if (string.IsNullOrEmpty(t.Translations[0].Text)) {
                    return "#DDD";
                } else {
                    return "#3CB371";
                }
            }
            return "#FFF";
        }

        #endregion Rendering

    };
}
