
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PaymentDescription control renderer
    /// </summary>
	public class PaymentDescriptionItem : BaseEntityItem<PaymentDescription> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentDescriptionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentDescriptionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<PaymentDescription> Implementation
		
		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Type</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionType () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Amount</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionAmount () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Bonus</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionBonus () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Cost</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCost () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Locale</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionLocale () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Data</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionData () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Currency</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCurrency () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PaymentDescription> Implementation
		
	};

}
