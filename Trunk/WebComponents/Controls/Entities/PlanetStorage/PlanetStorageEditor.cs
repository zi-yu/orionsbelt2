
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PlanetStorage editor control
    /// </summary>
	public partial class PlanetStorageEditor : BaseEntityEditor<PlanetStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PlanetStorageEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPlanetStoragePersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Name</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageNameEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ProductionFactor</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageProductionFactorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Modifiers</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageModifiersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Richness</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageRichnessEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Info</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageInfoEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Terrain</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageTerrainEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IsPrivate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageIsPrivateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSystemXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SystemY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSystemYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorX</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSectorXEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SectorY</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSectorYEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Score</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageScoreEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Level</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastPillageTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastPillageTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastConquerTick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastConquerTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>FacilityLevel</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageFacilityLevelEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Player</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStoragePlayerEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Sector</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageSectorEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PlanetStorageLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PlanetStorage> Implementation
		
	};

}