﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;
using System.Security.Permissions;
using System.Configuration;
using System.Web.Configuration;
using System.Net.Configuration;
using System.Globalization;


namespace Institutional.WebAdmin.Admin.Controls {

	[AspNetHostingPermission( SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal )]
	[AspNetHostingPermission( SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal )]
	public class SmtpSettings : Page {
		private enum AuthenticateMode { None = 0, Basic = 1, NTLM = 2, }

		#region Fields

		protected TextBox sendersName;
		protected TextBox sendersPass;

		protected TextBox serverName;
		protected TextBox serverPort;
		protected TextBox from;
		
		protected RadioButton NoneRadioButton;
		protected RadioButton BasicRadioButton;
		protected RadioButton NTLMRadioButton;

		#endregion		

		#region Private
		
		private AuthenticateMode ChooseAuthentication() {
			if( NoneRadioButton.Checked ) {
				return AuthenticateMode.None;
			}

			if( BasicRadioButton.Checked ) {
				return AuthenticateMode.Basic;
			}

			return AuthenticateMode.NTLM;
		}

		private void ToggleSenderState( bool enabled ) {
			sendersName.Enabled = enabled;
			sendersPass.Enabled = enabled;
		}

		#endregion

		#region Control Events

		protected override void OnLoad( EventArgs e ) {
		
			HttpContext.Current.Session["CurrentEntity"] = "smtpsettings";
			HttpContext.Current.Session["CurrentAction"] = "";
						
			string appPath = HttpContext.Current.Request.ApplicationPath;
			if( !Page.IsPostBack ) {

				Configuration config = WebConfigurationManager.OpenWebConfiguration( appPath );
				SmtpSection netSmtpMailSection = (SmtpSection)config.GetSection( "system.net/mailSettings/smtp" );

				serverName.Text = netSmtpMailSection.Network.Host;
				serverPort.Text = Convert.ToString( netSmtpMailSection.Network.Port, CultureInfo.InvariantCulture );
				from.Text = netSmtpMailSection.From;

				AuthenticateMode authenticateMode;
				if( netSmtpMailSection.Network.DefaultCredentials ) {
					authenticateMode = AuthenticateMode.NTLM;
				} else {
					authenticateMode = AuthenticateMode.None;
					if( !String.IsNullOrEmpty( netSmtpMailSection.Network.UserName ) ) {
						authenticateMode = AuthenticateMode.Basic;
						sendersName.Text = netSmtpMailSection.Network.UserName;
					}
				}

				switch( authenticateMode ) {
					case AuthenticateMode.None:
						NoneRadioButton.Checked = true;
						break;
					case AuthenticateMode.Basic:
						BasicRadioButton.Checked = true;
						break;
					case AuthenticateMode.NTLM:
						NTLMRadioButton.Checked = true;
						break;
					default:
						throw new Exception( "UnexpectedSmtpField" );
				}

				ToggleSenderState( authenticateMode == AuthenticateMode.Basic );

				base.OnLoad( e );
			}
		}

		#endregion

		#region Events

		protected void SaveButton_Click(object sender, EventArgs e) {
			Configuration config = WebConfigurationManager.OpenWebConfiguration( HttpContext.Current.Request.ApplicationPath );
			SmtpSection netSmtpMailSection = (SmtpSection) config.GetSection("system.net/mailSettings/smtp");

			netSmtpMailSection.Network.Host = serverName.Text;
			netSmtpMailSection.Network.Port = Convert.ToInt32(serverPort.Text, CultureInfo.InvariantCulture);
			netSmtpMailSection.From = from.Text;

			switch( ChooseAuthentication() ) { 
				case AuthenticateMode.None:
					netSmtpMailSection.Network.DefaultCredentials = false;
					netSmtpMailSection.Network.UserName = String.Empty;
					netSmtpMailSection.Network.Password = String.Empty;
					break;
				case AuthenticateMode.Basic:
					netSmtpMailSection.Network.DefaultCredentials = false;
					netSmtpMailSection.Network.UserName = sendersName.Text;
					netSmtpMailSection.Network.Password = sendersPass.Text;
					break;
				case AuthenticateMode.NTLM:
					netSmtpMailSection.Network.DefaultCredentials = true;
					netSmtpMailSection.Network.UserName = String.Empty;
					netSmtpMailSection.Network.Password = String.Empty;
					break;
			}
			
			config.Save();			
			
			Information.AddInformation( "Smtp Settings Updated Successfully!" );
		}

		protected void Authentication_ValueChanged( object sender, EventArgs e ) {
			ToggleSenderState( BasicRadioButton.Checked );
		}

		#endregion
	}
	
}