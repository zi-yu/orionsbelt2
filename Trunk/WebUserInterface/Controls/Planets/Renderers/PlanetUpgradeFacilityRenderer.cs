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

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("UpgradeFacility")]
	public class PlanetUpgradeFacilityRenderer : PlanetBuildFacilityRenderer  {

        #region Fields

        private IPlanetResource pResource;

        public IPlanetResource PlanetResource {
            get { return pResource; }
            set { pResource = value; }
        }

        #endregion Fields

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.UpgradeFacility; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            int id = CurrentResourceId;
            PlanetResource = ResourceUtils.GetResource(planet, id);

            writer.Write("<ul>");
            writer.Write("<li>");
            WriteFacilitySlot(writer, planet, null, (IFacilityInfo)PlanetResource.Info);
            writer.Write("</li>");
            writer.Write("</ul>");
        }

        private void WriteUpgrade(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }

        private void WriteUpgradeOld(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            writer.Write("<a href='javascript:Planet.upgradeFacility({2},\"{3}\");'>Upgrade {0} to level {1}</a>", resource.Info.Name, resource.Level + 1, planet.Storage.Id, resource.Slot.Identifier);
            writer.Write("<p/>");
            writer.Write("<a href='javascript:Planet.destroyFacility({2},\"{3}\");'>Destroy {0}</a>", resource.Info.Name, resource.Level + 1, planet.Storage.Id, resource.Slot.Identifier);
        }

        #endregion Rendering

        #region Base Implementation

        protected override int TargetLevel {
            get { return PlanetResource.Level + 1;  }
        }

        protected override string ActionString {
            get { return "Upgrade"; }
        }

        protected override string ActionHref(IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
            return string.Format("javascript:Planet.upgradeFacility({2},\"{3}\");", PlanetResource.Info.Name, PlanetResource.Level + 1, planet.Storage.Id, PlanetResource.Slot.Identifier);
        }

        protected override bool CanDoAction(IPlanet planet, IFacilityInfo info)
        {
            return true;
        }

        protected override void WriteHeader(TextWriter writer, IFacilityInfo info)
        {
            writer.Write("<h4>{3} {0} {1} {2}</h4>", 
                    LanguageManager.Instance.Get(info.Name), 
                    LanguageManager.Instance.Get("Level"), 
                    TargetLevel,
                    LanguageManager.Instance.Get("UpgradeTo")
                );
        }

        protected override void WriteOtherButtons(TextWriter writer, IPlanet planet, IFacilitySlot slot, IFacilityInfo info)
        {
            if (planet.IsDestroyAvailable(PlanetResource).Ok)   {
                GenericRenderer.WriteRightLinkButton(writer,
                        string.Format("javascript:Planet.destroyFacility({0},\"{1}\");", planet.Storage.Id, PlanetResource.Slot.Identifier),
                        string.Format("{1}", info.Name, LanguageManager.Instance.Get("Destroy"))
                    );
            }
        }

        #endregion Base Implementation

    };
}


