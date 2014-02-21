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

namespace OrionsBelt.WebUserInterface.Controls
{
    public class CampaignLevelMoves : BaseFieldControl<CampaignLevel> {

        #region Events

        protected override void Render(HtmlTextWriter writer, CampaignLevel t, int renderCount, bool flipFlop)
        {
            if (t.CampaignStatus.Count == 0) {
                return;
            }
            if (t.CampaignStatus[0].Completed) {
                writer.Write("{0}",
                        t.CampaignStatus[0].Moves, WebUtilities.ApplicationPath, t.CampaignStatus[0].Battle.Id
                    );
            } else {
                writer.Write("?");
            }
        }

        #endregion Events

    };
}
