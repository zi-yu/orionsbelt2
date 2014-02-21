using System;
using System.Web.UI;
using System.IO;
using System.Collections;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;
using System.Web.UI.WebControls;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface {

	public class AlliancePage: Page {

        #region Fields

        protected Literal allianceRank;

        #endregion Fields

        #region Events

        protected override void Render(HtmlTextWriter writer)
        {
            string hql = GetHql();

            using(IPersistanceSession session = Persistance.Instance.GetGenericPersistance()){
                IList list = session.Query(hql);
                allianceRank.Text = GetListHtml(list);
            }

            base.Render(writer);
        }

        private string GetListHtml(IList list)
        {
            TextWriter writer = new StringWriter();

            int i = 0;

            foreach (object[] allianceInfo in list) {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", ++i);
                writer.Write("<td><a href='{2}Alliance/Info.aspx?Id={0}'>{1}</a></td>", allianceInfo[0], allianceInfo[1], WebUtilities.ApplicationPath);
                writer.Write("<td>{0}</td>", allianceInfo[2]);
                writer.Write("<td>{0}</td>", allianceInfo[4]);
                writer.Write("<td>{0}</td>", allianceInfo[3]);
                writer.Write("<td>{0} / {1}</td>", GetZeroIfNull(allianceInfo[5]), GetZeroIfNull( allianceInfo[6]));
                writer.Write("</tr>");
            }

            return writer.ToString();
        }

        private object GetZeroIfNull(object p)
        {
            if (p != null) {
                return p;
            }
            return 0;
        }

        private static string GetHql()
        {
            TextWriter writer = new StringWriter();

            writer.Write(" select alliance.Id, alliance.Name, sum(distinct player.Score), count(distinct planet), count(distinct player), alliance.TotalRelics, alliance.TotalRelicsIncome from SpecializedAllianceStorage alliance ");
            writer.Write(" inner join alliance.PlayersNHibernate player ");
            writer.Write(" inner join player.PlanetsNHibernate planet ");
            writer.Write(" group by alliance ");
            writer.Write(" order by sum(distinct player.Score) desc ");

            return writer.ToString();
        }

        #endregion Events

    }
}
