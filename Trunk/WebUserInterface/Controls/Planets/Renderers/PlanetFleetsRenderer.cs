using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("Fleets")]
	public class PlanetFleetsRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.Fleets; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
			writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("FleetName"));
			writer.Write("<div class='panelPlaceHolder'>");
			CreateFleetRenderer.Render(writer,planet);
			writer.Write("</div>");

			FleetsInPlanetRenderer.Render(writer, planet);
        }

        #endregion Rendering

    };
}

