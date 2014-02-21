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
    public class CampaignPlay : BaseFieldControl<Campaign> {

        #region Events

        protected override void Render(HtmlTextWriter writer, Campaign t, int renderCount, bool flipFlop)
        {
            GenericRenderer.WriteLeftLinkButton(writer, string.Format("Detail.aspx?Id={0}&Campaign={1}", t.Id, t.Name), LanguageManager.Localize("More"));
        }

        #endregion Events

    };
}
