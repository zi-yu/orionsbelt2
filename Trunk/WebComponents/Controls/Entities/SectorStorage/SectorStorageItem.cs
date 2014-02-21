
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// SectorStorage control renderer
    /// </summary>
	public class SectorStorageItem : BaseEntityItem<SectorStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SectorStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSectorStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<SectorStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsStatic</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsStatic () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SubType</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSubType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSystemX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSystemY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSectorX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageSectorY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>AdditionalInformation</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageAdditionalInformation () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsInBattle</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsInBattle () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsConstructing</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsConstructing () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsMoving</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageIsMoving () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Alliance</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageAlliance () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new SectorStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<SectorStorage> Implementation
		
	};

}
