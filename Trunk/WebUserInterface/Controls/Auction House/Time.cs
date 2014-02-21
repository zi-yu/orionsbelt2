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
    public class Time : BaseFieldControl<AuctionHouse>, INamingContainer
    {
        private bool showOperator = true;

        public bool ShowOperator
        {
            get { return showOperator; }
            set { showOperator = value; }
        }

        protected override void Render(HtmlTextWriter writer, AuctionHouse entity, int renderCount, bool flipFlop)
        {
            if (Utils.Principal.IsInRole("gameMaster"))
            {
                writer.Write(string.Format("<b>( {0}) </b>", TimeFormatter.GetFormattedTicksTo(entity.Timeout)));
            }

            if (entity.Timeout - Clock.Instance.Tick <= 6)
            {
                writer.Write(LanguageManager.Instance.Get("AlmostFinish"));
                return;
            }
            if (entity.Timeout - Clock.Instance.Tick <= 36)
            {
                writer.Write(LanguageManager.Instance.Get("Few"));
                return;
            }
            if (entity.Timeout - Clock.Instance.Tick <= 244)
            {
                writer.Write(LanguageManager.Instance.Get("Average"));
                return;
            }
            if (entity.Timeout - Clock.Instance.Tick <= 720)
            {
                writer.Write(LanguageManager.Instance.Get("Long"));
                return;
            }
            writer.Write(LanguageManager.Instance.Get("VeryLong"));
            
        }
    }
}
