using System;
using System.Collections;
using System.IO;
using System.Web;
using System.Web.UI;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PaymentsPerPrincipal : ControlBase
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            string id = HttpContext.Current.Request.QueryString["page"];
            int page=0;
            int elemPage = 50;
            Int32.TryParse(id, out page);


            IList list = Sql.Query(@"SELECT p.Principalid,p.Name,SUM(t.CreditsGain),COUNT(Name) FROM Transaction AS t
                                    INNER JOIN Principal AS p ON t.IdentifierGain=p.Principalid
                                    WHERE t.TransactionContext='Payment'
                                    GROUP BY p.PrincipalId
                                    ORDER BY COUNT(name) DESC");

            int count = list.Count;
            double numberOfPages = Math.Ceiling((double)count / elemPage);

            WebUtilities.RenderPages(writer, numberOfPages);

            writer.Write("<table class='table'><tr><th>{0}</th><th>{1}</th><th>{2}</th></tr>",
                         LanguageManager.Instance.Get("Principal"),
                         LanguageManager.Instance.Get("Orions"),
                         LanguageManager.Instance.Get("Payments"));

            for(int iter = page * elemPage; iter < list.Count && iter < (page+1)*elemPage; ++iter)
            {
                object[] data = (object[]) list[iter];
                writer.Write(
                    "<tr><td><a href='{0}PrincipalInfo.aspx?Principal={1}'>{2}</a></td><td>{3}</td><td>{4}</td></tr>",
                    WebUtilities.ApplicationPath, data[0], data[1], data[2], data[3]);


            }
            writer.Write("</table>");
        }

    }
}
