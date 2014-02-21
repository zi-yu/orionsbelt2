
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Medal in the data source
    /// </summary>
	public class MedalCount : BaseEntityCount<Medal> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public MedalCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetMedalPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}