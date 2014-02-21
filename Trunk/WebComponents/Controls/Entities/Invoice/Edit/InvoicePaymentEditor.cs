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
    /// Edits the Payment of the Invoice entity
    /// </summary>
	public class InvoicePaymentEditor : 
			PaymentItem, IEntityFieldEditor<Invoice>, INamingContainer {

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

		#region PaymentItem Implementation
		
		/// <summary>
        /// Obtains the current value via the parent control
        /// </summary>
        /// <returns>The current object</returns>
		protected override Payment GetSourceFromParent( IDescriptable descriptable )
        {
            Invoice entity = descriptable as Invoice;
            if (entity == null) {
                return null;
            }
            return entity.Payment;
        }

		#region Control unique identifier

		/// <summary>
        /// Gets the key string to represent this control object
        /// </summary>
        /// <returns>The key</returns>
		protected override string GetKey()
		{
			return "InvoicePayment";
		}
		
		#endregion Control unique identifier
		
		#endregion PaymentItem Implementation
		

		#region IEntityFieldEditor<Payment> Implementation
		
		/// <summary>
        /// Updates an Invoice
        /// </summary>
        /// <param name="entity">An instance of Invoice</param>
		public void Update( Invoice entity )
		{
			// ManyToOne
			FetchCurrent();
			entity.Payment = Current;
		}
		
		#endregion IEntityFieldEditor<Payment> Implementation
		
	};

}
