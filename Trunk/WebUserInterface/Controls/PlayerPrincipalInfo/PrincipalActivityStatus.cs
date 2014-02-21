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
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {

    public class PrincipalActivityStatus : BaseFieldControl<Principal> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Principal t, int renderCount, bool flipFlop)
        {
            ActivityStatus status = PlayerUtils.GetStatus(t.UpdatedDate);
            writer.Write("<span class='activityStatus {0}'></span>", status, status);
        }

        #endregion Events

    };

}
