
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
    /// Control that enables PendingBotRequest search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PendingBotRequestPagedList
    /// </remarks>
	public class PendingBotRequestSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox botName = new TextBox();
		protected DropDownList operatorsForBotName = new DropDownList();
		protected TextBox xml = new TextBox();
		protected DropDownList operatorsForXml = new DropDownList();
		protected TextBox battleId = new TextBox();
		protected DropDownList operatorsForBattleId = new DropDownList();
		protected TextBox botId = new TextBox();
		protected DropDownList operatorsForBotId = new DropDownList();
		protected TextBox code = new TextBox();
		protected DropDownList operatorsForCode = new DropDownList();
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
        /// Search box for PendingBotRequest's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's BotName property
        /// </summary>
		public TextBox BotName {
			get { return botName; }
			set { botName = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's BotName operators
        /// </summary>
		public DropDownList OperatorsForBotName {
			get { return operatorsForBotName; }
			set { operatorsForBotName = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's Xml property
        /// </summary>
		public TextBox Xml {
			get { return xml; }
			set { xml = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's Xml operators
        /// </summary>
		public DropDownList OperatorsForXml {
			get { return operatorsForXml; }
			set { operatorsForXml = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's BattleId property
        /// </summary>
		public TextBox BattleId {
			get { return battleId; }
			set { battleId = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's BattleId operators
        /// </summary>
		public DropDownList OperatorsForBattleId {
			get { return operatorsForBattleId; }
			set { operatorsForBattleId = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's BotId property
        /// </summary>
		public TextBox BotId {
			get { return botId; }
			set { botId = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's BotId operators
        /// </summary>
		public DropDownList OperatorsForBotId {
			get { return operatorsForBotId; }
			set { operatorsForBotId = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's Code property
        /// </summary>
		public TextBox Code {
			get { return code; }
			set { code = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's Code operators
        /// </summary>
		public DropDownList OperatorsForCode {
			get { return operatorsForCode; }
			set { operatorsForCode = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PendingBotRequest's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PendingBotRequest's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( BotName.Text ) ) {
					writer.Write( "{2} e.BotName {0} '{1}' ",
							operatorsForBotName.SelectedValue, 
							BotName.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Xml.Text ) ) {
					writer.Write( "{2} e.Xml {0} '{1}' ",
							operatorsForXml.SelectedValue, 
							Xml.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( BattleId.Text ) ) {
					writer.Write( "{2} e.BattleId {0} '{1}' ",
							operatorsForBattleId.SelectedValue, 
							BattleId.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Code.Text ) ) {
					writer.Write( "{2} e.Code {0} '{1}' ",
							operatorsForCode.SelectedValue, 
							Code.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PendingBotRequest>.GetWhereKey("PendingBotRequest")] = writer.ToString();
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
			BotName.ID = "searchBotName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotName );
			Controls.Add( new LiteralControl("</td><tr>") );
			Xml.ID = "searchXml";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Xml</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForXml ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Xml );
			Controls.Add( new LiteralControl("</td><tr>") );
			BattleId.ID = "searchBattleId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BattleId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBattleId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BattleId );
			Controls.Add( new LiteralControl("</td><tr>") );
			BotId.ID = "searchBotId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotId );
			Controls.Add( new LiteralControl("</td><tr>") );
			Code.ID = "searchCode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Code</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Code );
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
