
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
    /// Control that enables QuestStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a QuestStoragePagedList
    /// </remarks>
	public class QuestStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox percentage = new TextBox();
		protected DropDownList operatorsForPercentage = new DropDownList();
		protected TextBox isTemplate = new TextBox();
		protected DropDownList operatorsForIsTemplate = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox type = new TextBox();
		protected DropDownList operatorsForType = new DropDownList();
		protected TextBox deadlineTick = new TextBox();
		protected DropDownList operatorsForDeadlineTick = new DropDownList();
		protected TextBox startTick = new TextBox();
		protected DropDownList operatorsForStartTick = new DropDownList();
		protected TextBox reward = new TextBox();
		protected DropDownList operatorsForReward = new DropDownList();
		protected TextBox questStringConfig = new TextBox();
		protected DropDownList operatorsForQuestStringConfig = new DropDownList();
		protected TextBox questIntConfig = new TextBox();
		protected DropDownList operatorsForQuestIntConfig = new DropDownList();
		protected TextBox questIntProgress = new TextBox();
		protected DropDownList operatorsForQuestIntProgress = new DropDownList();
		protected TextBox questStringProgress = new TextBox();
		protected DropDownList operatorsForQuestStringProgress = new DropDownList();
		protected TextBox completed = new TextBox();
		protected DropDownList operatorsForCompleted = new DropDownList();
		protected TextBox isProgressive = new TextBox();
		protected DropDownList operatorsForIsProgressive = new DropDownList();
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
        /// Search box for QuestStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's Percentage property
        /// </summary>
		public TextBox Percentage {
			get { return percentage; }
			set { percentage = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Percentage operators
        /// </summary>
		public DropDownList OperatorsForPercentage {
			get { return operatorsForPercentage; }
			set { operatorsForPercentage = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's IsTemplate property
        /// </summary>
		public TextBox IsTemplate {
			get { return isTemplate; }
			set { isTemplate = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's IsTemplate operators
        /// </summary>
		public DropDownList OperatorsForIsTemplate {
			get { return operatorsForIsTemplate; }
			set { operatorsForIsTemplate = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's Type property
        /// </summary>
		public TextBox Type {
			get { return type; }
			set { type = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Type operators
        /// </summary>
		public DropDownList OperatorsForType {
			get { return operatorsForType; }
			set { operatorsForType = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's DeadlineTick property
        /// </summary>
		public TextBox DeadlineTick {
			get { return deadlineTick; }
			set { deadlineTick = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's DeadlineTick operators
        /// </summary>
		public DropDownList OperatorsForDeadlineTick {
			get { return operatorsForDeadlineTick; }
			set { operatorsForDeadlineTick = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's StartTick property
        /// </summary>
		public TextBox StartTick {
			get { return startTick; }
			set { startTick = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's StartTick operators
        /// </summary>
		public DropDownList OperatorsForStartTick {
			get { return operatorsForStartTick; }
			set { operatorsForStartTick = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's Reward property
        /// </summary>
		public TextBox Reward {
			get { return reward; }
			set { reward = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Reward operators
        /// </summary>
		public DropDownList OperatorsForReward {
			get { return operatorsForReward; }
			set { operatorsForReward = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's QuestStringConfig property
        /// </summary>
		public TextBox QuestStringConfig {
			get { return questStringConfig; }
			set { questStringConfig = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's QuestStringConfig operators
        /// </summary>
		public DropDownList OperatorsForQuestStringConfig {
			get { return operatorsForQuestStringConfig; }
			set { operatorsForQuestStringConfig = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's QuestIntConfig property
        /// </summary>
		public TextBox QuestIntConfig {
			get { return questIntConfig; }
			set { questIntConfig = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's QuestIntConfig operators
        /// </summary>
		public DropDownList OperatorsForQuestIntConfig {
			get { return operatorsForQuestIntConfig; }
			set { operatorsForQuestIntConfig = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's QuestIntProgress property
        /// </summary>
		public TextBox QuestIntProgress {
			get { return questIntProgress; }
			set { questIntProgress = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's QuestIntProgress operators
        /// </summary>
		public DropDownList OperatorsForQuestIntProgress {
			get { return operatorsForQuestIntProgress; }
			set { operatorsForQuestIntProgress = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's QuestStringProgress property
        /// </summary>
		public TextBox QuestStringProgress {
			get { return questStringProgress; }
			set { questStringProgress = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's QuestStringProgress operators
        /// </summary>
		public DropDownList OperatorsForQuestStringProgress {
			get { return operatorsForQuestStringProgress; }
			set { operatorsForQuestStringProgress = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's Completed property
        /// </summary>
		public TextBox Completed {
			get { return completed; }
			set { completed = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's Completed operators
        /// </summary>
		public DropDownList OperatorsForCompleted {
			get { return operatorsForCompleted; }
			set { operatorsForCompleted = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's IsProgressive property
        /// </summary>
		public TextBox IsProgressive {
			get { return isProgressive; }
			set { isProgressive = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's IsProgressive operators
        /// </summary>
		public DropDownList OperatorsForIsProgressive {
			get { return operatorsForIsProgressive; }
			set { operatorsForIsProgressive = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for QuestStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for QuestStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Percentage.Text ) ) {
					writer.Write( "{2} e.Percentage {0} '{1}' ",
							operatorsForPercentage.SelectedValue, 
							Percentage.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsTemplate.Text ) ) {
					writer.Write( "{2} e.IsTemplate {0} '{1}' ",
							operatorsForIsTemplate.SelectedValue, 
							IsTemplate.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Type.Text ) ) {
					writer.Write( "{2} e.Type {0} '{1}' ",
							operatorsForType.SelectedValue, 
							Type.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( DeadlineTick.Text ) ) {
					writer.Write( "{2} e.DeadlineTick {0} '{1}' ",
							operatorsForDeadlineTick.SelectedValue, 
							DeadlineTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( StartTick.Text ) ) {
					writer.Write( "{2} e.StartTick {0} '{1}' ",
							operatorsForStartTick.SelectedValue, 
							StartTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Reward.Text ) ) {
					writer.Write( "{2} e.Reward {0} '{1}' ",
							operatorsForReward.SelectedValue, 
							Reward.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QuestStringConfig.Text ) ) {
					writer.Write( "{2} e.QuestStringConfig {0} '{1}' ",
							operatorsForQuestStringConfig.SelectedValue, 
							QuestStringConfig.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QuestIntConfig.Text ) ) {
					writer.Write( "{2} e.QuestIntConfig {0} '{1}' ",
							operatorsForQuestIntConfig.SelectedValue, 
							QuestIntConfig.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QuestIntProgress.Text ) ) {
					writer.Write( "{2} e.QuestIntProgress {0} '{1}' ",
							operatorsForQuestIntProgress.SelectedValue, 
							QuestIntProgress.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( QuestStringProgress.Text ) ) {
					writer.Write( "{2} e.QuestStringProgress {0} '{1}' ",
							operatorsForQuestStringProgress.SelectedValue, 
							QuestStringProgress.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Completed.Text ) ) {
					writer.Write( "{2} e.Completed {0} '{1}' ",
							operatorsForCompleted.SelectedValue, 
							Completed.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsProgressive.Text ) ) {
					writer.Write( "{2} e.IsProgressive {0} '{1}' ",
							operatorsForIsProgressive.SelectedValue, 
							IsProgressive.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<QuestStorage>.GetWhereKey("QuestStorage")] = writer.ToString();
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
			Percentage.ID = "searchPercentage";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Percentage</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPercentage ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Percentage );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsTemplate.ID = "searchIsTemplate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsTemplate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsTemplate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsTemplate );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			Type.ID = "searchType";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Type</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForType ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Type );
			Controls.Add( new LiteralControl("</td><tr>") );
			DeadlineTick.ID = "searchDeadlineTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>DeadlineTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDeadlineTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( DeadlineTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			StartTick.ID = "searchStartTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>StartTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForStartTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( StartTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			Reward.ID = "searchReward";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Reward</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForReward ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Reward );
			Controls.Add( new LiteralControl("</td><tr>") );
			QuestStringConfig.ID = "searchQuestStringConfig";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QuestStringConfig</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuestStringConfig ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QuestStringConfig );
			Controls.Add( new LiteralControl("</td><tr>") );
			QuestIntConfig.ID = "searchQuestIntConfig";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QuestIntConfig</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuestIntConfig ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QuestIntConfig );
			Controls.Add( new LiteralControl("</td><tr>") );
			QuestIntProgress.ID = "searchQuestIntProgress";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QuestIntProgress</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuestIntProgress ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QuestIntProgress );
			Controls.Add( new LiteralControl("</td><tr>") );
			QuestStringProgress.ID = "searchQuestStringProgress";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>QuestStringProgress</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForQuestStringProgress ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( QuestStringProgress );
			Controls.Add( new LiteralControl("</td><tr>") );
			Completed.ID = "searchCompleted";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Completed</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCompleted ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Completed );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsProgressive.ID = "searchIsProgressive";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsProgressive</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsProgressive ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsProgressive );
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
