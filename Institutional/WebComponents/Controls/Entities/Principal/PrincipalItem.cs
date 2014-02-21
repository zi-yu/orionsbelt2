
using System;
using System.Web.UI;
using System.ComponentModel;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// Principal control renderer
    /// </summary>
	public class PrincipalItem : BaseEntityItem<Principal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PrincipalItem () : base( Institutional.DataAccessLayer.Persistance.Instance.GetPrincipalPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Principal> Implementation

		/// <summary>
        /// Gets the current Principal to render
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Password</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalPassword () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Email</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalEmail () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Ip</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIp () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RegistDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRegistDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastLogin</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastLogin () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Approved</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalApproved () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsOnline</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalIsOnline () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locked</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocked () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locale</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLocale () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ConfirmationCode</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalConfirmationCode () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RawRoles</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalRawRoles () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PrincipalLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Principal> Implementation
		
	};

}
