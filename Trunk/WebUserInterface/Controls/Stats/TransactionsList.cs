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
    public class TransactionsList : ControlBase
    {
        protected override void Render(HtmlTextWriter writer)
        {
            base.Render(writer);

            string id = HttpContext.Current.Request.QueryString["page"];
            int page=0;
            int elemPage = 50;
            Int32.TryParse(id, out page);
            

            IList list = Sql.Query(@"SELECT p.name,m1.id,sum(m1.gains) AS gains,sum(m1.spends) AS spends,(sum(m1.gains)-sum(m1.spends)) AS dif,p.credits FROM
                                      (SELECT * FROM
                                        (SELECT principalidspend AS id, sum(creditsspend)AS spends,0 AS gains FROM 
                                        Transaction t
                                        GROUP BY  principalidspend) AS t1
                                        UNION
                                        (SELECT identifiergain AS id, 0, sum(creditsgain)AS gains FROM 
                                        Transaction t
                                        WHERE identitytypegain='Principal'
                                        GROUP BY  identifiergain)
                                      )AS m1
                                    INNER JOIN principal AS p ON p.principalid=m1.id
                                    GROUP BY m1.id");

            int count = list.Count;
            double numberOfPages = Math.Ceiling((double)count / elemPage);

            WebUtilities.RenderPages(writer, numberOfPages);

            writer.Write("<table class='table'><tr><th>{0}</th><th>{1}</th><th>{2}</th><th>{3}</th><th>{4}</th><th>{5}</th></tr>",
                         LanguageManager.Instance.Get("Principal"),
                         LanguageManager.Instance.Get("Earnings"),
                         LanguageManager.Instance.Get("Spends"),
                         LanguageManager.Instance.Get("Difference"),
                         LanguageManager.Instance.Get("Orions"),
                         LanguageManager.Instance.Get("Alert"));

            for(int iter = page * elemPage; iter < list.Count && iter < (page+1)*elemPage; ++iter)
            {
                object[] data = (object[]) list[iter];
                string alert = Int32.Parse(data[5].ToString()) > Int32.Parse(data[4].ToString()) ? "x" : "";
                writer.Write(
                    "<tr><td><a href='PrincipalTransactions.aspx?Principal={5}'>{0}</a></td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td><td>{6}</td>",
                    data[0], data[2], data[3], data[4], data[5], data[1],alert);


            }
            writer.Write("</table>");
        }

    }
}
