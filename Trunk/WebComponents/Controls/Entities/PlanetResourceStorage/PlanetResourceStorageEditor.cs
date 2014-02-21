
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlanetResourceStorage editor control
    /// </summary>
	public partial class PlanetResourceStorageEditor : BaseEntityEditor<PlanetResourceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetResourceStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetResourceStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlanetResourceStorage> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Quantity</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageQuantityEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>State</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageStateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>QueueOrder</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageQueueOrderEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Slot</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageSlotEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>EndTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageEndTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Planet</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStoragePlanetEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Player</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStoragePlayerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlanetResourceStorage> Implementation
		
	};

}