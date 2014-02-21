using System.IO;
using DesignPatterns.Attributes;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls {

    /// <summary>
    /// Renders something of a planet
    /// </summary>
    [FactoryKey("Manage")]
	public class PlanetManageRenderer : PlanetRenderer  {

        #region Rendering

        protected override PlanetRendererPanel Panel {
            get { return PlanetRendererPanel.Manage; }
        }

        protected override void RenderPlanetPanel(TextWriter writer, IPlanet planet)
        {
            WriteChangeName(writer, planet);
            WriteAbandonPlanet(writer, planet);
        }

        private static void WriteChangeName(TextWriter writer, IPlanet planet)
        {
            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("ChangeName"));
            writer.Write("<div class='panelPlaceHolder'>");
            writer.Write("<input type='text' value='{0}' size='20' maxlength='15' name='newPlanetName' id='newPlanetName' />", planet.Name);
            writer.Write("<a href='javascript:Planet.changeName({1});'>{0}</a>",
                    LanguageManager.Instance.Get("ChangeName"),
                    planet.Storage.Id
                );
            writer.Write("</div>");
        }

        private static void WriteAbandonPlanet(TextWriter writer, IPlanet planet)
        {
#if !DEBUG
            if (!planet.Info.MayAbandonPlanet) {
                return;
            }
#endif
            writer.Write("<h3>{0}</h3>", LanguageManager.Instance.Get("AbandonPlanet"));
            writer.Write("<div class='panelPlaceHolder'>");
            writer.Write("<a href='javascript:Planet.abandonPlanet({1});'>{0}</a>",
                    LanguageManager.Instance.Get("AbandonPlanet"),
                    planet.Storage.Id
                );
            writer.Write("</div>");
        }

        #endregion Rendering

    };
}

