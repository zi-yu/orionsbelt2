
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
    /// Control that enables FogOfWarStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a FogOfWarStoragePagedList
    /// </remarks>
	public class FogOfWarStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox systemX = new TextBox();
		protected DropDownList operatorsForSystemX = new DropDownList();
		protected TextBox systemY = new TextBox();
		protected DropDownList operatorsForSystemY = new DropDownList();
		protected TextBox sectors = new TextBox();
		protected DropDownList operatorsForSectors = new DropDownList();
		protected TextBox hasDiscoveredAll = new TextBox();
		protected DropDownList operatorsForHasDiscoveredAll = new DropDownList();
		protected TextBox hasDiscoveredHalf = new TextBox();
		protected DropDownList operatorsForHasDiscoveredHalf = new DropDownList();
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
        /// Search box for FogOfWarStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's SystemX property
        /// </summary>
		public TextBox SystemX {
			get { return systemX; }
			set { systemX = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's SystemX operators
        /// </summary>
		public DropDownList OperatorsForSystemX {
			get { return operatorsForSystemX; }
			set { operatorsForSystemX = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's SystemY property
        /// </summary>
		public TextBox SystemY {
			get { return systemY; }
			set { systemY = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's SystemY operators
        /// </summary>
		public DropDownList OperatorsForSystemY {
			get { return operatorsForSystemY; }
			set { operatorsForSystemY = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's Sectors property
        /// </summary>
		public TextBox Sectors {
			get { return sectors; }
			set { sectors = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's Sectors operators
        /// </summary>
		public DropDownList OperatorsForSectors {
			get { return operatorsForSectors; }
			set { operatorsForSectors = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's HasDiscoveredAll property
        /// </summary>
		public TextBox HasDiscoveredAll {
			get { return hasDiscoveredAll; }
			set { hasDiscoveredAll = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's HasDiscoveredAll operators
        /// </summary>
		public DropDownList OperatorsForHasDiscoveredAll {
			get { return operatorsForHasDiscoveredAll; }
			set { operatorsForHasDiscoveredAll = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's HasDiscoveredHalf property
        /// </summary>
		public TextBox HasDiscoveredHalf {
			get { return hasDiscoveredHalf; }
			set { hasDiscoveredHalf = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's HasDiscoveredHalf operators
        /// </summary>
		public DropDownList OperatorsForHasDiscoveredHalf {
			get { return operatorsForHasDiscoveredHalf; }
			set { operatorsForHasDiscoveredHalf = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for FogOfWarStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for FogOfWarStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Sectors.Text ) ) {
					writer.Write( "{2} e.Sectors {0} '{1}' ",
							operatorsForSectors.SelectedValue, 
							Sectors.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasDiscoveredAll.Text ) ) {
					writer.Write( "{2} e.HasDiscoveredAll {0} '{1}' ",
							operatorsForHasDiscoveredAll.SelectedValue, 
							HasDiscoveredAll.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( HasDiscoveredHalf.Text ) ) {
					writer.Write( "{2} e.HasDiscoveredHalf {0} '{1}' ",
							operatorsForHasDiscoveredHalf.SelectedValue, 
							HasDiscoveredHalf.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<FogOfWarStorage>.GetWhereKey("FogOfWarStorage")] = writer.ToString();
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
			Sectors.ID = "searchSectors";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Sectors</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSectors ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Sectors );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasDiscoveredAll.ID = "searchHasDiscoveredAll";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasDiscoveredAll</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasDiscoveredAll ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasDiscoveredAll );
			Controls.Add( new LiteralControl("</td><tr>") );
			HasDiscoveredHalf.ID = "searchHasDiscoveredHalf";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasDiscoveredHalf</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasDiscoveredHalf ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasDiscoveredHalf );
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
