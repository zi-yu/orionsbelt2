using System;
using System.Web;
using System.Web.Configuration;
using System.Web.UI.WebControls;
using System.Configuration;

namespace Institutional.WebAdmin.Admin {
	public partial class Default : System.Web.UI.Page {
		
		#region Fields

		protected Label appState;
		protected LinkButton toggleStatus;

		#endregion

		#region Private

		private void UpdateStatus() {
			if( (bool)Application["APP_STATUS"] ) {
				appState.Text = "Application is Online";
				toggleStatus.Text = "Take aplication Offline";
			} else {
				appState.Text = "Application is Offline";
				toggleStatus.Text = "Take aplication Online";
			}
		}

		#endregion

		#region Events
		
		protected override void OnLoad( EventArgs e ) {
			UpdateStatus();
		}

		protected void ToggleApplicationStatus( object sender, EventArgs e ) {
			Configuration config = WebConfigurationManager.OpenWebConfiguration( HttpContext.Current.Request.ApplicationPath );
			AppSettingsSection appSection = config.AppSettings;
			appSection.Settings.Remove("appStatus");

			bool appStatus = (bool)Application["APP_STATUS"];

			appSection.Settings.Add("appStatus", ( !appStatus ).ToString() );
			Application["APP_STATUS"] = !appStatus;

			config.Save( ConfigurationSaveMode.Minimal );

			UpdateStatus();
		}

		#endregion
	}
	
}