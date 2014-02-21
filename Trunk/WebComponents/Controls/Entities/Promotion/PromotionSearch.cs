
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
    /// Control that enables Promotion search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PromotionPagedList
    /// </remarks>
	public class PromotionSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox beginDate = new TextBox();
		protected DropDownList operatorsForBeginDate = new DropDownList();
		protected TextBox endDate = new TextBox();
		protected DropDownList operatorsForEndDate = new DropDownList();
		protected TextBox revenueType = new TextBox();
		protected DropDownList operatorsForRevenueType = new DropDownList();
		protected TextBox revenue = new TextBox();
		protected DropDownList operatorsForRevenue = new DropDownList();
		protected TextBox promotionType = new TextBox();
		protected DropDownList operatorsForPromotionType = new DropDownList();
		protected TextBox rangeBegin = new TextBox();
		protected DropDownList operatorsForRangeBegin = new DropDownList();
		protected TextBox rangeEnd = new TextBox();
		protected DropDownList operatorsForRangeEnd = new DropDownList();
		protected TextBox promotionCode = new TextBox();
		protected DropDownList operatorsForPromotionCode = new DropDownList();
		protected TextBox bonusType = new TextBox();
		protected DropDownList operatorsForBonusType = new DropDownList();
		protected TextBox bonus = new TextBox();
		protected DropDownList operatorsForBonus = new DropDownList();
		protected TextBox status = new TextBox();
		protected DropDownList operatorsForStatus = new DropDownList();
		protected TextBox description = new TextBox();
		protected DropDownList operatorsForDescription = new DropDownList();
		protected TextBox uses = new TextBox();
		protected DropDownList operatorsForUses = new DropDownList();
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
        /// Search box for Promotion's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's BeginDate property
        /// </summary>
		public TextBox BeginDate {
			get { return beginDate; }
			set { beginDate = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's BeginDate operators
        /// </summary>
		public DropDownList OperatorsForBeginDate {
			get { return operatorsForBeginDate; }
			set { operatorsForBeginDate = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's EndDate property
        /// </summary>
		public TextBox EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's EndDate operators
        /// </summary>
		public DropDownList OperatorsForEndDate {
			get { return operatorsForEndDate; }
			set { operatorsForEndDate = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's RevenueType property
        /// </summary>
		public TextBox RevenueType {
			get { return revenueType; }
			set { revenueType = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's RevenueType operators
        /// </summary>
		public DropDownList OperatorsForRevenueType {
			get { return operatorsForRevenueType; }
			set { operatorsForRevenueType = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Revenue property
        /// </summary>
		public TextBox Revenue {
			get { return revenue; }
			set { revenue = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Revenue operators
        /// </summary>
		public DropDownList OperatorsForRevenue {
			get { return operatorsForRevenue; }
			set { operatorsForRevenue = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's PromotionType property
        /// </summary>
		public TextBox PromotionType {
			get { return promotionType; }
			set { promotionType = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's PromotionType operators
        /// </summary>
		public DropDownList OperatorsForPromotionType {
			get { return operatorsForPromotionType; }
			set { operatorsForPromotionType = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's RangeBegin property
        /// </summary>
		public TextBox RangeBegin {
			get { return rangeBegin; }
			set { rangeBegin = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's RangeBegin operators
        /// </summary>
		public DropDownList OperatorsForRangeBegin {
			get { return operatorsForRangeBegin; }
			set { operatorsForRangeBegin = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's RangeEnd property
        /// </summary>
		public TextBox RangeEnd {
			get { return rangeEnd; }
			set { rangeEnd = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's RangeEnd operators
        /// </summary>
		public DropDownList OperatorsForRangeEnd {
			get { return operatorsForRangeEnd; }
			set { operatorsForRangeEnd = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's PromotionCode property
        /// </summary>
		public TextBox PromotionCode {
			get { return promotionCode; }
			set { promotionCode = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's PromotionCode operators
        /// </summary>
		public DropDownList OperatorsForPromotionCode {
			get { return operatorsForPromotionCode; }
			set { operatorsForPromotionCode = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's BonusType property
        /// </summary>
		public TextBox BonusType {
			get { return bonusType; }
			set { bonusType = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's BonusType operators
        /// </summary>
		public DropDownList OperatorsForBonusType {
			get { return operatorsForBonusType; }
			set { operatorsForBonusType = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Bonus property
        /// </summary>
		public TextBox Bonus {
			get { return bonus; }
			set { bonus = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Bonus operators
        /// </summary>
		public DropDownList OperatorsForBonus {
			get { return operatorsForBonus; }
			set { operatorsForBonus = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Status property
        /// </summary>
		public TextBox Status {
			get { return status; }
			set { status = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Status operators
        /// </summary>
		public DropDownList OperatorsForStatus {
			get { return operatorsForStatus; }
			set { operatorsForStatus = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Description property
        /// </summary>
		public TextBox Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Description operators
        /// </summary>
		public DropDownList OperatorsForDescription {
			get { return operatorsForDescription; }
			set { operatorsForDescription = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's Uses property
        /// </summary>
		public TextBox Uses {
			get { return uses; }
			set { uses = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's Uses operators
        /// </summary>
		public DropDownList OperatorsForUses {
			get { return operatorsForUses; }
			set { operatorsForUses = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Promotion's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Promotion's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Name.Text ) ) {
					writer.Write( "{2} e.Name {0} '{1}' ",
							operatorsForName.SelectedValue, 
							Name.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( RevenueType.Text ) ) {
					writer.Write( "{2} e.RevenueType {0} '{1}' ",
							operatorsForRevenueType.SelectedValue, 
							RevenueType.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Revenue.Text ) ) {
					writer.Write( "{2} e.Revenue {0} '{1}' ",
							operatorsForRevenue.SelectedValue, 
							Revenue.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PromotionType.Text ) ) {
					writer.Write( "{2} e.PromotionType {0} '{1}' ",
							operatorsForPromotionType.SelectedValue, 
							PromotionType.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RangeBegin.Text ) ) {
					writer.Write( "{2} e.RangeBegin {0} '{1}' ",
							operatorsForRangeBegin.SelectedValue, 
							RangeBegin.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RangeEnd.Text ) ) {
					writer.Write( "{2} e.RangeEnd {0} '{1}' ",
							operatorsForRangeEnd.SelectedValue, 
							RangeEnd.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PromotionCode.Text ) ) {
					writer.Write( "{2} e.PromotionCode {0} '{1}' ",
							operatorsForPromotionCode.SelectedValue, 
							PromotionCode.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BonusType.Text ) ) {
					writer.Write( "{2} e.BonusType {0} '{1}' ",
							operatorsForBonusType.SelectedValue, 
							BonusType.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Status.Text ) ) {
					writer.Write( "{2} e.Status {0} '{1}' ",
							operatorsForStatus.SelectedValue, 
							Status.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Uses.Text ) ) {
					writer.Write( "{2} e.Uses {0} '{1}' ",
							operatorsForUses.SelectedValue, 
							Uses.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Promotion>.GetWhereKey("Promotion")] = writer.ToString();
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
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
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
			RevenueType.ID = "searchRevenueType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RevenueType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRevenueType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RevenueType );
			Controls.Add( new LiteralControl("</td><tr>") );
			Revenue.ID = "searchRevenue";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Revenue</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRevenue ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Revenue );
			Controls.Add( new LiteralControl("</td><tr>") );
			PromotionType.ID = "searchPromotionType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PromotionType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPromotionType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PromotionType );
			Controls.Add( new LiteralControl("</td><tr>") );
			RangeBegin.ID = "searchRangeBegin";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RangeBegin</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRangeBegin ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RangeBegin );
			Controls.Add( new LiteralControl("</td><tr>") );
			RangeEnd.ID = "searchRangeEnd";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RangeEnd</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRangeEnd ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RangeEnd );
			Controls.Add( new LiteralControl("</td><tr>") );
			PromotionCode.ID = "searchPromotionCode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PromotionCode</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPromotionCode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PromotionCode );
			Controls.Add( new LiteralControl("</td><tr>") );
			BonusType.ID = "searchBonusType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BonusType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBonusType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BonusType );
			Controls.Add( new LiteralControl("</td><tr>") );
			Bonus.ID = "searchBonus";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Bonus</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBonus ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Bonus );
			Controls.Add( new LiteralControl("</td><tr>") );
			Status.ID = "searchStatus";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Status</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStatus ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Status );
			Controls.Add( new LiteralControl("</td><tr>") );
			Description.ID = "searchDescription";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Description</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDescription ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Description );
			Controls.Add( new LiteralControl("</td><tr>") );
			Uses.ID = "searchUses";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Uses</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUses ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Uses );
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
