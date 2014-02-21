
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
    /// Control that enables PrincipalTournament search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PrincipalTournamentPagedList
    /// </remarks>
	public class PrincipalTournamentSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox hasEliminated = new TextBox();
		protected DropDownList operatorsForHasEliminated = new DropDownList();
		protected TextBox eliminatedInFase = new TextBox();
		protected DropDownList operatorsForEliminatedInFase = new DropDownList();
		protected TextBox eliminatedInBattleId = new TextBox();
		protected DropDownList operatorsForEliminatedInBattleId = new DropDownList();
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
        /// Search box for PrincipalTournament's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's HasEliminated property
        /// </summary>
		public TextBox HasEliminated {
			get { return hasEliminated; }
			set { hasEliminated = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's HasEliminated operators
        /// </summary>
		public DropDownList OperatorsForHasEliminated {
			get { return operatorsForHasEliminated; }
			set { operatorsForHasEliminated = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's EliminatedInFase property
        /// </summary>
		public TextBox EliminatedInFase {
			get { return eliminatedInFase; }
			set { eliminatedInFase = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's EliminatedInFase operators
        /// </summary>
		public DropDownList OperatorsForEliminatedInFase {
			get { return operatorsForEliminatedInFase; }
			set { operatorsForEliminatedInFase = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's EliminatedInBattleId property
        /// </summary>
		public TextBox EliminatedInBattleId {
			get { return eliminatedInBattleId; }
			set { eliminatedInBattleId = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's EliminatedInBattleId operators
        /// </summary>
		public DropDownList OperatorsForEliminatedInBattleId {
			get { return operatorsForEliminatedInBattleId; }
			set { operatorsForEliminatedInBattleId = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalTournament's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalTournament's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( HasEliminated.Text ) ) {
					writer.Write( "{2} e.HasEliminated {0} '{1}' ",
							operatorsForHasEliminated.SelectedValue, 
							HasEliminated.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( EliminatedInFase.Text ) ) {
					writer.Write( "{2} e.EliminatedInFase {0} '{1}' ",
							operatorsForEliminatedInFase.SelectedValue, 
							EliminatedInFase.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( EliminatedInBattleId.Text ) ) {
					writer.Write( "{2} e.EliminatedInBattleId {0} '{1}' ",
							operatorsForEliminatedInBattleId.SelectedValue, 
							EliminatedInBattleId.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PrincipalTournament>.GetWhereKey("PrincipalTournament")] = writer.ToString();
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
			HasEliminated.ID = "searchHasEliminated";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>HasEliminated</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForHasEliminated ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( HasEliminated );
			Controls.Add( new LiteralControl("</td><tr>") );
			EliminatedInFase.ID = "searchEliminatedInFase";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EliminatedInFase</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEliminatedInFase ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EliminatedInFase );
			Controls.Add( new LiteralControl("</td><tr>") );
			EliminatedInBattleId.ID = "searchEliminatedInBattleId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EliminatedInBattleId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEliminatedInBattleId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EliminatedInBattleId );
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
