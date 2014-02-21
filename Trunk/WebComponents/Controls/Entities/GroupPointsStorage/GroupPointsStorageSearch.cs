
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
    /// Control that enables GroupPointsStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a GroupPointsStoragePagedList
    /// </remarks>
	public class GroupPointsStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox stage = new TextBox();
		protected DropDownList operatorsForStage = new DropDownList();
		protected TextBox pontuation = new TextBox();
		protected DropDownList operatorsForPontuation = new DropDownList();
		protected TextBox wins = new TextBox();
		protected DropDownList operatorsForWins = new DropDownList();
		protected TextBox losses = new TextBox();
		protected DropDownList operatorsForLosses = new DropDownList();
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
        /// Search box for GroupPointsStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's Stage property
        /// </summary>
		public TextBox Stage {
			get { return stage; }
			set { stage = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's Stage operators
        /// </summary>
		public DropDownList OperatorsForStage {
			get { return operatorsForStage; }
			set { operatorsForStage = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's Pontuation property
        /// </summary>
		public TextBox Pontuation {
			get { return pontuation; }
			set { pontuation = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's Pontuation operators
        /// </summary>
		public DropDownList OperatorsForPontuation {
			get { return operatorsForPontuation; }
			set { operatorsForPontuation = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's Wins property
        /// </summary>
		public TextBox Wins {
			get { return wins; }
			set { wins = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's Wins operators
        /// </summary>
		public DropDownList OperatorsForWins {
			get { return operatorsForWins; }
			set { operatorsForWins = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's Losses property
        /// </summary>
		public TextBox Losses {
			get { return losses; }
			set { losses = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's Losses operators
        /// </summary>
		public DropDownList OperatorsForLosses {
			get { return operatorsForLosses; }
			set { operatorsForLosses = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for GroupPointsStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for GroupPointsStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Stage.Text ) ) {
					writer.Write( "{2} e.Stage {0} '{1}' ",
							operatorsForStage.SelectedValue, 
							Stage.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Pontuation.Text ) ) {
					writer.Write( "{2} e.Pontuation {0} '{1}' ",
							operatorsForPontuation.SelectedValue, 
							Pontuation.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Wins.Text ) ) {
					writer.Write( "{2} e.Wins {0} '{1}' ",
							operatorsForWins.SelectedValue, 
							Wins.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Losses.Text ) ) {
					writer.Write( "{2} e.Losses {0} '{1}' ",
							operatorsForLosses.SelectedValue, 
							Losses.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<GroupPointsStorage>.GetWhereKey("GroupPointsStorage")] = writer.ToString();
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
			Stage.ID = "searchStage";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Stage</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStage ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Stage );
			Controls.Add( new LiteralControl("</td><tr>") );
			Pontuation.ID = "searchPontuation";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Pontuation</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPontuation ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Pontuation );
			Controls.Add( new LiteralControl("</td><tr>") );
			Wins.ID = "searchWins";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Wins</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForWins ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Wins );
			Controls.Add( new LiteralControl("</td><tr>") );
			Losses.ID = "searchLosses";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Losses</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLosses ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Losses );
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
