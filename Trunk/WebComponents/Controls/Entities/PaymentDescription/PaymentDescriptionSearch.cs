
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
    /// Control that enables PaymentDescription search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PaymentDescriptionPagedList
    /// </remarks>
	public class PaymentDescriptionSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox amount = new TextBox();
		protected DropDownList operatorsForAmount = new DropDownList();
		protected TextBox bonus = new TextBox();
		protected DropDownList operatorsForBonus = new DropDownList();
		protected TextBox cost = new TextBox();
		protected DropDownList operatorsForCost = new DropDownList();
		protected TextBox locale = new TextBox();
		protected DropDownList operatorsForLocale = new DropDownList();
		protected TextBox data = new TextBox();
		protected DropDownList operatorsForData = new DropDownList();
		protected TextBox currency = new TextBox();
		protected DropDownList operatorsForCurrency = new DropDownList();
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
        /// Search box for PaymentDescription's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Amount property
        /// </summary>
		public TextBox Amount {
			get { return amount; }
			set { amount = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Amount operators
        /// </summary>
		public DropDownList OperatorsForAmount {
			get { return operatorsForAmount; }
			set { operatorsForAmount = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Bonus property
        /// </summary>
		public TextBox Bonus {
			get { return bonus; }
			set { bonus = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Bonus operators
        /// </summary>
		public DropDownList OperatorsForBonus {
			get { return operatorsForBonus; }
			set { operatorsForBonus = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Cost property
        /// </summary>
		public TextBox Cost {
			get { return cost; }
			set { cost = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Cost operators
        /// </summary>
		public DropDownList OperatorsForCost {
			get { return operatorsForCost; }
			set { operatorsForCost = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Locale property
        /// </summary>
		public TextBox Locale {
			get { return locale; }
			set { locale = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Locale operators
        /// </summary>
		public DropDownList OperatorsForLocale {
			get { return operatorsForLocale; }
			set { operatorsForLocale = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Data property
        /// </summary>
		public TextBox Data {
			get { return data; }
			set { data = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Data operators
        /// </summary>
		public DropDownList OperatorsForData {
			get { return operatorsForData; }
			set { operatorsForData = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's Currency property
        /// </summary>
		public TextBox Currency {
			get { return currency; }
			set { currency = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's Currency operators
        /// </summary>
		public DropDownList OperatorsForCurrency {
			get { return operatorsForCurrency; }
			set { operatorsForCurrency = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PaymentDescription's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PaymentDescription's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Amount.Text ) ) {
					writer.Write( "{2} e.Amount {0} '{1}' ",
							operatorsForAmount.SelectedValue, 
							Amount.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Bonus.Text ) ) {
					writer.Write( "{2} e.Bonus {0} '{1}' ",
							operatorsForBonus.SelectedValue, 
							Bonus.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Locale.Text ) ) {
					writer.Write( "{2} e.Locale {0} '{1}' ",
							operatorsForLocale.SelectedValue, 
							Locale.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Data.Text ) ) {
					writer.Write( "{2} e.Data {0} '{1}' ",
							operatorsForData.SelectedValue, 
							Data.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Currency.Text ) ) {
					writer.Write( "{2} e.Currency {0} '{1}' ",
							operatorsForCurrency.SelectedValue, 
							Currency.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PaymentDescription>.GetWhereKey("PaymentDescription")] = writer.ToString();
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
			Amount.ID = "searchAmount";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Amount</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAmount ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Amount );
			Controls.Add( new LiteralControl("</td><tr>") );
			Bonus.ID = "searchBonus";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Bonus</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBonus ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Bonus );
			Controls.Add( new LiteralControl("</td><tr>") );
			Cost.ID = "searchCost";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Cost</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCost ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Cost );
			Controls.Add( new LiteralControl("</td><tr>") );
			Locale.ID = "searchLocale";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Locale</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLocale ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Locale );
			Controls.Add( new LiteralControl("</td><tr>") );
			Data.ID = "searchData";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Data</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForData ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Data );
			Controls.Add( new LiteralControl("</td><tr>") );
			Currency.ID = "searchCurrency";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Currency</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrency ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Currency );
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
