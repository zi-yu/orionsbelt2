using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface.Planets
{
    public class PlanetsMaster : System.Web.UI.MasterPage {

        #region Fields

        protected Literal planetHeader;

        #endregion Fields

        #region Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            IPlayer player = PlayerUtils.Current;
            SetCurrentPlanet(player);
            SetTutorialContext();
        }

        private void SetTutorialContext()
        {
            string raw = string.Format("{0}Planets", Current.RaceInformation.Race);
            TutorialManager.Current = (Tutorial) Enum.Parse(typeof(Tutorial), raw);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            planetHeader.Text = string.Format("<a id='planetHeader' name='planetHeader' href='javascript:Planet.toHome({2});'>{0} - {1}</a>", Current.Name, Current.Location, Current.Storage.Id);
        }

        private void SetCurrentPlanet(IPlayer player)
        {
            string raw = HttpContext.Current.Request.QueryString["Id"];
            int id = int.Parse(raw);

            foreach (IPlanet planet in player.Planets) {
                if (planet.Storage.Id == id) {
                    Current = planet;
                    return;
                }
            }

            throw new UIException("Cant' find planet with id {0} on player {1}", id, player.Name);
        }

        #endregion Events

        #region Static

        public static IPlanet Current {
            get { return (IPlanet)State.GetItems("CurrentPlanet"); }
            set { State.SetItems("CurrentPlanet", value); }
        }

        #endregion Static
    }
}
