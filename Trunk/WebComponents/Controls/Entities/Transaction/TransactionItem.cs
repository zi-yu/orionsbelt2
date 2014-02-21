
using System;
using System.Web.UI;
using System.ComponentModel;
using OrionsBelt.Core;
using OrionsBelt.DataAccessLayer;

namespace OrionsBelt.WebComponents.Controls {

	/// <summary>
    /// Transaction control renderer
    /// </summary>
	public class TransactionItem : BaseEntityItem<Transaction> {
	
		#region Ctor & Control Fields
		
		/// <summary>
        /// Constructor
        /// </summary>
		public TransactionItem () : base( OrionsBelt.DataAccessLayer.Persistance.Instance.GetTransactionPersistance () )
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
			Controls.Add( new LiteralControl( "<dt>Id</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>TransactionContext</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionTransactionContext () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>PrincipalIdSpend</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionPrincipalIdSpend () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IdentityTypeSpend</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentityTypeSpend () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IdentifierSpend</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentifierSpend () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreditsSpend</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreditsSpend () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>SpendCurrentCredits</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionSpendCurrentCredits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IdentityTypeGain</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentityTypeGain () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>IdentifierGain</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionIdentifierGain () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreditsGain</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreditsGain () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>GainCurrentCredits</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionGainCurrentCredits () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>Tick</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionTick () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>CreatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionCreatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>UpdatedDate</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionUpdatedDate () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl( "<dt>LastActionUserId</dt>" ) );
			Controls.Add( new LiteralControl("<dd>") );
			Controls.Add( new TransactionLastActionUserId () );
			Controls.Add( new LiteralControl("</dd>") );
			
			Controls.Add( new LiteralControl("</dl>") );
		}
		
		#endregion BaseEntityItem<Transaction> Implementation
		
	};

}
