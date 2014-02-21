
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of TimedActionStorage in the data source
    /// </summary>
	public class TimedActionStorageCount : BaseEntityCount<TimedActionStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TimedActionStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTimedActionStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}