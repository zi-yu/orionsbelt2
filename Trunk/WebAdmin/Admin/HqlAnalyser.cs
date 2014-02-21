using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using OrionsBelt.DataAccessLayer;
using IList = System.Collections.IList;
using NHibernate;

namespace OrionsBelt.WebAdmin.Admin.Controls {

	public class HqlAnalyser : Page {
				#region Fields

		private IList queryResults;
		protected TextBox query;
		protected GridView results;

		#endregion

		#region Control Events

		protected void ExecuteQuery( object sender, EventArgs e ) {
			try {
				queryResults = NHibernateUtilities.HqlQuery( query.Text );
				Information.AddInformation( "Query completed successfully!" );
			} catch( QueryException qe ) {
				Information.AddError( qe.Message );
			}
		}

		#endregion
		
		#region Events
		
		protected override void OnLoad( EventArgs e ) {
			HttpContext.Current.Session["CurrentEntity"] = "hqlanalyser";
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