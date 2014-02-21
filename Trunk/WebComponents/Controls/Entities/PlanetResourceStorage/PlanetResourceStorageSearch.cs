
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
    /// Control that enables PlanetResourceStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlanetResourceStoragePagedList
    /// </remarks>
	public class PlanetResourceStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox quantity = new TextBox();
		protected DropDownList operatorsForQuantity = new DropDownList();
		protected TextBox state = new TextBox();
		protected DropDownList operatorsForState = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox queueOrder = new TextBox();
		protected DropDownList operatorsForQueueOrder = new DropDownList();
		protected TextBox slot = new TextBox();
		protected DropDownList operatorsForSlot = new DropDownList();
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
        /// Search box for PlanetResourceStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's Quantity property
        /// </summary>
		public TextBox Quantity {
			get { return quantity; }
			set { quantity = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's Quantity operators
        /// </summary>
		public DropDownList OperatorsForQuantity {
			get { return operatorsForQuantity; }
			set { operatorsForQuantity = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's State property
        /// </summary>
		public TextBox State {
			get { return state; }
			set { state = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's State operators
        /// </summary>
		public DropDownList OperatorsForState {
			get { return operatorsForState; }
			set { operatorsForState = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's QueueOrder property
        /// </summary>
		public TextBox QueueOrder {
			get { return queueOrder; }
			set { queueOrder = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's QueueOrder operators
        /// </summary>
		public DropDownList OperatorsForQueueOrder {
			get { return operatorsForQueueOrder; }
			set { operatorsForQueueOrder = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's Slot property
        /// </summary>
		public TextBox Slot {
			get { return slot; }
			set { slot = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's Slot operators
        /// </summary>
		public DropDownList OperatorsForSlot {
			get { return operatorsForSlot; }
			set { operatorsForSlot = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's EndTick property
        /// </summary>
		public TextBox EndTick {
			get { return endTick; }
			set { endTick = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's EndTick operators
        /// </summary>
		public DropDownList OperatorsForEndTick {
			get { return operatorsForEndTick; }
			set { operatorsForEndTick = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlanetResourceStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlanetResourceStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Quantity.Text ) ) {
					writer.Write( "{2} e.Quantity {0} '{1}' ",
							operatorsForQuantity.SelectedValue, 
							Quantity.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( State.Text ) ) {
					writer.Write( "{2} e.State {0} '{1}' ",
							operatorsForState.SelectedValue, 
							State.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QueueOrder.Text ) ) {
					writer.Write( "{2} e.QueueOrder {0} '{1}' ",
							operatorsForQueueOrder.SelectedValue, 
							QueueOrder.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Slot.Text ) ) {
					writer.Write( "{2} e.Slot {0} '{1}' ",
							operatorsForSlot.SelectedValue, 
							Slot.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PlanetResourceStorage>.GetWhereKey("PlanetResourceStorage")] = writer.ToString();
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
			Quantity.ID = "searchQuantity";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Quantity</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuantity ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Quantity );
			Controls.Add( new LiteralControl("</td><tr>") );
			State.ID = "searchState";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>State</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForState ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( State );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			QueueOrder.ID = "searchQueueOrder";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QueueOrder</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQueueOrder ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QueueOrder );
			Controls.Add( new LiteralControl("</td><tr>") );
			Slot.ID = "searchSlot";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Slot</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForSlot ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Slot );
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
