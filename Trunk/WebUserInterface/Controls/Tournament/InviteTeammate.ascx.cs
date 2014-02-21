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
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Common;
using OrionsBelt.WebComponents;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Controls.Tournament
{
    public partial class InviteTeammate : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            invite.Text = LanguageManager.Instance.Get("Invite");
            //delete.Text = LanguageManager.Instance.Get("Delete");
            if (Utils.Principal.Team != null)
            {
                title.Text = string.Format(Resources.InviteToToken, Utils.Principal.Team.Name);
            }

            if (!string.IsNullOrEmpty(Request.Form["ctl00$ctl00$Content$Content$create$create"]))
            {
                title.Text = string.Format(Resources.InviteToToken, Request.Form["ctl00$ctl00$Content$Content$create$name"]);
            }

            list.Where = string.Format("e.Type='TeamInvitation' and e.Source={0}",Utils.Principal.Id);
        }

        protected void Invite(object sender, EventArgs e)
        {
            int id = targetChoice.GetSelectedPlayerId();
            if (id == 0 || id == Utils.Principal.Id)
            {
                ErrorBoard.AddLocalizedMessage("SamePrincipal");
                return;
            }
            IList<Principal> returns = GetPrincipals(id);

            if(returns == null)
            {
                return;
            }

            if (null != returns[0].Team)
            {
                ErrorBoard.AddLocalizedMessage("HaveTeam");
                return;
            }

            using (IInteractionPersistance persistance = Persistance.Instance.GetInteractionPersistance())
            {
                Interaction interaction = persistance.Create();
                RulesCore.Interfaces.IInteractionType type = InteractionType.Get("TeamInvitation");
                type.Prepare(interaction, Utils.Principal, returns[0]);
                persistance.Update(interaction);
                
                list.Collection = persistance.TypedQuery(string.Format("{0} where {1}",list.Select,list.Where));
                list.Collection.Add(interaction);
            }
            InformationBoard.AddLocalizedMessage("SucessOperation");

            
        }

        private static IList<Principal> GetPrincipals(int id)
        {
            using (IPrincipalPersistance persistance = Persistance.Instance.GetPrincipalPersistance())
            {
                IList<Principal> p = persistance.SelectById(id);
                if (p.Count > 0)
                {
                    p.Add(Utils.Principal);
                    return p;
                }
            }
            ErrorBoard.AddLocalizedMessage("InvalidName");
            return null;
            //throw new OrionsBeltException("InvalidName");
        }
    }
}