using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Planets {

    /// <summary>
    /// Renders Planet information
    /// </summary>
    [WebService(Namespace = "http://orionsbelt.eu/Ajax/Planets")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class Renderer : IHttpHandler {

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context){
            if (WebUtilities.HasBattles && WebUtilities.HasUniverseBattles) {
                context.Response.Output.WriteLine("HasBattles = {0};HasUnivereBattles ={1}", WebUtilities.HasBattles, WebUtilities.HasUniverseBattles);
                return;
            }else{
                context.Response.ContentType = "text/html";

                IPlanet planet = GetCurrentPlanet();
                PlanetRendererPanel panel = GetPanel(context);

                PlanetRenderer renderer = PlanetRenderer.Get(planet, panel);
                renderer.Render(context.Response.Output, planet);
            }
        }

        private IPlanet GetCurrentPlanet()
        {
            int id = EntityUtils.GetIdFromQueryString<PlanetStorage>("Planet");
            IPlayer player = PlayerUtils.Current;
            foreach (IPlanet planet in player.Planets) {
                if (planet.Storage.Id == id) {
                    return planet;
                }
            }

            throw new UIException("Can't find given planet on this player");
        }

        private PlanetRendererPanel GetPanel(HttpContext context)
        {
            string raw = context.Request.QueryString["Panel"];
            if (string.IsNullOrEmpty(raw)) {
                throw new UIException("No Panel provivided");
            }
            return (PlanetRendererPanel)Enum.Parse(typeof(PlanetRendererPanel), raw);
        }

		
        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

    };
}
