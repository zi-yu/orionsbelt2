using System;
using System.Configuration;
using System.Web;
using OrionsBelt.DataAccessLayer;
using OrionsBelt.Engine.Actions;
using OrionsBelt.Generic.Log;
using OrionsBelt.WebComponents;

namespace OrionsBelt.WebUserInterface {
	public class Global : HttpApplication {
	
		protected void Application_Start( object sender, EventArgs e ) {
            LanguageManager.Instance = new PreCompiledLanguage();
            Application["LanguageManager"] = LanguageManager.Instance;

            LanguageResources.LogExceptions = false;
			string status = ConfigurationManager.AppSettings["appStatus"];
			Application["APP_STATUS"] = bool.Parse( status );
            //Logger.Info(LogType.Generic, "Web Application Started");
		}

		protected void Application_End( object sender, EventArgs e ) {
            Logger.Info(LogType.Generic, "Web Application Ended {0}", Environment.StackTrace);            
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