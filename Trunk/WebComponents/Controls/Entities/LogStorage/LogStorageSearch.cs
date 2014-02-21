
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
    /// Control that enables LogStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a LogStoragePagedList
    /// </remarks>
	public class LogStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox date = new TextBox();
		protected DropDownList operatorsForDate = new DropDownList();
		protected TextBox username1 = new TextBox();
		protected DropDownList operatorsForUsername1 = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
		protected TextBox url = new TextBox();
		protected DropDownList operatorsForUrl = new DropDownList();
		protected TextBox content = new TextBox();
		protected DropDownList operatorsForContent = new DropDownList();
		protected TextBox exceptionInformation = new TextBox();
		protected DropDownList operatorsForExceptionInformation = new DropDownList();
		protected TextBox ip = new TextBox();
		protected DropDownList operatorsForIp = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox username2 = new TextBox();
		protected DropDownList operatorsForUsername2 = new DropDownList();
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
        /// Search box for LogStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Date property
        /// </summary>
		public TextBox Date {
			get { return date; }
			set { date = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Date operators
        /// </summary>
		public DropDownList OperatorsForDate {
			get { return operatorsForDate; }
			set { operatorsForDate = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Username1 property
        /// </summary>
		public TextBox Username1 {
			get { return username1; }
			set { username1 = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Username1 operators
        /// </summary>
		public DropDownList OperatorsForUsername1 {
			get { return operatorsForUsername1; }
			set { operatorsForUsername1 = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Url property
        /// </summary>
		public TextBox Url {
			get { return url; }
			set { url = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Url operators
        /// </summary>
		public DropDownList OperatorsForUrl {
			get { return operatorsForUrl; }
			set { operatorsForUrl = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Content property
        /// </summary>
		public TextBox Content {
			get { return content; }
			set { content = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Content operators
        /// </summary>
		public DropDownList OperatorsForContent {
			get { return operatorsForContent; }
			set { operatorsForContent = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's ExceptionInformation property
        /// </summary>
		public TextBox ExceptionInformation {
			get { return exceptionInformation; }
			set { exceptionInformation = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's ExceptionInformation operators
        /// </summary>
		public DropDownList OperatorsForExceptionInformation {
			get { return operatorsForExceptionInformation; }
			set { operatorsForExceptionInformation = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Ip property
        /// </summary>
		public TextBox Ip {
			get { return ip; }
			set { ip = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Ip operators
        /// </summary>
		public DropDownList OperatorsForIp {
			get { return operatorsForIp; }
			set { operatorsForIp = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's Username2 property
        /// </summary>
		public TextBox Username2 {
			get { return username2; }
			set { username2 = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's Username2 operators
        /// </summary>
		public DropDownList OperatorsForUsername2 {
			get { return operatorsForUsername2; }
			set { operatorsForUsername2 = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for LogStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for LogStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Date.Text ) ) {
					writer.Write( "{2} e.Date {0} '{1}' ",
							operatorsForDate.SelectedValue, 
							Date.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Username1.Text ) ) {
					writer.Write( "{2} e.Username1 {0} '{1}' ",
							operatorsForUsername1.SelectedValue, 
							Username1.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Level.Text ) ) {
					writer.Write( "{2} e.Level {0} '{1}' ",
							operatorsForLevel.SelectedValue, 
							Level.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Content.Text ) ) {
					writer.Write( "{2} e.Content {0} '{1}' ",
							operatorsForContent.SelectedValue, 
							Content.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ExceptionInformation.Text ) ) {
					writer.Write( "{2} e.ExceptionInformation {0} '{1}' ",
							operatorsForExceptionInformation.SelectedValue, 
							ExceptionInformation.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Ip.Text ) ) {
					writer.Write( "{2} e.Ip {0} '{1}' ",
							operatorsForIp.SelectedValue, 
							Ip.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Username2.Text ) ) {
					writer.Write( "{2} e.Username2 {0} '{1}' ",
							operatorsForUsername2.SelectedValue, 
							Username2.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<LogStorage>.GetWhereKey("LogStorage")] = writer.ToString();
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
			Date.ID = "searchDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Date</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Date );
			Controls.Add( new LiteralControl("</td><tr>") );
			Username1.ID = "searchUsername1";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Username1</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUsername1 ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Username1 );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
			Controls.Add( new LiteralControl("</td><tr>") );
			Url.ID = "searchUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Url</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Url );
			Controls.Add( new LiteralControl("</td><tr>") );
			Content.ID = "searchContent";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Content</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForContent ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Content );
			Controls.Add( new LiteralControl("</td><tr>") );
			ExceptionInformation.ID = "searchExceptionInformation";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ExceptionInformation</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForExceptionInformation ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ExceptionInformation );
			Controls.Add( new LiteralControl("</td><tr>") );
			Ip.ID = "searchIp";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Ip</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIp ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Ip );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			Username2.ID = "searchUsername2";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Username2</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUsername2 ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Username2 );
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
