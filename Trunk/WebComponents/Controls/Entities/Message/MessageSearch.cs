
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
    /// Control that enables Message search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a MessagePagedList
    /// </remarks>
	public class MessageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox parameters = new TextBox();
		protected DropDownList operatorsForParameters = new DropDownList();
		protected TextBox category = new TextBox();
		protected DropDownList operatorsForCategory = new DropDownList();
		protected TextBox subCategory = new TextBox();
		protected DropDownList operatorsForSubCategory = new DropDownList();
		protected TextBox ownerId = new TextBox();
		protected DropDownList operatorsForOwnerId = new DropDownList();
		protected TextBox date = new TextBox();
		protected DropDownList operatorsForDate = new DropDownList();
		protected TextBox extended = new TextBox();
		protected DropDownList operatorsForExtended = new DropDownList();
		protected TextBox tickDeadline = new TextBox();
		protected DropDownList operatorsForTickDeadline = new DropDownList();
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
        /// Search box for Message's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Message's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Message's Parameters property
        /// </summary>
		public TextBox Parameters {
			get { return parameters; }
			set { parameters = value; }
		}
		
		/// <summary>
        /// Combo box for Message's Parameters operators
        /// </summary>
		public DropDownList OperatorsForParameters {
			get { return operatorsForParameters; }
			set { operatorsForParameters = value; }
		}
		
		/// <summary>
        /// Search box for Message's Category property
        /// </summary>
		public TextBox Category {
			get { return category; }
			set { category = value; }
		}
		
		/// <summary>
        /// Combo box for Message's Category operators
        /// </summary>
		public DropDownList OperatorsForCategory {
			get { return operatorsForCategory; }
			set { operatorsForCategory = value; }
		}
		
		/// <summary>
        /// Search box for Message's SubCategory property
        /// </summary>
		public TextBox SubCategory {
			get { return subCategory; }
			set { subCategory = value; }
		}
		
		/// <summary>
        /// Combo box for Message's SubCategory operators
        /// </summary>
		public DropDownList OperatorsForSubCategory {
			get { return operatorsForSubCategory; }
			set { operatorsForSubCategory = value; }
		}
		
		/// <summary>
        /// Search box for Message's OwnerId property
        /// </summary>
		public TextBox OwnerId {
			get { return ownerId; }
			set { ownerId = value; }
		}
		
		/// <summary>
        /// Combo box for Message's OwnerId operators
        /// </summary>
		public DropDownList OperatorsForOwnerId {
			get { return operatorsForOwnerId; }
			set { operatorsForOwnerId = value; }
		}
		
		/// <summary>
        /// Search box for Message's Date property
        /// </summary>
		public TextBox Date {
			get { return date; }
			set { date = value; }
		}
		
		/// <summary>
        /// Combo box for Message's Date operators
        /// </summary>
		public DropDownList OperatorsForDate {
			get { return operatorsForDate; }
			set { operatorsForDate = value; }
		}
		
		/// <summary>
        /// Search box for Message's Extended property
        /// </summary>
		public TextBox Extended {
			get { return extended; }
			set { extended = value; }
		}
		
		/// <summary>
        /// Combo box for Message's Extended operators
        /// </summary>
		public DropDownList OperatorsForExtended {
			get { return operatorsForExtended; }
			set { operatorsForExtended = value; }
		}
		
		/// <summary>
        /// Search box for Message's TickDeadline property
        /// </summary>
		public TextBox TickDeadline {
			get { return tickDeadline; }
			set { tickDeadline = value; }
		}
		
		/// <summary>
        /// Combo box for Message's TickDeadline operators
        /// </summary>
		public DropDownList OperatorsForTickDeadline {
			get { return operatorsForTickDeadline; }
			set { operatorsForTickDeadline = value; }
		}
		
		/// <summary>
        /// Search box for Message's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Message's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Message's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Message's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Message's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Message's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Parameters.Text ) ) {
					writer.Write( "{2} e.Parameters {0} '{1}' ",
							operatorsForParameters.SelectedValue, 
							Parameters.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Category.Text ) ) {
					writer.Write( "{2} e.Category {0} '{1}' ",
							operatorsForCategory.SelectedValue, 
							Category.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SubCategory.Text ) ) {
					writer.Write( "{2} e.SubCategory {0} '{1}' ",
							operatorsForSubCategory.SelectedValue, 
							SubCategory.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( OwnerId.Text ) ) {
					writer.Write( "{2} e.OwnerId {0} '{1}' ",
							operatorsForOwnerId.SelectedValue, 
							OwnerId.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Extended.Text ) ) {
					writer.Write( "{2} e.Extended {0} '{1}' ",
							operatorsForExtended.SelectedValue, 
							Extended.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TickDeadline.Text ) ) {
					writer.Write( "{2} e.TickDeadline {0} '{1}' ",
							operatorsForTickDeadline.SelectedValue, 
							TickDeadline.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Message>.GetWhereKey("Message")] = writer.ToString();
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
			Parameters.ID = "searchParameters";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Parameters</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForParameters ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Parameters );
			Controls.Add( new LiteralControl("</td><tr>") );
			Category.ID = "searchCategory";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Category</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCategory ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Category );
			Controls.Add( new LiteralControl("</td><tr>") );
			SubCategory.ID = "searchSubCategory";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SubCategory</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSubCategory ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SubCategory );
			Controls.Add( new LiteralControl("</td><tr>") );
			OwnerId.ID = "searchOwnerId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>OwnerId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOwnerId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( OwnerId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Date.ID = "searchDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Date</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Date );
			Controls.Add( new LiteralControl("</td><tr>") );
			Extended.ID = "searchExtended";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Extended</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForExtended ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Extended );
			Controls.Add( new LiteralControl("</td><tr>") );
			TickDeadline.ID = "searchTickDeadline";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TickDeadline</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTickDeadline ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TickDeadline );
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
