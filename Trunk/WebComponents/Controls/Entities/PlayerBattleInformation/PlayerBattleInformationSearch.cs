
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
    /// Control that enables PlayerBattleInformation search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlayerBattleInformationPagedList
    /// </remarks>
	public class PlayerBattleInformationSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox initialContainer = new TextBox();
		protected DropDownList operatorsForInitialContainer = new DropDownList();
		protected TextBox hasPositioned = new TextBox();
		protected DropDownList operatorsForHasPositioned = new DropDownList();
		protected TextBox teamNumber = new TextBox();
		protected DropDownList operatorsForTeamNumber = new DropDownList();
		protected TextBox hasLost = new TextBox();
		protected DropDownList operatorsForHasLost = new DropDownList();
		protected TextBox winScore = new TextBox();
		protected DropDownList operatorsForWinScore = new DropDownList();
		protected TextBox fleetId = new TextBox();
		protected DropDownList operatorsForFleetId = new DropDownList();
		protected TextBox updateFleet = new TextBox();
		protected DropDownList operatorsForUpdateFleet = new DropDownList();
		protected TextBox hasGaveUp = new TextBox();
		protected DropDownList operatorsForHasGaveUp = new DropDownList();
		protected TextBox loseScore = new TextBox();
		protected DropDownList operatorsForLoseScore = new DropDownList();
		protected TextBox victoryPercentage = new TextBox();
		protected DropDownList operatorsForVictoryPercentage = new DropDownList();
		protected TextBox dominationPoints = new TextBox();
		protected DropDownList operatorsForDominationPoints = new DropDownList();
		protected TextBox timeouts = new TextBox();
		protected DropDownList operatorsForTimeouts = new DropDownList();
		protected TextBox owner = new TextBox();
		protected DropDownList operatorsForOwner = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox teamName = new TextBox();
		protected DropDownList operatorsForTeamName = new DropDownList();
		protected TextBox ultimateUnit = new TextBox();
		protected DropDownList operatorsForUltimateUnit = new DropDownList();
		protected TextBox botId = new TextBox();
		protected DropDownList operatorsForBotId = new DropDownList();
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
        /// Search box for PlayerBattleInformation's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's InitialContainer property
        /// </summary>
		public TextBox InitialContainer {
			get { return initialContainer; }
			set { initialContainer = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's InitialContainer operators
        /// </summary>
		public DropDownList OperatorsForInitialContainer {
			get { return operatorsForInitialContainer; }
			set { operatorsForInitialContainer = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's HasPositioned property
        /// </summary>
		public TextBox HasPositioned {
			get { return hasPositioned; }
			set { hasPositioned = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's HasPositioned operators
        /// </summary>
		public DropDownList OperatorsForHasPositioned {
			get { return operatorsForHasPositioned; }
			set { operatorsForHasPositioned = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's TeamNumber property
        /// </summary>
		public TextBox TeamNumber {
			get { return teamNumber; }
			set { teamNumber = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's TeamNumber operators
        /// </summary>
		public DropDownList OperatorsForTeamNumber {
			get { return operatorsForTeamNumber; }
			set { operatorsForTeamNumber = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's HasLost property
        /// </summary>
		public TextBox HasLost {
			get { return hasLost; }
			set { hasLost = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's HasLost operators
        /// </summary>
		public DropDownList OperatorsForHasLost {
			get { return operatorsForHasLost; }
			set { operatorsForHasLost = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's WinScore property
        /// </summary>
		public TextBox WinScore {
			get { return winScore; }
			set { winScore = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's WinScore operators
        /// </summary>
		public DropDownList OperatorsForWinScore {
			get { return operatorsForWinScore; }
			set { operatorsForWinScore = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's FleetId property
        /// </summary>
		public TextBox FleetId {
			get { return fleetId; }
			set { fleetId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's FleetId operators
        /// </summary>
		public DropDownList OperatorsForFleetId {
			get { return operatorsForFleetId; }
			set { operatorsForFleetId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's UpdateFleet property
        /// </summary>
		public TextBox UpdateFleet {
			get { return updateFleet; }
			set { updateFleet = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's UpdateFleet operators
        /// </summary>
		public DropDownList OperatorsForUpdateFleet {
			get { return operatorsForUpdateFleet; }
			set { operatorsForUpdateFleet = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's HasGaveUp property
        /// </summary>
		public TextBox HasGaveUp {
			get { return hasGaveUp; }
			set { hasGaveUp = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's HasGaveUp operators
        /// </summary>
		public DropDownList OperatorsForHasGaveUp {
			get { return operatorsForHasGaveUp; }
			set { operatorsForHasGaveUp = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's LoseScore property
        /// </summary>
		public TextBox LoseScore {
			get { return loseScore; }
			set { loseScore = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's LoseScore operators
        /// </summary>
		public DropDownList OperatorsForLoseScore {
			get { return operatorsForLoseScore; }
			set { operatorsForLoseScore = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's VictoryPercentage property
        /// </summary>
		public TextBox VictoryPercentage {
			get { return victoryPercentage; }
			set { victoryPercentage = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's VictoryPercentage operators
        /// </summary>
		public DropDownList OperatorsForVictoryPercentage {
			get { return operatorsForVictoryPercentage; }
			set { operatorsForVictoryPercentage = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's DominationPoints property
        /// </summary>
		public TextBox DominationPoints {
			get { return dominationPoints; }
			set { dominationPoints = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's DominationPoints operators
        /// </summary>
		public DropDownList OperatorsForDominationPoints {
			get { return operatorsForDominationPoints; }
			set { operatorsForDominationPoints = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's Timeouts property
        /// </summary>
		public TextBox Timeouts {
			get { return timeouts; }
			set { timeouts = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's Timeouts operators
        /// </summary>
		public DropDownList OperatorsForTimeouts {
			get { return operatorsForTimeouts; }
			set { operatorsForTimeouts = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's Owner property
        /// </summary>
		public TextBox Owner {
			get { return owner; }
			set { owner = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's Owner operators
        /// </summary>
		public DropDownList OperatorsForOwner {
			get { return operatorsForOwner; }
			set { operatorsForOwner = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's TeamName property
        /// </summary>
		public TextBox TeamName {
			get { return teamName; }
			set { teamName = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's TeamName operators
        /// </summary>
		public DropDownList OperatorsForTeamName {
			get { return operatorsForTeamName; }
			set { operatorsForTeamName = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's UltimateUnit property
        /// </summary>
		public TextBox UltimateUnit {
			get { return ultimateUnit; }
			set { ultimateUnit = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's UltimateUnit operators
        /// </summary>
		public DropDownList OperatorsForUltimateUnit {
			get { return operatorsForUltimateUnit; }
			set { operatorsForUltimateUnit = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's BotId property
        /// </summary>
		public TextBox BotId {
			get { return botId; }
			set { botId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's BotId operators
        /// </summary>
		public DropDownList OperatorsForBotId {
			get { return operatorsForBotId; }
			set { operatorsForBotId = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayerBattleInformation's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayerBattleInformation's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( InitialContainer.Text ) ) {
					writer.Write( "{2} e.InitialContainer {0} '{1}' ",
							operatorsForInitialContainer.SelectedValue, 
							InitialContainer.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasPositioned.Text ) ) {
					writer.Write( "{2} e.HasPositioned {0} '{1}' ",
							operatorsForHasPositioned.SelectedValue, 
							HasPositioned.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TeamNumber.Text ) ) {
					writer.Write( "{2} e.TeamNumber {0} '{1}' ",
							operatorsForTeamNumber.SelectedValue, 
							TeamNumber.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasLost.Text ) ) {
					writer.Write( "{2} e.HasLost {0} '{1}' ",
							operatorsForHasLost.SelectedValue, 
							HasLost.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( WinScore.Text ) ) {
					writer.Write( "{2} e.WinScore {0} '{1}' ",
							operatorsForWinScore.SelectedValue, 
							WinScore.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( FleetId.Text ) ) {
					writer.Write( "{2} e.FleetId {0} '{1}' ",
							operatorsForFleetId.SelectedValue, 
							FleetId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UpdateFleet.Text ) ) {
					writer.Write( "{2} e.UpdateFleet {0} '{1}' ",
							operatorsForUpdateFleet.SelectedValue, 
							UpdateFleet.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasGaveUp.Text ) ) {
					writer.Write( "{2} e.HasGaveUp {0} '{1}' ",
							operatorsForHasGaveUp.SelectedValue, 
							HasGaveUp.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LoseScore.Text ) ) {
					writer.Write( "{2} e.LoseScore {0} '{1}' ",
							operatorsForLoseScore.SelectedValue, 
							LoseScore.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VictoryPercentage.Text ) ) {
					writer.Write( "{2} e.VictoryPercentage {0} '{1}' ",
							operatorsForVictoryPercentage.SelectedValue, 
							VictoryPercentage.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( DominationPoints.Text ) ) {
					writer.Write( "{2} e.DominationPoints {0} '{1}' ",
							operatorsForDominationPoints.SelectedValue, 
							DominationPoints.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Timeouts.Text ) ) {
					writer.Write( "{2} e.Timeouts {0} '{1}' ",
							operatorsForTimeouts.SelectedValue, 
							Timeouts.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Owner.Text ) ) {
					writer.Write( "{2} e.Owner {0} '{1}' ",
							operatorsForOwner.SelectedValue, 
							Owner.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( TeamName.Text ) ) {
					writer.Write( "{2} e.TeamName {0} '{1}' ",
							operatorsForTeamName.SelectedValue, 
							TeamName.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UltimateUnit.Text ) ) {
					writer.Write( "{2} e.UltimateUnit {0} '{1}' ",
							operatorsForUltimateUnit.SelectedValue, 
							UltimateUnit.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BotId.Text ) ) {
					writer.Write( "{2} e.BotId {0} '{1}' ",
							operatorsForBotId.SelectedValue, 
							BotId.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PlayerBattleInformation>.GetWhereKey("PlayerBattleInformation")] = writer.ToString();
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
			InitialContainer.ID = "searchInitialContainer";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>InitialContainer</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForInitialContainer ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( InitialContainer );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasPositioned.ID = "searchHasPositioned";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasPositioned</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasPositioned ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasPositioned );
			Controls.Add( new LiteralControl("</td><tr>") );
			TeamNumber.ID = "searchTeamNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TeamNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTeamNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TeamNumber );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasLost.ID = "searchHasLost";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasLost</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasLost ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasLost );
			Controls.Add( new LiteralControl("</td><tr>") );
			WinScore.ID = "searchWinScore";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WinScore</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWinScore ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WinScore );
			Controls.Add( new LiteralControl("</td><tr>") );
			FleetId.ID = "searchFleetId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>FleetId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForFleetId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( FleetId );
			Controls.Add( new LiteralControl("</td><tr>") );
			UpdateFleet.ID = "searchUpdateFleet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UpdateFleet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUpdateFleet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UpdateFleet );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasGaveUp.ID = "searchHasGaveUp";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasGaveUp</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasGaveUp ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasGaveUp );
			Controls.Add( new LiteralControl("</td><tr>") );
			LoseScore.ID = "searchLoseScore";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LoseScore</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLoseScore ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LoseScore );
			Controls.Add( new LiteralControl("</td><tr>") );
			VictoryPercentage.ID = "searchVictoryPercentage";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VictoryPercentage</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVictoryPercentage ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VictoryPercentage );
			Controls.Add( new LiteralControl("</td><tr>") );
			DominationPoints.ID = "searchDominationPoints";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>DominationPoints</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDominationPoints ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( DominationPoints );
			Controls.Add( new LiteralControl("</td><tr>") );
			Timeouts.ID = "searchTimeouts";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Timeouts</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTimeouts ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Timeouts );
			Controls.Add( new LiteralControl("</td><tr>") );
			Owner.ID = "searchOwner";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Owner</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOwner ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Owner );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			TeamName.ID = "searchTeamName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TeamName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTeamName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TeamName );
			Controls.Add( new LiteralControl("</td><tr>") );
			UltimateUnit.ID = "searchUltimateUnit";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UltimateUnit</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUltimateUnit ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UltimateUnit );
			Controls.Add( new LiteralControl("</td><tr>") );
			BotId.ID = "searchBotId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotId );
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
