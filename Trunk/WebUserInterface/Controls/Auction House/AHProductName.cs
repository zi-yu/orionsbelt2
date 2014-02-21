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
    public class AHProductName : AuctionHouseDetails
    {
 
        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {

            if (((AuctionHouseType)Enum.Parse(typeof(AuctionHouseType), entity.ComplexNumber.ToString()) & AuctionHouseType.Ship) == 0)
            {
                writer.Write("<a href='{1}'>{0}</a>",
                    ResourcesManager.GetResourceSmallImageHtml(RulesUtils.GetResource(entity.Details)), ManualUtils.GetUrl(RulesUtils.GetResource(entity.Details)));
            }else
            {
                writer.Write("<a href='{2}'><img class='smallShip' src='{0}' alt='{1}' title='{1}'/></a>",
                    ResourcesManager.GetUnitImage(entity.Details), entity.Details, ManualUtils.GetUrl(RulesUtils.GetResource(entity.Details)));
            }

        }
    }
}
