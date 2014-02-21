
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// FogOfWarStorage editor control
    /// </summary>
	public partial class FogOfWarStorageEditor : BaseEntityEditor<FogOfWarStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FogOfWarStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFogOfWarStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSystemXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSystemYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Sectors</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageSectorsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasDiscoveredAll</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageHasDiscoveredAllEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>HasDiscoveredHalf</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageHasDiscoveredHalfEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Owner</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageOwnerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new FogOfWarStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<FogOfWarStorage> Implementation
		
	};

}