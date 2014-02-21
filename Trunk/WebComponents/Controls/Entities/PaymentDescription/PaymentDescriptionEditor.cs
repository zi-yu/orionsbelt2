
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// PaymentDescription editor control
    /// </summary>
	public partial class PaymentDescriptionEditor : BaseEntityEditor<PaymentDescription> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public PaymentDescriptionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetPaymentDescriptionPersistance () )
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
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Type</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionTypeEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Amount</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionAmountEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Bonus</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionBonusEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Cost</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCostEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Locale</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionLocaleEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Data</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionDataEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Currency</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCurrencyEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new PaymentDescriptionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<PaymentDescription> Implementation
		
	};

}