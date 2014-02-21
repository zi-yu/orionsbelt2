using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders a planet panel using a PlanetRenderer
    /// </summary>
	public class PlanetPanel: Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            IPlanet planet = PlanetsMaster.Current;
            PlanetRenderer renderer = PlanetRenderer.Get(planet, Panel);
            renderer.Render(writer, planet);
        }

        #endregion Events

        #region Properties

        private PlanetRendererPanel panel;

        public PlanetRendererPanel Panel {
            get { return panel; }
            set { panel = value; }
        }

        #endregion Properties

    };
}

