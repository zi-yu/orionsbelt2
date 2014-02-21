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

    public class AllianceManageDiplomacyLink : BaseFieldControl<AllianceStorage> {

        #region Events

        protected override void Render(HtmlTextWriter writer, AllianceStorage t, int renderCount, bool flipFlop)
        {
            if (AllianceWebUtils.CurrentPlayerOwnsCurrentAlliance) {
                writer.Write("<td style='width:180px;'>");
                string href = string.Format("{0}?Id={2}&Other={1}'", AllianceWebUtils.GetUrl("ManageDiplomacy"), t.Id, AllianceWebUtils.Current.Storage.Id);
                GenericRenderer.WriteRightLinkButton(writer,href,LanguageManager.Instance.Get("ManageAllianceDiplomacy"));
                writer.Write("</td>");
            }
        }

        #endregion Events

    };

}
