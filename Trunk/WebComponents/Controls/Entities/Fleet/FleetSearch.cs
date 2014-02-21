
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
    /// Control that enables Fleet search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a FleetPagedList
    /// </remarks>
	public class FleetSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox units = new TextBox();
		protected DropDownList operatorsForUnits = new DropDownList();
		protected TextBox tournamentFleet = new TextBox();
		protected DropDownList operatorsForTournamentFleet = new DropDownList();
		protected TextBox isMovable = new TextBox();
		protected DropDownList operatorsForIsMovable = new DropDownList();
		protected TextBox ultimateUnit = new TextBox();
		protected DropDownList operatorsForUltimateUnit = new DropDownList();
		protected TextBox isInBattle = new TextBox();
		protected DropDownList operatorsForIsInBattle = new DropDownList();
		protected TextBox isPlanetDefenseFleet = new TextBox();
		protected DropDownList operatorsForIsPlanetDefenseFleet = new DropDownList();
		protected TextBox systemX = new TextBox();
		protected DropDownList operatorsForSystemX = new DropDownList();
		protected TextBox systemY = new TextBox();
		protected DropDownList operatorsForSystemY = new DropDownList();
		protected TextBox sectorX = new TextBox();
		protected DropDownList operatorsForSectorX = new DropDownList();
		protected TextBox sectorY = new TextBox();
		protected DropDownList operatorsForSectorY = new DropDownList();
		protected TextBox cargo = new TextBox();
		protected DropDownList operatorsForCargo = new DropDownList();
		protected TextBox isBot = new TextBox();
		protected DropDownList operatorsForIsBot = new DropDownList();
		protected TextBox wayPoints = new TextBox();
		protected DropDownList operatorsForWayPoints = new DropDownList();
		protected TextBox immunityStartTick = new TextBox();
		protected DropDownList operatorsForImmunityStartTick = new DropDownList();
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
        /// Search box for Fleet's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's Units property
        /// </summary>
		public TextBox Units {
			get { return units; }
			set { units = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's Units operators
        /// </summary>
		public DropDownList OperatorsForUnits {
			get { return operatorsForUnits; }
			set { operatorsForUnits = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's TournamentFleet property
        /// </summary>
		public TextBox TournamentFleet {
			get { return tournamentFleet; }
			set { tournamentFleet = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's TournamentFleet operators
        /// </summary>
		public DropDownList OperatorsForTournamentFleet {
			get { return operatorsForTournamentFleet; }
			set { operatorsForTournamentFleet = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's IsMovable property
        /// </summary>
		public TextBox IsMovable {
			get { return isMovable; }
			set { isMovable = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's IsMovable operators
        /// </summary>
		public DropDownList OperatorsForIsMovable {
			get { return operatorsForIsMovable; }
			set { operatorsForIsMovable = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's UltimateUnit property
        /// </summary>
		public TextBox UltimateUnit {
			get { return ultimateUnit; }
			set { ultimateUnit = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's UltimateUnit operators
        /// </summary>
		public DropDownList OperatorsForUltimateUnit {
			get { return operatorsForUltimateUnit; }
			set { operatorsForUltimateUnit = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's IsInBattle property
        /// </summary>
		public TextBox IsInBattle {
			get { return isInBattle; }
			set { isInBattle = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's IsInBattle operators
        /// </summary>
		public DropDownList OperatorsForIsInBattle {
			get { return operatorsForIsInBattle; }
			set { operatorsForIsInBattle = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's IsPlanetDefenseFleet property
        /// </summary>
		public TextBox IsPlanetDefenseFleet {
			get { return isPlanetDefenseFleet; }
			set { isPlanetDefenseFleet = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's IsPlanetDefenseFleet operators
        /// </summary>
		public DropDownList OperatorsForIsPlanetDefenseFleet {
			get { return operatorsForIsPlanetDefenseFleet; }
			set { operatorsForIsPlanetDefenseFleet = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's SystemX property
        /// </summary>
		public TextBox SystemX {
			get { return systemX; }
			set { systemX = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's SystemX operators
        /// </summary>
		public DropDownList OperatorsForSystemX {
			get { return operatorsForSystemX; }
			set { operatorsForSystemX = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's SystemY property
        /// </summary>
		public TextBox SystemY {
			get { return systemY; }
			set { systemY = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's SystemY operators
        /// </summary>
		public DropDownList OperatorsForSystemY {
			get { return operatorsForSystemY; }
			set { operatorsForSystemY = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's SectorX property
        /// </summary>
		public TextBox SectorX {
			get { return sectorX; }
			set { sectorX = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's SectorX operators
        /// </summary>
		public DropDownList OperatorsForSectorX {
			get { return operatorsForSectorX; }
			set { operatorsForSectorX = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's SectorY property
        /// </summary>
		public TextBox SectorY {
			get { return sectorY; }
			set { sectorY = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's SectorY operators
        /// </summary>
		public DropDownList OperatorsForSectorY {
			get { return operatorsForSectorY; }
			set { operatorsForSectorY = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's Cargo property
        /// </summary>
		public TextBox Cargo {
			get { return cargo; }
			set { cargo = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's Cargo operators
        /// </summary>
		public DropDownList OperatorsForCargo {
			get { return operatorsForCargo; }
			set { operatorsForCargo = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's IsBot property
        /// </summary>
		public TextBox IsBot {
			get { return isBot; }
			set { isBot = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's IsBot operators
        /// </summary>
		public DropDownList OperatorsForIsBot {
			get { return operatorsForIsBot; }
			set { operatorsForIsBot = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's WayPoints property
        /// </summary>
		public TextBox WayPoints {
			get { return wayPoints; }
			set { wayPoints = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's WayPoints operators
        /// </summary>
		public DropDownList OperatorsForWayPoints {
			get { return operatorsForWayPoints; }
			set { operatorsForWayPoints = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's ImmunityStartTick property
        /// </summary>
		public TextBox ImmunityStartTick {
			get { return immunityStartTick; }
			set { immunityStartTick = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's ImmunityStartTick operators
        /// </summary>
		public DropDownList OperatorsForImmunityStartTick {
			get { return operatorsForImmunityStartTick; }
			set { operatorsForImmunityStartTick = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Fleet's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Fleet's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Units.Text ) ) {
					writer.Write( "{2} e.Units {0} '{1}' ",
							operatorsForUnits.SelectedValue, 
							Units.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TournamentFleet.Text ) ) {
					writer.Write( "{2} e.TournamentFleet {0} '{1}' ",
							operatorsForTournamentFleet.SelectedValue, 
							TournamentFleet.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsMovable.Text ) ) {
					writer.Write( "{2} e.IsMovable {0} '{1}' ",
							operatorsForIsMovable.SelectedValue, 
							IsMovable.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( IsInBattle.Text ) ) {
					writer.Write( "{2} e.IsInBattle {0} '{1}' ",
							operatorsForIsInBattle.SelectedValue, 
							IsInBattle.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsPlanetDefenseFleet.Text ) ) {
					writer.Write( "{2} e.IsPlanetDefenseFleet {0} '{1}' ",
							operatorsForIsPlanetDefenseFleet.SelectedValue, 
							IsPlanetDefenseFleet.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SystemX.Text ) ) {
					writer.Write( "{2} e.SystemX {0} '{1}' ",
							operatorsForSystemX.SelectedValue, 
							SystemX.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SystemY.Text ) ) {
					writer.Write( "{2} e.SystemY {0} '{1}' ",
							operatorsForSystemY.SelectedValue, 
							SystemY.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SectorX.Text ) ) {
					writer.Write( "{2} e.SectorX {0} '{1}' ",
							operatorsForSectorX.SelectedValue, 
							SectorX.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( SectorY.Text ) ) {
					writer.Write( "{2} e.SectorY {0} '{1}' ",
							operatorsForSectorY.SelectedValue, 
							SectorY.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Cargo.Text ) ) {
					writer.Write( "{2} e.Cargo {0} '{1}' ",
							operatorsForCargo.SelectedValue, 
							Cargo.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsBot.Text ) ) {
					writer.Write( "{2} e.IsBot {0} '{1}' ",
							operatorsForIsBot.SelectedValue, 
							IsBot.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( WayPoints.Text ) ) {
					writer.Write( "{2} e.WayPoints {0} '{1}' ",
							operatorsForWayPoints.SelectedValue, 
							WayPoints.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ImmunityStartTick.Text ) ) {
					writer.Write( "{2} e.ImmunityStartTick {0} '{1}' ",
							operatorsForImmunityStartTick.SelectedValue, 
							ImmunityStartTick.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Fleet>.GetWhereKey("Fleet")] = writer.ToString();
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
			Units.ID = "searchUnits";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Units</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUnits ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Units );
			Controls.Add( new LiteralControl("</td><tr>") );
			TournamentFleet.ID = "searchTournamentFleet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TournamentFleet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTournamentFleet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TournamentFleet );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsMovable.ID = "searchIsMovable";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsMovable</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsMovable ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsMovable );
			Controls.Add( new LiteralControl("</td><tr>") );
			UltimateUnit.ID = "searchUltimateUnit";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UltimateUnit</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUltimateUnit ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UltimateUnit );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsInBattle.ID = "searchIsInBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsPlanetDefenseFleet.ID = "searchIsPlanetDefenseFleet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsPlanetDefenseFleet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsPlanetDefenseFleet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsPlanetDefenseFleet );
			Controls.Add( new LiteralControl("</td><tr>") );
			SystemX.ID = "searchSystemX";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SystemX</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSystemX ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SystemX );
			Controls.Add( new LiteralControl("</td><tr>") );
			SystemY.ID = "searchSystemY";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SystemY</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSystemY ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SystemY );
			Controls.Add( new LiteralControl("</td><tr>") );
			SectorX.ID = "searchSectorX";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SectorX</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSectorX ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SectorX );
			Controls.Add( new LiteralControl("</td><tr>") );
			SectorY.ID = "searchSectorY";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SectorY</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSectorY ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SectorY );
			Controls.Add( new LiteralControl("</td><tr>") );
			Cargo.ID = "searchCargo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Cargo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCargo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Cargo );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsBot.ID = "searchIsBot";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsBot</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsBot ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsBot );
			Controls.Add( new LiteralControl("</td><tr>") );
			WayPoints.ID = "searchWayPoints";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>WayPoints</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWayPoints ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( WayPoints );
			Controls.Add( new LiteralControl("</td><tr>") );
			ImmunityStartTick.ID = "searchImmunityStartTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ImmunityStartTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForImmunityStartTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ImmunityStartTick );
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
