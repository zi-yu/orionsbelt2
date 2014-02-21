
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of ActivatedPromotion in the data source
    /// </summary>
	public class ActivatedPromotionCount : BaseEntityCount<ActivatedPromotion> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public ActivatedPromotionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetActivatedPromotionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}