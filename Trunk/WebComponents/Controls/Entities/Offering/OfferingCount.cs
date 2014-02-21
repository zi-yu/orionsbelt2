
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Offering in the data source
    /// </summary>
	public class OfferingCount : BaseEntityCount<Offering> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public OfferingCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetOfferingPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}