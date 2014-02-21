using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    public class AllianceLink : BaseFieldControl<AllianceStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, AllianceStorage t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='{0}'>{1}</a>", AllianceWebUtils.GetUrl(t), t.Name);
        }

        #endregion Events

    };

}
