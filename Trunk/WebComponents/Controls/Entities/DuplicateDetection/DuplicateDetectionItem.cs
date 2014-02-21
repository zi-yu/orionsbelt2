
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// DuplicateDetection control renderer
    /// </summary>
	public class DuplicateDetectionItem : BaseEntityItem<DuplicateDetection> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public DuplicateDetectionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetDuplicateDetectionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<DuplicateDetection> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Cheater</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionCheater () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Duplicate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionDuplicate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>FindType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionFindType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ExtraInfo</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionExtraInfo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Verified</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionVerified () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<DuplicateDetection> Implementation
		
	};

}
