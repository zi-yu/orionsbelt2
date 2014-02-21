
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of UniverseSpecialSector in the data source
    /// </summary>
	public class UniverseSpecialSectorCount : BaseEntityCount<UniverseSpecialSector> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public UniverseSpecialSectorCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetUniverseSpecialSectorPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}