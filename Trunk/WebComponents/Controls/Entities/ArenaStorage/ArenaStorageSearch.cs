
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
    /// Control that enables ArenaStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ArenaStoragePagedList
    /// </remarks>
	public class ArenaStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox isInBattle = new TextBox();
		protected DropDownList operatorsForIsInBattle = new DropDownList();
		protected TextBox conquestTick = new TextBox();
		protected DropDownList operatorsForConquestTick = new DropDownList();
		protected TextBox battleType = new TextBox();
		protected DropDownList operatorsForBattleType = new DropDownList();
		protected TextBox coordinate = new TextBox();
		protected DropDownList operatorsForCoordinate = new DropDownList();
		protected TextBox payment = new TextBox();
		protected DropDownList operatorsForPayment = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
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
        /// Search box for ArenaStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's IsInBattle property
        /// </summary>
		public TextBox IsInBattle {
			get { return isInBattle; }
			set { isInBattle = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's IsInBattle operators
        /// </summary>
		public DropDownList OperatorsForIsInBattle {
			get { return operatorsForIsInBattle; }
			set { operatorsForIsInBattle = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's ConquestTick property
        /// </summary>
		public TextBox ConquestTick {
			get { return conquestTick; }
			set { conquestTick = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's ConquestTick operators
        /// </summary>
		public DropDownList OperatorsForConquestTick {
			get { return operatorsForConquestTick; }
			set { operatorsForConquestTick = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's BattleType property
        /// </summary>
		public TextBox BattleType {
			get { return battleType; }
			set { battleType = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's BattleType operators
        /// </summary>
		public DropDownList OperatorsForBattleType {
			get { return operatorsForBattleType; }
			set { operatorsForBattleType = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's Coordinate property
        /// </summary>
		public TextBox Coordinate {
			get { return coordinate; }
			set { coordinate = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's Coordinate operators
        /// </summary>
		public DropDownList OperatorsForCoordinate {
			get { return operatorsForCoordinate; }
			set { operatorsForCoordinate = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's Payment property
        /// </summary>
		public TextBox Payment {
			get { return payment; }
			set { payment = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's Payment operators
        /// </summary>
		public DropDownList OperatorsForPayment {
			get { return operatorsForPayment; }
			set { operatorsForPayment = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ArenaStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ArenaStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( IsInBattle.Text ) ) {
					writer.Write( "{2} e.IsInBattle {0} '{1}' ",
							operatorsForIsInBattle.SelectedValue, 
							IsInBattle.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ConquestTick.Text ) ) {
					writer.Write( "{2} e.ConquestTick {0} '{1}' ",
							operatorsForConquestTick.SelectedValue, 
							ConquestTick.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Coordinate.Text ) ) {
					writer.Write( "{2} e.Coordinate {0} '{1}' ",
							operatorsForCoordinate.SelectedValue, 
							Coordinate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Payment.Text ) ) {
					writer.Write( "{2} e.Payment {0} '{1}' ",
							operatorsForPayment.SelectedValue, 
							Payment.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<ArenaStorage>.GetWhereKey("ArenaStorage")] = writer.ToString();
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
			IsInBattle.ID = "searchIsInBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			ConquestTick.ID = "searchConquestTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ConquestTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForConquestTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ConquestTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			BattleType.ID = "searchBattleType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BattleType</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBattleType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BattleType );
			Controls.Add( new LiteralControl("</td><tr>") );
			Coordinate.ID = "searchCoordinate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Coordinate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCoordinate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Coordinate );
			Controls.Add( new LiteralControl("</td><tr>") );
			Payment.ID = "searchPayment";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Payment</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPayment ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Payment );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
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
