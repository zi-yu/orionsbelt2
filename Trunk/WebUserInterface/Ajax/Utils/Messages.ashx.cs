using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Collections.Generic;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Utils {
    public class Messages : IHttpHandler {

        #region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/html";
            string action = context.Request.QueryString["Action"];
            if (actions.ContainsKey(action)) {
                actions[action](context);
            } else {
                context.Response.Output.Write("Invalid Action");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        #endregion IHttpHandler Implementation

        #region Utils

        private delegate void ProcessMessageAction(HttpContext context);
        private static Dictionary<string, ProcessMessageAction> actions = new Dictionary<string, ProcessMessageAction>();

        static Messages()
        {
            actions.Add("DeleteAll", DeleteAllMessages);
        }

        #endregion Utils

        #region Actions

        private static void DeleteAllMessages(HttpContext context)
        {
            using (IMessagePersistance persistance = Persistance.Instance.GetMessagePersistance()) {
                persistance.StartTransaction();
                int deleted = persistance.Delete("from SpecializedMessage m where (m.OwnerId = {0} and (m.Category = 'Player' or m.Category = 'Universe')) or (m.OwnerId = {1} and m.Category = 'Principal')",
                        PlayerUtils.Current.Id, PlayerUtils.Current.Principal.Id
                    );
                persistance.CommitTransaction();
                context.Response.Output.Write("Deleted {0} messages", deleted);
            }
        }

        #endregion Actions

    };
}
