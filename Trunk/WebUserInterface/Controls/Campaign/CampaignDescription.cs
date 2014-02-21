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
    public class CampaignDescription : BaseFieldControl<Campaign> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Campaign t, int renderCount, bool flipFlop)
        {
            writer.Write(string.Format(LanguageManager.Localize(string.Format("{0}Description", t.Name)), WebUtilities.ApplicationPath));
        }

        #endregion Events

    };
}
