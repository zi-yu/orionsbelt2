
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlanetStorage control renderer
    /// </summary>
	public class PlanetStorageItem : BaseEntityItem<PlanetStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetStorageItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetStoragePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PlanetStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ProductionFactor</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageProductionFactor () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Modifiers</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageModifiers () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Richness</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageRichness () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Info</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageInfo () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Terrain</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageTerrain () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IsPrivate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageIsPrivate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSystemX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SystemY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSystemY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorX</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSectorX () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SectorY</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSectorY () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Score</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageScore () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Level</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastPillageTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastPillageTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastConquerTick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastConquerTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>FacilityLevel</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageFacilityLevel () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Player</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStoragePlayer () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Sector</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSector () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlanetStorage> Implementation
		
	};

}
