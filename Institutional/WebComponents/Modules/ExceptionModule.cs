using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Modules {
	public class ExceptionModule : IHttpModule {

		#region IHttpModule Members

		public void Init( HttpApplication context ) {
			context.Error += new EventHandler( Error );
		}

		public void Dispose() {}

		#endregion

		#region Events

		private void Error( object sender, EventArgs e ) {
			Exception exp = HttpContext.Current.Server.GetLastError();
			if( exp is HttpUnhandledException ) {
				if( exp.InnerException != null ) {
					ExceptionLogger.Log( exp.InnerException );
				} else {
					ExceptionLogger.Log( exp );
				}
			} else {
				ExceptionLogger.Log( exp );
			}

			#if !DEBUG
			HttpContext.Current.Response.Redirect( "~/error.aspx" );
			#endif
		}

		#endregion
	}
}
