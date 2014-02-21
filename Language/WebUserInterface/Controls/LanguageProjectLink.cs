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

    public class LanguageProjectLink : BaseFieldControl<LanguageProject> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, LanguageProject t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='Project.aspx?Id={0}&Name={1}'>{1}</a>", t.Id, t.Name);
        }

        #endregion Rendering

    };
}
