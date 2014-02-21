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
	public class DarkHumansPrivatePlanetFacilities : PlanetFacilitiesRenderer  {

        #region Rendering

        protected override void WriteFacilityImage(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot, IPlanetResource resource)
        {
            string css = GetCss(slot, resource);

            writer.Write("<a class='{2}' href='javascript:Planet.upgrade({1},{0});'>", resource.Storage.Id, planet.Storage.Id, css);
            writer.Write(" ");
            writer.Write("</a>");

            WriteUpgradeTooltip(tooltip, resource);
        }

        protected override void WriteEmptySlot(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot)
        {
            writer.Write("<a class='empty' href='javascript:Planet.build({1},\"{0}\");'> </a>", slot.Identifier, planet.Storage.Id);

            WriteTooltip(tooltip, slot, "BuildFacility", GetBuildBody(slot), false);
        }

        #endregion Rendering

        #region Utilities

        private static string GetCss(IFacilitySlot slot, IPlanetResource resource)
        {
            if (resource.State != OrionsBelt.RulesCore.Common.ResourceState.Running) {
                return "inConstruction";
            }

            if (slot.SupportedFacilities.Count > 1) {
                return string.Format("baseGeneric {0}{1}", slot.PositionChoice, resource.Info.Name );
            }

            return "image";
        }

        #endregion Utilities

    };
}

