using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Races;
using OrionsBelt.RulesCore;

namespace OrionsBelt.WebUserInterface.Controls {

	public class PlanetSideInfo: Control {

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            IPlanet planet = PlanetsMaster.Current;

            WritePlanetOverview(writer, planet);
            WritePlanetInfo(writer, planet);
            WritePlanetIncome(writer, planet);

            //WriteGlobalInfo(writer, planet.Owner);
        }

        private static void WritePlanetOverview(HtmlTextWriter writer, IPlanet planet)
        {
            writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("PlanetOverview"));
            writer.Write("<ul>");
            writer.Write("<li><a href='javascript:Planet.toPanel({0}, \"ResourceOverview\");'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("ResourceOverview"));
            writer.Write("<li><a href='javascript:Planet.toPanel({0}, \"FacilityOverview\");'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("FacilityOverview"));
            writer.Write("<li><a href='javascript:Planet.toPanel({0}, \"UnitOverview\");'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("UnitOverview"));
            writer.Write("</ul>");
        }

        private static void WritePlanetInfo(HtmlTextWriter writer, IPlanet planet)
        {
            writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("PlanetInfo"));
            writer.Write("<ul>");
            writer.Write("<li>{0}: <span id='ProductionFactor'>{1}</span></li>", LanguageManager.Instance.Get("ProductionFactor"), planet.FinalProductionFactor);
            writer.Write("<li>{0}: <span id='Capacity'>{1}</span></li>", LanguageManager.Instance.Get("Capacity"), planet.Owner.GetLimit(null));
            writer.Write("<li>{0}: <span id='QueueSpace'>{1}</span></li>", LanguageManager.Instance.Get("QueueSpace"), planet.Owner.GetQuantity(QueueSpace.Resource));
            writer.Write("</ul>");
        }

        private static void WritePlanetIncome(HtmlTextWriter writer, IPlanet planet)
        {
            writer.Write("<h2>{0}</h2>", LanguageManager.Instance.Get("Income"));
            writer.Write("<ul>");
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(planet.Owner))
            {
                string css = string.Empty;
                int perTick = planet.GetPerTick(info);
                if (perTick == 0)
                {
                    css = " style='display:none;'";
                }
                writer.Write("<li{5}>{2} <a href='{3}'>{0}</a> : +<span id='{4}Mod'>{1}</span></li>", LanguageManager.Instance.Get(info.Name), perTick, ResourcesManager.GetResourceSmallImageHtml(info), ManualUtils.GetUrl(info), info.Name, css);
            }
            writer.Write("</ul>");
            //writer.Write("<div class='planetListEnd'></div>");
        }

        private void WriteGlobalInfo(HtmlTextWriter writer, IPlayer player)
        {
            writer.Write("<h5>Total Income</h5>");
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(player))
            {
                int sum = 0;
                foreach (IPlanet planet in player.Planets)
                {
                    sum += planet.GetPerTick(info);

                }
                writer.Write("{0} : +{1}<br/>", info.Name, sum);
            }
        }

	    #endregion Events

    };
}

