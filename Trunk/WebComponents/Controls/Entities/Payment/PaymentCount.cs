
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Payment in the data source
    /// </summary>
	public class PaymentCount : BaseEntityCount<Payment> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentPersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}