using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using Loki.DataRepresentation;
using OrionsBelt.DataAccessLayer;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Net;

namespace OrionsBelt.WebUserInterface {
	public class ReferralsPage : Page  {

        #region Fields

        protected Literal referrals;
        protected Literal campaigns;
        protected Literal lastDay; 

        #endregion Fields

        #region Static

        private static Dictionary<int, string> custom = new Dictionary<int, string>();

        static ReferralsPage()
        {
            string raw = GetReferrals();
            string[] lines = raw.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string line in lines) {
                string[] infos = line.Split(new char[]{';'}, StringSplitOptions.RemoveEmptyEntries);
                int key = int.Parse(infos[0]);
                if(!custom.ContainsKey(key)) {
                    custom.Add(key, infos[1]);
                }
            }
        }

        private static string GetReferrals()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create("http://www.orionsbelt.eu/Ajax/Referrals.ashx");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream())) {
                return reader.ReadToEnd();
            }
        }

        #endregion Static

        #region Events

        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            string hql = GetHql();
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                IList list = session.Query(hql);
                WriteList(list);
            }
            WriteLastDay();
            WriteCampaigns();
            
        }

        private void WriteLastDay()
        {
            TextWriter writer = new StringWriter();
            writer.Write("<h2>Last day</h2><table class='table'>");
            writer.Write("<tr>");
            writer.Write("<th>Campaign</th>");
            writer.Write("<th>Regists</th>");
            writer.Write("</tr>");

            IList list;
            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                list = session.Query("SELECT e.ReferrerId,count(e.ReferrerId) FROM SpecializedPrincipal e where e.RegistDate >= '{0}' and e.RegistDate < '{1}' group by e.ReferrerId order by count(e.ReferrerId) desc"
                    , DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd"), DateTime.Now.ToString("yyyy-MM-dd"));
                
            }

            foreach (object[] objs in list)
            {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", GetSource(objs[0]));
                writer.Write("<td>{0}</td>", (Convert.ToInt32(objs[1])));
                writer.Write("</tr>");
            } 
            writer.Write("</table>");

            lastDay.Text = writer.ToString();

        }
        private void WriteCampaigns()
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<table class='table'>");
                writer.Write("<tr>");
                writer.Write("<th>Campaign</th>");
                writer.Write("<th>Id</th>");
                writer.Write("</tr>");

                foreach (KeyValuePair<int, string> pair in custom) {
                    writer.Write("<tr>");
                    writer.Write("<td>{0}</td>", pair.Value);
                    writer.Write("<td>{0}</td>", pair.Key);
                    writer.Write("</tr>");
                }

                writer.Write("</table>");

                campaigns.Text = writer.ToString();
            }
        }

        private void WriteList(IList list)
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write("<table class='table'>");
                writer.Write("<tr>");
                writer.Write("<th>Source</th>");
                writer.Write("<th>Referrals</th>");
                writer.Write("<th>%</th>");
                writer.Write("</tr>");

                double total = GetTotal(list);
                writer.Write("<tr><td>Total</td><td>{0}</td><td>100%</td></tr>", total);

                foreach (object[] objs in list) {
                    writer.Write("<tr>");
                    writer.Write("<td>{0}</td>", GetSource(objs[0]));
                    writer.Write("<td>{0}</td>", objs[1]);
                    writer.Write("<td>{0:#0.00}%</td>", (Convert.ToInt32(objs[1]) / total * 100));
                    writer.Write("</tr>");
                }

                writer.Write("</table>");

                referrals.Text = writer.ToString();
            }
        }

        private double GetTotal(IList list)
        {
            double sum = 0;
            foreach (object[] objs in list) {
                sum += Convert.ToInt32(objs[1]);
            }
            return sum;
        }

        public static object GetSource(object obj)
        {
            int id = Convert.ToInt32(obj);

            if (id > 0) {
                return string.Format("<a href='../PrincipalInfo.aspx?Principal={0}'>Principal {0}</a>", id);
            }

            if (custom.ContainsKey(id)) { 
                return string.Format("{0} ({1})", custom[id], id);
            }

            return string.Format("Unmamed Campaign ({0})", id);
        }

        private string GetHql()
        {
            using (TextWriter writer = new StringWriter()) {

                writer.Write(" select principal.ReferrerId, count(principal.ReferrerId) ");
                writer.Write(" from SpecializedPrincipal principal ");
                writer.Write(" group by principal.ReferrerId ");
                writer.Write(" order by count(principal.ReferrerId)  desc ");

                return writer.ToString();
            }
        }

        #endregion Events

    };
}

