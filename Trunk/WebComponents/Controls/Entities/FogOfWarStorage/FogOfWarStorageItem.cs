
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// FogOfWarStorage control renderer
    /// </summary>
	public class FogOfWarStorageItem : BaseEntityItem<FogOfWarStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FogOfWarStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFogOfWarStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<FogOfWarStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSystemX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSystemY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Sectors</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSectors () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasDiscoveredAll</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageHasDiscoveredAll () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>HasDiscoveredHalf</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageHasDiscoveredHalf () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Owner</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageOwner () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<FogOfWarStorage> Implementation
		
	};

}
