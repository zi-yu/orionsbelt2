using System;
using System.Collections.Generic;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.MarketPlace;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.WebComponents;
using OrionsBelt.Engine;
using System.Text;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class AcademyControl : UserControl
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
            int servicePrice = 15;
            if (Utils.Principal.Credits < servicePrice)
            {
                ErrorBoard.AddLocalizedMessage("AdvertisingValidator");
                return;
            }
            if (0 != finder.GetSelectedPlayerId())
            {
                IList<SectorCoordinate> coordinates = AcademyUtils.GetPiratePlanets(finder.GetSelectedPlayerId());
                WriteCoordinates(coordinates);

                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    persistance.StartTransaction();
                    Utils.Principal.Credits -= servicePrice;
                    persistance.Update(Utils.Principal);
                    TransactionManager.AcademyTransaction(PlayerUtils.Current,servicePrice, finder.GetSelectedPlayerId(), persistance);
                    persistance.CommitTransaction();
                }
            }
            else
            {
                ErrorBoard.AddLocalizedMessage("InvalidPlayer");
            }
        }

        protected void FindFleet(object sender, EventArgs e)
        {
            int servicePrice = 5;
            if (Utils.Principal.Credits < servicePrice)
            {
                ErrorBoard.AddLocalizedMessage("AdvertisingValidator");
                return;
            }
            if (0 != finder.GetSelectedPlayerId())
            {
                IList<SectorCoordinate> coordinates = AcademyUtils.GetPirateFleets(finder.GetSelectedPlayerId());
                WriteCoordinates(coordinates);

                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    persistance.StartTransaction();
                    Utils.Principal.Credits -= servicePrice;
                    persistance.Update(Utils.Principal);
                    TransactionManager.AcademyTransaction(PlayerUtils.Current, servicePrice, finder.GetSelectedPlayerId(), persistance);
                    persistance.CommitTransaction();
                }
            }
            else
            {
                ErrorBoard.AddLocalizedMessage("InvalidPlayer");
            }
        }

        private static void WriteCoordinates(ICollection<SectorCoordinate> coordinates)
        {
            if(coordinates.Count == 0)
            {
                InformationBoard.AddLocalizedMessage("PlayerHaveNone");
                return;
            }
            TextWriter sb = new StringWriter();

            foreach (SectorCoordinate coordinate in coordinates)
            {
                sb.Write("<p>{0}</p>",coordinate);
            }
            InformationBoard.AddMessage(sb.ToString());
        }

        
    }
}