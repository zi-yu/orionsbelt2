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
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Join : System.Web.UI.Page {

        #region Fields

        protected OrionsBelt.WebComponents.Controls.Label alreadyAllianceMember;
        protected OrionsBelt.WebComponents.Controls.Label allianceJoinRequested;
        protected Button joinAlliance;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            bool pageAvailable = !AllianceWebUtils.PlayerHasAlliance();
            PreparePage(pageAvailable);

            if (joinAlliance.Enabled) {
                joinAlliance.Click += new EventHandler(joinAlliance_Click);
            }

            AllianceMenu.CurrentPage = "List";
        }

        void joinAlliance_Click(object sender, EventArgs e)
        {
            AllianceManager.RegisterSubscription(AllianceWebUtils.Current, PlayerUtils.Current);
            SetSuccessMessage();
        }

        private void SetSuccessMessage()
        {
            PreparePage(false);
            alreadyAllianceMember.Visible = false;
            allianceJoinRequested.Visible = true;
        }

        private void PreparePage(bool pageAvailable)
        {
            alreadyAllianceMember.Visible = !pageAvailable;
            allianceJoinRequested.Visible = false;
            joinAlliance.Text = LanguageManager.Instance.Get("AllianceSendJoinRequest");
            joinAlliance.Enabled = joinAlliance.Visible = pageAvailable;

        }

        #endregion Events

    };
}
