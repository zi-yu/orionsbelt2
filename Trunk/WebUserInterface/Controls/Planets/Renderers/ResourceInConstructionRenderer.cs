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
using OrionsBelt.Generic;
using OrionsBelt.RulesCore.Common;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [NoAutoRegister]
	public abstract class FacilityInConstructionRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.FacilityInConstruction; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            IList<IPlanetResource> inProduction = planet.GetResourcesInProduction(CurrentResourceType);
            WriteInProduction(writer, planet, inProduction);

            IList<IPlanetResource> resources = planet.GetQueueList(CurrentResourceType);
            WriteQueue(writer, planet, resources);

        }

        private void WriteInProduction(TextWriter writer, IPlanet planet, IList<IPlanetResource> inProduction)
        {
            writer.Write("<h2>In Production</h2>");
            writer.Write("<ul>");
            foreach (IPlanetResource resource in inProduction) {
                writer.Write("<li>");
                WriteResource(writer, planet, resource);
                writer.Write("({0})",WebUtilities.GetFormattedTime(Clock.Instance.GetTimeLeft(resource.EndTick)));
                writer.Write(" <a href='javascript:Planet.cancel{2}Production({0}, {1});'>Cancel</a>", planet.Storage.Id, resource.Storage.Id, resource.Info.Type);
                writer.Write("</li>");
            }
            writer.Write("</ul>");
        }

        private void WriteQueue(TextWriter writer, IPlanet planet, IList<IPlanetResource> resources)
        {
            List<IPlanetResource> list = (List<IPlanetResource>)resources;
            list.Sort(delegate(IPlanetResource r1, IPlanetResource r2) { return r1.QueueOrder.CompareTo(r2.QueueOrder); });

            writer.Write("<h2>Queue</h2>");
            writer.Write("<ul>");
            foreach (IPlanetResource resource in resources) {
                writer.Write("<li>");
                WriteResource(writer, planet, resource);
                writer.Write(" <a href='javascript:Planet.cancel{2}Queue({0}, {1});'>Cancel</a>", planet.Storage.Id, resource.Storage.Id, resource.Info.Type);
                writer.Write("</li>");
            }
            writer.Write("</ul>");
        }

        private void WriteResource(TextWriter writer, IPlanet planet, IPlanetResource resource)
        {
            writer.Write(resource.Info.Name);
            writer.Write(" Quantity:{0}", resource.Quantity);
        }

        #endregion Rendering

    };
}

