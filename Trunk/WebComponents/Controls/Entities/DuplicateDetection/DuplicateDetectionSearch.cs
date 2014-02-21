
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
    /// Control that enables DuplicateDetection search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a DuplicateDetectionPagedList
    /// </remarks>
	public class DuplicateDetectionSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox cheater = new TextBox();
		protected DropDownList operatorsForCheater = new DropDownList();
		protected TextBox duplicate = new TextBox();
		protected DropDownList operatorsForDuplicate = new DropDownList();
		protected TextBox findType = new TextBox();
		protected DropDownList operatorsForFindType = new DropDownList();
		protected TextBox extraInfo = new TextBox();
		protected DropDownList operatorsForExtraInfo = new DropDownList();
		protected TextBox verified = new TextBox();
		protected DropDownList operatorsForVerified = new DropDownList();
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
        /// Search box for DuplicateDetection's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's Cheater property
        /// </summary>
		public TextBox Cheater {
			get { return cheater; }
			set { cheater = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's Cheater operators
        /// </summary>
		public DropDownList OperatorsForCheater {
			get { return operatorsForCheater; }
			set { operatorsForCheater = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's Duplicate property
        /// </summary>
		public TextBox Duplicate {
			get { return duplicate; }
			set { duplicate = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's Duplicate operators
        /// </summary>
		public DropDownList OperatorsForDuplicate {
			get { return operatorsForDuplicate; }
			set { operatorsForDuplicate = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's FindType property
        /// </summary>
		public TextBox FindType {
			get { return findType; }
			set { findType = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's FindType operators
        /// </summary>
		public DropDownList OperatorsForFindType {
			get { return operatorsForFindType; }
			set { operatorsForFindType = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's ExtraInfo property
        /// </summary>
		public TextBox ExtraInfo {
			get { return extraInfo; }
			set { extraInfo = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's ExtraInfo operators
        /// </summary>
		public DropDownList OperatorsForExtraInfo {
			get { return operatorsForExtraInfo; }
			set { operatorsForExtraInfo = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's Verified property
        /// </summary>
		public TextBox Verified {
			get { return verified; }
			set { verified = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's Verified operators
        /// </summary>
		public DropDownList OperatorsForVerified {
			get { return operatorsForVerified; }
			set { operatorsForVerified = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for DuplicateDetection's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for DuplicateDetection's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Cheater.Text ) ) {
					writer.Write( "{2} e.Cheater {0} '{1}' ",
							operatorsForCheater.SelectedValue, 
							Cheater.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Duplicate.Text ) ) {
					writer.Write( "{2} e.Duplicate {0} '{1}' ",
							operatorsForDuplicate.SelectedValue, 
							Duplicate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( FindType.Text ) ) {
					writer.Write( "{2} e.FindType {0} '{1}' ",
							operatorsForFindType.SelectedValue, 
							FindType.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ExtraInfo.Text ) ) {
					writer.Write( "{2} e.ExtraInfo {0} '{1}' ",
							operatorsForExtraInfo.SelectedValue, 
							ExtraInfo.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Verified.Text ) ) {
					writer.Write( "{2} e.Verified {0} '{1}' ",
							operatorsForVerified.SelectedValue, 
							Verified.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<DuplicateDetection>.GetWhereKey("DuplicateDetection")] = writer.ToString();
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
			Cheater.ID = "searchCheater";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Cheater</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCheater ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Cheater );
			Controls.Add( new LiteralControl("</td><tr>") );
			Duplicate.ID = "searchDuplicate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Duplicate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDuplicate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Duplicate );
			Controls.Add( new LiteralControl("</td><tr>") );
			FindType.ID = "searchFindType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>FindType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForFindType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( FindType );
			Controls.Add( new LiteralControl("</td><tr>") );
			ExtraInfo.ID = "searchExtraInfo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ExtraInfo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForExtraInfo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ExtraInfo );
			Controls.Add( new LiteralControl("</td><tr>") );
			Verified.ID = "searchVerified";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Verified</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVerified ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Verified );
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
