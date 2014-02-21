using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.RulesCore;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class MarketProductName : ProductName
    {
 
        protected override void Render(HtmlTextWriter writer, Product entity, int renderCount, bool flipFlop)
        {

            writer.Write("{0}", ResourcesManager.GetResourceSmallImageHtml(RulesUtils.GetResource(entity.Name)));


        }
    }
}
