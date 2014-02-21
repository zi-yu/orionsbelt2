using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class CampaignLevelPlayerFleet : BaseFieldControl<CampaignLevel> {

        #region Events

        protected override void Render(HtmlTextWriter writer, CampaignLevel t, int renderCount, bool flipFlop)
        {
            FleetRender.WriteUnits(writer, new FleetInfo("Campaign", null, t.PlayerFleet));
        }

        #endregion Events

    };
}
