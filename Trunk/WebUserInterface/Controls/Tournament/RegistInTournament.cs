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
using OrionsBelt.TournamentCore.Exceptions;
using OrionsBelt.WebComponents;
using System.Collections.Generic;
using OrionsBelt.Engine.Tournament;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class RegistInTournament : ControlBase
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
            Regist();
            WriteRegist();
        }

        private void Regist()
        {
            string toRegist = (string)(HttpContext.Current.Request.QueryString["Regist"]);
            int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);

            if (!string.IsNullOrEmpty(toRegist) &&
                toRegist.Contains("1"))
            {
                try
                {
                    TournamentManager.RegistPlayer(Utils.Principal, tourId);
                    InformationBoard.AddLocalizedMessage("SuccessRegisted");
                }
                catch (OrionsException)
                {
                    ErrorBoard.AddLocalizedMessage("NotEnoughtOrions");
                }
                catch(ELOException)
                {
                    ErrorBoard.AddLocalizedMessage("UnallowedElo");
                }
                catch (SoldOutException)
                {
                    ErrorBoard.AddLocalizedMessage("SoldOut");
                }
                catch (PaymentException ex)
                {
                    ErrorBoard.AddLocalizedMessage("NotEnoughtPayments", ex.Message);
                }
                catch (Exception)
                {
                    ErrorBoard.AddLocalizedMessage("YouCantRegist");
                }
                return;
            }

            if (!string.IsNullOrEmpty(toRegist) &&
                toRegist == "2")
            {
                try
                {
                    TournamentManager.RegistTeam(Utils.Principal.Team, tourId);
                }
                catch (ELOException)
                {
                    ErrorBoard.AddLocalizedMessage("UnallowedElo");
                }
                catch (Exception) { }
                return;
            }
        }

        private void WriteRegist()
        {
         
            if (tour.TournamentType == "TotalAnnihalation" ||
                tour.TournamentType == "Regicide" ||
                tour.TournamentType == "Domination")
            {
                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    IList<PrincipalTournament> regists = persistance.TypedQuery(
                        "select pt from SpecializedPrincipalTournament pt where pt.TournamentNHibernate.Id={0} and pt.PrincipalNHibernate.Id={1}",
                        tour.Id, Utils.Principal.Id);
                    
                    if (regists.Count != 0)
                    {
                        ErrorBoard.AddLocalizedMessage("AlreadyRegisted");
                    }
                    else
                    {
                        int tourId = Int32.Parse(HttpContext.Current.Request.QueryString["Tournament"]);
                        using (ITournamentPersistance persistance2 = Persistance.Instance.GetTournamentPersistance(persistance))
                        {
                            Core.Tournament t = persistance2.SelectById(tourId)[0];
                            if (t.MaxPlayers <= t.Regists.Count && 0 != t.MaxPlayers)
                            {
                                InformationBoard.AddLocalizedMessage("SoldOut");
                            }
                            else
                            {
                                Write(string.Format("<div class='button'><a href='{0}&Regist=1'>{1}</a></div>",HttpContext.Current.Request.RawUrl, LanguageManager.Instance.Get("TourRegist")));
                            }
                        }
                        
                    }
                }
            }else
            {
                if (null == Utils.Principal.Team)
                {
                    ErrorBoard.AddLocalizedMessage("NoTeam");
                    return;
                }

                using (IPrincipalTournamentPersistance persistance = Persistance.Instance.GetPrincipalTournamentPersistance())
                {
                    IList<PrincipalTournament> regists = persistance.TypedQuery(
                        "select pt from SpecializedPrincipalTournament pt where pt.TournamentNHibernate.Id={0} and pt.TeamNHibernate.Id={1}",
                        tour.Id, Utils.Principal.Team.Id);

                    if (regists.Count != 0)
                    {
                        InformationBoard.AddLocalizedMessage("AlreadyRegistedTeam");
                    }
                    else
                    {
                        Write(string.Format("<div class='button'><a href='{0}&Regist=2'>{1}</a></div>",
                                            HttpContext.Current.Request.RawUrl, LanguageManager.Instance.Get("TourRegist")));
                    }
                }
            }
        }

        #endregion Control Events
    }
}
