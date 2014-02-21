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

namespace OrionsBelt.WebUserInterface.Feeds {

    public class PlayerMessages : IHttpHandler {

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/xml";
            WritePlayerMessages(context);
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

        private void WritePlayerMessages(HttpContext context)
        {
            IPlayer player = GetPlayer(context); ;
            Principal principal = player.Principal;
            OrionsBelt.WebUserInterface.Modules.AuthenticateModule.SetLanguage(principal.Locale);

            if (!IsValidRequest(context, player)) {
                context.Response.Output.Write("<Invalid />");
                return;
            }

            TextWriter writer = context.Response.Output;

            writer.Write("<?xml version='1.0' encoding='utf-8'?>");
            writer.Write("<rss xmlns:content='http://purl.org/rss/1.0/modules/content/' xmlns:wfw='http://wellformedweb.org/CommentAPI/' xmlns:dc='http://purl.org/dc/elements/1.1/' xmlns:atom='http://www.w3.org/2005/Atom' version='2.0'>");

            writer.Write("<channel>");
            AddRssChannelInformation(writer);
            AddItemInformation(context, writer, PlayerUtils.GetPlayerMessages(player));
            writer.Write("</channel>");

            writer.Write("</rss>");
        }

        private IPlayer GetPlayer(HttpContext context)
        {
            int id = int.Parse(context.Request.QueryString["Player"]);
            PlayerStorage storage =  Hql.StatelessQuery<PlayerStorage>("from SpecializedPlayerStorage player inner join fetch player.PrincipalNHibernate where player.Id = :id", Hql.Param("id", id))[0];
            return PlayerUtils.LoadPlayer(storage);
        }

        private void AddItemInformation(HttpContext context, TextWriter writer, System.Collections.Generic.IList<Message> iList)
        {
            foreach (Message message in iList)
            {
                IMessage msg = Messenger.ConvertMessage(message);
                msg.LanguageTranslator = LanguageParameterTranslator.Instance;
                string text = msg.Translate();
                writer.Write("<item>");

                writer.Write("<title>");
                writer.Write(text);
                writer.Write("</title>");

                string siteUrl = GetBaseUrl(context);

                writer.Write("<link>");
                writer.Write(siteUrl);
                writer.Write("</link>");

                //writer.Write("<description><![CDATA[");
                //writer.Write(msg.Date);
                //writer.Write("]]></description>");

                writer.Write("<author>");
                writer.Write("Sirius");
                writer.Write("</author>");

                writer.Write("<pubDate>");
                writer.Write(GetPubDate(msg));
                writer.Write("</pubDate>");

                writer.Write("<guid>");
                writer.Write("{0} - Message {1}", siteUrl, message.Id);
                writer.Write("</guid>");

                writer.Write("</item>");
            }
        }

        private string GetBaseUrl(HttpContext context)
        {
            return string.Format("http://{0}/", context.Request.Url.Authority);
        }

        private static string GetPubDate(IMessage msg )
        {
            return msg.Date.ToString("r");
        }

        private bool IsValidRequest(HttpContext context, IPlayer player)
        {
            return context.Request.QueryString["Token"] == PlayerUtils.GetSecretCode(player);
        }

        private void AddRssChannelInformation(TextWriter writer)
        {
            writer.Write("<title>Orion's Belt - {0}</title>", LanguageManager.Instance.Get("EmpireMessages"));
            writer.Write("<link>http://www.orionsbelt.eu</link>");
            writer.Write("<description>{0}</description>", LanguageManager.Instance.Get("EmpireMessages"));

            writer.Write("<language>");
            writer.Write(LanguageManager.CurrentLanguage);
            writer.Write("</language>");
        }

        #endregion Player Messages

    }
}
