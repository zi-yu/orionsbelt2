using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("ResourceOverview")]
	public class PlanetResourceOverviewRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.ResourceOverview; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='panelPlaceHolder'>");
            WriteResourcesIncome(writer, planet.Owner, planet);
            writer.Write("</div>");
        }

        private void WriteResourcesIncome(TextWriter writer, IPlayer player, IPlanet planet)
        {
            writer.Write("<table class='table'><tbody>");

            WriteHeader(writer, player);
            WriteFooter(writer, player);
            WriteBody(writer, player);

            writer.Write("</tbody></table>");
        }

        private static void WriteFooter(TextWriter writer, IPlayer player)
        {
            writer.Write("<tr>");
            writer.Write("<td>{0}</td>", LanguageManager.Instance.Get("Total"));
            writer.Write("<td></td>");
            writer.Write("<td>{0}</td>", GetPlanetScore(player));
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player))  {
                int total = GetIncomeSum(player, info);
                if (total != 0) {
                    writer.Write("<td>+{0}</td>", total);
                } else {
                    writer.Write("<td></td>");
                }
            }
            writer.Write("</tr>");
        }

        private static int GetIncomeSum(IPlayer player, IResourceInfo info)
        {
            int sum = 0;
            foreach (IPlanet planet in player.Planets) {
                sum += planet.GetPerTick(info);
            }
            return sum;
        }

        private static int GetPlanetScore(IPlayer player)
        {
            int sum = 0;
            foreach (IPlanet planet in player.Planets) {
                sum += planet.Score;
            }
            return sum;
        }

        private static void WriteBody(TextWriter writer, IPlayer player)
        {
            foreach (IPlanet curr in player.Planets)
            {
                writer.Write("<tr>");
                writer.Write("<td><a href='javascript:Planet.toHome({0});'>{1}</a></td>", curr.Storage.Id, curr.Name);
                writer.Write("<td>{0}</td>", curr.Level);
                writer.Write("<td>{0}</td>", curr.Score);
                foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player))
                {
                    writer.Write("<td>");
                    int amount = curr.GetPerTick(info);
                    if (amount != 0)
                    {
                        writer.Write("+{0}", amount);
                    }
                    writer.Write("</td>");
                }
                writer.Write("</tr>");
            }
        }

        private static void WriteHeader(TextWriter writer, IPlayer player)
        {
            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Planet"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("ZoneLevel"));
            writer.Write("<th>{0}</th>", LanguageManager.Instance.Get("Score"));
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player))
            {
                writer.Write("<th>{0}</th>", ResourcesManager.GetResourceSmallImageHtml(info));
            }
            writer.Write("</tr>");
        }

        #endregion Rendering

    };
}

