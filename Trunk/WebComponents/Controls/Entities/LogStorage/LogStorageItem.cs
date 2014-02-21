
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// LogStorage control renderer
    /// </summary>
	public class LogStorageItem : BaseEntityItem<LogStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public LogStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetLogStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<LogStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Date</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Username1</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUsername1 () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Url</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUrl () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Content</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageContent () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ExceptionInformation</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageExceptionInformation () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Ip</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageIp () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Username2</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUsername2 () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<LogStorage> Implementation
		
	};

}
