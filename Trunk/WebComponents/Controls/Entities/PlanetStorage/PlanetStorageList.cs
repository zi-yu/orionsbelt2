
using System;
using System.Collections.Generic;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a collection of PlanetStorage 
    /// </summary>
	public class PlanetStorageList : BaseList<PlanetStorage> {
	
		#region Abstract Members
		
		/// <summary>
        /// Gets the PlanetStorage collection
        /// </summary>
        /// <returns>The collection</returns>
		protected override IList<PlanetStorage> GetCollection()
		{
			using( IPlanetStoragePersistance persistance = Persistance.Instance.GetPlanetStoragePersistance() ) {
				return persistance.Select();
			}
		}
		
		#endregion Abstract Members
		
		#region BaseList<PlanetStorage> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			PlanetStorageItem entity = new PlanetStorageItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"24\"> Listing <i>") );
			Controls.Add( new PlanetStorageCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>PlanetStorage</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>Name</th>") );
			Controls.Add( new LiteralControl("<th>ProductionFactor</th>") );
			Controls.Add( new LiteralControl("<th>Modifiers</th>") );
			Controls.Add( new LiteralControl("<th>Richness</th>") );
			Controls.Add( new LiteralControl("<th>Info</th>") );
			Controls.Add( new LiteralControl("<th>Terrain</th>") );
			Controls.Add( new LiteralControl("<th>IsPrivate</th>") );
			Controls.Add( new LiteralControl("<th>SystemX</th>") );
			Controls.Add( new LiteralControl("<th>SystemY</th>") );
			Controls.Add( new LiteralControl("<th>SectorX</th>") );
			Controls.Add( new LiteralControl("<th>SectorY</th>") );
			Controls.Add( new LiteralControl("<th>Score</th>") );
			Controls.Add( new LiteralControl("<th>Level</th>") );
			Controls.Add( new LiteralControl("<th>LastPillageTick</th>") );
			Controls.Add( new LiteralControl("<th>LastConquerTick</th>") );
			Controls.Add( new LiteralControl("<th>FacilityLevel</th>") );
			Controls.Add( new LiteralControl("<th>Player</th>") );
			Controls.Add( new LiteralControl("<th>Sector</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new PlanetStorageDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageName () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageProductionFactor () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageModifiers () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageRichness () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageInfo () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageTerrain () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageIsPrivate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageSystemX () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageSystemY () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageSectorX () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageSectorY () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageScore () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageLastPillageTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageLastConquerTick () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageFacilityLevel () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStoragePlayer () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageSector () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new PlanetStorageDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BaseList<PlanetStorage> Implementation
		
	};

}