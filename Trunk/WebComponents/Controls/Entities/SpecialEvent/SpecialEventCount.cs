
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of SpecialEvent in the data source
    /// </summary>
	public class SpecialEventCount : BaseEntityCount<SpecialEvent> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public SpecialEventCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetSpecialEventPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}