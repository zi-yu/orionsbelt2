using System.Collections.Generic;
using System.IO;
using System.Web;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebUserInterface.Feeds {

    public class LatestPayments : IHttpHandler {

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

        private static void WriteLatestPlayers(HttpContext context)
        {
            TextWriter writer = context.Response.Output;

            writer.Write("<?xml version='1.0' encoding='utf-8'?>");
            writer.Write("<rss xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0'>");

            writer.Write("<channel>");
            AddRssChannelInformation(writer);
            AddItemInformation(writer);
            writer.Write("</channel>");

            writer.Write("</rss>");
        }

        private static void AddItemInformation(TextWriter writer)
        {
            IList<Invoice> list = Hql.StatelessQuery<Invoice>(0, 25, "from SpecializedInvoice p order by p.CreatedDate desc", null);
            foreach (Invoice invoice in list)
            {
                writer.Write("<item>");

                writer.Write("<title>");
                writer.Write(invoice.Identifier);
                writer.Write("</title>");

                string siteUrl = GetBaseUrl();

                writer.Write("<link>");
                writer.Write(siteUrl);
                writer.Write("</link>");

                writer.Write("<description><![CDATA[");
                writer.Write("<h1>{0}</h1>", invoice.Identifier);
                writer.Write("<p>Buyer = {0}</p>", invoice.Payment.PrincipalId);
                writer.Write("<p>Name = {0}</p>", invoice.Name);
                writer.Write("<p>Country = {0}</p>", invoice.Country);
                writer.Write("<p>Money = {0} €</p>", invoice.Money);
                writer.Write("<p>Date = {0}</p>", invoice.CreatedDate);
                writer.Write("]]></description>");

                writer.Write("<author>");
                writer.Write("Sirius");
                writer.Write("</author>");

                writer.Write("<pubDate>");
                writer.Write(GetPubDate(invoice));
                writer.Write("</pubDate>");

                writer.Write("<guid>");
                writer.Write("{0} - Invoice {1}", siteUrl, invoice.Id);
                writer.Write("</guid>");

                writer.Write("</item>");
            }
        }

        private static string GetBaseUrl()
        {
            return OrionsBelt.Generic.Server.Properties.BaseUrl;
        }

        private static string GetPubDate(IEntity p )
        {
            return p.CreatedDate.ToString("r");
        }

        private static void AddRssChannelInformation(TextWriter writer)
        {
            writer.Write("<title>Orion's Belt - Latest Payments</title>");
            writer.Write("<link>http://www.orionsbelt.eu</link>");
            writer.Write("<description>Latest Payments</description>");

            writer.Write("<language>");
            writer.Write("en");
            writer.Write("</language>");
        }

        #endregion Player Messages

    }
}
