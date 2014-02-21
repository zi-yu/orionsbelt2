
using System;
using System.IO;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Control that enables Principal search
    /// </summary>
	/// <remarks>
    /// This control specifies gives input to a PrincipalPagedList
    /// </remarks>
	public class PrincipalSearch : Control {
	
		#region Control Fields
		
		protected TextBox id = new TextBox();
		protected DropDownList operatorsForId = new DropDownList();
		protected TextBox name = new TextBox();
		protected DropDownList operatorsForName = new DropDownList();
		protected TextBox password = new TextBox();
		protected DropDownList operatorsForPassword = new DropDownList();
		protected TextBox email = new TextBox();
		protected DropDownList operatorsForEmail = new DropDownList();
		protected TextBox ip = new TextBox();
		protected DropDownList operatorsForIp = new DropDownList();
		protected TextBox registDate = new TextBox();
		protected DropDownList operatorsForRegistDate = new DropDownList();
		protected TextBox lastLogin = new TextBox();
		protected DropDownList operatorsForLastLogin = new DropDownList();
		protected TextBox approved = new TextBox();
		protected DropDownList operatorsForApproved = new DropDownList();
		protected TextBox isOnline = new TextBox();
		protected DropDownList operatorsForIsOnline = new DropDownList();
		protected TextBox locked = new TextBox();
		protected DropDownList operatorsForLocked = new DropDownList();
		protected TextBox locale = new TextBox();
		protected DropDownList operatorsForLocale = new DropDownList();
		protected TextBox confirmationCode = new TextBox();
		protected DropDownList operatorsForConfirmationCode = new DropDownList();
		protected TextBox rawRoles = new TextBox();
		protected DropDownList operatorsForRawRoles = new DropDownList();
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
        /// Search box for Principal's Id property
        /// </summary>
		public TextBox Id {
			get { return id; }
			set { id = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Id operators
        /// </summary>
		public DropDownList OperatorsForId {
			get { return operatorsForId; }
			set { operatorsForId = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Name property
        /// </summary>
		public TextBox Name {
			get { return name; }
			set { name = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Name operators
        /// </summary>
		public DropDownList OperatorsForName {
			get { return operatorsForName; }
			set { operatorsForName = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Password property
        /// </summary>
		public TextBox Password {
			get { return password; }
			set { password = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Password operators
        /// </summary>
		public DropDownList OperatorsForPassword {
			get { return operatorsForPassword; }
			set { operatorsForPassword = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Email property
        /// </summary>
		public TextBox Email {
			get { return email; }
			set { email = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Email operators
        /// </summary>
		public DropDownList OperatorsForEmail {
			get { return operatorsForEmail; }
			set { operatorsForEmail = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Ip property
        /// </summary>
		public TextBox Ip {
			get { return ip; }
			set { ip = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Ip operators
        /// </summary>
		public DropDownList OperatorsForIp {
			get { return operatorsForIp; }
			set { operatorsForIp = value; }
		}
		
		/// <summary>
        /// Search box for Principal's RegistDate property
        /// </summary>
		public TextBox RegistDate {
			get { return registDate; }
			set { registDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's RegistDate operators
        /// </summary>
		public DropDownList OperatorsForRegistDate {
			get { return operatorsForRegistDate; }
			set { operatorsForRegistDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LastLogin property
        /// </summary>
		public TextBox LastLogin {
			get { return lastLogin; }
			set { lastLogin = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LastLogin operators
        /// </summary>
		public DropDownList OperatorsForLastLogin {
			get { return operatorsForLastLogin; }
			set { operatorsForLastLogin = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Approved property
        /// </summary>
		public TextBox Approved {
			get { return approved; }
			set { approved = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Approved operators
        /// </summary>
		public DropDownList OperatorsForApproved {
			get { return operatorsForApproved; }
			set { operatorsForApproved = value; }
		}
		
		/// <summary>
        /// Search box for Principal's IsOnline property
        /// </summary>
		public TextBox IsOnline {
			get { return isOnline; }
			set { isOnline = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's IsOnline operators
        /// </summary>
		public DropDownList OperatorsForIsOnline {
			get { return operatorsForIsOnline; }
			set { operatorsForIsOnline = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Locked property
        /// </summary>
		public TextBox Locked {
			get { return locked; }
			set { locked = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Locked operators
        /// </summary>
		public DropDownList OperatorsForLocked {
			get { return operatorsForLocked; }
			set { operatorsForLocked = value; }
		}
		
		/// <summary>
        /// Search box for Principal's Locale property
        /// </summary>
		public TextBox Locale {
			get { return locale; }
			set { locale = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's Locale operators
        /// </summary>
		public DropDownList OperatorsForLocale {
			get { return operatorsForLocale; }
			set { operatorsForLocale = value; }
		}
		
		/// <summary>
        /// Search box for Principal's ConfirmationCode property
        /// </summary>
		public TextBox ConfirmationCode {
			get { return confirmationCode; }
			set { confirmationCode = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's ConfirmationCode operators
        /// </summary>
		public DropDownList OperatorsForConfirmationCode {
			get { return operatorsForConfirmationCode; }
			set { operatorsForConfirmationCode = value; }
		}
		
		/// <summary>
        /// Search box for Principal's RawRoles property
        /// </summary>
		public TextBox RawRoles {
			get { return rawRoles; }
			set { rawRoles = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's RawRoles operators
        /// </summary>
		public DropDownList OperatorsForRawRoles {
			get { return operatorsForRawRoles; }
			set { operatorsForRawRoles = value; }
		}
		
		/// <summary>
        /// Search box for Principal's CreatedDate property
        /// </summary>
		public TextBox CreatedDate {
			get { return createdDate; }
			set { createdDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's CreatedDate operators
        /// </summary>
		public DropDownList OperatorsForCreatedDate {
			get { return operatorsForCreatedDate; }
			set { operatorsForCreatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's UpdatedDate property
        /// </summary>
		public TextBox UpdatedDate {
			get { return updatedDate; }
			set { updatedDate = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's UpdatedDate operators
        /// </summary>
		public DropDownList OperatorsForUpdatedDate {
			get { return operatorsForUpdatedDate; }
			set { operatorsForUpdatedDate = value; }
		}
		
		/// <summary>
        /// Search box for Principal's LastActionUserId property
        /// </summary>
		public TextBox LastActionUserId {
			get { return lastActionUserId; }
			set { lastActionUserId = value; }
		}
		
		/// <summary>
        /// Combo box for Principal's LastActionUserId operators
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
				if( !string.IsNullOrEmpty( Password.Text ) ) {
					writer.Write( "{2} e.Password {0} '{1}' ",
							operatorsForPassword.SelectedValue, 
							Password.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Email.Text ) ) {
					writer.Write( "{2} e.Email {0} '{1}' ",
							operatorsForEmail.SelectedValue, 
							Email.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Ip.Text ) ) {
					writer.Write( "{2} e.Ip {0} '{1}' ",
							operatorsForIp.SelectedValue, 
							Ip.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RegistDate.Text ) ) {
					writer.Write( "{2} e.RegistDate {0} '{1}' ",
							operatorsForRegistDate.SelectedValue, 
							RegistDate.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( LastLogin.Text ) ) {
					writer.Write( "{2} e.LastLogin {0} '{1}' ",
							operatorsForLastLogin.SelectedValue, 
							LastLogin.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Approved.Text ) ) {
					writer.Write( "{2} e.Approved {0} '{1}' ",
							operatorsForApproved.SelectedValue, 
							Approved.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( IsOnline.Text ) ) {
					writer.Write( "{2} e.IsOnline {0} '{1}' ",
							operatorsForIsOnline.SelectedValue, 
							IsOnline.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Locked.Text ) ) {
					writer.Write( "{2} e.Locked {0} '{1}' ",
							operatorsForLocked.SelectedValue, 
							Locked.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( Locale.Text ) ) {
					writer.Write( "{2} e.Locale {0} '{1}' ",
							operatorsForLocale.SelectedValue, 
							Locale.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( ConfirmationCode.Text ) ) {
					writer.Write( "{2} e.ConfirmationCode {0} '{1}' ",
							operatorsForConfirmationCode.SelectedValue, 
							ConfirmationCode.Text, first ? "" : ","
						);
					first = false;
				}
				if( !string.IsNullOrEmpty( RawRoles.Text ) ) {
					writer.Write( "{2} e.RawRoles {0} '{1}' ",
							operatorsForRawRoles.SelectedValue, 
							RawRoles.Text, first ? "" : ","
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
					HttpContext.Current.Items[BasePagedList<Principal>.GetWhereKey("Principal")] = writer.ToString();
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
			Password.ID = "searchPassword";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Password</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForPassword ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Password );
			Controls.Add( new LiteralControl("</td><tr>") );
			Email.ID = "searchEmail";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Email</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForEmail ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Email );
			Controls.Add( new LiteralControl("</td><tr>") );
			Ip.ID = "searchIp";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Ip</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIp ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Ip );
			Controls.Add( new LiteralControl("</td><tr>") );
			RegistDate.ID = "searchRegistDate";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RegistDate</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRegistDate ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RegistDate );
			Controls.Add( new LiteralControl("</td><tr>") );
			LastLogin.ID = "searchLastLogin";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>LastLogin</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLastLogin ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( LastLogin );
			Controls.Add( new LiteralControl("</td><tr>") );
			Approved.ID = "searchApproved";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Approved</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForApproved ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Approved );
			Controls.Add( new LiteralControl("</td><tr>") );
			IsOnline.ID = "searchIsOnline";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>IsOnline</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForIsOnline ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( IsOnline );
			Controls.Add( new LiteralControl("</td><tr>") );
			Locked.ID = "searchLocked";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Locked</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLocked ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Locked );
			Controls.Add( new LiteralControl("</td><tr>") );
			Locale.ID = "searchLocale";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>Locale</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForLocale ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( Locale );
			Controls.Add( new LiteralControl("</td><tr>") );
			ConfirmationCode.ID = "searchConfirmationCode";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>ConfirmationCode</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForConfirmationCode ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( ConfirmationCode );
			Controls.Add( new LiteralControl("</td><tr>") );
			RawRoles.ID = "searchRawRoles";
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<td><b>RawRoles</b></td><td>") );
			Controls.Add( AddOperators( OperatorsForRawRoles ) );
			Controls.Add( new LiteralControl("</td><td>") );
			Controls.Add( RawRoles );
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
