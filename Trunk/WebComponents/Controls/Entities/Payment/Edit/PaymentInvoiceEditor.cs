using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.ComponentModel;
using Loki.DataRepresentation;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Edits the Invoice of the Payment entity
    /// </summary>
	public class PaymentInvoiceEditor : 
			InvoiceItem, IEntityFieldEditor<Payment>, INamingContainer {

		#region Events
		
		/// <summary>
        /// Initializes this control
        /// </summary>
        /// <param name="args">Event arguments</param>
		protected override void OnInit(EventArgs args)
        {
			if( Source == SourceType.None ) {
				Source = SourceType.Choice;
			}
            base.OnInit(args);
        }
		
		#endregion Events

		#region IEntityFieldEditor<Invoice> Implementation
		
		/// <summary>
        /// Updates an Payment
        /// </summary>
        /// <param name="entity">An instance of Payment</param>
		public void Update( Payment entity )
		{
			// OneToMany
			System.Collections.Generic.IList<Invoice> list = entity.Invoice;
			list.Add(Current);
		}
		
		#endregion IEntityFieldEditor<Invoice> Implementation
		
	};

}
