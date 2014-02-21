
using System;
using System.Web.UI;
using System.ComponentModel;
using Institutional.Core;
using Institutional.DataAccessLayer;

namespace Institutional.WebComponents.Controls {

	/// <summary>
    /// ExceptionInfo control renderer
    /// </summary>
	public class ExceptionInfoItem : BaseEntityItem<ExceptionInfo> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ExceptionInfoItem () : base( Institutional.DataAccessLayer.Persistance.Instance.GetExceptionInfoPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<ExceptionInfo> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Message</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoMessage () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Date</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Principal</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoPrincipal () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Url</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>StackTrace</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoStackTrace () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new ExceptionInfoLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<ExceptionInfo> Implementation
		
	};

}
