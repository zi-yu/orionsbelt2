
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
    /// Control that enables Necessity search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a NecessityPagedList
    /// </remarks>
	public class NecessitySearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox description = new TextBox();
		protected DropDownList operatorsForDescription = new DropDownList();
		protected TextBox coordinate = new TextBox();
		protected DropDownList operatorsForCoordinate = new DropDownList();
		protected TextBox status = new TextBox();
		protected DropDownList operatorsForStatus = new DropDownList();
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
        /// Search box for Necessity's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's Description property
        /// </summary>
		public TextBox Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's Description operators
        /// </summary>
		public DropDownList OperatorsForDescription {
			get { return operatorsForDescription; }
			set { operatorsForDescription = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's Coordinate property
        /// </summary>
		public TextBox Coordinate {
			get { return coordinate; }
			set { coordinate = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's Coordinate operators
        /// </summary>
		public DropDownList OperatorsForCoordinate {
			get { return operatorsForCoordinate; }
			set { operatorsForCoordinate = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's Status property
        /// </summary>
		public TextBox Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's Status operators
        /// </summary>
		public DropDownList OperatorsForStatus {
			get { return operatorsForStatus; }
			set { operatorsForStatus = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Necessity's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Necessity's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Coordinate.Text ) ) {
					writer.Write( "{2} e.Coordinate {0} '{1}' ",
							operatorsForCoordinate.SelectedValue, 
							Coordinate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Status.Text ) ) {
					writer.Write( "{2} e.Status {0} '{1}' ",
							operatorsForStatus.SelectedValue, 
							Status.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Necessity>.GetWhereKey("Necessity")] = writer.ToString();
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
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			Description.ID = "searchDescription";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Description</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDescription ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Description );
			Controls.Add( new LiteralControl("</td><tr>") );
			Coordinate.ID = "searchCoordinate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Coordinate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCoordinate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Coordinate );
			Controls.Add( new LiteralControl("</td><tr>") );
			Status.ID = "searchStatus";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Status</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStatus ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Status );
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
