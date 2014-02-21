using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class NearMarkets : ControlBase
    {
        private SectorCoordinate coordinates;

        #region Control Events

        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            IList<SectorCoordinate> systems = MarketUtil.GetNearMarkets(coordinates);

            writer.Write("<h2>{0}</h2><ul>", LanguageManager.Instance.Get("NearMarkets"));
            foreach (SectorCoordinate system in systems)
            {
                writer.Write("<li>{2} {0}:{1}</li>", system.System.X, system.System.Y, LanguageManager.Instance.Get("InSystem"));
            }
            writer.Write("</ul>");
        }

        #endregion Control Events        

        public SectorCoordinate Coordinates
        {
            get { return coordinates; }
            set {coordinates = value; }
        }
    }
}
