
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
    /// Control that enables SpecialEvent search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a SpecialEventPagedList
    /// </remarks>
	public class SpecialEventSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox cost = new TextBox();
		protected DropDownList operatorsForCost = new DropDownList();
		protected TextBox token = new TextBox();
		protected DropDownList operatorsForToken = new DropDownList();
		protected TextBox resorces = new TextBox();
		protected DropDownList operatorsForResorces = new DropDownList();
		protected TextBox beginDate = new TextBox();
		protected DropDownList operatorsForBeginDate = new DropDownList();
		protected TextBox endDate = new TextBox();
		protected DropDownList operatorsForEndDate = new DropDownList();
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
        /// Search box for SpecialEvent's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's Cost property
        /// </summary>
		public TextBox Cost {
			get { return cost; }
			set { cost = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's Cost operators
        /// </summary>
		public DropDownList OperatorsForCost {
			get { return operatorsForCost; }
			set { operatorsForCost = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's Token property
        /// </summary>
		public TextBox Token {
			get { return token; }
			set { token = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's Token operators
        /// </summary>
		public DropDownList OperatorsForToken {
			get { return operatorsForToken; }
			set { operatorsForToken = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's Resorces property
        /// </summary>
		public TextBox Resorces {
			get { return resorces; }
			set { resorces = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's Resorces operators
        /// </summary>
		public DropDownList OperatorsForResorces {
			get { return operatorsForResorces; }
			set { operatorsForResorces = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's BeginDate property
        /// </summary>
		public TextBox BeginDate {
			get { return beginDate; }
			set { beginDate = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's BeginDate operators
        /// </summary>
		public DropDownList OperatorsForBeginDate {
			get { return operatorsForBeginDate; }
			set { operatorsForBeginDate = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's EndDate property
        /// </summary>
		public TextBox EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's EndDate operators
        /// </summary>
		public DropDownList OperatorsForEndDate {
			get { return operatorsForEndDate; }
			set { operatorsForEndDate = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for SpecialEvent's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for SpecialEvent's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Cost.Text ) ) {
					writer.Write( "{2} e.Cost {0} '{1}' ",
							operatorsForCost.SelectedValue, 
							Cost.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Token.Text ) ) {
					writer.Write( "{2} e.Token {0} '{1}' ",
							operatorsForToken.SelectedValue, 
							Token.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Resorces.Text ) ) {
					writer.Write( "{2} e.Resorces {0} '{1}' ",
							operatorsForResorces.SelectedValue, 
							Resorces.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BeginDate.Text ) ) {
					writer.Write( "{2} e.BeginDate {0} '{1}' ",
							operatorsForBeginDate.SelectedValue, 
							BeginDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( EndDate.Text ) ) {
					writer.Write( "{2} e.EndDate {0} '{1}' ",
							operatorsForEndDate.SelectedValue, 
							EndDate.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<SpecialEvent>.GetWhereKey("SpecialEvent")] = writer.ToString();
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
			Cost.ID = "searchCost";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Cost</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCost ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Cost );
			Controls.Add( new LiteralControl("</td><tr>") );
			Token.ID = "searchToken";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Token</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForToken ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Token );
			Controls.Add( new LiteralControl("</td><tr>") );
			Resorces.ID = "searchResorces";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Resorces</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForResorces ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Resorces );
			Controls.Add( new LiteralControl("</td><tr>") );
			BeginDate.ID = "searchBeginDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BeginDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBeginDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BeginDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			EndDate.ID = "searchEndDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EndDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEndDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EndDate );
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
