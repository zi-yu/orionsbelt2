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
using Language.WebComponents;

namespace Language.WebUserInterface.Controls {

    public class LanguageTranslationCopy : BaseFieldControl<LanguageTranslation> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageTranslation t, int renderCount, bool flipFlop)
        {
            //if (State.HasItems("MainContentEmpty")) {
                writer.Write("(<a href='javascript:updateContent(\"lang_{0}\");'>Copy</a>)", t.Locale);
            //}
        }

        #endregion Rendering

    };
}
