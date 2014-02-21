
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Promotion in the data source
    /// </summary>
	public class PromotionCount : BaseEntityCount<Promotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PromotionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPromotionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}