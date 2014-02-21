using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.WebComponents;
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class RealTime : BaseFieldControl<AuctionHouse>, INamingContainer
    {
        private bool showOperator = true;

        public bool ShowOperator
        {
            get { return showOperator; }
            set { showOperator = value; }
        }

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            writer.Write(string.Format("<b>{0}</b>", TimeFormatter.GetFormattedTicksTo(entity.Timeout))); 
        }
    }
}
