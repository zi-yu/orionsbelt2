using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.RulesCore.Common;
using OrionsBelt.RulesCore.Interfaces;
using OrionsBelt.TournamentCore.TournamentCreators;
using OrionsBelt.WebComponents;
using System;
using OrionsBelt.WebComponents.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using Loki.DataRepresentation;
using System.Web.Security;
using System.IO;
using OrionsBelt.WebUserInterface.Controls;

namespace OrionsBelt.WebUserInterface {

    public class TournamentViewer : Page 
    {
        protected FleetRender fleetRender;
        protected Literal tName;

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);

            Tournament tour = (Tournament)Page.Cache["tournament" + tourId];
            if (null == tour)
            {
                using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
                {
                    tour = persistance.SelectById(tourId)[0];
                    Page.Cache.Insert("tournament" + tourId, tour);
                }
            }
            if(tour.IsCustom)
            {
                tName.Text = tour.Name;
            }
            else
            {
                tName.Text = string.Format("{0} {1}", LanguageManager.Instance.Get(tour.Token), tour.TokenNumber);
            }
            fleetRender.Tournament = tour;
        }
    }
}
