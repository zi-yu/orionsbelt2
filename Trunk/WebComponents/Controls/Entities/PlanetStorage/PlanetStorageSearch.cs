
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
    /// Control that enables PlanetStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlanetStoragePagedList
    /// </remarks>
	public class PlanetStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox productionFactor = new TextBox();
		protected DropDownList operatorsForProductionFactor = new DropDownList();
		protected TextBox modifiers = new TextBox();
		protected DropDownList operatorsForModifiers = new DropDownList();
		protected TextBox richness = new TextBox();
		protected DropDownList operatorsForRichness = new DropDownList();
		protected TextBox info = new TextBox();
		protected DropDownList operatorsForInfo = new DropDownList();
		protected TextBox terrain = new TextBox();
		protected DropDownList operatorsForTerrain = new DropDownList();
		protected TextBox isPrivate = new TextBox();
		protected DropDownList operatorsForIsPrivate = new DropDownList();
		protected TextBox systemX = new TextBox();
		protected DropDownList operatorsForSystemX = new DropDownList();
		protected TextBox systemY = new TextBox();
		protected DropDownList operatorsForSystemY = new DropDownList();
		protected TextBox sectorX = new TextBox();
		protected DropDownList operatorsForSectorX = new DropDownList();
		protected TextBox sectorY = new TextBox();
		protected DropDownList operatorsForSectorY = new DropDownList();
		protected TextBox score = new TextBox();
		protected DropDownList operatorsForScore = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
		protected TextBox lastPillageTick = new TextBox();
		protected DropDownList operatorsForLastPillageTick = new DropDownList();
		protected TextBox lastConquerTick = new TextBox();
		protected DropDownList operatorsForLastConquerTick = new DropDownList();
		protected TextBox facilityLevel = new TextBox();
		protected DropDownList operatorsForFacilityLevel = new DropDownList();
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
        /// Search box for PlanetStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's ProductionFactor property
        /// </summary>
		public TextBox ProductionFactor {
			get { return productionFactor; }
			set { productionFactor = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's ProductionFactor operators
        /// </summary>
		public DropDownList OperatorsForProductionFactor {
			get { return operatorsForProductionFactor; }
			set { operatorsForProductionFactor = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Modifiers property
        /// </summary>
		public TextBox Modifiers {
			get { return modifiers; }
			set { modifiers = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Modifiers operators
        /// </summary>
		public DropDownList OperatorsForModifiers {
			get { return operatorsForModifiers; }
			set { operatorsForModifiers = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Richness property
        /// </summary>
		public TextBox Richness {
			get { return richness; }
			set { richness = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Richness operators
        /// </summary>
		public DropDownList OperatorsForRichness {
			get { return operatorsForRichness; }
			set { operatorsForRichness = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Info property
        /// </summary>
		public TextBox Info {
			get { return info; }
			set { info = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Info operators
        /// </summary>
		public DropDownList OperatorsForInfo {
			get { return operatorsForInfo; }
			set { operatorsForInfo = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Terrain property
        /// </summary>
		public TextBox Terrain {
			get { return terrain; }
			set { terrain = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Terrain operators
        /// </summary>
		public DropDownList OperatorsForTerrain {
			get { return operatorsForTerrain; }
			set { operatorsForTerrain = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's IsPrivate property
        /// </summary>
		public TextBox IsPrivate {
			get { return isPrivate; }
			set { isPrivate = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's IsPrivate operators
        /// </summary>
		public DropDownList OperatorsForIsPrivate {
			get { return operatorsForIsPrivate; }
			set { operatorsForIsPrivate = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's SystemX property
        /// </summary>
		public TextBox SystemX {
			get { return systemX; }
			set { systemX = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's SystemX operators
        /// </summary>
		public DropDownList OperatorsForSystemX {
			get { return operatorsForSystemX; }
			set { operatorsForSystemX = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's SystemY property
        /// </summary>
		public TextBox SystemY {
			get { return systemY; }
			set { systemY = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's SystemY operators
        /// </summary>
		public DropDownList OperatorsForSystemY {
			get { return operatorsForSystemY; }
			set { operatorsForSystemY = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's SectorX property
        /// </summary>
		public TextBox SectorX {
			get { return sectorX; }
			set { sectorX = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's SectorX operators
        /// </summary>
		public DropDownList OperatorsForSectorX {
			get { return operatorsForSectorX; }
			set { operatorsForSectorX = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's SectorY property
        /// </summary>
		public TextBox SectorY {
			get { return sectorY; }
			set { sectorY = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's SectorY operators
        /// </summary>
		public DropDownList OperatorsForSectorY {
			get { return operatorsForSectorY; }
			set { operatorsForSectorY = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Score property
        /// </summary>
		public TextBox Score {
			get { return score; }
			set { score = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Score operators
        /// </summary>
		public DropDownList OperatorsForScore {
			get { return operatorsForScore; }
			set { operatorsForScore = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's LastPillageTick property
        /// </summary>
		public TextBox LastPillageTick {
			get { return lastPillageTick; }
			set { lastPillageTick = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's LastPillageTick operators
        /// </summary>
		public DropDownList OperatorsForLastPillageTick {
			get { return operatorsForLastPillageTick; }
			set { operatorsForLastPillageTick = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's LastConquerTick property
        /// </summary>
		public TextBox LastConquerTick {
			get { return lastConquerTick; }
			set { lastConquerTick = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's LastConquerTick operators
        /// </summary>
		public DropDownList OperatorsForLastConquerTick {
			get { return operatorsForLastConquerTick; }
			set { operatorsForLastConquerTick = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's FacilityLevel property
        /// </summary>
		public TextBox FacilityLevel {
			get { return facilityLevel; }
			set { facilityLevel = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's FacilityLevel operators
        /// </summary>
		public DropDownList OperatorsForFacilityLevel {
			get { return operatorsForFacilityLevel; }
			set { operatorsForFacilityLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlanetStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( ProductionFactor.Text ) ) {
					writer.Write( "{2} e.ProductionFactor {0} '{1}' ",
							operatorsForProductionFactor.SelectedValue, 
							ProductionFactor.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Modifiers.Text ) ) {
					writer.Write( "{2} e.Modifiers {0} '{1}' ",
							operatorsForModifiers.SelectedValue, 
							Modifiers.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Richness.Text ) ) {
					writer.Write( "{2} e.Richness {0} '{1}' ",
							operatorsForRichness.SelectedValue, 
							Richness.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Info.Text ) ) {
					writer.Write( "{2} e.Info {0} '{1}' ",
							operatorsForInfo.SelectedValue, 
							Info.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( IsPrivate.Text ) ) {
					writer.Write( "{2} e.IsPrivate {0} '{1}' ",
							operatorsForIsPrivate.SelectedValue, 
							IsPrivate.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Score.Text ) ) {
					writer.Write( "{2} e.Score {0} '{1}' ",
							operatorsForScore.SelectedValue, 
							Score.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Level.Text ) ) {
					writer.Write( "{2} e.Level {0} '{1}' ",
							operatorsForLevel.SelectedValue, 
							Level.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastPillageTick.Text ) ) {
					writer.Write( "{2} e.LastPillageTick {0} '{1}' ",
							operatorsForLastPillageTick.SelectedValue, 
							LastPillageTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastConquerTick.Text ) ) {
					writer.Write( "{2} e.LastConquerTick {0} '{1}' ",
							operatorsForLastConquerTick.SelectedValue, 
							LastConquerTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( FacilityLevel.Text ) ) {
					writer.Write( "{2} e.FacilityLevel {0} '{1}' ",
							operatorsForFacilityLevel.SelectedValue, 
							FacilityLevel.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PlanetStorage>.GetWhereKey("PlanetStorage")] = writer.ToString();
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
			ProductionFactor.ID = "searchProductionFactor";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ProductionFactor</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForProductionFactor ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ProductionFactor );
			Controls.Add( new LiteralControl("</td><tr>") );
			Modifiers.ID = "searchModifiers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Modifiers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForModifiers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Modifiers );
			Controls.Add( new LiteralControl("</td><tr>") );
			Richness.ID = "searchRichness";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Richness</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRichness ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Richness );
			Controls.Add( new LiteralControl("</td><tr>") );
			Info.ID = "searchInfo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Info</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForInfo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Info );
			Controls.Add( new LiteralControl("</td><tr>") );
			Terrain.ID = "searchTerrain";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Terrain</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTerrain ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Terrain );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsPrivate.ID = "searchIsPrivate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsPrivate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsPrivate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsPrivate );
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
			Score.ID = "searchScore";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Score</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForScore ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Score );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastPillageTick.ID = "searchLastPillageTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastPillageTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastPillageTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastPillageTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastConquerTick.ID = "searchLastConquerTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastConquerTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastConquerTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastConquerTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			FacilityLevel.ID = "searchFacilityLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>FacilityLevel</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForFacilityLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( FacilityLevel );
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
