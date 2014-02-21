
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
    /// Control that enables BattleStats search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a BattleStatsPagedList
    /// </remarks>
	public class BattleStatsSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox wins = new TextBox();
		protected DropDownList operatorsForWins = new DropDownList();
		protected TextBox defeats = new TextBox();
		protected DropDownList operatorsForDefeats = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox detail = new TextBox();
		protected DropDownList operatorsForDetail = new DropDownList();
		protected TextBox giveUps = new TextBox();
		protected DropDownList operatorsForGiveUps = new DropDownList();
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
        /// Search box for BattleStats's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's Wins property
        /// </summary>
		public TextBox Wins {
			get { return wins; }
			set { wins = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's Wins operators
        /// </summary>
		public DropDownList OperatorsForWins {
			get { return operatorsForWins; }
			set { operatorsForWins = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's Defeats property
        /// </summary>
		public TextBox Defeats {
			get { return defeats; }
			set { defeats = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's Defeats operators
        /// </summary>
		public DropDownList OperatorsForDefeats {
			get { return operatorsForDefeats; }
			set { operatorsForDefeats = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's Detail property
        /// </summary>
		public TextBox Detail {
			get { return detail; }
			set { detail = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's Detail operators
        /// </summary>
		public DropDownList OperatorsForDetail {
			get { return operatorsForDetail; }
			set { operatorsForDetail = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's GiveUps property
        /// </summary>
		public TextBox GiveUps {
			get { return giveUps; }
			set { giveUps = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's GiveUps operators
        /// </summary>
		public DropDownList OperatorsForGiveUps {
			get { return operatorsForGiveUps; }
			set { operatorsForGiveUps = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for BattleStats's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for BattleStats's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Wins.Text ) ) {
					writer.Write( "{2} e.Wins {0} '{1}' ",
							operatorsForWins.SelectedValue, 
							Wins.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Defeats.Text ) ) {
					writer.Write( "{2} e.Defeats {0} '{1}' ",
							operatorsForDefeats.SelectedValue, 
							Defeats.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Detail.Text ) ) {
					writer.Write( "{2} e.Detail {0} '{1}' ",
							operatorsForDetail.SelectedValue, 
							Detail.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GiveUps.Text ) ) {
					writer.Write( "{2} e.GiveUps {0} '{1}' ",
							operatorsForGiveUps.SelectedValue, 
							GiveUps.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<BattleStats>.GetWhereKey("BattleStats")] = writer.ToString();
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
			Wins.ID = "searchWins";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Wins</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWins ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Wins );
			Controls.Add( new LiteralControl("</td><tr>") );
			Defeats.ID = "searchDefeats";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Defeats</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDefeats ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Defeats );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			Detail.ID = "searchDetail";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Detail</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDetail ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Detail );
			Controls.Add( new LiteralControl("</td><tr>") );
			GiveUps.ID = "searchGiveUps";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GiveUps</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGiveUps ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GiveUps );
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
