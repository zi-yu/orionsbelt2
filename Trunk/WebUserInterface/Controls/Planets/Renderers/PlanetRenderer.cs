using System.Web;
using System.Web.UI;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.Engine;
using OrionsBelt.WebUserInterface.Planets;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using DesignPatterns;
using OrionsBelt.RulesCore;
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;
using OrionsBelt.Engine.Resources;
using OrionsBelt.RulesCore.Races;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
	public abstract class PlanetRenderer : PlanetActions, IFactory  {

        #region To Implement

        protected abstract void RenderPlanetPanel(TextWriter writer, IPlanet planet);

        protected abstract PlanetRendererPanel Panel { get;}

        #endregion To Implement

        #region Methods

        public void Render(TextWriter writer, IPlanet planet)
        {
            CurrentPlanet = planet;
            if (CheckActions(writer, planet, Panel)) {
                WriteRedirectToHome(writer);
                return;
            }
            ShowMessage(writer);

            writer.Write("<div class='headerPanel' id='tutRef'>");
            writer.Write("<h3>");
            writer.Write(LanguageManager.Instance.Get(Panel.ToString()));
            writer.Write("</h3>");
            WriteMenu(writer, planet);
            writer.Write("</div>");

            writer.Write("<div id='{0}_{1}' class='{2}'>", GetPlanetIdentifier(planet), Panel, GetPanelCssClass(planet));
            RenderPlanetPanel(writer, planet);
            writer.Write("</div>");
			WriteResources(writer, planet);
        }

        protected virtual string GetPanelCssClass(IPlanet planet)
        {
            return string.Empty;
        }

        private static string GetPlanetIdentifier(IPlanet planet)
        {
            if (planet.Info.RaceInformation != null) {
                return planet.Info.Identifier;
            }
            return string.Format("{0}_{1}", planet.Info.Identifier, planet.Terrain.Terrain);
        }

        public void WriteResources(TextWriter writer, IPlanet planet)
        {
            writer.WriteLine();
            writer.Write("<script type='text/javascript'>");
            writer.Write("window.resourceList = {currOrions:");
            writer.Write(planet.Owner.Principal.Credits);
            writer.Write(",ProductionFactor:'{0}'", planet.FinalProductionFactor);
            writer.Write(",Capacity:{0}", planet.Owner.GetLimit(null));
            writer.Write(",QueueSpace:{0}", planet.Owner.GetQuantity(QueueSpace.Resource));
            foreach (IResourceInfo info in RulesUtils.GetInstrinsicResources(planet.Owner))  {
                writer.Write(",");
                writer.Write(info.Name);
                writer.Write(":");
                writer.Write(planet.Owner.GetQuantity(info));
                writer.Write(",");
                writer.Write(info.Name);
                writer.Write("Mod:");
                writer.Write(planet.GetPerTick(info));
            }
            writer.Write("};");
            writer.Write("window.planetInfo={");
            writer.Write("PlanetName:\"{0}\",PlanetId:{1},PlanetLocation:\"{2}\"", planet.Name, planet.Storage.Id, planet.Location);
            writer.Write("};");
            writer.Write("window.tutorialEnabled={0};", IsTutorialEnabled(planet).ToString().ToLower());
            writer.Write("</script>");
        }

        private bool IsTutorialEnabled(IPlanet planet)
        {
            return !planet.Info.HotZone && CurrentPanel == PlanetRendererPanel.Facilities;
        }

        private void WriteRedirectToHome(TextWriter writer)
        {
            writer.WriteLine();
            writer.Write("<script type='text/javascript'>");
            writer.Write("window.redirectToPlanet={0};", PlayerUtils.Current.HomePlanetId);
            writer.Write("</script>");
        }

        private void WriteMenu(TextWriter writer, IPlanet planet)
        {
            writer.Write("<ul>");
            writer.Write("<li><a href='javascript:Planet.toHome({0});'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("PlanetHome"));
            writer.Write("<li><a href='javascript:Planet.getQueue({0});'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("Queue"));
            if (ResourceUtils.CanBuildUnits(planet))  {
                writer.Write("<li><a href='javascript:Planet.toUnits({0});'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("Units"));
            }
            writer.Write("<li><a href='javascript:Planet.toFleets({0});'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("Fleets"));
            writer.Write("<li><a href='javascript:Planet.toPanel({0},\"Manage\");'>{1}</a></li>", planet.Storage.Id, LanguageManager.Instance.Get("Manage"));
            WriteNavOptions(writer, planet);
            writer.Write("</ul>");
        }

        private void WriteNavOptions(TextWriter writer, IPlanet planet)
        {
            KeyValuePair<IPlanet, IPlanet> pair = GetPreviousAndNext(planet);

            if (pair.Key == null) {
                writer.Write("<li>«</li>");
            } else {
                writer.Write("<li><a href='javascript:Planet.toPanel({0},\"{1}\");'>«</a></li>", pair.Key.Storage.Id, GetCurrNavPanel());
            }
            
            if (pair.Value == null) {
                writer.Write("<li>»</li>");
            } else {
                writer.Write("<li><a href='javascript:Planet.toPanel({0},\"{1}\");'>»</a></li>", pair.Value.Storage.Id, GetCurrNavPanel());
            }
        }

        private PlanetRendererPanel GetCurrNavPanel()
        {
            switch (Panel) { 
                case PlanetRendererPanel.Units:
                case PlanetRendererPanel.Queue:
                case PlanetRendererPanel.Fleets:
                case PlanetRendererPanel.Manage:
                    return Panel;
                default:
                    return PlanetRendererPanel.Facilities;
            }
        }

        private static KeyValuePair<IPlanet, IPlanet> GetPreviousAndNext(IPlanet planet)
        {
            IPlanet previous = null;
            IPlanet next = null;

            for (int i = 0; i < planet.Owner.Planets.Count; ++i ) {
                if (i > 0) {
                    previous = planet.Owner.Planets[i - 1];
                } else {
                    previous = null;
                }
                if (i < planet.Owner.Planets.Count - 1) {
                    next = planet.Owner.Planets[i + 1];
                } else {
                    next = null;
                }
                IPlanet curr = planet.Owner.Planets[i];
                if (curr.Storage.Id == planet.Storage.Id) {
                    return new KeyValuePair<IPlanet, IPlanet>(previous, next);
                }
            }

            return new KeyValuePair<IPlanet, IPlanet>(previous, next);
        }

        #endregion Methods

        #region Static

        public static PlanetRenderer Get(IPlanet planet, PlanetRendererPanel panel)
        {
            return Get(planet.Info, panel);
        }

        public static PlanetRenderer Get(IPlanetInfo info, PlanetRendererPanel panel)
        {
            return Get(info.Identifier, panel);
        }

        public static PlanetRenderer Get(string name, PlanetRendererPanel panel)
        {
            string key = string.Format("{0}{1}", name, panel);
            if( factories.ContainsKey(key)) {
                return (PlanetRenderer)factories.create(key);
            }
            return (PlanetRenderer)factories.create(panel.ToString());
        }

        private static FactoryContainer factories = new FactoryContainer(typeof(PlanetRenderer));

        #endregion Static

        #region IFactory Members

        public object create(object args)
        {
            return this;
        }

        #endregion

        #region Utils

        protected void WriterCost(TextWriter writer, IPlanet planet, IResourceWithRulesInfo info, int level)
        {
            writer.Write("<p>");

            GenericRenderer.RenderResourceQuantityList(writer, RulesUtils.GetCost(info, planet.Owner, level));

            writer.Write("</p>");
        }

        #endregion Utils

        #region Queues

        protected bool WriteProductionQueue(TextWriter writer, IPlanet planet, ResourceType resourceType)
        {
            bool b1 = WriteProduction(writer, planet, resourceType);
            bool b2 = WriteQueue(writer, planet, resourceType);

            return b1 || b2;
        }

        private bool WriteProduction(TextWriter writer, IPlanet planet, ResourceType resourceType)
        {
            List<IPlanetResource> list = (List<IPlanetResource>)planet.GetResourcesInProduction(resourceType);
            if (list.Count == 0) {
                return false;
            }

            writer.Write("<h4>{0}</h4>", LanguageManager.Instance.Get("InProduction"));

            writer.Write("<ul>");
            foreach (IPlanetResource resource in list) {
                writer.Write("<li>");
                WriteResource(writer, planet, resource);
                writer.Write(" <a href='javascript:Planet.cancel{2}Production({0}, {1});'>Cancel</a>", planet.Storage.Id, resource.Storage.Id, resource.Info.Type);
                writer.Write("</li>");
            }
            writer.Write("</ul>");

            return true;
        }

        protected bool WriteQueue(TextWriter writer, IPlanet planet, ResourceType resourceType)
        {
            List<IPlanetResource> list = (List<IPlanetResource>)planet.GetQueueList(resourceType);
            if (list.Count == 0) {
                return false;
            }
            list.Sort(delegate(IPlanetResource r1, IPlanetResource r2) { return r1.QueueOrder.CompareTo(r2.QueueOrder); });

            writer.Write("<h4>{0}</h4>", LanguageManager.Instance.Get("InQueue"));
            writer.Write("<ul>");
            foreach (IPlanetResource resource in list) {
                writer.Write("<li>");
                WriteResource(writer, planet, resource);
                writer.Write(" <a href='javascript:Planet.cancel{2}Queue({0}, {1});'>{3}</a>", planet.Storage.Id, resource.Storage.Id, resource.Info.Type, LanguageManager.Instance.Get("Cancel"));
                writer.Write("</li>");
            }
            writer.Write("</ul>");

            return true;
        }

        private void WriteResource(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            if (resource.Info.Type == ResourceType.Facility) {
                WriteFacility(writer, planet, resource);
            } else {
                WriteUnit(writer, planet, resource);
            }
        }

        private void WriteUnit(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            writer.Write(LanguageManager.Instance.Get(resource.Info.Name));
            writer.Write(" - {0}:{1} ", LanguageManager.Instance.Get("Quantity"), resource.Quantity);
            if (resource.State == ResourceState.InConstruction) {
                writer.Write(" - {0} ", WebUtilities.GetFormattedTime(Clock.Instance.GetTimeLeft(resource.EndTick)));
            }
        }

        private void WriteFacility(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            writer.Write(LanguageManager.Instance.Get(resource.Info.Name));
            writer.Write(" - {0}:{1} ", LanguageManager.Instance.Get("Level"), resource.Level);
            if (resource.State == ResourceState.InConstruction) {
                writer.Write(" - {0} ", WebUtilities.GetFormattedTime(Clock.Instance.GetTimeLeft(resource.EndTick)));
            }
        }

        #endregion Queues

    };
}


