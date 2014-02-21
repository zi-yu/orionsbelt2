
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
    /// Control that enables PrincipalStats search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PrincipalStatsPagedList
    /// </remarks>
	public class PrincipalStatsSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox maxElo = new TextBox();
		protected DropDownList operatorsForMaxElo = new DropDownList();
		protected TextBox minElo = new TextBox();
		protected DropDownList operatorsForMinElo = new DropDownList();
		protected TextBox numberPlayedBattles = new TextBox();
		protected DropDownList operatorsForNumberPlayedBattles = new DropDownList();
		protected TextBox maxLadder = new TextBox();
		protected DropDownList operatorsForMaxLadder = new DropDownList();
		protected TextBox minLadder = new TextBox();
		protected DropDownList operatorsForMinLadder = new DropDownList();
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
        /// Search box for PrincipalStats's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's MaxElo property
        /// </summary>
		public TextBox MaxElo {
			get { return maxElo; }
			set { maxElo = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's MaxElo operators
        /// </summary>
		public DropDownList OperatorsForMaxElo {
			get { return operatorsForMaxElo; }
			set { operatorsForMaxElo = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's MinElo property
        /// </summary>
		public TextBox MinElo {
			get { return minElo; }
			set { minElo = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's MinElo operators
        /// </summary>
		public DropDownList OperatorsForMinElo {
			get { return operatorsForMinElo; }
			set { operatorsForMinElo = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's NumberPlayedBattles property
        /// </summary>
		public TextBox NumberPlayedBattles {
			get { return numberPlayedBattles; }
			set { numberPlayedBattles = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's NumberPlayedBattles operators
        /// </summary>
		public DropDownList OperatorsForNumberPlayedBattles {
			get { return operatorsForNumberPlayedBattles; }
			set { operatorsForNumberPlayedBattles = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's MaxLadder property
        /// </summary>
		public TextBox MaxLadder {
			get { return maxLadder; }
			set { maxLadder = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's MaxLadder operators
        /// </summary>
		public DropDownList OperatorsForMaxLadder {
			get { return operatorsForMaxLadder; }
			set { operatorsForMaxLadder = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's MinLadder property
        /// </summary>
		public TextBox MinLadder {
			get { return minLadder; }
			set { minLadder = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's MinLadder operators
        /// </summary>
		public DropDownList OperatorsForMinLadder {
			get { return operatorsForMinLadder; }
			set { operatorsForMinLadder = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PrincipalStats's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PrincipalStats's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( MaxElo.Text ) ) {
					writer.Write( "{2} e.MaxElo {0} '{1}' ",
							operatorsForMaxElo.SelectedValue, 
							MaxElo.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MinElo.Text ) ) {
					writer.Write( "{2} e.MinElo {0} '{1}' ",
							operatorsForMinElo.SelectedValue, 
							MinElo.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( MaxLadder.Text ) ) {
					writer.Write( "{2} e.MaxLadder {0} '{1}' ",
							operatorsForMaxLadder.SelectedValue, 
							MaxLadder.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( MinLadder.Text ) ) {
					writer.Write( "{2} e.MinLadder {0} '{1}' ",
							operatorsForMinLadder.SelectedValue, 
							MinLadder.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PrincipalStats>.GetWhereKey("PrincipalStats")] = writer.ToString();
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
			MaxElo.ID = "searchMaxElo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MaxElo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMaxElo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MaxElo );
			Controls.Add( new LiteralControl("</td><tr>") );
			MinElo.ID = "searchMinElo";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MinElo</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMinElo ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MinElo );
			Controls.Add( new LiteralControl("</td><tr>") );
			NumberPlayedBattles.ID = "searchNumberPlayedBattles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>NumberPlayedBattles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForNumberPlayedBattles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( NumberPlayedBattles );
			Controls.Add( new LiteralControl("</td><tr>") );
			MaxLadder.ID = "searchMaxLadder";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MaxLadder</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMaxLadder ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MaxLadder );
			Controls.Add( new LiteralControl("</td><tr>") );
			MinLadder.ID = "searchMinLadder";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>MinLadder</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForMinLadder ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( MinLadder );
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
