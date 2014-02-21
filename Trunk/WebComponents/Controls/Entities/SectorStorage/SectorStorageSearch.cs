
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
    /// Control that enables SectorStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a SectorStoragePagedList
    /// </remarks>
	public class SectorStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox isStatic = new TextBox();
		protected DropDownList operatorsForIsStatic = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox subType = new TextBox();
		protected DropDownList operatorsForSubType = new DropDownList();
		protected TextBox systemX = new TextBox();
		protected DropDownList operatorsForSystemX = new DropDownList();
		protected TextBox systemY = new TextBox();
		protected DropDownList operatorsForSystemY = new DropDownList();
		protected TextBox sectorX = new TextBox();
		protected DropDownList operatorsForSectorX = new DropDownList();
		protected TextBox sectorY = new TextBox();
		protected DropDownList operatorsForSectorY = new DropDownList();
		protected TextBox additionalInformation = new TextBox();
		protected DropDownList operatorsForAdditionalInformation = new DropDownList();
		protected TextBox isInBattle = new TextBox();
		protected DropDownList operatorsForIsInBattle = new DropDownList();
		protected TextBox isConstructing = new TextBox();
		protected DropDownList operatorsForIsConstructing = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
		protected TextBox isMoving = new TextBox();
		protected DropDownList operatorsForIsMoving = new DropDownList();
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
        /// Search box for SectorStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's IsStatic property
        /// </summary>
		public TextBox IsStatic {
			get { return isStatic; }
			set { isStatic = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's IsStatic operators
        /// </summary>
		public DropDownList OperatorsForIsStatic {
			get { return operatorsForIsStatic; }
			set { operatorsForIsStatic = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's SubType property
        /// </summary>
		public TextBox SubType {
			get { return subType; }
			set { subType = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's SubType operators
        /// </summary>
		public DropDownList OperatorsForSubType {
			get { return operatorsForSubType; }
			set { operatorsForSubType = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's SystemX property
        /// </summary>
		public TextBox SystemX {
			get { return systemX; }
			set { systemX = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's SystemX operators
        /// </summary>
		public DropDownList OperatorsForSystemX {
			get { return operatorsForSystemX; }
			set { operatorsForSystemX = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's SystemY property
        /// </summary>
		public TextBox SystemY {
			get { return systemY; }
			set { systemY = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's SystemY operators
        /// </summary>
		public DropDownList OperatorsForSystemY {
			get { return operatorsForSystemY; }
			set { operatorsForSystemY = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's SectorX property
        /// </summary>
		public TextBox SectorX {
			get { return sectorX; }
			set { sectorX = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's SectorX operators
        /// </summary>
		public DropDownList OperatorsForSectorX {
			get { return operatorsForSectorX; }
			set { operatorsForSectorX = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's SectorY property
        /// </summary>
		public TextBox SectorY {
			get { return sectorY; }
			set { sectorY = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's SectorY operators
        /// </summary>
		public DropDownList OperatorsForSectorY {
			get { return operatorsForSectorY; }
			set { operatorsForSectorY = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's AdditionalInformation property
        /// </summary>
		public TextBox AdditionalInformation {
			get { return additionalInformation; }
			set { additionalInformation = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's AdditionalInformation operators
        /// </summary>
		public DropDownList OperatorsForAdditionalInformation {
			get { return operatorsForAdditionalInformation; }
			set { operatorsForAdditionalInformation = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's IsInBattle property
        /// </summary>
		public TextBox IsInBattle {
			get { return isInBattle; }
			set { isInBattle = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's IsInBattle operators
        /// </summary>
		public DropDownList OperatorsForIsInBattle {
			get { return operatorsForIsInBattle; }
			set { operatorsForIsInBattle = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's IsConstructing property
        /// </summary>
		public TextBox IsConstructing {
			get { return isConstructing; }
			set { isConstructing = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's IsConstructing operators
        /// </summary>
		public DropDownList OperatorsForIsConstructing {
			get { return operatorsForIsConstructing; }
			set { operatorsForIsConstructing = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's IsMoving property
        /// </summary>
		public TextBox IsMoving {
			get { return isMoving; }
			set { isMoving = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's IsMoving operators
        /// </summary>
		public DropDownList OperatorsForIsMoving {
			get { return operatorsForIsMoving; }
			set { operatorsForIsMoving = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for SectorStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for SectorStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( IsStatic.Text ) ) {
					writer.Write( "{2} e.IsStatic {0} '{1}' ",
							operatorsForIsStatic.SelectedValue, 
							IsStatic.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( SubType.Text ) ) {
					writer.Write( "{2} e.SubType {0} '{1}' ",
							operatorsForSubType.SelectedValue, 
							SubType.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( AdditionalInformation.Text ) ) {
					writer.Write( "{2} e.AdditionalInformation {0} '{1}' ",
							operatorsForAdditionalInformation.SelectedValue, 
							AdditionalInformation.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( IsConstructing.Text ) ) {
					writer.Write( "{2} e.IsConstructing {0} '{1}' ",
							operatorsForIsConstructing.SelectedValue, 
							IsConstructing.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( IsMoving.Text ) ) {
					writer.Write( "{2} e.IsMoving {0} '{1}' ",
							operatorsForIsMoving.SelectedValue, 
							IsMoving.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<SectorStorage>.GetWhereKey("SectorStorage")] = writer.ToString();
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
			IsStatic.ID = "searchIsStatic";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsStatic</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsStatic ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsStatic );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			SubType.ID = "searchSubType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>SubType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSubType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( SubType );
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
			AdditionalInformation.ID = "searchAdditionalInformation";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>AdditionalInformation</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForAdditionalInformation ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( AdditionalInformation );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsInBattle.ID = "searchIsInBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsConstructing.ID = "searchIsConstructing";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsConstructing</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsConstructing ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsConstructing );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsMoving.ID = "searchIsMoving";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsMoving</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsMoving ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsMoving );
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
