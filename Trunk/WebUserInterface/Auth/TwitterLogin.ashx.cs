using System;
using System.Collections.Generic;
using System.Web;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {

	/// <summary>
    /// Redirects the user to Twiter for authentication
    /// </summary>
	public class TwitterLogin : IHttpHandler {
	
		#region IHttpHandler Implementation

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            context.Response.Redirect(new OAuthTwitter().GetAuthorizationLink());
        }

        public bool IsReusable {
            get {
                return false;
            }
        }

        #endregion IHttpHandler Implementation
	
	};
}
