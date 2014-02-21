using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Web.UI.WebControls;
using System.Text;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {
    public class QuestsStats : Page
    {

        #region Fields

        protected Literal tables;

        #endregion Fields

        #region Events

        protected override void OnInit( EventArgs e ) 
        {
            StringBuilder sb = new StringBuilder();

            IList completed = Sql.StatelessQuery("SELECT e.Type,COUNT(*) FROM QuestStorage AS e WHERE e.Completed=1 GROUP BY e.Type ORDER BY COUNT(*) DESC");
            IList running = Sql.StatelessQuery("SELECT e.Type,COUNT(*) FROM QuestStorage AS e WHERE e.Completed=0 GROUP BY e.Type ORDER BY COUNT(*) DESC");

            sb.Append(string.Format("<h2>{0}</h2><table class='table'><tbody><tr><th>{1}</th><th>{2}</th></tr>",
                      LanguageManager.Instance.Get("Running"),
                      LanguageManager.Instance.Get("Quest"),
                      LanguageManager.Instance.Get("Count")));

            foreach (object[] elem in running)
            {
                sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td></tr>",
                      elem[0],
                      elem[1]));
            }

            sb.Append(string.Format("</tbody></table><h2>{0}</h2><table class='table'><tbody><tr><th>{1}</th><th>{2}</th></tr>",
                      LanguageManager.Instance.Get("Completed"),
                      LanguageManager.Instance.Get("Quest"),
                      LanguageManager.Instance.Get("Count")));

            foreach (object[] elem in completed)
            {
                sb.Append(string.Format("<tr><td>{0}</td><td>{1}</td></tr>",
                      elem[0],
                      elem[1]));
            }

            sb.Append(string.Format("</tbody></table>"));

            tables.Text = sb.ToString();
        }

	    #endregion Events

        

    };
}

