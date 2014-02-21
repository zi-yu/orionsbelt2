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
    public class CampaignTitle : BaseFieldControl<Campaign> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Campaign t, int renderCount, bool flipFlop)
        {
            writer.Write(LanguageManager.Localize(string.Format("{0}Title", t.Name)));
        }

        #endregion Events

    };
}
