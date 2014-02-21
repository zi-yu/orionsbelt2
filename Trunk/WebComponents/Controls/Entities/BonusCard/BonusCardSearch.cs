
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
    /// Control that enables BonusCard search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a BonusCardPagedList
    /// </remarks>
	public class BonusCardSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox code = new TextBox();
		protected DropDownList operatorsForCode = new DropDownList();
		protected TextBox orions = new TextBox();
		protected DropDownList operatorsForOrions = new DropDownList();
		protected TextBox used = new TextBox();
		protected DropDownList operatorsForUsed = new DropDownList();
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
        /// Search box for BonusCard's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's Code property
        /// </summary>
		public TextBox Code {
			get { return code; }
			set { code = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's Code operators
        /// </summary>
		public DropDownList OperatorsForCode {
			get { return operatorsForCode; }
			set { operatorsForCode = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's Orions property
        /// </summary>
		public TextBox Orions {
			get { return orions; }
			set { orions = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's Orions operators
        /// </summary>
		public DropDownList OperatorsForOrions {
			get { return operatorsForOrions; }
			set { operatorsForOrions = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's Used property
        /// </summary>
		public TextBox Used {
			get { return used; }
			set { used = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's Used operators
        /// </summary>
		public DropDownList OperatorsForUsed {
			get { return operatorsForUsed; }
			set { operatorsForUsed = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for BonusCard's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for BonusCard's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Code.Text ) ) {
					writer.Write( "{2} e.Code {0} '{1}' ",
							operatorsForCode.SelectedValue, 
							Code.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Orions.Text ) ) {
					writer.Write( "{2} e.Orions {0} '{1}' ",
							operatorsForOrions.SelectedValue, 
							Orions.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Used.Text ) ) {
					writer.Write( "{2} e.Used {0} '{1}' ",
							operatorsForUsed.SelectedValue, 
							Used.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<BonusCard>.GetWhereKey("BonusCard")] = writer.ToString();
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
			Code.ID = "searchCode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Code</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Code );
			Controls.Add( new LiteralControl("</td><tr>") );
			Orions.ID = "searchOrions";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Orions</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOrions ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Orions );
			Controls.Add( new LiteralControl("</td><tr>") );
			Used.ID = "searchUsed";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Used</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUsed ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Used );
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
