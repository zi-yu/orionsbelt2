
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
    /// Control that enables ServerProperties search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a ServerPropertiesPagedList
    /// </remarks>
	public class ServerPropertiesSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox currentTick = new TextBox();
		protected DropDownList operatorsForCurrentTick = new DropDownList();
		protected TextBox lastTickDate = new TextBox();
		protected DropDownList operatorsForLastTickDate = new DropDownList();
		protected TextBox running = new TextBox();
		protected DropDownList operatorsForRunning = new DropDownList();
		protected TextBox millisPerTick = new TextBox();
		protected DropDownList operatorsForMillisPerTick = new DropDownList();
		protected TextBox useWebClock = new TextBox();
		protected DropDownList operatorsForUseWebClock = new DropDownList();
		protected TextBox maxPlayers = new TextBox();
		protected DropDownList operatorsForMaxPlayers = new DropDownList();
		protected TextBox vacationTicksPerWeek = new TextBox();
		protected DropDownList operatorsForVacationTicksPerWeek = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox baseUrl = new TextBox();
		protected DropDownList operatorsForBaseUrl = new DropDownList();
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
        /// Search box for ServerProperties's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's CurrentTick property
        /// </summary>
		public TextBox CurrentTick {
			get { return currentTick; }
			set { currentTick = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's CurrentTick operators
        /// </summary>
		public DropDownList OperatorsForCurrentTick {
			get { return operatorsForCurrentTick; }
			set { operatorsForCurrentTick = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's LastTickDate property
        /// </summary>
		public TextBox LastTickDate {
			get { return lastTickDate; }
			set { lastTickDate = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's LastTickDate operators
        /// </summary>
		public DropDownList OperatorsForLastTickDate {
			get { return operatorsForLastTickDate; }
			set { operatorsForLastTickDate = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's Running property
        /// </summary>
		public TextBox Running {
			get { return running; }
			set { running = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's Running operators
        /// </summary>
		public DropDownList OperatorsForRunning {
			get { return operatorsForRunning; }
			set { operatorsForRunning = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's MillisPerTick property
        /// </summary>
		public TextBox MillisPerTick {
			get { return millisPerTick; }
			set { millisPerTick = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's MillisPerTick operators
        /// </summary>
		public DropDownList OperatorsForMillisPerTick {
			get { return operatorsForMillisPerTick; }
			set { operatorsForMillisPerTick = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's UseWebClock property
        /// </summary>
		public TextBox UseWebClock {
			get { return useWebClock; }
			set { useWebClock = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's UseWebClock operators
        /// </summary>
		public DropDownList OperatorsForUseWebClock {
			get { return operatorsForUseWebClock; }
			set { operatorsForUseWebClock = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's MaxPlayers property
        /// </summary>
		public TextBox MaxPlayers {
			get { return maxPlayers; }
			set { maxPlayers = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's MaxPlayers operators
        /// </summary>
		public DropDownList OperatorsForMaxPlayers {
			get { return operatorsForMaxPlayers; }
			set { operatorsForMaxPlayers = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's VacationTicksPerWeek property
        /// </summary>
		public TextBox VacationTicksPerWeek {
			get { return vacationTicksPerWeek; }
			set { vacationTicksPerWeek = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's VacationTicksPerWeek operators
        /// </summary>
		public DropDownList OperatorsForVacationTicksPerWeek {
			get { return operatorsForVacationTicksPerWeek; }
			set { operatorsForVacationTicksPerWeek = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's BaseUrl property
        /// </summary>
		public TextBox BaseUrl {
			get { return baseUrl; }
			set { baseUrl = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's BaseUrl operators
        /// </summary>
		public DropDownList OperatorsForBaseUrl {
			get { return operatorsForBaseUrl; }
			set { operatorsForBaseUrl = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for ServerProperties's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for ServerProperties's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( CurrentTick.Text ) ) {
					writer.Write( "{2} e.CurrentTick {0} '{1}' ",
							operatorsForCurrentTick.SelectedValue, 
							CurrentTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastTickDate.Text ) ) {
					writer.Write( "{2} e.LastTickDate {0} '{1}' ",
							operatorsForLastTickDate.SelectedValue, 
							LastTickDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Running.Text ) ) {
					writer.Write( "{2} e.Running {0} '{1}' ",
							operatorsForRunning.SelectedValue, 
							Running.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MillisPerTick.Text ) ) {
					writer.Write( "{2} e.MillisPerTick {0} '{1}' ",
							operatorsForMillisPerTick.SelectedValue, 
							MillisPerTick.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( UseWebClock.Text ) ) {
					writer.Write( "{2} e.UseWebClock {0} '{1}' ",
							operatorsForUseWebClock.SelectedValue, 
							UseWebClock.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MaxPlayers.Text ) ) {
					writer.Write( "{2} e.MaxPlayers {0} '{1}' ",
							operatorsForMaxPlayers.SelectedValue, 
							MaxPlayers.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( VacationTicksPerWeek.Text ) ) {
					writer.Write( "{2} e.VacationTicksPerWeek {0} '{1}' ",
							operatorsForVacationTicksPerWeek.SelectedValue, 
							VacationTicksPerWeek.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( BaseUrl.Text ) ) {
					writer.Write( "{2} e.BaseUrl {0} '{1}' ",
							operatorsForBaseUrl.SelectedValue, 
							BaseUrl.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<ServerProperties>.GetWhereKey("ServerProperties")] = writer.ToString();
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
			CurrentTick.ID = "searchCurrentTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>CurrentTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForCurrentTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( CurrentTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastTickDate.ID = "searchLastTickDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastTickDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastTickDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastTickDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			Running.ID = "searchRunning";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Running</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRunning ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Running );
			Controls.Add( new LiteralControl("</td><tr>") );
			MillisPerTick.ID = "searchMillisPerTick";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MillisPerTick</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMillisPerTick ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MillisPerTick );
			Controls.Add( new LiteralControl("</td><tr>") );
			UseWebClock.ID = "searchUseWebClock";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>UseWebClock</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForUseWebClock ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( UseWebClock );
			Controls.Add( new LiteralControl("</td><tr>") );
			MaxPlayers.ID = "searchMaxPlayers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MaxPlayers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMaxPlayers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MaxPlayers );
			Controls.Add( new LiteralControl("</td><tr>") );
			VacationTicksPerWeek.ID = "searchVacationTicksPerWeek";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>VacationTicksPerWeek</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForVacationTicksPerWeek ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( VacationTicksPerWeek );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			BaseUrl.ID = "searchBaseUrl";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>BaseUrl</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForBaseUrl ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( BaseUrl );
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
