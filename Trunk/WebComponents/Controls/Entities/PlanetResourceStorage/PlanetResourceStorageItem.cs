
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlanetResourceStorage control renderer
    /// </summary>
	public class PlanetResourceStorageItem : BaseEntityItem<PlanetResourceStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetResourceStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetResourceStoragePersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Quantity</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageQuantity () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>State</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageState () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>QueueOrder</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageQueueOrder () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Slot</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageSlot () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>EndTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageEndTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Planet</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStoragePlanet () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStoragePlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetResourceStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlanetResourceStorage> Implementation
		
	};

}
