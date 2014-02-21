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
    public class SHDonor : BaseFieldControl<Offering>, INamingContainer
    {
        protected override void Render(HtmlTextWriter writer, Offering entity, int renderCount, bool flipFlop)
        {
            writer.Write(WebUtilities.WritePlayerWithAvatar(entity.Donor, true, false));
            
        }
    }
}
