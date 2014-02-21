
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Payment editor control
    /// </summary>
	public partial class PaymentEditor : BaseEntityEditor<Payment> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PrincipalId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentPrincipalIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Method</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentMethodEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Request</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentRequestEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Response</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentResponseEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>RequestId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentRequestIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>VerifyState</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentVerifyStateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Parameters</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentParametersEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>ParentPayment</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentParentPaymentEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Ammount</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentAmmountEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Payment> Implementation
		
	};

}