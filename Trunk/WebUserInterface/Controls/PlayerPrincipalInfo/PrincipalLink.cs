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
using OrionsBelt.Engine.Resources;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalLink : BaseFieldControl<Principal> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            writer.Write("<a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a>", WebUtilities.ApplicationPath, t.Id, t.Name);
        }

        #endregion Events

    };

}
