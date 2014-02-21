
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
    /// Control that enables AllianceStorage search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a AllianceStoragePagedList
    /// </remarks>
	public class AllianceStorageSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox score = new TextBox();
		protected DropDownList operatorsForScore = new DropDownList();
		protected TextBox karma = new TextBox();
		protected DropDownList operatorsForKarma = new DropDownList();
		protected TextBox totalMembers = new TextBox();
		protected DropDownList operatorsForTotalMembers = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox tag = new TextBox();
		protected DropDownList operatorsForTag = new DropDownList();
		protected TextBox description = new TextBox();
		protected DropDownList operatorsForDescription = new DropDownList();
		protected TextBox language = new TextBox();
		protected DropDownList operatorsForLanguage = new DropDownList();
		protected TextBox orions = new TextBox();
		protected DropDownList operatorsForOrions = new DropDownList();
		protected TextBox openToNewMembers = new TextBox();
		protected DropDownList operatorsForOpenToNewMembers = new DropDownList();
		protected TextBox totalRelics = new TextBox();
		protected DropDownList operatorsForTotalRelics = new DropDownList();
		protected TextBox totalRelicsIncome = new TextBox();
		protected DropDownList operatorsForTotalRelicsIncome = new DropDownList();
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
        /// Search box for AllianceStorage's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Score property
        /// </summary>
		public TextBox Score {
			get { return score; }
			set { score = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Score operators
        /// </summary>
		public DropDownList OperatorsForScore {
			get { return operatorsForScore; }
			set { operatorsForScore = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Karma property
        /// </summary>
		public TextBox Karma {
			get { return karma; }
			set { karma = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Karma operators
        /// </summary>
		public DropDownList OperatorsForKarma {
			get { return operatorsForKarma; }
			set { operatorsForKarma = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's TotalMembers property
        /// </summary>
		public TextBox TotalMembers {
			get { return totalMembers; }
			set { totalMembers = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's TotalMembers operators
        /// </summary>
		public DropDownList OperatorsForTotalMembers {
			get { return operatorsForTotalMembers; }
			set { operatorsForTotalMembers = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Tag property
        /// </summary>
		public TextBox Tag {
			get { return tag; }
			set { tag = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Tag operators
        /// </summary>
		public DropDownList OperatorsForTag {
			get { return operatorsForTag; }
			set { operatorsForTag = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Description property
        /// </summary>
		public TextBox Description {
			get { return description; }
			set { description = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Description operators
        /// </summary>
		public DropDownList OperatorsForDescription {
			get { return operatorsForDescription; }
			set { operatorsForDescription = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Language property
        /// </summary>
		public TextBox Language {
			get { return language; }
			set { language = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Language operators
        /// </summary>
		public DropDownList OperatorsForLanguage {
			get { return operatorsForLanguage; }
			set { operatorsForLanguage = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's Orions property
        /// </summary>
		public TextBox Orions {
			get { return orions; }
			set { orions = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's Orions operators
        /// </summary>
		public DropDownList OperatorsForOrions {
			get { return operatorsForOrions; }
			set { operatorsForOrions = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's OpenToNewMembers property
        /// </summary>
		public TextBox OpenToNewMembers {
			get { return openToNewMembers; }
			set { openToNewMembers = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's OpenToNewMembers operators
        /// </summary>
		public DropDownList OperatorsForOpenToNewMembers {
			get { return operatorsForOpenToNewMembers; }
			set { operatorsForOpenToNewMembers = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's TotalRelics property
        /// </summary>
		public TextBox TotalRelics {
			get { return totalRelics; }
			set { totalRelics = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's TotalRelics operators
        /// </summary>
		public DropDownList OperatorsForTotalRelics {
			get { return operatorsForTotalRelics; }
			set { operatorsForTotalRelics = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's TotalRelicsIncome property
        /// </summary>
		public TextBox TotalRelicsIncome {
			get { return totalRelicsIncome; }
			set { totalRelicsIncome = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's TotalRelicsIncome operators
        /// </summary>
		public DropDownList OperatorsForTotalRelicsIncome {
			get { return operatorsForTotalRelicsIncome; }
			set { operatorsForTotalRelicsIncome = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for AllianceStorage's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for AllianceStorage's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Score.Text ) ) {
					writer.Write( "{2} e.Score {0} '{1}' ",
							operatorsForScore.SelectedValue, 
							Score.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Karma.Text ) ) {
					writer.Write( "{2} e.Karma {0} '{1}' ",
							operatorsForKarma.SelectedValue, 
							Karma.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalMembers.Text ) ) {
					writer.Write( "{2} e.TotalMembers {0} '{1}' ",
							operatorsForTotalMembers.SelectedValue, 
							TotalMembers.Text, first ? "" : ","
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
				if( !string.IsNullOrEmpty( Tag.Text ) ) {
					writer.Write( "{2} e.Tag {0} '{1}' ",
							operatorsForTag.SelectedValue, 
							Tag.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Description.Text ) ) {
					writer.Write( "{2} e.Description {0} '{1}' ",
							operatorsForDescription.SelectedValue, 
							Description.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Language.Text ) ) {
					writer.Write( "{2} e.Language {0} '{1}' ",
							operatorsForLanguage.SelectedValue, 
							Language.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Orions.Text ) ) {
					writer.Write( "{2} e.Orions {0} '{1}' ",
							operatorsForOrions.SelectedValue, 
							Orions.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( OpenToNewMembers.Text ) ) {
					writer.Write( "{2} e.OpenToNewMembers {0} '{1}' ",
							operatorsForOpenToNewMembers.SelectedValue, 
							OpenToNewMembers.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalRelics.Text ) ) {
					writer.Write( "{2} e.TotalRelics {0} '{1}' ",
							operatorsForTotalRelics.SelectedValue, 
							TotalRelics.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( TotalRelicsIncome.Text ) ) {
					writer.Write( "{2} e.TotalRelicsIncome {0} '{1}' ",
							operatorsForTotalRelicsIncome.SelectedValue, 
							TotalRelicsIncome.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<AllianceStorage>.GetWhereKey("AllianceStorage")] = writer.ToString();
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
			Score.ID = "searchScore";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Score</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForScore ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Score );
			Controls.Add( new LiteralControl("</td><tr>") );
			Karma.ID = "searchKarma";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Karma</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForKarma ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Karma );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalMembers.ID = "searchTotalMembers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalMembers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalMembers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalMembers );
			Controls.Add( new LiteralControl("</td><tr>") );
			Name.ID = "searchName";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Name</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForName ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Name );
			Controls.Add( new LiteralControl("</td><tr>") );
			Tag.ID = "searchTag";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Tag</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTag ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Tag );
			Controls.Add( new LiteralControl("</td><tr>") );
			Description.ID = "searchDescription";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Description</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForDescription ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Description );
			Controls.Add( new LiteralControl("</td><tr>") );
			Language.ID = "searchLanguage";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Language</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLanguage ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Language );
			Controls.Add( new LiteralControl("</td><tr>") );
			Orions.ID = "searchOrions";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Orions</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOrions ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Orions );
			Controls.Add( new LiteralControl("</td><tr>") );
			OpenToNewMembers.ID = "searchOpenToNewMembers";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>OpenToNewMembers</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForOpenToNewMembers ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( OpenToNewMembers );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalRelics.ID = "searchTotalRelics";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalRelics</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalRelics ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalRelics );
			Controls.Add( new LiteralControl("</td><tr>") );
			TotalRelicsIncome.ID = "searchTotalRelicsIncome";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>TotalRelicsIncome</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForTotalRelicsIncome ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( TotalRelicsIncome );
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
