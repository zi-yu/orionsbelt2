using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using System.IO;
using OrionsBelt.Generic.Messages;
using OrionsBelt.Core;
using OrionsBelt.WebComponents;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Utils {
    
    public class Ticker : IHttpHandler {

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string bootstrap = context.Request.QueryString["Bootstrap"];
            if (!string.IsNullOrEmpty(bootstrap)) {
                WriteBootstrap(context.Response.Output);
            } else {
                WriteLatest(context.Response.Output);
            }
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

        #region Rendering

        private void WriteBootstrap(System.IO.TextWriter textWriter)
        {
            string query = GetQuery();
            IList<Message> messages = Hql.StatelessQuery<Message>(0, 75, query, new KeyValuePair<string, object>[] { Hql.Param("date", DateTime.Now.AddDays(-30)) });
            WriteMessages(textWriter, messages);
        }

        private void WriteMessages(TextWriter writer, IList<Message> messages)
        {
            writer.Write("<script type='text/javascript'>");
            writer.Write("window.tickerData = ['{0}'", DateTime.Now);
            foreach (Message msg in messages) {
                IMessage message = Messenger.ConvertMessage(msg);
                message.LanguageTranslator = LanguageParameterTranslator.Instance;
                writer.Write(",'{0}'", message.Translate().Replace(Environment.NewLine, string.Empty).Replace("'","`"));
            }
            writer.Write("];");
            writer.Write("</script>");
        }

        private static string GetQuery()
        {
            TextWriter hql = new StringWriter();
            hql.Write("from SpecializedMessage m ");
            hql.Write("where m.Date > :date ");
            hql.Write(" and ( m.SubCategory='DeployMessage' ");
            hql.Write(" or m.SubCategory='EndTurnMessage' ");
            hql.Write(" or m.SubCategory='ConquerMessage' ");
            hql.Write(" or m.SubCategory='FleetArrivedMessage' ");
            hql.Write(" or m.SubCategory='FleetStartMovingMessage' ");
            hql.Write(" or m.SubCategory='StolenResourcesMessage' ");
            hql.Write(" or m.SubCategory='CancelFleetMovementMessage' ");
            hql.Write(" or m.SubCategory='FleetDestroyedMessage' ");
            hql.Write(" or m.SubCategory='FleetWonMessage' ");            
            hql.Write(" or m.SubCategory='BattleStartedMessage' ");
            hql.Write(" or m.SubCategory='LostAllCargoMessage' ");          
            hql.Write(" or m.SubCategory='CatchResourcesMessage' ) ");
            hql.Write(" order by m.Id desc");
            string query = hql.ToString();
            return query;
        }

        private void WriteLatest(System.IO.TextWriter textWriter)
        {
            string query = GetQuery();
            IList<Message> messages = Hql.StatelessQuery<Message>(0, 25, query, new KeyValuePair<string, object>[] { Hql.Param("date", DateTime.Now.AddSeconds(-5)) });
            WriteMessages(textWriter, messages);
        }

        #endregion Rendering
    }
}
