
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Country in the data source
    /// </summary>
	public class CountryCount : BaseEntityCount<Country> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public CountryCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetCountryPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}