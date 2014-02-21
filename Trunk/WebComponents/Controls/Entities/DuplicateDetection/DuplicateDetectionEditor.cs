
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// DuplicateDetection editor control
    /// </summary>
	public partial class DuplicateDetectionEditor : BaseEntityEditor<DuplicateDetection> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public DuplicateDetectionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetDuplicateDetectionPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Cheater</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionCheaterEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Duplicate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionDuplicateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>FindType</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionFindTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ExtraInfo</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionExtraInfoEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Verified</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionVerifiedEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new DuplicateDetectionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<DuplicateDetection> Implementation
		
	};

}