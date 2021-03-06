﻿using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Web;

namespace OrionsBelt.WebAdmin.Admin.Controls {

	public class Information : Control {

		#region Fields

		List<string> errors = new List<string>();
		private string title = null;
		private bool _isInformation = false; 

		#endregion

		#region Public 
		
		public string Title {
			set { title = value; }
			get {
				return title;
			}
		}
		
		public bool IsInformation {
			get { return _isInformation; }
			set { _isInformation = value; }
		}

		public void InsertMessage( string message ) {
			errors.Add( message );
		}

		#endregion

		#region Events

		protected override void OnInit( EventArgs e ) {
			base.OnInit( e );
		}

		protected override void Render(HtmlTextWriter writer) {
			if( errors.Count == 0  ) {
				this.Visible = false;
				return;
			}	
			writer.WriteLine( "<table id='informationTable'>" );
			writer.WriteLine( "<th colspan='2'><img src='Images/msg_left.gif'/>&nbsp;{0}</th>", Title );
			if( IsInformation ) {
				writer.WriteLine( "<tr><td><img src='Images/information.gif'/></td>" );
			} else {
				writer.WriteLine( "<tr><td><img src='Images/error.gif'/></td>" );
			}
			writer.WriteLine( "<td class='messageContent'>" );

			writer.WriteLine( "<ul>" );
			if( errors != null && errors.Count > 0 ) {
				WriteErrors(writer);
			}
			
			writer.WriteLine( "</ul>" );

			writer.WriteLine( "</td></tr>" );
			writer.WriteLine( "</table><p/>" );

			base.Render (writer);
			errors.Clear();
		}
		
		private void WriteErrors( HtmlTextWriter writer ) {
			foreach( object error in errors ) {
				writer.WriteLine( "<li>{0}</li>", error);
			}
		}
		
		#endregion

		#region Static 

		public static void InitErrorControl( Information info ) {
			info.Title = "Error";
			HttpContext.Current.Items["ErrorControl"] = info;
		}

		public static void InitInformationControl( Information info ) {
			info.Title = "Information";
			info.IsInformation = true;
			HttpContext.Current.Items["InformationControl"] = info;
		}

		public static void AddInformation( string message ) {
			Information info = (Information) HttpContext.Current.Items["InformationControl"];
			info.IsInformation = true;
			info.InsertMessage( message );
		}

		public static void AddError( string message ) {
			Information info = (Information) HttpContext.Current.Items["ErrorControl"];
			info.InsertMessage( message );
		}

		public static Information GetInformationControl() {
			Information info = GetInformation("InformationControl");
			info.IsInformation = true;
			return info;
		}
		
		public static Information GetErrorControl() {
			return GetInformation("ErrorControl");
		}

		private static Information GetInformation( string name ) {
			return (Information) HttpContext.Current.Items[name];
		}

		#endregion
	}
}
