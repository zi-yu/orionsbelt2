using System;
using System.Collections.Generic;
using System.Web.UI;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Control that can render a paged collection of UniverseSpecialSector 
    /// </summary>
	public class UniverseSpecialSectorPagedList : BasePagedList<UniverseSpecialSector> {
		
		#region BasePagedList<UniverseSpecialSector> Implementation
		
		/// <summary>
        /// The current persistance object
        /// </summary>
		protected override IPersistance<UniverseSpecialSector> Persistance {
			get { 
				return OrionsBelt.DataAccessLayer.Persistance.Instance.GetUniverseSpecialSectorPersistance ();
			}
		}
		
		/// <summary>
        /// The current entity name
        /// </summary>
		protected override string EntityName { 
			get { 
				return "UniverseSpecialSector";
			}
		}
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			UniverseSpecialSectorItem entity = new UniverseSpecialSectorItem ();
		
			Controls.Add( new LiteralControl("<table>") );
			Controls.Add( new LiteralControl("<tr><th colspan=\"11\"> Listing <i>") );
			Controls.Add( new UniverseSpecialSectorCount () );
			Controls.Add( new LiteralControl("</i> entities of <i>UniverseSpecialSector</i></th></tr>") );
			Controls.Add( new LiteralControl("<tr>") );
			Controls.Add( new LiteralControl("<th>Id</th>") );
			Controls.Add( new LiteralControl("<th>SystemX</th>") );
			Controls.Add( new LiteralControl("<th>SystemY</th>") );
			Controls.Add( new LiteralControl("<th>SectorX</th>") );
			Controls.Add( new LiteralControl("<th>SectorY</th>") );
			Controls.Add( new LiteralControl("<th>Type</th>") );
			Controls.Add( new LiteralControl("<th>Owner</th>") );
			Controls.Add( new LiteralControl("<th>Sector</th>") );
			Controls.Add( new LiteralControl("<th>CreatedDate</th>") );
			Controls.Add( new LiteralControl("<th>UpdatedDate</th>") );
			Controls.Add( new LiteralControl("<th>LastActionUserId</th>") );
			Controls.Add( new LiteralControl("<th>") );
			Controls.Add( new UniverseSpecialSectorDeleteAll() );
			Controls.Add( new LiteralControl("</th>") );
			Controls.Add( new LiteralControl("</tr>") );
			entity.Controls.Add( new LiteralControl("<tr>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorSystemX () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorSystemY () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorSectorX () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorSectorY () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorType () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorOwner () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorSector () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorCreatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorUpdatedDate () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorLastActionUserId () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("<td>") );
			entity.Controls.Add( new UniverseSpecialSectorDelete () );
			entity.Controls.Add( new LiteralControl("</td>") );
			entity.Controls.Add( new LiteralControl("</tr>") );
			Controls.Add( entity );
			Controls.Add( new LiteralControl("</table>") );
			
		}
		
		#endregion BasePagedList<UniverseSpecialSector> Implementation
		
	};

}