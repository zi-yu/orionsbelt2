
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of LogStorage in the data source
    /// </summary>
	public class LogStorageCount : BaseEntityCount<LogStorage> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public LogStorageCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetLogStoragePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}