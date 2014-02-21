
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of PaymentDescription in the data source
    /// </summary>
	public class PaymentDescriptionCount : BaseEntityCount<PaymentDescription> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentDescriptionCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentDescriptionPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}