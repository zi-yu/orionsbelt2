using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Web.SessionState;
using OrionsBelt.WebUserInterface.Engine;

namespace OrionsBelt.WebUserInterface.Ajax.Prices
{
    public class Prices : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            string type = context.Request.QueryString["Type"];
            if (!string.IsNullOrEmpty(type))
            {
                PricesActions a = new PricesActions();
                a.ProcessActions(type);
            }
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
