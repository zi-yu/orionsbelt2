
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
    /// Control that enables UniverseSpecialSector search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a UniverseSpecialSectorPagedList
    /// </remarks>
	public class UniverseSpecialSectorSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox systemX = new TextBox();
		protected DropDownList operatorsForSystemX = new DropDownList();
		protected TextBox systemY = new TextBox();
		protected DropDownList operatorsForSystemY = new DropDownList();
		protected TextBox sectorX = new TextBox();
		protected DropDownList operatorsForSectorX = new DropDownList();
		protected TextBox sectorY = new TextBox();
		protected DropDownList operatorsForSectorY = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
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
        /// Search box for UniverseSpecialSector's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's SystemX property
        /// </summary>
		public TextBox SystemX {
			get { return systemX; }
			set { systemX = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's SystemX operators
        /// </summary>
		public DropDownList OperatorsForSystemX {
			get { return operatorsForSystemX; }
			set { operatorsForSystemX = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's SystemY property
        /// </summary>
		public TextBox SystemY {
			get { return systemY; }
			set { systemY = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's SystemY operators
        /// </summary>
		public DropDownList OperatorsForSystemY {
			get { return operatorsForSystemY; }
			set { operatorsForSystemY = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's SectorX property
        /// </summary>
		public TextBox SectorX {
			get { return sectorX; }
			set { sectorX = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's SectorX operators
        /// </summary>
		public DropDownList OperatorsForSectorX {
			get { return operatorsForSectorX; }
			set { operatorsForSectorX = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's SectorY property
        /// </summary>
		public TextBox SectorY {
			get { return sectorY; }
			set { sectorY = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's SectorY operators
        /// </summary>
		public DropDownList OperatorsForSectorY {
			get { return operatorsForSectorY; }
			set { operatorsForSectorY = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for UniverseSpecialSector's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for UniverseSpecialSector's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<UniverseSpecialSector>.GetWhereKey("UniverseSpecialSector")] = writer.ToString();
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
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
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
