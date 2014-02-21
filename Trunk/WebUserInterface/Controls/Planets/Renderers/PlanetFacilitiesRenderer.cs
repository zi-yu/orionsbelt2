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
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("Facilities")]
	public class PlanetFacilitiesRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.Facilities; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            TextWriter tooltip = new StringWriter();
            foreach (IFacilitySlot slot in planet.Info.FacilitySlots) {
                WriteSlot(writer, tooltip, planet, slot);
            }
            WriteTooltip(writer, tooltip);
        }

        protected override string GetPanelCssClass(IPlanet planet)
        {
            return string.Format("Level{0}", PlanetList.GetPlanetLevel(planet));
        }

        private void WriteSlot(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot)
        {
            writer.Write("<div class='{0}' id='{0}'>", slot.Identifier);

            IPlanetResource resource = planet.GetFacility(slot);
            if (resource == null) {
                if (!planet.HasFacilityAvailableForSlot(slot)) {
                    WriteNotAvailableslot(writer, tooltip, planet, slot);
                } else {
                    WriteEmptySlot(writer, tooltip, planet, slot);
                }
            } else {
                WriteResourceSlot(writer, tooltip, planet, slot, resource);
            }

            writer.Write("</div>");
        }

        private void WriteTooltip(TextWriter writer, TextWriter tooltip)
        {
            writer.Write("<script type='text/javascript'>");
            writer.Write("window.slotTips = {");
            writer.Write(tooltip.ToString());
            writer.Write("v:1};");
            writer.Write("</script>");
        }

        protected static void WriteTooltip(TextWriter tooltip, IFacilitySlot slot, string title, string body)
        {
            WriteTooltip(tooltip, slot, title, body, true);
        }

        protected static void WriteTooltip(TextWriter tooltip, IFacilitySlot slot, string title, string body, bool localize)
        {
            tooltip.Write("{0}:{{t:'{1}',b:'{2}',l:{3}}},", slot.Identifier, title, body, localize.ToString().ToLower());
        }

        protected virtual void WriteUpgradeTooltip(TextWriter tooltip, IPlanetResource resource)
        {
            string msg = string.Empty;
            string rawMessage = string.Empty;
            if (resource.State == ResourceState.Running) {
                msg = "ClickHereToUpgradeOnThisSlot";
            } else if( resource.State == ResourceState.InConstruction ) {
                rawMessage = string.Format("<span class=\"green\">{0}</span>", WebUtilities.GetFormattedTime(Clock.Instance.GetTimeLeft(resource.EndTick)));
            }
            tooltip.Write("{0}:{{t:'{1}',b:{{l:{2},s:'{3}',m:'{4}',rm:'{5}'}}}},", resource.Slot.Identifier, resource.Info.Name, resource.Level, resource.State, msg, rawMessage);
        }

        private void WriteNotAvailableslot(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot)
        {
        }

        private void WriteResourceSlot(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot, IPlanetResource resource)
        {
            WriteFacilityImage(writer, tooltip, planet, slot, resource);
        }

        protected virtual void WriteFacilityImage(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot, IPlanetResource resource)
        {
            writer.Write("<a href='javascript:Planet.upgrade({1},{0});'>", resource.Storage.Id, planet.Storage.Id);
            WriteImage(writer, planet, resource);
            writer.Write("</a>");

            WriteUpgradeTooltip(tooltip, resource);
        }

        protected virtual void WriteImage(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            writer.Write("<img src='{0}' alt='{1}' />", ResourcesManager.GetFacilityImage(planet.RaceInformation, resource), resource.Info.Name);
        }

        protected virtual void WriteEmptySlot(TextWriter writer, TextWriter tooltip, IPlanet planet, IFacilitySlot slot)
        {
            string image = ResourcesManager.GetFacilityImage(planet.RaceInformation, slot);
			writer.Write("<a href='javascript:Planet.build({3},\"{2}\");'><img src='{0}' alt='{1}' /></a>", image, slot.Identifier, slot.Identifier, planet.Storage.Id);

            WriteTooltip(tooltip, slot, "BuildFacility", GetBuildBody(slot), false);
        }

        public static string GetBuildBody(IFacilitySlot slot)
        {
            TextWriter body = new StringWriter();

            body.Write(LanguageManager.Instance.Get("ClickHereToBuildOnThisSlot"));
            body.Write("<ul>");
            foreach (IFacilityInfo info in slot.SupportedFacilities)
            {
                body.Write("<li><span class=\"green\">{0}</span></li>", LanguageManager.Instance.Get(info.Name));
            }
            body.Write("</ul>");
            return body.ToString();
        }

        #endregion Rendering

    };
}

