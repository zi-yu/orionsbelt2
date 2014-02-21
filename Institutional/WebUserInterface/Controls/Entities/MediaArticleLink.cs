using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using Institutional.Core;
using Institutional.WebComponents.Controls;

namespace Institutional.WebUserInterface.Controls {

    public class MediaArticleLink : BaseFieldControl<MediaArticle> {

        #region Rendering

        protected override void Render(HtmlTextWriter writer, MediaArticle t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href=\"{0}\">{1}</a>", t.Url, t.Name);
        }

        #endregion Rendering

    };

}
