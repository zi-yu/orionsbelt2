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

    public class LanguageFileLink : BaseFieldControl<LanguageFile> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageFile t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='ProjectFile.aspx?Id={0}&Name={2}'>{1}</a>", t.Id, t.Name, HttpUtility.UrlEncode( t.Name));
        }

        #endregion Rendering

    };
}
