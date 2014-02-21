
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// LogStorage editor control
    /// </summary>
	public partial class LogStorageEditor : BaseEntityEditor<LogStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public LogStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetLogStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Date</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Username1</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUsername1Editor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Url</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUrlEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Content</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageContentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ExceptionInformation</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageExceptionInformationEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Ip</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageIpEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Username2</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUsername2Editor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new LogStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<LogStorage> Implementation
		
	};

}