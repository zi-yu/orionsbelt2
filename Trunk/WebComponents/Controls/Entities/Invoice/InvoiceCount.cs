
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Renders the total number of Invoice in the data source
    /// </summary>
	public class InvoiceCount : BaseEntityCount<Invoice> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public InvoiceCount () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetInvoicePersistance() )
		{
		}
		
		#endregion Control Fields
		
	};

}