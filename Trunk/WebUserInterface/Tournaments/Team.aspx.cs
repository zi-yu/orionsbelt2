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
using System.Web.UI.HtmlControls;
using OrionsBelt.WebUserInterface.Controls;
using OrionsBelt.WebUserInterface.Controls.Tournament;

namespace OrionsBelt.WebUserInterface {

    public class Team : Page 
    {
        protected CreateTeam create;
        protected InviteTeammate invite;
        protected ViewTeam view;

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string team = Request.QueryString["TeamStorage"];
            if (!string.IsNullOrEmpty(team))
            {
                create.Visible = false;
                invite.Visible = false;
            }
            else
            {
                if (Utils.Principal.Team != null)
                {
                    create.Visible = false;
                }
                else
                {
                    invite.Visible = false;
                    view.Visible = false;

                    if (!string.IsNullOrEmpty(Request.Form["ctl00$ctl00$Content$Content$create$create"]))
                    {
                        invite.Visible = true;
                    }

                    return;
                }

                if (Utils.Principal.Team.IsComplete)
                {
                    invite.Visible = false;
                }
                else
                {
                    view.Visible = false;
                }
            }

            
        }


    
    }
}
