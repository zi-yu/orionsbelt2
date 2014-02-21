
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
    /// Control that enables ArenaHistorical search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ArenaHistoricalPagedList
    /// </remarks>
	public class ArenaHistoricalSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox championId = new TextBox();
		protected DropDownList operatorsForChampionId = new DropDownList();
		protected TextBox challengerId = new TextBox();
		protected DropDownList operatorsForChallengerId = new DropDownList();
		protected TextBox winner = new TextBox();
		protected DropDownList operatorsForWinner = new DropDownList();
		protected TextBox winningSequence = new TextBox();
		protected DropDownList operatorsForWinningSequence = new DropDownList();
		protected TextBox battleId = new TextBox();
		protected DropDownList operatorsForBattleId = new DropDownList();
		protected TextBox startTick = new TextBox();
		protected DropDownList operatorsForStartTick = new DropDownList();
		protected TextBox endTick = new TextBox();
		protected DropDownList operatorsForEndTick = new DropDownList();
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
        /// Search box for ArenaHistorical's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's ChampionId property
        /// </summary>
		public TextBox ChampionId {
			get { return championId; }
			set { championId = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's ChampionId operators
        /// </summary>
		public DropDownList OperatorsForChampionId {
			get { return operatorsForChampionId; }
			set { operatorsForChampionId = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's ChallengerId property
        /// </summary>
		public TextBox ChallengerId {
			get { return challengerId; }
			set { challengerId = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's ChallengerId operators
        /// </summary>
		public DropDownList OperatorsForChallengerId {
			get { return operatorsForChallengerId; }
			set { operatorsForChallengerId = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's Winner property
        /// </summary>
		public TextBox Winner {
			get { return winner; }
			set { winner = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's Winner operators
        /// </summary>
		public DropDownList OperatorsForWinner {
			get { return operatorsForWinner; }
			set { operatorsForWinner = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's WinningSequence property
        /// </summary>
		public TextBox WinningSequence {
			get { return winningSequence; }
			set { winningSequence = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's WinningSequence operators
        /// </summary>
		public DropDownList OperatorsForWinningSequence {
			get { return operatorsForWinningSequence; }
			set { operatorsForWinningSequence = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's BattleId property
        /// </summary>
		public TextBox BattleId {
			get { return battleId; }
			set { battleId = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's BattleId operators
        /// </summary>
		public DropDownList OperatorsForBattleId {
			get { return operatorsForBattleId; }
			set { operatorsForBattleId = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's StartTick property
        /// </summary>
		public TextBox StartTick {
			get { return startTick; }
			set { startTick = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's StartTick operators
        /// </summary>
		public DropDownList OperatorsForStartTick {
			get { return operatorsForStartTick; }
			set { operatorsForStartTick = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's EndTick property
        /// </summary>
		public TextBox EndTick {
			get { return endTick; }
			set { endTick = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's EndTick operators
        /// </summary>
		public DropDownList OperatorsForEndTick {
			get { return operatorsForEndTick; }
			set { operatorsForEndTick = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ArenaHistorical's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaHistorical's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( ChampionId.Text ) ) {
					writer.Write( "{2} e.ChampionId {0} '{1}' ",
							operatorsForChampionId.SelectedValue, 
							ChampionId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ChallengerId.Text ) ) {
					writer.Write( "{2} e.ChallengerId {0} '{1}' ",
							operatorsForChallengerId.SelectedValue, 
							ChallengerId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Winner.Text ) ) {
					writer.Write( "{2} e.Winner {0} '{1}' ",
							operatorsForWinner.SelectedValue, 
							Winner.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( WinningSequence.Text ) ) {
					writer.Write( "{2} e.WinningSequence {0} '{1}' ",
							operatorsForWinningSequence.SelectedValue, 
							WinningSequence.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BattleId.Text ) ) {
					writer.Write( "{2} e.BattleId {0} '{1}' ",
							operatorsForBattleId.SelectedValue, 
							BattleId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StartTick.Text ) ) {
					writer.Write( "{2} e.StartTick {0} '{1}' ",
							operatorsForStartTick.SelectedValue, 
							StartTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( EndTick.Text ) ) {
					writer.Write( "{2} e.EndTick {0} '{1}' ",
							operatorsForEndTick.SelectedValue, 
							EndTick.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<ArenaHistorical>.GetWhereKey("ArenaHistorical")] = writer.ToString();
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
			ChampionId.ID = "searchChampionId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ChampionId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForChampionId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ChampionId );
			Controls.Add( new LiteralControl("</td><tr>") );
			ChallengerId.ID = "searchChallengerId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ChallengerId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForChallengerId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ChallengerId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Winner.ID = "searchWinner";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Winner</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWinner ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Winner );
			Controls.Add( new LiteralControl("</td><tr>") );
			WinningSequence.ID = "searchWinningSequence";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WinningSequence</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWinningSequence ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WinningSequence );
			Controls.Add( new LiteralControl("</td><tr>") );
			BattleId.ID = "searchBattleId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BattleId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBattleId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BattleId );
			Controls.Add( new LiteralControl("</td><tr>") );
			StartTick.ID = "searchStartTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StartTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStartTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StartTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			EndTick.ID = "searchEndTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EndTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEndTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EndTick );
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
