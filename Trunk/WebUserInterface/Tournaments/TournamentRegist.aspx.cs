using System;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Controls;
using System.Web.UI.WebControls;
using OrionsBelt.Engine.Tournament;
using System.Threading;

namespace OrionsBelt.WebUserInterface {

    public class TournamentRegist : Page 
    {
        protected FleetRender fleetRender;
        protected RegistInTournament registration;
        protected RegistedPlayers registedPlayers;
        protected TournamentDescription description;
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
            fleetRender.Tournament = tour;
            registration.Tournament = tour;
            registedPlayers.Tournament = tour;
            description.Tournament = tour;

            
        }

        protected void StartClick( object sender, EventArgs e )
        {
            ThreadPool.QueueUserWorkItem(ThreadProc, Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]));
        }

        static void ThreadProc(Object stateInfo)
        {
            TournamentManager.BeginTournament((int)stateInfo);
        }

    }
}
