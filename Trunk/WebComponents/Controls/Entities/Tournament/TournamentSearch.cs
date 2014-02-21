
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
    /// Control that enables Tournament search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a TournamentPagedList
    /// </remarks>
	public class TournamentSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox warningTick = new TextBox();
		protected DropDownList operatorsForWarningTick = new DropDownList();
		protected TextBox prize = new TextBox();
		protected DropDownList operatorsForPrize = new DropDownList();
		protected TextBox costCredits = new TextBox();
		protected DropDownList operatorsForCostCredits = new DropDownList();
		protected TextBox tournamentType = new TextBox();
		protected DropDownList operatorsForTournamentType = new DropDownList();
		protected TextBox fleetId = new TextBox();
		protected DropDownList operatorsForFleetId = new DropDownList();
		protected TextBox isPublic = new TextBox();
		protected DropDownList operatorsForIsPublic = new DropDownList();
		protected TextBox isSurvival = new TextBox();
		protected DropDownList operatorsForIsSurvival = new DropDownList();
		protected TextBox turnTime = new TextBox();
		protected DropDownList operatorsForTurnTime = new DropDownList();
		protected TextBox subscriptionTime = new TextBox();
		protected DropDownList operatorsForSubscriptionTime = new DropDownList();
		protected TextBox maxPlayers = new TextBox();
		protected DropDownList operatorsForMaxPlayers = new DropDownList();
		protected TextBox minPlayers = new TextBox();
		protected DropDownList operatorsForMinPlayers = new DropDownList();
		protected TextBox nPlayersToPlayoff = new TextBox();
		protected DropDownList operatorsForNPlayersToPlayoff = new DropDownList();
		protected TextBox maxElo = new TextBox();
		protected DropDownList operatorsForMaxElo = new DropDownList();
		protected TextBox minElo = new TextBox();
		protected DropDownList operatorsForMinElo = new DropDownList();
		protected TextBox startTime = new TextBox();
		protected DropDownList operatorsForStartTime = new DropDownList();
		protected TextBox endDate = new TextBox();
		protected DropDownList operatorsForEndDate = new DropDownList();
		protected TextBox token = new TextBox();
		protected DropDownList operatorsForToken = new DropDownList();
		protected TextBox tokenNumber = new TextBox();
		protected DropDownList operatorsForTokenNumber = new DropDownList();
		protected TextBox isCustom = new TextBox();
		protected DropDownList operatorsForIsCustom = new DropDownList();
		protected TextBox paymentsRequired = new TextBox();
		protected DropDownList operatorsForPaymentsRequired = new DropDownList();
		protected TextBox numberPassGroup = new TextBox();
		protected DropDownList operatorsForNumberPassGroup = new DropDownList();
		protected TextBox descriptionToken = new TextBox();
		protected DropDownList operatorsForDescriptionToken = new DropDownList();
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
        /// Search box for Tournament's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's WarningTick property
        /// </summary>
		public TextBox WarningTick {
			get { return warningTick; }
			set { warningTick = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's WarningTick operators
        /// </summary>
		public DropDownList OperatorsForWarningTick {
			get { return operatorsForWarningTick; }
			set { operatorsForWarningTick = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's Prize property
        /// </summary>
		public TextBox Prize {
			get { return prize; }
			set { prize = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's Prize operators
        /// </summary>
		public DropDownList OperatorsForPrize {
			get { return operatorsForPrize; }
			set { operatorsForPrize = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's CostCredits property
        /// </summary>
		public TextBox CostCredits {
			get { return costCredits; }
			set { costCredits = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's CostCredits operators
        /// </summary>
		public DropDownList OperatorsForCostCredits {
			get { return operatorsForCostCredits; }
			set { operatorsForCostCredits = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's TournamentType property
        /// </summary>
		public TextBox TournamentType {
			get { return tournamentType; }
			set { tournamentType = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's TournamentType operators
        /// </summary>
		public DropDownList OperatorsForTournamentType {
			get { return operatorsForTournamentType; }
			set { operatorsForTournamentType = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's FleetId property
        /// </summary>
		public TextBox FleetId {
			get { return fleetId; }
			set { fleetId = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's FleetId operators
        /// </summary>
		public DropDownList OperatorsForFleetId {
			get { return operatorsForFleetId; }
			set { operatorsForFleetId = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's IsPublic property
        /// </summary>
		public TextBox IsPublic {
			get { return isPublic; }
			set { isPublic = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's IsPublic operators
        /// </summary>
		public DropDownList OperatorsForIsPublic {
			get { return operatorsForIsPublic; }
			set { operatorsForIsPublic = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's IsSurvival property
        /// </summary>
		public TextBox IsSurvival {
			get { return isSurvival; }
			set { isSurvival = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's IsSurvival operators
        /// </summary>
		public DropDownList OperatorsForIsSurvival {
			get { return operatorsForIsSurvival; }
			set { operatorsForIsSurvival = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's TurnTime property
        /// </summary>
		public TextBox TurnTime {
			get { return turnTime; }
			set { turnTime = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's TurnTime operators
        /// </summary>
		public DropDownList OperatorsForTurnTime {
			get { return operatorsForTurnTime; }
			set { operatorsForTurnTime = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's SubscriptionTime property
        /// </summary>
		public TextBox SubscriptionTime {
			get { return subscriptionTime; }
			set { subscriptionTime = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's SubscriptionTime operators
        /// </summary>
		public DropDownList OperatorsForSubscriptionTime {
			get { return operatorsForSubscriptionTime; }
			set { operatorsForSubscriptionTime = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's MaxPlayers property
        /// </summary>
		public TextBox MaxPlayers {
			get { return maxPlayers; }
			set { maxPlayers = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's MaxPlayers operators
        /// </summary>
		public DropDownList OperatorsForMaxPlayers {
			get { return operatorsForMaxPlayers; }
			set { operatorsForMaxPlayers = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's MinPlayers property
        /// </summary>
		public TextBox MinPlayers {
			get { return minPlayers; }
			set { minPlayers = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's MinPlayers operators
        /// </summary>
		public DropDownList OperatorsForMinPlayers {
			get { return operatorsForMinPlayers; }
			set { operatorsForMinPlayers = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's NPlayersToPlayoff property
        /// </summary>
		public TextBox NPlayersToPlayoff {
			get { return nPlayersToPlayoff; }
			set { nPlayersToPlayoff = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's NPlayersToPlayoff operators
        /// </summary>
		public DropDownList OperatorsForNPlayersToPlayoff {
			get { return operatorsForNPlayersToPlayoff; }
			set { operatorsForNPlayersToPlayoff = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's MaxElo property
        /// </summary>
		public TextBox MaxElo {
			get { return maxElo; }
			set { maxElo = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's MaxElo operators
        /// </summary>
		public DropDownList OperatorsForMaxElo {
			get { return operatorsForMaxElo; }
			set { operatorsForMaxElo = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's MinElo property
        /// </summary>
		public TextBox MinElo {
			get { return minElo; }
			set { minElo = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's MinElo operators
        /// </summary>
		public DropDownList OperatorsForMinElo {
			get { return operatorsForMinElo; }
			set { operatorsForMinElo = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's StartTime property
        /// </summary>
		public TextBox StartTime {
			get { return startTime; }
			set { startTime = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's StartTime operators
        /// </summary>
		public DropDownList OperatorsForStartTime {
			get { return operatorsForStartTime; }
			set { operatorsForStartTime = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's EndDate property
        /// </summary>
		public TextBox EndDate {
			get { return endDate; }
			set { endDate = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's EndDate operators
        /// </summary>
		public DropDownList OperatorsForEndDate {
			get { return operatorsForEndDate; }
			set { operatorsForEndDate = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's Token property
        /// </summary>
		public TextBox Token {
			get { return token; }
			set { token = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's Token operators
        /// </summary>
		public DropDownList OperatorsForToken {
			get { return operatorsForToken; }
			set { operatorsForToken = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's TokenNumber property
        /// </summary>
		public TextBox TokenNumber {
			get { return tokenNumber; }
			set { tokenNumber = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's TokenNumber operators
        /// </summary>
		public DropDownList OperatorsForTokenNumber {
			get { return operatorsForTokenNumber; }
			set { operatorsForTokenNumber = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's IsCustom property
        /// </summary>
		public TextBox IsCustom {
			get { return isCustom; }
			set { isCustom = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's IsCustom operators
        /// </summary>
		public DropDownList OperatorsForIsCustom {
			get { return operatorsForIsCustom; }
			set { operatorsForIsCustom = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's PaymentsRequired property
        /// </summary>
		public TextBox PaymentsRequired {
			get { return paymentsRequired; }
			set { paymentsRequired = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's PaymentsRequired operators
        /// </summary>
		public DropDownList OperatorsForPaymentsRequired {
			get { return operatorsForPaymentsRequired; }
			set { operatorsForPaymentsRequired = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's NumberPassGroup property
        /// </summary>
		public TextBox NumberPassGroup {
			get { return numberPassGroup; }
			set { numberPassGroup = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's NumberPassGroup operators
        /// </summary>
		public DropDownList OperatorsForNumberPassGroup {
			get { return operatorsForNumberPassGroup; }
			set { operatorsForNumberPassGroup = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's DescriptionToken property
        /// </summary>
		public TextBox DescriptionToken {
			get { return descriptionToken; }
			set { descriptionToken = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's DescriptionToken operators
        /// </summary>
		public DropDownList OperatorsForDescriptionToken {
			get { return operatorsForDescriptionToken; }
			set { operatorsForDescriptionToken = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Tournament's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Tournament's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( WarningTick.Text ) ) {
					writer.Write( "{2} e.WarningTick {0} '{1}' ",
							operatorsForWarningTick.SelectedValue, 
							WarningTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Prize.Text ) ) {
					writer.Write( "{2} e.Prize {0} '{1}' ",
							operatorsForPrize.SelectedValue, 
							Prize.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CostCredits.Text ) ) {
					writer.Write( "{2} e.CostCredits {0} '{1}' ",
							operatorsForCostCredits.SelectedValue, 
							CostCredits.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TournamentType.Text ) ) {
					writer.Write( "{2} e.TournamentType {0} '{1}' ",
							operatorsForTournamentType.SelectedValue, 
							TournamentType.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( IsPublic.Text ) ) {
					writer.Write( "{2} e.IsPublic {0} '{1}' ",
							operatorsForIsPublic.SelectedValue, 
							IsPublic.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsSurvival.Text ) ) {
					writer.Write( "{2} e.IsSurvival {0} '{1}' ",
							operatorsForIsSurvival.SelectedValue, 
							IsSurvival.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TurnTime.Text ) ) {
					writer.Write( "{2} e.TurnTime {0} '{1}' ",
							operatorsForTurnTime.SelectedValue, 
							TurnTime.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SubscriptionTime.Text ) ) {
					writer.Write( "{2} e.SubscriptionTime {0} '{1}' ",
							operatorsForSubscriptionTime.SelectedValue, 
							SubscriptionTime.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MaxPlayers.Text ) ) {
					writer.Write( "{2} e.MaxPlayers {0} '{1}' ",
							operatorsForMaxPlayers.SelectedValue, 
							MaxPlayers.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MinPlayers.Text ) ) {
					writer.Write( "{2} e.MinPlayers {0} '{1}' ",
							operatorsForMinPlayers.SelectedValue, 
							MinPlayers.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NPlayersToPlayoff.Text ) ) {
					writer.Write( "{2} e.NPlayersToPlayoff {0} '{1}' ",
							operatorsForNPlayersToPlayoff.SelectedValue, 
							NPlayersToPlayoff.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MaxElo.Text ) ) {
					writer.Write( "{2} e.MaxElo {0} '{1}' ",
							operatorsForMaxElo.SelectedValue, 
							MaxElo.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MinElo.Text ) ) {
					writer.Write( "{2} e.MinElo {0} '{1}' ",
							operatorsForMinElo.SelectedValue, 
							MinElo.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StartTime.Text ) ) {
					writer.Write( "{2} e.StartTime {0} '{1}' ",
							operatorsForStartTime.SelectedValue, 
							StartTime.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Token.Text ) ) {
					writer.Write( "{2} e.Token {0} '{1}' ",
							operatorsForToken.SelectedValue, 
							Token.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TokenNumber.Text ) ) {
					writer.Write( "{2} e.TokenNumber {0} '{1}' ",
							operatorsForTokenNumber.SelectedValue, 
							TokenNumber.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsCustom.Text ) ) {
					writer.Write( "{2} e.IsCustom {0} '{1}' ",
							operatorsForIsCustom.SelectedValue, 
							IsCustom.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PaymentsRequired.Text ) ) {
					writer.Write( "{2} e.PaymentsRequired {0} '{1}' ",
							operatorsForPaymentsRequired.SelectedValue, 
							PaymentsRequired.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberPassGroup.Text ) ) {
					writer.Write( "{2} e.NumberPassGroup {0} '{1}' ",
							operatorsForNumberPassGroup.SelectedValue, 
							NumberPassGroup.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( DescriptionToken.Text ) ) {
					writer.Write( "{2} e.DescriptionToken {0} '{1}' ",
							operatorsForDescriptionToken.SelectedValue, 
							DescriptionToken.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Tournament>.GetWhereKey("Tournament")] = writer.ToString();
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
			WarningTick.ID = "searchWarningTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WarningTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWarningTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WarningTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			Prize.ID = "searchPrize";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Prize</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPrize ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Prize );
			Controls.Add( new LiteralControl("</td><tr>") );
			CostCredits.ID = "searchCostCredits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CostCredits</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCostCredits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CostCredits );
			Controls.Add( new LiteralControl("</td><tr>") );
			TournamentType.ID = "searchTournamentType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TournamentType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTournamentType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TournamentType );
			Controls.Add( new LiteralControl("</td><tr>") );
			FleetId.ID = "searchFleetId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>FleetId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForFleetId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( FleetId );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsPublic.ID = "searchIsPublic";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsPublic</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsPublic ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsPublic );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsSurvival.ID = "searchIsSurvival";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsSurvival</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsSurvival ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsSurvival );
			Controls.Add( new LiteralControl("</td><tr>") );
			TurnTime.ID = "searchTurnTime";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TurnTime</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTurnTime ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TurnTime );
			Controls.Add( new LiteralControl("</td><tr>") );
			SubscriptionTime.ID = "searchSubscriptionTime";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SubscriptionTime</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSubscriptionTime ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SubscriptionTime );
			Controls.Add( new LiteralControl("</td><tr>") );
			MaxPlayers.ID = "searchMaxPlayers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MaxPlayers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMaxPlayers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MaxPlayers );
			Controls.Add( new LiteralControl("</td><tr>") );
			MinPlayers.ID = "searchMinPlayers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MinPlayers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMinPlayers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MinPlayers );
			Controls.Add( new LiteralControl("</td><tr>") );
			NPlayersToPlayoff.ID = "searchNPlayersToPlayoff";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NPlayersToPlayoff</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNPlayersToPlayoff ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NPlayersToPlayoff );
			Controls.Add( new LiteralControl("</td><tr>") );
			MaxElo.ID = "searchMaxElo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MaxElo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMaxElo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MaxElo );
			Controls.Add( new LiteralControl("</td><tr>") );
			MinElo.ID = "searchMinElo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MinElo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMinElo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MinElo );
			Controls.Add( new LiteralControl("</td><tr>") );
			StartTime.ID = "searchStartTime";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StartTime</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStartTime ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StartTime );
			Controls.Add( new LiteralControl("</td><tr>") );
			EndDate.ID = "searchEndDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EndDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEndDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EndDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			Token.ID = "searchToken";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Token</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForToken ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Token );
			Controls.Add( new LiteralControl("</td><tr>") );
			TokenNumber.ID = "searchTokenNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TokenNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTokenNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TokenNumber );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsCustom.ID = "searchIsCustom";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsCustom</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsCustom ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsCustom );
			Controls.Add( new LiteralControl("</td><tr>") );
			PaymentsRequired.ID = "searchPaymentsRequired";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PaymentsRequired</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPaymentsRequired ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PaymentsRequired );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberPassGroup.ID = "searchNumberPassGroup";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberPassGroup</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberPassGroup ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberPassGroup );
			Controls.Add( new LiteralControl("</td><tr>") );
			DescriptionToken.ID = "searchDescriptionToken";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>DescriptionToken</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDescriptionToken ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( DescriptionToken );
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
