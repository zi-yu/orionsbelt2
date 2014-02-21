using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.IO;
using Language.Core;
using System.Collections.Generic;
using Language.DataAccessLayer;

namespace WebUserInterface {

    public class LatestEntries : IHttpHandler {

        #region Events

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            WriteFeed(context.Response.Output, context);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion Events

        #region Feed

        private void WriteFeed(System.IO.TextWriter writer, HttpContext context)
        {
            writer.Write("<?xml version='1.0' encoding='utf-8'?>");
            writer.Write("<rss xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0'>");

            writer.Write("<channel>");
            AddRssChannelInformation(writer);
            AddItemInformation(context, writer);
            writer.Write("</channel>");

            writer.Write("</rss>");
        }

        private void AddItemInformation(HttpContext context, System.IO.TextWriter writer)
        {
            IList<LanguageEntry> list = Hql.StatelessQuery<LanguageEntry>(0, 25, "select distinct e from SpecializedLanguageEntry e order by e.UpdatedDate desc", null);
            foreach (LanguageEntry entry in list) {
                writer.Write("<item>");

                writer.Write("<title>");
                writer.Write("Entry {0} Updated", entry.Name);
                writer.Write("</title>");

                string siteUrl = GetBaseUrl(context);

                writer.Write("<link>");
                writer.Write("{0}EditEntry.aspx?Id={1}&amp;Locale=en", siteUrl, entry.Id);
                writer.Write("</link>");

                writer.Write("<description><![CDATA[");
                writer.Write("<p>Principal: {0}</p>", entry.LastActionUserId);
                writer.Write("]]></description>");

                writer.Write("<author>");
                writer.Write("Sirius");
                writer.Write("</author>");

                writer.Write("<pubDate>");
                writer.Write(GetPubDate(entry));
                writer.Write("</pubDate>");

                writer.Write("<guid>");
                writer.Write("{0} - Entry {1}", siteUrl, entry.Id);
                writer.Write("</guid>");

                writer.Write("</item>");
            }
        }

        private object GetPubDate(LanguageEntry entry)
        {
            return entry.UpdatedDate.ToString("r");
        }

        private string GetBaseUrl(HttpContext context)
        {
            return "http://lang.orionsbelt.eu/";
        }

        private void AddRssChannelInformation(TextWriter writer)
        {
            writer.Write("<title>Orion's Belt - Latest Entries</title>");
            writer.Write("<link>http://www.orionsbelt.eu</link>");
            writer.Write("<description>Latest Updated Entries</description>");

            writer.Write("<language>");
            writer.Write("en");
            writer.Write("</language>");
        }

        #endregion

    };
}
