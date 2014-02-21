using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;
using System.IO;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Controls
{
    public class PrincipalExtract : ControlBase
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);
            /*
            string id = HttpContext.Current.Request.QueryString["page"];
            int page=0;
            int elemPage = 50;
            Int32.TryParse(id, out page);


            IList list = Sql.Query(@"SELECT p.Principalid,p.Name,p.Credits,COUNT(Name) FROM Transaction AS t
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
            */

            IList<Transaction> list = Hql.StatelessQuery<Transaction>("select e from SpecializedTransaction e where e.PrincipalIdSpend=:principal or (e.IdentifierGain=:principal and e.IdentityTypeGain='Principal') order by e.CreatedDate",
                Hql.Param("principal", Utils.Principal.Id));


            StringWriter content = new StringWriter();
            content.Write("<table class='newtable'><tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th></tr>",
                         LanguageManager.Instance.Get("Date"),
                         LanguageManager.Instance.Get("Description"),
                         LanguageManager.Instance.Get("Spent"),
                         LanguageManager.Instance.Get("Gain"),
                         LanguageManager.Instance.Get("Balance"));

            int balance = 0;
            foreach (Transaction transaction in list)
            {
                string input, output;
                if(transaction.PrincipalIdSpend == Utils.Principal.Id)
                {
                    balance -= transaction.CreditsSpend;
                    output = transaction.CreditsSpend.ToString();
                    input = string.Empty;
                }
                else
                {
                    balance += transaction.CreditsGain;
                    input = transaction.CreditsGain.ToString();
                    output = string.Empty;
                }
                content.Write("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                             transaction.CreatedDate, LanguageManager.Instance.Get(transaction.TransactionContext), output, input, balance);
            }
            content.Write("</table>");

            string title = string.Format("<h2>{0}</h2>", LanguageManager.Localize("Extract"));

            Border.RenderBig("extractTable",writer, title, content.ToString());
        }

    }
}
