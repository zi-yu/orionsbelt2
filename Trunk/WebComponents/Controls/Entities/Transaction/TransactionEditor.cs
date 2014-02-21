
using System;
using System.Web.UI;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Transaction editor control
    /// </summary>
	public partial class TransactionEditor : BaseEntityEditor<Transaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TransactionEditor () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTransactionPersistance () )
		{
		}
		
		#endregion Control Fields
		
		#region BaseEntityItem<Transaction> Implementation

		/// <summary>
        /// Adds a default control tree
        /// </summary>
		protected override void AddDefaultControlTree()
		{
			Controls.Add( new LiteralControl("<dl>") );
			Controls.Add( new LiteralControl("<dt>Id</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>TransactionContext</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionTransactionContextEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>PrincipalIdSpend</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionPrincipalIdSpendEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IdentityTypeSpend</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentityTypeSpendEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IdentifierSpend</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentifierSpendEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreditsSpend</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreditsSpendEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>SpendCurrentCredits</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionSpendCurrentCreditsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IdentityTypeGain</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentityTypeGainEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>IdentifierGain</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentifierGainEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreditsGain</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreditsGainEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>GainCurrentCredits</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionGainCurrentCreditsEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>Tick</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionTickEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>CreatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>UpdatedDate</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionUpdatedDateEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>LastActionUserId</dt>") );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionLastActionUserIdEditor () );
			Controls.Add( new LiteralControl("</dd>") );
			Controls.Add( new LiteralControl("<dt>") );
			Controls.Add( new UpdateButton() );
			Controls.Add( new LiteralControl("</dt>") );
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Transaction> Implementation
		
	};

}