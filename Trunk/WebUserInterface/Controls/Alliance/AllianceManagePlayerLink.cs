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

    public class AllianceManagePlayerLink : BaseFieldControl<PlayerStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, PlayerStorage t, int renderCount, bool flipFlop)
        {
            if( !AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance ) {
                return;
            }
            string url = AllianceWebUtils.GetUrl(AllianceWebUtils.Current, "ManageMember");
            string href = string.Format("{0}&Player={1}", url, t.Id);

            GenericRenderer.WriteRightLinkButton(writer, href, LanguageManager.Instance.Get("AllianceManageMemberLink"));
        }

        #endregion Events

    };

}
