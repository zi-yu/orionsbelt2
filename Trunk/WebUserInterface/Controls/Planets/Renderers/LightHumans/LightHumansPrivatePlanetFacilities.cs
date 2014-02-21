using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
	public class LightHumansPrivatePlanetFacilities : PlanetFacilitiesRenderer  {

        #region Rendering

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            base.RenderPlanetPanel(writer, planet);
        }

        #endregion Rendering

    };
}

