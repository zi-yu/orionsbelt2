
using System;
using System.Web.UI;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Principal editor control
    /// </summary>
	public partial class PrincipalEditor : BaseEntityEditor<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalEditor () : base( Institutional.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Principal> Implementation

		/// <summary>
        /// Gets the current Principal
        /// </summary>
        /// <returns>The Principal</returns>
		protected override Principal GetSourceObject()
		{
			if( Source != SourceType.ContextUser ) {
				return base.GetSourceObject();
			}
			Principal principal = Context.User as Principal;
			if( principal == null ) {
				throw new Exception("Context.User it's not Principal");
			}
			return principal;
		}

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Password</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalPasswordEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Email</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEmailEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Ip</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIpEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RegistDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRegistDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastLogin</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastLoginEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Approved</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalApprovedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsOnline</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnlineEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Locked</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLockedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Locale</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocaleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ConfirmationCode</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalConfirmationCodeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RawRoles</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRawRolesEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Principal> Implementation
		
	};

}