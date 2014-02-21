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
    public class ChampionTime : BaseFieldControl<ArenaStorage>, INamingContainer
    {
        private bool showOperator = true;

        public bool ShowOperator
        {
            get { return showOperator; }
            set { showOperator = value; }
        }

        protected override void Render(HtmlTextWriter writer, ArenaStorage entity, int renderCount, bool flipFlop)
        {
            if (entity.ConquestTick != 0)
            {
                writer.Write(TimeFormatter.GetFormattedTicksSince(entity.ConquestTick));
            }else
            {
                writer.Write(LanguageManager.Instance.Get("NotFoundYet"));
            }
        }
    }
}
