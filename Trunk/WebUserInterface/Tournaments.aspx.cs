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
using OrionsBelt.WebUserInterface.Controls.Tournament;

namespace OrionsBelt.WebUserInterface {

    public class Tournaments : Page 
    {
        protected TournamentPagedList registedTournaments;
        protected CurrentBattles currentBattles;
        protected XLPartyTournaments xl;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if(Utils.Principal.IsInRole("financial") || Utils.Principal.ReferrerId == -999)
            {
                xl.Visible = true;
            }
            else
            {
                xl.Visible = false;
            }

            using (ITournamentPersistance persistance = Persistance.Instance.GetTournamentPersistance())
            {
                string team = string.Empty;
                if(null != Utils.Principal.Team)
                {
                    team = string.Format("or pt.TeamNHibernate.Id={0}", Utils.Principal.Team.Id);
                }

                //registedTournaments.Collection = persistance.TypedQuery("select t from SpecializedPrincipalTournament pt inner join pt.TournamentNHibernate t where (pt.PrincipalNHibernate.Id={0} {1}) and t.CreatedDate <> t.StartTime and t.CreatedDate = t.EndDate", Utils.Principal.Id, team);
                //registedTournaments.Collection = persistance.TypedQuery("select distinct t from SpecializedTournament t inner join fetch t.RegistsNHibernate r where t.CreatedDate <> t.StartTime order by t.CreatedDate desc", Utils.Principal.Id, team);
                string[] hql = new string[2];
                hql[0] = string.Format("select distinct t from SpecializedTournament t inner join fetch t.RegistsNHibernate r order by t.CreatedDate desc");
                hql[1] = string.Format("select p from SpecializedPrincipal p inner join fetch p.TournamentsNHibernate");
                persistance.MultiQuery(hql, new Dictionary<string, object>()); 


            }

        }
    }
}
