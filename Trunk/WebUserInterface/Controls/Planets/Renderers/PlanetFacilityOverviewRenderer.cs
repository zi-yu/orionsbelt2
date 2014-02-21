using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("FacilityOverview")]
	public class PlanetFacilityOverviewRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.FacilityOverview; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            writer.Write("<div class='panelPlaceHolder'>");
            WritePrivateZonePlanets(writer, planet);
            writer.Write("</div>");
        }

        private static void WritePrivateZonePlanets(TextWriter writer, IPlanet planet)
        {
            IPlanetInfo info = null;

            writer.Write("<table class='table'><tbody>");

            writer.Write("<tr>");
            writer.Write("<th></th>");
            foreach (IPlanet curr in planet.Owner.Planets) {
                if (curr.Info.HotZone) {
                    continue;
                }
                info = curr.Info;
                writer.Write("<th><a href='javascript:Planet.toHome({1});'>{0}</a></th>", curr.Name, curr.Storage.Id);
            }
            writer.Write("</tr>");
            foreach (IFacilitySlot slot in info.FacilitySlots) {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", LanguageManager.Instance.Get(slot.Identifier));
                foreach (IPlanet curr in planet.Owner.Planets) {
                    if (curr.Info.HotZone) {
                        continue;
                    }
                    IPlanetResource resource = curr.GetFacility(slot);
                    writer.Write("<td style='padding:5px;'>");
                    if (resource != null) {
                        writer.Write("<a href='javascript:Planet.upgrade({3},{4});'>{0}</a><br/>", LanguageManager.Instance.Get(resource.Info.Name), LanguageManager.Instance.Get("Level"), resource.Level, curr.Storage.Id, resource.Storage.Id);                        
                        WriteLevel(writer, planet, resource);
                        writer.Write("<br/>");
                        writer.Write("<span class='{1}'>{0}</span>", LanguageManager.Instance.Get(resource.State.ToString()), GetCssClass(resource.State));
                        if (resource.State == ResourceState.InConstruction) {
                            writer.Write("<br/>{0}", TimeFormatter.GetFormattedTicksTo(resource.EndTick));
                        }
                    }
                    writer.Write("</td>");
                }
                writer.Write("</tr>");
            }

            writer.Write("</tbody></table>");
        }

        private static void WriteLevel(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            if (resource.State != ResourceState.Running) {
                writer.Write("<span class='blue'>{0} {1}</span>", LanguageManager.Instance.Get("Level"), resource.Level);
                return;
            }
            if (resource.Level == planet.Owner.PlanetLevel) {
                writer.Write("<span class='green'>{0} {1}</span>", LanguageManager.Instance.Get("Level"), resource.Level);
                return;
            }
            if (resource.Level > planet.Owner.PlanetLevel) {
                writer.Write("<span class='green'><b>{0} {1}</b></span>", LanguageManager.Instance.Get("Level"), resource.Level);
                return;
            }
            writer.Write("{0} {1}", LanguageManager.Instance.Get("Level"), resource.Level);
        }

        private static string GetCssClass(ResourceState state)
        {
            if (state == ResourceState.Running) {
                return "green";
            }
            return "blue";
        }

        #endregion Rendering

    };
}

