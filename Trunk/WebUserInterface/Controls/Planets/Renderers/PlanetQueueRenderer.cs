using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;
using DesignPatterns.Attributes;
using OrionsBelt.Engine.Resources;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("Queue")]
	public class PlanetQueueRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.Queue; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='panelPlaceHolder'>");

            writer.Write("<div class='oneOfTwoPanels'>");
            if (!WriteProductionQueue(writer, planet, ResourceType.Facility)) {
                writer.Write(string.Format(LanguageManager.Instance.Get("NoFacilitiesInQueue"), planet.Storage.Id));
            }
            writer.Write("</div>");

            writer.Write("<div class='oneOfTwoPanels'>");
            if( planet.Info.GetUnitBuilderFacility() != null ) {
                if (!WriteProductionQueue(writer, planet, ResourceType.Unit)) {
                    writer.Write(string.Format(LanguageManager.Instance.Get("NoUnitsInQueue"), planet.Storage.Id));
                }
            }
            writer.Write("</div>");

            writer.Write("<div class='clear'></div>");

            writer.Write("</div>");
        }

        #endregion Rendering

    };
}

