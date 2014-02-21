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

    public class LanguageTranslationText : BaseFieldControl<LanguageTranslation> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageTranslation t, int renderCount, bool flipFlop)
        {
            writer.Write("<div id='lang_{0}' style='display:none;'>", t.Locale);
            writer.Write(t.Text);
            writer.Write("</div>");

            writer.Write("<pre style='font-size:10px;padding:10px;overflow:auto;border:solid 1px #AAA;margin-bottom:15px;'>", t.Locale);
            writer.Write(HttpUtility.HtmlEncode(t.Text));
            writer.Write("</pre>");
        }

        #endregion Rendering

    };
}
