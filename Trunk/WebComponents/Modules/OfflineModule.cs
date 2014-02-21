using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace OrionsBelt.WebComponents.Modules {
	class OfflineModule : IHttpModule {

		#region Private

		private void RedirectToMaintenance( HttpApplication app ) {
			string fullFileName = app.Server.MapPath( @"~/maintenance.html" );
			if( System.IO.File.Exists( fullFileName ) ) {
				app.Response.WriteFile( fullFileName );
				app.Response.End();
			}
		}
		
		private bool UrlContains( string s ) {
			return HttpContext.Current.Request.RawUrl.ToLower().IndexOf( s ) != -1;
		}

		#endregion
		
		#region IHttpModule Members

		public void Init( HttpApplication context ) {
			context.BeginRequest += new EventHandler( BeginRequest );
		}

		public void Dispose() {

		}

		#endregion

		#region Events

		private void BeginRequest( object sender, EventArgs e ) {
			HttpApplication app = (HttpApplication)sender;

			if( HttpContext.Current.Application["APP_STATUS"] == null ) {
				HttpContext.Current.Application["APP_STATUS"] = true;
			}

			if( !UrlContains( "/admin/" ) && !UrlContains( "Login.aspx" ) ) {
				bool status = (bool)HttpContext.Current.Application["APP_STATUS"];
				if( !status ) {
					RedirectToMaintenance( app );
				}
			}
		}

		#endregion
	}
}
