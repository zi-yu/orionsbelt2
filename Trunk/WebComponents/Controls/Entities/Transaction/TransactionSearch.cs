
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
    /// Control that enables Transaction search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a TransactionPagedList
    /// </remarks>
	public class TransactionSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox transactionContext = new TextBox();
		protected DropDownList operatorsForTransactionContext = new DropDownList();
		protected TextBox principalIdSpend = new TextBox();
		protected DropDownList operatorsForPrincipalIdSpend = new DropDownList();
		protected TextBox identityTypeSpend = new TextBox();
		protected DropDownList operatorsForIdentityTypeSpend = new DropDownList();
		protected TextBox identifierSpend = new TextBox();
		protected DropDownList operatorsForIdentifierSpend = new DropDownList();
		protected TextBox creditsSpend = new TextBox();
		protected DropDownList operatorsForCreditsSpend = new DropDownList();
		protected TextBox spendCurrentCredits = new TextBox();
		protected DropDownList operatorsForSpendCurrentCredits = new DropDownList();
		protected TextBox identityTypeGain = new TextBox();
		protected DropDownList operatorsForIdentityTypeGain = new DropDownList();
		protected TextBox identifierGain = new TextBox();
		protected DropDownList operatorsForIdentifierGain = new DropDownList();
		protected TextBox creditsGain = new TextBox();
		protected DropDownList operatorsForCreditsGain = new DropDownList();
		protected TextBox gainCurrentCredits = new TextBox();
		protected DropDownList operatorsForGainCurrentCredits = new DropDownList();
		protected TextBox tick = new TextBox();
		protected DropDownList operatorsForTick = new DropDownList();
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
        /// Search box for Transaction's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's TransactionContext property
        /// </summary>
		public TextBox TransactionContext {
			get { return transactionContext; }
			set { transactionContext = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's TransactionContext operators
        /// </summary>
		public DropDownList OperatorsForTransactionContext {
			get { return operatorsForTransactionContext; }
			set { operatorsForTransactionContext = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's PrincipalIdSpend property
        /// </summary>
		public TextBox PrincipalIdSpend {
			get { return principalIdSpend; }
			set { principalIdSpend = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's PrincipalIdSpend operators
        /// </summary>
		public DropDownList OperatorsForPrincipalIdSpend {
			get { return operatorsForPrincipalIdSpend; }
			set { operatorsForPrincipalIdSpend = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's IdentityTypeSpend property
        /// </summary>
		public TextBox IdentityTypeSpend {
			get { return identityTypeSpend; }
			set { identityTypeSpend = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's IdentityTypeSpend operators
        /// </summary>
		public DropDownList OperatorsForIdentityTypeSpend {
			get { return operatorsForIdentityTypeSpend; }
			set { operatorsForIdentityTypeSpend = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's IdentifierSpend property
        /// </summary>
		public TextBox IdentifierSpend {
			get { return identifierSpend; }
			set { identifierSpend = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's IdentifierSpend operators
        /// </summary>
		public DropDownList OperatorsForIdentifierSpend {
			get { return operatorsForIdentifierSpend; }
			set { operatorsForIdentifierSpend = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's CreditsSpend property
        /// </summary>
		public TextBox CreditsSpend {
			get { return creditsSpend; }
			set { creditsSpend = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's CreditsSpend operators
        /// </summary>
		public DropDownList OperatorsForCreditsSpend {
			get { return operatorsForCreditsSpend; }
			set { operatorsForCreditsSpend = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's SpendCurrentCredits property
        /// </summary>
		public TextBox SpendCurrentCredits {
			get { return spendCurrentCredits; }
			set { spendCurrentCredits = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's SpendCurrentCredits operators
        /// </summary>
		public DropDownList OperatorsForSpendCurrentCredits {
			get { return operatorsForSpendCurrentCredits; }
			set { operatorsForSpendCurrentCredits = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's IdentityTypeGain property
        /// </summary>
		public TextBox IdentityTypeGain {
			get { return identityTypeGain; }
			set { identityTypeGain = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's IdentityTypeGain operators
        /// </summary>
		public DropDownList OperatorsForIdentityTypeGain {
			get { return operatorsForIdentityTypeGain; }
			set { operatorsForIdentityTypeGain = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's IdentifierGain property
        /// </summary>
		public TextBox IdentifierGain {
			get { return identifierGain; }
			set { identifierGain = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's IdentifierGain operators
        /// </summary>
		public DropDownList OperatorsForIdentifierGain {
			get { return operatorsForIdentifierGain; }
			set { operatorsForIdentifierGain = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's CreditsGain property
        /// </summary>
		public TextBox CreditsGain {
			get { return creditsGain; }
			set { creditsGain = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's CreditsGain operators
        /// </summary>
		public DropDownList OperatorsForCreditsGain {
			get { return operatorsForCreditsGain; }
			set { operatorsForCreditsGain = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's GainCurrentCredits property
        /// </summary>
		public TextBox GainCurrentCredits {
			get { return gainCurrentCredits; }
			set { gainCurrentCredits = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's GainCurrentCredits operators
        /// </summary>
		public DropDownList OperatorsForGainCurrentCredits {
			get { return operatorsForGainCurrentCredits; }
			set { operatorsForGainCurrentCredits = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's Tick property
        /// </summary>
		public TextBox Tick {
			get { return tick; }
			set { tick = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's Tick operators
        /// </summary>
		public DropDownList OperatorsForTick {
			get { return operatorsForTick; }
			set { operatorsForTick = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Transaction's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Transaction's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( TransactionContext.Text ) ) {
					writer.Write( "{2} e.TransactionContext {0} '{1}' ",
							operatorsForTransactionContext.SelectedValue, 
							TransactionContext.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PrincipalIdSpend.Text ) ) {
					writer.Write( "{2} e.PrincipalIdSpend {0} '{1}' ",
							operatorsForPrincipalIdSpend.SelectedValue, 
							PrincipalIdSpend.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IdentityTypeSpend.Text ) ) {
					writer.Write( "{2} e.IdentityTypeSpend {0} '{1}' ",
							operatorsForIdentityTypeSpend.SelectedValue, 
							IdentityTypeSpend.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IdentifierSpend.Text ) ) {
					writer.Write( "{2} e.IdentifierSpend {0} '{1}' ",
							operatorsForIdentifierSpend.SelectedValue, 
							IdentifierSpend.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreditsSpend.Text ) ) {
					writer.Write( "{2} e.CreditsSpend {0} '{1}' ",
							operatorsForCreditsSpend.SelectedValue, 
							CreditsSpend.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SpendCurrentCredits.Text ) ) {
					writer.Write( "{2} e.SpendCurrentCredits {0} '{1}' ",
							operatorsForSpendCurrentCredits.SelectedValue, 
							SpendCurrentCredits.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IdentityTypeGain.Text ) ) {
					writer.Write( "{2} e.IdentityTypeGain {0} '{1}' ",
							operatorsForIdentityTypeGain.SelectedValue, 
							IdentityTypeGain.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IdentifierGain.Text ) ) {
					writer.Write( "{2} e.IdentifierGain {0} '{1}' ",
							operatorsForIdentifierGain.SelectedValue, 
							IdentifierGain.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CreditsGain.Text ) ) {
					writer.Write( "{2} e.CreditsGain {0} '{1}' ",
							operatorsForCreditsGain.SelectedValue, 
							CreditsGain.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GainCurrentCredits.Text ) ) {
					writer.Write( "{2} e.GainCurrentCredits {0} '{1}' ",
							operatorsForGainCurrentCredits.SelectedValue, 
							GainCurrentCredits.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Tick.Text ) ) {
					writer.Write( "{2} e.Tick {0} '{1}' ",
							operatorsForTick.SelectedValue, 
							Tick.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Transaction>.GetWhereKey("Transaction")] = writer.ToString();
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
			TransactionContext.ID = "searchTransactionContext";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TransactionContext</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTransactionContext ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TransactionContext );
			Controls.Add( new LiteralControl("</td><tr>") );
			PrincipalIdSpend.ID = "searchPrincipalIdSpend";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PrincipalIdSpend</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPrincipalIdSpend ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PrincipalIdSpend );
			Controls.Add( new LiteralControl("</td><tr>") );
			IdentityTypeSpend.ID = "searchIdentityTypeSpend";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IdentityTypeSpend</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIdentityTypeSpend ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IdentityTypeSpend );
			Controls.Add( new LiteralControl("</td><tr>") );
			IdentifierSpend.ID = "searchIdentifierSpend";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IdentifierSpend</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIdentifierSpend ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IdentifierSpend );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreditsSpend.ID = "searchCreditsSpend";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreditsSpend</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreditsSpend ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreditsSpend );
			Controls.Add( new LiteralControl("</td><tr>") );
			SpendCurrentCredits.ID = "searchSpendCurrentCredits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SpendCurrentCredits</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSpendCurrentCredits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SpendCurrentCredits );
			Controls.Add( new LiteralControl("</td><tr>") );
			IdentityTypeGain.ID = "searchIdentityTypeGain";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IdentityTypeGain</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIdentityTypeGain ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IdentityTypeGain );
			Controls.Add( new LiteralControl("</td><tr>") );
			IdentifierGain.ID = "searchIdentifierGain";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IdentifierGain</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIdentifierGain ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IdentifierGain );
			Controls.Add( new LiteralControl("</td><tr>") );
			CreditsGain.ID = "searchCreditsGain";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CreditsGain</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCreditsGain ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CreditsGain );
			Controls.Add( new LiteralControl("</td><tr>") );
			GainCurrentCredits.ID = "searchGainCurrentCredits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GainCurrentCredits</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGainCurrentCredits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GainCurrentCredits );
			Controls.Add( new LiteralControl("</td><tr>") );
			Tick.ID = "searchTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Tick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Tick );
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
