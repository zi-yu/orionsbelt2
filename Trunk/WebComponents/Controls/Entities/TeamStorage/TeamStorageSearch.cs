
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
    /// Control that enables TeamStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a TeamStoragePagedList
    /// </remarks>
	public class TeamStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox eloRanking = new TextBox();
		protected DropDownList operatorsForEloRanking = new DropDownList();
		protected TextBox numberPlayedBattles = new TextBox();
		protected DropDownList operatorsForNumberPlayedBattles = new DropDownList();
		protected TextBox ladderActive = new TextBox();
		protected DropDownList operatorsForLadderActive = new DropDownList();
		protected TextBox ladderPosition = new TextBox();
		protected DropDownList operatorsForLadderPosition = new DropDownList();
		protected TextBox isInBattle = new TextBox();
		protected DropDownList operatorsForIsInBattle = new DropDownList();
		protected TextBox restUntil = new TextBox();
		protected DropDownList operatorsForRestUntil = new DropDownList();
		protected TextBox stoppedUntil = new TextBox();
		protected DropDownList operatorsForStoppedUntil = new DropDownList();
		protected TextBox myStatsId = new TextBox();
		protected DropDownList operatorsForMyStatsId = new DropDownList();
		protected TextBox isComplete = new TextBox();
		protected DropDownList operatorsForIsComplete = new DropDownList();
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
        /// Search box for TeamStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's EloRanking property
        /// </summary>
		public TextBox EloRanking {
			get { return eloRanking; }
			set { eloRanking = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's EloRanking operators
        /// </summary>
		public DropDownList OperatorsForEloRanking {
			get { return operatorsForEloRanking; }
			set { operatorsForEloRanking = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's NumberPlayedBattles property
        /// </summary>
		public TextBox NumberPlayedBattles {
			get { return numberPlayedBattles; }
			set { numberPlayedBattles = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's NumberPlayedBattles operators
        /// </summary>
		public DropDownList OperatorsForNumberPlayedBattles {
			get { return operatorsForNumberPlayedBattles; }
			set { operatorsForNumberPlayedBattles = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's LadderActive property
        /// </summary>
		public TextBox LadderActive {
			get { return ladderActive; }
			set { ladderActive = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's LadderActive operators
        /// </summary>
		public DropDownList OperatorsForLadderActive {
			get { return operatorsForLadderActive; }
			set { operatorsForLadderActive = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's LadderPosition property
        /// </summary>
		public TextBox LadderPosition {
			get { return ladderPosition; }
			set { ladderPosition = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's LadderPosition operators
        /// </summary>
		public DropDownList OperatorsForLadderPosition {
			get { return operatorsForLadderPosition; }
			set { operatorsForLadderPosition = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's IsInBattle property
        /// </summary>
		public TextBox IsInBattle {
			get { return isInBattle; }
			set { isInBattle = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's IsInBattle operators
        /// </summary>
		public DropDownList OperatorsForIsInBattle {
			get { return operatorsForIsInBattle; }
			set { operatorsForIsInBattle = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's RestUntil property
        /// </summary>
		public TextBox RestUntil {
			get { return restUntil; }
			set { restUntil = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's RestUntil operators
        /// </summary>
		public DropDownList OperatorsForRestUntil {
			get { return operatorsForRestUntil; }
			set { operatorsForRestUntil = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's StoppedUntil property
        /// </summary>
		public TextBox StoppedUntil {
			get { return stoppedUntil; }
			set { stoppedUntil = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's StoppedUntil operators
        /// </summary>
		public DropDownList OperatorsForStoppedUntil {
			get { return operatorsForStoppedUntil; }
			set { operatorsForStoppedUntil = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's MyStatsId property
        /// </summary>
		public TextBox MyStatsId {
			get { return myStatsId; }
			set { myStatsId = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's MyStatsId operators
        /// </summary>
		public DropDownList OperatorsForMyStatsId {
			get { return operatorsForMyStatsId; }
			set { operatorsForMyStatsId = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's IsComplete property
        /// </summary>
		public TextBox IsComplete {
			get { return isComplete; }
			set { isComplete = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's IsComplete operators
        /// </summary>
		public DropDownList OperatorsForIsComplete {
			get { return operatorsForIsComplete; }
			set { operatorsForIsComplete = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for TeamStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for TeamStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( EloRanking.Text ) ) {
					writer.Write( "{2} e.EloRanking {0} '{1}' ",
							operatorsForEloRanking.SelectedValue, 
							EloRanking.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( NumberPlayedBattles.Text ) ) {
					writer.Write( "{2} e.NumberPlayedBattles {0} '{1}' ",
							operatorsForNumberPlayedBattles.SelectedValue, 
							NumberPlayedBattles.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LadderActive.Text ) ) {
					writer.Write( "{2} e.LadderActive {0} '{1}' ",
							operatorsForLadderActive.SelectedValue, 
							LadderActive.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LadderPosition.Text ) ) {
					writer.Write( "{2} e.LadderPosition {0} '{1}' ",
							operatorsForLadderPosition.SelectedValue, 
							LadderPosition.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( RestUntil.Text ) ) {
					writer.Write( "{2} e.RestUntil {0} '{1}' ",
							operatorsForRestUntil.SelectedValue, 
							RestUntil.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StoppedUntil.Text ) ) {
					writer.Write( "{2} e.StoppedUntil {0} '{1}' ",
							operatorsForStoppedUntil.SelectedValue, 
							StoppedUntil.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MyStatsId.Text ) ) {
					writer.Write( "{2} e.MyStatsId {0} '{1}' ",
							operatorsForMyStatsId.SelectedValue, 
							MyStatsId.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsComplete.Text ) ) {
					writer.Write( "{2} e.IsComplete {0} '{1}' ",
							operatorsForIsComplete.SelectedValue, 
							IsComplete.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<TeamStorage>.GetWhereKey("TeamStorage")] = writer.ToString();
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
			EloRanking.ID = "searchEloRanking";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EloRanking</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEloRanking ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EloRanking );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberPlayedBattles.ID = "searchNumberPlayedBattles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberPlayedBattles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberPlayedBattles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberPlayedBattles );
			Controls.Add( new LiteralControl("</td><tr>") );
			LadderActive.ID = "searchLadderActive";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LadderActive</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLadderActive ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LadderActive );
			Controls.Add( new LiteralControl("</td><tr>") );
			LadderPosition.ID = "searchLadderPosition";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LadderPosition</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLadderPosition ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LadderPosition );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsInBattle.ID = "searchIsInBattle";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsInBattle</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsInBattle ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsInBattle );
			Controls.Add( new LiteralControl("</td><tr>") );
			RestUntil.ID = "searchRestUntil";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RestUntil</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRestUntil ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RestUntil );
			Controls.Add( new LiteralControl("</td><tr>") );
			StoppedUntil.ID = "searchStoppedUntil";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StoppedUntil</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStoppedUntil ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StoppedUntil );
			Controls.Add( new LiteralControl("</td><tr>") );
			MyStatsId.ID = "searchMyStatsId";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MyStatsId</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMyStatsId ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MyStatsId );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsComplete.ID = "searchIsComplete";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsComplete</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsComplete ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsComplete );
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
