using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("UnitOverview")]
	public class PlanetUnitOverviewRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.UnitOverview; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='panelPlaceHolder'>");

            WriteUnitProduction(writer, planet.Owner);

            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("DefenseFleet"));
            foreach (IPlanet curr in planet.Owner.Planets) {
                if (curr.DefenseFleet != null) {
                    FleetRenderer.RenderInPlanet(writer, curr, curr.DefenseFleet);
                }
            }

            writer.Write("</div>");
        }

        private void WriteUnitProduction(TextWriter writer, IPlayer player)
        {
            writer.Write("<table class='table'><tbody>");
            writer.Write("<tr><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>", LanguageManager.Instance.Get("Planet"), LanguageManager.Instance.Get("InConstruction"), LanguageManager.Instance.Get("Quantity"), LanguageManager.Instance.Get("Duration"), LanguageManager.Instance.Get("Status"));

            int count = GetPlanetsBuildingUnitsCount(player);
            if (count == 0) {
                writer.Write("<tr><td colspan='4'>{0}</td></tr>", string.Format(LanguageManager.Instance.Get("NoUnitsInQueue"), player.GetHomePlanet().Storage.Id));
            } else {
                foreach (IPlanet planet in player.Planets) {
                    int nrows = GetTotalRows(planet);
                    if (nrows == 0) {
                        continue;
                    }
                    writer.Write("<tr>");
                    writer.Write("<td colspan='{1}'><a href='javascript:Planet.toUnits({2});'>{0}</a></td>", planet.Name, 4, planet.Storage.Id);
                    writer.Write("</tr>");
                    WriteUnits(writer, planet.GetResourcesInProduction(ResourceType.Unit));
                    WriteUnits(writer, planet.GetQueueList(ResourceType.Unit));
                }
            }

            writer.Write("</tbody></table>");
        }

        private void WriteUnits(TextWriter writer, IList<IPlanetResource> list)
        {
            foreach( IPlanetResource resource in list ) {
                writer.Write("<tr>");
                writer.Write("<td style='padding:5px;'><img src='{0}' alt='{1}' /></td>", ResourcesManager.GetUnitImage(resource.Info.Name), LanguageManager.Instance.Get(resource.Info.Name));
                writer.Write("<td>{0}</td>", resource.Quantity);
                writer.Write("<td>{0}</td>", GetTimeToBuild(resource));
                writer.Write("<td>{0}</td>", GetState(resource));
                writer.Write("</tr>");
            }
        }

        private static string GetState(IPlanetResource resource)
        {
            string state = LanguageManager.Instance.Get(resource.State.ToString());
            if (resource.State != ResourceState.InConstruction) {
                return state;
            }
            return string.Format("<span class='blue'>{0}</span>", state);
        }

        private string GetTimeToBuild(IPlanetResource resource)
        {
            if (resource.State == ResourceState.InConstruction) {
                return TimeFormatter.GetFormattedTicksTo(resource.EndTick);
            }
            return TimeFormatter.GetFormattedTicks(resource.Info.GetBuildDuration(resource.Owner, resource));
        }

        private int GetTotalRows(IPlanet planet)
        {
            IList<IPlanetResource> construction = planet.GetResourcesInProduction(ResourceType.Unit);
            IList<IPlanetResource> queue = planet.GetQueueList(ResourceType.Unit);

            return queue.Count + construction.Count;
        }

        private int GetPlanetsBuildingUnitsCount(IPlayer player)
        {
            int sum = 0;
            foreach (IPlanet planet in player.Planets) {
                IList<IPlanetResource> construction = planet.GetResourcesInProduction(ResourceType.Unit);
                IList<IPlanetResource> queue = planet.GetQueueList(ResourceType.Unit);
                if (queue.Count > 0 || construction.Count > 0) {
                    ++sum;
                }
            }
            return sum;
        }

        #endregion Rendering

    };
}

