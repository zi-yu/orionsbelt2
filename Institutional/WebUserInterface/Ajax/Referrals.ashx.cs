using System;
using System.Data;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Institutional.DataAccessLayer;
using Institutional.Core;

namespace WebUserInterface.Ajax {

    public class Referrals : IHttpHandler {

        #region Events

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            WriteReferrals(context.Response.Output);
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion Events

        #region Rendering

        private void WriteReferrals(System.IO.TextWriter writer)
        {
            foreach (Referral referral in Hql.StatelessQuery<Referral>("select r from SpecializedReferral r", null)) {
                writer.WriteLine("{0};{1};", referral.Code, referral.Name);
            }

        }

        #endregion Rendering

    };
}
