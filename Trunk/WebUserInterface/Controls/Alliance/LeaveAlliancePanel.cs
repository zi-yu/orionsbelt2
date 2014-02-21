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

    public class LeaveAlliancePanel : Control {

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Visible = AllianceWebUtils.PlayerHasAlliance();
        }

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<a href='Leave.aspx?Id={1}'>{0}</a>", LanguageManager.Instance.Get("AllianceLeaveAlliance"), AllianceWebUtils.Current.Storage.Id);
        }

        #endregion Events

    };

}
