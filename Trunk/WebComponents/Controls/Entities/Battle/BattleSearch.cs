
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
    /// Control that enables Battle search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a BattlePagedList
    /// </remarks>
	public class BattleSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox currentTurn = new TextBox();
		protected DropDownList operatorsForCurrentTurn = new DropDownList();
		protected TextBox hasEnded = new TextBox();
		protected DropDownList operatorsForHasEnded = new DropDownList();
		protected TextBox battleType = new TextBox();
		protected DropDownList operatorsForBattleType = new DropDownList();
		protected TextBox battleMode = new TextBox();
		protected DropDownList operatorsForBattleMode = new DropDownList();
		protected TextBox unitsDestroyed = new TextBox();
		protected DropDownList operatorsForUnitsDestroyed = new DropDownList();
		protected TextBox terrain = new TextBox();
		protected DropDownList operatorsForTerrain = new DropDownList();
		protected TextBox currentPlayer = new TextBox();
		protected DropDownList operatorsForCurrentPlayer = new DropDownList();
		protected TextBox timeoutsAllowed = new TextBox();
		protected DropDownList operatorsForTimeoutsAllowed = new DropDownList();
		protected TextBox tournamentMode = new TextBox();
		protected DropDownList operatorsForTournamentMode = new DropDownList();
		protected TextBox isDeployTime = new TextBox();
		protected DropDownList operatorsForIsDeployTime = new DropDownList();
		protected TextBox isTeamBattle = new TextBox();
		protected DropDownList operatorsForIsTeamBattle = new DropDownList();
		protected TextBox seqNumber = new TextBox();
		protected DropDownList operatorsForSeqNumber = new DropDownList();
		protected TextBox isToConquer = new TextBox();
		protected DropDownList operatorsForIsToConquer = new DropDownList();
		protected TextBox isInPlanet = new TextBox();
		protected DropDownList operatorsForIsInPlanet = new DropDownList();
		protected TextBox currentBot = new TextBox();
		protected DropDownList operatorsForCurrentBot = new DropDownList();
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
        /// Search box for Battle's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Battle's CurrentTurn property
        /// </summary>
		public TextBox CurrentTurn {
			get { return currentTurn; }
			set { currentTurn = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's CurrentTurn operators
        /// </summary>
		public DropDownList OperatorsForCurrentTurn {
			get { return operatorsForCurrentTurn; }
			set { operatorsForCurrentTurn = value; }
		}
		
		/// <summary>
        /// Search box for Battle's HasEnded property
        /// </summary>
		public TextBox HasEnded {
			get { return hasEnded; }
			set { hasEnded = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's HasEnded operators
        /// </summary>
		public DropDownList OperatorsForHasEnded {
			get { return operatorsForHasEnded; }
			set { operatorsForHasEnded = value; }
		}
		
		/// <summary>
        /// Search box for Battle's BattleType property
        /// </summary>
		public TextBox BattleType {
			get { return battleType; }
			set { battleType = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's BattleType operators
        /// </summary>
		public DropDownList OperatorsForBattleType {
			get { return operatorsForBattleType; }
			set { operatorsForBattleType = value; }
		}
		
		/// <summary>
        /// Search box for Battle's BattleMode property
        /// </summary>
		public TextBox BattleMode {
			get { return battleMode; }
			set { battleMode = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's BattleMode operators
        /// </summary>
		public DropDownList OperatorsForBattleMode {
			get { return operatorsForBattleMode; }
			set { operatorsForBattleMode = value; }
		}
		
		/// <summary>
        /// Search box for Battle's UnitsDestroyed property
        /// </summary>
		public TextBox UnitsDestroyed {
			get { return unitsDestroyed; }
			set { unitsDestroyed = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's UnitsDestroyed operators
        /// </summary>
		public DropDownList OperatorsForUnitsDestroyed {
			get { return operatorsForUnitsDestroyed; }
			set { operatorsForUnitsDestroyed = value; }
		}
		
		/// <summary>
        /// Search box for Battle's Terrain property
        /// </summary>
		public TextBox Terrain {
			get { return terrain; }
			set { terrain = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's Terrain operators
        /// </summary>
		public DropDownList OperatorsForTerrain {
			get { return operatorsForTerrain; }
			set { operatorsForTerrain = value; }
		}
		
		/// <summary>
        /// Search box for Battle's CurrentPlayer property
        /// </summary>
		public TextBox CurrentPlayer {
			get { return currentPlayer; }
			set { currentPlayer = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's CurrentPlayer operators
        /// </summary>
		public DropDownList OperatorsForCurrentPlayer {
			get { return operatorsForCurrentPlayer; }
			set { operatorsForCurrentPlayer = value; }
		}
		
		/// <summary>
        /// Search box for Battle's TimeoutsAllowed property
        /// </summary>
		public TextBox TimeoutsAllowed {
			get { return timeoutsAllowed; }
			set { timeoutsAllowed = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's TimeoutsAllowed operators
        /// </summary>
		public DropDownList OperatorsForTimeoutsAllowed {
			get { return operatorsForTimeoutsAllowed; }
			set { operatorsForTimeoutsAllowed = value; }
		}
		
		/// <summary>
        /// Search box for Battle's TournamentMode property
        /// </summary>
		public TextBox TournamentMode {
			get { return tournamentMode; }
			set { tournamentMode = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's TournamentMode operators
        /// </summary>
		public DropDownList OperatorsForTournamentMode {
			get { return operatorsForTournamentMode; }
			set { operatorsForTournamentMode = value; }
		}
		
		/// <summary>
        /// Search box for Battle's IsDeployTime property
        /// </summary>
		public TextBox IsDeployTime {
			get { return isDeployTime; }
			set { isDeployTime = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's IsDeployTime operators
        /// </summary>
		public DropDownList OperatorsForIsDeployTime {
			get { return operatorsForIsDeployTime; }
			set { operatorsForIsDeployTime = value; }
		}
		
		/// <summary>
        /// Search box for Battle's IsTeamBattle property
        /// </summary>
		public TextBox IsTeamBattle {
			get { return isTeamBattle; }
			set { isTeamBattle = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's IsTeamBattle operators
        /// </summary>
		public DropDownList OperatorsForIsTeamBattle {
			get { return operatorsForIsTeamBattle; }
			set { operatorsForIsTeamBattle = value; }
		}
		
		/// <summary>
        /// Search box for Battle's SeqNumber property
        /// </summary>
		public TextBox SeqNumber {
			get { return seqNumber; }
			set { seqNumber = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's SeqNumber operators
        /// </summary>
		public DropDownList OperatorsForSeqNumber {
			get { return operatorsForSeqNumber; }
			set { operatorsForSeqNumber = value; }
		}
		
		/// <summary>
        /// Search box for Battle's IsToConquer property
        /// </summary>
		public TextBox IsToConquer {
			get { return isToConquer; }
			set { isToConquer = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's IsToConquer operators
        /// </summary>
		public DropDownList OperatorsForIsToConquer {
			get { return operatorsForIsToConquer; }
			set { operatorsForIsToConquer = value; }
		}
		
		/// <summary>
        /// Search box for Battle's IsInPlanet property
        /// </summary>
		public TextBox IsInPlanet {
			get { return isInPlanet; }
			set { isInPlanet = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's IsInPlanet operators
        /// </summary>
		public DropDownList OperatorsForIsInPlanet {
			get { return operatorsForIsInPlanet; }
			set { operatorsForIsInPlanet = value; }
		}
		
		/// <summary>
        /// Search box for Battle's CurrentBot property
        /// </summary>
		public TextBox CurrentBot {
			get { return currentBot; }
			set { currentBot = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's CurrentBot operators
        /// </summary>
		public DropDownList OperatorsForCurrentBot {
			get { return operatorsForCurrentBot; }
			set { operatorsForCurrentBot = value; }
		}
		
		/// <summary>
        /// Search box for Battle's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Battle's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Battle's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Battle's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( CurrentTurn.Text ) ) {
					writer.Write( "{2} e.CurrentTurn {0} '{1}' ",
							operatorsForCurrentTurn.SelectedValue, 
							CurrentTurn.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasEnded.Text ) ) {
					writer.Write( "{2} e.HasEnded {0} '{1}' ",
							operatorsForHasEnded.SelectedValue, 
							HasEnded.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BattleType.Text ) ) {
					writer.Write( "{2} e.BattleType {0} '{1}' ",
							operatorsForBattleType.SelectedValue, 
							BattleType.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BattleMode.Text ) ) {
					writer.Write( "{2} e.BattleMode {0} '{1}' ",
							operatorsForBattleMode.SelectedValue, 
							BattleMode.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UnitsDestroyed.Text ) ) {
					writer.Write( "{2} e.UnitsDestroyed {0} '{1}' ",
							operatorsForUnitsDestroyed.SelectedValue, 
							UnitsDestroyed.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Terrain.Text ) ) {
					writer.Write( "{2} e.Terrain {0} '{1}' ",
							operatorsForTerrain.SelectedValue, 
							Terrain.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CurrentPlayer.Text ) ) {
					writer.Write( "{2} e.CurrentPlayer {0} '{1}' ",
							operatorsForCurrentPlayer.SelectedValue, 
							CurrentPlayer.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TimeoutsAllowed.Text ) ) {
					writer.Write( "{2} e.TimeoutsAllowed {0} '{1}' ",
							operatorsForTimeoutsAllowed.SelectedValue, 
							TimeoutsAllowed.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TournamentMode.Text ) ) {
					writer.Write( "{2} e.TournamentMode {0} '{1}' ",
							operatorsForTournamentMode.SelectedValue, 
							TournamentMode.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsDeployTime.Text ) ) {
					writer.Write( "{2} e.IsDeployTime {0} '{1}' ",
							operatorsForIsDeployTime.SelectedValue, 
							IsDeployTime.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsTeamBattle.Text ) ) {
					writer.Write( "{2} e.IsTeamBattle {0} '{1}' ",
							operatorsForIsTeamBattle.SelectedValue, 
							IsTeamBattle.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SeqNumber.Text ) ) {
					writer.Write( "{2} e.SeqNumber {0} '{1}' ",
							operatorsForSeqNumber.SelectedValue, 
							SeqNumber.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsToConquer.Text ) ) {
					writer.Write( "{2} e.IsToConquer {0} '{1}' ",
							operatorsForIsToConquer.SelectedValue, 
							IsToConquer.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsInPlanet.Text ) ) {
					writer.Write( "{2} e.IsInPlanet {0} '{1}' ",
							operatorsForIsInPlanet.SelectedValue, 
							IsInPlanet.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( CurrentBot.Text ) ) {
					writer.Write( "{2} e.CurrentBot {0} '{1}' ",
							operatorsForCurrentBot.SelectedValue, 
							CurrentBot.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Battle>.GetWhereKey("Battle")] = writer.ToString();
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
			CurrentTurn.ID = "searchCurrentTurn";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CurrentTurn</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrentTurn ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CurrentTurn );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasEnded.ID = "searchHasEnded";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasEnded</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasEnded ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasEnded );
			Controls.Add( new LiteralControl("</td><tr>") );
			BattleType.ID = "searchBattleType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BattleType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBattleType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BattleType );
			Controls.Add( new LiteralControl("</td><tr>") );
			BattleMode.ID = "searchBattleMode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BattleMode</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBattleMode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BattleMode );
			Controls.Add( new LiteralControl("</td><tr>") );
			UnitsDestroyed.ID = "searchUnitsDestroyed";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UnitsDestroyed</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUnitsDestroyed ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UnitsDestroyed );
			Controls.Add( new LiteralControl("</td><tr>") );
			Terrain.ID = "searchTerrain";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Terrain</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTerrain ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Terrain );
			Controls.Add( new LiteralControl("</td><tr>") );
			CurrentPlayer.ID = "searchCurrentPlayer";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CurrentPlayer</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrentPlayer ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CurrentPlayer );
			Controls.Add( new LiteralControl("</td><tr>") );
			TimeoutsAllowed.ID = "searchTimeoutsAllowed";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TimeoutsAllowed</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTimeoutsAllowed ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TimeoutsAllowed );
			Controls.Add( new LiteralControl("</td><tr>") );
			TournamentMode.ID = "searchTournamentMode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TournamentMode</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTournamentMode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TournamentMode );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsDeployTime.ID = "searchIsDeployTime";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsDeployTime</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsDeployTime ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsDeployTime );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsTeamBattle.ID = "searchIsTeamBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsTeamBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsTeamBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsTeamBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			SeqNumber.ID = "searchSeqNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SeqNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSeqNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SeqNumber );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsToConquer.ID = "searchIsToConquer";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsToConquer</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsToConquer ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsToConquer );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsInPlanet.ID = "searchIsInPlanet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInPlanet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInPlanet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInPlanet );
			Controls.Add( new LiteralControl("</td><tr>") );
			CurrentBot.ID = "searchCurrentBot";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CurrentBot</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrentBot ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CurrentBot );
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
