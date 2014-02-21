using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls.Tournament
{
    public partial class ViewTeam : UserControl
    {

        #region Private

        private static bool HasTournaments(int id) {
            IList<PrincipalTournament> list = Hql.Query<PrincipalTournament>("select pt from SpecializedPrincipalTournament pt where pt.TeamNHibernate.Id = :id and pt.HasEliminated = 0", Hql.GetParams(Hql.Param("id", id)));
            foreach (PrincipalTournament t in list) {
                if (t.EliminatedInFase != "Winner") {
                    return true;
                }
            }
            return false;
        }

        private static string GetAbandonURL() {
            if (HttpContext.Current.Request.RawUrl.EndsWith("aspx")) {
                return string.Format("{0}?Abandon=1", HttpContext.Current.Request.RawUrl);
            }
            return string.Format("{0}&Abandon=1", HttpContext.Current.Request.RawUrl);
        }

        #endregion Private

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            string team = Request.QueryString["TeamStorage"];

            if (!string.IsNullOrEmpty(team))
            {
                TeamStorage t = EntityUtils.GetFromQueryString<TeamStorage>();
                WriteInfo(t);
                return;
            }
            
            if (Utils.Principal.Team != null)
            {
                title.Text =
                    string.Format("{0}: {1}", LanguageManager.Instance.Get("Team"), Utils.Principal.Team.Name);

                string abandom = HttpContext.Current.Request.QueryString["Abandon"];

                TeamStorage t = Utils.Principal.Team;
                WriteInfo(t);
                if (!string.IsNullOrEmpty(abandom) && abandom == "1")
                {
                    if (HasTournaments(t.Id)) {
                        ErrorBoard.AddLocalizedMessage("PlayingInTournaments");
                        return;
                    }


                    using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
                    {
                        persistance.StartTransaction();
                        Utils.Principal.Team = null;
                        persistance.Update(Utils.Principal);

                        using (ITeamStoragePersistance persistance2 = Persistance.Instance.GetTeamStoragePersistance(persistance))
                        {
                            t.IsComplete = false;
                            persistance2.Update(t);
                        }

                        persistance.CommitTransaction();

                        Messenger.Add(Category.Principal, typeof(YouAbandom), Utils.Principal.Id,
                        t.Name);
                        
                        if(t.Principals.Count > 1)
                        {
                            foreach (Principal principal in t.Principals)
                            {
                                if(principal.Id != Utils.Principal.Id)
                                {
                                    Messenger.Add(Category.Principal, typeof(TeamAbandom), principal.Id, Utils.Principal.DisplayName);
                                }
                            }                        
                        }
                        else
                        {
                            using (IPrincipalStatsPersistance persistance2 = Persistance.Instance.GetPrincipalStatsPersistance(persistance))
                            {
                                persistance2.Delete(t.MyStatsId);
                            }
                            using (ITeamStoragePersistance persistance2 = Persistance.Instance.GetTeamStoragePersistance(persistance))
                            {
                                persistance2.Delete(t);
                            }
                        }
                        persistance.Flush();
                        Response.Redirect("~/Default.aspx", true);
                    }
                    
                   
                    IList<Principal> prins = t.Principals;
                    reader.Team = t;
                    WriteMembers(prins);
                    eloStats.CurrTeam = t;
                    
                }
            }
        }

        private void WriteInfo(TeamStorage t)
        {
            reader.Team = t;
            title.Text = string.Format("{0}: {1}", LanguageManager.Instance.Get("Team"), t.Name);

            IList<Principal> prins = t.Principals;

            WriteMembers(prins);

            eloStats.CurrTeam = t;
        }

        private void WriteMembers(IEnumerable<Principal> prins)
        {
            TextWriter tw = new StringWriter();
            tw.Write("<table class='newtable'><tr><th colspan=2>{0}</th><tr>",
                     LanguageManager.Instance.Get("Members"));
            foreach (Principal prin in prins)
            {
                tw.Write("<td>");
                tw.Write(WebUtilities.WritePrincipalWithAvatar(prin));
                if(prin.Id == Utils.Principal.Id){
                    abandon.Text = string.Format("<div class='button'><a href='{0}'>{1}</a></div>", GetAbandonURL(), LanguageManager.Instance.Get("Abandom"));
                }
                tw.Write("</td>");
            }
            tw.Write("</tr></table>");
            players.Text = tw.ToString();

            
        }

        
    }
}