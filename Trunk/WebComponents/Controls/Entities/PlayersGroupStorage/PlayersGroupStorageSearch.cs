
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
    /// Control that enables PlayersGroupStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PlayersGroupStoragePagedList
    /// </remarks>
	public class PlayersGroupStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox eliminatoryNumber = new TextBox();
		protected DropDownList operatorsForEliminatoryNumber = new DropDownList();
		protected TextBox playersIds = new TextBox();
		protected DropDownList operatorsForPlayersIds = new DropDownList();
		protected TextBox groupNumber = new TextBox();
		protected DropDownList operatorsForGroupNumber = new DropDownList();
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
        /// Search box for PlayersGroupStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's EliminatoryNumber property
        /// </summary>
		public TextBox EliminatoryNumber {
			get { return eliminatoryNumber; }
			set { eliminatoryNumber = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's EliminatoryNumber operators
        /// </summary>
		public DropDownList OperatorsForEliminatoryNumber {
			get { return operatorsForEliminatoryNumber; }
			set { operatorsForEliminatoryNumber = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's PlayersIds property
        /// </summary>
		public TextBox PlayersIds {
			get { return playersIds; }
			set { playersIds = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's PlayersIds operators
        /// </summary>
		public DropDownList OperatorsForPlayersIds {
			get { return operatorsForPlayersIds; }
			set { operatorsForPlayersIds = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's GroupNumber property
        /// </summary>
		public TextBox GroupNumber {
			get { return groupNumber; }
			set { groupNumber = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's GroupNumber operators
        /// </summary>
		public DropDownList OperatorsForGroupNumber {
			get { return operatorsForGroupNumber; }
			set { operatorsForGroupNumber = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for PlayersGroupStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for PlayersGroupStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( EliminatoryNumber.Text ) ) {
					writer.Write( "{2} e.EliminatoryNumber {0} '{1}' ",
							operatorsForEliminatoryNumber.SelectedValue, 
							EliminatoryNumber.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( PlayersIds.Text ) ) {
					writer.Write( "{2} e.PlayersIds {0} '{1}' ",
							operatorsForPlayersIds.SelectedValue, 
							PlayersIds.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( GroupNumber.Text ) ) {
					writer.Write( "{2} e.GroupNumber {0} '{1}' ",
							operatorsForGroupNumber.SelectedValue, 
							GroupNumber.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<PlayersGroupStorage>.GetWhereKey("PlayersGroupStorage")] = writer.ToString();
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
			EliminatoryNumber.ID = "searchEliminatoryNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>EliminatoryNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEliminatoryNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( EliminatoryNumber );
			Controls.Add( new LiteralControl("</td><tr>") );
			PlayersIds.ID = "searchPlayersIds";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>PlayersIds</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPlayersIds ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( PlayersIds );
			Controls.Add( new LiteralControl("</td><tr>") );
			GroupNumber.ID = "searchGroupNumber";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>GroupNumber</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForGroupNumber ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( GroupNumber );
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
