
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Fleet in the data source
    /// </summary>
	public class FleetCount : BaseEntityCount<Fleet> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public FleetCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetFleetPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}