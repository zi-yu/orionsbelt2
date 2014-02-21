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
using OrionsBelt.RulesCore;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;
using System.Collections.Generic;
using OrionsBelt.RulesCore.Enum;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("Units")]
	public class PlanetUnitsRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.Units; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            if (!ResourceUtils.HasUnitsAvailable(planet)) {
                WriteNoUnitsMessage(writer, planet);
                return;
            }
            WriteUnitQueue(writer, planet);
            WriteBuildList(writer, planet);
        }

        private void WriteNoUnitsMessage(TextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='panelPlaceHolder'>");
            IFacilityInfo info = planet.Info.GetUnitBuilderFacility();
            string url = ManualUtils.GetLink(info, LanguageManager.Instance.Get(info.Name));
            writer.Write(string.Format(LanguageManager.Instance.Get("NoUnitsAvailable"), url));
            writer.Write("</div>");
        }

        private void WriteUnitQueue(TextWriter writer, IPlanet planet)
        {
            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("ProductionQueue"));

            writer.Write("<div style='background-color:#272727;' class='panelPlaceHolder'>");
            bool writtenSomething = WriteProductionQueue(writer, planet, ResourceType.Unit);
            if (!writtenSomething) {
                writer.Write(LanguageManager.Instance.Get("NoUnitsBeingProduced"));
            }
            writer.Write("</div>");
        }

        private void WriteBuildList(TextWriter writer, IPlanet planet)
        {
            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("BuildUnits"));
            writer.Write("<ul class='buildUnits'>");
            foreach (IUnitInfo info in GetSortedUnits(planet)) {
                if (info.IsBuildAvailable(planet).Ok) {
                    writer.Write("<li>");
                    WriteUnit(writer, planet, info);
                    writer.Write("</li>");
                }
            }
            writer.Write("</ul>");
        }

        private static System.Collections.Generic.IEnumerable<IUnitInfo> GetSortedUnits(IPlanet planet)
        {
            List<IUnitInfo> list = new List<IUnitInfo>(RulesUtils.GetRaceUnits(planet.Info));
            list.Sort(delegate(IUnitInfo u1, IUnitInfo u2) {
                    if( u1.UnitCategory == u2.UnitCategory ) {
                        return u1.UnitValue.CompareTo(u2.UnitValue);
                    }
                    return GetWeigth(u1).CompareTo(GetWeigth(u2));
                });
            return list;
        }

        private static int GetWeigth(IUnitInfo unit)
        {
            switch (unit.UnitCategory) {
                case UnitCategory.Light: return 1;
                case UnitCategory.Medium: return 2;
                case UnitCategory.Heavy: return 3;
                case UnitCategory.Special: return 0;
                case UnitCategory.Ultimate: return 4;
                default: return 0;
            }
        }

        private void WriteUnit(TextWriter writer, IPlanet planet, IUnitInfo info)
        {
            writer.Write("<div class='preview'><img src='{0}' alt='{1}' title='{1}' /></div>", ResourcesManager.GetUnitPerspectiveImage(info.Name), info.Name);

            string manualLink = string.Format("<a href='{0}' title='{1}'>?</a>", ManualUtils.GetUrl(info), LanguageManager.Instance.Get("Manual"));

            writer.Write("<div class='info'>");
            writer.Write("<h4>{0} {1}</h4>", LanguageManager.Instance.Get(info.Name), manualLink);
            WriterCost(writer, planet, info, 1);
            writer.Write("</div>");

            writer.Write("<div class='buildQuantity'>");
            writer.Write("<p>{0}</p>", LanguageManager.Instance.Get("Quantity"));
            writer.Write("<input type='text' name='{0}_Quantity' id='{0}_Quantity' value='{1}' />", info.Name, GetMaxToBuy(planet, info));
            WriteBuildButton(writer, planet, info);
            writer.Write("</div>");
        }

        private int GetMaxToBuy(IPlanet planet, IUnitInfo info)
        {
            return ResourceUtils.GetMaxQuantityToBuild(planet.Owner, info);
        }

        private static void WriteBuildButton(TextWriter writer, IPlanet planet, IUnitInfo info)
        {
            GenericRenderer.WriteLeftLinkButton(writer,
                        string.Format("javascript:Planet.startBuildUnit({0}, \"{1}\");", planet.Storage.Id, info.Name),
                        string.Format("{0}", LanguageManager.Instance.Get("Build"))
                    );
        }

        private void WriteUnitOld(TextWriter writer, IPlanet planet, IUnitInfo info)
        {
            writer.Write("{0}", info.Name);
            writer.Write("<input type='text' name='{0}_Quantity' id='{0}_Quantity' value='0' />", info.Name);
            writer.Write("<a href='javascript:Planet.startBuildUnit({0}, \"{1}\");'>Build</a>", planet.Storage.Id, info.Name);
        }

        #endregion Rendering

    };
}


