using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Enum;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class SHProductName : OfferingProduct
    {

        protected override void Render(HtmlTextWriter writer, Offering entity, int renderCount, bool flipFlop)
        {

            writer.Write("<a href='{1}'>{0}</a>",
                ResourcesManager.GetResourceSmallImageHtml(RulesUtils.GetResource(entity.Product)), ManualUtils.GetUrl(RulesUtils.GetResource(entity.Product)));
          
        }
    }
}
