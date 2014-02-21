using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using System.Collections.Generic;
using OrionsBelt.Generic;

namespace OrionsBelt.WebUserInterface.Feeds {

    [WebService(Namespace = "http://orionsbelt.eu")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class BattleMoves : IHttpHandler {

        #region Static Fields

        public static string BaseUrl {
            get { return string.Format("{0}Battle/",  Server.Properties.BaseUrl); }
        }

        #endregion Static Fields

        #region IHttpHandler implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            AddRss(context.Response);
        }

        public bool IsReusable {
            get{
                return false;
            }
        }

        #endregion IHttpHandler implementation

        #region Utilities

        private void AddRss(HttpResponse writer)
        {
            writer.Write("<?xml version='1.0' encoding='utf-8'?>");
            writer.Write("<rss xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0'>");

            writer.Write("<channel>");
            AddRssChannelInformation(writer);
            AddItemInformation(writer);
            writer.Write("</channel>");

            writer.Write("</rss>");
        }

        private void AddItemInformation(HttpResponse writer)
        {
            using (IBattlePersistance persistance = Persistance.Instance.GetBattlePersistance()) {
                string query = "select distinct b from SpecializedBattle b inner join fetch b.PlayerInformationNHibernate player where b.IsDeployTime = 0 order by b.UpdatedDate desc";
                IList<Core.Battle> list = persistance.TypedQuery(0, 100, query);
                list = Hql.Unify<Core.Battle>(list);
                foreach (Core.Battle battle in list) {
                    WriteItem(writer, battle);
                }
            }
        }

        private void WriteItem(HttpResponse writer, Core.Battle battle)
        {
            writer.Write("<item>");

            writer.Write("<title>");
            string title = GetBattleTitle(battle);
            writer.Write(title);
            writer.Write("</title>");

            string siteUrl = string.Format("{0}/Battle.aspx?Id={1}", BaseUrl, battle.Id);

            writer.Write("<link>");
            writer.Write(siteUrl);
            writer.Write("</link>");

            writer.Write("<description><![CDATA[");
            writer.Output.Write("<a href='{0}'>Go to Battle</a>", siteUrl);
            writer.Write("]]></description>");

            writer.Write("<author>");
            writer.Write("Sirius");
            writer.Write("</author>");

            writer.Write("<pubDate>");
            writer.Write(GetPubDate(battle));
            writer.Write("</pubDate>");

            writer.Write("<guid>");
            writer.Output.Write("{0} - Turn {1}", siteUrl, battle.CurrentTurn);
            writer.Write("</guid>");

            writer.Write("</item>");
        }

        private string GetBattleTitle(Core.Battle battle)
        {
            if (battle.IsTeamBattle) {
                return "Team Battle";
            } else {
                return string.Format("{0} vs {1}", battle.PlayerInformation[0].Name, battle.PlayerInformation[1].Name);
            }
        }

        private static string GetPubDate(Core.Battle battle)
        {
            return battle.UpdatedDate.ToString("r");
        }

        private void AddRssChannelInformation(HttpResponse writer)
        {
            writer.Write("<title>Orion's Belt - Battle Moves</title>");
            writer.Write(string.Format("<link>{0}</link>", BaseUrl));
            writer.Write("<description>Every battle move</description>");

            writer.Write("<language>");
            writer.Write("en");
            writer.Write("</language>");
        }

        #endregion Utilities

    };
}
