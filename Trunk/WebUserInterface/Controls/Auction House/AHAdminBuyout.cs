using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AHAdminBuyout : AuctionHouseBuyout
    {

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            writer.Write("<div>");
            base.Render(writer, entity, renderCount, flipFlop);

            writer.Write(" <a href='AuctionAdmin.aspx?buy={0}'><img src='{1}' alt='{2}'/></a></div>",
                         entity.Id, ResourcesManager.GetImage("Icons/Orions.png"),
                         LanguageManager.Instance.Get("Buyout"));
        }
    }
}
