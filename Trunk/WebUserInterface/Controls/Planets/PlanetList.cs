using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PlanetList: Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Planets"));
            writer.Write("<ul>");
            foreach (IPlanet planet in GetPlanets()) {
                writer.Write("<li>");
                WritePlanet(writer, planet);
                writer.Write("</li>");
            }
            writer.Write("</ul>");
            writer.Write("<div class='planetListEnd'></div>");
        }

        private static System.Collections.Generic.IList<IPlanet> GetPlanets()
        {
            List<IPlanet> list = (List<IPlanet>)PlayerUtils.Current.Planets;
            return list;
        }

        private void WritePlanet(HtmlTextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='planetInfo'>");
            writer.Write("<div class='planetPreview {0}{1}{2}'></div>", planet.Terrain.Terrain, planet.RaceInformation.Race, GetPlanetLevel(planet));
            writer.Write("</div>");

            writer.Write("<div class='planetInfo'>");
            writer.Write("<a id='planetName{0}' href='javascript:Planet.toHome({0});'>{1}</a>", planet.Storage.Id, planet.Name);

            writer.Write("<ul>");
            WriteIcon(writer, planet, "Facilities", "PlanetIcon", "toHome");
            WriteIcon(writer, planet, "Queue", "QueueIcon", "getQueue");
            if (ResourceUtils.CanBuildUnits(planet)) {
                WriteIcon(writer, planet, "Units", "UnitsIcon", "toUnits");
            }
            WriteIcon(writer, planet, "Fleets", "FleetsIcon", "toFleets");
            writer.Write("</ul>");
            writer.Write("</div>");
        }

        internal static int GetPlanetLevel(IPlanet planet)
        {
            if (planet.Info.HotZone) {
                if (planet.FacilityLevel <= 2) {
                    return 1;
                }
                if (planet.FacilityLevel <= 4) {
                    return 3;
                }
                return planet.FacilityLevel;
            }

            if (planet.FacilityLevel < 4) {
                return 1;
            }
            if (planet.FacilityLevel < 8) {
                return 3;
            }
            
            return 5;
        }

        private static void WriteIcon(HtmlTextWriter writer, IPlanet planet, string label, string icon, string action)
        {
            writer.Write("<li><a href='javascript:Planet.{3}({0});'><img title='{1}' src='{2}' /></a></li>",
                    planet.Storage.Id,
                    LanguageManager.Instance.Get(label),
                    ResourcesManager.GetPlanetImage(icon),
                    action
                );
        }

        #endregion Events

    };
}

