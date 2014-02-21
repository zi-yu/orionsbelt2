using System;
using System.Web.Security;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using Language.Core;
using Language.DataAccessLayer;
using System.IO;

namespace Language.WebUserInterface {
    public partial class Top : System.Web.UI.Page {

        #region Events

        protected Literal content;
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            IList<Principal> principals = Hql.StatelessQuery<Principal>("select p from SpecializedPrincipal p where p.RawRoles not like '%admin%' order by p.OrionsReward desc");
            TextWriter writer = new StringWriter();

            writer.Write("<table class='table'>");
            writer.Write("<tr>");
            writer.Write("<th>Name</th>" );
            writer.Write("<th>Language</th>");
            writer.Write("<th>Reward</th>");
            writer.Write("<tr>");

            foreach (Principal principal in principals) {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", principal.Name);
                writer.Write("<td><img src='http://resources.orionsbelt.eu/Images/Common/Flags/{0}.gif' alt='{0}' title='{0}' /></td>", GetLocale(principal));
                writer.Write("<td>{0} Orions</td>", principal.OrionsReward);
                writer.Write("</tr>");
            }

            writer.Write("</table>");

            content.Text = writer.ToString();
        }

        private string GetLocale(Principal principal)
        {
            foreach (Locale locale in ProjectFile.GetLocales()) {
                if (principal.IsInRole(locale.Name)) {
                    return locale.Name;
                }
            }
            return "en";
        }

        #endregion Events

    };
}
