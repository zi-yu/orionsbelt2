using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Language.Core;
using Language.DataAccessLayer;
using System.Collections.Generic;

namespace Language.WebUserInterface {
	public class Global : System.Web.HttpApplication {
	
		protected void Application_Start( object sender, EventArgs e ) {
			string status = ConfigurationManager.AppSettings["appStatus"];
			Application["APP_STATUS"] = bool.Parse( status );
		}

		protected void Application_End( object sender, EventArgs e ) {
            
		}
		
		protected void Application_EndRequest( object sender, EventArgs e ) {
			Persistance.CloseCurrentSession();
		}
		
		protected void Application_Error(object sender, EventArgs e)
        {
            // Errors are dealed with the ExceptionModule
        }
	}
}