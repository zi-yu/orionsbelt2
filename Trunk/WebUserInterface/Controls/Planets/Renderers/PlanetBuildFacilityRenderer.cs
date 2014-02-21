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
using System.Collections.Generic;
using OrionsBelt.RulesCore;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("BuildFacility")]
	public class PlanetBuildFacilityRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.BuildFacility; }
        }

        protected virtual int TargetLevel {
            get { return 1;  }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            IFacilitySlot slot = GetFacilitySlot(planet);

            writer.Write("<ul>");
            foreach (IFacilityInfo info in slot.SupportedFacilities) {
                writer.Write("<li>");
                WriteFacilitySlot(writer, planet, slot, info);
                writer.Write("</li>");
            
            }
            writer.Write("</ul>");
        }

        protected void WriteFacilitySlot(TextWriter writer, IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
			writer.Write("<div class='facilitiesBuild'>");
			writer.Write("<div class='display'>");
            GetImageCode(writer, planet, info);
            writer.Write("</div>");

            writer.Write("<div class='info'>");
            WriteHeader(writer, info);
            WriteDescription(writer, info);
            WriterCost(writer, planet, info, TargetLevel);
            WriteBuildButton(writer, planet, slot, info);
            WriteOtherButtons(writer, planet, slot, info);
            writer.Write("</div>");
			writer.Write("<div class='facilitiesBuildEnd'></div>");
			writer.Write("</div>");
        }

        protected virtual void GetImageCode(TextWriter writer, IPlanet planet, IFacilityInfo info)
        {
            if (planet.RaceInformation.Race == Race.LightHumans)  {
                writer.Write("<img src='{0}' alt='' />", ResourcesManager.GetFacilityImage(planet.RaceInformation, info));
            } else {
				writer.Write("<div class='base{1}Preview {1}{0}Preview'></div>", info.Name, planet.RaceInformation.Race);
            }
        }

        protected virtual void WriteHeader(TextWriter writer, IFacilityInfo info)
        {
            writer.Write("<h4>{0} {1} {2}</h4>", LanguageManager.Instance.Get(info.Name), LanguageManager.Instance.Get("Level"), TargetLevel);
        }

        private void WriteDescription(TextWriter writer, IFacilityInfo info)
        {
            string desc = LanguageManager.Instance.Get(string.Format("{0}Description", info.Name));
            if (!string.IsNullOrEmpty(desc)) {
                writer.Write("<p>");
                writer.Write(ManualUtils.Wikify(desc));
                writer.Write("</p>");
            }
        }

        protected virtual void WriteOtherButtons(TextWriter writer, IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
        }

        private void WriteBuildButton(TextWriter writer, IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
            if (CanDoAction(planet, info)) {
                GenericRenderer.WriteRightLinkButton(writer,
                        ActionHref(planet, slot, info),
                        string.Format("{1}", info.Name, LanguageManager.Instance.Get(ActionString))
                    );
            } else {
                writer.Write(LanguageManager.Instance.Get("NotAvailableYet"));
            }
        }

        protected virtual string ActionString {
            get { return "Build"; }
        }

        protected virtual string ActionHref(IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
            return string.Format("javascript:Planet.startBuildFacility({1}, \"{2}\", \"{0}\");", info.Name, planet.Storage.Id, slot.Identifier);
        }

        protected virtual bool CanDoAction(IPlanet planet, IFacilityInfo info)
        {
            return info.IsBuildAvailable(planet).Ok;
        }

        private IFacilitySlot GetFacilitySlot(IPlanet planet)
        {
            string raw = HttpContext.Current.Request.QueryString["SlotName"];
            return planet.Info.GetSlot(raw);
        }

        #endregion Rendering

    };
}

