
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
    /// Control that enables CampaignLevel search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a CampaignLevelPagedList
    /// </remarks>
	public class CampaignLevelSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox botFleet = new TextBox();
		protected DropDownList operatorsForBotFleet = new DropDownList();
		protected TextBox playerFleet = new TextBox();
		protected DropDownList operatorsForPlayerFleet = new DropDownList();
		protected TextBox level = new TextBox();
		protected DropDownList operatorsForLevel = new DropDownList();
		protected TextBox botName = new TextBox();
		protected DropDownList operatorsForBotName = new DropDownList();
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
        /// Search box for CampaignLevel's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's BotFleet property
        /// </summary>
		public TextBox BotFleet {
			get { return botFleet; }
			set { botFleet = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's BotFleet operators
        /// </summary>
		public DropDownList OperatorsForBotFleet {
			get { return operatorsForBotFleet; }
			set { operatorsForBotFleet = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's PlayerFleet property
        /// </summary>
		public TextBox PlayerFleet {
			get { return playerFleet; }
			set { playerFleet = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's PlayerFleet operators
        /// </summary>
		public DropDownList OperatorsForPlayerFleet {
			get { return operatorsForPlayerFleet; }
			set { operatorsForPlayerFleet = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's Level property
        /// </summary>
		public TextBox Level {
			get { return level; }
			set { level = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's Level operators
        /// </summary>
		public DropDownList OperatorsForLevel {
			get { return operatorsForLevel; }
			set { operatorsForLevel = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's BotName property
        /// </summary>
		public TextBox BotName {
			get { return botName; }
			set { botName = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's BotName operators
        /// </summary>
		public DropDownList OperatorsForBotName {
			get { return operatorsForBotName; }
			set { operatorsForBotName = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for CampaignLevel's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for CampaignLevel's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( BotFleet.Text ) ) {
					writer.Write( "{2} e.BotFleet {0} '{1}' ",
							operatorsForBotFleet.SelectedValue, 
							BotFleet.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PlayerFleet.Text ) ) {
					writer.Write( "{2} e.PlayerFleet {0} '{1}' ",
							operatorsForPlayerFleet.SelectedValue, 
							PlayerFleet.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( BotName.Text ) ) {
					writer.Write( "{2} e.BotName {0} '{1}' ",
							operatorsForBotName.SelectedValue, 
							BotName.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<CampaignLevel>.GetWhereKey("CampaignLevel")] = writer.ToString();
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
			BotFleet.ID = "searchBotFleet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotFleet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotFleet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotFleet );
			Controls.Add( new LiteralControl("</td><tr>") );
			PlayerFleet.ID = "searchPlayerFleet";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PlayerFleet</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPlayerFleet ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PlayerFleet );
			Controls.Add( new LiteralControl("</td><tr>") );
			Level.ID = "searchLevel";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Level</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLevel ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Level );
			Controls.Add( new LiteralControl("</td><tr>") );
			BotName.ID = "searchBotName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BotName</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBotName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BotName );
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
