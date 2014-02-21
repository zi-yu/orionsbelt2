
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Invoice control renderer
    /// </summary>
	public class InvoiceItem : BaseEntityItem<Invoice> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public InvoiceItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetInvoicePersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Invoice> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Identifier</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceIdentifier () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Name</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceName () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Nif</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceNif () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Money</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceMoney () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Country</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceCountry () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Transaction</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceTransaction () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Payment</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoicePayment () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new InvoiceLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Invoice> Implementation
		
	};

}
