﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Institutional.DataAccessLayer;
using IList = System.Collections.IList;
using NHibernate;

namespace Institutional.WebAdmin.Admin.Controls {

	public class SqlAnalyser : Page {
				#region Fields

		private IList queryResults;
		protected TextBox query;
		protected GridView results;

		#endregion

		#region Control Events

		protected void ExecuteQuery( object sender, EventArgs e ) {
			try {
				queryResults = Sql.StatelessQuery( query.Text );
				Information.AddInformation( "Sql Query completed successfully!" );
			}
			catch ( Exception ex)
            {
                Information.AddError(ex.Message);
            }
		}

		#endregion
		
		#region Events
		
		protected override void OnLoad( EventArgs e ) {
			HttpContext.Current.Session["CurrentEntity"] = "sqlanalyser";
			HttpContext.Current.Session["CurrentAction"] = "";
		}

		protected override void Render( HtmlTextWriter writer ) {
			if( queryResults!= null && queryResults.Count > 0 ) {
				results.Visible = true;
				results.DataSource = queryResults;
				results.DataBind();
				results.Style.Clear();
				results.Style.Add( "border-collapse", "none" );
			} else {
				results.Visible = false;
			}

			base.Render( writer );
		}

		#endregion
	}
	
}