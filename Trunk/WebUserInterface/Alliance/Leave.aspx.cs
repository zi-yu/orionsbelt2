using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.Engine.Alliances;
using OrionsBelt.WebComponents;
using OrionsBelt.Core;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Leave : System.Web.UI.Page
    {

        #region Fields

        protected Button leaveAlliance;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            bool pageAvailable = AllianceWebUtils.PlayerHasAlliance();
            PreparePage(pageAvailable);

            if (leaveAlliance.Enabled) {
                leaveAlliance.Click += new EventHandler(leaveAlliance_Click);
            }
        }

        void leaveAlliance_Click(object sender, EventArgs e)
        {
            AllianceManager.LeaveAlliance(PlayerUtils.Current);
            SetSuccessMessage();
        }

        private void SetSuccessMessage()
        {
            Response.Redirect(AllianceWebUtils.GetUrl());
        }

        private void PreparePage(bool pageAvailable)
        {
            leaveAlliance.Text = LanguageManager.Instance.Get("AllianceLeaveAction");
        }

        #endregion Events

    };
}
