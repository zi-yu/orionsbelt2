using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Threading;
using System.Globalization;
using Institutional.WebComponents;

namespace Institutional.WebUserInterface.Modules {

	/// <summary>
    /// This is the I18N Module responsible for the internacionalization
    /// </summary>
    /// <remarks>
    /// Note that this implementation is Independent from the .NET Resources Framework
    /// </remarks>
	public class IndependentLanguageModule : IHttpModule {
		
		#region IHttpModule Members

        /// <summary>
        /// Inits the Module
        /// </summary>
        /// <param name="context">Request Context</param>
		public void Init( HttpApplication context ) {
			context.PreRequestHandlerExecute += new EventHandler(PreRequestHandlerExecute);
		}

        /// <summary>
        /// Clean up resources
        /// </summary>
		public void Dispose() {

		}

		#endregion

		#region Events

        /// <summary>
        /// Responsible to get the current request's language
        /// </summary>
        /// <param name="sender">Event Originator</param>
        /// <param name="e">Arguments</param>
		private void PreRequestHandlerExecute( object sender, EventArgs e ) 
        {
			string option = LanguageManager.RequestLanguage;
            
            string fromqs = HttpContext.Current.Request.QueryString["Lang"];
            if (!string.IsNullOrEmpty(fromqs)) {
                option = fromqs;
            }

            try {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(option);
            } catch {
                Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
            }
		}

		#endregion
	};
	
}
