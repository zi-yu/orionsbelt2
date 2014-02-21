using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PirateBayControl : UserControl
    {
        protected ChooseOpponent finder;
        protected Button findPlanet, findFleet;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            findPlanet.Text = LanguageManager.Instance.Get("FindPlanets");
            findFleet.Text = LanguageManager.Instance.Get("FindFleets");
        }

        protected void FindPlanet(object sender, EventArgs e)
        {
            int servicePrice = 10;
            if (Utils.Principal.Credits < servicePrice)
            {
                ErrorBoard.AddLocalizedMessage("AdvertisingValidator");
                return;
            }

            int sysX = Convert.ToInt32(HttpContext.Current.Request.QueryString["sysX"]);
            int sysY = Convert.ToInt32(HttpContext.Current.Request.QueryString["sysY"]);
            SectorCoordinate sec = new SectorCoordinate(sysX,sysY,0,0);
            IList planets = PirateBayUtils.GetNoneDefendedPlanets(sec, servicePrice);

            if (planets.Count == 0)
            {
                InformationBoard.AddLocalizedMessage("NoPlanetFound");
                return;
            }
            else
            {
                WriteCoordinates(planets);
            }

        }

        protected void FindFleet(object sender, EventArgs e)
        {
            int servicePrice = 2;
            if (Utils.Principal.Credits < servicePrice)
            {
                ErrorBoard.AddLocalizedMessage("AdvertisingValidator");
                return;
            }

            int sysX = Convert.ToInt32(HttpContext.Current.Request.QueryString["sysX"]);
            int sysY = Convert.ToInt32(HttpContext.Current.Request.QueryString["sysY"]);
            SectorCoordinate sec = new SectorCoordinate(sysX, sysY, 0, 0);
            IList planets = PirateBayUtils.GetCargoFleets(sec, servicePrice);

            if (planets.Count == 0)
            {
                InformationBoard.AddLocalizedMessage("NoFleetFound");
                return;
            }
            else
            {
                WriteCoordinates(planets);
            }
        }

        private static void WriteCoordinates(ICollection infos)
        {
            
            TextWriter sb = new StringWriter();

            foreach (IList info in infos)
            {
                sb.Write("<p>{0}:{1}:{2}:{3} - {4} - {5} - {6} {7}</p>", info[0], info[1], info[2], info[3], info[4],
                                    LanguageManager.Instance.Get(info[5].ToString()), LanguageManager.Instance.Get("Level"), info[6]);
            }
            InformationBoard.AddMessage(sb.ToString());
        }
    }
}