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
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Alliance
{
    public class Members : System.Web.UI.Page {

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            AllianceWebUtils.AssertCurrentPlayerBelongsToCurrentAlliance();
            AllianceStorage alliance = State.GetItems<AllianceStorage>();
            alliance.Players = Relics.GetSortedMembers(alliance.Players);
        }

        #endregion Events


    };
}
