
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
    /// Control that enables ForumTopic search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ForumTopicPagedList
    /// </remarks>
	public class ForumTopicSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox title = new TextBox();
		protected DropDownList operatorsForTitle = new DropDownList();
		protected TextBox lastPost = new TextBox();
		protected DropDownList operatorsForLastPost = new DropDownList();
		protected TextBox totalPosts = new TextBox();
		protected DropDownList operatorsForTotalPosts = new DropDownList();
		protected TextBox totalThreads = new TextBox();
		protected DropDownList operatorsForTotalThreads = new DropDownList();
		protected TextBox isPrivate = new TextBox();
		protected DropDownList operatorsForIsPrivate = new DropDownList();
		protected TextBox forumRoles = new TextBox();
		protected DropDownList operatorsForForumRoles = new DropDownList();
		protected TextBox description = new TextBox();
		protected DropDownList operatorsForDescription = new DropDownList();
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
        /// Search box for ForumTopic's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's Title property
        /// </summary>
		public TextBox Title {
			get { return title; }
			set { title = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's Title operators
        /// </summary>
		public DropDownList OperatorsForTitle {
			get { return operatorsForTitle; }
			set { operatorsForTitle = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's LastPost property
        /// </summary>
		public TextBox LastPost {
			get { return lastPost; }
			set { lastPost = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's LastPost operators
        /// </summary>
		public DropDownList OperatorsForLastPost {
			get { return operatorsForLastPost; }
			set { operatorsForLastPost = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's TotalPosts property
        /// </summary>
		public TextBox TotalPosts {
			get { return totalPosts; }
			set { totalPosts = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's TotalPosts operators
        /// </summary>
		public DropDownList OperatorsForTotalPosts {
			get { return operatorsForTotalPosts; }
			set { operatorsForTotalPosts = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's TotalThreads property
        /// </summary>
		public TextBox TotalThreads {
			get { return totalThreads; }
			set { totalThreads = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's TotalThreads operators
        /// </summary>
		public DropDownList OperatorsForTotalThreads {
			get { return operatorsForTotalThreads; }
			set { operatorsForTotalThreads = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's IsPrivate property
        /// </summary>
		public TextBox IsPrivate {
			get { return isPrivate; }
			set { isPrivate = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's IsPrivate operators
        /// </summary>
		public DropDownList OperatorsForIsPrivate {
			get { return operatorsForIsPrivate; }
			set { operatorsForIsPrivate = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's ForumRoles property
        /// </summary>
		public TextBox ForumRoles {
			get { return forumRoles; }
			set { forumRoles = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's ForumRoles operators
        /// </summary>
		public DropDownList OperatorsForForumRoles {
			get { return operatorsForForumRoles; }
			set { operatorsForForumRoles = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's Description property
        /// </summary>
		public TextBox Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's Description operators
        /// </summary>
		public DropDownList OperatorsForDescription {
			get { return operatorsForDescription; }
			set { operatorsForDescription = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ForumTopic's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ForumTopic's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( LastPost.Text ) ) {
					writer.Write( "{2} e.LastPost {0} '{1}' ",
							operatorsForLastPost.SelectedValue, 
							LastPost.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalPosts.Text ) ) {
					writer.Write( "{2} e.TotalPosts {0} '{1}' ",
							operatorsForTotalPosts.SelectedValue, 
							TotalPosts.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalThreads.Text ) ) {
					writer.Write( "{2} e.TotalThreads {0} '{1}' ",
							operatorsForTotalThreads.SelectedValue, 
							TotalThreads.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsPrivate.Text ) ) {
					writer.Write( "{2} e.IsPrivate {0} '{1}' ",
							operatorsForIsPrivate.SelectedValue, 
							IsPrivate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ForumRoles.Text ) ) {
					writer.Write( "{2} e.ForumRoles {0} '{1}' ",
							operatorsForForumRoles.SelectedValue, 
							ForumRoles.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Description.Text ) ) {
					writer.Write( "{2} e.Description {0} '{1}' ",
							operatorsForDescription.SelectedValue, 
							Description.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<ForumTopic>.GetWhereKey("ForumTopic")] = writer.ToString();
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
			LastPost.ID = "searchLastPost";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastPost</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastPost ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastPost );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalPosts.ID = "searchTotalPosts";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalPosts</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalPosts ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalPosts );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalThreads.ID = "searchTotalThreads";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalThreads</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalThreads ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalThreads );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsPrivate.ID = "searchIsPrivate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsPrivate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsPrivate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsPrivate );
			Controls.Add( new LiteralControl("</td><tr>") );
			ForumRoles.ID = "searchForumRoles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ForumRoles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForForumRoles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ForumRoles );
			Controls.Add( new LiteralControl("</td><tr>") );
			Description.ID = "searchDescription";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Description</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDescription ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Description );
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
