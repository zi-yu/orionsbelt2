
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Payment control renderer
    /// </summary>
	public class PaymentItem : BaseEntityItem<Payment> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Payment> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PrincipalId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentPrincipalId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Method</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentMethod () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Request</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentRequest () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Response</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentResponse () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>RequestId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentRequestId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>VerifyState</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentVerifyState () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Parameters</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentParameters () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>ParentPayment</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentParentPayment () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Ammount</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentAmmount () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Payment> Implementation
		
	};

}
