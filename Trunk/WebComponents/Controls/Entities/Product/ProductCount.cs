
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Product in the data source
    /// </summary>
	public class ProductCount : BaseEntityCount<Product> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ProductCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetProductPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}