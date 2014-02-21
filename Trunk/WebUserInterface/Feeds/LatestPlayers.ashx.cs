using System;
using System.Data;
using System.Web;
using System.Collections;
using OrionsBelt.Core;
using OrionsBelt.Engine;
using OrionsBelt.RulesCore.Interfaces;
using System.IO;
using OrionsBelt.WebComponents;
using OrionsBelt.Generic.Messages;
using OrionsBelt.WebUserInterface.Engine;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Resources;
using System.Collections.Generic;

namespace OrionsBelt.WebUserInterface.Feeds {

    public class LatestPlayers : IHttpHandler {

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            WriteLatestPlayers(context);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

        #region Player Messages

        private void WriteLatestPlayers(HttpContext context)
        {
            TextWriter writer = context.Response.Output;

            writer.Write("<?xml version='1.0' encoding='utf-8'?>");
            writer.Write("<rss xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0'>");

            writer.Write("<channel>");
            AddRssChannelInformation(writer);
            AddItemInformation(context, writer);
            writer.Write("</channel>");

            writer.Write("</rss>");
        }

        private void AddItemInformation(HttpContext context, TextWriter writer)
        {
            IList<Principal> list = Hql.StatelessQuery<Principal>(0, 25, "from SpecializedPrincipal p order by p.CreatedDate desc", null);
            foreach (Principal principal in list)
            {
                writer.Write("<item>");

                writer.Write("<title>");
                writer.Write(principal.DisplayName);
                writer.Write("</title>");

                string siteUrl = GetBaseUrl(context);

                writer.Write("<link>");
                writer.Write(siteUrl);
                writer.Write("</link>");

                writer.Write("<description><![CDATA[");
                writer.Write("<p>{0}</p>", principal.Email);
                if (principal.ReferrerId != 0) {
                    writer.Write("<p>ReferrerId = {0}</p>", ReferralsPage.GetSource( principal.ReferrerId));
                }
                writer.Write("]]></description>");

                writer.Write("<author>");
                writer.Write("Sirius");
                writer.Write("</author>");

                writer.Write("<pubDate>");
                writer.Write(GetPubDate(principal));
                writer.Write("</pubDate>");

                writer.Write("<guid>");
                writer.Write("{0} - Principal {1}", siteUrl, principal.Id);
                writer.Write("</guid>");

                writer.Write("</item>");
            }
        }

        private string GetBaseUrl(HttpContext context)
        {
            return OrionsBelt.Generic.Server.Properties.BaseUrl;
        }

        private static string GetPubDate(Principal p )
        {
            return p.CreatedDate.ToString("r");
        }

        private void AddRssChannelInformation(TextWriter writer)
        {
            writer.Write("<title>Orion's Belt - Latest Players</title>");
            writer.Write("<link>http://www.orionsbelt.eu</link>");
            writer.Write("<description>Latest Registered Players</description>");

            writer.Write("<language>");
            writer.Write("en");
            writer.Write("</language>");
        }

        #endregion Player Messages

    }
}
