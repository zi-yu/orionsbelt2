using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class RegistedPlayers : ControlBase
    {
        private Core.Tournament tour;

        public Core.Tournament Tournament
        {
            get { return tour; }
            set { tour = value; }
        }

        #region Control Events

        protected override void  OnLoad(EventArgs e)
        {
            base.OnLoad(e);

 
            if (tour.TournamentType == "TotalAnnihalation" ||
                tour.TournamentType == "Regicide" ||
                tour.TournamentType == "Domination")
            {
                IList<Principal> prins= null;
                using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                {
                    prins = persistance.TypedQuery("select p from SpecializedPrincipalTournament pt inner join pt.PrincipalNHibernate p where pt.TournamentNHibernate.Id = {0} order by p.EloRanking desc", tour.Id);
                    if (tour.PaymentsRequired == 0 || prins.Count > 100 || Utils.Principal.IsInRole("financial"))
                    {
                        WritePots(prins);
                    }else
                    {
                        Write(string.Format("<div class='center'><img src='{0}' alt='Top Secret' title='Top Secret'/></div>", 
                            ResourcesManager.GetIntergalacticImage("TopSecretStamp.png")));
                        //Write("<div class='center'><h1 style='color:Red;'>Top Secret</h1>");
                    }
                }
            }else
            {
                IList<TeamStorage> teams = null;
                using (ITeamStoragePersistance persistance = Persistance.Instance.GetTeamStoragePersistance())
                {
                    teams = persistance.TypedQuery("select t from SpecializedPrincipalTournament pt inner join pt.TeamNHibernate t where pt.TournamentNHibernate.Id = {0} order by t.EloRanking desc", tour.Id);
                    WritePots(teams);
                }
            }
        }

        private string GetAvatar(Principal principal)
        {
            if (string.IsNullOrEmpty(principal.Avatar)) {
                return ResourcesManager.DefaultAvatar;
            }
            return principal.Avatar;
        }

        private void WritePots(IList<TeamStorage> teams)
        {
            int dez = teams.Count / 10;
            int uni = teams.Count % 10;
            int potNum = 0;
            int potPlayer = 0;
            for (int iter = 0; iter < teams.Count; ++iter)
            {
                if (0 == potPlayer)
                {
                    if (iter != 0)
                    {
                        Write("</ul>");
                    }

                    Write("<ul class='tourPot'>");
                    Write("<li class='tourPotTitle'>{0} {1}</li>", LanguageManager.Instance.Get("Pot"), (++potNum).ToString());
                    potPlayer = dez;
                    if (potNum <= uni)
                    {
                        ++potPlayer;
                    }
                }

                Write("<li ><img src='{3}' /><a href='{1}Tournaments/Team.aspx?TeamStorage={2}'>{0}</a><img src='{4}' /></li>", 
                    teams[iter].Name, WebUtilities.ApplicationPath, teams[iter].Id.ToString(),
                    GetAvatar(teams[iter].Principals[0]), GetAvatar(teams[iter].Principals[1]));
                --potPlayer;
            }
            Write("</ul>");
        }

        private void WritePots(IList<Principal> prins)
        {
            int dez = prins.Count / 10;
            int uni = prins.Count % 10;
            int potNum = 0;
            int potPlayer = 0;

            for (int iter = 0; iter < prins.Count; ++iter)
            {
                if (0 == potPlayer)
                {
                    if (iter != 0)
                    {
                        Write("</ul>");
                    }
                    Write("<ul class='tourPot'>");
                    Write("<li class='tourPotTitle'>{0} {1}</li>", LanguageManager.Instance.Get("Pot"), (++potNum).ToString());
                    potPlayer = dez;
                    if (potNum <= uni)
                    {
                        ++potPlayer;
                    }
                }
                Write("<li><img src='{3}' /><a href='{1}PrincipalInfo.aspx?Principal={2}'>{0}</a></li>", prins[iter].DisplayName, WebUtilities.ApplicationPath, prins[iter].Id.ToString(), GetAvatar(prins[iter]));
                --potPlayer;
            }
            Write("</ul>");
        }

        #endregion Control Events
    }
}
