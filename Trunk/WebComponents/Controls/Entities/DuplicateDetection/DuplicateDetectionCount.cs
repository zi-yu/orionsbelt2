
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of DuplicateDetection in the data source
    /// </summary>
	public class DuplicateDetectionCount : BaseEntityCount<DuplicateDetection> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public DuplicateDetectionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetDuplicateDetectionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}