
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that enables ExceptionInfo search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ExceptionInfoPagedList
    /// </remarks>
	public class ExceptionInfoSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox message = new TextBox();
		protected DropDownList operatorsForMessage = new DropDownList();
		protected TextBox date = new TextBox();
		protected DropDownList operatorsForDate = new DropDownList();
		protected TextBox url = new TextBox();
		protected DropDownList operatorsForUrl = new DropDownList();
		protected TextBox stackTrace = new TextBox();
		protected DropDownList operatorsForStackTrace = new DropDownList();
		protected TextBox createdDate = new TextBox();
		protected DropDownList operatorsForCreatedDate = new DropDownList();
		protected TextBox updatedDate = new TextBox();
		protected DropDownList operatorsForUpdatedDate = new DropDownList();
		protected TextBox lastActionUserId = new TextBox();
		protected DropDownList operatorsForLastActionUserId = new DropDownList();
		protected Button button = new Button();

		#endregion Control Fields
		
		#region Control Properties
		
		/// <summary>
        /// Search box for ExceptionInfo's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's Message property
        /// </summary>
		public TextBox Message {
			get { return message; }
			set { message = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's Message operators
        /// </summary>
		public DropDownList OperatorsForMessage {
			get { return operatorsForMessage; }
			set { operatorsForMessage = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's Date property
        /// </summary>
		public TextBox Date {
			get { return date; }
			set { date = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's Date operators
        /// </summary>
		public DropDownList OperatorsForDate {
			get { return operatorsForDate; }
			set { operatorsForDate = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's Url property
        /// </summary>
		public TextBox Url {
			get { return url; }
			set { url = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's Url operators
        /// </summary>
		public DropDownList OperatorsForUrl {
			get { return operatorsForUrl; }
			set { operatorsForUrl = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's StackTrace property
        /// </summary>
		public TextBox StackTrace {
			get { return stackTrace; }
			set { stackTrace = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's StackTrace operators
        /// </summary>
		public DropDownList OperatorsForStackTrace {
			get { return operatorsForStackTrace; }
			set { operatorsForStackTrace = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ExceptionInfo's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ExceptionInfo's LastActionUserId operators
        /// </summary>
		public DropDownList OperatorsForLastActionUserId {
			get { return operatorsForLastActionUserId; }
			set { operatorsForLastActionUserId = value; }
		}
		
		#endregion Control Properties
		
		#region Control Events
		
		/// <summary>
        /// Initialization
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnInit( EventArgs args )
		{
			base.OnInit(args);
			EnsureChildControls();
			button.Text = "Search";
		}
		
		/// <summary>
        /// Control actions
        /// </summary>
        /// <param name="args">Arguments</param>
		protected override void OnLoad( EventArgs args )
		{
			base.OnLoad(args);
			if( Page.IsPostBack ) {
				StringWriter writer = new StringWriter();
				bool first = true;
				
				if( !string.IsNullOrEmpty( Id.Text ) ) {
					writer.Write( "{2} e.Id {0} '{1}' ",
							operatorsForId.SelectedValue, 
							Id.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Name.Text ) ) {
					writer.Write( "{2} e.Name {0} '{1}' ",
							operatorsForName.SelectedValue, 
							Name.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Message.Text ) ) {
					writer.Write( "{2} e.Message {0} '{1}' ",
							operatorsForMessage.SelectedValue, 
							Message.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Date.Text ) ) {
					writer.Write( "{2} e.Date {0} '{1}' ",
							operatorsForDate.SelectedValue, 
							Date.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Url.Text ) ) {
					writer.Write( "{2} e.Url {0} '{1}' ",
							operatorsForUrl.SelectedValue, 
							Url.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StackTrace.Text ) ) {
					writer.Write( "{2} e.StackTrace {0} '{1}' ",
							operatorsForStackTrace.SelectedValue, 
							StackTrace.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreatedDate.Text ) ) {
					writer.Write( "{2} e.CreatedDate {0} '{1}' ",
							operatorsForCreatedDate.SelectedValue, 
							CreatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UpdatedDate.Text ) ) {
					writer.Write( "{2} e.UpdatedDate {0} '{1}' ",
							operatorsForUpdatedDate.SelectedValue, 
							UpdatedDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastActionUserId.Text ) ) {
					writer.Write( "{2} e.LastActionUserId {0} '{1}' ",
							operatorsForLastActionUserId.SelectedValue, 
							LastActionUserId.Text, first ? "" : ","
						);
					first = false;
				}

				string search = writer.ToString();
				if( !string.IsNullOrEmpty(search) ) {
					HttpContext.Current.Items[BasePagedList<ExceptionInfo>.GetWhereKey("ExceptionInfo")] = writer.ToString();
				}
			}
		}
		
		/// <summary>
        /// Creates the control tree
        /// </summary>
		protected override void CreateChildControls()
        {
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th>Field</th><th>Operator</th><th>Search</th></tr>") );
			Id.ID = "searchId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Id</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Id );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			Message.ID = "searchMessage";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Message</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMessage ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Message );
			Controls.Add( new LiteralControl("</td><tr>") );
			Date.ID = "searchDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Date</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Date );
			Controls.Add( new LiteralControl("</td><tr>") );
			Url.ID = "searchUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Url</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Url );
			Controls.Add( new LiteralControl("</td><tr>") );
			StackTrace.ID = "searchStackTrace";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StackTrace</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStackTrace ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StackTrace );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreatedDate.ID = "searchCreatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			UpdatedDate.ID = "searchUpdatedDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UpdatedDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUpdatedDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UpdatedDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastActionUserId.ID = "searchLastActionUserId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastActionUserId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastActionUserId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastActionUserId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Controls.Add( new LiteralControl("<tr><td></td><td></td><td>") );
			Controls.Add( button );
			Controls.Add( new LiteralControl("</td></tr>") );
			Controls.Add( new LiteralControl("</table>") );
        }
		
		#endregion Control Events
		
		#region Utilities
		
		/// <summary>
        /// Adds Search operators
        /// </summary>
        /// <param name="list">The Target List</param>
        /// <returns>The target list</returns>
		private DropDownList AddOperators( DropDownList list )
		{
			list.Items.Add( "=" );
			list.Items.Add( "!=" );
			list.Items.Add( "<" );
			list.Items.Add( ">" );
			list.Items.Add( "<=" );
			list.Items.Add( ">=" );
			list.Items.Add( "like" );
			list.Items.Add( "not like" );
			
			return list;
		}
		
		#endregion Utilities
	
	};

}
