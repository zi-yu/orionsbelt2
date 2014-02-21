
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
    /// Control that enables PlayerStats search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlayerStatsPagedList
    /// </remarks>
	public class PlayerStatsSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox numberOfPlayedBattles = new TextBox();
		protected DropDownList operatorsForNumberOfPlayedBattles = new DropDownList();
		protected TextBox numberPirateQuest = new TextBox();
		protected DropDownList operatorsForNumberPirateQuest = new DropDownList();
		protected TextBox numberBountyQuests = new TextBox();
		protected DropDownList operatorsForNumberBountyQuests = new DropDownList();
		protected TextBox numberMerchantQuests = new TextBox();
		protected DropDownList operatorsForNumberMerchantQuests = new DropDownList();
		protected TextBox numberGladiatorQuests = new TextBox();
		protected DropDownList operatorsForNumberGladiatorQuests = new DropDownList();
		protected TextBox numberColonizerQuests = new TextBox();
		protected DropDownList operatorsForNumberColonizerQuests = new DropDownList();
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
        /// Search box for PlayerStats's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberOfPlayedBattles property
        /// </summary>
		public TextBox NumberOfPlayedBattles {
			get { return numberOfPlayedBattles; }
			set { numberOfPlayedBattles = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberOfPlayedBattles operators
        /// </summary>
		public DropDownList OperatorsForNumberOfPlayedBattles {
			get { return operatorsForNumberOfPlayedBattles; }
			set { operatorsForNumberOfPlayedBattles = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberPirateQuest property
        /// </summary>
		public TextBox NumberPirateQuest {
			get { return numberPirateQuest; }
			set { numberPirateQuest = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberPirateQuest operators
        /// </summary>
		public DropDownList OperatorsForNumberPirateQuest {
			get { return operatorsForNumberPirateQuest; }
			set { operatorsForNumberPirateQuest = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberBountyQuests property
        /// </summary>
		public TextBox NumberBountyQuests {
			get { return numberBountyQuests; }
			set { numberBountyQuests = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberBountyQuests operators
        /// </summary>
		public DropDownList OperatorsForNumberBountyQuests {
			get { return operatorsForNumberBountyQuests; }
			set { operatorsForNumberBountyQuests = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberMerchantQuests property
        /// </summary>
		public TextBox NumberMerchantQuests {
			get { return numberMerchantQuests; }
			set { numberMerchantQuests = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberMerchantQuests operators
        /// </summary>
		public DropDownList OperatorsForNumberMerchantQuests {
			get { return operatorsForNumberMerchantQuests; }
			set { operatorsForNumberMerchantQuests = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberGladiatorQuests property
        /// </summary>
		public TextBox NumberGladiatorQuests {
			get { return numberGladiatorQuests; }
			set { numberGladiatorQuests = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberGladiatorQuests operators
        /// </summary>
		public DropDownList OperatorsForNumberGladiatorQuests {
			get { return operatorsForNumberGladiatorQuests; }
			set { operatorsForNumberGladiatorQuests = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's NumberColonizerQuests property
        /// </summary>
		public TextBox NumberColonizerQuests {
			get { return numberColonizerQuests; }
			set { numberColonizerQuests = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's NumberColonizerQuests operators
        /// </summary>
		public DropDownList OperatorsForNumberColonizerQuests {
			get { return operatorsForNumberColonizerQuests; }
			set { operatorsForNumberColonizerQuests = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerStats's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerStats's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( NumberOfPlayedBattles.Text ) ) {
					writer.Write( "{2} e.NumberOfPlayedBattles {0} '{1}' ",
							operatorsForNumberOfPlayedBattles.SelectedValue, 
							NumberOfPlayedBattles.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberPirateQuest.Text ) ) {
					writer.Write( "{2} e.NumberPirateQuest {0} '{1}' ",
							operatorsForNumberPirateQuest.SelectedValue, 
							NumberPirateQuest.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberBountyQuests.Text ) ) {
					writer.Write( "{2} e.NumberBountyQuests {0} '{1}' ",
							operatorsForNumberBountyQuests.SelectedValue, 
							NumberBountyQuests.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberMerchantQuests.Text ) ) {
					writer.Write( "{2} e.NumberMerchantQuests {0} '{1}' ",
							operatorsForNumberMerchantQuests.SelectedValue, 
							NumberMerchantQuests.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberGladiatorQuests.Text ) ) {
					writer.Write( "{2} e.NumberGladiatorQuests {0} '{1}' ",
							operatorsForNumberGladiatorQuests.SelectedValue, 
							NumberGladiatorQuests.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberColonizerQuests.Text ) ) {
					writer.Write( "{2} e.NumberColonizerQuests {0} '{1}' ",
							operatorsForNumberColonizerQuests.SelectedValue, 
							NumberColonizerQuests.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PlayerStats>.GetWhereKey("PlayerStats")] = writer.ToString();
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
			NumberOfPlayedBattles.ID = "searchNumberOfPlayedBattles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberOfPlayedBattles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberOfPlayedBattles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberOfPlayedBattles );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberPirateQuest.ID = "searchNumberPirateQuest";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberPirateQuest</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberPirateQuest ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberPirateQuest );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberBountyQuests.ID = "searchNumberBountyQuests";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberBountyQuests</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberBountyQuests ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberBountyQuests );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberMerchantQuests.ID = "searchNumberMerchantQuests";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberMerchantQuests</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberMerchantQuests ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberMerchantQuests );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberGladiatorQuests.ID = "searchNumberGladiatorQuests";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberGladiatorQuests</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberGladiatorQuests ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberGladiatorQuests );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberColonizerQuests.ID = "searchNumberColonizerQuests";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberColonizerQuests</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberColonizerQuests ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberColonizerQuests );
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
