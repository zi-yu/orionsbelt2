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
using OrionsBelt.WebComponents.Controls;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;
using System.IO;
using OrionsBelt.WebComponents;
using Loki.DataRepresentation;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Campaigns
{
    public class Stats : Page {

        #region Fields

        protected Literal title;
        protected Literal content;

        public int CampaignId {
            get { 
                return int.Parse(HttpContext.Current.Request.QueryString["Id"]);            
            }
        }

        public string CampaignName {
            get { 
                string raw =HttpContext.Current.Request.QueryString["Campaign"];
                if (string.IsNullOrEmpty(raw)) {
                    throw new UIException("No Campaign name given");
                }
                return raw;
            }
        }

        #endregion Fields

        #region Events

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            string campaignTitle = LanguageManager.Localize(string.Format("{0}Title", CampaignName));
            title.Text = string.Format(LanguageManager.Localize("CampaignStatsTitle"), campaignTitle);

            content.Text = GetContent();
        }

        #endregion Events

        #region Utils

        private string GetContent()
        {
            TextWriter writer = new StringWriter();

            IList list = GetData();

            writer.Write("<table class='table'>");

            writer.Write("<tr>");
            writer.Write("<th>{0}</th>", LanguageManager.Localize("Player"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("Level"));
            writer.Write("<th>{0}</th>", LanguageManager.Localize("CampaignMoves"));
            writer.Write("</tr>");

            foreach (object[] line in list) {
                writer.Write("<tr>");
                writer.Write("<td>{0}</td>", WebUtilities.WritePrincipalWithAvatar((int)line[0], (string)line[1], (string)line[4]));
                writer.Write("<td>{0}</td>", line[2]);
                writer.Write("<td>{0}</td>", line[3]);
                writer.Write("</tr>");
                
            }

            writer.Write("</table>");

            return writer.ToString();
        }

        private IList GetData()
        {
            TextWriter writer = new StringWriter();

            writer.Write("select status.PrincipalNHibernate.Id, status.PrincipalNHibernate.Name, max(status.Level),  sum(status.Moves), status.PrincipalNHibernate.Avatar ");
            writer.Write("from SpecializedCampaignStatus status ");
            writer.Write("where status.CampaignNHibernate.Id = {0} and status.Completed = 1 ");
            writer.Write("order by max(status.Level) desc,  sum(status.Moves) asc ");
            writer.Write("group by status.PrincipalNHibernate.Id");

            using (IPersistanceSession session = Persistance.Instance.GetGenericPersistance()) {
                return session.Query(0, 20, writer.ToString(), CampaignId);
            }
        }

        #endregion Utils

    };
}
