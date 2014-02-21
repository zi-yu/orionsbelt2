
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
    /// Control that enables ForumThread search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ForumThreadPagedList
    /// </remarks>
	public class ForumThreadSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox title = new TextBox();
		protected DropDownList operatorsForTitle = new DropDownList();
		protected TextBox totalViews = new TextBox();
		protected DropDownList operatorsForTotalViews = new DropDownList();
		protected TextBox totalReplies = new TextBox();
		protected DropDownList operatorsForTotalReplies = new DropDownList();
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
        /// Search box for ForumThread's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's Title property
        /// </summary>
		public TextBox Title {
			get { return title; }
			set { title = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's Title operators
        /// </summary>
		public DropDownList OperatorsForTitle {
			get { return operatorsForTitle; }
			set { operatorsForTitle = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's TotalViews property
        /// </summary>
		public TextBox TotalViews {
			get { return totalViews; }
			set { totalViews = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's TotalViews operators
        /// </summary>
		public DropDownList OperatorsForTotalViews {
			get { return operatorsForTotalViews; }
			set { operatorsForTotalViews = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's TotalReplies property
        /// </summary>
		public TextBox TotalReplies {
			get { return totalReplies; }
			set { totalReplies = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's TotalReplies operators
        /// </summary>
		public DropDownList OperatorsForTotalReplies {
			get { return operatorsForTotalReplies; }
			set { operatorsForTotalReplies = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ForumThread's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ForumThread's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Title.Text ) ) {
					writer.Write( "{2} e.Title {0} '{1}' ",
							operatorsForTitle.SelectedValue, 
							Title.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalViews.Text ) ) {
					writer.Write( "{2} e.TotalViews {0} '{1}' ",
							operatorsForTotalViews.SelectedValue, 
							TotalViews.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalReplies.Text ) ) {
					writer.Write( "{2} e.TotalReplies {0} '{1}' ",
							operatorsForTotalReplies.SelectedValue, 
							TotalReplies.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<ForumThread>.GetWhereKey("ForumThread")] = writer.ToString();
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
			Title.ID = "searchTitle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Title</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTitle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Title );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalViews.ID = "searchTotalViews";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalViews</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalViews ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalViews );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalReplies.ID = "searchTotalReplies";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalReplies</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalReplies ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalReplies );
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
