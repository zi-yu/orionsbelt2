using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of FogOfWarStorage 
    /// </summary>
	public class FogOfWarStoragePagedList : BasePagedList<FogOfWarStorage> {
		
		#region BasePagedList<FogOfWarStorage> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<FogOfWarStorage> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetFogOfWarStoragePersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "FogOfWarStorage";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			FogOfWarStorageItem entity = new FogOfWarStorageItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"10\"> Listing <i>") );
			Controls.Add( new FogOfWarStorageCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>FogOfWarStorage</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>SystemX</th>") );
			Controls.Add( new LiteralControl("<th>SystemY</th>") );
			Controls.Add( new LiteralControl("<th>Sectors</th>") );
			Controls.Add( new LiteralControl("<th>HasDiscoveredAll</th>") );
			Controls.Add( new LiteralControl("<th>HasDiscoveredHalf</th>") );
			Controls.Add( new LiteralControl("<th>Owner</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new FogOfWarStorageDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageSystemX () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageSystemY () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageSectors () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageHasDiscoveredAll () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageHasDiscoveredHalf () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageOwner () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new FogOfWarStorageDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<FogOfWarStorage> Implementation
		
	};

}